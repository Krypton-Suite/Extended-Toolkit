using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    internal class WinFormsClipboard
    {
        public static void CopyTo(string text)
        {
            Clipboard.SetDataObject(text, true);
        }
    }
}