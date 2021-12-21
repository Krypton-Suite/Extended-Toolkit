#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.VirtualTreeColumnView
{
    /// <summary>
    /// What is stored where, in the virtual tree
    /// </summary>
    public class VirtualTreeRowNode
    {
        #region Instance Fields
        private Color _firstCellForeColor = Color.Empty;
        private Font _firstCellFont;
        private bool _isCheckBoxVisible = true;
        #endregion

        #region Events
        /// <summary>
        /// Occurs when a property has changed value.
        /// </summary>
        [Category("Property Changed")]
        [Description("Occurs when the value of property has changed.")]
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Identity

        /// <summary>
        /// Initializes a new instance of the System.Windows.Forms.TreeNode class with the specified label text.
        /// </summary>
        /// <param name="tag"></param>
        public VirtualTreeRowNode(object tag)
        {
            Tag = tag;
        }


        /// <summary>
        /// Initializes a new instance of the System.Windows.Forms.TreeNode class with the specified label text and child tree nodes.
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="children">An array of child System.Windows.Forms.TreeNode objects.</param>
        public VirtualTreeRowNode(object tag, IReadOnlyList<VirtualTreeRowNode> children)
            : this(tag)
        {
            Children.AddRange(children);
        }

        /// <summary>
        /// Initializes a new instance of the System.Windows.Forms.TreeNode class with the specified label text and images to display when the tree node is in a selected and unselected state.
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="imageIndex">The index value of System.Drawing.Image to display when the tree node is unselected.</param>
        /// <param name="selectedImageIndex">The index value of System.Drawing.Image to display when the tree node is selected.</param>
        public VirtualTreeRowNode(object tag, int imageIndex, int selectedImageIndex)
            : this(tag)
        {
            ImageIndex = imageIndex;
            SelectedImageIndex = selectedImageIndex;
        }

        /// <summary>
        /// Initializes a new instance of the System.Windows.Forms.TreeNode class with the specified label text, child tree nodes, and images to display when the tree node is in a selected and unselected state.
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="imageIndex">The index value of System.Drawing.Image to display when the tree node is unselected.</param>
        /// <param name="selectedImageIndex">The index value of System.Drawing.Image to display when the tree node is selected.</param>
        /// <param name="children">An array of child System.Windows.Forms.TreeNode objects.</param>
        public VirtualTreeRowNode(object tag, int imageIndex, int selectedImageIndex, IReadOnlyList<VirtualTreeRowNode> children)
        : this(tag, imageIndex, selectedImageIndex)
        {
            Children.AddRange(children);
        }
        #endregion

        public int ImageIndex { get; set; } = -1;

        public int SelectedImageIndex { get; set; } = -1;

        /// <summary>
        /// User data stored at this Node
        /// </summary>
        public object Tag { get; set; }

        /// <summary>
        /// Branch level from Root = 0
        /// </summary>
        public int Level { get; internal set; }

        /// <summary>
        /// Optional Parent
        /// Maybe root therefore null
        /// </summary>
        public VirtualTreeRowNode Parent { get; internal set; }

        /// <summary>
        /// Optional Sibling at this level, before this one
        /// Maybe root therefore null
        /// </summary>
        public VirtualTreeRowNode PreviousSibling { get; internal set; }

        /// <summary>
        /// Optional Sibling at this level, after this one
        /// Maybe last therefore null
        /// </summary>
        public VirtualTreeRowNode NextSibling { get; internal set; }

        public List<VirtualTreeRowNode> Children { get; internal set; } = new();

        public RowNodeState RowNodeState { get; internal set; }

        public Color BackColor { get; set; } = Color.Empty;

        #region FirstCellForeColor
        /// <summary>
        /// Gets or sets the foreground color of the first column text.
        /// </summary>
        /// <remarks>
        /// OnGetRowNodeCellText will be called before this usage to allow the cell colour to be updated
        /// </remarks>
        [Category("Appearance")]
        [Description("Foreground color of the first cell text")]
        public Color FirstCellForeColor
        {
            get => _firstCellForeColor;

            set
            {
                if (_firstCellForeColor != value)
                {
                    _firstCellForeColor = value;
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(_firstCellForeColor)));
                }
            }
        }

        private bool ShouldSerializeFirstCellForeColor() => _firstCellForeColor != Color.Empty;

        #endregion FirstCellForeColor

        #region FirstCellFont
        /// <summary>
        /// Gets or sets the font of the first column text.
        /// </summary>
        /// <remarks>
        /// OnGetRowNodeCellText will be called before this usage to allow the cell colour to be updated
        /// </remarks>
        [Category("Appearance")]
        [Description("Font of the first cell text")]
        public Font FirstCellFont
        {
            get => _firstCellFont;

            set
            {
                if (_firstCellFont != value)
                {
                    _firstCellFont = value;
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(_firstCellFont)));
                }
            }
        }

        private bool ShouldSerializeFirstCellFont() => _firstCellFont != null;

        #endregion FirstCellFont

        #region IsCheckBoxVisible
        /// <summary>
        /// Gets and sets the long text.
        /// </summary>
        [Category("Appearance")]
        [Description("Is the CheckBox Visible on this node when the TreeView has Checkboxes")]
        [DefaultValue(true)]
        public bool IsCheckBoxVisible
        {
            get => _isCheckBoxVisible;

            set
            {
                if (_isCheckBoxVisible != value)
                {
                    _isCheckBoxVisible = value;
                    OnPropertyChanged(new PropertyChangedEventArgs(nameof(IsCheckBoxVisible)));
                    //Rectangle callOnce = Bounds;
                    //if (callOnce != Rectangle.Empty)
                    //{
                    //    // Have to do this as RowBounds is not accessible ! and the check box is on the left, normally !
                    //    Rectangle nodeWidth = Rectangle.FromLTRB(0, callOnce.Top, callOnce.Right + callOnce.Left,
                    //        callOnce.Bottom);
                    //    TreeView.Invalidate(nodeWidth);
                    //    TreeView.Update();
                    //}
                }
            }
        }

        private bool ShouldSerializeIsCheckBoxVisible() => !_isCheckBoxVisible;
        #endregion IsCheckBoxVisible

        #region Protected
        /// <summary>
        /// Raises the PropertyChanged event.
        /// </summary>
        /// <param name="e">A PropertyChangedEventArgs containing the event data.</param>
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        #endregion

        public void Expand()
        {
            RowNodeState |= RowNodeState.Expanded;
        }
    }
}
