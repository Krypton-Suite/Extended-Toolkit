#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Tree.Grid.View
{
    /// <summary>
    /// Summary description for TreeGridCell.
    /// </summary>
    public class TreeGridCell : DataGridViewTextBoxCell
    {
        private const int INDENT_WIDTH = 20;
        private const int INDENT_MARGIN = 5;
        private int glyphWidth;
        private int calculatedLeftPadding;
        internal bool IsSited;
        private Padding _previousPadding;
        private int _imageWidth = 0, _imageHeight = 0, _imageHeightOffset = 0;
        //private Rectangle _lastKnownGlyphRect;

        public TreeGridCell()
        {
            glyphWidth = 15;
            calculatedLeftPadding = 0;
            IsSited = false;

        }

        public override object Clone()
        {
            TreeGridCell c = (TreeGridCell)base.Clone();

            c.glyphWidth = glyphWidth;
            c.calculatedLeftPadding = calculatedLeftPadding;

            return c;
        }

        protected internal virtual void UnSited()
        {
            // The row this cell is in is being removed from the grid.
            IsSited = false;
            Style.Padding = _previousPadding;
        }

        protected internal virtual void Sited()
        {
            // when we are added to the DGV we can realize our style
            IsSited = true;

            // remember what the previous padding size is so it can be restored when unsiting
            _previousPadding = Style.Padding;

            UpdateStyle();
        }

        protected internal virtual void UpdateStyle()
        {
            // styles shouldn't be modified when we are not sited.
            if (IsSited == false) return;

            int level = Level;

            Padding p = _previousPadding;
            Size preferredSize;

            using (Graphics g = OwningNode._grid.CreateGraphics())
            {
                preferredSize = GetPreferredSize(g, InheritedStyle, RowIndex, new Size(0, 0));
            }

            Image image = OwningNode.Image;

            if (image != null)
            {
                // calculate image size
                _imageWidth = image.Width + 2;
                _imageHeight = image.Height + 2;

            }
            else
            {
                _imageWidth = glyphWidth;
                _imageHeight = 0;
            }

            // TODO: Make this cleaner
            if (preferredSize.Height < _imageHeight)
            {

                Style.Padding = new Padding(p.Left + (level * INDENT_WIDTH) + _imageWidth + INDENT_MARGIN,
                                                 p.Top + (_imageHeight / 2), p.Right, p.Bottom + (_imageHeight / 2));
                _imageHeightOffset = 2;// (_imageHeight - preferredSize.Height) / 2;
            }
            else
            {
                Style.Padding = new Padding(p.Left + (level * INDENT_WIDTH) + _imageWidth + INDENT_MARGIN,
                                                 p.Top, p.Right, p.Bottom);

            }

            calculatedLeftPadding = ((level - 1) * glyphWidth) + _imageWidth + INDENT_MARGIN;
        }

        public int Level
        {
            get
            {
                TreeGridNode row = OwningNode;
                if (row != null)
                {
                    return row.Level;
                }
                else
                    return -1;
            }
        }

        protected virtual int GlyphMargin => ((Level - 1) * INDENT_WIDTH) + INDENT_MARGIN;

        protected virtual int GlyphOffset => ((Level - 1) * INDENT_WIDTH);

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {

            TreeGridNode node = OwningNode;
            if (node == null) return;

            Image image = node.Image;

            if (_imageHeight == 0 && image != null) UpdateStyle();

            // paint the cell normally
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, formattedValue, errorText, cellStyle, advancedBorderStyle, paintParts);

            // TODO: Indent width needs to take image size into account
            Rectangle glyphRect = new Rectangle(cellBounds.X + GlyphMargin, cellBounds.Y, INDENT_WIDTH, cellBounds.Height - 1);
            int glyphHalf = glyphRect.Width / 2;

            //TODO: This painting code needs to be rehashed to be cleaner
            int level = Level;

            //TODO: Rehash this to take different Imagelayouts into account. This will speed up drawing
            //		for images of the same size (ImageLayout.None)
            if (image != null)
            {
                Point pp;
                if (_imageHeight > cellBounds.Height)
                    pp = new Point(glyphRect.X + glyphWidth, cellBounds.Y + _imageHeightOffset);
                else
                    pp = new Point(glyphRect.X + glyphWidth, (cellBounds.Height / 2 - _imageHeight / 2) + cellBounds.Y);

                // Graphics container to push/pop changes. This enables us to set clipping when painting
                // the cell's image -- keeps it from bleeding outsize of cells.
                System.Drawing.Drawing2D.GraphicsContainer gc = graphics.BeginContainer();
                {
                    graphics.SetClip(cellBounds);
                    graphics.DrawImageUnscaled(image, pp);
                }
                graphics.EndContainer(gc);
            }

            // Paint tree lines			
            if (node._grid.ShowLines)
            {
                using (Pen linePen = new Pen(SystemBrushes.ControlDark, 1.0f))
                {
                    linePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    bool isLastSibling = node.IsLastSibling;
                    bool isFirstSibling = node.IsFirstSibling;
                    if (node.Level == 1)
                    {
                        // the Root nodes display their lines differently
                        if (isFirstSibling && isLastSibling)
                        {
                            // only node, both first and last. Just draw horizontal line
                            graphics.DrawLine(linePen, glyphRect.X + 4, cellBounds.Top + cellBounds.Height / 2, glyphRect.Right, cellBounds.Top + cellBounds.Height / 2);
                        }
                        else if (isLastSibling)
                        {
                            // last sibling doesn't draw the line extended below. Paint horizontal then vertical
                            graphics.DrawLine(linePen, glyphRect.X + 4, cellBounds.Top + cellBounds.Height / 2, glyphRect.Right, cellBounds.Top + cellBounds.Height / 2);
                            graphics.DrawLine(linePen, glyphRect.X + 4, cellBounds.Top, glyphRect.X + 4, cellBounds.Top + cellBounds.Height / 2);
                        }
                        else if (isFirstSibling)
                        {
                            // first sibling doesn't draw the line extended above. Paint horizontal then vertical
                            graphics.DrawLine(linePen, glyphRect.X + 4, cellBounds.Top + cellBounds.Height / 2, glyphRect.Right, cellBounds.Top + cellBounds.Height / 2);
                            graphics.DrawLine(linePen, glyphRect.X + 4, cellBounds.Top + cellBounds.Height / 2, glyphRect.X + 4, cellBounds.Bottom);
                        }
                        else
                        {
                            // normal drawing draws extended from top to bottom. Paint horizontal then vertical
                            graphics.DrawLine(linePen, glyphRect.X + 4, cellBounds.Top + cellBounds.Height / 2, glyphRect.Right, cellBounds.Top + cellBounds.Height / 2);
                            graphics.DrawLine(linePen, glyphRect.X + 4, cellBounds.Top, glyphRect.X + 4, cellBounds.Bottom);
                        }
                    }
                    else
                    {
                        if (isLastSibling)
                        {
                            // last sibling doesn't draw the line extended below. Paint horizontal then vertical
                            graphics.DrawLine(linePen, glyphRect.X + 4, cellBounds.Top + cellBounds.Height / 2, glyphRect.Right, cellBounds.Top + cellBounds.Height / 2);
                            graphics.DrawLine(linePen, glyphRect.X + 4, cellBounds.Top, glyphRect.X + 4, cellBounds.Top + cellBounds.Height / 2);
                        }
                        else
                        {
                            // normal drawing draws extended from top to bottom. Paint horizontal then vertical
                            graphics.DrawLine(linePen, glyphRect.X + 4, cellBounds.Top + cellBounds.Height / 2, glyphRect.Right, cellBounds.Top + cellBounds.Height / 2);
                            graphics.DrawLine(linePen, glyphRect.X + 4, cellBounds.Top, glyphRect.X + 4, cellBounds.Bottom);
                        }

                        // paint lines of previous levels to the root
                        TreeGridNode previousNode = node.Parent;
                        int horizontalStop = (glyphRect.X + 4) - INDENT_WIDTH;

                        while (!previousNode.IsRoot)
                        {
                            if (previousNode.HasChildren && !previousNode.IsLastSibling)
                            {
                                // paint vertical line
                                graphics.DrawLine(linePen, horizontalStop, cellBounds.Top, horizontalStop, cellBounds.Bottom);
                            }
                            previousNode = previousNode.Parent;
                            horizontalStop = horizontalStop - INDENT_WIDTH;
                        }
                    }

                }
            }

            if (node.HasChildren || node._grid.VirtualNodes)
            {
                try
                {
                    // Paint node glyphs				
                    if (node.IsExpanded)
                        node._grid.rOpen.DrawBackground(graphics, new Rectangle(glyphRect.X, glyphRect.Y + (glyphRect.Height / 2) - 4, 10, 10));
                    else
                        node._grid.rClosed.DrawBackground(graphics, new Rectangle(glyphRect.X, glyphRect.Y + (glyphRect.Height / 2) - 4, 10, 10));
                }
                catch
                { }
            }


        }
        protected override void OnMouseUp(DataGridViewCellMouseEventArgs e)
        {
            base.OnMouseUp(e);

            TreeGridNode node = OwningNode;
            if (node != null)
                node._grid._inExpandCollapseMouseCapture = false;
        }
        protected override void OnMouseDown(DataGridViewCellMouseEventArgs e)
        {
            if (e.Location.X > InheritedStyle.Padding.Left)
            {
                base.OnMouseDown(e);
            }
            else
            {
                // Expand the node
                //TODO: Calculate more precise location
                TreeGridNode node = OwningNode;
                if (node != null)
                {
                    node._grid._inExpandCollapseMouseCapture = true;
                    if (node.IsExpanded)
                        node.Collapse();
                    else
                        node.Expand();
                }
            }
        }
        public TreeGridNode OwningNode => base.OwningRow as TreeGridNode;
    }

    public class TreeGridColumn : DataGridViewTextBoxColumn
    {
        internal Image _defaultNodeImage;

        public TreeGridColumn()
        {
            CellTemplate = new TreeGridCell();
        }

        // Need to override Clone for design-time support.
        public override object Clone()
        {
            TreeGridColumn c = (TreeGridColumn)base.Clone();
            c._defaultNodeImage = _defaultNodeImage;
            return c;
        }

        public Image DefaultNodeImage { get => _defaultNodeImage; set => _defaultNodeImage = value; }
    }
}