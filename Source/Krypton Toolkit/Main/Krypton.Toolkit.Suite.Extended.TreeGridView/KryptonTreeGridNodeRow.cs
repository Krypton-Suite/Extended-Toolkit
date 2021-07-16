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

using Krypton.Toolkit.Suite.Extended.TreeGridView.Components;
// ReSharper disable ValueParameterNotUsed

namespace Krypton.Toolkit.Suite.Extended.TreeGridView
{
    [ToolboxItem(false),
     DesignTimeVisible(false)]
    public class KryptonTreeGridNodeRow : DataGridViewRow//, IComponent
    {
        internal KryptonTreeGridView Grid;
        internal TreeGridNodeCollection Owner;
        internal bool IsExpanded;
        internal bool IsRoot;
        private bool _isSited;
        private Image _image;
        private int _imageIndex;

        private readonly Random _rndSeed = new();
        private KryptonTreeGridCell _treeCell;
        private TreeGridNodeCollection _childrenNodes;

        private int _index;
        private int _level;
        private bool _childCellsCreated;

        internal KryptonTreeGridNodeRow(KryptonTreeGridView owner)
            : this()
        {
            Grid = owner;
            IsExpanded = true;
        }

        public KryptonTreeGridNodeRow()
        {
            _index = -1;
            _level = -1;
            IsExpanded = false;
            UniqueValue = -1;
            UniqueValue = _rndSeed.Next();// +DateTime.Now.Second + DateTime.Now.Millisecond;
            _isSited = false;
            _imageIndex = -1;
        }

        public override object Clone()
        {
            var r = (KryptonTreeGridNodeRow)base.Clone();
            r.UniqueValue = _rndSeed.Next();// +DateTime.Now.Second + DateTime.Now.Millisecond; 
            r._level = _level;
            r.Grid = Grid;
            r.Parent = Parent;

            r._imageIndex = _imageIndex;
            if (r._imageIndex == -1)
            {
                r.Image = Image;
            }

            r.IsExpanded = IsExpanded;
            //r.treeCell = new TreeGridCell();

            return r;
        }

        protected internal virtual void UnSited()
        {
            // This row is being removed from being displayed on the grid.
            KryptonTreeGridCell cell;
            foreach (DataGridViewCell dgVcell in Cells)
            {
                cell = dgVcell as KryptonTreeGridCell;
                cell?.UnSited();
            }
            _isSited = false;
        }

        protected internal virtual void Sited()
        {
            // This row is being added to the grid.
            _isSited = true;
            _childCellsCreated = true;
            Debug.Assert(Grid != null);

            KryptonTreeGridCell cell;
            foreach (DataGridViewCell dgVcell in Cells)
            {
                cell = dgVcell as KryptonTreeGridCell;
                cell?.Sited();// Level = Level;
            }

        }

        // Represents the index of this row in the Grid
        [Description("Represents the index of this row in the Grid. Advanced usage."),
        EditorBrowsable(EditorBrowsableState.Advanced),
         Browsable(false),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int RowIndex => base.Index;

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
                    _index = Owner.IndexOf(this);
                }

