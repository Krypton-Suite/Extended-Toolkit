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
using System.Drawing.Design;
using System.Windows.Forms;

// ReSharper disable UnusedMember.Global

namespace Krypton.Toolkit.Suite.Extended.VirtualTreeColumnView
{
    /// <summary>
    /// Provide a Virtual TreeView with Columns with Krypton styling applied.
    /// </summary>
    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(KryptonTreeView), "ToolboxBitmaps.KryptonTreeView.bmp")]
    [Designer("Krypton.Toolkit.KryptonTreeViewDesigner, Krypton.Toolkit")]
    [DesignerCategory("code")]
    [Description("Displays a hierarchical collection of labeled items, each represented by a VirtualTreeNode")]
    public class KryptonVirtualTreeColumnView : VisualSimpleBase
    {
        #region Instance Fields

        internal readonly PaletteRedirectTreeView _redirectImages;
        private readonly PaletteDoubleRedirect _background;

        private bool _mouseOver;
        private bool _forcedLayout;
        private bool _trackingMouseEnter;

        internal readonly ViewDrawDocker _drawDockerOuter;
        private readonly ViewLayoutFill _layoutFill;    // ViewLayoutScrollViewport
        internal readonly ViewDrawButton _drawRow;
        internal readonly ViewDrawCheckBox _drawCheckBox;
        internal readonly ViewLayoutStack _layoutCheckBoxStack;
        internal readonly ViewLayoutDocker _layoutDocker;
        internal readonly ViewLayoutStack _layoutImageStack;
        internal readonly ViewLayoutCenter _layoutImageCenterState;
        internal readonly ViewLayoutSeparator _layoutImage;
        internal readonly ViewLayoutSeparator _layoutImageState;
        private readonly FixedContentValue _rowValues;
        private readonly InternalTreeColumnView _treeView;
        internal readonly ViewDrawScrollBar _vScrollBar;
        internal readonly ViewDrawScrollBar _hScrollBar;
        internal readonly ViewLayoutDocker _drawDockerInner;


        #endregion

        #region Events

        /// <summary>
        /// (VirtualTreeRowNode node, int column), return string cellText
        /// </summary>
        [Category("Code")]
        [Description("Required to convert the Tag data into a column cell text value")]
        public Func<VirtualTreeRowNode, int, string> OnGetRowNodeCellText;

        /// <summary>
        /// (int column)
        /// </summary>
        [Category("Code")]
        [Description("(int column)")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Action<int> OnHeaderClick;

        /// <summary>
        /// (VirtualTreeRowNode, int column)
        /// with row clicked (May be select on or off)
        /// </summary>
        [Category("Code")] 
        [Description("(VirtualTreeRowNode, int column)")] 
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Action<VirtualTreeRowNode, int> OnSelectionChanged;

        /// <summary>
        /// (VirtualTreeRowNode node1, VirtualTreeRowNode node2, int column), return int result
        /// </summary>
        [Category("Code")]
        [Description("")]
        public Func<VirtualTreeRowNode, VirtualTreeRowNode, int, int> OnCompareRowNode;

        /// <summary>
        /// (VirtualTreeRowNode node, int column);
        /// </summary>
        [Category("Code")]
        [Description("")]
        public Action<VirtualTreeRowNode, int> OnRowNodeDoubleClick;

        /// <summary>
        /// (VirtualTreeRowNode node);
        /// </summary>
        [Category("Code")]
        [Description("")]
        public Action<VirtualTreeRowNode> OnRowNodeExpanded;

        /// <summary>
        /// (VirtualTreeRowNode node, int column), return int index;
        /// </summary>
        [Category("Code")]
        [Description("")]
        public Func<VirtualTreeRowNode, int, int> GetImageIndex;

        /// <summary>
        /// (VirtualTreeRowNode node, int column, Graphics g, RectangleF rect), return bool handled;
        /// </summary>
        [Category("Code")]
        [Description("")]
        public Func<VirtualTreeRowNode, int, Graphics, RectangleF, bool> DrawCell;

        /// <summary>
        /// (VirtualTreeRowNode node, int column), return string hintText
        /// </summary>
        [Category("Code")]
        [Description("")]
        public Func<VirtualTreeRowNode, int, string> OnGetRowNodeTooltipText;

        ///// <summary>
        ///// Occurs when the mouse hovers over a node.
        ///// </summary>
        //[Category("Action")]
        //[Description("Occurs when the mouse hovers over a node.")]
        //public event TreeNodeMouseHoverEventHandler NodeMouseHover;

        /// <summary>
        /// Occurs when the value of the BackColor property changes.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler BackColorChanged;

        /// <summary>
        /// Occurs when the value of the BackgroundImage property changes.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler BackgroundImageChanged;

        /// <summary>
        /// Occurs when the value of the BackgroundImageLayout property changes.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler BackgroundImageLayoutChanged;

        /// <summary>
        /// Occurs when the value of the ForeColor property changes.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler ForeColorChanged;

        /// <summary>
        /// Occurs when the value of the MouseClick property changes.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler PaddingChanged;

        /// <summary>
        /// Occurs when the value of the MouseClick property changes.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event PaintEventHandler Paint;

        /// <summary>
        /// Occurs when the value of the TextChanged property changes.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new event EventHandler TextChanged;

        /// <summary>
        /// Occurs when the mouse enters the control.
        /// </summary>
        [Description("Raises the TrackMouseEnter event in the wrapped control.")]
        [Category("Mouse")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public event EventHandler TrackMouseEnter;

        /// <summary>
        /// Occurs when the mouse leaves the control.
        /// </summary>
        [Description("Raises the TrackMouseLeave event in the wrapped control.")]
        [Category("Mouse")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public event EventHandler TrackMouseLeave;
        #endregion

        #region Identity

        /// <summary>
        /// Initialize a new instance of the KryptonVirtualTreeColumnView class.
        /// </summary>
        public KryptonVirtualTreeColumnView()
        {
            // Contains another control and needs marking as such for validation to work
            SetStyle(ControlStyles.ContainerControl, true);
            
            // Cannot select this control, only the child tree view and does not generate a click event
            SetStyle(ControlStyles.Selectable
                     /*| ControlStyles.StandardClick
                     | ControlStyles.StandardDoubleClick*/, false);

            // We need to allow a transparent background
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            // We need to repaint entire control whenever resized
            SetStyle(ControlStyles.ResizeRedraw, true);

            // Yes, we want to be drawn double buffered by default
            base.DoubleBuffered = true;

            // Default fields
            base.Padding = new Padding(1);

            // Create the palette storage
            _redirectImages = new PaletteRedirectTreeView(Redirector, PlusMinusImages, CheckBoxImages);
            StateCommon = new PaletteDataGridViewRedirect(Redirector, NeedPaintDelegate);
            StateDisabled = new PaletteDataGridViewAll(StateCommon, NeedPaintDelegate);
            StateNormal = new PaletteDataGridViewAll(StateCommon, NeedPaintDelegate);
            StateTracking = new PaletteDataGridViewAll(StateCommon, NeedPaintDelegate);
            StatePressed = new PaletteDataGridViewHeaders(StateCommon, NeedPaintDelegate);
            StateSelected = new PaletteDataGridViewCells(StateCommon, NeedPaintDelegate);

            // Create the check box image drawer and place inside element so it is always centered
            _drawCheckBox = new ViewDrawCheckBox(_redirectImages);
            ViewLayoutCenter layoutCheckBox = new()
            {
                _drawCheckBox
            };
            ViewLayoutSeparator layoutCheckBoxAfter = new(3, 0);
            _layoutCheckBoxStack = new ViewLayoutStack(true)
            {
                layoutCheckBox,
                layoutCheckBoxAfter
            };

            // Stack used to layout the location of the node image
            _layoutImage = new ViewLayoutSeparator(0, 0);
            ViewLayoutSeparator layoutImageAfter = new(3, 0);
            ViewLayoutCenter layoutImageCenter = new(_layoutImage);
            _layoutImageStack = new ViewLayoutStack(true)
            {
                layoutImageCenter,
                layoutImageAfter
            };
            _layoutImageState = new ViewLayoutSeparator(16, 16);
            _layoutImageCenterState = new ViewLayoutCenter(_layoutImageState);

            // Create the draw element for owner drawing individual items
            _rowValues = new FixedContentValue();
            _drawRow = new ViewDrawButton(StateDisabled.DataCell, StateNormal.DataCell,
                StateTracking.DataCell, StatePressed.HeaderColumn,
                StateSelected.DataCell,
                StateTracking.DataCell,
                StatePressed.HeaderColumn,
                                 new PaletteMetricRedirect(Redirector),
                                 _rowValues, VisualOrientation.Top, false);

            // Place check box on the left and the label in the remainder
            _layoutDocker = new ViewLayoutDocker
            {
                { _layoutImageStack, ViewDockStyle.Left },
                { _layoutImageCenterState, ViewDockStyle.Left },
                { _layoutCheckBoxStack, ViewDockStyle.Left },
                { _drawRow, ViewDockStyle.Fill }
            };

            _treeView = new InternalTreeColumnView(this);
            _treeView.Click += OnTreeClick;  // SKC: make sure that the default click is also routed.

            // Create the element that fills the remainder space and remembers fill rectangle
            _layoutFill = new ViewLayoutFill(_treeView)
            {
                DisplayPadding = new Padding(1)
            };

            _vScrollBar = new ViewDrawScrollBar(true)
            {
                Visible = false
            };
            _hScrollBar = new ViewDrawScrollBar(false)
            {
                Visible = false
            };
            // Create inner view for placing inside the drawing docker
            _drawDockerInner = new ViewLayoutDocker
            {
                { _layoutFill, ViewDockStyle.Fill },
                { _vScrollBar, ViewDockStyle.Right },
                { _hScrollBar, ViewDockStyle.Bottom }
            };

            // Create view for the control border and background
            _background = new PaletteDoubleRedirect(Redirector, PaletteBackStyle.GridBackgroundList, PaletteBorderStyle.GridDataCellList, NeedPaintDelegate);
            _drawDockerOuter = new ViewDrawDocker(_background.Back, _background.Border)
            {
                { _drawDockerInner, ViewDockStyle.Fill }
            };

            // Create the view manager instance
            ViewManager = new ViewManager(this, _drawDockerOuter);

            // Hook into scroll position changes
            _vScrollBar.ScrollChanged += OnScrollChanged;
            _hScrollBar.ScrollChanged += OnScrollChanged;

        }

        private void OnScrollChanged(object sender, EventArgs e)
        {
            // Request a layout be performed immediately
            PerformNeedPaint(false);
        }

        #endregion Identity


        #region Public

        [Category("Data")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public VirtualTreeHeader Header { get; set; } = new();

        /// <summary>
        /// Gets access to the contained input control.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(false)]
        public InternalTreeColumnView TreeColumnView => _treeView;

        /// <summary>
        /// Gets access to the contained input control.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(false)]
        public Control ContainedControl => TreeColumnView;

        /// <summary>
        /// Gets or sets the text for the control.
        /// </summary>
        [Browsable(false)]
        [Bindable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }

        /// <summary>
        /// Gets or sets the background color for the control.
        /// </summary>
        [Browsable(false)]
        [Bindable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color BackColor
        {
            get => base.BackColor;
            set => base.BackColor = value;
        }

        /// <summary>
        /// Gets or sets the font of the text displayed by the control.
        /// </summary>
        [Browsable(false)]
        [Bindable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Font Font
        {
            get => base.Font;
            set => base.Font = value;
        }

        /// <summary>
        /// Gets or sets the foreground color for the control.
        /// </summary>
        [Browsable(false)]
        [Bindable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ForeColor
        {
            get => base.ForeColor;
            set => base.ForeColor = value;
        }

        /// <summary>
        /// Gets and sets the internal padding space.
        /// </summary>
        [DefaultValue(typeof(Padding), "1,1,1,1")]
        [RefreshProperties(RefreshProperties.Repaint)]
        public new Padding Padding
        {
            get => base.Padding;

            set
            {
                base.Padding = value;
                _layoutFill.DisplayPadding = value;
                PerformNeedPaint(true);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether check boxes are displayed next to the tree nodes in the tree view control.
        /// </summary>
        [Category("Appearance")]
        [Description("Indicates whether check boxes are displayed next to nodes")]
        [DefaultValue(false)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public bool CheckBoxes
        {
            get => _treeView.CheckBoxes;
            set => _treeView.CheckBoxes = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether MultiSelect is allowed.
        /// </summary>
        [Category("Behavior")]
        [Description("Indicates whether MultiSelect is allowed")]
        [DefaultValue(false)]
        public bool MultiSelect
        {
            get => _treeView.MultiSelect;
            set => _treeView.MultiSelect = value;
        }


        /// <summary>
        /// Gets or sets a value indicating whether the selected tree node remains highlighted even when the tree view has lost the focus.
        /// </summary>
        [Category("Behavior")]
        [Description("Removes highlight from the control when it no longer has focus.")]
        [DefaultValue(false)]
        public bool HideSelection
        {
            get => _treeView.HideSelection;
            set => _treeView.HideSelection = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether a tree node label takes on the appearance of a hyperlink as the mouse pointer passes over it.
        /// </summary>
        [Category("Behavior")]
        [Description("Indicates if the node gives feedback as the mouse moves over them.")]
        [DefaultValue(false)]
        public bool HotTracking
        {
            get => _treeView.HotTracking;
            set => _treeView.HotTracking = value;
        }

        /// <summary>
        /// Gets or sets the image-list index value of the default image that is displayed by the tree nodes.
        /// </summary>
        [Category("Behavior")]
        [Description("The default image index for nodes.")]
        [Localizable(true)]
        [TypeConverter("Krypton.Toolkit.NoneExcludedImageIndexConverter, Krypton.Toolkit")]
        [Editor("System.Windows.Forms.Design.ImageIndexEditor", typeof(UITypeEditor))]
        [RefreshProperties(RefreshProperties.Repaint)]
        [RelatedImageList("ImageList")]
        [DefaultValue(-1)]
        public int ImageIndex
        {
            get => _treeView.ImageIndex;
            set => _treeView.ImageIndex = value;
        }

        /// <summary>
        /// Gets or sets the key of the default image for each node in the TreeView control when it is in an unselected state.
        /// </summary>
        [Category("Behavior")]
        [Description("The default image key for the nodes.")]
        [Localizable(true)]
        [TypeConverter(typeof(ImageKeyConverter))]
        [Editor("System.Windows.Forms.Design.ImageIndexEditor", typeof(UITypeEditor))]
        [RefreshProperties(RefreshProperties.Repaint)]
        [RelatedImageList("ImageList")]
        [DefaultValue("")]
        public string ImageKey
        {
            get => _treeView.ImageKey;
            set => _treeView.ImageKey = value;
        }

        /// <summary>
        /// Gets or sets the ImageList that contains the Image objects that are used by the tree nodes.
        /// </summary>
        [Category("Behavior")]
        [Description("The ImageList control from which nodes images are taken.")]
        [RefreshProperties(RefreshProperties.Repaint)]
        [DefaultValue(null)]
        public ImageList ImageList
        {
            get => _treeView.ImageList;
            set
            {
                _treeView.ImageList = value;
                if (value != null)
                {
                    _layoutImageStack.Visible = true;
                    _layoutImage.SeparatorSize = ImageList.ImageSize;
                }
                else
                {
                    _layoutImageStack.Visible = false;
                }
            }
        }

        /// <summary>
        /// Gets or sets the image list index value of the image that is displayed when a tree node is selected.
        /// </summary>
        [Category("Behavior")]
        [Description("The default image index for selected nodes.")]
        [Localizable(true)]
        [TypeConverter("Krypton.Toolkit.NoneExcludedImageIndexConverter, Krypton.Toolkit")]
        [Editor("System.Windows.Forms.Design.ImageIndexEditor", typeof(UITypeEditor))]
        [RelatedImageList("ImageList")]
        [DefaultValue(-1)]
        public int SelectedImageIndex
        {
            get => _treeView.SelectedImageIndex;
            set => _treeView.SelectedImageIndex = value;
        }

        /// <summary>
        /// Gets or sets the key of the default image shown when a VirtualTreeRowNode is in a selected state.
        /// </summary>
        [Category("Behavior")]
        [Description("The default image for selected nodes.")]
        [Localizable(true)]
        [TypeConverter(typeof(ImageKeyConverter))]
        [Editor("System.Windows.Forms.Design.ImageIndexEditor", typeof(UITypeEditor))]
        [RelatedImageList("ImageList")]
        [RefreshProperties(RefreshProperties.Repaint)]
        [DefaultValue("")]
        public string SelectedImageKey
        {
            get => _treeView.SelectedImageKey;
            set => _treeView.SelectedImageKey = value;
        }

        /// <summary>
        /// Gets or sets the tree node that is currently selected in the tree view control.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public VirtualTreeRowNode SelectedNode
        {
            get => _treeView.SelectedNode;
            set => _treeView.SelectedNode = value;
        }

        /// <summary>
        /// Gets the tree nodes that are currently selected in the tree view control.
        /// </summary>
        public IReadOnlyList<VirtualTreeRowNode> SelectedNodes => _treeView.SelectedNodes;

        /// <summary>
        /// Gets or sets a value indicating whether lines are drawn between tree nodes in the tree view control.
        /// </summary>
        [Category("Appearance")]
        [Description("Indicates whether lines are drawn between sibling and parent/child nodes.")]
        [DefaultValue(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public bool ShowLines
        {
            get => _treeView.ShowLines;
            set => _treeView.ShowLines = value;
        }

        /// <summary>
        /// Gets or sets a value indicating ToolTips are shown when the mouse pointer hovers over a VirtualTreeRowNode.
        /// </summary>
        [Category("Behavior")]
        [Description("Indicates whether ToolTips are displayed for the nodes.")]
        [DefaultValue(false)]
        public bool ShowNodeToolTips
        {
            get => _treeView.ShowNodeToolTips;
            set => _treeView.ShowNodeToolTips = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether plus-sign (+) and minus-sign (-) buttons are displayed next to tree nodes that contain child tree nodes.
        /// </summary>
        [Category("Behavior")]
        [Description("Indicates whether plus/minus nodes are drawn next to parent nodes.")]
        [DefaultValue(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public bool ShowPlusMinus
        {
            get => _treeView.ShowPlusMinus;
            set => _treeView.ShowPlusMinus = value;
        }

        /// <summary>
        /// Gets or sets a value indicating whether lines are drawn between the tree nodes that are at the root of the tree view.
        /// </summary>
        [Category("Behavior")]
        [Description("Indicates whether lines are shown between root nodes.")]
        [DefaultValue(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public bool ShowRootLines
        {
            get => _treeView.ShowRootLines;
            set => _treeView.ShowRootLines = value;
        }

        /// <summary>
        /// Gets or sets the image list that is used to indicate the state of the TreeView and its nodes.
        /// </summary>
        [Category("Behavior")]
        [Description("The ImageList used by the control for custom states.")]
        [DefaultValue(null)]
        public ImageList StateImageList
        {
            get => _treeView.StateImageList;
            set => _treeView.StateImageList = value;
        }

        /// <summary>
        /// Gets or sets the first fully-visible tree node in the tree view control.
        /// </summary>
        [Category("Appearance")]
        [Description("First fully-visible node.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public VirtualTreeRowNode VisibleRowNode
        {
            get => _treeView.VisibleRowNode;
            set => _treeView.VisibleRowNode = value;
        }

        /// <summary>
        /// Gets or sets the implementation of IComparer to perform a custom sort of the TreeView nodes.
        /// </summary>
        [Category("Behavior")]
        [Description("IComparer used to perform custom sorting.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public IComparer<VirtualTreeRowNode> TreeViewNodeSorter
        {
            get => _treeView.TreeViewNodeSorter;
            set => _treeView.TreeViewNodeSorter = value;
        }

        /// <summary>
        /// Gets the number of tree nodes that can be fully visible in the tree view control.
        /// </summary>
        [Category("Behavior")]
        [Description("Returns number of visible nodes in the control.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public int VisibleCount => _treeView.VisibleCount;

        /// <summary>
        /// Gets the collection of tree nodes that are assigned to the tree view control.
        /// </summary>
        [Category("Behavior")]
        [Description("The root nodes in the KryptonTreeView control.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public IReadOnlyList<VirtualTreeRowNode> RootNodes => _treeView.RootNodes;

        /// <summary>
        /// Gets or sets a value indicating whether the items in the KryptonTreeView are sorted.
        /// </summary>
        [Category("Behavior")]
        [Description("Controls whether the list is sorted.")]
        [DefaultValue(false)]
        public bool Sorted
        {
            get => _treeView.Sorted;
            set => _treeView.Sorted = value;
        }

        /// <summary>
        /// Gets and sets the background style.
        /// </summary>
        [Category("Visuals")]
        [Description("Style used to draw the background.")]
        [DefaultValue(PaletteBackStyle.PanelClient)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public PaletteBackStyle BackStyle
        {
            get => StateCommon.BackStyle;

            set
            {
                if (StateCommon.BackStyle != value)
                {
                    StateCommon.BackStyle = value;
                    _treeView.Recreate();
                    PerformNeedPaint(true);
                }
            }
        }

        private bool ShouldSerializeBackStyle() => (BackStyle != PaletteBackStyle.PanelClient);

        private void ResetBackStyle() => BackStyle = PaletteBackStyle.PanelClient;


        /// <summary>
        /// Gets access to the plus/minus image value overrides.
        /// </summary>
        [Category("Visuals")]
        [Description("Plus/minus image value overrides.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TreeViewImages PlusMinusImages { get; } = new();

        private bool ShouldSerializePlusMinusImages() => !PlusMinusImages.IsDefault;

        /// <summary>
        /// Gets access to the check box image value overrides.
        /// </summary>
        [Category("Visuals")]
        [Description("CheckBox image value overrides.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public CheckBoxImages CheckBoxImages { get; } = new();

        private bool ShouldSerializeCheckBoxImages() => !CheckBoxImages.IsDefault;

        /// <summary>
        /// Gets access to the common appearance entries that other states can override.
        /// </summary>
        [Category("Visuals")]
        [Description("Overrides for defining common appearance that other states can override.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PaletteDataGridViewRedirect StateCommon { get; }

        private bool ShouldSerializeStateCommon() => !StateCommon.IsDefault;

        /// <summary>
        /// Gets access to the disabled appearance entries.
        /// </summary>
        [Category("Visuals")]
        [Description("Overrides for defining disabled appearance.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PaletteDataGridViewAll StateDisabled { get; }

        private bool ShouldSerializeStateDisabled() => !StateDisabled.IsDefault;

        /// <summary>
        /// Gets access to the normal appearance entries.
        /// </summary>
        [Category("Visuals")]
        [Description("Overrides for defining normal appearance.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PaletteDataGridViewAll StateNormal { get; }

        private bool ShouldSerializeStateNormal() => !StateNormal.IsDefault;

        /// <summary>
        /// Gets access to the hot tracking item appearance entries.
        /// </summary>
        [Category("Visuals")]
        [Description("Overrides for defining hot tracking item appearance.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PaletteDataGridViewAll StateTracking { get; }

        private bool ShouldSerializeStateTracking() => !StateTracking.IsDefault;

        /// <summary>
        /// Gets access to the pressed item appearance entries.
        /// </summary>
        [Category("Visuals")]
        [Description("Overrides for defining pressed item appearance.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PaletteDataGridViewHeaders StatePressed { get; }

        private bool ShouldSerializeStatePressed() => !StatePressed.IsDefault;

        /// <summary>
        /// Gets access to the selected data grid view appearance entries.
        /// </summary>
        [Category("Visuals")]
        [Description("Overrides for defining selected data grid view appearance.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public PaletteDataGridViewCells StateSelected { get; private set; }

        private bool ShouldSerializeStateSelected() => !StateSelected.IsDefault;


        /// <summary>
        /// Collapses all the tree nodes.
        /// </summary>
        public void CollapseAll()
        {
            _treeView.CollapseAll();
            PerformNeedPaint(true);
        }

        /// <summary>
        /// Expands all the tree nodes.
        /// </summary>
        public void ExpandAll()
        {
            _treeView.ExpandAll();
            PerformNeedPaint(true);
        }

        /// <summary>
        /// Sorts the items in KryptonTreeView control.
        /// </summary>
        public void Sort() => _treeView.Sort();

        /// <summary>
        /// Maintains performance while items are added to the TreeView one at a time by preventing the control from drawing until the EndUpdate method is called.
        /// </summary>
        public void BeginUpdate() => _treeView.BeginUpdate();

        /// <summary>
        /// Resumes painting the TreeView control after painting is suspended by the BeginUpdate method. 
        /// </summary>
        public void EndUpdate() => _treeView.EndUpdate();

        /// <summary>
        /// Retrieves the tree node that is at the specified client coord point.
        /// </summary>
        /// <param name="pt">The Point to evaluate and retrieve the node from. </param>
        /// <returns>The TreeNode at the specified point, in tree view (client) coordinates, or null if there is no node at that location.</returns>
        public VirtualTreeRowNode GetNodeAt(Point pt) => GetNodeAt(pt.X, pt.Y);

        /// <summary>
        /// Retrieves the tree node at the point with the specified client coord coordinates.
        /// </summary>
        /// <param name="x">The X position to evaluate and retrieve the node from.</param>
        /// <param name="y">The Y position to evaluate and retrieve the node from.</param>
        /// <returns>The TreeNode at the specified location, in tree view (client) coordinates, or null if there is no node at that location.</returns>
        public VirtualTreeRowNode GetNodeAt(int x, int y) => _treeView.GetRowNodeAt(x, y);

        /// <summary>
        /// Retrieves the number of tree nodes, optionally including those in all subtrees, assigned to the tree view control.
        /// </summary>
        /// <param name="includeSubTrees">true to count the TreeNode items that the subtrees contain; otherwise, false.</param>
        /// <returns>The number of tree nodes, optionally including those in all subtrees, assigned to the control.</returns>
        public int GetNodeCount(bool includeSubTrees) => _treeView.GetNodeCount(includeSubTrees);

        // <summary>
        // Provides node information, given a point.
        // </summary>
        // <param name="pt">The Point at which to retrieve node information.</param>
        // <returns>A TreeViewHitTestInfo.</returns>
        //public TreeViewHitTestInfo HitTest(Point pt) => _treeView.HitTest(pt);

        // <summary>
        // Provides node information, given x- and y-coordinates.
        // </summary>
        // <param name="x">The x-coordinate at which to retrieve node information.</param>
        // <param name="y">The y-coordinate at which to retrieve node information.</param>
        // <returns>A TreeViewHitTestInfo.</returns>
        //public TreeViewHitTestInfo HitTest(int x, int y) => _treeView.HitTest(x, y);


        /// <summary>
        /// Gets a value indicating if the input control is active.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsActive => /*DesignMode ||*/ ContainsFocus || _mouseOver || _treeView.MouseOver;

        /// <summary>
        /// Sets input focus to the control.
        /// </summary>
        /// <returns>true if the input focus request was successful; otherwise, false.</returns>
        public new bool Focus() => _treeView != null && _treeView.Focus();

        /// <summary>
        /// Activates the control.
        /// </summary>
        public new void Select() => _treeView?.Select();

        /// <summary>
        /// Recovers the back/border/content palettes to use for drawing the provided cell.
        /// </summary>
        /// <param name="state">State of the cell.</param>
        /// <param name="rowIndex">Row index of cell (-1 for row headers).</param>
        /// <param name="paletteBack">IPaletteBack to be used for cell drawing.</param>
        /// <param name="paletteBorder">IPaletteBorder to be used for cell drawing.</param>
        /// <param name="paletteContent">IPaletteContent to be used for cell drawing.</param>
        /// <returns></returns>
        public PaletteState GetCellTriple(RowNodeState state,
                                                  int rowIndex,
                                                  out IPaletteBack paletteBack,
                                                  out IPaletteBorder paletteBorder,
                                                  out IPaletteContent paletteContent)
        {
            PaletteState retState;

            // If control is disabled, then draw cell as disabled
            if (!Enabled)
            {
                retState = PaletteState.Disabled;
            }
            else
            {
                retState = PaletteState.Normal;

                if (state.HasFlag(RowNodeState.Selected))
                {
                    // If the cell is selected, then use the checked state
                    retState = PaletteState.CheckedNormal;
                }
                else if (state.HasFlag(RowNodeState.Pressed))
                {
                    // If the user has pressed down on this header cell
                    retState = PaletteState.Pressed;
                }
                else if (state.HasFlag(RowNodeState.Tracking))
                {
                    // Cell not pressed, but if mouse over the cell anyway
                    retState = PaletteState.Tracking;
                }
            }

            switch (rowIndex)
            {
                // Is this a data cell?
                case >= 0:
                    switch (retState)
                    {
                        default:
                        case PaletteState.Normal:
                            paletteBack = StateNormal.DataCell.Back;
                            paletteBorder = StateNormal.DataCell.Border;
                            paletteContent = StateNormal.DataCell.Content;
                            break;
                        case PaletteState.Disabled:
                            paletteBack = StateDisabled.DataCell.Back;
                            paletteBorder = StateDisabled.DataCell.Border;
                            paletteContent = StateDisabled.DataCell.Content;
                            break;
                        case PaletteState.Tracking:
                            paletteBack = StateTracking.DataCell.Back;
                            paletteBorder = StateTracking.DataCell.Border;
                            paletteContent = StateTracking.DataCell.Content;
                            break;
                        case PaletteState.CheckedNormal:
                            paletteBack = StateSelected.DataCell.Back;
                            paletteBorder = StateSelected.DataCell.Border;
                            paletteContent = StateSelected.DataCell.Content;
                            break;
                    }

                    break;
                case < 0:
                    // Negative row index means it is a header cell
                    switch (retState)
                    {
                        default:
                        case PaletteState.Normal:
                            paletteBack = StateNormal.HeaderColumn.Back;
                            paletteBorder = StateNormal.HeaderColumn.Border;
                            paletteContent = StateNormal.HeaderColumn.Content;
                            break;
                        case PaletteState.Disabled:
                            paletteBack = StateDisabled.HeaderColumn.Back;
                            paletteBorder = StateDisabled.HeaderColumn.Border;
                            paletteContent = StateDisabled.HeaderColumn.Content;
                            break;
                        case PaletteState.Tracking:
                            paletteBack = StateTracking.HeaderColumn.Back;
                            paletteBorder = StateTracking.HeaderColumn.Border;
                            paletteContent = StateTracking.HeaderColumn.Content;
                            break;
                        case PaletteState.Pressed:
                            paletteBack = StatePressed.HeaderColumn.Back;
                            paletteBorder = StatePressed.HeaderColumn.Border;
                            paletteContent = StatePressed.HeaderColumn.Content;
                            break;
                        case PaletteState.CheckedNormal:
                            paletteBack = StateSelected.HeaderColumn.Back;
                            paletteBorder = StateSelected.HeaderColumn.Border;
                            paletteContent = StateSelected.HeaderColumn.Content;
                            break;
                    }

                    break;
            }

            return retState;
        }

        #endregion public

        #region Protected
        /// <summary>
        /// Force the layout logic to size and position the controls.
        /// </summary>
        protected void ForceControlLayout()
        {
            if (!IsHandleCreated)
            {
                _forcedLayout = true;
                OnLayout(new LayoutEventArgs(null, null));
                _forcedLayout = false;
            }
        }
        #endregion Protected

        #region Protected Virtual

        protected override void OnMouseClick(MouseEventArgs e)
        {
            _treeView.InternalTreeColumnView_MouseClick(e);
            base.OnMouseClick(e);
        }

        /// <summary>
        /// Creates a new instance of the control collection for the KryptonTreeView.
        /// </summary>
        /// <returns>A new instance of Control.ControlCollection assigned to the control.</returns>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected override ControlCollection CreateControlsInstance() => new KryptonReadOnlyControls(this);

        /// <summary>
        /// Raises the PaletteChanged event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnPaletteChanged(EventArgs e)
        {
            _treeView.Recreate();
            UpdateItemHeight();
            _treeView.Invalidate();
            base.OnPaletteChanged(e);
        }

        /// <summary>
        /// Processes a notification from palette of a paint and optional layout required.
        /// </summary>
        /// <param name="sender">Source of notification.</param>
        /// <param name="e">An NeedLayoutEventArgs containing event data.</param>
        protected override void OnPaletteNeedPaint(object sender, NeedLayoutEventArgs e)
        {
            UpdateItemHeight();
            base.OnPaletteChanged(e);
        }

        /// <summary>
        /// Raises the EnabledChanged event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnEnabledChanged(EventArgs e)
        {
            // Change in enabled state requires a layout and repaint
            UpdateStateAndPalettes();
            PerformNeedPaint(true);

            // Let base class fire standard event
            base.OnEnabledChanged(e);
        }

        /// <summary>
        /// Raises the CreateControl event.
        /// </summary>
        protected override void OnCreateControl()
        {
            UpdateItemHeight();
            base.OnCreateControl();
        }

        /// <summary>
        /// Raises the BackColorChanged event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnBackColorChanged(EventArgs e) => BackColorChanged?.Invoke(this, e);

        /// <summary>
        /// Raises the BackgroundImageChanged event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnBackgroundImageChanged(EventArgs e) => BackgroundImageChanged?.Invoke(this, e);

        /// <summary>
        /// Raises the BackgroundImageLayoutChanged event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnBackgroundImageLayoutChanged(EventArgs e) => BackgroundImageLayoutChanged?.Invoke(this, e);

        /// <summary>
        /// Raises the ForeColorChanged event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnForeColorChanged(EventArgs e) => ForeColorChanged?.Invoke(this, e);

        /// <summary>
        /// Raises the PaddingChanged event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnPaddingChanged(EventArgs e) => PaddingChanged?.Invoke(this, e);

        /// <summary>
        /// Raises the TabStop event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnTabStopChanged(EventArgs e)
        {
            _treeView.TabStop = TabStop;
            base.OnTabStopChanged(e);
        }

        /// <summary>
        /// Raises the CausesValidationChanged event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnCausesValidationChanged(EventArgs e)
        {
            _treeView.CausesValidation = CausesValidation;
            base.OnCausesValidationChanged(e);
        }

        /// <summary>
        /// Raises the Paint event.
        /// </summary>
        /// <param name="e">An PaintEventArgs that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (IsDisposed || Disposing || ViewManager == null)
                return;

            Paint?.Invoke(this, e);
            base.OnPaint(e);
            _treeView.ReDrawView(e.Graphics);
            if (DesignMode)
            {
                _treeView.DrawDesignMode(e.Graphics);
            }
        }

        /// <summary>
        /// Raises the TextChanged event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnTextChanged(EventArgs e) => TextChanged?.Invoke(this, e);

        /// <summary>
        /// Raises the TrackMouseEnter event.
        /// </summary>
        /// <param name="e">An EventArgs containing the event data.</param>
        protected virtual void OnTrackMouseEnter(EventArgs e) => TrackMouseEnter?.Invoke(this, e);

        /// <summary>
        /// Raises the TrackMouseLeave event.
        /// </summary>
        /// <param name="e">An EventArgs containing the event data.</param>
        protected virtual void OnTrackMouseLeave(EventArgs e) => TrackMouseLeave?.Invoke(this, e);

        /// <summary>
        /// Raises the HandleCreated event.
        /// </summary>
        /// <param name="e">An EventArgs containing the event data.</param>
        protected override void OnHandleCreated(EventArgs e)
        {
            // Let base class do standard stuff
            base.OnHandleCreated(e);

            // Force the font to be set into the text box child control
            PerformNeedPaint(false);

            // We need a layout to occur before any painting
            InvokeLayout();
        }

        /// <summary>
        /// Processes a notification from palette storage of a paint and optional layout required.
        /// </summary>
        /// <param name="sender">Source of notification.</param>
        /// <param name="e">An NeedLayoutEventArgs containing event data.</param>
        protected override void OnNeedPaint(object sender, NeedLayoutEventArgs e)
        {
            if (IsHandleCreated && !e.NeedLayout)
            {
                _treeView.Invalidate();
            }
            else
            {
                ForceControlLayout();
            }

            // Update palette to reflect latest state
            UpdateStateAndPalettes();
            UpdateItemHeight();
            base.OnNeedPaint(sender, e);
        }

        /// <summary>
        /// Raises the Layout event.
        /// </summary>
        /// <param name="levent">An EventArgs that contains the event data.</param>
        protected override void OnLayout(LayoutEventArgs levent)
        {
            if (IsDisposed || Disposing || ViewManager == null)
                return;

            if (IsHandleCreated)
            {
                _hScrollBar.Enabled = Enabled;
                _vScrollBar.Enabled = Enabled;

                // We short size the horizontal scrollbar if both bars are showing
                _hScrollBar.ShortSize = _hScrollBar.Visible && _vScrollBar.Visible;
            }

            base.OnLayout(levent);

            // Only use layout logic if control is fully initialized or if being forced
            // to allow a relayout or if in design mode.
            if (IsHandleCreated || _forcedLayout || (DesignMode && (_treeView != null)))
            {
                Rectangle fillRect = _layoutFill.FillRect;
                _treeView.SetBounds(fillRect.X, fillRect.Y, fillRect.Width, fillRect.Height);
            }
        }

        /// <summary>
        /// Raises the MouseEnter event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnMouseEnter(EventArgs e)
        {
            _mouseOver = true;
            PerformNeedPaint(true);
            _treeView.Invalidate();
            base.OnMouseEnter(e);
        }

        /// <summary>
        /// Raises the MouseLeave event.
        /// </summary>
        /// <param name="e">An EventArgs that contains the event data.</param>
        protected override void OnMouseLeave(EventArgs e)
        {
            _mouseOver = false;
            PerformNeedPaint(true);
            _treeView.Invalidate();
            base.OnMouseLeave(e);
        }

        /// <summary>
        /// Raises the MouseDown event.
        /// </summary>
        /// <param name="e">A MouseEventArgs that contains the event data.</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            _mouseOver = false;

            PerformNeedPaint(true);

            _treeView.Invalidate();

            base.OnMouseDown(e);
        }

        /// <summary>
        /// Gets the default size of the control.
        /// </summary>
        protected override Size DefaultSize => new(120, 96);

        protected override void CreateHandle()
        {
            base.CreateHandle();

            _ = PI.SetWindowTheme(Handle, @"DarkMode_Explorer", null);
        }

        //protected override onh
        #endregion

        #region Implementation
        private void UpdateStateAndPalettes()
        {
            if (!IsDisposed)
            {
                // TODO: Get the correct palette settings to use (i.e. enabled -> disabled)
                _treeView.ViewDrawPanel.SetPalettes(_background.PaletteBack);
                _drawDockerOuter.SetPalettes(_background.PaletteBack, _background.PaletteBorder);
                _drawDockerOuter.Enabled = Enabled;

                // Find the new state of the main view element
                PaletteState state;
                //if (IsActive)
                //{
                //    state = PaletteState.Tracking;
                //}
                //else
                {
                    state = Enabled ? PaletteState.Normal : PaletteState.Disabled;
                }

                _treeView.ViewDrawPanel.ElementState = state;
                _drawDockerOuter.ElementState = state;
            }
        }

        private void UpdateItemHeight()
        {
            if (!IsDisposed && !Disposing)
            {
                UpdateContentFromNode(null);

                // Ask the view element to layout in given space, needs this before a render call
                using ViewLayoutContext context = new(this, Renderer);
                // For calculating the item height we always assume normal state
                _drawRow.ElementState = PaletteState.Normal;

                // Find required size to show a node (only interested in the height)
                Size size = _drawRow.GetPreferredSize(context);
                size.Height += 1;

                // If we have images defined then adjust to reflect image height
                if (ImageList != null)
                {
                    size.Height = Math.Max(size.Height, ImageList.ImageSize.Height);
                }

                // Update the item height to match height of a single node
                _treeView.ItemHeight = size.Height;
            }
        }

        private void UpdateContentFromNode(VirtualTreeRowNode node)
        {
            if (node != null)
            {
                // Get information from the node
                _rowValues.ShortText = node.ToString();
                _rowValues.LongText = string.Empty;
                _rowValues.Image = null;
                _rowValues.ImageTransparentColor = Color.Empty;
            }
            else
            {
                // Get the text string for the item
                _rowValues.ShortText = @"A";
                _rowValues.LongText = @"A";
                _rowValues.Image = null;
                _rowValues.ImageTransparentColor = Color.Empty;
            }
        }

        private void OnTreeViewGotFocus(object sender, EventArgs e)
        {
            _treeView.Invalidate();
            PerformNeedPaint(true);
            OnGotFocus(e);
        }

        private void OnTreeViewLostFocus(object sender, EventArgs e)
        {
            _treeView.Invalidate();
            PerformNeedPaint(true);
            OnLostFocus(e);
        }

        private void OnTreeViewKeyPress(object sender, KeyPressEventArgs e) => OnKeyPress(e);

        private void OnTreeViewKeyUp(object sender, KeyEventArgs e) => OnKeyUp(e);

        private void OnTreeViewKeyDown(object sender, KeyEventArgs e) => OnKeyDown(e);

        private void OnTreeViewPreviewKeyDown(object sender, PreviewKeyDownEventArgs e) => OnPreviewKeyDown(e);

        private void OnTreeViewValidated(object sender, EventArgs e) => OnValidated(e);

        private void OnTreeViewValidating(object sender, CancelEventArgs e) => OnValidating(e);

        private void OnTreeViewMouseChange(object sender, EventArgs e)
        {
            // Change in tracking state?
            if (_treeView.MouseOver != _trackingMouseEnter)
            {
                _trackingMouseEnter = _treeView.MouseOver;

                // Raise appropriate event
                if (_trackingMouseEnter)
                {
                    OnTrackMouseEnter(EventArgs.Empty);
                    OnMouseEnter(e);
                }
                else
                {
                    OnTrackMouseLeave(EventArgs.Empty);
                    OnMouseLeave(e);
                }
            }
        }
        #endregion Implementation


        #region Private

        private void OnTreeClick(object sender, EventArgs e) => OnClick(e);

        #endregion Private

        /// <summary>
        /// Add new node data to the tree
        /// </summary>
        /// <param name="parentNode"></param>
        /// <param name="mode"></param>
        /// <param name="data"></param>
        /// <returns>Row for the data object provided</returns>
        public VirtualTreeRowNode Add(VirtualTreeRowNode parentNode, NodeAttachPlacement mode, object data) => _treeView.Add(parentNode, mode, data);

        public void EnsureRowVisible(VirtualTreeRowNode targetRow) => _treeView.EnsureRowVisible(targetRow);

        /// <summary>
        /// Remove all RootNodes from the view
        /// </summary>
        /// <remarks>
        /// It is upto the caller to perform a refresh / redraw / endUpdate
        /// </remarks>
        public void Clear() => _treeView.Clear();

        public void ClearSelection() => _treeView.ClearSelection();

        public void AddSelected(IReadOnlyList<VirtualTreeRowNode> selectedNodes) => _treeView.AddSelected(selectedNodes);
    }
}
