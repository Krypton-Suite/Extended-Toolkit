using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Krypton.Toolkit.Suite.Extended.Networking
{
    public interface IFTPClient : IDisposable
    {
        ILogger Logger { set; }

        bool IsConnected { get; }

        bool IsEncrypted { get; }

        bool IsAuthenticated { get; }

        string WorkingDirectory { get; }

        void Configure(FTPClientConfiguration configuration);

        Task LoginAsync();

        Task LogOutAsync();

        Task ChangeWorkingDirectoryAsync(string directory);

        Task CreateDirectoryAsync(string directory);

        Task RenameAsync(string from, string to);

        Task DeleteDirectoryAsync(string directory);

        Task<FTPResponse> SetClientName(string clientName);

        Task<Stream> OpenFileReadStreamAsync(string fileName);

        Task<Stream> OpenFileWriteStreamAsync(string fileName);

        Task CloseFileDataStreamAsync(CancellationToken ctsToken = default(CancellationToken));

        Task<ReadOnlyCollection<FTPNodeInformation>> ListAllAsync();

        Task<ReadOnlyCollection<FTPNodeInformation>> ListFilesAsync();

        Task<ReadOnlyCollection<FTPNodeInformation>> ListDirectoriesAsync();

        Task DeleteFileAsync(string fileName);

        Task SetTransferMode(FTPTransferMode transferMode, char secondType = '\0');

        Task<long> GetFileSizeAsync(string fileName);

        Task<FTPResponse> SendCommandAsync(FTPCommandEnvelope envelope, CancellationToken token = default(CancellationToken));

        Task<FTPResponse> SendCommandAsync(string command, CancellationToken token = default(CancellationToken));
    }
}