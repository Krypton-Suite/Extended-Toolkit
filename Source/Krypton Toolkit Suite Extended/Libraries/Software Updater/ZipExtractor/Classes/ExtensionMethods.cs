#if NET45
using System.IO.Compression;
#endif

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.ZipExtractor
{
    public static class ExtensionMethods
    {
#if NET45
        public static bool IsDirectory(this ZipArchiveEntry entry) => string.IsNullOrEmpty(entry.Name) && (entry.FullName.EndsWith("/") || entry.FullName.EndsWith(@"\"));
#endif
    }
}