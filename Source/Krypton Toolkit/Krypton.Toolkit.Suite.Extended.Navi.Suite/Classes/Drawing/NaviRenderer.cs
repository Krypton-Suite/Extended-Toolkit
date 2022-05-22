#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    public class NaviRenderer
    {
        NaviColourTable coloursTable = new NaviColourTableOff7Blue();

        #region Properties

        /// <summary>
        /// Gets or sets the color 
        /// </summary>
        public NaviColourTable ColourTable
        {
            get { return coloursTable; }
            set { coloursTable = value; }
        }

        #endregion

        #region Initialization Methods

        /// <summary>
        /// Initializes the drawing functionality
        /// </summary>
        public virtual void Initialize(NaviLayoutStyle layoutStyle)
        {
        }

        #endregion

        #region General Drawing

        /// <summary>
        /// Draws an image on the canvas at a given location
        /// </summary>
        /// <param name="g">The graphics canvas to draw on</param>
        /// <param name="location">The location of the image</param>
        /// <param name="image">The image</param>
        public virtual void DrawImage(Graphics g, Point location, Image image)
        {
            g.DrawImage(image, location);
        }

        /// <summary>
        /// Draws text on a graphics canvas
        /// </summary>
        /// <param name="g">The graphics surface to draw on</param>
        /// <param name="bounds">The bounds of the text</param>
        /// <param name="font">The font of the text</param>
        /// <param name="text">The text to draw</param>
        /// <param name="rightToLeft">Rigth to left or left to right layout</param>
        public virtual void DrawText(Graphics g, Rectangle bounds, Font font, Color color, string text, bool rightToLeft)
        {
            using (Brush brush = new SolidBrush(ColourTable.Text))
            {
                if (rightToLeft)
                {
                    TextRenderer.DrawText(g, text, font, bounds, color,
                       TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis
                       | TextFormatFlags.Right | TextFormatFlags.RightToLeft);
                }
                else
                {
                    TextRenderer.DrawText(g, text, font, bounds, color,
                       TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
                }
            }
        }

        #endregion

        #region NaviBar

        /// <summary>
        /// Draws the background of the NavigationBar
        /// </summary>
        /// <param name="g">The graphics surface to draw on</param>
        /// <param name="bounds">The bounds of the background</param>
        /// <remarks>Its sufficient to supply the ClientRectangle property of the control</remarks>
        public virtual void DrawNaviBarBg(Graphics g, Rectangle bounds)
        {
            bounds.Width -= 1;
            bounds.Height -= 1;

            using (Brush b = new SolidBrush(Color.White))
            using (Pen p = new Pen(ColourTable.Border))
            {
                g.FillRectangle(b, bounds);
                g.DrawRectangle(p, bounds);
            }
        }

        /// <summary>
        /// Draws the background of the rectangle containing the small buttons on the bottom 
        /// of the NavigationBar
        /// </summary>
        /// <param name="g">The graphics surface to draw on</param>
        /// <param name="bounds">The bounds of the small rectangle</param>
        public virtual void DrawNaviBarOverFlowPanelBg(Graphics g, Rectangle bounds)
        {
        }

        /// <summary>
        /// Draws the header region on top of the NavigationBar
        /// </summary>
        /// <param name="g">The graphics surface to draw on</param>
        /// <param name="bounds">The bounds of the header</param>
        public virtual void DrawNaviBarHeaderBg(Graphics g, Rectangle bounds)
        {
        }

        #endregion

        #region NaviBand

        /// <summary>
        /// Draws the background of an Navigation band Client Area
        /// </summary>
        /// <param name="g">The graphics surface to draw on</param>
        /// <param name="bounds">The bounds that the drawing should apply to</param>
        /// <param name="state"></param>
        public virtual void DrawNaviBandClientAreaBg(Graphics g, Rectangle bounds)
        {
            using (Brush b = new SolidBrush(ColourTable.Background))
            {
                g.FillRectangle(b, bounds);
            }
        }

        #endregion

        #region NaviBandClientArea

        /// <summary>
        /// Draws the background of an Navigation band Client Area
        /// </summary>
        /// <param name="g">The graphics surface to draw on</param>
        /// <param name="bounds">The bounds that the drawing should apply to</param>
        /// <param name="state"></param>
        public virtual void DrawNaviBandBg(Graphics g, Rectangle bounds)
        {
            using (Brush b = new SolidBrush(ColourTable.Background))
            {
                g.FillRectangle(b, bounds);
            }
        }

        #endregion

        #region NaviBandCollapsed

        /// <summary>
        /// Draws the background of the collapsed band
        /// </summary>
        /// <param name="g">The canvas to draw on</param>
        /// <param name="bounds">The bounds of the drawing</param>
        /// <param name="text">The text that should appear into the bar</param>
        /// <param name="font">The font to use when drawing the text</param>
        /// <param name="state">The inputstate of the collapsed band</param>
        public virtual void DrawNaviBandCollapsedBg(Graphics g, Rectangle bounds, string text, Font font,
           bool rightToLeft, InputState state)
        {
        }

        #endregion

        #region NaviBandPopup

        /// <summary>
        /// Draws the background of the popped up band
        /// </summary>
        /// <param name="g">The canvas to draw on</param>
        /// <param name="bounds">The bounds of the drawing</param>
        public virtual void DrawNaviBandPopupBg(Graphics g, Rectangle bounds)
        {
            bounds.Width -= 1;
            bounds.Height -= 1;

            using (Pen p = new Pen(ColourTable.Border))
            using (Brush b = new SolidBrush(ColourTable.PopupBandBackground1))
            {
                g.FillRectangle(b, bounds);
                g.DrawRectangle(p, bounds);
            }
        }

        #endregion

        #region NaviButton

        /// <summary>
        /// Draws the background gradients of an Button
        /// </summary>
        /// <param name="g">The graphics surface to draw on</param>
        /// <param name="bounds">The bounds that the drawing should apply to</param>
        public virtual void DrawButtonBg(Graphics g, Rectangle bounds, ControlState state, InputState inputState)
        {
        }

        #endregion

        #region NaviButtonCollapse

        /// <summary>
        /// Draws the surface of the Collapse button
        /// </summary>
        /// <param name="g">The graphics surface to draw on</param>
        /// <param name="bounds">The bounds that the drawing should apply to</param>
        /// <param name="inputState">The input state of the control</param>
        /// <param name="rightToLeft">Right to left or left to right</param>
        /// <param name="collapsed">The bar is collasped or not</param>
        public virtual void DrawButtonCollapseBg(Graphics g, Rectangle bounds, InputState inputState, bool rightToLeft,
           bool collapsed)
        {
        }

        #endregion

        #region NaviButtonOptions

        /// <summary>
        /// Draws the surface of the options button
        /// </summary>
        /// <param name="g">The graphics canvas to draw on</param>
        /// <param name="bounds">The bounds of the text</param>
        public virtual void DrawOptionsTriangle(Graphics g, Rectangle bounds)
        {
        }

        #endregion

        #region NaviGroup

        /// <summary>
        /// Draws the background of a NaviGroup
        /// </summary>
        /// <param name="g">The graphics surface to draw on</param>
        /// <param name="bounds">The bounds of the background</param>
        public virtual void DrawNaviGroupBg(Graphics g, Rectangle bounds)
        {
        }

        /// <summary>
        /// Draws NaviGroup header 
        /// </summary>
        /// <param name="g">The graphics surface to draw on</param>
        /// <param name="bounds">The bounds of the background</param>
        /// <param name="state">The input state of the control</param>
        /// <param name="expanded">Wether the group is expanded or not</param>
        /// <param name="rightToLeft">Whether the group should be drawn from left to right</param>
        public virtual void DrawNaviGroupHeader(Graphics g, Rectangle bounds, InputState state, bool expanded, bool rightToLeft)
        {
        }

        /// <summary>
        /// Calculates the text bounds for the text in the header. 
        /// </summary>
        /// <param name="bounds">The bounds</param>
        /// <returns>The new text bounds</returns>
        public virtual Rectangle CalcGroupTextbounds(Rectangle bounds)
        {
            return bounds;
        }

        /// <summary>
        /// Draws an hatched rectangle
        /// </summary>
        /// <param name="g">The graphics surface to draw on</param>
        /// <param name="bounds">The bounds of the background</param>
        public virtual void DrawHatchedPanel(Graphics g, Rectangle bounds)
        {
            using (Pen pen = new Pen(ColourTable.DashedLineColor))
            {
                pen.DashStyle = DashStyle.Dash;
                g.DrawRectangle(pen, bounds);
            }
        }

        #endregion

        #region NaviSplitter

        /// <summary>
        /// Draws the background of the gradient splitter class to a graphics surface
        /// </summary>
        /// <param name="g">The graphics surface to draw on</param>
        /// <param name="bounds">The bounds of the drawing relative to the graphics surface</param>
        public virtual void DrawSplitterBg(Graphics g, Rectangle bounds)
        {
        }

        #endregion
    }
}