#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    [ComImport, CoClass(typeof(CMLangStringClass)), Guid("C04D65CE-B70D-11D0-B188-00AA0038C969")]
    public interface CMLangString : IMLangString
    {
    }
}