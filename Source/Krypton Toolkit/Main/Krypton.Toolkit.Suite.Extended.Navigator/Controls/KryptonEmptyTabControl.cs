#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Navigator
{
    [ToolboxBitmap(typeof(TabControl)), ToolboxItem(false)]
    public class KryptonEmptyTabControl : TabControl
    {
        private IPalette _palette;
        private PaletteRedirect _paletteRedirect;
        private PaletteBorderInheritRedirect _paletteBorder;
        private IDisposable _mementoBack;

        private Color _bgcolor;
        private Boolean _drawBorder = false;
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("false")]
        public Boolean DrawBorder
        {
            get { return _drawBorder; }
            set { _drawBorder = value; Invalidate(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new virtual Size ItemSize
        {
            get { return base.ItemSize; }
            set { base.ItemSize = value; Invalidate(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new virtual TabSizeMode SizeMode
        {
            get { return base.SizeMode; }
            set { base.SizeMode = value; Invalidate(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new virtual TabAppearance Appearance
        {
            get { return base.Appearance; }
            set { base.Appearance = value; Invalidate(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new virtual TabDrawMode DrawMode
        {
            get { return base.DrawMode; }
            set { base.DrawMode = value; Invalidate(); }
        }

        ///
        /// Indicates if the current view is being utilized in the VS.NET IDE or not.
        ///
        private bool _designMode;
        public new bool DesignMode
        {
            get
            {
                //return (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv");
                return _designMode; ;
            }
        }

        public KryptonEmptyTabControl()
        {
            //Design Mode
            _designMode = (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv");

            Init();
        }

        public KryptonEmptyTabControl(IContainer container)
        {
            container.Add(this);

            //Design Mode
            _designMode = (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv");

            Init();
        }
        private void Init()
        {
            // double buffering
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            if (!DesignMode)
            {
                this.SetStyle(ControlStyles.UserPaint, true);
                this.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
                this.DrawMode = TabDrawMode.OwnerDrawFixed;
                //this.ItemSize = new Size(0, 1);
                this.Appearance = System.Windows.Forms.TabAppearance.Buttons;
                this.Margin = new System.Windows.Forms.Padding(0);
            }
            else
            {
                this.SetStyle(ControlStyles.UserPaint, false);
                this.DrawMode = TabDrawMode.Normal;
                this.SizeMode = System.Windows.Forms.TabSizeMode.Normal;
                this.ItemSize = new Size(41, 10);
                this.Appearance = System.Windows.Forms.TabAppearance.Normal;
            }

            _palette = KryptonManager.CurrentGlobalPalette;

            if (_palette != null)
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);

            KryptonManager.GlobalPaletteChanged += new EventHandler(OnGlobalPaletteChanged);

            _paletteRedirect = new PaletteRedirect(_palette);
            _paletteBorder = new PaletteBorderInheritRedirect(_paletteRedirect);

            InitColours();

        }

        private void InitColours()
        {
            _bgcolor = _palette.ColorTable.MenuStripGradientEnd;
            if (!DesignMode)
            {
                foreach (TabPage tp in this.TabPages)
                {
                    tp.BackColor = _palette.GetBackColor1(PaletteBackStyle.ControlClient, PaletteState.Normal);
                }
            }
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            if (!DesignMode)
            {
                this.ItemSize = new Size(0, 1);
                // draw tabs
                for (int i = 0; i < this.TabCount; i++)
                {
                    this.TabPages[i].Padding = new System.Windows.Forms.Padding(0);
                    this.TabPages[i].Margin = new System.Windows.Forms.Padding(0);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            if (!Visible)
                return;

            base.OnPaint(e);

            if (DesignMode)
                return;

            InitColours();

            Graphics g = e.Graphics;

            Rectangle TabControlArea = this.ClientRectangle;
            Rectangle TabArea = this.DisplayRectangle;

            e.Graphics.FillRectangle(new SolidBrush(_bgcolor), TabControlArea);

            IRenderer renderer = _palette.GetRenderer();
            _paletteBorder.Style = PaletteBorderStyle.HeaderPrimary;

            //Draw border
            using (GraphicsPath path = new GraphicsPath())
            {
                Rectangle rect = TabControlArea;
                path.AddRectangle(rect);

                using (RenderContext context = new RenderContext(this, e.Graphics, rect, renderer))
                {
                    if (_drawBorder) renderer.RenderStandardBorder.DrawBorder(context, rect, _paletteBorder, VisualOrientation.Top, PaletteState.Normal);
                }
            }

            if (!DesignMode)
            {
                if (this.SelectedTab != null)
                {
                    TabPage tabPage = this.SelectedTab;
                    tabPage.BackColor = _bgcolor;
                }
            }

        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
        }

        #region ... Krypton ...
        private void OnGlobalPaletteChanged(object sender, EventArgs e)
        {

            if (_palette != null)
                _palette.PalettePaint -= new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);


            _palette = KryptonManager.CurrentGlobalPalette;
            _paletteRedirect.Target = _palette;


            if (_palette != null)
            {
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
                InitColours();
            }

            Invalidate();
        }

        private void OnPalettePaint(object sender, PaletteLayoutEventArgs e)
        {

            Invalidate();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {


                if (_mementoBack != null)
                {
                    _mementoBack.Dispose();
                    _mementoBack = null;
                }


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
    }


}