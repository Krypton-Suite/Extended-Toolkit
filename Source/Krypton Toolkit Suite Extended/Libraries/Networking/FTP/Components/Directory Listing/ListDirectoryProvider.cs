using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Networking
{
    internal class ListDirectoryProvider : DirectoryProviderBase
    {
        private readonly List<IListDirectoryParser> directoryParsers;

        public ListDirectoryProvider(FTPClient ftpClient, ILogger logger, FTPClientConfiguration configuration)
        {
            this.ftpClient = ftpClient;
            this.logger = logger;
            this.configuration = configuration;

            directoryParsers = new List<IListDirectoryParser>
            {
                new UnixDirectoryParser( logger ),
                new DOSDirectoryParser( logger ),
            };
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
                return await ListNodesAsync();
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
                return await ListNodesAsync(FTPNodeType.FILE);
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
                return await ListNodesAsync(FTPNodeType.DIRECTORY);
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
        private async Task<ReadOnlyCollection<FTPNodeInformation>> ListNodesAsync(FTPNodeType? ftpNodeType = null)
        {
            EnsureLoggedIn();
            logger?.LogDebug($"[ListDirectoryProvider] Listing {ftpNodeType}");

            try
            {
                stream = await ftpClient.ConnectDataStreamAsync();

                var result = await ftpClient.ControlStream.SendCommandAsync(new FTPCommandEnvelope
                {
                    FtpCommand = FTPCommand.LIST
                });

                if ((result.FtpStatusCode != FTPStatusCode.DATAALREADYOPEN) && (result.FtpStatusCode != FTPStatusCode.OPENINGDATA))
                    throw new FTPException("Could not retrieve directory listing " + result.ResponseMessage);

                var directoryListing = RetrieveDirectoryListing();

                var nodes = ParseLines(directoryListing.ToList().AsReadOnly())
                    .Where(x => !ftpNodeType.HasValue || x.NodeType == ftpNodeType)
                    .ToList();

                return nodes.AsReadOnly();
            }
            finally
            {
                stream.Dispose();
            }
        }

        private IEnumerable<FTPNodeInformation> ParseLines(IReadOnlyList<string> lines)
        {
            if (!lines.Any())
                yield break;

            var parser = directoryParsers.FirstOrDefault(x => x.Test(lines[0]));

            if (parser == null)
                yield break;

            foreach (string line in lines)
            {
                var parsed = parser.Parse(line);

                if (parsed != null)
                    yield return parsed;
            }
        }
    }
}