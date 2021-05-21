using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Krypton.Toolkit.Suite.Extended.Drawing;

namespace Krypton.Toolkit.Suite.Extended.ComboBox
{
    [ToolboxBitmap(typeof(System.Windows.Forms.ComboBox))]
    public class KryptonComboBox : System.Windows.Forms.ComboBox
    {
        private IPalette _palette;
        private PaletteRedirect _paletteRedirect;

        public KryptonComboBox()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            UpdateStyles();
            DrawMode = DrawMode.OwnerDrawVariable;

            // add Palette Handler
            if (_palette != null)
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);

            KryptonManager.GlobalPaletteChanged += new EventHandler(OnGlobalPaletteChanged);

            _palette = KryptonManager.CurrentGlobalPalette;
            _paletteRedirect = new PaletteRedirect(_palette);

            //vista

            //Initialize border
            _borderColor = _palette.ColorTable.ButtonSelectedBorder;

            //for image list
            InitializeComponent();

        }

        #region ... Properties ...
        private Color _borderColor = Color.Black;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("Color.Black")]
        public Color BorderColour
        {
            get { return _borderColor; }
            set { _borderColor = value; Invalidate(); }
        }

        private Boolean _disableBorderColor = false;
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("False")]
        public Boolean DisableBorderColour
        {
            get { return _disableBorderColor; }
            set { _disableBorderColor = value; }
        }

        private Color _gradientStartColor = Color.White;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("Color.White")]
        public Color GradientStartColour
        {
            get { return _gradientStartColor; }
            set { _gradientStartColor = value; Invalidate(); }
        }

        private Color _gradientEndColor = Color.Gray;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("Color.Gray")]
        public Color GradientEndColour
        {
            get { return _gradientEndColor; }
            set { _gradientEndColor = value; Invalidate(); }
        }

        private Boolean _persistentColors = false;
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("False")]
        public Boolean PersistentColours
        {
            get { return _persistentColors; }
            set { _persistentColors = value; }
        }

        private Boolean _useStyledColors = false;
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("False")]
        public Boolean UseStyledColours
        {
            get { return _useStyledColors; }
            set { _useStyledColors = value; }
        }

        #endregion

        #region ... Overrides ...
        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            base.OnMeasureItem(e);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
            //pevent.Graphics.DrawRectangle(new Pen(Color.Red), 0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //e.Graphics.FillRectangle(System.Drawing.Brushes.Blue, 0, 0, Width, Height);
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            Rectangle rect = e.Bounds;
            Graphics g = e.Graphics;

            //DDL fix
            if (e.Index == -1) return;

            //ClearType
            try
            {
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            if (_palette == null)
            {
                EventArgs Ev = new EventArgs();
                OnGlobalPaletteChanged(this, Ev);
            }

            //set colors
            if (_persistentColors == false)
            {
                //init color values
                if (_useStyledColors == true)
                {
                    _gradientStartColor = Color.FromArgb(255, 246, 215);
                    _gradientEndColor = Color.FromArgb(255, 213, 77);
                }
                else
                {
                    _gradientStartColor = _palette.ColorTable.StatusStripGradientBegin;
                    _gradientEndColor = _palette.ColorTable.OverflowButtonGradientEnd;
                }
            }

            //BackColors 
            Color gradStartColor = _gradientStartColor;
            Color gradEndColor = _gradientEndColor;
            Color textColor = _palette.ColorTable.StatusStripText;

            // Retrieve the item font. If the item font has not been set,
            // use the ComboBox font.
            Font itemFont = e.Font;
            if (itemFont == null) itemFont = this.Font;

            // Draw the background of the item.
            e.DrawBackground();

            // Draw each string in the array, using a different size, color,
            // and font for each item.

            string str = (string)this.Items[e.Index];

            e.Graphics.DrawString(str, itemFont, new SolidBrush(this.ForeColor), e.Bounds);

            if ((e.State & DrawItemState.Selected) != 0)
            {
                //DrawingMethods.DrawBlendGradient(e.Graphics, e.Bounds, gradStartColor, gradEndColor, gradMiddleColor, 90F);
                DrawingMethods.DrawGradient(g, e.Bounds, gradStartColor, gradEndColor, 90F, false, Color.White, 0);
                e.Graphics.DrawString(str, itemFont, new SolidBrush(textColor), e.Bounds);
                e.DrawFocusRectangle();
            }

            // Draw the focus rectangle if the mouse hovers over an item.
            e.DrawFocusRectangle();

        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (_disableBorderColor == false)
            {
                DrawBorder(ref m, this.Width, this.Height);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {

                if (_palette != null)
                {
                    _palette.PalettePaint -= new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
                    _palette = null;
                }


                KryptonManager.GlobalPaletteChanged -= new EventHandler(OnGlobalPaletteChanged);
            }

            base.Dispose(disposing);
        }

        #endregion

        #region ... Krypton ...
        //Kripton Palette Events
        private void OnGlobalPaletteChanged(object sender, EventArgs e)
        {
            if (_palette != null)
                _palette.PalettePaint -= new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);

            _palette = KryptonManager.CurrentGlobalPalette;
            _paletteRedirect.Target = _palette;

            if (_palette != null)
            {
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
                //repaint with new values

                //set colors
                if (_persistentColors == false)
                {
                    //init color values
                    if (_useStyledColors == true)
                    {
                        _gradientStartColor = Color.FromArgb(255, 246, 215);
                        _gradientEndColor = Color.FromArgb(255, 213, 77);
                    }
                    else
                    {
                        _gradientStartColor = _palette.ColorTable.StatusStripGradientBegin;
                        _gradientEndColor = _palette.ColorTable.OverflowButtonGradientEnd;
                    }
                }
            }

            Invalidate();
        }

        //Kripton Palette Events
        private void OnPalettePaint(object sender, PaletteLayoutEventArgs e)
        {
            Invalidate();
        }
        #endregion

        #region ... Subs ...
        // message - a message from control's WndProc(ref Message m) method
        // width - controls' width
        // height - controls' height
        public void DrawBorder(ref Message message, int width, int height)
        {
            if (message.Msg == WIN32.WM_NCPAINT || message.Msg == WIN32.WM_ERASEBKGND || message.Msg == WIN32.WM_PAINT)
            {
                //get handle to a display device context
                IntPtr hdc = WIN32.GetDCEx(message.HWnd, (IntPtr)1, 1 | 0x0020);

                if (hdc != IntPtr.Zero)
                {
                    //get Graphics object from the display device context
                    Graphics graphics = Graphics.FromHdc(hdc);
                    Rectangle rectangle = new Rectangle(0, 0, width, height);
                    ControlPaint.DrawBorder(graphics, rectangle, _borderColor, ButtonBorderStyle.Solid);

                    message.Result = (IntPtr)1;
                    WIN32.ReleaseDC(message.HWnd, hdc);
                }
            }
        }


        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }

        #endregion


    }
}