using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
    internal class WinFormsClipboard
    {
        public static void CopyTo(string text)
        {
            Clipboard.SetDataObject(text, true);
        }
    }
}