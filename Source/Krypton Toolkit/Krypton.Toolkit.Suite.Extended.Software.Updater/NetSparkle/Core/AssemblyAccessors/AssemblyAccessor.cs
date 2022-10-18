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