using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Extended.Base
{
    public class ToggleSwitchKryptonRenderer : ToggleSwitchRendererBase
    {
        #region Variables
        private KryptonManager _manager = new KryptonManager();

        private PaletteBackInheritRedirect _paletteBack;

        private PaletteBorderInheritRedirect _paletteBorder;

        private PaletteContentInheritRedirect _paletteContent;

        private IPalette _palette;
        
        private PaletteRedirect _paletteRedirect;
        #endregion

        #region Constructor
        public ToggleSwitchKryptonRenderer()
        {
            if (((_palette != null))) _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);

            KryptonManager.GlobalPaletteChanged += new EventHandler(OnGlobalPaletteChanged);
            _palette = KryptonManager.CurrentGlobalPalette;
            _paletteRedirect = new PaletteRedirect(_palette);

            //Create accessor objects for the back, border and content
            _paletteBack = new PaletteBackInheritRedirect(_paletteRedirect);
            _paletteBorder = new PaletteBorderInheritRedirect(_paletteRedirect);
            _paletteContent = new PaletteContentInheritRedirect(_paletteRedirect);

            SynchroniseColours();
        }
        #endregion

        #region Krypton
        //Krypton Events
        private void OnPalettePaint(object sender, PaletteLayoutEventArgs e)
        {
            SynchroniseColours();
        }

        private void OnGlobalPaletteChanged(object sender, EventArgs e)
        {
            if (((_palette != null)))
            {
                _palette.PalettePaint -= new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
            }
            _palette = KryptonManager.CurrentGlobalPalette;
            _paletteRedirect.Target = _palette;
            if (((_palette != null)))
            {
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
                SynchroniseColours();
            }

        }

        private void SynchroniseColours()
        {

        }
        #endregion

        #region Base Implementation
        public override Rectangle GetButtonRectangle()
        {
            throw new NotImplementedException();
        }

        public override Rectangle GetButtonRectangle(int buttonWidth)
        {
            throw new NotImplementedException();
        }

        public override int GetButtonWidth()
        {
            throw new NotImplementedException();
        }

        public override void RenderBorder(Graphics g, Rectangle borderRectangle)
        {
            throw new NotImplementedException();
        }

        public override void RenderButton(Graphics g, Rectangle buttonRectangle)
        {
            throw new NotImplementedException();
        }

        public override void RenderLeftToggleField(Graphics g, Rectangle leftRectangle, int totalToggleFieldWidth)
        {
            throw new NotImplementedException();
        }

        public override void RenderRightToggleField(Graphics g, Rectangle rightRectangle, int totalToggleFieldWidth)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}