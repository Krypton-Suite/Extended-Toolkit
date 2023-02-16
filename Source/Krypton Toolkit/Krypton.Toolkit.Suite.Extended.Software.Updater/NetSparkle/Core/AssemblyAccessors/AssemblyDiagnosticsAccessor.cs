#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
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
        public AssemblyDiagnosticsAccessor(string? assemblyName)
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