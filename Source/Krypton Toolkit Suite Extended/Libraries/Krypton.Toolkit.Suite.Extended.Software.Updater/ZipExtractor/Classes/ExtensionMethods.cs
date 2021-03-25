#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

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