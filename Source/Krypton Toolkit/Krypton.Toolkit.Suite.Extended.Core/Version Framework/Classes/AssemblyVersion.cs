#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Core;

public class AssemblyVersion
{
    #region Variables
    private string _errorMessage;
    private AssemblyInformation _assemblyInformation;
    private List<AssemblyInformation> _referencesList;
    #endregion

    #region Properties
    public string ErrorMessage
    {
        get => _errorMessage;
        set => _errorMessage = value;
    }

    public AssemblyInformation CurrentAssemblyInformation
    {
        get => _assemblyInformation;
        set => _assemblyInformation = value;
    }

    public List<AssemblyInformation> ReferenceAssembly
    {
        get => _referencesList;
        set => _referencesList = value;
    }
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
                AssemblyInformation? information = null;

                ReferenceAssembly = [];

                for (int i = 0; i < assemblyNameList.Length; i++)
                {
                    information = new();

                    information.Name = assemblyNameList[i].Name;

                    information.Version = assemblyNameList[i].Version.ToString();

                    information.FullName = assemblyNameList[i].ToString();

                    ReferenceAssembly.Add(information);
                }
            }
        }
        catch (Exception error)
        {
            DebugUtilities.NotImplemented(error.ToString());

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
            DebugUtilities.NotImplemented(error.ToString());

            return false;
        }

        if (assembly != null)
        {
            AssemblyInformation information = new();

            information.Name = assembly.GetName().Name;

            information.Version = assembly.GetName().Version.ToString();

            information.FullName = assembly.GetName().ToString();
        }
        else
        {
            ErrorMessage = "Invalid assembly specifier!";

            KryptonMessageBox.Show($"An error has occurred: {ErrorMessage}", "Unexpected Error", KryptonMessageBoxButtons.OK, KryptonMessageBoxIcon.Error);

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
            AssemblyInformation information = new();

            information.Name = assembly.GetName().Name;

            information.Version = assembly.GetName().Version.ToString();

            information.FullName = assembly.GetName().ToString();
        }
        else
        {
            ErrorMessage = "Invalid assembly specifier!";

            KryptonMessageBox.Show($"An error has occurred: {ErrorMessage}", "Unexpected Error", KryptonMessageBoxButtons.OK, KryptonMessageBoxIcon.Error);

            return false;
        }

        return GetReferenceAssembly(assembly);
    }
    #endregion
}