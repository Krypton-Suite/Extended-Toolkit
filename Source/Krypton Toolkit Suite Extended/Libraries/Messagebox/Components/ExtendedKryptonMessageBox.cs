using System.ComponentModel;
using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Messagebox
{
    [ToolboxItem(true), ToolboxBitmap(typeof(ExtendedKryptonMessageBox), "ToolboxBitmaps.KryptonMessageBox.bmp"),
     DefaultEvent("Show"), DesignerCategory("code"), Designer(ExtendedKryptonMessageBoxDesigner),
     Description("")]
    public class ExtendedKryptonMessageBox : Component
    {
    }
}