                return _index;
            }
            internal set => _index = value;
        }

        [Browsable(false),
        EditorBrowsable(EditorBrowsableState.Never),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ImageList ImageList => Grid?.ImageList;

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
            get => _imageIndex;
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
                    {
                        Grid.InvalidateRow(RowIndex);
                    }
                }
            }
        }

        private bool ShouldSerializeImage() => (_imageIndex == -1 && _image != null);

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
                    //else
                    return null;
                }
                //else
                {
                    // image from image property
                    return _image;
                }
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
                    {
                        Grid.InvalidateRow(RowIndex);
                    }
                }
            }
        }

        protected override DataGridViewCellCollection CreateCellsInstance()
        {
            DataGridViewCellCollection cells = base.CreateCellsInstance();
            cells.CollectionChanged += Cells_CollectionChanged;
            return cells;
        }

        private void Cells_CollectionChanged(object sender, CollectionChangeEventArgs e)
        {
            // Exit if there already is a tree cell for this row
            if (_treeCell != null)
            {
                return;
            }

            if (e.Action is CollectionChangeAction.Add or CollectionChangeAction.Refresh)
            {
                KryptonTreeGridCell treeCell = null;

                if (e.Element == null)
                {
                    foreach (DataGridViewCell cell in base.Cells)
                    {
                        try
                        {
                            if (cell is KryptonTreeGridCell gridCell)
                            {
                                treeCell = gridCell;
                                break;
                            }
                        }
                        catch
                        {
                            //treeCell = (TreeGridCell)cell;
                        }
                    }
                }
                else
                {
                    treeCell = e.Element as KryptonTreeGridCell;
                }

                if (treeCell != null)
                {
                    this._treeCell = treeCell;
                }
            }
        }

        [Category("Data"),
         Description("The collection of root nodes in the treelist."),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
         Editor(typeof(CollectionEditor), typeof(UITypeEditor))]
        public TreeGridNodeCollection Nodes
        {
            get => _childrenNodes ??= new TreeGridNodeCollection(this);
            set { }
        }

        // Create a new Cell property because by default a row is not in the grid and won't
        // have any cells. We have to fabricate the cell collection ourself.
        [Browsable(false),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new DataGridViewCellCollection Cells
        {
            get
            {
                if (!_childCellsCreated && DataGridView == null)
                {
                    if (Grid == null)
                    {
                        return null;
                    }

                    CreateCells(Grid);
                    _childCellsCreated = true;
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
                    var walk = 0;
                    KryptonTreeGridNodeRow walkRow = Parent;
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
        public KryptonTreeGridNodeRow Parent { get; set; }

        [Browsable(false),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool HasChildren => (_childrenNodes != null && Nodes.Count != 0);

        [Browsable(false)]
        public bool IsSited => _isSited;

        [Browsable(false)]
        public bool IsFirstSibling => (Index == 0);

        [Browsable(false)]
        public bool IsLastSibling
        {
            get
            {
                KryptonTreeGridNodeRow parent = Parent;
                return parent is not { HasChildren: true } || Index == parent.Nodes.Count - 1;
            }
        }

        [Browsable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int UniqueValue { set; get; }


        public virtual bool Collapse()
        {
            return Grid.CollapseNode(this);
        }

        public virtual bool Expand()
        {
            if (Grid != null)
            {
                return Grid.ExpandNode(this);
            }
            else
            {
                IsExpanded = true;
                return true;
            }
        }

        protected internal virtual bool InsertChildNode(int index, KryptonTreeGridNodeRow node)
        {
            node.Parent = this;
            node.Grid = Grid;

            // ensure that all children of this node has their grid set
            if (Grid != null)
            {
                UpdateChildNodes(node);

                //TODO: do we need to use index parameter?
                if ((_isSited || IsRoot) && IsExpanded)
                {
                    Grid.SiteNode(node);
                    // Reindexing...
                    for (int i = index; i < Nodes.Count; i++)
                    {
                        Nodes[i].Index = i;
                    }
                }
            }
            return true;
        }

        protected internal virtual bool InsertChildNodes(int index, params KryptonTreeGridNodeRow[] nodes)
        {
            foreach (KryptonTreeGridNodeRow node in nodes)
            {
                InsertChildNode(index, node);
            }
            return true;
        }

        protected internal virtual bool AddChildNode(KryptonTreeGridNodeRow node)
        {
            node.Parent = this;
            node.Grid = Grid;

            // ensure that all children of this node has their grid set
            if (Grid != null)
            {
                UpdateChildNodes(node);

                if ((_isSited || IsRoot) && IsExpanded && !node._isSited)
                {
                    Grid.SiteNode(node);
                }
            }

            return true;
        }
        protected internal virtual bool AddChildNodes(params KryptonTreeGridNodeRow[] nodes)
        {
            //TODO: Convert the final call into an SiteNodes??
            foreach (KryptonTreeGridNodeRow node in nodes)
            {
                AddChildNode(node);
            }
            return true;

        }

        protected internal virtual bool RemoveChildNode(KryptonTreeGridNodeRow node)
        {
            if ((IsRoot || _isSited) && IsExpanded)
            {
                //We only unsite out child node if we are sited and expanded.
                Grid.UnSiteNode(node);

            }
            // Reindexing...
            for (int i = node.Index; i < node.Parent.Nodes.Count; i++)
            {
                Nodes[i].Index = i - 1;
            }

            node.Grid = null;
            node.Parent = null;
            return true;

        }

        internal protected virtual bool ClearNodes()
        {
            if (HasChildren)
            {
                for (var i = Nodes.Count - 1; i >= 0; i--)
                {
                    Nodes.RemoveAt(i);
                }
            }
            return true;
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public event EventHandler Disposed
        {
            add { }
            remove { }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ISite Site { get; set; }

        public void UpdateChildNodes(KryptonTreeGridNodeRow node)
        {
            if (node.HasChildren)
            {
                foreach (KryptonTreeGridNodeRow childNode in node.Nodes)
                {
                    childNode.Grid = node.Grid;
                    UpdateChildNodes(childNode);
                }
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder(36);
            sb.Append(@"TreeGridNode { Index=");
            sb.Append(RowIndex.ToString(System.Globalization.CultureInfo.CurrentCulture));
            sb.Append(@" }");
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