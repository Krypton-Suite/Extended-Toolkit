#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
	internal static class WinFormsClipboard
    {
        /// <summary>
        /// Copy text to clipboard
        /// </summary>
        /// <param name="text"></param>
        /// <returns>whether the clipboard operation succeeded</returns>
        public static bool CopyTo(string text)
        {
            try
            {
                Clipboard.SetDataObject(text, true);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}