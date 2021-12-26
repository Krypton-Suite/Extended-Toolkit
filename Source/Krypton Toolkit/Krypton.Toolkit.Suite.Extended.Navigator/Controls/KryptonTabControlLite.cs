#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Navigator
{
    [ToolboxBitmap(typeof(TabControl))]
    public class KryptonTabControlLite : TabControl
    {
        private static IRenderer Renderer;
        private static IPalette Palette;
        private static ViewLayoutContext ViewLayoutContext;
        private static Control ViewLayoutContextControl = new Control();
        private static PaletteBackInheritRedirect PaletteTabPageBackground;
        private static PaletteBorderInheritRedirect PaletteTabPageBorder;
        private static PaletteBackInheritRedirect PaletteTabButtonBackground;
        private static PaletteBorderInheritRedirect PaletteTabButtonBorder;
        private static IDisposable MementoTabPageBackground;
        private static IDisposable MementoTabButtonBackground;
        private static IDisposable MementoTabButtonBorder;
        private static Font TabFontBold;
        private static Font TabFontRegular;
        private static SolidBrush TabBrush;
        private static StringFormat SF;
        private bool _DrawTabPage;
        private Font TabFont;
        public KryptonTabControlLite()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            SF = new StringFormat(StringFormatFlags.NoWrap);
            SF.Alignment = StringAlignment.Center;
            SF.LineAlignment = StringAlignment.Center;

            RefreshPalette();

            KryptonManager.GlobalPaletteChanged += KryptonManager_GlobalPaletteChanged;
        }

        private void KryptonManager_GlobalPaletteChanged(object sender, EventArgs e)
        {
            RefreshPalette();
        }

        private void RefreshPalette()
        {
            Palette = KryptonManager.CurrentGlobalPalette;
            Renderer = Palette.GetRenderer();
            ViewLayoutContext = new ViewLayoutContext(ViewLayoutContextControl, Renderer);

            PaletteRedirect PaletteRedirect = new PaletteRedirect(Palette);
            PaletteTabPageBackground = new PaletteBackInheritRedirect(PaletteRedirect);
            PaletteTabPageBorder = new PaletteBorderInheritRedirect(PaletteRedirect);
            PaletteTabButtonBackground = new PaletteBackInheritRedirect(PaletteRedirect);
            PaletteTabButtonBorder = new PaletteBorderInheritRedirect(PaletteRedirect);

            PaletteTabPageBackground.Style = PaletteBackStyle.ControlToolTip;
            PaletteTabPageBorder.Style = PaletteBorderStyle.ButtonNavigatorStack;
            PaletteTabButtonBackground.Style = PaletteBackStyle.ButtonNavigatorStack;
            PaletteTabButtonBorder.Style = PaletteBorderStyle.ButtonNavigatorMini;

            TabFontBold = new Font(Palette.GetContentShortTextFont(PaletteContentStyle.ButtonNavigatorStack, PaletteState.Normal), FontStyle.Bold);
            TabFontRegular = new Font(TabFontBold, FontStyle.Regular);
            TabBrush = new SolidBrush(Palette.GetContentShortTextColor1(PaletteContentStyle.ButtonNavigatorStack, PaletteState.Normal));
            Invalidate();

        }

        [System.ComponentModel.DefaultValue(false)]
        public bool DrawTabPage
        {
            get { return _DrawTabPage; }
            set
            {
                _DrawTabPage = value;
                if (_DrawTabPage)
                {
                    foreach (TabPage TP in TabPages)
                    {
                        TP.Paint += TabPage_Paint;
                    }
                    if (SelectedTab != null)
                        SelectedTab.Invalidate();
                }
                else
                {
                    foreach (TabPage TP in TabPages)
                    {
                        TP.Paint -= TabPage_Paint;
                    }
                    if (SelectedTab != null)
                        SelectedTab.Invalidate();
                }
            }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            Rectangle RBorder = DisplayRectangle;
            RBorder.Inflate(1, 1);

            using (Pen PBorder = new Pen(PaletteTabPageBorder.GetBorderColor1(PaletteState.Normal)))
            {
                e.Graphics.DrawRectangle(PBorder, RBorder);
            }

            if (this.TabCount > 0)
            {
                using (RenderContext renderContext = new RenderContext(this, e.Graphics, e.ClipRectangle, Renderer))
                {
                    renderContext.Graphics.CompositingQuality = CompositingQuality.HighQuality;
                    renderContext.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                    int selectedIndex = this.SelectedIndex;
                    for (int index = 0; index <= this.TabCount - 1; index++)
                    {
                        if (index != selectedIndex)
                            this.PaintTab(index, renderContext);
                    }
                    if (selectedIndex >= 0)
                        this.PaintTab(SelectedIndex, renderContext);
                }
            }

        }

        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
        {
            if (Application.RenderWithVisualStyles)
            {
                System.Windows.Forms.GroupBoxRenderer.DrawParentBackground(pevent.Graphics, pevent.ClipRectangle, this);
            }
            else
            {
                // Fill default panel background color (TODO: this should be configurable)
                Color backColor = Palette.GetBackColor1(PaletteBackStyle.PanelClient, PaletteState.Normal);
                using (SolidBrush backBrush = new SolidBrush(backColor))
                {
                    pevent.Graphics.FillRectangle(backBrush, pevent.ClipRectangle);
                }
            }
        }

        private void PaintTab(int index, RenderContext RenderContext)
        {
            bool Selected = (SelectedIndex == index);

            Rectangle TabRect = GetTabRect(index);
            //If Selected Then TabRect.Inflate(0, 2)

            if ((Appearance & TabAppearance.Normal) == TabAppearance.Normal)
            {
                TabRect.Inflate(0, Selected ? 2 : 1);
                TabRect.X += 1;
            }

            PaletteState State = default(PaletteState);
            if (Selected)
            {
                State = PaletteState.Pressed;
            }
            else
            {
                State = TabRect.Contains(PointToClient(MousePosition)) ? PaletteState.Tracking : PaletteState.Normal;
            }

            VisualOrientation visualOrientation = (VisualOrientation)Alignment;

            if (PaletteTabButtonBackground.GetBackDraw(State) == InheritBool.True)
            {
                using (GraphicsPath BackPath = Renderer.RenderStandardBorder.GetBackPath(RenderContext, TabRect, PaletteTabButtonBorder, visualOrientation, State))
                {
                    MementoTabButtonBackground = Renderer.RenderStandardBack.DrawBack(RenderContext, TabRect, BackPath, PaletteTabButtonBackground, visualOrientation, State, MementoTabButtonBackground);
                }
            }

            if (PaletteTabButtonBorder.GetBorderDraw(State) == InheritBool.True)
            {
                Renderer.RenderStandardBorder.DrawBorder(RenderContext, TabRect, PaletteTabButtonBorder, visualOrientation, State);
            }
            else if (Selected)
            {
                using (Pen PBorder = new Pen(PaletteTabPageBorder.GetBorderColor1(PaletteState.Normal)))
                {
                    Rectangle RBorder = TabRect;
                    RBorder.Width -= 1;

                    RenderContext.Graphics.DrawRectangle(PBorder, RBorder);
                }
            }

            // Draw tab image (TODO: adjust rendering for other Appearance settings)
            if (ImageList != null)
            {
                Image tabImage = null;

                if (TabPages[index].ImageIndex != -1)
                {
                    int imageIndex = TabPages[index].ImageIndex;
                    tabImage = ImageList.Images[imageIndex];
                }
                else if (TabPages[index].ImageKey != null)
                {
                    string imageKey = TabPages[index].ImageKey;
                    tabImage = ImageList.Images[imageKey];
                }

                if (tabImage != null)
                {
                    int x = TabRect.X + (tabImage.Width / 2);
                    int y = TabRect.Y + (TabRect.Height - tabImage.Height) / 2;

                    RenderContext.Graphics.DrawImage(tabImage, x, y);

                    TabRect.X += tabImage.Width;
                    TabRect.Width -= tabImage.Width;

                }

            }

            if (TabFont == null || (!object.ReferenceEquals(TabFont, TabFontBold) & !object.ReferenceEquals(TabFont, TabFontRegular)))
            {
                if (RenderContext.Graphics.MeasureString(TabPages[index].Text, TabFontBold, TabRect.X, SF).Width <= TabRect.Width)
                {
                    TabFont = TabFontBold;
                }
                else
                {
                    TabFont = TabFontRegular;
                }
            }

            RenderContext.Graphics.DrawString(TabPages[index].Text, TabFont, TabBrush, TabRect, SF);

        }

        protected override void OnControlAdded(System.Windows.Forms.ControlEventArgs e)
        {
            if (_DrawTabPage)
                e.Control.Paint += TabPage_Paint;
            base.OnControlAdded(e);
        }

        protected override void OnControlRemoved(System.Windows.Forms.ControlEventArgs e)
        {
            if (_DrawTabPage)
                e.Control.Paint -= TabPage_Paint;
            base.OnControlRemoved(e);
        }

        private void TabPage_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            TabPage TP = (TabPage)sender;

            using (RenderContext renderContext = new RenderContext(TP, e.Graphics, e.ClipRectangle, Renderer))
            {
                using (GraphicsPath path = new GraphicsPath())
                {
                    Rectangle R = TP.DisplayRectangle;
                    path.AddRectangle(R);
                    MementoTabPageBackground = Renderer.RenderStandardBack.DrawBack(renderContext, R, path, PaletteTabPageBackground, VisualOrientation.Top, PaletteState.Normal, MementoTabPageBackground);
                }
            }
        }

    }

}