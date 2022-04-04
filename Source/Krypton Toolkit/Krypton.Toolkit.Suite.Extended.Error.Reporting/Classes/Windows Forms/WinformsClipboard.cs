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