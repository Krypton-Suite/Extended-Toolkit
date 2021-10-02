#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.NetSparkle
{
    /// <summary>
    /// A diagnostic accessor
    /// </summary>
    public class AssemblyDiagnosticsAccessor : IAssemblyAccessor
    {
        private string fileVersion;
        private string productVersion;
        private string productName;
        private string companyName;
        private string legalCopyright;
        private string fileDescription;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="assemblyName">the assembly name</param>
        public AssemblyDiagnosticsAccessor(string assemblyName)
        {
            if (assemblyName != null)
            {
                string absolutePath = Path.GetFullPath(assemblyName);
                if (!File.Exists(absolutePath))
                {
                    throw new FileNotFoundException();
                }
                var info = FileVersionInfo.GetVersionInfo(assemblyName);
                fileVersion = info.FileVersion;
                productVersion = info.ProductVersion;
                productName = info.ProductName;
                companyName = info.CompanyName;
                legalCopyright = info.LegalCopyright;
                fileDescription = info.FileDescription;
            }
        }

        #region Assembly Attribute Accessors

        /// <summary>
        /// Gets the Title
        /// </summary>
        public string AssemblyTitle => productName ?? "";

        /// <summary>
        /// Gets the version
        /// </summary>
        public string AssemblyVersion => fileVersion;

        /// <summary>
        /// Gets the description
        /// </summary>
        public string AssemblyDescription => fileDescription;

        /// <summary>
        /// gets the product
        /// </summary>
        public string AssemblyProduct => productName;

        /// <summary>
        /// Gets the copyright
        /// </summary>
        public string AssemblyCopyright => legalCopyright;

        /// <summary>
        /// Gets the company
        /// </summary>
        public string AssemblyCompany => companyName;
        #endregion
    }
}