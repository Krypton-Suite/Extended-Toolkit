using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
#if !NETCOREAPP31 && !NET5
    [ToolboxBitmap(typeof(ListView)), ToolboxItem(false)]
    public class ListViewPrint : PrintDocument
    {

    }
#endif
}