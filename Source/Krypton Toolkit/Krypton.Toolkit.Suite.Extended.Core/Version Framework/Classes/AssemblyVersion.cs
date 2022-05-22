#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public class AssemblyVersion
    {
        #region Variables
        private string _errorMessage;
        private AssemblyInformation _assemblyInformation;
        private List<AssemblyInformation> _referencesList;
        #endregion

        #region Properties
        public string ErrorMessage { get { return _errorMessage; } set { _errorMessage = value; } }

        public AssemblyInformation CurrentAssemblyInformation { get { return _assemblyInformation; } set { _assemblyInformation = value; } }

        public List<AssemblyInformation> ReferenceAssembly { get { return _referencesList; } set { _referencesList = value; } }
        #endregion

        #region Constructor
        public AssemblyVersion()
        {

        }
        #endregion

        #region Methods        
        /// <summary>
        /// Gets the reference assembly.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns></returns>
        public bool GetReferenceAssembly(Assembly assembly)
        {
            try
            {
                AssemblyName[] assemblyNameList = assembly.GetReferencedAssemblies();

                if (assemblyNameList.Length > 0)
                {
                    AssemblyInformation information = null;

                    ReferenceAssembly = new List<AssemblyInformation>();

                    for (int i = 0; i < assemblyNameList.Length; i++)
                    {
                        information = new AssemblyInformation();

                        information.Name = assemblyNameList[i].Name;

                        information.Version = assemblyNameList[i].Version.ToString();

                        information.FullName = assemblyNameList[i].ToString();

                        ReferenceAssembly.Add(information);
                    }
                }
            }
            catch (Exception error)
            {
                ErrorMessage = error.Message;

                KryptonMessageBox.Show($"An error has occurred: { ErrorMessage }", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return true;
        }

        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public bool GetVersion(string fileName)
        {
            Assembly assembly = null;

            try
            {
                assembly = Assembly.LoadFrom(fileName);
            }
            catch (Exception error)
            {
                ErrorMessage = error.Message;

                KryptonMessageBox.Show($"An error has occurred: { ErrorMessage }", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            if (assembly != null)
            {
                AssemblyInformation information = new AssemblyInformation();

                information.Name = assembly.GetName().Name;

                information.Version = assembly.GetName().Version.ToString();

                information.FullName = assembly.GetName().ToString();
            }
            else
            {
                ErrorMessage = "Invalid assembly specifier!";

                KryptonMessageBox.Show($"An error has occurred: { ErrorMessage }", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return GetReferenceAssembly(assembly);
        }

        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        /// <returns></returns>
        public bool GetVersion(Assembly assembly)
        {
            if (assembly != null)
            {
                AssemblyInformation information = new AssemblyInformation();

                information.Name = assembly.GetName().Name;

                information.Version = assembly.GetName().Version.ToString();

                information.FullName = assembly.GetName().ToString();
            }
            else
            {
                ErrorMessage = "Invalid assembly specifier!";

                KryptonMessageBox.Show($"An error has occurred: { ErrorMessage }", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return GetReferenceAssembly(assembly);
        }
        #endregion
    }
}