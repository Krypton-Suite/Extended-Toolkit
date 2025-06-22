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
/// An assembly accessor grabs details on the current version
/// and publisher information for a C# application (presumably
/// the one that is currently running). This is intended to be
/// used in conjunction with a Configuration subclass in order 
/// to retrieve and store info on the latest version of the app
/// that was used, whether the app has run 1x or not, etc.
/// These fields may or may not be required based on the specific 
/// Configuration that you use. At the very least, make sure
/// your IAssemblyAccessor can grab valid info for the title of the 
/// application, the product name (which may or may not be the same
/// as the title), and the version of the application (e.g. 3.1.2.0).
/// </summary>
public interface IAssemblyAccessor
{
    /// <summary>
    /// The publisher of the application. Might be "".
    /// </summary>
    string AssemblyCompany { get; }
    /// <summary>
    /// The copyright for the application (e.g. © 2020)
    /// </summary>
    string AssemblyCopyright { get; }
    /// <summary>
    /// Description of the assembly.
    /// </summary>
    string AssemblyDescription { get; }
    /// <summary>
    /// Title of the assembly, e.g. "My Best Product"
    /// </summary>
    string AssemblyTitle { get; }
    /// <summary>
    /// Product for the assembly. Might be the same as
    /// the title, but also could be more specific than the
    /// title.
    /// </summary>
    string AssemblyProduct { get; }
    /// <summary>
    /// Version of the item that's running. E.g. 3.1.2.1.
    /// </summary>
    string AssemblyVersion { get; }
}