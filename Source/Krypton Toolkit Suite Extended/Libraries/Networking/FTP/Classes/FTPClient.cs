using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Networking
{
    public class FTPClient : IFTPClient
    {
        private IDirectoryProvider directoryProvider;
        private ILogger logger;
        private Stream dataStream;
        internal readonly SemaphoreSlim dataSocketSemaphore = new SemaphoreSlim(1, 1);
        public FTPClientConfiguration Configuration { get; private set; }

        internal IEnumerable<string> Features { get; private set; }
        internal FTPControlStream ControlStream { get; private set; }
        public bool IsConnected => ControlStream != null && ControlStream.IsConnected;
        public bool IsEncrypted => ControlStream != null && ControlStream.IsEncrypted;
        public bool IsAuthenticated { get; private set; }
        public string WorkingDirectory { get; private set; } = "/";

        public ILogger Logger
        {
            private get { return logger; }
            set
            {
                logger = value;
                ControlStream.Logger = value;
            }
        }

        public FTPClient() { }

        public FTPClient(FTPClientConfiguration configuration)
        {
            Configure(configuration);
        }

        public void Configure(FTPClientConfiguration configuration)
        {
            Configuration = configuration;

            if (configuration.Host == null)
                throw new ArgumentNullException(nameof(configuration.Host));

            if (Uri.IsWellFormedUriString(configuration.Host, UriKind.Absolute))
            {
                configuration.Host = new Uri(configuration.Host).Host;
            }


            ControlStream = new FTPControlStream(Configuration, new DnsResolver());
            Configuration.BaseDirectory = $"/{Configuration.BaseDirectory.TrimStart('/')}";
        }

        /// <summary>
        ///     Attempts to log the user in to the FTP Server
        /// </summary>
        /// <returns></returns>
        public async Task LoginAsync()
        {
            if (IsConnected)
                await LogOutAsync();

            string username = string.IsNullOrWhiteSpace(Configuration.Username)
                ? Constants.ANONYMOUS_USER
                : Configuration.Username;

            await ControlStream.ConnectAsync();

            var usrResponse = await ControlStream.SendCommandAsync(new FTPCommandEnvelope
            {
                FTPCommand = FTPCommand.USER,
                Data = username
            });

            await BailIfResponseNotAsync(usrResponse, FTPStatusCode.SENDUSERCOMMAND, FTPStatusCode.SENDPASSWORDCOMMAND, FTPStatusCode.LOGGEDINPROCEED);

            var passResponse = await ControlStream.SendCommandAsync(new FTPCommandEnvelope
            {
                FTPCommand = FTPCommand.PASS,
                Data = username != Constants.ANONYMOUS_USER ? Configuration.Password : string.Empty
            });

            await BailIfResponseNotAsync(passResponse, FTPStatusCode.LoggedInProceed);
            IsAuthenticated = true;

            if (ControlStream.IsEncrypted)
            {
                await ControlStream.SendCommandAsync(new FTPCommandEnvelope
                {
                    FTPCommand = FTPCommand.PBSZ,
                    Data = "0"
                });

                await ControlStream.SendCommandAsync(new FTPCommandEnvelope
                {
                    FTPCommand = FTPCommand.PROT,
                    Data = "P"
                });
            }

            Features = await DetermineFeaturesAsync();
            directoryProvider = DetermineDirectoryProvider();
            await EnableUTF8IfPossible();
            await SetTransferMode(Configuration.Mode, Configuration.ModeSecondType);

            if (Configuration.BaseDirectory != "/")
            {
                await CreateDirectoryAsync(Configuration.BaseDirectory);
            }

            await ChangeWorkingDirectoryAsync(Configuration.BaseDirectory);
        }

        /// <summary>
        ///     Attemps to log the user out asynchronously, sends the QUIT command and terminates the command socket.
        /// </summary>
        public async Task LogOutAsync()
        {
            await IgnoreStaleData();
            if (!IsConnected)
                return;

            Logger?.LogTrace("[FTPClient] Logging out");
            await ControlStream.SendCommandAsync(FTPCommand.QUIT);
            ControlStream.Disconnect();
            IsAuthenticated = false;
        }

        /// <summary>
        /// Changes the working directory to the given value for the current session
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        public async Task ChangeWorkingDirectoryAsync(string directory)
        {
            Logger?.LogTrace($"[FTPClient] changing directory to {directory}");
            if (string.IsNullOrWhiteSpace(directory) || directory.Equals("."))
                throw new ArgumentOutOfRangeException(nameof(directory), "Directory supplied was incorrect");

            EnsureLoggedIn();

            var response = await ControlStream.SendCommandAsync(new FTPCommandEnvelope
            {
                FTPCommand = FTPCommand.CWD,
                Data = directory
            });

            if (!response.IsSuccess)
                throw new FTPException(response.ResponseMessage);

            var pwdResponse = await ControlStream.SendCommandAsync(FTPCommand.PWD);

            if (!response.IsSuccess)
                throw new FTPException(response.ResponseMessage);

            WorkingDirectory = pwdResponse.ResponseMessage.Split('"')[1];
        }

        /// <summary>
        /// Creates a directory on the FTP Server
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        public async Task CreateDirectoryAsync(string directory)
        {
            if (string.IsNullOrWhiteSpace(directory) || directory.Equals("."))
                throw new ArgumentOutOfRangeException(nameof(directory), "Directory supplied was not valid");

            Logger?.LogDebug($"[FTPClient] Creating directory {directory}");

            EnsureLoggedIn();

            await CreateDirectoryStructureRecursively(directory.Split('/'), directory.StartsWith("/"));
        }

        /// <summary>
        /// Renames a file on the FTP server
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public async Task RenameAsync(string from, string to)
        {
            EnsureLoggedIn();
            Logger?.LogDebug($"[FTPClient] Renaming from {from}, to {to}");
            var renameFromResponse = await ControlStream.SendCommandAsync(new FTPCommandEnvelope
            {
                FTPCommand = FTPCommand.RNFR,
                Data = from
            });

            if (renameFromResponse.FTPStatusCode != FTPStatusCode.FileCommandPending)
                throw new FTPException(renameFromResponse.ResponseMessage);

            var renameToResponse = await ControlStream.SendCommandAsync(new FTPCommandEnvelope
            {
                FTPCommand = FTPCommand.RNTO,
                Data = to
            });

            if (renameToResponse.FTPStatusCode != FTPStatusCode.FILEACTIONOK && renameToResponse.FTPStatusCode != FTPStatusCode.CLOSINGDATA)
                throw new FTPException(renameFromResponse.ResponseMessage);
        }

        /// <summary>
        /// Deletes the given directory from the FTP server
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        public async Task DeleteDirectoryAsync(string directory)
        {
            if (string.IsNullOrWhiteSpace(directory) || directory.Equals("."))
                throw new ArgumentOutOfRangeException(nameof(directory), "Directory supplied was not valid");

            if (directory == "/")
                return;

            Logger?.LogDebug($"[FTPClient] Deleting directory {directory}");

            EnsureLoggedIn();

            var rmdResponse = await ControlStream.SendCommandAsync(new FTPCommandEnvelope
            {
                FTPCommand = FTPCommand.RMD,
                Data = directory
            });

            switch (rmdResponse.FTPStatusCode)
            {
                case FTPStatusCode.COMMANDOK:
                case FTPStatusCode.FILEACTIONOK:
                    return;

                case FTPStatusCode.ActionNotTakenFileUnavailable:
                    await DeleteNonEmptyDirectory(directory);
                    return;

                default:
                    throw new FTPException(rmdResponse.ResponseMessage);
            }
        }

        /// <summary>
        /// Deletes the given directory from the FTP server
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        private async Task DeleteNonEmptyDirectory(string directory)
        {
            await ChangeWorkingDirectoryAsync(directory);

            var allNodes = await ListAllAsync();

            foreach (var file in allNodes.Where(x => x.NodeType == FTPNodeType.FILE))
            {
                await DeleteFileAsync(file.Name);
            }

            foreach (var dir in allNodes.Where(x => x.NodeType == FTPNodeType.DIRECTORY))
            {
                await DeleteDirectoryAsync(dir.Name);
            }

            await ChangeWorkingDirectoryAsync("..");
            await DeleteDirectoryAsync(directory);
        }

        /// <summary>
        /// Informs the FTP server of the client being used
        /// </summary>
        /// <param name="clientName"></param>
        /// <returns></returns>
        public async Task<FTPResponse> SetClientName(string clientName)
        {
            EnsureLoggedIn();
            Logger?.LogDebug($"[FTPClient] Setting client name to {clientName}");

            return await ControlStream.SendCommandAsync(new FTPCommandEnvelope
            {
                FTPCommand = FTPCommand.CLNT,
                Data = clientName
            });
        }

        /// <summary>
        /// Provides a stream which contains the data of the given filename on the FTP server
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public async Task<Stream> OpenFileReadStreamAsync(string fileName)
        {
            Logger?.LogDebug($"[FTPClient] Opening file read stream for {fileName}");

            return new FTPDataStream(await OpenFileStreamAsync(fileName, FTPCommand.RETR), this, Logger);
        }

        /// <summary>
        /// Provides a stream which can be written to
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public async Task<Stream> OpenFileWriteStreamAsync(string fileName)
        {
            string filePath = WorkingDirectory.CombineAsUriWith(fileName);
            Logger?.LogDebug($"[FTPClient] Opening file read stream for {filePath}");
            var segments = filePath.Split('/')
                                   .Where(x => !x.IsNullOrWhiteSpace())
                                   .ToList();
            await CreateDirectoryStructureRecursively(segments.Take(segments.Count - 1).ToArray(), filePath.StartsWith("/"));
            return new FTPDataStream(await OpenFileStreamAsync(filePath, FTPCommand.STOR), this, Logger);
        }

        /// <summary>
        /// Closes the write stream and associated socket (if open), 
        /// </summary>
        /// <param name="ctsToken"></param>
        /// <returns></returns>
        public async Task CloseFileDataStreamAsync(CancellationToken ctsToken = default(CancellationToken))
        {
            Logger?.LogTrace("[FTPClient] Closing write file stream");
            dataStream.Dispose();

            if (ControlStream != null)
                await ControlStream.GetResponseAsync(ctsToken);
        }

        /// <summary>
        /// Lists all files in the current working directory
        /// </summary>
        /// <returns></returns>
        public async Task<ReadOnlyCollection<FTPNodeInformation>> ListAllAsync()
        {
            try
            {
                EnsureLoggedIn();
                Logger?.LogDebug($"[FTPClient] Listing files in {WorkingDirectory}");
                return await directoryProvider.ListAllAsync();
            }
            finally
            {
                await ControlStream.GetResponseAsync();
            }
        }

        /// <summary>
        /// Lists all files in the current working directory
        /// </summary>
        /// <returns></returns>
        public async Task<ReadOnlyCollection<FTPNodeInformation>> ListFilesAsync()
        {
            try
            {
                EnsureLoggedIn();
                Logger?.LogDebug($"[FTPClient] Listing files in {WorkingDirectory}");
                return await directoryProvider.ListFilesAsync();
            }
            finally
            {
                await ControlStream.GetResponseAsync();
            }
        }

        /// <summary>
        /// Lists all directories in the current working directory
        /// </summary>
        /// <returns></returns>
        public async Task<ReadOnlyCollection<FTPNodeInformation>> ListDirectoriesAsync()
        {
            try
            {
                EnsureLoggedIn();
                Logger?.LogDebug($"[FTPClient] Listing directories in {WorkingDirectory}");
                return await directoryProvider.ListDirectoriesAsync();
            }
            finally
            {
                await ControlStream.GetResponseAsync();
            }
        }


        /// <summary>
        /// Lists all directories in the current working directory
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public async Task DeleteFileAsync(string fileName)
        {
            EnsureLoggedIn();
            Logger?.LogDebug($"[FTPClient] Deleting file {fileName}");
            var response = await ControlStream.SendCommandAsync(new FTPCommandEnvelope
            {
                FTPCommand = FTPCommand.DELE,
                Data = fileName
            });

            if (!response.IsSuccess)
                throw new FTPException(response.ResponseMessage);
        }

        /// <summary>
        /// Determines the file size of the given file
        /// </summary>
        /// <param name="transferMode"></param>
        /// <param name="secondType"></param>
        /// <returns></returns>
        public async Task SetTransferMode(FTPTransferMode transferMode, char secondType = '\0')
        {
            EnsureLoggedIn();
            Logger?.LogTrace($"[FTPClient] Setting transfer mode {transferMode}, {secondType}");
            var response = await ControlStream.SendCommandAsync(new FTPCommandEnvelope
            {
                FTPCommand = FTPCommand.TYPE,
                Data = secondType != '\0'
                    ? $"{(char)transferMode} {secondType}"
                    : $"{(char)transferMode}"
            });

            if (!response.IsSuccess)
                throw new FTPException(response.ResponseMessage);
        }

        /// <summary>
        /// Determines the file size of the given file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public async Task<long> GetFileSizeAsync(string fileName)
        {
            EnsureLoggedIn();
            Logger?.LogDebug($"[FTPClient] Getting file size for {fileName}");
            var sizeResponse = await ControlStream.SendCommandAsync(new FTPCommandEnvelope
            {
                FTPCommand = FTPCommand.SIZE,
                Data = fileName
            });

            if (sizeResponse.FTPStatusCode != FTPStatusCode.FILESTATUS)
                throw new FTPException(sizeResponse.ResponseMessage);

            long fileSize = long.Parse(sizeResponse.ResponseMessage);
            return fileSize;
        }

        /// <summary>
        /// Determines the type of directory listing the FTP server will return, and set the appropriate parser
        /// </summary>
        /// <returns></returns>
        private IDirectoryProvider DetermineDirectoryProvider()
        {
            Logger?.LogTrace("[FTPClient] Determining directory provider");
            if (this.UsesMlsd())
                return new MlsdDirectoryProvider(this, Logger, Configuration);

            return new ListDirectoryProvider(this, Logger, Configuration);
        }

        private async Task<IEnumerable<string>> DetermineFeaturesAsync()
        {
            EnsureLoggedIn();
            Logger?.LogTrace("[FTPClient] Determining features");
            var response = await ControlStream.SendCommandAsync(FTPCommand.FEAT);

            if (response.FTPStatusCode == FTPStatusCode.COMMANDSYNTAXERROR || response.FTPStatusCode == FTPStatusCode.COMMANDNOTIMPLEMENTED)
                return Enumerable.Empty<string>();

            var features = response.Data.Where(x => !x.StartsWith(((int)FTPStatusCode.SYSTEMHELPREPLY).ToString()) && !x.IsNullOrWhiteSpace())
                                   .Select(x => x.Replace(Constants.CARRIAGE_RETURN, string.Empty).Trim())
                                   .ToList();

            return features;
        }

        /// <summary>
        /// Creates a directory structure recursively given a path
        /// </summary>
        /// <param name="directories"></param>
        /// <param name="isRootedPath"></param>
        /// <returns></returns>
        private async Task CreateDirectoryStructureRecursively(IReadOnlyCollection<string> directories, bool isRootedPath)
        {
            Logger?.LogDebug($"[FTPClient] Creating directory structure recursively {string.Join("/", directories)}");
            string originalPath = WorkingDirectory;

            if (isRootedPath && directories.Any())
                await ChangeWorkingDirectoryAsync("/");

            if (!directories.Any())
                return;

            if (directories.Count == 1)
            {
                await ControlStream.SendCommandAsync(new FTPCommandEnvelope
                {
                    FTPCommand = FTPCommand.MKD,
                    Data = directories.First()
                });

                await ChangeWorkingDirectoryAsync(originalPath);
                return;
            }

            foreach (string directory in directories)
            {
                if (string.IsNullOrWhiteSpace(directory))
                    continue;

                var response = await ControlStream.SendCommandAsync(new FTPCommandEnvelope
                {
                    FTPCommand = FTPCommand.CWD,
                    Data = directory
                });

                if (response.FTPStatusCode != FTPStatusCode.ACTIONNOTTAKENFILEUNAVAILABLE)
                    continue;

                await ControlStream.SendCommandAsync(new FTPCommandEnvelope
                {
                    FTPCommand = FTPCommand.MKD,
                    Data = directory
                });
                await ControlStream.SendCommandAsync(new FTPCommandEnvelope
                {
                    FTPCommand = FTPCommand.CWD,
                    Data = directory
                });
            }

            await ChangeWorkingDirectoryAsync(originalPath);
        }


        /// <summary>
        /// Opens a filestream to the given filename
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        private async Task<Stream> OpenFileStreamAsync(string fileName, FTPCommand command)
        {
            EnsureLoggedIn();
            Logger?.LogDebug($"[FTPClient] Opening filestream for {fileName}, {command}");
            dataStream = await ConnectDataStreamAsync();

            var retrResponse = await ControlStream.SendCommandAsync(new FTPCommandEnvelope
            {
                FTPCommand = command,
                Data = fileName
            });

            if ((retrResponse.FTPStatusCode != FTPStatusCode.DATAALREADYOPEN) &&
                 (retrResponse.FTPStatusCode != FTPStatusCode.OPENINGDATA) &&
                 (retrResponse.FTPStatusCode != FTPStatusCode.CLOSINGDATA))
                throw new FTPException(retrResponse.ResponseMessage);

            return dataStream;
        }

        /// <summary>
        /// Checks if the command socket is open and that an authenticated session is active
        /// </summary>
        private void EnsureLoggedIn()
        {
            if (!IsConnected || !IsAuthenticated)
                throw new FTPException("User must be logged in");
        }

        /// <summary>
        /// Produces a data socket using Passive (PASV) or Extended Passive (EPSV) mode
        /// </summary>
        /// <returns></returns>
        internal async Task<Stream> ConnectDataStreamAsync()
        {
            Logger?.LogTrace("[FTPClient] Connecting to a data socket");

            var epsvResult = await ControlStream.SendCommandAsync(FTPCommand.EPSV);

            int? passivePortNumber;
            if (epsvResult.FTPStatusCode == FTPStatusCode.ENTERINGEXTENDEDPASSIVE)
            {
                passivePortNumber = epsvResult.ResponseMessage.ExtractEpsvPortNumber();
            }
            else
            {
                // EPSV failed - try regular PASV
                var pasvResult = await ControlStream.SendCommandAsync(FTPCommand.PASV);
                if (pasvResult.FTPStatusCode != FTPStatusCode.ENTERINGPASSIVE)
                    throw new FTPException(pasvResult.ResponseMessage);

                passivePortNumber = pasvResult.ResponseMessage.ExtractPasvPortNumber();
            }

            if (!passivePortNumber.HasValue)
                throw new FTPException("Could not determine EPSV/PASV data port");

            return await ControlStream.OpenDataStreamAsync(Configuration.Host, passivePortNumber.Value, CancellationToken.None);
        }

        /// <summary>
        /// Throws an exception if the server response is not one of the given acceptable codes
        /// </summary>
        /// <param name="response"></param>
        /// <param name="codes"></param>
        /// <returns></returns>
        private async Task BailIfResponseNotAsync(FTPResponse response, params FTPStatusCode[] codes)
        {
            if (codes.Any(x => x == response.FTPStatusCode))
                return;

            Logger?.LogDebug($"Bailing due to response codes being {response.FTPStatusCode}, which is not one of: [{string.Join(",", codes)}]");

            await LogOutAsync();
            throw new FTPException(response.ResponseMessage);
        }

        /// <summary>
        /// Determine if the FTP server supports UTF8 encoding, and set it to the default if possible
        /// </summary>
        /// <returns></returns>
        private async Task EnableUTF8IfPossible()
        {
            if (Equals(ControlStream.Encoding, Encoding.ASCII) && Features.Any(x => x == Constants.UTF8))
            {
                ControlStream.Encoding = Encoding.UTF8;
            }

            if (Equals(ControlStream.Encoding, Encoding.UTF8))
            {
                // If the server supports UTF8 it should already be enabled and this
                // command should not matter however there are conflicting drafts
                // about this so we'll just execute it to be safe. 
                await ControlStream.SendCommandAsync("OPTS UTF8 ON");
            }
        }

        public async Task<FTPResponse> SendCommandAsync(FTPCommandEnvelope envelope, CancellationToken token = default(CancellationToken))
        {
            return await ControlStream.SendCommandAsync(envelope, token);
        }

        public async Task<FTPResponse> SendCommandAsync(string command, CancellationToken token = default(CancellationToken))
        {
            return await ControlStream.SendCommandAsync(command, token);
        }

        /// <summary>
        /// Ignore any stale data we may have waiting on the stream
        /// </summary>
        /// <returns></returns>
        private async Task IgnoreStaleData()
        {
            if (IsConnected && ControlStream.SocketDataAvailable())
            {
                var staleData = await ControlStream.GetResponseAsync();
                Logger?.LogWarning($"Stale data detected: {staleData.ResponseMessage}");
            }
        }

        public void Dispose()
        {
            Logger?.LogDebug("Disposing of FTPClient");
            Task.WaitAny(LogOutAsync());
            ControlStream?.Dispose();
            dataSocketSemaphore?.Dispose();
        }
    }
}