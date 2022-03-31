#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Krypton.Toolkit.Suite.Extended.VirtualTreeColumnView
{
    /// <summary>
    /// Summary description for InternalTreeColumnView.
    /// </summary>
    [ToolboxItem(false)]
    public partial class InternalTreeColumnView : UserControl
    {
        #region Instance Fields
        private readonly ViewManager _viewManager;
        private readonly KryptonVirtualTreeColumnView _kryptonVirtualTreeColumnView;

        private VirtualTreeRowNode _hiddenRootNode;
        private readonly HashSet<VirtualTreeRowNode> _selectedNodeSet = new();
        private bool _mouseOver;
        #endregion

        #region Events

        /// <summary>
        /// Occurs when the mouse enters the InternalTreeView.
        /// </summary>
        public event EventHandler TrackMouseEnter;

        /// <summary>
        /// Occurs when the mouse leaves the InternalTreeView.
        /// </summary>
        public event EventHandler TrackMouseLeave;
        #endregion

        #region Identity
        public InternalTreeColumnView()
        {
            InitializeComponent();
            SetStyle(ControlStyles.ResizeRedraw, true);

            BorderStyle = BorderStyle.None;
            Clear();
        }

        public InternalTreeColumnView(KryptonVirtualTreeColumnView kryptonVirtualTreeColumnView)
            : this()
        {
            _kryptonVirtualTreeColumnView = kryptonVirtualTreeColumnView;
            // Create manager and view for drawing the background
            ViewDrawPanel = new ViewDrawPanel();
            _viewManager = new ViewManager(this, ViewDrawPanel);
        }

        #endregion Identity

        #region Public
        internal void Clear() => _hiddenRootNode = new VirtualTreeRowNode(this);

        /// <summary>
        /// Recreate the window handle.
        /// </summary>
        public void Recreate() => RecreateHandle();

        /// <summary>
        /// Gets access to the contained view draw panel instance.
        /// </summary>
        public ViewDrawPanel ViewDrawPanel { get; }

        /// <summary>
        /// Gets and sets if the mouse is currently over the combo box.
        /// </summary>
        public bool MouseOver
        {
            get => _mouseOver;

            set
            {
                // Only interested in changes
                if (_mouseOver != value)
                {
                    _mouseOver = value;

                    // Generate appropriate change event
                    if (_mouseOver)
                    {
                        OnTrackMouseEnter(EventArgs.Empty);
                    }
                    else
                    {
                        OnTrackMouseLeave(EventArgs.Empty);
                    }
                }
            }
        }
        #endregion Public

        #region Protected

        /// <summary>
        /// Raises the Layout event.
        /// </summary>
        /// <param name="e">A LayoutEventArgs containing the event data.</param>
        protected override void OnLayout(LayoutEventArgs e)
        {
            base.OnLayout(e);

            // Ask the panel to layout given our available size
            using ViewLayoutContext context = new(_viewManager, this, _kryptonVirtualTreeColumnView, _kryptonVirtualTreeColumnView.Renderer);
            ViewDrawPanel.Layout(context);
        }

        /// <summary>
        /// Process Windows-based messages.
        /// </summary>
        /// <param name="m">A Windows-based message.</param>
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case PI.WM_.ERASEBKGND:
                    // Do not draw the background here, always do it in the paint 
                    // instead to prevent flicker because of a two stage drawing process
                    break;
                case PI.WM_.VSCROLL:
                case PI.WM_.HSCROLL:
                case PI.WM_.MOUSEWHEEL:
                    Invalidate();
                    base.WndProc(ref m);
                    break;
                case PI.WM_.MOUSELEAVE:
                    if (MouseOver)
                    {
                        MouseOver = false;
                        _kryptonVirtualTreeColumnView.PerformNeedPaint(true);
                        Invalidate();
                    }
                    base.WndProc(ref m);
                    break;
                case PI.WM_.MOUSEMOVE:
                    if (!MouseOver)
                    {
                        MouseOver = true;
                        _kryptonVirtualTreeColumnView.PerformNeedPaint(true);
                        Invalidate();
                    }
                    base.WndProc(ref m);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        /// <summary>
        /// Raises the TrackMouseEnter event.
        /// </summary>
        /// <param name="e">An EventArgs containing the event data.</param>
        protected void OnTrackMouseEnter(EventArgs e) => TrackMouseEnter?.Invoke(this, e);

        /// <summary>
        /// Raises the TrackMouseLeave event.
        /// </summary>
        /// <param name="e">An EventArgs containing the event data.</param>
        protected void OnTrackMouseLeave(EventArgs e) => TrackMouseLeave?.Invoke(this, e);
        #endregion Protected

        #region Private
        internal void DrawDesignMode(Graphics graphics)
        {
            // TODO: Take into account padding against graphics.VisibleClipBounds
            //ApplyPadding

            PaletteState stateEven = _kryptonVirtualTreeColumnView.GetCellTriple(RowNodeState.None, 0,
                out IPaletteBack paletteBackEven,
                out IPaletteBorder paletteBorderEven,
                out IPaletteContent paletteContentEven);
            PaletteState stateOdd = _kryptonVirtualTreeColumnView.GetCellTriple(RowNodeState.None, 1,
                out IPaletteBack paletteBackOdd,
                out IPaletteBorder paletteBorderOdd,
                out IPaletteContent paletteContentOdd);
            using var penEven = new Pen(paletteBorderEven.GetBorderColor1(stateEven), paletteBorderEven.GetBorderWidth(stateEven));
            using var penOdd = new Pen(paletteBorderOdd.GetBorderColor1(stateOdd), paletteBorderOdd.GetBorderWidth(stateOdd));
            using var brushEven = new SolidBrush(paletteBackEven.GetBackColor1(stateEven));
            using var brushOdd = new SolidBrush(paletteBackOdd.GetBackColor1(stateOdd));

            RectangleF r = graphics.VisibleClipBounds;
            var useHeaderHeight = _kryptonVirtualTreeColumnView.Header.Visible
                ? Math.Max(_kryptonVirtualTreeColumnView.Header.MinHeight, ItemHeight)
                : 0;
            var rows = ((int)(r.Height - useHeaderHeight) / ItemHeight);

            var y = graphics.VisibleClipBounds.Y + useHeaderHeight;
            var totalColWidth = Math.Min(TotalWidth(), graphics.VisibleClipBounds.Right);

            PaletteState state = stateEven;
            Pen pen = penEven;
            IPaletteBorder paletteBorder = paletteBorderEven;
            for (var row = 0; row < rows; row++)
            {
                Brush brush;
                IPaletteBack paletteBack;
                IPaletteContent paletteContent;
                if (row % 2 == 0)
                {
                    state = stateEven;
                    brush = brushEven;
                    pen = penEven;
                    paletteBack = paletteBackEven;
                    paletteBorder = paletteBorderEven;
                    paletteContent = paletteContentEven;
                }
                else
                {
                    state = stateOdd;
                    brush = brushOdd;
                    pen = penOdd;
                    paletteBack = paletteBackOdd;
                    paletteBorder = paletteBorderOdd;
                    paletteContent = paletteContentOdd;
                }
                SetTextRenderingHint(graphics, paletteContent, state);
                SetLineQuality(graphics, paletteBorder, state);
                var flags = GetTextFormatFlags(paletteContent, state);
                var font = paletteContent.GetContentShortTextFont(state);
                var contentShortTextColor1 = paletteContent.GetContentShortTextColor1(state);

                var penWidth = pen.Width;

                var rectangle = new Rectangle((int)(graphics.VisibleClipBounds.X + penWidth), (int)(y + penWidth),
                    (int)(totalColWidth - penWidth), (int)(ItemHeight - penWidth)); if (paletteBack.GetBackDraw(state) == InheritBool.True)
                {
                    graphics.FillRectangle(brush, rectangle);
                }
                // Fill in text
                TextRenderer.DrawText(graphics, @"Designer", font, rectangle, contentShortTextColor1, flags);

                y += ItemHeight;
                if (paletteBorder.GetBorderDraw(state) == InheritBool.True)
                {
                    graphics.DrawLine(pen, graphics.VisibleClipBounds.X + penWidth, y,
                        totalColWidth, y);
                }


                if (y > graphics.VisibleClipBounds.Bottom)
                {
                    break;
                }
            }


            if (paletteBorderEven.GetBorderDraw(stateEven) == InheritBool.True)
            {
                var currentWidthOffset = penEven.Width;
                foreach (VirtualTreeColumn col in _kryptonVirtualTreeColumnView.Header.Columns)
                {
                    graphics.DrawLine(penEven, currentWidthOffset, useHeaderHeight, currentWidthOffset, y);
                    currentWidthOffset += col.Width;
                }

                currentWidthOffset = totalColWidth;
                graphics.DrawLine(penEven, currentWidthOffset, useHeaderHeight, currentWidthOffset, y);
            }
        }

        private int TotalWidth()
        {
            return _kryptonVirtualTreeColumnView.Header.Columns.Sum(col => col.Width);
        }

        #endregion

        #region Internal

        internal IReadOnlyList<VirtualTreeRowNode> SelectedNodes => _selectedNodeSet.ToArray();

        internal int ItemHeight { get; set; } = 16;

        internal bool CheckBoxes { get; set; }

        internal bool MultiSelect { get; set; }

        internal bool HideSelection { get; set; }

        internal bool HotTracking { get; set; }

        internal int ImageIndex { get; set; } = -1;

        internal string ImageKey { get; set; } = string.Empty;

        internal ImageList ImageList { get; set; }

        internal int SelectedImageIndex { get; set; } = -1;

        internal string SelectedImageKey { get; set; } = string.Empty;

        internal VirtualTreeRowNode SelectedNode
        {
            get => _selectedNodeSet.FirstOrDefault();
            set
            {
                _selectedNodeSet.Clear();
                AddSelected(value);
                _kryptonVirtualTreeColumnView.PerformNeedPaint(false);
            }
        }

        internal bool ShowLines { get; set; } = true;

        internal bool ShowNodeToolTips { get; set; }

        internal bool ShowPlusMinus { get; set; } = true;

        internal bool ShowRootLines { get; set; } = true;

        internal ImageList StateImageList { get; set; }

        internal VirtualTreeRowNode VisibleRowNode
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        internal IComparer<VirtualTreeRowNode> TreeViewNodeSorter
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        internal int VisibleCount => GetPossibleOpenVisibleNodes().Count;

        internal IReadOnlyList<VirtualTreeRowNode> RootNodes => _hiddenRootNode?.Children ?? new List<VirtualTreeRowNode>();

        internal bool Sorted { get; set; }

        internal void AddSelected(VirtualTreeRowNode selected)
        {
            selected.RowNodeState |= RowNodeState.Selected;
            _selectedNodeSet.Add(selected);
        }

        internal void AddSelected(IReadOnlyList<VirtualTreeRowNode> selectedRows)
        {
            foreach (var selected in selectedRows)
            {
                selected.RowNodeState |= RowNodeState.Selected;
            }
            _selectedNodeSet.UnionWith(selectedRows);
            _kryptonVirtualTreeColumnView.PerformNeedPaint(false);
        }

        internal void RemoveSelected(VirtualTreeRowNode selected)
        {
            selected.RowNodeState &= ~RowNodeState.Selected;
            _selectedNodeSet.Remove(selected);
        }

        internal void RemoveSelected(IReadOnlyList<VirtualTreeRowNode> rows) => _selectedNodeSet.ExceptWith(rows);

        internal void ClearSelection()
        {
            var selectedRows = SelectedNodes;
            foreach (var selected in selectedRows)
            {
                selected.RowNodeState &= ~RowNodeState.Selected;
            }

            RemoveSelected(selectedRows);
            _kryptonVirtualTreeColumnView.PerformNeedPaint(false);
        }


        #endregion Public
        private bool alreadyUpdating;

        internal void ReDrawView(Graphics g)
        {
            if (alreadyUpdating)
            {
                return;
            }

            try
            {
                alreadyUpdating = true;
                // TODO: Take into account padding against g.VisibleClipBounds
                //ApplyPadding

                // Draw header afterwards due to "Under-Draw" in the rows.
                DrawHeader(g);

                DrawRowNodes(g);
            }
            finally
            {
                alreadyUpdating = false;
            }
        }

        internal void CollapseAll()
        {
            static void CollapseNodes(IReadOnlyList<VirtualTreeRowNode> children)
            {
                foreach (VirtualTreeRowNode child in children.Where(child => child.Children.Any()))
                {
                    child.RowNodeState &= ~RowNodeState.Expanded;
                    CollapseNodes(child.Children);
                }
            }

            CollapseNodes(RootNodes);
            needPossibleVisibleUpdate = true;
        }

        internal void ExpandAll()
        {
            static void ExpandNodes(IReadOnlyList<VirtualTreeRowNode> children)
            {
                foreach (VirtualTreeRowNode child in children.Where(child => child.Children.Any()))
                {
                    child.RowNodeState |= RowNodeState.Expanded;
                    ExpandNodes(child.Children);
                }
            }

            ExpandNodes(RootNodes);
            needPossibleVisibleUpdate = true;
        }

        internal void Sort()
        {
            throw new NotImplementedException();
        }

        internal void BeginUpdate()
        {
            alreadyUpdating = true;
        }

        internal void EndUpdate()
        {
            alreadyUpdating = false;
            needPossibleVisibleUpdate = true;
            _kryptonVirtualTreeColumnView.PerformNeedPaint(true);
        }

        private List<VirtualTreeRowNode> visibleNodes;
        private bool needPossibleVisibleUpdate = true;

        private IReadOnlyList<VirtualTreeRowNode> GetPossibleOpenVisibleNodes()
        {
            if (needPossibleVisibleUpdate)
            {
                needPossibleVisibleUpdate = false;
                visibleNodes = new List<VirtualTreeRowNode>();
                GetOpenVisibleNodes(RootNodes, visibleNodes);
            }

            return visibleNodes;
        }

        private void GetOpenVisibleNodes(IReadOnlyList<VirtualTreeRowNode> children,
            List<VirtualTreeRowNode> virtualTreeRowNodes)
        {
            foreach (var child in children)
            {
                virtualTreeRowNodes.Add(child);
                if (child.RowNodeState.HasFlag(RowNodeState.Expanded))
                {
                    GetOpenVisibleNodes(child.Children, virtualTreeRowNodes);
                }
            }
        }


        internal VirtualTreeRowNode GetRowNodeAt(int x, int y)
        {
            var hdrHeight = 0;
            if (_kryptonVirtualTreeColumnView.Header.Visible)
            {
                hdrHeight = Math.Max(_kryptonVirtualTreeColumnView.Header.MinHeight, ItemHeight);
                if (y < hdrHeight)
                {
                    return _hiddenRootNode;
                }
            }

            var visibleNodes = GetPossibleOpenVisibleNodes();

            if (!visibleNodes.Any())
            {
                return null;
            }

            var bounds = new Rectangle(0, 0, TotalWidth(), ItemHeight);

            for (var offset = 0; offset < visibleNodes.Count; offset++)
            {
                // Step until we start to get to the visible ones
                if (_kryptonVirtualTreeColumnView._vScrollBar.ScrollPosition > offset)
                {
                    continue;
                }

                var displayOffset = offset;
                if (_kryptonVirtualTreeColumnView._vScrollBar.Visible)
                {
                    displayOffset -= _kryptonVirtualTreeColumnView._vScrollBar.ScrollPosition;
                }

                bounds.Y = (displayOffset * ItemHeight) + hdrHeight;
                if (bounds.Contains(x, y))
                {
                    return visibleNodes[offset];
                }
            }

            return null;
        }

        private int GetColumnAt(int y)
        {
            var offsetCol = 0;
            foreach (VirtualTreeColumn col in _kryptonVirtualTreeColumnView.Header.Columns)
            {
                var startPos = col.StartPos;
                if (_kryptonVirtualTreeColumnView._hScrollBar.Visible)
                {
                    startPos -= _kryptonVirtualTreeColumnView._hScrollBar.ScrollPosition;
                }

                if (y >= startPos
                    && y < startPos + col.Width
                   )
                {
                    return offsetCol;
                }

                offsetCol++;
            }

            return -1;
        }

        internal int GetNodeCount(bool includeSubTrees)
        {
            var rootNodes = RootNodes;
            return !includeSubTrees
                ? rootNodes.Count
                : rootNodes.Sum(child => GetNodeCount(child.Children));
        }

        internal int GetNodeCount(IReadOnlyList<VirtualTreeRowNode> children)
        {
            return children.Count + children.Sum(child => GetNodeCount(child.Children));
        }

        /// <summary>
        /// Add new node data to the tree
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="mode"></param>
        /// <param name="data"></param>
        /// <returns>Row for the data object provided</returns>
        internal VirtualTreeRowNode Add(VirtualTreeRowNode parentNode, NodeAttachPlacement mode, object data)
        {
            VirtualTreeRowNode newNode = new(data);

            if (parentNode == null)
            {
                mode = NodeAttachPlacement.InsertAfter;
            }

            switch (mode)
            {
                case NodeAttachPlacement.InsertAfter:
                case NodeAttachPlacement.InsertBefore:
                    if (parentNode == null)
                    {
                        var firstRootNode = _hiddenRootNode.Children.FirstOrDefault();
                        if (firstRootNode == null)
                        {
                            _hiddenRootNode.Children.Add(newNode);
                        }
                        else
                        {
                            if (mode == NodeAttachPlacement.InsertAfter)
                            {
                                var lastRootNode = _hiddenRootNode.Children.Last();
                                lastRootNode.NextSibling = newNode;
                                newNode.PreviousSibling = lastRootNode;
                                _hiddenRootNode.Children.Add(newNode);
                            }
                            else
                            {
                                firstRootNode.PreviousSibling = newNode;
                                _hiddenRootNode.Children.Insert(0, newNode);
                            }
                        }

                        newNode.Parent = _hiddenRootNode;
                    }
                    else
                    {
                        newNode.Level = parentNode.Level;
                        if (newNode.Level == 0)
                        {
                            newNode.Parent = _hiddenRootNode;
                        }

                        if (mode == NodeAttachPlacement.InsertAfter)
                        {
                            newNode.NextSibling = parentNode.NextSibling;
                            parentNode.NextSibling = newNode;
                            newNode.PreviousSibling = parentNode;
                        }
                        else
                        {
                            newNode.PreviousSibling = parentNode.PreviousSibling;
                            newNode.NextSibling = parentNode;
                            parentNode.PreviousSibling = newNode;
                        }
                    }

                    break;
                case NodeAttachPlacement.AddChildFirst:
                case NodeAttachPlacement.AddChildLast:
                    if (parentNode != null)
                    {
                        var firstChild = parentNode.Children.FirstOrDefault();
                        if (firstChild != null)
                        {
                            if (mode == NodeAttachPlacement.AddChildFirst)
                            {
                                firstChild.PreviousSibling = newNode;
                                newNode.NextSibling = firstChild;
                                newNode.Level = parentNode.Level + 1;
                                parentNode.Children.Insert(0, newNode);
                                newNode.Parent = parentNode;
                            }
                            else
                            {
                                var lastChild = parentNode.Children.Last();
                                lastChild.NextSibling = newNode;
                                parentNode.Children.Add(newNode);
                                newNode.Level = parentNode.Level + 1;
                                newNode.PreviousSibling = lastChild;
                                newNode.Parent = parentNode;
                            }
                        }
                        else
                        {
                            parentNode.Children.Add(newNode);
                            newNode.Level = parentNode.Level + 1;
                            newNode.Parent = parentNode;
                        }
                    }

                    break;
            }
            needPossibleVisibleUpdate = true;
            return newNode;
        }

        private void treePanel_Resize(object sender, EventArgs e)
        {
            if (_kryptonVirtualTreeColumnView?.Header?.Columns == null)
            {
                return;
            }

            var numberOfFills = 0f;
            var widthUsed = 0;
            foreach (VirtualTreeColumn col in _kryptonVirtualTreeColumnView.Header.Columns)
            {
                if (col.Fill)
                {
                    numberOfFills++;
                }
                else
                {
                    widthUsed += col.Width;
                }
            }

            var fillWidth = 0;
            if (numberOfFills > 0)
            {
                fillWidth = Math.Max(10, (int)((Width - widthUsed) / numberOfFills));
            }

            foreach (VirtualTreeColumn col in _kryptonVirtualTreeColumnView.Header.Columns.Where(col => col.Fill))
            {
                col.Width = fillWidth;
            }
            // Reset Scroll Bars
            SetVScrollVisibility(Height);
            SetHScrollVisibility(Width);

            _kryptonVirtualTreeColumnView.PerformNeedPaint(true);
        }

        private void DrawHeader(Graphics g)
        {
            PaletteState stateHdr = _kryptonVirtualTreeColumnView.GetCellTriple(Enabled ? RowNodeState.None : RowNodeState.Disabled, -1,
                out IPaletteBack paletteBackHdr,
                out IPaletteBorder paletteBorderHdr,
                out IPaletteContent paletteContentHdr);

            using var penHdr = new Pen(paletteBorderHdr.GetBorderColor1(stateHdr), paletteBorderHdr.GetBorderWidth(stateHdr));
            var currentWidthOffset = penHdr.Width;

            if (!_kryptonVirtualTreeColumnView.Header.Visible)
            {
                // initialise the cached drawing widths
                foreach (VirtualTreeColumn col in _kryptonVirtualTreeColumnView.Header.Columns)
                {
                    col.StartPos = (int)currentWidthOffset;
                    currentWidthOffset += col.Width;
                }

                return;
            }

            // Draw the header background
            var totalColWidth = Math.Min(TotalWidth(), g.VisibleClipBounds.Width);
            using var brushHdr = new SolidBrush(paletteBackHdr.GetBackColor1(stateHdr));
            var penWidth = penHdr.Width;
            totalColWidth += penWidth;

            if (paletteBackHdr.GetBackDraw(stateHdr) == InheritBool.True)
            {
                g.FillRectangle(brushHdr, g.VisibleClipBounds.X + penWidth, g.VisibleClipBounds.Y + penWidth,
                    totalColWidth, Math.Max(_kryptonVirtualTreeColumnView.Header.MinHeight, ItemHeight) - penWidth);
            }
            if (paletteBorderHdr.GetBorderDraw(stateHdr) == InheritBool.True)
            {
                g.DrawLine(penHdr, g.VisibleClipBounds.X + penWidth, g.VisibleClipBounds.Y,
                    totalColWidth, g.VisibleClipBounds.Y);
                g.DrawLine(penHdr, g.VisibleClipBounds.X + penWidth, g.VisibleClipBounds.Y + Math.Max(_kryptonVirtualTreeColumnView.Header.MinHeight, ItemHeight),
                    totalColWidth, g.VisibleClipBounds.Y + Math.Max(_kryptonVirtualTreeColumnView.Header.MinHeight, ItemHeight));
            }
            // Draw the Header Content
            if (paletteContentHdr.GetContentDraw(stateHdr) != InheritBool.True)
            {
                return;
            }

            // Set Font Quality for header
            SetTextRenderingHint(g, paletteContentHdr, stateHdr);

            SetLineQuality(g, paletteBorderHdr, stateHdr);

            var flags = GetTextFormatFlags(paletteContentHdr, stateHdr);

            var font = paletteContentHdr.GetContentShortTextFont(stateHdr);
            var contentShortTextColor1 = paletteContentHdr.GetContentShortTextColor1(stateHdr);

            SetHScrollVisibility(g.VisibleClipBounds.Width);

            foreach (VirtualTreeColumn col in _kryptonVirtualTreeColumnView.Header.Columns)
            {
                col.StartPos = (int)currentWidthOffset;
                var startPos = col.StartPos;
                if (_kryptonVirtualTreeColumnView._hScrollBar.Visible)
                {
                    startPos -= _kryptonVirtualTreeColumnView._hScrollBar.ScrollPosition;
                }

                if (paletteBorderHdr.GetBorderDraw(stateHdr) == InheritBool.True)
                {
                    g.DrawLine(penHdr, startPos, g.VisibleClipBounds.Y, currentWidthOffset,
                        Math.Max(_kryptonVirtualTreeColumnView.Header.MinHeight, ItemHeight));
                }

                // Fill in text
                TextRenderer.DrawText(g, col.Name, font, new Rectangle(startPos, (int)g.VisibleClipBounds.Y,
                        col.Width, Math.Max(_kryptonVirtualTreeColumnView.Header.MinHeight, ItemHeight)),
                    contentShortTextColor1, flags);
                // TODO: deal with focus etc.
                // GetContentDrawFocus
                // GetContentImageH
                // GetContentImageColorMap

                currentWidthOffset += col.Width;
            }
            currentWidthOffset = totalColWidth;
            if (paletteBorderHdr.GetBorderDraw(stateHdr) == InheritBool.True)
            {
                g.DrawLine(penHdr, currentWidthOffset, g.VisibleClipBounds.Y,
                    currentWidthOffset, Math.Max(_kryptonVirtualTreeColumnView.Header.MinHeight, ItemHeight));
            }

        }

        private void SetHScrollVisibility(float visibleWidth)
        {
            var totalWidth = TotalWidth();
            if (totalWidth > visibleWidth)
            {
                if (!_kryptonVirtualTreeColumnView._hScrollBar.Visible)
                {
                    _kryptonVirtualTreeColumnView._hScrollBar.Visible = true;
                    _kryptonVirtualTreeColumnView._hScrollBar.SetScrollValues(0, totalWidth, totalWidth / 10,
                        totalWidth / 3, 0);
                }
            }
            else if (_kryptonVirtualTreeColumnView._hScrollBar.Visible)
            {
                _kryptonVirtualTreeColumnView._hScrollBar.Visible = false;
                using ViewLayoutContext context = new(this, _kryptonVirtualTreeColumnView.Renderer);
                _kryptonVirtualTreeColumnView._hScrollBar.Layout(context);
            }
        }

        private static TextFormatFlags GetTextFormatFlags(IPaletteContent paletteContentHdr, PaletteState stateHdr)
        {
            var flags = TextFormatFlags.Default;
            switch (paletteContentHdr.GetContentShortTextH(stateHdr))
            {
                case PaletteRelativeAlign.Near:
                    flags |= TextFormatFlags.Left;
                    break;
                case PaletteRelativeAlign.Center:
                    flags |= TextFormatFlags.HorizontalCenter;
                    break;
                case PaletteRelativeAlign.Far:
                    flags |= TextFormatFlags.Right;
                    break;
                case PaletteRelativeAlign.Inherit:
                default:
                    break;
            }

            switch (paletteContentHdr.GetContentShortTextV(stateHdr))
            {
                case PaletteRelativeAlign.Near:
                    flags |= TextFormatFlags.Top;
                    break;
                case PaletteRelativeAlign.Center:
                    flags |= TextFormatFlags.VerticalCenter;
                    break;
                case PaletteRelativeAlign.Far:
                    flags |= TextFormatFlags.Bottom;
                    break;
                case PaletteRelativeAlign.Inherit:
                default:
                    break;
            }

            if (paletteContentHdr.GetContentShortTextMultiLine(stateHdr) != InheritBool.True)
            {
                flags |= TextFormatFlags.SingleLine;
            }

            return flags;
        }

        private static void SetLineQuality(Graphics g, IPaletteBorder paletteBorderHdr, PaletteState stateHdr)
        {
            switch (paletteBorderHdr.GetBorderGraphicsHint(stateHdr))
            {
                case PaletteGraphicsHint.None:
                    g.SmoothingMode = SmoothingMode.Default;
                    g.InterpolationMode = InterpolationMode.Default;
                    break;
                case PaletteGraphicsHint.AntiAlias:
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.InterpolationMode = InterpolationMode.HighQualityBilinear;
                    break;
                case PaletteGraphicsHint.Inherit:
                default:
                    g.SmoothingMode = SmoothingMode.HighSpeed;
                    g.InterpolationMode = InterpolationMode.High;
                    break;
            }
        }

        private static void SetTextRenderingHint(Graphics g, IPaletteContent paletteContentHdr, PaletteState stateHdr)
        {
            g.TextRenderingHint = paletteContentHdr.GetContentShortTextHint(stateHdr) switch
            {
                PaletteTextHint.AntiAlias => TextRenderingHint.AntiAlias,
                PaletteTextHint.AntiAliasGridFit => TextRenderingHint.AntiAliasGridFit,
                PaletteTextHint.ClearTypeGridFit => TextRenderingHint.ClearTypeGridFit,
                PaletteTextHint.SingleBitPerPixel => TextRenderingHint.SingleBitPerPixel,
                PaletteTextHint.SingleBitPerPixelGridFit => TextRenderingHint.SingleBitPerPixelGridFit,
                PaletteTextHint.Inherit => TextRenderingHint.SystemDefault,
                PaletteTextHint.SystemDefault => TextRenderingHint.SystemDefault,
                _ => TextRenderingHint.SystemDefault
            };
        }

        private void DrawRowNodes(Graphics g)
        {
            if (GetNodeCount(false) == 0)
            {
                return;
            }

            SetVScrollVisibility(g.VisibleClipBounds.Height);

            var visibleNodes = GetPossibleOpenVisibleNodes();

            for (var offset = 0; offset < visibleNodes.Count; offset++)
            {
                // Step until we start to get to the visible ones
                if (_kryptonVirtualTreeColumnView._vScrollBar.ScrollPosition > offset)
                {
                    continue;
                }

                if (DrawRowNode(visibleNodes[offset], offset, g))
                {
                    // has attempted to draw off the bottom of the view, i.e past scroll view
                    break;
                }
            }
        }

        private void SetVScrollVisibility(float visibleHeight)
        {
            var visibleCount = VisibleCount;
            var requiredVisHeight = visibleCount * ItemHeight;
            if (_kryptonVirtualTreeColumnView.Header.Visible)
            {
                requiredVisHeight += Math.Max(_kryptonVirtualTreeColumnView.Header.MinHeight, ItemHeight);
            }

            if (requiredVisHeight > visibleHeight)
            {
                if (!_kryptonVirtualTreeColumnView._vScrollBar.Visible)
                {
                    _kryptonVirtualTreeColumnView._vScrollBar.Visible = true;
                    _kryptonVirtualTreeColumnView._vScrollBar.SetScrollValues(0, visibleCount, 3, 10, 0);
                    _kryptonVirtualTreeColumnView.PerformNeedPaint(true);
                }
                else
                {
                    _kryptonVirtualTreeColumnView._vScrollBar.SetScrollValues(0, visibleCount, 3, 10, _kryptonVirtualTreeColumnView._vScrollBar.ScrollPosition);
                }
            }
            else if (_kryptonVirtualTreeColumnView._vScrollBar.Visible)
            {
                _kryptonVirtualTreeColumnView._vScrollBar.Visible = false;
                using ViewLayoutContext context = new(this, _kryptonVirtualTreeColumnView.Renderer);
                _kryptonVirtualTreeColumnView._vScrollBar.Layout(context);
            }
        }

        // Will return true if this has attempted to draw off the bottom of the view
        private bool DrawRowNode(VirtualTreeRowNode visibleNode, int rowOffset, Graphics graphics)
        {
            var displayOffset = rowOffset;
            if (_kryptonVirtualTreeColumnView._vScrollBar.Visible)
            {
                displayOffset -= _kryptonVirtualTreeColumnView._vScrollBar.ScrollPosition;
            }

            var requiredStartPos = displayOffset * ItemHeight;
            if (_kryptonVirtualTreeColumnView.Header.Visible)
            {
                requiredStartPos += Math.Max(_kryptonVirtualTreeColumnView.Header.MinHeight, ItemHeight);
            }

            var bounds = new Rectangle(0, requiredStartPos,
                (int)graphics.VisibleClipBounds.Width, ItemHeight);
            using (ViewLayoutContext context = new(this, _kryptonVirtualTreeColumnView.Renderer))
            {
                context.DisplayRectangle = bounds;
                ViewDrawPanel.Layout(context);
                _kryptonVirtualTreeColumnView._layoutDocker.Layout(context);
            }

            ViewDrawRowNode(visibleNode, graphics, bounds, rowOffset);

            return (bounds.Bottom > graphics.VisibleClipBounds.Bottom);
        }

        private int NodeIndent(VirtualTreeRowNode node, bool ignoreImage)
        {
            var depth = 0; // Do not show Hidden root

            // Count depth of our node in tree
            VirtualTreeRowNode current = node;
            while (current != null)
            {
                depth++;
                current = current.Parent;
            }

            // Do we need the root level indent?
            if (!ShowRootLines)
            {
                depth--;
            }

            var nodeIndent = depth * 16; // fixed width for drawing lines

            if (!ignoreImage)
            {
                if (_kryptonVirtualTreeColumnView._layoutImageStack.Visible)
                {
                    nodeIndent += _kryptonVirtualTreeColumnView._layoutImageStack.ClientWidth;
                }
                //if (_kryptonVirtualTreeColumnView._layoutImageCenterState.Visible)
                //{
                //    nodeIndent += _kryptonVirtualTreeColumnView._layoutImageCenterState.ClientWidth;
                //}
            }

            return nodeIndent;
        }

        internal void ViewDrawRowNode(VirtualTreeRowNode rowNode, Graphics graphics, Rectangle bounds, int rowOffset)
        {
            // We cannot do anything without a valid node
            if (rowNode == null)
            {
                return;
            }

            // Work out if we need to draw a state image
            Image drawStateImage = null;
            if (StateImageList != null)
            {
                try
                {
                    // If showing check boxes then used fixed entries from the state image list
                    if (CheckBoxes)
                    {
                        if (rowNode.IsCheckBoxVisible)
                        {
                            drawStateImage = rowNode.RowNodeState.HasFlag(RowNodeState.Checked) ? StateImageList.Images[1] : StateImageList.Images[0];
                        }
                    }
                    else
                    {
                        // Check node values before tree level values
                        if ((rowNode.SelectedImageIndex >= 0) && (rowNode.SelectedImageIndex < StateImageList.Images.Count))
                        {
                            drawStateImage = StateImageList.Images[rowNode.SelectedImageIndex];
                        }
                    }
                }
                catch
                {
                    // ignored
                }
            }

            _kryptonVirtualTreeColumnView._layoutImageCenterState.Visible = (drawStateImage != null);

            // Do we need the check box?
            _kryptonVirtualTreeColumnView._layoutCheckBoxStack.Visible = (StateImageList == null)
                                                                         && CheckBoxes
                                                                         && (rowNode.IsCheckBoxVisible);
            if (_kryptonVirtualTreeColumnView._layoutCheckBoxStack.Visible)
            {
                _kryptonVirtualTreeColumnView._drawCheckBox.CheckState = rowNode.RowNodeState.HasFlag(RowNodeState.Checked) ? CheckState.Checked : CheckState.Unchecked;
            }

            // By default the button is in the normal state
            PaletteState buttonState;

            // Is this item disabled
            if (rowNode.RowNodeState.HasFlag(RowNodeState.Disabled))
            {
                buttonState = PaletteState.Disabled;
            }
            else
            {
                // If selected then show as a checked item
                if (rowNode.RowNodeState.HasFlag(RowNodeState.Selected))
                {
                    _kryptonVirtualTreeColumnView._drawRow.Checked = true;

                    buttonState = rowNode.RowNodeState.HasFlag(RowNodeState.Tracking)
                        ? PaletteState.CheckedTracking
                        : PaletteState.CheckedNormal;
                }
                else
                {
                    _kryptonVirtualTreeColumnView._drawRow.Checked = false;

                    buttonState = rowNode.RowNodeState.HasFlag(RowNodeState.Tracking)
                        ? PaletteState.Tracking
                        : PaletteState.Normal;
                }

            }

            // Update the view with the calculated state
            _kryptonVirtualTreeColumnView._drawRow.ElementState = buttonState;

            PaletteState state = _kryptonVirtualTreeColumnView.GetCellTriple(Enabled ? rowNode.RowNodeState : RowNodeState.Disabled, rowOffset,
                out IPaletteBack _,
                out IPaletteBorder paletteBorder,
                out IPaletteContent paletteContent);
            var penWidth = paletteBorder.GetBorderWidth(state);
            bounds.Height += penWidth;
            bounds.X += 2 * penWidth;
            bounds.Width -= 4 * penWidth;

            // Create indent rectangle and adjust bounds for remainder
            var nodeIndent = NodeIndent(rowNode, false);

            PopulateDrawRowNode(bounds, nodeIndent, rowNode, graphics, rowOffset);

            // Do we have a indent area for drawing plus/minus/lines?
            var indent = NodeIndent(rowNode, true);
            Rectangle indentBounds = new(bounds.X, bounds.Y, indent, bounds.Height);
            if (indentBounds.X >= 0)
            {
                // Do we draw lines between nodes?
                if (ShowLines)
                {
                    // Find center points
                    var hCenter = (indentBounds.X + (indentBounds.Width - 16)) - 1;
                    var vCenter = indentBounds.Y + (indentBounds.Height / 2);
                    vCenter -= vCenter % 2;

                    // Default to showing full line height
                    var top = indentBounds.Y;
                    top -= (top + 1) % 2;
                    var bottom = indentBounds.Bottom;

                    // If the first root node then do not show top half of line
                    if ((rowNode.Parent == null) && (rowNode.PreviousSibling == null))
                    {
                        top = vCenter;
                    }

                    // If the last node in collection then do not show bottom half of line
                    if (rowNode.NextSibling == null)
                    {
                        bottom = vCenter;
                    }

                    // Draw the horizontal and vertical lines
                    Color lineColor = paletteContent.GetContentShortTextColor1(state);
                    using Pen linePen = new(lineColor);
                    linePen.DashStyle = DashStyle.Dot;
                    linePen.DashOffset = 16 % 2;
                    graphics.DrawLine(linePen, hCenter, top, hCenter, bottom);
                    graphics.DrawLine(linePen, hCenter - 1, vCenter, indentBounds.Right, vCenter);
                    hCenter -= 16;

                    // Draw the vertical lines for previous node levels
                    var parent = rowNode.Parent;
                    while (hCenter >= 0)
                    {
                        if (parent?.NextSibling != null)
                        {
                            var begin = indentBounds.Y;
                            begin -= (begin + 1) % 2;
                            graphics.DrawLine(linePen, hCenter, begin, hCenter, indentBounds.Bottom);
                        }
                        parent = parent?.Parent;
                        hCenter -= 16;
                    }
                }

                // Do we draw any plus/minus images in indent bounds?
                if (ShowPlusMinus && (rowNode.Children.Count > 0))
                {
                    Image drawImage =
                        _kryptonVirtualTreeColumnView._redirectImages.GetTreeViewImage(rowNode.RowNodeState.HasFlag(RowNodeState.Expanded));
                    if (drawImage != null)
                    {
                        graphics.DrawImage(drawImage, new Rectangle(
                            (indentBounds.X + (indentBounds.Width - (16 * 2))),
                            indentBounds.Y + ((indentBounds.Height - drawImage.Height) / 2),
                            drawImage.Width, drawImage.Height));
                    }
                }
            }

            // Do we draw an image for the node?
            if (ImageList != null)
            {
                Image drawImage = null;
                var imageCount = ImageList.Images.Count;

                try
                {
                    // Check node values before tree level values
                    if ((rowNode.ImageIndex >= 0) && (rowNode.ImageIndex < imageCount))
                    {
                        drawImage = ImageList.Images[rowNode.ImageIndex];
                    }
                    else if (!string.IsNullOrEmpty(ImageKey))
                    {
                        drawImage = ImageList.Images[ImageKey];
                    }
                    else if ((ImageIndex >= 0) && (ImageIndex < imageCount))
                    {
                        drawImage = ImageList.Images[ImageIndex];
                    }

                    if (rowNode.RowNodeState.HasFlag(RowNodeState.Selected))
                    {
                        // Check node values before tree level values
                        if ((rowNode.SelectedImageIndex >= 0) && (rowNode.SelectedImageIndex < imageCount))
                        {
                            drawImage = ImageList.Images[rowNode.SelectedImageIndex];
                        }
                        else if (!string.IsNullOrEmpty(SelectedImageKey))
                        {
                            drawImage = ImageList.Images[SelectedImageKey];
                        }
                        else if ((SelectedImageIndex >= 0) && (SelectedImageIndex < imageCount))
                        {
                            drawImage = ImageList.Images[SelectedImageIndex];
                        }
                    }

                    if (drawImage != null)
                    {
                        Rectangle imageBounds = new(indent, bounds.Y, _kryptonVirtualTreeColumnView._layoutImage.ClientWidth, bounds.Height);
                        graphics.DrawImage(drawImage, imageBounds);
                    }
                }
                catch
                {
                    // ignored
                }
            }

            // Draw a node state image?
            if (_kryptonVirtualTreeColumnView._layoutImageCenterState.Visible)
            {
                if (drawStateImage != null)
                {
                    graphics.DrawImage(drawStateImage, _kryptonVirtualTreeColumnView._layoutImageState.ClientRectangle);
                }
            }
        }

        private void PopulateDrawRowNode(Rectangle rectangle, int nodeIndent, VirtualTreeRowNode rowNode,
            Graphics g, int rowOffset)
        {
            PaletteState state = _kryptonVirtualTreeColumnView.GetCellTriple(Enabled ? rowNode.RowNodeState : RowNodeState.Disabled, rowOffset,
                out IPaletteBack paletteBack,
                out IPaletteBorder paletteBorder,
                out IPaletteContent paletteContent);
            using var pen = new Pen(paletteBorder.GetBorderColor1(state), paletteBorder.GetBorderWidth(state));
            using var brush = new SolidBrush(rowNode.BackColor != Color.Empty ? rowNode.BackColor : paletteBack.GetBackColor1(state));
            var totalColWidth = Math.Min(TotalWidth(), g.VisibleClipBounds.Right);
            SetTextRenderingHint(g, paletteContent, state);
            SetLineQuality(g, paletteBorder, state);
            var flags = GetTextFormatFlags(paletteContent, state);
            var font = paletteContent.GetContentShortTextFont(state);
            var contentShortTextColor1 = paletteContent.GetContentShortTextColor1(state);

            if (paletteBack.GetBackDraw(state) == InheritBool.True)
            {
                g.FillRectangle(brush, rectangle);
            }

            if (paletteBorder.GetBorderDraw(state) == InheritBool.True)
            {
                g.DrawLine(pen, rectangle.Left, rectangle.Y, rectangle.Right, rectangle.Y);
                g.DrawLine(pen, rectangle.Left, rectangle.Y, rectangle.Left, rectangle.Bottom);
            }

            // Fill in text
            for (var index = 0; index < _kryptonVirtualTreeColumnView.Header.Columns.Count; index++)
            {
                VirtualTreeColumn col = _kryptonVirtualTreeColumnView.Header.Columns[index];
                var textRect = new Rectangle(col.StartPos, rectangle.Y,
                    col.Width, rectangle.Height);
                if (index == 0)
                {
                    textRect.X += nodeIndent;
                    textRect.Width -= nodeIndent;
                    var handled = false;
                    if (_kryptonVirtualTreeColumnView.DrawCell != null)
                    {
                        handled = _kryptonVirtualTreeColumnView.DrawCell(rowNode, index, g, textRect);
                    }

                    if (!handled)
                    {
                        // ReSharper disable once PossibleNullReferenceException - On Purpose to force implementer to write function
                        var text = _kryptonVirtualTreeColumnView.OnGetRowNodeCellText(rowNode, index);
                        var fnt = rowNode.FirstCellFont ?? font;
                        var clr = rowNode.FirstCellForeColor != Color.Empty
                            ? rowNode.FirstCellForeColor
                            : contentShortTextColor1;
                        TextRenderer.DrawText(g, text, fnt, textRect, clr, flags);
                    }
                }
                else
                {
                    var handled = false;
                    if (_kryptonVirtualTreeColumnView.DrawCell != null)
                    {
                        handled = _kryptonVirtualTreeColumnView.DrawCell(rowNode, index, g, textRect);
                    }

                    if (!handled)
                    {
                        TextRenderer.DrawText(g,
                            // ReSharper disable once PossibleNullReferenceException - On Purpose to force implementer to write function
                            _kryptonVirtualTreeColumnView.OnGetRowNodeCellText(rowNode, index),
                            font, textRect, contentShortTextColor1, flags);
                    }
                }

                if (paletteBorder.GetBorderDraw(state) == InheritBool.True)
                {
                    g.DrawLine(pen, textRect.Right, rectangle.Top,
                        textRect.Right, rectangle.Bottom);
                }

            }
        }

        internal void InternalTreeColumnView_MouseClick(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            var rowNode = GetRowNodeAt(e.X, e.Y);
            if (rowNode == null)
            {
                return;
            }

            var col = GetColumnAt(e.Y);
            if (col < 0)
            {
                return;
            }

            if (rowNode == _hiddenRootNode)
            {
                _kryptonVirtualTreeColumnView.OnHeaderClick?.Invoke(col);
                return;
            }

            if (rowNode.RowNodeState.HasFlag(RowNodeState.Disabled))
            {
                return;
            }

            // Check for row selection
            var nodeIndent = NodeIndent(rowNode, true) + 2;
            if (e.X > nodeIndent)
            {
                if (!MultiSelect
                    || !Control.ModifierKeys.HasFlag(Keys.Control)
                    // TODO: Deal with Shift-Select
                    )
                {
                    ClearSelection();
                }

                if (rowNode.RowNodeState.HasFlag(RowNodeState.Selected))
                {
                    // Unselect with same click
                    RemoveSelected(rowNode);
                }
                else
                {
                    AddSelected(rowNode);
                }

                _kryptonVirtualTreeColumnView.PerformNeedPaint(false);
                _kryptonVirtualTreeColumnView.OnSelectionChanged?.Invoke(rowNode, col);
                return;
            }

            // So it must be in the lines area
            // TODO: Deal with the checkboxes
            if (!rowNode.Children.Any())
            {
                return;
            }

            needPossibleVisibleUpdate = true;
            rowNode.RowNodeState ^= RowNodeState.Expanded;
            _kryptonVirtualTreeColumnView.OnRowNodeExpanded?.Invoke(rowNode);
            _kryptonVirtualTreeColumnView.PerformNeedPaint(false);
        }

        public void EnsureRowVisible(VirtualTreeRowNode targetRow)
        {
            var parent = targetRow.Parent;
            while (parent != null
                   && parent != _hiddenRootNode)
            {
                parent.RowNodeState |= RowNodeState.Expanded;
                parent = parent.Parent;
            }
            needPossibleVisibleUpdate = true;

            var visibleRows = GetPossibleOpenVisibleNodes().ToArray();
            var scrollOffset = Math.Max(0, Array.IndexOf(visibleRows, targetRow) - 2);
            _kryptonVirtualTreeColumnView._vScrollBar.SetScrollValues(0, visibleRows.Length, 3, 10, scrollOffset);
            _kryptonVirtualTreeColumnView.PerformNeedPaint(true);
            // System.Reflection
            //var mi = typeof(ViewDrawScrollBar).GetField(@"_scrollBar", BindingFlags.NonPublic | BindingFlags.Instance);
            ////_kryptonVirtualTreeColumnView._vScrollBar.ScrollPosition = scrollOffset;
            //if (mi?.GetValue(_kryptonVirtualTreeColumnView._vScrollBar) is ScrollBar internalBar)
            //{
            //    internalBar.Value = scrollOffset;
            //}
        }

    }
}
