#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.NetSparkle
{
    interface IAssemblyAccessor
    {
        string AssemblyCompany { get; }
        string AssemblyCopyright { get; }
        string AssemblyDescription { get; }
        string AssemblyProduct { get; }
        string AssemblyTitle { get; }
        string AssemblyVersion { get; }
    }
}