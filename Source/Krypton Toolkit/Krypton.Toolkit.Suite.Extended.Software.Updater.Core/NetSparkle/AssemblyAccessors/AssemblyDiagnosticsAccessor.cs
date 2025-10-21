#region License

/*
 * Copyright(c) 2022 Deadpikle
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

#endregion

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.Core;

/// <summary>
/// An assembly accessor that uses <seealso cref="System.Diagnostics.FileVersionInfo"/>
/// to get information on the assembly with a given name
/// </summary>
public class AssemblyDiagnosticsAccessor : IAssemblyAccessor
{
    private string _fileVersion;
    private string _productVersion;
    private string _productName;
    private string _companyName;
    private string _legalCopyright;
    private string _fileDescription;

    /// <summary>
    /// Create a new diagnostics accessor and parse the assembly's information
    /// using <seealso cref="System.Diagnostics.FileVersionInfo"/>.
    /// <seealso cref="Path.GetFullPath(string)"/> is used to get the full file
    /// path of the given assembly.
    /// </summary>
    /// <param name="assemblyName">the assembly name</param>
    /// <exception cref="FileNotFoundException">Thrown when the path to the assembly with the given name doesn't exist</exception>
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
            _fileVersion = info.FileVersion;
            _productVersion = info.ProductVersion;
            _productName = info.ProductName;
            _companyName = info.CompanyName;
            _legalCopyright = info.LegalCopyright;
            _fileDescription = info.FileDescription;
        }
    }

    #region Assembly Attribute Accessors

    /// <inheritdoc/>
    public string AssemblyTitle
    {
        get => _productName ?? "";
    }

    /// <inheritdoc/>
    public string AssemblyVersion
    {
        get => _fileVersion;
    }

    /// <summary>
    /// Gets the description
    /// </summary>
    public string AssemblyDescription
    {
        get => _fileDescription;
    }

    /// <inheritdoc/>
    public string AssemblyProduct
    {
        get => _productName;
    }

    /// <inheritdoc/>
    public string AssemblyCopyright
    {
        get => _legalCopyright;
    }

    /// <inheritdoc/>
    public string AssemblyCompany
    {
        get => _companyName;
    }

    #endregion
}