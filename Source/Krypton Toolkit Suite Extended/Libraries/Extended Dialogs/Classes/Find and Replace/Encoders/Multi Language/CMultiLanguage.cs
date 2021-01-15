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
    [ComImport, Guid("275C23E1-3747-11D0-9FEA-00AA003F8646"), CoClass(typeof(CMultiLanguageClass))]
    public interface CMultiLanguage : IMultiLanguage
    {
    }
}