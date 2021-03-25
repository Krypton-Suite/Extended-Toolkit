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
    /// An assembly accessor
    /// </summary>
    public class AssemblyAccessor : IAssemblyAccessor
    {
        IAssemblyAccessor _internalAccessor = null;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="assemblyName">the assembly name</param>
        /// <param name="isReflectionAccesorUsed"><c>true</c> if reflection is used to access the attributes.</param>
        public AssemblyAccessor(string assemblyName, bool isReflectionAccesorUsed)
        {
            if (isReflectionAccesorUsed)
            {
                _internalAccessor = new AssemblyReflectionAccessor(assemblyName);
            }
            else
            {
                _internalAccessor = new AssemblyDiagnosticsAccessor(assemblyName);
            }
        }

        #region IAssemblyAccessor Members

        /// <summary>
        /// Gets the company
        /// </summary>
        public string AssemblyCompany => _internalAccessor.AssemblyCompany;

        /// <summary>
        /// Gets the copyright
        /// </summary>
        public string AssemblyCopyright => _internalAccessor.AssemblyCopyright;

        /// <summary>
        /// Gets the description
        /// </summary>
        public string AssemblyDescription => _internalAccessor.AssemblyDescription;

        /// <summary>
        /// Gets the product
        /// </summary>
        public string AssemblyProduct => _internalAccessor.AssemblyProduct;

        /// <summary>
        /// Gets the title
        /// </summary>
        public string AssemblyTitle => _internalAccessor.AssemblyTitle;

        /// <summary>
        /// Gets the version
        /// </summary>
        public string AssemblyVersion => _internalAccessor.AssemblyVersion;

        #endregion
    }
}