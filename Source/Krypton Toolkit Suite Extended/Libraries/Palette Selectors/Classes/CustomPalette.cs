using System.ComponentModel;
using System.Drawing.Design;
using System.Text;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Palette.Selectors
{
    public class CustomPalette
    {
        private ToolStripRenderMode _renderMode = ToolStripRenderMode.ManagerRenderMode;

        [Category("Custom Palette")]
        [DisplayName("Display Name")]
        [Description("The display name for the custom palette.")]
        public string DisplayName { get; set; }

        [Category("Custom Palette")]
        [DisplayName("Palette XML")]
        [Description("The XML markup for the custom palette.")]
        [Editor(typeof(CustomPaletteXmlEditor), typeof(UITypeEditor))]
        public string PaletteXml { get; set; }

        [Category("Custom Palette")]
        [DisplayName("Render Mode")]
        [Description("The render mode to use if linked to a StatusStrip.")]
        [DefaultValue(ToolStripRenderMode.ManagerRenderMode)]
        public ToolStripRenderMode RenderMode { get => _renderMode; set => _renderMode = value; }

        [Browsable(false)]
        public KryptonPalette Palette
        {
            get
            {
                var palette = new KryptonPalette();
                palette.Import(Encoding.Default.GetBytes(PaletteXml));
                return palette;
            }
        }

    }
}