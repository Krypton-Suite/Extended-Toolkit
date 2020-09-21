using System;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
#if !NETCOREAPP31 && !NET5
    [ToolboxBitmap(typeof(ListView))]
    public class KryptonListView : ListView
    {
        #region Design Code
        private ImageList ilCheckBoxes;
        private ImageList ilHeight;
        private System.ComponentModel.IContainer components;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KryptonListView));
            this.ilCheckBoxes = new System.Windows.Forms.ImageList(this.components);
            this.ilHeight = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // ilCheckBoxes
            // 
            this.ilCheckBoxes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilCheckBoxes.ImageStream")));
            this.ilCheckBoxes.TransparentColor = System.Drawing.Color.Transparent;
            this.ilCheckBoxes.Images.SetKeyName(0, "VistaChecked.png");
            this.ilCheckBoxes.Images.SetKeyName(1, "VistaNotChecked.png");
            this.ilCheckBoxes.Images.SetKeyName(2, "XPChecked.gif");
            this.ilCheckBoxes.Images.SetKeyName(3, "XPNotChecked.gif");
            // 
            // ilHeight
            // 
            this.ilHeight.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ilHeight.ImageSize = new System.Drawing.Size(1, 16);
            this.ilHeight.TransparentColor = System.Drawing.Color.Transparent;
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private bool _hasFocus = false;
        private IPalette _palette;
        private PaletteRedirect _paletteRedirect;
        private PaletteBackInheritRedirect _paletteBack;
        private PaletteBorderInheritRedirect _paletteBorder;
        private PaletteContentInheritRedirect _paletteContent;
        private IDisposable _mementoContent;
        private IDisposable _mementoBack1;
        private IDisposable _mementoBack2;
        private ListViewColumnSorter lvwColumnSorter;
        private Font _originalFont;
        private Color _originalForeColor;
        private const int _minimumItemHeight = 18;
        #endregion
    }
#endif
}