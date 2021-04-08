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
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Text;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Tree.Grid.View
{
    [ToolboxItem(false), DesignTimeVisible(false)]
    public class TreeGridNode : DataGridViewRow//, IComponent
    {
        internal KryptonTreeGridView _grid;
        internal TreeGridNode _parent;
        internal TreeGridNodeCollection _owner;
        internal bool IsExpanded;
        internal bool IsRoot;
        internal bool _isSited;
        internal bool _isFirstSibling;
        internal bool _isLastSibling;
        internal Image _image;
        internal int _imageIndex;

        private Random rndSeed = new Random();
        private int _uniqueValue = -1;
        private TreeGridCell _treeCell;
        private TreeGridNodeCollection childrenNodes;

        private int _index;
        private int _level;
        private bool childCellsCreated = false;

        // needed for IComponent
        private ISite site = null;
        private EventHandler disposed = null;

        internal TreeGridNode(KryptonTreeGridView owner)
            : this()
        {
            _grid = owner;
            IsExpanded = true;
        }

        public TreeGridNode()
        {
            _index = -1;
            _level = -1;
            IsExpanded = false;
            _uniqueValue = rndSeed.Next();// +DateTime.Now.Second + DateTime.Now.Millisecond;
            _isSited = false;
            _isFirstSibling = false;
            _isLastSibling = false;
            _imageIndex = -1;
        }

        public override object Clone()
        {
            TreeGridNode r = (TreeGridNode)base.Clone();
            r.UniqueValue = rndSeed.Next();// +DateTime.Now.Second + DateTime.Now.Millisecond; 
            r._level = _level;
            r._grid = _grid;
            r._parent = Parent;

            r._imageIndex = _imageIndex;
            if (r._imageIndex == -1)
                r.Image = Image;

            r.IsExpanded = IsExpanded;
            //r.treeCell = new TreeGridCell();

            return r;
        }

        protected internal virtual void UnSited()
        {
            // This row is being removed from being displayed on the grid.
            TreeGridCell cell;
            foreach (DataGridViewCell DGVcell in Cells)
            {
                cell = DGVcell as TreeGridCell;
                if (cell != null)
                {
                    cell.UnSited();
                }
            }
            _isSited = false;
        }

        protected internal virtual void Sited()
        {
            // This row is being added to the grid.
            _isSited = true;
            childCellsCreated = true;
            Debug.Assert(_grid != null);

            TreeGridCell cell;
            foreach (DataGridViewCell DGVcell in Cells)
            {
                cell = DGVcell as TreeGridCell;
                if (cell != null)
                {
                    cell.Sited();// Level = Level;
                }
            }

        }

        // Represents the index of this row in the Grid
        [System.ComponentModel.Description("Represents the index of this row in the Grid. Advanced usage."),
        System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),
         Browsable(false),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int RowIndex
        {
            get
            {
                return base.Index;
            }
        }

        // Represents the index of this row based upon its position in the collection.
        [Browsable(false),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new int Index
        {
            get
            {
                if (_index == -1)
                {
                    // get the index from the collection if unknown
                    _index = _owner.IndexOf(this);
                }

                return _index;
            }
            internal set
            {
                _index = value;
            }
        }

        [Browsable(false),
        EditorBrowsable(EditorBrowsableState.Never),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ImageList ImageList
        {
            get
            {
                if (_grid != null)
                    return _grid.ImageList;
                else
                    return null;
            }
        }

        private bool ShouldSerializeImageIndex()
        {
            return (_imageIndex != -1 && _image == null);
        }

        [Category("Appearance"),
        Description("..."), DefaultValue(-1),
        TypeConverter(typeof(ImageIndexConverter)),
        Editor("System.Windows.Forms.Design.ImageIndexEditor", typeof(UITypeEditor))]
        public int ImageIndex
        {
            get { return _imageIndex; }
            set
            {
                _imageIndex = value;
                if (_imageIndex != -1)
                {
                    // when a imageIndex is provided we do not store the image.
                    _image = null;
                }
                if (_isSited)
                {
                    // when the image changes the cell's style must be updated
                    _treeCell.UpdateStyle();
                    if (Displayed)
                        _grid.InvalidateRow(RowIndex);
                }
            }
        }

        private bool ShouldSerializeImage()
        {
            return (_imageIndex == -1 && _image != null);
        }

        public Image Image
        {
            get
            {
                if (_image == null && _imageIndex != -1)
                {
                    if (ImageList != null && _imageIndex < ImageList.Images.Count)
                    {
                        // get image from image index
                        return ImageList.Images[_imageIndex];
                    }
                    else
                        return null;
                }
                else
                {
                    // image from image property
                    return _image;
                };
            }
            set
            {
                _image = value;
                if (_image != null)
                {
                    // when a image is provided we do not store the imageIndex.
                    _imageIndex = -1;
                }
                if (_isSited)
                {
                    // when the image changes the cell's style must be updated
                    _treeCell.UpdateStyle();
                    if (Displayed)
                        _grid.InvalidateRow(RowIndex);
                }
            }
        }

        protected override DataGridViewCellCollection CreateCellsInstance()
        {
            DataGridViewCellCollection cells = base.CreateCellsInstance();
            cells.CollectionChanged += cells_CollectionChanged;
            return cells;
        }

        private void cells_CollectionChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e)
        {
            // Exit if there already is a tree cell for this row
            if (_treeCell != null) return;

            if (e.Action == System.ComponentModel.CollectionChangeAction.Add || e.Action == System.ComponentModel.CollectionChangeAction.Refresh)
            {
                TreeGridCell treeCell = null;

                if (e.Element == null)
                {
                    foreach (DataGridViewCell cell in base.Cells)
                    {
                        if (cell.GetType().IsAssignableFrom(typeof(TreeGridCell)))
                        {
                            try
                            {
                                treeCell = (TreeGridCell)cell;
                            }
                            catch
                            {
                                //treeCell = (TreeGridCell)cell;
                            }
                            break;
                        }
                    }
                }
                else
                {
                    treeCell = e.Element as TreeGridCell;
                }

                if (treeCell != null)
                    _treeCell = treeCell;
            }
        }

        [Category("Data"),
         Description("The collection of root nodes in the treelist."),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
         Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
        public TreeGridNodeCollection Nodes
        {
            get
            {
                if (childrenNodes == null)
                {
                    childrenNodes = new TreeGridNodeCollection(this);
                }
                return childrenNodes;
            }
            set {; }
        }

        // Create a new Cell property because by default a row is not in the grid and won't
        // have any cells. We have to fabricate the cell collection ourself.
        [Browsable(false),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataGridViewCellCollection Cells
        {
            get
            {
                if (!childCellsCreated && DataGridView == null)
                {
                    if (_grid == null) return null;

                    CreateCells(_grid);
                    childCellsCreated = true;
                }
                return base.Cells;
            }
        }

        [Browsable(false),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Level
        {
            get
            {
                if (_level == -1)
                {
                    // calculate level
                    int walk = 0;
                    TreeGridNode walkRow = Parent;
                    while (walkRow != null)
                    {
                        walk++;
                        walkRow = walkRow.Parent;
                    }
                    _level = walk;
                }
                return _level;
            }
        }

        [Browsable(false),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TreeGridNode Parent
        {
            set
            {
                _parent = value;
            }
            get
            {
                return _parent;
            }
        }

        [Browsable(false),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool HasChildren
        {
            get
            {
                return (childrenNodes != null && Nodes.Count != 0);
            }
        }

        [Browsable(false)]
        public bool IsSited
        {
            get
            {
                return _isSited;
            }
        }
        [Browsable(false)]
        public bool IsFirstSibling
        {
            get
            {
                return (Index == 0);
            }
        }

        [Browsable(false)]
        public bool IsLastSibling
        {
            get
            {
                TreeGridNode parent = Parent;
                if (parent != null && parent.HasChildren)
                {
                    return (Index == parent.Nodes.Count - 1);
                }
                else
                    return true;
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int UniqueValue
        {
            set
            {
                _uniqueValue = value;
            }
            get
            {
                return _uniqueValue;
            }
        }


        public virtual bool Collapse()
        {
            return _grid.CollapseNode(this);
        }

        public virtual bool Expand()
        {
            if (_grid != null)
                return _grid.ExpandNode(this);
            else
            {
                IsExpanded = true;
                return true;
            }
        }

        protected internal virtual bool InsertChildNode(int index, TreeGridNode node)
        {
            node._parent = this;
            node._grid = _grid;

            // ensure that all children of this node has their grid set
            if (_grid != null)
                UpdateChildNodes(node);

            //TODO: do we need to use index parameter?
            if ((_isSited || IsRoot) && IsExpanded)
                _grid.SiteNode(node);
            return true;
        }

        protected internal virtual bool InsertChildNodes(int index, params TreeGridNode[] nodes)
        {
            foreach (TreeGridNode node in nodes)
            {
                InsertChildNode(index, node);
            }
            return true;
        }

        protected internal virtual bool AddChildNode(TreeGridNode node)
        {
            node._parent = this;
            node._grid = _grid;

            // ensure that all children of this node has their grid set
            if (_grid != null)
                UpdateChildNodes(node);

            if ((_isSited || IsRoot) && IsExpanded && !node._isSited)
                _grid.SiteNode(node);

            return true;
        }
        protected internal virtual bool AddChildNodes(params TreeGridNode[] nodes)
        {
            //TODO: Convert the final call into an SiteNodes??
            foreach (TreeGridNode node in nodes)
            {
                AddChildNode(node);
            }
            return true;

        }

        protected internal virtual bool RemoveChildNode(TreeGridNode node)
        {
            if ((IsRoot || _isSited) && IsExpanded)
            {
                //We only unsite out child node if we are sited and expanded.
                _grid.UnSiteNode(node);

            }
            node._grid = null;
            node._parent = null;
            return true;

        }

        protected internal virtual bool ClearNodes()
        {
            if (HasChildren)
            {
                for (int i = Nodes.Count - 1; i >= 0; i--)
                {
                    Nodes.RemoveAt(i);
                }
            }
            return true;
        }

        [
            Browsable(false),
            EditorBrowsable(EditorBrowsableState.Advanced)
        ]
        public event EventHandler Disposed
        {
            add
            {
                disposed += value;
            }
            remove
            {
                disposed -= value;
            }
        }

        [
            Browsable(false),
            DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
        ]
        public ISite Site
        {
            get
            {
                return site;
            }
            set
            {
                site = value;
            }
        }

        public void UpdateChildNodes(TreeGridNode node)
        {
            if (node.HasChildren)
            {
                foreach (TreeGridNode childNode in node.Nodes)
                {
                    childNode._grid = node._grid;
                    UpdateChildNodes(childNode);
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(36);
            sb.Append("TreeGridNode { Index=");
            sb.Append(RowIndex.ToString(System.Globalization.CultureInfo.CurrentCulture));
            sb.Append(" }");
            return sb.ToString();
        }

        //protected override void Dispose(bool disposing) {
        //    if (disposing)
        //    {
        //        lock(this)
        //        {
        //            if (site != null && site.Container != null)
        //            {
        //                site.Container.Remove(this);
        //            }

        //            if (disposed != null)
        //            {
        //                disposed(this, EventArgs.Empty);
        //            }
        //        }
        //    }

        //    base.Dispose(disposing);
        //}
    }

}