#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

// ReSharper disable RedundantOverriddenMember
namespace Krypton.Toolkit.Suite.Extended.Navigator
{
    [ToolboxBitmap(typeof(TabControl)), ToolboxItem(false)]
    public class KryptonEmptyTabControl : TabControl
    {
        private PaletteBase? _palette;
        private PaletteRedirect _paletteRedirect;
        private PaletteBorderInheritRedirect _paletteBorder;
        private IDisposable? _mementoBack;

        private Color _bgcolor;
        private bool _drawBorder = false;
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("false")]
        public bool DrawBorder
        {
            get => _drawBorder;
            set { _drawBorder = value; Invalidate(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new virtual Size ItemSize
        {
            get => base.ItemSize;
            set { base.ItemSize = value; Invalidate(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new virtual TabSizeMode SizeMode
        {
            get => base.SizeMode;
            set { base.SizeMode = value; Invalidate(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new virtual TabAppearance Appearance
        {
            get => base.Appearance;
            set { base.Appearance = value; Invalidate(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new virtual TabDrawMode DrawMode
        {
            get => base.DrawMode;
            set { base.DrawMode = value; Invalidate(); }
        }

        ///
        /// Indicates if the current view is being utilized in the VS.NET IDE or not.
        ///
        private bool _designMode;
        public new bool DesignMode =>
            //return (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv");
            _designMode;

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
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            if (!DesignMode)
            {
                SetStyle(ControlStyles.UserPaint, true);
                SizeMode = TabSizeMode.Fixed;
                DrawMode = TabDrawMode.OwnerDrawFixed;
                //this.ItemSize = new Size(0, 1);
                Appearance = TabAppearance.Buttons;
                Margin = new Padding(0);
            }
            else
            {
                SetStyle(ControlStyles.UserPaint, false);
                DrawMode = TabDrawMode.Normal;
                SizeMode = TabSizeMode.Normal;
                ItemSize = new Size(41, 10);
                Appearance = TabAppearance.Normal;
            }

            _palette = KryptonManager.CurrentGlobalPalette;

            if (_palette != null)
            {
                _palette.PalettePaint += OnPalettePaint;
            }

            KryptonManager.GlobalPaletteChanged += OnGlobalPaletteChanged;

            _paletteRedirect = new PaletteRedirect(_palette);
            _paletteBorder = new PaletteBorderInheritRedirect(_paletteRedirect);

            InitColours();

        }

        private void InitColours()
        {
            _bgcolor = _palette.ColorTable.MenuStripGradientEnd;
            if (!DesignMode)
            {
                foreach (TabPage tp in TabPages)
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
                ItemSize = new Size(0, 1);
                // draw tabs
                for (int i = 0; i < TabCount; i++)
                {
                    TabPages[i].Padding = new Padding(0);
                    TabPages[i].Margin = new Padding(0);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            if (!Visible)
            {
                return;
            }

            base.OnPaint(e);

            if (DesignMode)
            {
                return;
            }

            InitColours();

            Graphics g = e.Graphics;

            Rectangle tabControlArea = ClientRectangle;
            Rectangle tabArea = DisplayRectangle;

            e.Graphics.FillRectangle(new SolidBrush(_bgcolor), tabControlArea);

            if (_palette != null)
            {
                IRenderer? renderer = _palette.GetRenderer();
                _paletteBorder.Style = PaletteBorderStyle.HeaderPrimary;

                //Draw border
                using (GraphicsPath path = new GraphicsPath())
                {
                    Rectangle rect = tabControlArea;
                    path.AddRectangle(rect);

                    using (RenderContext context = new RenderContext(this, e.Graphics, rect, renderer))
                    {
                        if (_drawBorder)
                        {
                            renderer?.RenderStandardBorder.DrawBorder(context, rect, _paletteBorder, VisualOrientation.Top, PaletteState.Normal);
                        }
                    }
                }
            }

            if (!DesignMode)
            {
                if (SelectedTab != null)
                {
                    TabPage tabPage = SelectedTab;
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
            {
                _palette.PalettePaint -= OnPalettePaint;
            }


            _palette = KryptonManager.CurrentGlobalPalette;
            _paletteRedirect.Target = _palette;


            if (_palette != null)
            {
                _palette.PalettePaint += OnPalettePaint;
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
                    _palette.PalettePaint -= OnPalettePaint;
                    _palette = null;
                }


                KryptonManager.GlobalPaletteChanged -= OnGlobalPaletteChanged;
            }

            base.Dispose(disposing);
        }
        #endregion
    }


}