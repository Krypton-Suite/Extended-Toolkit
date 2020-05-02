using System.Diagnostics;

namespace Krypton.Toolkit.Extended.Common
{
    public class AssemblyManager
    {
        public AssemblyManager()
        {

        }

        /// <summary>Gets the file version information.</summary>
        /// <param name="assemblyPath">The assembly path.</param>
        /// <returns>The file version of the selected assembly.</returns>
        public static FileVersionInfo GetFileVersionInformation(string assemblyPath) => FileVersionInfo.GetVersionInfo(assemblyPath);
    }
}