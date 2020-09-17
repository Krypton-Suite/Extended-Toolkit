using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    [ToolboxBitmap(typeof(TreeView))]
    public class KryptonTreeView : TreeView
    {

        #region "   Members   "
        private bool _hasFocus = false;
        private IPalette _palette;
        private PaletteRedirect _paletteRedirect;
        private PaletteBackInheritRedirect _paletteBack;
        private PaletteBorderInheritRedirect _paletteBorder;
        private PaletteContentInheritRedirect _paletteContent;
        private IDisposable _mementoContent;
        private IDisposable _mementoBack1;
        private IDisposable _mementoBack2;
        #endregion

        #region "   Ctor   "
        public KryptonTreeView()
        {
            //double buffer
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();

            // Configure the TreeView control for owner-draw.
            this.DrawMode = TreeViewDrawMode.OwnerDrawText;

            // add Palette Handler
            // Cache the current global palette setting
            _palette = KryptonManager.CurrentGlobalPalette;

            // Hook into palette events
            if (_palette != null)
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);

            // We want to be notified whenever the global palette changes
            KryptonManager.GlobalPaletteChanged += new EventHandler(OnGlobalPaletteChanged);

            // Create redirection object to the base palette
            _paletteRedirect = new PaletteRedirect(_palette);

            // Create accessor objects for the back, border and content
            _paletteBack = new PaletteBackInheritRedirect(_paletteRedirect);
            _paletteBorder = new PaletteBorderInheritRedirect(_paletteRedirect);
            _paletteContent = new PaletteContentInheritRedirect(_paletteRedirect);

        }
        #endregion

        #region "   Palette Change Event & Dispose   "
        //Krypton Palette Events
        private void OnGlobalPaletteChanged(object sender, EventArgs e)
        {
            // Unhook events from old palette
            if (_palette != null)
                _palette.PalettePaint -= new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);

            // Cache the new IPalette that is the global palette
            _palette = KryptonManager.CurrentGlobalPalette;
            _paletteRedirect.Target = _palette;

            // Hook into events for the new palette
            if (_palette != null)
            {
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
            }

            // Change of palette means we should repaint to show any changes
            Invalidate();
        }


        //Kripton Palette Events
        private void OnPalettePaint(object sender, PaletteLayoutEventArgs e)
        {
            // Palette indicates we might need to repaint, so lets do it
            Invalidate();
        }

        //Dispose Event
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_mementoContent != null)
                {
                    _mementoContent.Dispose();
                    _mementoContent = null;
                }

                if (_mementoBack1 != null)
                {
                    _mementoBack1.Dispose();
                    _mementoBack1 = null;
                }

                if (_mementoBack2 != null)
                {
                    _mementoBack2.Dispose();
                    _mementoBack2 = null;
                }

                // Unhook from the palette events
                if (_palette != null)
                {
                    _palette.PalettePaint -= new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
                    _palette = null;
                }

                // Unhook from the static events, otherwise we cannot be garbage collected
                KryptonManager.GlobalPaletteChanged -= new EventHandler(OnGlobalPaletteChanged);
            }

            base.Dispose(disposing);
        }
        #endregion

        #region "   Overrides & Draw  "
        protected override void OnLostFocus(EventArgs e)
        {
            _hasFocus = false;
            Invalidate();
            base.OnLostFocus(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            _hasFocus = true;
            Invalidate();
            base.OnGotFocus(e);
        }

        protected override void OnAfterExpand(TreeViewEventArgs e)
        {
            Invalidate();
            base.OnAfterExpand(e);
        }
        protected override void OnAfterCollapse(TreeViewEventArgs e)
        {
            Invalidate();
            base.OnAfterCollapse(e);
        }

        // Selects a node that is clicked on its label or tag text.
        protected override void OnMouseDown(MouseEventArgs e)
        {
            TreeNode clickedNode = this.GetNodeAt(e.X, e.Y);
            if (clickedNode == null)
                return;
            if (NodeBounds(clickedNode).Contains(e.X, e.Y))
            {
                this.SelectedNode = clickedNode;
            }
        }

        //create Graphics Path
        private GraphicsPath CreateRectGraphicsPath(Rectangle rect)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(rect);
            return path;
        }

        private PaletteState GetNodeState(DrawTreeNodeEventArgs e)
        {
            // Find the correct state when getting button values
            if (!Enabled)
                return PaletteState.Disabled;
            else
            {
                if (e.State == TreeNodeStates.Hot)
                    return PaletteState.Tracking;
                else
                    return PaletteState.Pressed;
            }
        }

        // Draws a node.
        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            if (e.Node.IsVisible == false) return;


            e.DrawDefault = false;
            Graphics g = e.Graphics;

            // Get the renderer associated with this palette
            IRenderer renderer = _palette.GetRenderer();

            // We want to anti alias the drawing for nice smooth curves
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.CompositingQuality = CompositingQuality.HighQuality;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            // Create the rendering context that is passed into all renderer calls
            using (RenderContext renderContext = new RenderContext(this, g, NodeBounds(e.Node), renderer))
            {

                // we need to find the correct palette state based on if the mouse
                // is over the control if the mouse button is pressed down or not.
                PaletteState buttonState = PaletteState.CheckedPressed;

                // Create a rectangle inset, this is where we will draw the node
                Rectangle innerRect = NodeBounds(e.Node);
                Rectangle innerContent = new Rectangle(innerRect.X + 1, innerRect.Y + 1, innerRect.Width - 2, innerRect.Height - 2);

                // Set the style of control we want to draw
                _paletteBack.Style = PaletteBackStyle.ButtonStandalone;
                _paletteBorder.Style = PaletteBorderStyle.ButtonStandalone;
                _paletteContent.Style = PaletteContentStyle.ButtonStandalone;

                // Get the color and font used to draw the text
                Color textColor = _palette.GetContentShortTextColor1(PaletteContentStyle.ButtonStandalone, buttonState);
                Font textFont = _palette.GetContentShortTextFont(PaletteContentStyle.ButtonStandalone, buttonState);

                //do we have enought room for the text? --> let expand it
                SizeF TextLenght = g.MeasureString(e.Node.Text, textFont);
                innerRect.Width = (int)Math.Max(innerRect.Width, Math.Round(TextLenght.Width));
                innerRect.Width = (int)TextLenght.Width + 3;

                //right offset
                int rightOffset = 2;
                if (this.CheckBoxes == true)
                {
                    if (this.ImageList == null)
                    {
                        rightOffset = 0;
                    }
                }
                innerRect.X = innerRect.X - rightOffset;

                //clear contents (fix the square at left)
                g.FillRectangle(new SolidBrush(e.Node.BackColor), innerRect.X, innerContent.Y, innerRect.Width - 1, innerContent.Height);

                //draw only for some node states
                if (e.State == TreeNodeStates.Hot || e.State == TreeNodeStates.Selected || (e.State & TreeNodeStates.Focused) != 0)
                {

                    //get button state
                    buttonState = GetNodeState(e);

                    //lost focus
                    if (!_hasFocus & !(buttonState == PaletteState.Tracking)) buttonState = PaletteState.Normal;

                    //force disabled mode
                    if (this.Enabled == false) buttonState = PaletteState.Disabled;

                    //////////////////////////////////////////////////////////////////////////////////
                    // In case the border has a rounded effect we need to get the background path   //
                    // to draw from the border part of the renderer. It will return a path that is  //
                    // appropriate for use drawing within the border settings.                      //
                    //////////////////////////////////////////////////////////////////////////////////

                    // Get the color and font used to draw the text
                    textColor = _palette.GetContentShortTextColor1(PaletteContentStyle.ButtonStandalone, buttonState);

                    using (GraphicsPath path = renderer.RenderStandardBorder.GetBackPath(renderContext, innerRect, _paletteBorder, VisualOrientation.Top, buttonState))
                    {
                        // Ask renderer to draw the background
                        _mementoBack2 = renderer.RenderStandardBack.DrawBack(renderContext, innerRect, path, _paletteBack, VisualOrientation.Top, buttonState, _mementoBack2);
                    }

                    // Now we draw the border of the inner area, also in ButtonStandalone style
                    renderer.RenderStandardBorder.DrawBorder(renderContext, innerRect, _paletteBorder, VisualOrientation.Top, buttonState);

                    // Draw the node text.
                    using (Brush textBrush = new SolidBrush(textColor))
                    {
                        // We want to anti alias the drawing for nice smooth curves
                        g.DrawString(e.Node.Text, textFont, textBrush, e.Node.Bounds.Left, e.Node.Bounds.Top);
                    }
                }
                else
                {
                    // Get the color and font used to draw the text
                    try
                    {
                        textColor = _palette.ColorTable.MenuItemText;
                        //textColor = _palette.GetContentShortTextColor1(PaletteContentStyle.LabelNormalControl, buttonState);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                        textColor = this.ForeColor;
                    }
                    // Draw the node text.
                    using (Brush textBrush = new SolidBrush(textColor))
                        g.DrawString(e.Node.Text, textFont, textBrush, e.Node.Bounds.Left, e.Node.Bounds.Top);
                }
            }
        }

        // Returns the bounds of the specified node, including the region
        // occupied by the node label and any node tag displayed.
        private Rectangle NodeBounds(TreeNode node)
        {

            // Set the return value to the normal node bounds.
            Rectangle bounds = node.Bounds;
            return bounds;
        }
        #endregion
    }
}