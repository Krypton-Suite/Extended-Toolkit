namespace ZipExtractor
{
    public static class ExtensionAPIs
    {
        public static bool IsDirectory(this ZipArchiveEntry entry) => string.IsNullOrEmpty(entry.Name) && (entry.FullName.EndsWith("/") || entry.FullName.EndsWith("\\"));
    }
}