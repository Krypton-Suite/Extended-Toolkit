namespace ZipExtractor
{
    public static class ExtensionAPIs
    {
        /// <summary>Determines whether this instance is directory.</summary>
        /// <param name="entry">The entry.</param>
        /// <returns><c>true</c> if the specified entry is directory; otherwise, <c>false</c>.</returns>
        public static bool IsDirectory(this ZipArchiveEntry entry) => string.IsNullOrEmpty(entry.Name) && (entry.FullName.EndsWith('/') || entry.FullName.EndsWith('\\'));
    }
}