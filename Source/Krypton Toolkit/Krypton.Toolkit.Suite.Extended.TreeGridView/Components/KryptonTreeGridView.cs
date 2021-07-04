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
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Krypton.Toolkit.Suite.Extended.Tree.Grid.View
{
    /// <summary>
    /// Summary description for TreeGridView.
    /// </summary>
    [System.ComponentModel.DesignerCategory("code"),
    Designer(typeof(System.Windows.Forms.Design.ControlDesigner)),
    ComplexBindingProperties(),
    Docking(DockingBehavior.Ask)]
    public class KryptonTreeGridView : KryptonDataGridView
    {
        //private int _indentWidth;
        private TreeGridNode _root;
        private TreeGridColumn _expandableColumn;

        internal ImageList _imageList;
        private bool _inExpandCollapse = false;
        internal bool _inExpandCollapseMouseCapture = false;
        private Control hideScrollBarControl;
        private bool _showLines = true;
        private bool _virtualNodes = false;


        internal VisualStyleRenderer rOpen; // = new VisualStyleRenderer(VisualStyleElement.TreeView.Glyph.Opened);
        internal VisualStyleRenderer rClosed; // = new VisualStyleRenderer(VisualStyleElement.TreeView.Glyph.Closed);

        #region Constructor
        public KryptonTreeGridView()
        {
            // Control when edit occurs because edit mode shouldn't start when expanding/collapsing
            EditMode = DataGridViewEditMode.EditProgrammatically;
            RowTemplate = new TreeGridNode() as DataGridViewRow;
            // This sample does not support adding or deleting rows by the user.
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            _root = new TreeGridNode(this);
            _root.IsRoot = true;

            // Ensures that all rows are added unshared by listening to the CollectionChanged event.
            base.Rows.CollectionChanged += delegate (object sender, System.ComponentModel.CollectionChangeEventArgs e) { };
            try
            {
                rOpen = new VisualStyleRenderer(VisualStyleElement.TreeView.Glyph.Opened);
                rClosed = new VisualStyleRenderer(VisualStyleElement.TreeView.Glyph.Closed);
            }
            catch
            {
            }

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
        private bool useParentRelationship;
        [DefaultValue(false)]
        [Browsable(true), Category("Appearance-Extended")]
        public bool UseParentRelationship
        {
            get
            {
                return useParentRelationship;
            }
            set
            {
                useParentRelationship = value;
            }
        }

        private string iDColumnName;
        [DefaultValue("ID")]
        [Browsable(true), Category("Appearance-Extended")]
        public string IDColumnName
        {
            get
            {
                return iDColumnName;
            }
            set
            {
                iDColumnName = value;
            }
        }

        private string _parentIDColumnName;
        [DefaultValue("ParentID")]
        [Browsable(true), Category("Appearance-Extended")]
        public string ParentIDColumnName
        {
            get
            {
                return _parentIDColumnName;
            }
            set
            {
                _parentIDColumnName = value;
            }
        }

        private bool isOneLevel;
        [DefaultValue(true)]
        [Browsable(true), Category("Appearance-Extended")]
        public bool IsOneLevel
        {
            get
            {
                return isOneLevel;
            }
            set
            {
                isOneLevel = value;
            }
        }

        private int imageIndexChild;
        [DefaultValue(1)]
        [Browsable(true), Category("Appearance-Extended")]
        [RefreshProperties(RefreshProperties.Repaint)]
        public int ImageIndexChild
        {
            get
            {
                return imageIndexChild;
            }
            set
            {
                imageIndexChild = value;
            }
        }

        private int imageIndexParent;
        [DefaultValue(0)]
        [Browsable(true), Category("Appearance-Extended")]
        [RefreshProperties(RefreshProperties.Repaint)]
        public int ImageIndexParent
        {
            get
            {
                return imageIndexParent;
            }
            set
            {
                imageIndexParent = value;
            }
        }

        private bool fontParentBold;
        [DefaultValue(true)]
        [Browsable(true), Category("Appearance-Extended")]
        [RefreshProperties(RefreshProperties.Repaint)]
        public bool FontParentBold
        {
            get
            {
                return fontParentBold;
            }
            set
            {
                fontParentBold = value;
            }
        }

        private int groupByColumnIndex;
        [DefaultValue(0)]
        [Browsable(true), Category("Appearance-Extended")]
        [RefreshProperties(RefreshProperties.Repaint)]
        public int GroupByColumnIndex
        {
            get
            {
                return groupByColumnIndex;
            }
            set
            {
                groupByColumnIndex = value;
            }
        }

        private DataTable dataSource;
        [DefaultValue("")]
        [Browsable(true), Category("Appearance-Extended")]
        [RefreshProperties(RefreshProperties.Repaint)]
        [AttributeProvider(typeof(IListSource))]
        public new DataTable DataSource
        {
            get
            {
                return dataSource;
            }
            set
            {
                if (value != null)
                {
                    dataSource = value;

                    //-------------------------- 
                    //Clear nodes and columns
                    //-------------------------- 
                    GridNode.Clear();
                    Columns.Clear();

                    if (groupByColumnIndex != 0)
                    {
                        dataSource.Columns[groupByColumnIndex].SetOrdinal(0);
                    }

                    //-------------------------- 
                    //Sort Data
                    //-------------------------- 
                    dataSource = FilterSortData(dataSource, "", dataSource.Columns[0].ColumnName);

                    //-------------------------- 
                    //Add Columns
                    //-------------------------- 
                    for (int i = 0; i < dataSource.Columns.Count; i++)
                    {
                        if (i == 0)
                        {
                            //-------------------------- 
                            //Add new Columns - 0
                            //-------------------------- 
                            TreeGridColumn clm = new TreeGridColumn();
                            clm.HeaderText = dataSource.Columns[i].ColumnName;
                            clm.DataPropertyName = dataSource.Columns[i].ColumnName;
                            clm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
                            Columns.Add(clm);
                        }
                        else
                        {
                            //-------------------------- 
                            //Others
                            //-------------------------- 
                            DataGridViewTextBoxColumn dgvtbc = new DataGridViewTextBoxColumn();
                            dgvtbc.HeaderText = dataSource.Columns[i].ColumnName;
                            dgvtbc.DataPropertyName = dataSource.Columns[i].ColumnName;
                            dgvtbc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
                            Columns.Add(dgvtbc);
                        }
                    }

                    if (useParentRelationship)
                    {
                        //-------------------------- 
                        //Sort Data
                        //-------------------------- 
                        dataSource = FilterSortData(dataSource, "", _parentIDColumnName);
                        //-------------------------- 
                        //Init nodes
                        //-------------------------- 
                        BuildPortsNodesInitialLoop("", dataSource, iDColumnName, _parentIDColumnName, 0);
                    }
                    else
                    {
                        //-------------------------- 
                        //Setup font
                        //-------------------------- 
                        Font boldFont = new Font(DefaultCellStyle.Font, FontStyle.Bold);

                        //-------------------------- 
                        //for hierarchy
                        //-------------------------- 
                        bool isChild = false;

                        //-------------------------- 
                        //Init nodes
                        //-------------------------- 
                        TreeGridNode node = new TreeGridNode();
                        TreeGridNode parentNode = new TreeGridNode();

                        //-------------------------- 
                        //Columns Collection
                        //-------------------------- 
                        string[] c = new string[dataSource.Columns.Count];

                        //-------------------------- 
                        //Init RowCounter
                        //-------------------------- 
                        int k = 0;

                        foreach (DataRow dr in dataSource.Rows)
                        {
                            //-------------------------- 
                            // Retrieve columns
                            //-------------------------- 
                            string[] p = new string[dataSource.Columns.Count];

                            for (int i = 0; i < dataSource.Columns.Count; i++)
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
                                if (isOneLevel)
                                {
                                    //-------------------------- 
                                    //set Child values
                                    //-------------------------- 
                                    node = parentNode.Nodes.Add(p);
                                    node.ImageIndex = imageIndexChild;
                                    //-------------------------- 
                                    //set parent values
                                    //-------------------------- 
                                    //set bold
                                    //-------------------------- 
                                    if (fontParentBold) parentNode.DefaultCellStyle.Font = new Font(DefaultCellStyle.Font, FontStyle.Bold);
                                    parentNode.ImageIndex = imageIndexParent;
                                }
                                else
                                {
                                    //-------------------------- 
                                    //set Child values
                                    //-------------------------- 
                                    node = node.Nodes.Add(p);
                                    node.ImageIndex = imageIndexChild;
                                    //-------------------------- 
                                    //set parent values
                                    //-------------------------- 
                                    parentNode.ImageIndex = imageIndexParent;
                                }
                                isChild = false;
                            }
                            else
                            {
                                if (isOneLevel)
                                {
                                    parentNode = new TreeGridNode();
                                    parentNode = GridNode.Add(p);
                                    parentNode.ImageIndex = imageIndexChild;
                                }
                                else
                                {
                                    node = new TreeGridNode();
                                    node = GridNode.Add(p);
                                    node.ImageIndex = imageIndexParent;
                                    //-------------------------- 
                                    //set bold
                                    //-------------------------- 
                                    if (fontParentBold) node.DefaultCellStyle.Font = new Font(DefaultCellStyle.Font, FontStyle.Bold);

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
        /*
        [Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        EditorBrowsable(EditorBrowsableState.Never)]
        public new object DataSource
        {
            get { return null; }
            set { throw new NotSupportedException("The TreeGridView does not support databinding"); }
        }
        */

        [Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        EditorBrowsable(EditorBrowsableState.Never)]
        public new object DataMember
        {
            get { return null; }
            set { throw new NotSupportedException("The TreeGridView does not support databinding"); }
        }

        [Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        EditorBrowsable(EditorBrowsableState.Never)]
        public new DataGridViewRowCollection Rows
        {
            get { return base.Rows; }
        }

        [Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        EditorBrowsable(EditorBrowsableState.Never)]
        public new bool VirtualMode
        {
            get { return false; }
            set { throw new NotSupportedException("The TreeGridView does not support virtual mode"); }
        }

        // none of the rows/nodes created use the row template, so it is hidden.
        [Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        EditorBrowsable(EditorBrowsableState.Never)]
        public new DataGridViewRow RowTemplate
        {
            get { return base.RowTemplate; }
            set { base.RowTemplate = value; }
        }

        #endregion

        #region Public methods
        [Description("Returns the TreeGridNode for the given DataGridViewRow")]
        public TreeGridNode GetNodeForRow(DataGridViewRow row)
        {
            return row as TreeGridNode;
        }

        [Description("Returns the TreeGridNode for the given DataGridViewRow")]
        public TreeGridNode GetNodeForRow(int index)
        {
            return GetNodeForRow(base.Rows[index]);
        }



        /// <summary>
        /// FilterSortData is used to sort a datatable directly.
        /// </summary>
        /// <param name="dtStart">The DataTable to be sorted.</param>
        /// <param name="filter">A way to filter out certain rows from the table.</param>
        /// <param name="sort">A way to sort the table (i.e. "State IN 'CA'")</param>
        /// <returns>A Sorted/Filtered DataTable</returns>
        public static DataTable FilterSortData(DataTable dtStart, string filter, string sort)
        {
            DataTable dt = dtStart.Clone();
            DataRow[] drs = dtStart.Select(filter, sort);
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
        public TreeGridNodeCollection GridNode
        {
            get
            {
                return _root.Nodes;
            }
        }

        public new TreeGridNode CurrentRow
        {
            get
            {
                return base.CurrentRow as TreeGridNode;
            }
        }

        [DefaultValue(false),
        Description("Causes nodes to always show as expandable. Use the NodeExpanding event to add nodes.")]
        [Browsable(true), Category("Appearance-Extended")]
        public bool VirtualNodes
        {
            get { return _virtualNodes; }
            set { _virtualNodes = value; }
        }

        public TreeGridNode CurrentNode
        {
            get
            {
                return CurrentRow;
            }
        }

        [DefaultValue(true)]
        [Browsable(true), Category("Appearance-Extended")]
        public bool ShowLines
        {
            get { return _showLines; }
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
        public ImageList ImageList
        {
            get { return _imageList; }
            set
            {
                _imageList = value;
                //TODO: should we invalidate cell styles when setting the image list?

            }
        }

        [Browsable(true), Category("Appearance-Extended")]
        public new int RowCount
        {
            get { return GridNode.Count; }
            set
            {
                for (int i = 0; i < value; i++)
                    GridNode.Add(new TreeGridNode());

            }
        }
        #endregion

        #region

        private void BuildPortsNodes(bool FirstLoop, string Item_Id, DataTable dt, string IDColumnName, string ParentIDColumnName, int UniqueId)
        {
            int NetItems = 0;



            DataView dv = new DataView(dt);
            if (FirstLoop)
            {
                dv.RowFilter = IDColumnName + "=" + ParentIDColumnName;
                TreeGridNode RootNode = new TreeGridNode();
                UniqueId = RootNode.UniqueValue;
            }
            else
            {
                dv.RowFilter = ParentIDColumnName + "=" + Item_Id + " AND " + IDColumnName + "<>" + Item_Id;
            }

            if (dv.Count > 0)
            {
                try
                {
                    for (NetItems = 0; NetItems <= dv.Count - 1; NetItems++)
                    {

                        //-------------------------- 
                        //Add Node
                        //-------------------------- 

                        // Retrieve columns
                        string[] p = new string[dt.Columns.Count];

                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            p[i] = dv[NetItems][i].ToString().Trim();
                        }

                        //-------------------------- 
                        //Add Node
                        //-------------------------- 
                        TreeGridNode NetItemNode = new TreeGridNode();
                        TreeGridNode RootNode = GridNode.GetNodeByUniqueValue(UniqueId);

                        if (RootNode.UniqueValue == -10)
                        {
                            //empty node
                            RootNode = new TreeGridNode();
                        }

                        NetItemNode = RootNode.Nodes.Add(p);

                        UniqueId = NetItemNode.UniqueValue;

                        BuildPortsNodes(false, dv[NetItems][IDColumnName].ToString(), dt, IDColumnName, ParentIDColumnName, UniqueId);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to add item " + NetItems + " : " + ex.Message, " ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BuildPortsNodesInitialLoop(string Item_Id, DataTable dt, string IDColumnName, string ParentIDColumnName, int UniqueId)
        {
            int Items = 0;

            DataView dv = new DataView(dt);
            dv.RowFilter = IDColumnName + "=" + ParentIDColumnName;


            TreeGridNode RootNode = new TreeGridNode();


            if (dv.Count > 0)
            {

                for (Items = 0; Items <= dv.Count - 1; Items++)
                {
                    //-------------------------- 
                    // Retrieve columns
                    //-------------------------- 
                    string[] p = new string[dt.Columns.Count];

                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        p[i] = dv[Items][i].ToString().Trim();
                    }

                    //-------------------------- 
                    //Add Node
                    //-------------------------- 
                    RootNode = GridNode.Add(p);

                    string Item_id = dv[Items][IDColumnName].ToString();
                    BuildPortsNodesOtherLoops(Item_id, dt, IDColumnName, ParentIDColumnName, ref RootNode);
                }
            }
        }

        private void BuildPortsNodesOtherLoops(string Item_Id, DataTable dt, string IDColumnName, string ParentIDColumnName, ref TreeGridNode parentNode)
        {
            int Items = 0;

            //-------------------------- 
            //create filtered data
            //-------------------------- 
            DataView dv = new DataView(dt);
            dv.RowFilter = ParentIDColumnName + "=" + Item_Id + " AND " + IDColumnName + "<>" + ParentIDColumnName;

            //-------------------------- 
            //get the parent node based on unique value
            //-------------------------- 
            TreeGridNode node = parentNode;

            if (dv.Count > 0)
            {
                //-------------------------- 
                //set Image Index
                //-------------------------- 
                node.ImageIndex = imageIndexParent;

                //-------------------------- 
                //set bold
                //-------------------------- 
                if (fontParentBold) node.DefaultCellStyle.Font = new Font(DefaultCellStyle.Font, FontStyle.Bold);

                for (Items = 0; Items <= dv.Count - 1; Items++)
                {
                    //-------------------------- 
                    // Retrieve columns
                    //-------------------------- 
                    string[] p = new string[dt.Columns.Count];

                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        p[i] = dv[Items][i].ToString().Trim();
                    }
                    //-------------------------- 
                    //Add Node
                    //-------------------------- 
                    TreeGridNode childNode = new TreeGridNode();
                    childNode = node.Nodes.Add(p);

                    string Item = dv[Items][IDColumnName].ToString();

                    BuildPortsNodesOtherLoops(Item, dt, IDColumnName, ParentIDColumnName, ref childNode);
                }

            }
            else
            {
                //set Image Index
                node.ImageIndex = imageIndexChild;
            }
        }
        #endregion

        #region Site nodes and collapse/expand support
        protected override void OnRowsAdded(DataGridViewRowsAddedEventArgs e)
        {
            base.OnRowsAdded(e);
            // Notify the row when it is added to the base grid 
            int count = e.RowCount - 1;
            TreeGridNode row;
            while (count >= 0)
            {
                row = base.Rows[e.RowIndex + count] as TreeGridNode;
                if (row != null)
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

        protected internal virtual void UnSiteNode(TreeGridNode node)
        {
            if (node.IsSited || node.IsRoot)
            {
                // remove child rows first
                foreach (TreeGridNode childNode in node.Nodes)
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
                    catch { }
                }
            }
        }

        protected internal virtual bool CollapseNode(TreeGridNode node)
        {
            if (node.IsExpanded)
            {
                CollapsingEventArgs exp = new CollapsingEventArgs(node);
                OnNodeCollapsing(exp);

                if (!exp.Cancel)
                {
                    LockVerticalScrollBarUpdate(true);
                    SuspendLayout();
                    _inExpandCollapse = true;
                    node.IsExpanded = false;

                    foreach (TreeGridNode childNode in node.Nodes)
                    {
                        Debug.Assert(childNode.RowIndex != -1, "Row is NOT in the grid.");
                        UnSiteNode(childNode);
                    }

                    CollapsedEventArgs exped = new CollapsedEventArgs(node);
                    OnNodeCollapsed(exped);
                    //TODO: Convert this to a specific NodeCell property
                    _inExpandCollapse = false;
                    LockVerticalScrollBarUpdate(false);
                    ResumeLayout(true);
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

        protected internal virtual void SiteNode(TreeGridNode node)
        {
            //TODO: Raise exception if parent node is not the root or is not sited.
            int rowIndex = -1;
            TreeGridNode currentRow;
            node._grid = this;

            if (node.Parent != null && node.Parent.IsRoot == false)
            {
                // row is a child
                Debug.Assert(node.Parent != null && node.Parent.IsExpanded == true);

                if (node.Index > 0)
                {
                    currentRow = node.Parent.Nodes[node.Index - 1];
                }
                else
                {
                    currentRow = node.Parent;
                }
            }
            else
            {
                // row is being added to the root
                if (node.Index > 0)
                {
                    currentRow = node.Parent.Nodes[node.Index - 1];
                }
                else
                {
                    currentRow = null;
                }

            }

            if (currentRow != null)
            {
                while (currentRow.Level >= node.Level)
                {
                    if (currentRow.RowIndex < base.Rows.Count - 1)
                    {
                        currentRow = base.Rows[currentRow.RowIndex + 1] as TreeGridNode;
                        Debug.Assert(currentRow != null);
                    }
                    else
                        // no more rows, site this node at the end.
                        break;

                }
                if (currentRow == node.Parent)
                    rowIndex = currentRow.RowIndex + 1;
                else if (currentRow.Level < node.Level)
                    rowIndex = currentRow.RowIndex;
                else
                    rowIndex = currentRow.RowIndex + 1;
            }
            else
                rowIndex = 0;


            Debug.Assert(rowIndex != -1);
            SiteNode(node, rowIndex);

            Debug.Assert(node.IsSited);
            if (node.IsExpanded)
            {
                // add all child rows to display
                foreach (TreeGridNode childNode in node.Nodes)
                {
                    //TODO: could use the more efficient SiteRow with index.
                    SiteNode(childNode);
                }
            }
        }


        protected internal virtual void SiteNode(TreeGridNode node, int index)
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

        protected internal virtual bool ExpandNode(TreeGridNode node)
        {
            if (!node.IsExpanded || _virtualNodes)
            {
                ExpandingEventArgs exp = new ExpandingEventArgs(node);
                OnNodeExpanding(exp);

                if (!exp.Cancel)
                {
                    LockVerticalScrollBarUpdate(true);
                    SuspendLayout();
                    _inExpandCollapse = true;
                    node.IsExpanded = true;

                    //TODO Convert this to a InsertRange
                    foreach (TreeGridNode childNode in node.Nodes)
                    {
                        Debug.Assert(childNode.RowIndex == -1, "Row is already in the grid.");

                        SiteNode(childNode);
                        //BaseRows.Insert(rowIndex + 1, childRow);
                        //TODO : remove -- just a test.
                        //childNode.Cells[0].Value = "child";
                    }

                    ExpandedEventArgs exped = new ExpandedEventArgs(node);
                    OnNodeExpanded(exped);
                    //TODO: Convert this to a specific NodeCell property
                    _inExpandCollapse = false;
                    LockVerticalScrollBarUpdate(false);
                    ResumeLayout(true);
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
            _inExpandCollapseMouseCapture = false;
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            // while we are expanding and collapsing a node mouse moves are
            // supressed to keep selections from being messed up.
            if (!_inExpandCollapseMouseCapture)
                base.OnMouseMove(e);

        }
        [Description("Expands all nodes")]
        public void ExpandAll()
        {
            foreach (TreeGridNode node in GridNode)
            {
                expandNode(node);
            }
        }

        private void expandNode(TreeGridNode node)
        {

            if (node.Nodes.Count > 0)
            {
                node.Expand();
                foreach (TreeGridNode subNode in node.Nodes)
                {
                    expandNode(subNode);
                }
            }
        }

        [Description("Collapse all nodes")]
        public void CollapseAll()
        {
            foreach (TreeGridNode node in GridNode)
            {
                collapseNode(node);
            }
        }

        private void collapseNode(TreeGridNode node)
        {
            if (node.Nodes.Count > 0)
            {
                foreach (TreeGridNode subNode in node.Nodes)
                {
                    collapseNode(subNode);
                }
                node.Collapse();
            }
        }
        #endregion

        #region Collapse/Expand events
        public event ExpandingEventHandler NodeExpanding;
        public event ExpandedEventHandler NodeExpanded;
        public event CollapsingEventHandler NodeCollapsing;
        public event CollapsedEventHandler NodeCollapsed;

        protected virtual void OnNodeExpanding(ExpandingEventArgs e)
        {
            if (NodeExpanding != null)
            {
                NodeExpanding(this, e);
            }
        }
        protected virtual void OnNodeExpanded(ExpandedEventArgs e)
        {
            if (NodeExpanded != null)
            {
                NodeExpanded(this, e);
            }
        }
        protected virtual void OnNodeCollapsing(CollapsingEventArgs e)
        {
            if (NodeCollapsing != null)
            {
                NodeCollapsing(this, e);
            }

        }
        protected virtual void OnNodeCollapsed(CollapsedEventArgs e)
        {
            if (NodeCollapsed != null)
            {
                NodeCollapsed(this, e);
            }
        }
        #endregion

        #region Helper methods

        //private bool _disposing = false;

        protected override void Dispose(bool disposing)
        {
            //_disposing = true;
            base.Dispose(Disposing);
            UnSiteAll();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            // this control is used to temporarly hide the vertical scroll bar
            hideScrollBarControl = new Control();
            hideScrollBarControl.Visible = false;
            hideScrollBarControl.Enabled = false;
            hideScrollBarControl.TabStop = false;
            // control is disposed automatically when the grid is disposed
            Controls.Add(hideScrollBarControl);
        }

        protected override void OnRowEnter(DataGridViewCellEventArgs e)
        {
            // ensure full row select
            base.OnRowEnter(e);
            if (SelectionMode == DataGridViewSelectionMode.CellSelect ||
                (SelectionMode == DataGridViewSelectionMode.FullRowSelect &&
                base.Rows[e.RowIndex].Selected == false))
            {
                SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                base.Rows[e.RowIndex].Selected = true;
            }
        }

        private void LockVerticalScrollBarUpdate(bool lockUpdate/*, bool delayed*/)
        {
            // Temporarly hide/show the vertical scroll bar by changing its parent
            if (!_inExpandCollapse)
            {
                if (lockUpdate)
                {
                    VerticalScrollBar.Parent = hideScrollBarControl;
                }
                else
                {
                    VerticalScrollBar.Parent = this;
                }
            }
        }

        protected override void OnColumnAdded(DataGridViewColumnEventArgs e)
        {
            if (typeof(TreeGridColumn).IsAssignableFrom(e.Column.GetType()))
            {
                if (_expandableColumn == null)
                {
                    // identify the expanding column.			
                    _expandableColumn = (TreeGridColumn)e.Column;
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

        private static class Win32Helper
        {
            public const int WM_SYSKEYDOWN = 0x0104,
                             WM_KEYDOWN = 0x0100,
                             WM_SETREDRAW = 0x000B;

            [System.Runtime.InteropServices.DllImport("USER32.DLL", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            public static extern IntPtr SendMessage(System.Runtime.InteropServices.HandleRef hWnd, int msg, IntPtr wParam, IntPtr lParam);

            [System.Runtime.InteropServices.DllImport("USER32.DLL", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            public static extern IntPtr SendMessage(System.Runtime.InteropServices.HandleRef hWnd, int msg, int wParam, int lParam);

            [System.Runtime.InteropServices.DllImport("USER32.DLL", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
            public static extern bool PostMessage(System.Runtime.InteropServices.HandleRef hwnd, int msg, IntPtr wparam, IntPtr lparam);

        }
        #endregion
    }
}