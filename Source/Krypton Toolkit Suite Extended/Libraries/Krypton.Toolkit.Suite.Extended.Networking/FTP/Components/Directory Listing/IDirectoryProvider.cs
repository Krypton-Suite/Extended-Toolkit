using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Networking
{
    internal interface IDirectoryProvider
    {
        /// <summary>
        /// Lists all nodes in the current working directory
        /// </summary>
        /// <returns></returns>
        Task<ReadOnlyCollection<FTPNodeInformation>> ListAllAsync();

        /// <summary>
        /// Lists all files in the current working directory
        /// </summary>
        /// <returns></returns>
        Task<ReadOnlyCollection<FTPNodeInformation>> ListFilesAsync();

        /// <summary>
        /// Lists directories beneath the current working directory
        /// </summary>
        /// <returns></returns>
        Task<ReadOnlyCollection<FTPNodeInformation>> ListDirectoriesAsync();
    }
}