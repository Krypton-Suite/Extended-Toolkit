using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Base
{
    public class KryptonFadePanel : Control
    {
        #region Variables
        private int _fadeValue = 0;

        private Image _imageA, _imageB;

        private float _fadeTime;

        private Timer _timer = null;

        private KryptonManager _manager = new KryptonManager();

        private PaletteBackInheritRedirect _paletteBack;

        private PaletteBorderInheritRedirect _paletteBorder;

        private PaletteContentInheritRedirect _paletteContent;

        private IPalette _palette;

        private PaletteRedirect _paletteRedirect;
        #endregion

        #region Property
        [Browsable(false)]
        public Image ImageA { get => _imageA; set => _imageA = value; }

        [Browsable(false)]
        public Image ImageB { get => _imageB; set => _imageB = value; }

        public float FadeTime { get => _fadeTime; set => _fadeTime = value; }
        #endregion

        #region Constructor
        public KryptonFadePanel()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);

            _timer = new Timer();

            _timer.Tick += Timer_Tick;

            _imageA = null;

            _imageB = null;

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

        #region Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            if (_imageA == null) return;

            e.Graphics.DrawImage(_imageA, this.ClientRectangle, 0, 0, _imageA.Width, _imageA.Height, GraphicsUnit.Pixel);

            if (_imageB == null) return;

            ImageAttributes ia = new ImageAttributes();

            ColorMatrix cm = new ColorMatrix();

            cm.Matrix33 = 1.0f / 255 * _fadeValue;

            ia.SetColorMatrix(cm);

            e.Graphics.DrawImage(_imageB, this.ClientRectangle, 0, 0, _imageA.Width, _imageA.Height, GraphicsUnit.Pixel, ia);

            base.OnPaint(e);
        }
        #endregion

        #region Methods
        public void Fade()
        {
            _fadeValue = 1;

            _timer.Interval = (int)(1000f * _fadeTime / 32);

            _timer.Enabled = true;
        }
        #endregion

        #region Event Handler
        private void Timer_Tick(object sender, EventArgs e)
        {
            _fadeValue += 8;

            if (_fadeValue >= 255)
            {
                _fadeValue = 255;

                _timer.Enabled = false;
            }

            Invalidate();
        }
        #endregion

        #region Krypton
        //Krypton Events
        private void OnPalettePaint(object sender, PaletteLayoutEventArgs e)
        {
            base.Invalidate();
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
            BackColor = _palette.ColorTable.ToolStripPanelGradientBegin;
        }
        #endregion
    }
}