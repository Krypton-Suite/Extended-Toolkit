using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Networking
{
    internal class MlsdDirectoryProvider : DirectoryProviderBase
    {
        public MlsdDirectoryProvider(FTPClient ftpClient, ILogger logger, FTPClientConfiguration configuration)
        {
            this.ftpClient = ftpClient;
            this.configuration = configuration;
            this.logger = logger;
        }

        private void EnsureLoggedIn()
        {
            if (!ftpClient.IsConnected || !ftpClient.IsAuthenticated)
                throw new FTPException("User must be logged in");
        }

        public override async Task<ReadOnlyCollection<FTPNodeInformation>> ListAllAsync()
        {
            try
            {
                await ftpClient.dataSocketSemaphore.WaitAsync();
                return await ListNodeTypeAsync();
            }
            finally
            {
                ftpClient.dataSocketSemaphore.Release();
            }
        }

        public override async Task<ReadOnlyCollection<FTPNodeInformation>> ListFilesAsync()
        {
            try
            {
                await ftpClient.dataSocketSemaphore.WaitAsync();
                return await ListNodeTypeAsync(FTPNodeType.FILE);
            }
            finally
            {
                ftpClient.dataSocketSemaphore.Release();
            }
        }

        public override async Task<ReadOnlyCollection<FTPNodeInformation>> ListDirectoriesAsync()
        {
            try
            {
                await ftpClient.dataSocketSemaphore.WaitAsync();
                return await ListNodeTypeAsync(FTPNodeType.DIRECTORY);
            }
            finally
            {
                ftpClient.dataSocketSemaphore.Release();
            }
        }

        /// <summary>
        /// Lists all nodes (files and directories) in the current working directory
        /// </summary>
        /// <param name="ftpNodeType"></param>
        /// <returns></returns>
        private async Task<ReadOnlyCollection<FTPNodeInformation>> ListNodeTypeAsync(FTPNodeType? ftpNodeType = null)
        {
            string nodeTypeString = !ftpNodeType.HasValue
                ? "all"
                : ftpNodeType.Value == FTPNodeType.FILE
                    ? "file"
                    : "dir";

            logger?.LogDebug($"[MlsdDirectoryProvider] Listing {ftpNodeType}");

            EnsureLoggedIn();

            try
            {
                stream = await ftpClient.ConnectDataStreamAsync();
                if (stream == null)
                    throw new FTPException("Could not establish a data connection");

                var result = await ftpClient.ControlStream.SendCommandAsync(FTPCommand.MLSD);
                if ((result.FtpStatusCode != FTPStatusCode.DATAALREADYOPEN) && (result.FtpStatusCode != FTPStatusCode.OPENINGDATA) && (result.FtpStatusCode != FTPStatusCode.CLOSINGDATA))
                    throw new FTPException("Could not retrieve directory listing " + result.ResponseMessage);

                var directoryListing = RetrieveDirectoryListing().ToList();

                var nodes = (from node in directoryListing
                             where !node.IsNullOrWhiteSpace()
                             where !ftpNodeType.HasValue || node.Contains($"type={nodeTypeString}")
                             select node.ToFtpNode())
                    .ToList();


                return nodes.AsReadOnly();
            }
            finally
            {
                stream?.Dispose();
                stream = null;
            }
        }
    }
}