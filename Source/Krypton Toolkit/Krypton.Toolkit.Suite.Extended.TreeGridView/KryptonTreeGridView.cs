#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Krypton.Toolkit.Suite.Extended.TreeGridView
{
    /// <summary>
    /// Summary description for TreeGridView.
    /// </summary>
    [DesignerCategory("code"),
    Designer(typeof(System.Windows.Forms.Design.ControlDesigner)),
    ComplexBindingProperties(),
    Docking(DockingBehavior.Ask)]
    public class KryptonTreeGridView : KryptonDataGridView
    {
        //private int _indentWidth;
        private readonly KryptonTreeGridNodeRow _root;
        private KryptonTreeGridColumn? _expandableColumn;

        private bool _inExpandCollapse;
        internal bool InExpandCollapseMouseCapture;
        private Control? _hideScrollBarControl;
        private bool _showLines = true;
        private DataTable _dataSource;
        
        internal VisualStyleRenderer? ROpen; // = new VisualStyleRenderer(VisualStyleElement.TreeView.Glyph.Opened);
        internal VisualStyleRenderer? RClosed; // = new VisualStyleRenderer(VisualStyleElement.TreeView.Glyph.Closed);

        #region Constructor
        public KryptonTreeGridView()
        {
            // Control when edit occurs because edit mode shouldn't start when expanding/collapsing
            EditMode = DataGridViewEditMode.EditProgrammatically;
            RowTemplate = new KryptonTreeGridNodeRow();
            // This sample does not support adding or deleting rows by the user.
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            _root = new KryptonTreeGridNodeRow(this)
            {
                IsRoot = true
            };
            ShowLines = true;
            // Ensures that all rows are added unshared by listening to the CollectionChanged event.
            base.Rows.CollectionChanged += delegate { };
            try
            {
                // TODO: This should be the one from the Theme - See KryptonTree
                ROpen = new VisualStyleRenderer(VisualStyleElement.TreeView.Glyph.Opened);
                RClosed = new VisualStyleRenderer(VisualStyleElement.TreeView.Glyph.Closed);
            }
            catch
            {
                // TODO: Empty - Why ?
            }

        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            //UnSiteAll();
            if (disposing)
            {
                // Dispose managed resources
                _root?.Dispose();
                _hideScrollBarControl?.Dispose();
                _dataSource?.Dispose();
            }

            // Free native resources
        }

        #endregion

        #region Keyboard F2 to begin edit support
        protected override void OnKeyDown(KeyEventArgs e)
        {
            // Cause edit mode to begin since edit mode is disabled to support 
            // expanding/collapsing 
            base.OnKeyDown(e);
            if (!e.Handled)
            {
                if (e.KeyCode == Keys.F2 && CurrentCellAddress.X > -1 && CurrentCellAddress.Y > -1)
                {
                    if (!CurrentCell.Displayed)
                    {
                        FirstDisplayedScrollingRowIndex = CurrentCellAddress.Y;
                    }
                    else
                    {
                        // TODO:calculate if the cell is partially offscreen and if so scroll into view
                    }
                    SelectionMode = DataGridViewSelectionMode.CellSelect;
                    BeginEdit(true);
                }
                else if (e.KeyCode == Keys.Enter && !IsCurrentCellInEditMode)
                {
                    SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    CurrentCell.OwningRow.Selected = true;
                }
            }
        }
        #endregion

        #region Shadow and hide DGV properties

        [DefaultValue(false)]
        [Browsable(true), Category(@"DataSource-Usage")]
        public bool UseParentRelationship { get; set; } = false;

        [DefaultValue(@"ID")]
        [Browsable(true), Category(@"DataSource-Usage")]
        public string IdColumnName { get; set; } = @"ID";

        [DefaultValue(@"ParentID")]
        [Browsable(true), Category(@"DataSource-Usage")]
        public string ParentIdColumnName { get; set; } = @"ParentID";

        [DefaultValue(true)]
        [Browsable(true), Category(@"DataSource-Usage")]
        public bool IsOneLevel { get; set; } = true;

        [DefaultValue(1)]
        [Browsable(true), Category("Appearance-Extended")]
        [RefreshProperties(RefreshProperties.Repaint)]
        public int ImageIndexChild { get; set; } = 1;

        [DefaultValue(0)]
        [Browsable(true), Category("Appearance-Extended")]
        [RefreshProperties(RefreshProperties.Repaint)]
        public int ImageIndexParent { get; set; } = 0;

        [DefaultValue(true)]
        [Browsable(true), Category("Appearance-Extended")]
        [RefreshProperties(RefreshProperties.Repaint)]
        public bool FontParentBold { get; set; } = true;

        [DefaultValue(0)]
        [Browsable(true), Category(@"DataSource-Usage")]
        [RefreshProperties(RefreshProperties.Repaint)]
        public int GroupByColumnIndex { get; set; } = 0;

        [Browsable(true), Category(@"DataSource-Usage")]
        [RefreshProperties(RefreshProperties.Repaint)]
        [AttributeProvider(typeof(IListSource))]
        public new DataTable DataSource
        {
            get => _dataSource;
            set
            {
                if (value != null)
                {
                    _dataSource = value;

                    //-------------------------- 
                    //Clear nodes and columns
                    //-------------------------- 
                    GridNodes.Clear();
                    Columns.Clear();

                    if (GroupByColumnIndex != 0)
                    {
                        _dataSource.Columns[GroupByColumnIndex].SetOrdinal(0);
                    }

                    //-------------------------- 
                    //Sort Data
                    //-------------------------- 
                    _dataSource = FilterSortData(_dataSource, string.Empty, _dataSource.Columns[0].ColumnName);

                    //-------------------------- 
                    //Add Columns
                    //-------------------------- 
                    for (var i = 0; i < _dataSource.Columns.Count; i++)
                    {
                        if (i == 0)
                        {
                            //-------------------------- 
                            //Add new Columns - 0
                            //-------------------------- 
                            var clm = new KryptonTreeGridColumn
                            {
                                HeaderText = _dataSource.Columns[i].ColumnName,
                                DataPropertyName = _dataSource.Columns[i].ColumnName,
                                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            };
                            Columns.Add(clm);
                        }
                        else
                        {
                            //-------------------------- 
                            //Others
                            //-------------------------- 
                            var dgvtbc = new DataGridViewTextBoxColumn
                            {
                                HeaderText = _dataSource.Columns[i].ColumnName,
                                DataPropertyName = _dataSource.Columns[i].ColumnName,
                                AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                            };
                            Columns.Add(dgvtbc);
                        }
                    }

                    if (UseParentRelationship)
                    {
                        //-------------------------- 
                        //Sort Data
                        //-------------------------- 
                        _dataSource = FilterSortData(_dataSource, string.Empty, ParentIdColumnName);
                        //-------------------------- 
                        //Init nodes
                        //-------------------------- 
                        BuildPortsNodesInitialLoop(_dataSource, IdColumnName, ParentIdColumnName);
                    }
                    else
                    {
                        //-------------------------- 
                        //Setup font
                        //-------------------------- 
                        var boldFont = new Font(DefaultCellStyle.Font, FontStyle.Bold);

                        //-------------------------- 
                        //for hierarchy
                        //-------------------------- 
                        var isChild = false;

                        //-------------------------- 
                        //Init nodes
                        //-------------------------- 
#pragma warning disable CA2000 // Dispose objects before losing scope
                        var node = new KryptonTreeGridNodeRow();
                        var parentNode = new KryptonTreeGridNodeRow();
#pragma warning restore CA2000 // Dispose objects before losing scope

                        //-------------------------- 
                        //Columns Collection
                        //-------------------------- 
                        var c = new string[_dataSource.Columns.Count];

                        //-------------------------- 
                        //Init RowCounter
                        //-------------------------- 
                        var k = 0;

                        foreach (DataRow dr in _dataSource.Rows)
                        {
                            //-------------------------- 
                            // Retrieve columns
                            //-------------------------- 
                            var p = new string[_dataSource.Columns.Count];

                            for (var i = 0; i < _dataSource.Columns.Count; i++)
                            {
                                p[i] = dr[i].ToString().Trim();
                                if (k > 0 && i == 0 && p[i] == c[i])
                                {
                                    isChild = true;
                                }
                            }
                            //-------------------------- 
                            // Inserts a row
                            //-------------------------- 
                            if (isChild)
                            {
                                if (IsOneLevel)
                                {
                                    //-------------------------- 
                                    //set Child values
                                    //-------------------------- 
                                    node = parentNode.Nodes.Add(p);
                                    node.ImageIndex = ImageIndexChild;
                                    //-------------------------- 
                                    //set parent values
                                    //-------------------------- 
                                    //set bold
                                    //-------------------------- 
                                    if (FontParentBold)
                                    {
                                        parentNode.DefaultCellStyle.Font = new Font(DefaultCellStyle.Font, FontStyle.Bold);
                                    }

                                    parentNode.ImageIndex = ImageIndexParent;
                                }
                                else
                                {
                                    //-------------------------- 
                                    //set Child values
                                    //-------------------------- 
                                    node = node.Nodes.Add(p);
                                    node.ImageIndex = ImageIndexChild;
                                    //-------------------------- 
                                    //set parent values
                                    //-------------------------- 
                                    parentNode.ImageIndex = ImageIndexParent;
                                }
                                isChild = false;
                            }
                            else
                            {
                                if (IsOneLevel)
                                {
                                    parentNode = GridNodes.Add(p);
                                    parentNode.ImageIndex = ImageIndexChild;
                                }
                                else
                                {
                                    node = GridNodes.Add(p);
                                    node.ImageIndex = ImageIndexParent;
                                    //-------------------------- 
                                    //set bold
                                    //-------------------------- 
                                    if (FontParentBold)
                                    {
                                        node.DefaultCellStyle.Font = new Font(DefaultCellStyle.Font, FontStyle.Bold);
                                    }
                                }
                            }
                            //Nodes.Add(p);
                            k++;
                            c = (string[])p.Clone();
                        }
                        boldFont.Dispose();
                    }
                }
            }
        }

        // This sample does not support databinding
        [Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        EditorBrowsable(EditorBrowsableState.Never)]
#pragma warning disable CA1061 // Do not hide base class methods
        public new object DataMember
        {
            get => null;
            set => throw new NotSupportedException(@"The TreeGridView does not support databinding");
        }
#pragma warning restore CA1061 // Do not hide base class methods

        [Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        EditorBrowsable(EditorBrowsableState.Never)]
        public new DataGridViewRowCollection Rows => base.Rows;

        [Browsable(false),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
         EditorBrowsable(EditorBrowsableState.Never)]
        public new bool VirtualMode
        {
            get => false;
            set => throw new NotSupportedException(@"The TreeGridView does not support virtual mode");
        }

        // none of the rows/nodes created use the row template, so it is hidden.
        [Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        EditorBrowsable(EditorBrowsableState.Never)]
        public new DataGridViewRow RowTemplate
        {
            get => base.RowTemplate;
            set => base.RowTemplate = value;
        }

        #endregion

        #region Public methods
        [Description("Returns the TreeGridNode for the given DataGridViewRow")]
        public KryptonTreeGridNodeRow GetNodeForRow(DataGridViewRow row) => row as KryptonTreeGridNodeRow;

        [Description("Returns the TreeGridNode for the given DataGridViewRow")]
        public KryptonTreeGridNodeRow GetNodeForRow(int index) => GetNodeForRow(base.Rows[index]);


        /// <summary>
        /// FilterSortData is used to sort a datatable directly.
        /// </summary>
        /// <param name="dtStart">The DataTable to be sorted.</param>
        /// <param name="filter">A way to filter out certain rows from the table.</param>
        /// <param name="sort">A way to sort the table (i.e. "State IN 'CA'")</param>
        /// <returns>A Sorted/Filtered DataTable</returns>
        public static DataTable FilterSortData(DataTable dtStart, string filter, string sort)
        {
            DataTable? dt = dtStart.Clone();
            var drs = dtStart.Select(filter, sort);
            foreach (DataRow dr in drs)
            {
                dt.ImportRow(dr);
            }
            dtStart.Dispose();
            return dt;
        }
        #endregion

        #region Public properties
        [Description("The collection of root nodes in the treelist."),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
        Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
        [Browsable(true), Category("Appearance-Extended")]
        public TreeGridNodeCollection GridNodes => _root.Nodes;

        public new KryptonTreeGridNodeRow CurrentRow => base.CurrentRow as KryptonTreeGridNodeRow;

        [DefaultValue(false),
         Description("Causes nodes to always show as expandable. Use the NodeExpanding event to add nodes.")]
        [Browsable(true), Category("Appearance-Extended")]
        public bool VirtualNodes { get; set; }

        public KryptonTreeGridNodeRow CurrentNode => CurrentRow;

        [DefaultValue(true)]
        [Browsable(true), Category("Appearance-Extended")]
        public bool ShowLines
        {
            get => _showLines;
            set
            {
                if (value != _showLines)
                {
                    _showLines = value;
                    Invalidate();
                }
            }
        }

        [Browsable(true), Category("Appearance-Extended")]
        [RefreshProperties(RefreshProperties.Repaint)]
        public ImageList ImageList { get; set; } //TODO: should we invalidate cell styles when setting the image list?

        [Browsable(true), Category("Appearance-Extended")]
        public new int RowCount
        {
            get => GridNodes.Count;
            set
            {
                for (var i = 0; i < value; i++)
                {
                    GridNodes.Add(new KryptonTreeGridNodeRow());
                }
            }
        }
        #endregion

        #region

        private void BuildPortsNodes(bool firstLoop, string itemId, DataTable dt, string idColumnName, string parentIdColumnName, int uniqueId)
        {
            var netItems = 0;

            using var dv = new DataView(dt);
            if (firstLoop)
            {
                dv.RowFilter = $"{idColumnName}={parentIdColumnName}";
                using var rootNode = new KryptonTreeGridNodeRow();
                uniqueId = rootNode.UniqueValue;
            }
            else
            {
                dv.RowFilter = $"{parentIdColumnName}={itemId} AND {idColumnName}<>{itemId}";
            }

            if (dv.Count > 0)
            {
                try
                {
                    for (netItems = 0; netItems <= dv.Count - 1; netItems++)
                    {

                        //-------------------------- 
                        //Add Node
                        //-------------------------- 

                        // Retrieve columns
                        var p = new string[dt.Columns.Count];

                        for (var i = 0; i < dt.Columns.Count; i++)
                        {
                            p[i] = dv[netItems][i].ToString().Trim();
                        }

                        //-------------------------- 
                        //Add Node
                        //-------------------------- 
                        KryptonTreeGridNodeRow? rootNode = GridNodes.GetNodeByUniqueValue(uniqueId);

                        if (rootNode.UniqueValue == -10)
                        {
                            //empty node
                            rootNode = new KryptonTreeGridNodeRow();
                        }

                        var netItemNode = rootNode.Nodes.Add(p);

                        uniqueId = netItemNode.UniqueValue;

                        BuildPortsNodes(false, dv[netItems][idColumnName].ToString(), dt, idColumnName, parentIdColumnName, uniqueId);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, $@"Failed to add item {netItems}", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BuildPortsNodesInitialLoop(DataTable dt, string idColumnName, string parentIdColumnName)
        {
            using var dv = new DataView(dt)
            {
                RowFilter = $@"{idColumnName}={parentIdColumnName}"
            };

            if (dv.Count > 0)
            {
                for (int items = 0; items <= dv.Count - 1; items++)
                {
                    //-------------------------- 
                    // Retrieve columns
                    //-------------------------- 
                    var p = new string[dt.Columns.Count];

                    for (var i = 0; i < dt.Columns.Count; i++)
                    {
                        p[i] = dv[items][i].ToString().Trim();
                    }

                    //-------------------------- 
                    //Add Node
                    //-------------------------- 
                    var rootNode = GridNodes.Add(p);

                    var itemId = dv[items][idColumnName].ToString();
                    BuildPortsNodesOtherLoops(itemId, dt, idColumnName, parentIdColumnName, rootNode);
                }
            }
        }

        private void BuildPortsNodesOtherLoops(string itemId, DataTable dt, string idColumnName, string parentIdColumnName, KryptonTreeGridNodeRow parentNode)
        {
            //create filtered data
            using var dv = new DataView(dt)
            {
                RowFilter = $"{parentIdColumnName}={itemId} AND {idColumnName}<>{parentIdColumnName}"
            };

            //get the parent node based on unique value
            if (dv.Count > 0)
            {
                //set Image Index
                parentNode.ImageIndex = ImageIndexParent;

                //set bold
                if (FontParentBold)
                {
                    parentNode.DefaultCellStyle.Font = new Font(DefaultCellStyle.Font, FontStyle.Bold);
                }

                for (var items = 0; items <= dv.Count - 1; items++)
                {
                    // Retrieve columns
                    var p = new string[dt.Columns.Count];

                    for (var i = 0; i < dt.Columns.Count; i++)
                    {
                        p[i] = dv[items][i].ToString().Trim();
                    }
                    //-------------------------- 
                    //Add Node
                    //-------------------------- 
                    KryptonTreeGridNodeRow? childNode = parentNode.Nodes.Add(p);

                    var item = dv[items][idColumnName].ToString();

                    BuildPortsNodesOtherLoops(item, dt, idColumnName, parentIdColumnName, childNode);
                }

            }
            else
            {
                //set Image Index
                parentNode.ImageIndex = ImageIndexChild;
            }
        }
        #endregion

        #region Site nodes and collapse/expand support
        protected override void OnRowsAdded(DataGridViewRowsAddedEventArgs e)
        {
            base.OnRowsAdded(e);
            // Notify the row when it is added to the base grid 
            var count = e.RowCount - 1;
            while (count >= 0)
            {
                if (base.Rows[e.RowIndex + count] is KryptonTreeGridNodeRow row)
                {
                    row.Sited();
                }
                count--;
            }
        }

        protected internal void UnSiteAll()
        {
            UnSiteNode(_root);
        }

        protected internal virtual void UnSiteNode(KryptonTreeGridNodeRow node)
        {
            if (node.IsSited || node.IsRoot)
            {
                // remove child rows first
                foreach (KryptonTreeGridNodeRow childNode in node.Nodes)
                {
                    UnSiteNode(childNode);
                }

                // now remove this row except for the root
                if (!node.IsRoot)
                {
                    try
                    {
                        base.Rows.Remove(node);
                        // Row isn't sited in the grid anymore after remove. Note that we cannot
                        // Use the RowRemoved event since we cannot map from the row index to
                        // the index of the expandable row/node.
                        node.UnSited();
                    }
                    catch
                    {
                        // TODO: Empty - Why ?
                        // Maybe: because the items have been added and then removed (incorrectly) by the owner
                    }
                }
            }
        }

        protected internal virtual bool CollapseNode(KryptonTreeGridNodeRow node)
        {
            if (node.IsExpanded)
            {
                var exp = new CollapsingEventArgs(node);
                OnNodeCollapsing(exp);

                if (!exp.Cancel)
                {
                    BeginUpdate();
                    _inExpandCollapse = true;
                    node.IsExpanded = false;

                    foreach (KryptonTreeGridNodeRow childNode in node.Nodes)
                    {
                        Debug.Assert(childNode.RowIndex != -1, @"Row is NOT in the grid.");
                        UnSiteNode(childNode);
                    }

                    var exped = new CollapsedEventArgs(node);
                    OnNodeCollapsed(exped);
                    //TODO: Convert this to a specific NodeCell property
                    _inExpandCollapse = false;
                    EndUpdate();
                    InvalidateCell(node.Cells[0]);

                }

                return !exp.Cancel;
            }
            else
            {
                // row isn't expanded, so we didn't do anything.
                return false;
            }
        }

        public void EndUpdate()
        {
            LockVerticalScrollBarUpdate(false);
            ResumeLayout(true);
            SendMessage(11, -1, 0);
            Invalidate();
        }

        public void BeginUpdate()
        {
            LockVerticalScrollBarUpdate(true);
            SuspendLayout();
            SendMessage(11, 0, 0);
        }

        private IntPtr SendMessage(int msg, int wParam, int lParam) => SendMessage(new HandleRef(this, Handle), msg, wParam, lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        private static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, int lParam);

        protected internal virtual void SiteNode(KryptonTreeGridNodeRow node)
        {
            //TODO: Raise exception if parent node is not the root or is not sited.
            KryptonTreeGridNodeRow? currentRow;
            node.Grid = this;

            if (node.Parent is { IsRoot: false })
            {
                // row is a child
                Debug.Assert(node.Parent is { IsExpanded: true });

                currentRow = node.Index > 0 ? node.Parent.Nodes[node.Index - 1] : node.Parent;
            }
            else
            {
                // row is being added to the root
                currentRow = node.Index > 0 ? node.Parent.Nodes[node.Index - 1] : null;
            }

            int rowIndex;
            if (currentRow != null)
            {
                while (currentRow.Level > node.Level)
                {
                    if (currentRow.RowIndex < base.Rows.Count - 1)
                    {
                        currentRow = base.Rows[currentRow.RowIndex + 1] as KryptonTreeGridNodeRow;
                        Debug.Assert(currentRow != null);
                    }
                    else
                    {
                        // no more rows, site this node at the end.
                        break;
                    }
                }
                if (currentRow == node.Parent)
                {
                    rowIndex = currentRow.RowIndex + 1;
                }
                else if (currentRow.Level < node.Level)
                {
                    rowIndex = currentRow.RowIndex;
                }
                else
                {
                    rowIndex = currentRow.RowIndex + 1;
                }
            }
            else
            {
                rowIndex = 0;
            }

            Debug.Assert(rowIndex != -1);
            SiteNode(node, rowIndex);

            Debug.Assert(node.IsSited);
            if (node.IsExpanded)
            {
                // add all child rows to display
                foreach (KryptonTreeGridNodeRow childNode in node.Nodes)
                {
                    //TODO: could use the more efficient SiteRow with index.
                    SiteNode(childNode);
                }
            }
        }


        protected internal virtual void SiteNode(KryptonTreeGridNodeRow node, int index)
        {
            if (index < base.Rows.Count)
            {
                base.Rows.Insert(index, node);
            }
            else
            {
                // for the last item.
                base.Rows.Add(node);
            }
        }

        protected internal virtual bool ExpandNode(KryptonTreeGridNodeRow node)
        {
            if (!node.IsExpanded || VirtualNodes)
            {
                var exp = new ExpandingEventArgs(node);
                OnNodeExpanding(exp);

                if (!exp.Cancel)
                {
                    BeginUpdate();
                    _inExpandCollapse = true;
                    node.IsExpanded = true;

                    //TODO Convert this to a InsertRange
                    foreach (KryptonTreeGridNodeRow childNode in node.Nodes)
                    {
                        Debug.Assert(childNode.RowIndex == -1, @"Row is already in the grid.");

                        SiteNode(childNode);
                    }

                    var exped = new ExpandedEventArgs(node);
                    OnNodeExpanded(exped);
                    //TODO: Convert this to a specific NodeCell property
                    _inExpandCollapse = false;
                    EndUpdate();
                    InvalidateCell(node.Cells[0]);
                }

                return !exp.Cancel;
            }
            else
            {
                // row is already expanded, so we didn't do anything.
                return false;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            // used to keep extra mouse moves from selecting more rows when collapsing
            base.OnMouseUp(e);
            InExpandCollapseMouseCapture = false;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            // while we are expanding and collapsing a node mouse moves are
            // supressed to keep selections from being messed up.
            if (!InExpandCollapseMouseCapture)
            {
                base.OnMouseMove(e);
            }
        }

        [Description("Expands all nodes")]
        public void ExpandAll()
        {
            foreach (KryptonTreeGridNodeRow node in GridNodes)
            {
                ExpandAllImp(node);
            }
        }

        private void ExpandAllImp(KryptonTreeGridNodeRow node)
        {

            if (node.Nodes.Count > 0)
            {
                node.Expand();
                foreach (var subNode in node.Nodes)
                {
                    ExpandAllImp(subNode);
                }
            }
        }

        [Description("Collapse all nodes")]
        public void CollapseAll()
        {
            foreach (var node in GridNodes)
            {
                CollapseAllImp(node);
            }
        }

        private void CollapseAllImp(KryptonTreeGridNodeRow node)
        {
            if (node.Nodes.Count > 0)
            {
                foreach (var subNode in node.Nodes)
                {
                    CollapseAllImp(subNode);
                }
                node.Collapse();
            }
        }
        #endregion

        #region Collapse/Expand events
        public event ExpandingEventHandler? NodeExpanding;
        public event ExpandedEventHandler? NodeExpanded;
        public event CollapsingEventHandler? NodeCollapsing;
        public event CollapsedEventHandler? NodeCollapsed;

        protected virtual void OnNodeExpanding(ExpandingEventArgs e)
        {
            NodeExpanding?.Invoke(this, e);
        }
        protected virtual void OnNodeExpanded(ExpandedEventArgs e)
        {
            NodeExpanded?.Invoke(this, e);
        }
        protected virtual void OnNodeCollapsing(CollapsingEventArgs e)
        {
            NodeCollapsing?.Invoke(this, e);

        }
        protected virtual void OnNodeCollapsed(CollapsedEventArgs e)
        {
            NodeCollapsed?.Invoke(this, e);
        }
        #endregion

        #region Helper methods

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            // this control is used to temporarily hide the vertical scroll bar
            _hideScrollBarControl = new Control
            {
                Visible = false,
                Enabled = false,
                TabStop = false
            };
            // control is disposed automatically when the grid is disposed
            Controls.Add(_hideScrollBarControl);
        }

        protected override void OnRowEnter(DataGridViewCellEventArgs e)
        {
            // ensure full row select
            base.OnRowEnter(e);
            if (SelectionMode == DataGridViewSelectionMode.CellSelect
                || (SelectionMode == DataGridViewSelectionMode.FullRowSelect
                    && base.Rows[e.RowIndex].Selected == false)
                )
            {
                SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                base.Rows[e.RowIndex].Selected = true;
            }
        }

        private void LockVerticalScrollBarUpdate(bool lockUpdate/*, bool delayed*/)
        {
            // Temporarily hide/show the vertical scroll bar by changing its parent
            if (!_inExpandCollapse)
            {
                VerticalScrollBar.Parent = lockUpdate ? _hideScrollBarControl : this;
            }
        }

        protected override void OnColumnAdded(DataGridViewColumnEventArgs e)
        {
            if (e.Column is KryptonTreeGridColumn column)
            {
                if (_expandableColumn == null)
                {
                    // identify the expanding column.
                    _expandableColumn = column;
                }
                else
                {
                    // Columns.Remove(e.Column);
                    //throw new InvalidOperationException("Only one TreeGridColumn per TreeGridView is supported.");
                }
            }

            // Expandable Grid doesn't support sorting. This is just a limitation of the sample.
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;

            base.OnColumnAdded(e);
        }

        #endregion
    }
}