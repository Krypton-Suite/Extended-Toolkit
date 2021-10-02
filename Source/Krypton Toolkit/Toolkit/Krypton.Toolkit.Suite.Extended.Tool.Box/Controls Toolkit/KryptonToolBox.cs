#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace Krypton.Toolkit.Suite.Extended.Tool.Box
{
    /// <summary>A Visual Studio toolbox like control for your application. Adapted from: https://www.codeproject.com/Articles/8658/Another-ToolBox-Control.</summary>
    /// <seealso cref="UserControl" />
    [Description("A Visual Studio toolbox like control for your application."), Serializable]
    public class KryptonToolBox : UserControl
    {
        #region Constants

        private const string Xml_Root_Node = "Krypton.Toolkit.Suite.Extended.Base.ToolBox";
        private const string Xml_Config_Node = "Config";
        private const string Xml_TabHeight_Node = "TabHeight";
        private const string Xml_ItemHeight_Node = "ItemHeight";
        private const string Xml_TabSpacing_Node = "TabSpacing";
        private const string Xml_ItemSpacing_Node = "ItemSpacing";
        private const string Xml_LayoutDelay_Node = "LayoutDelay";
        private const string Xml_ScrollDelay_Node = "ScrollDelay";
        private const string Xml_ScrollWait_Node = "ScrollWaitTime";
        private const string Xml_BgColor_Node = "BackgroundColor";

        private const string Xml_ItemBorderColor_Node = "ItemBorderColor";
        private const string Xml_ItemBgColor_Node = "ItemBackgroundColor";
        private const string Xml_SelItemColor_Node = "ItemSelectedColor";
        private const string Xml_NormItemColor_Node = "ItemNormalColor";
        private const string Xml_HoverItemColor_Node = "ItemHoverColor";

        private const string Xml_SelItemTxtColor_Node = "ItemSelectedTextColor";
        private const string Xml_NormItemTxtColor_Node = "ItemNormalTextColor";
        private const string Xml_HoverItemTxtColor_Node = "ItemHoverTextColor";

        private const string Xml_SelTabTxtColor_Node = "TabSelectedTextColor";
        private const string Xml_NormTabTxtColor_Node = "TabNormalTextColor";
        private const string Xml_HoverTabTxtColor_Node = "TabHoverTextColor";

        private const string Xml_ShowOneItemPerRow_Node = "ShowOnlyOneItemPerRow";
        private const string Xml_SelAllTxtInRename_Node = "SelectAllTextWhileRenaming";
        private const string Xml_AllowDragSwap_Node = "AllowSwappingByDragDrop";
        private const string Xml_UseItemClrInRen_Node = "UseItemColorInRename";

        private const string Xml_LargeItemSize_Node = "LargeItemSize";
        private const string Xml_SmallItemSize_Node = "SmallItemSize";
        private const string Xml_Tab_Node = "Tab";
        private const string Xml_Tabs_Node = "Tabs";
        private const string Xml_TabItem_Node = "TabItem";
        private const string Xml_TabItems_Node = "TabItems";
        private const string Xml_Scrolls_Node = "Scrolls";
        private const string Xml_ImageIdxs_Node = "ImageIndices";
        private const string Xml_Caption_Node = "Caption";
        private const string Xml_ToolTip_Node = "ToolTip";


        private const string Xml_Version_Attr = "version";
        private const string Xml_SmallImgIdx_Attr = "small";
        private const string Xml_LargeImgIdx_Attr = "large";
        private const string Xml_Movable_Attr = "movable";
        private const string Xml_Renamable_Attr = "renamable";
        private const string Xml_Deletable_Attr = "deletable";
        private const string Xml_AllowDrag_Attr = "allow-drag";

        private const string Xml_ViewMode_Attr = "view-mode";
        private const string Xml_OneItemPerRow_Attr = "one-item-per-row";
        private const string Xml_ItemSpacing_Attr = "item-spacing";
        private const string Xml_ItemBgClr_Attr = "item-bg-color";
        private const string Xml_ItemBorderClr_Attr = "item-border-color";
        private const string Xml_ItemNormClr_Attr = "item-normal-color";
        private const string Xml_ItemSelClr_Attr = "item-selected-color";
        private const string Xml_ItemHoverClr_Attr = "item-hover-color";

        private const string Xml_Width_Attr = "width";
        private const string Xml_Height_Attr = "height";
        private const string Xml_Enabled_Attr = "enabled";
        private const string Xml_SelTabIdx_Attr = "selected-tab";
        private const string Xml_SelItemIdx_Attr = "selected-item";

        #endregion //Constants

        #region Interop
        private const int DSTINVERT = 0x00550009;
        private const int WM_CHAR = 0x0102;

        [DllImport("gdi32.dll", SetLastError = true)]
        private static extern bool PatBlt(IntPtr hDC, int x, int y, int width, int height, int rop);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern long SendMessage(IntPtr hwnd, int msg, long wParam, long lParam);

        #endregion //Interop

        #region Static Methods

        public static ImageList CreateImageListFromImage(Image image, Size size, Color transparentColor)
        {
            ImageList imgList = null;
            Rectangle rImage = Rectangle.Empty;
            Rectangle rBmp = Rectangle.Empty;
            Graphics gmp = null;
            Bitmap bmp = null;
            int count = 0;
            int index = 0;

            try
            {
                imgList = new ImageList();

                rImage.Size = size;
                rBmp.Size = size;
                count = image.Width / size.Width;

                imgList.ImageSize = size;

                for (index = 0; index < count; index++)
                {
                    bmp = new Bitmap(size.Width, size.Height);
                    gmp = Graphics.FromImage(bmp);

                    gmp.DrawImage(image, rBmp, rImage, GraphicsUnit.Pixel);
                    gmp.Dispose();

                    imgList.Images.Add(bmp);
                    rImage.Offset(size.Width, 0);
                }

                imgList.TransparentColor = transparentColor;
            }
            catch
            {
                imgList = null;
            }
            return imgList;
        }

        public static void DrawBorders(Graphics g, Rectangle rect, bool bDepressed)
        {
            DrawBorders(g, rect, bDepressed, Color.Empty);
        }

        public static void DrawBorders(Graphics g, Rectangle rect, bool bDepressed, Color bdrColor)
        {
            Pen bdrPen = null;

            if (bdrColor.IsEmpty)
            {
                if (bDepressed)
                {
                    g.DrawLine(SystemPens.ControlDark, rect.Left, rect.Top + 0, rect.Right - 1, rect.Top + 0);
                    g.DrawLine(SystemPens.ControlDark, rect.Left, rect.Top + 0, rect.Left, rect.Bottom - 1);
                    g.DrawLine(SystemPens.ControlLightLight, rect.Right - 1, rect.Top + 0, rect.Right - 1, rect.Bottom - 1);
                    g.DrawLine(SystemPens.ControlLightLight, rect.Left, rect.Bottom - 1, rect.Right - 1, rect.Bottom - 1);
                }
                else
                {
                    g.DrawLine(SystemPens.ControlLightLight, rect.Left, rect.Top + 0, rect.Right - 1, rect.Top + 0);
                    g.DrawLine(SystemPens.ControlLightLight, rect.Left, rect.Top + 0, rect.Left, rect.Bottom - 1);
                    g.DrawLine(SystemPens.ControlDark, rect.Right - 1, rect.Top + 0, rect.Right - 1, rect.Bottom - 1);
                    g.DrawLine(SystemPens.ControlDark, rect.Left, rect.Bottom - 1, rect.Right - 1, rect.Bottom - 1);
                }
            }
            else
            {
                bdrPen = new Pen(bdrColor, 1);
                //rect.Inflate(-1,-1);
                g.DrawRectangle(bdrPen, rect.Left, rect.Top, rect.Width - 1, rect.Height - 1);
                bdrPen.Dispose();
            }
        }

        #endregion //Static Methods

        #region Private Attributes

        private ToolBoxTabCollection _toolBoxTabs = null;

        private int _tabHeight = 18;
        private int _itemHeight = 20;

        private int _origTabHeight = 18;
        private int _origItemHeight = 20;

        private Size _largeItemSize = new Size(64, 64);
        private Size _smallItemSize = new Size(32, 32);
        private Size _origLargeItemSize = new Size(64, 64);
        private Size _origSmallItemSize = new Size(32, 32);

        private int _itemSpacing = 2;
        private int _tabSpacing = 1;
        private int _layoutDelay = 10;
        private int _scrollWait = 500;
        private int _scrollDelay = 60;

        private ToolScrollButton _upScroll = null;
        private ToolScrollButton _dnScroll = null;
        private ToolTip _toolTip = null;
        private ToolBoxTab _selectedTab = null;
        private ToolBoxTab _oldselectedTab = null;
        private ToolBoxItem _patBltItem = null;
        private ToolBoxItem _dragItem = null;
        private ToolBoxItem _dropItem = null;

        private Color _itemBgColour = Color.Empty;
        private Color _itemBorderColour = Color.Empty;         // #0A246A XP
        private Color _selectedItemColour = Color.White;         // #D2D4DA XP
        private Color _itemHoverColour = SystemColors.Control;// #B6BDD2 XP
        private Color _itemNormalColour = SystemColors.Control;

        private Color _tabTxtNormalColour = Color.Empty;
        private Color _tabTxtHoverColour = Color.Empty;
        private Color _tabTxtSelectColour = Color.Empty;

        private Color _itemTxtNormalColour = Color.Empty;
        private Color _itemTxtHoverColor = Color.Empty;
        private Color _itemTxtSelectColour = Color.Empty;
        private Color _defTxtBoxBgColour = Color.Empty;
        private Color _defTxtBoxTxColour = Color.Empty;

        private bool _timerIsForLayout = false;
        private bool _mouseMoveFreezed = false;
        private bool _isLoading = false;
        private bool _onlyOneItemPerRow = false;
        private bool _selAllTextInRename = true;
        private bool _allowDragSwap = true;
        private bool _useItemClrInRename = false;

        private ImageList _smallImageList = null;
        private ImageList _largeImageList = null;

        [NonSerialized]
        private TextBox _textBox = null;

        [NonSerialized]
        private System.Windows.Forms.Timer _timer = null;

        [NonSerialized]
        private ImageAttributes _dImgAttr = null;

        [NonSerialized]
        private LayoutFinished _layoutFinished = null;

        #region Krypton Variables
        private KryptonManager _manager = new KryptonManager();

        private PaletteBackInheritRedirect _paletteBack;

        private PaletteBorderInheritRedirect _paletteBorder;

        private PaletteContentInheritRedirect _paletteContent;

        private IPalette _palette;

        private PaletteRedirect _paletteRedirect;
        #endregion

        #endregion //Private Attributes

        #region Public Attributes

        public event TabSelectionChangedHandler TabSelectionChanged;
        public event ItemSelectionChangedHandler ItemSelectionChanged;
        public event TabMouseEventHandler TabMouseDown;
        public event TabMouseEventHandler TabMouseUp;
        public event ItemMouseEventHandler ItemMouseDown;
        public event ItemMouseEventHandler ItemMouseUp;
        public event ItemKeyEventHandler ItemKeyDown;
        public event ItemKeyPressEventHandler ItemKeyPress;
        public event ItemKeyEventHandler ItemKeyUp;
        public event DragDropFinishedHandler DragDropFinished;
        public event RenameFinishedHandler RenameFinished;
        public event XmlSerializerHandler OnSerializeObject;
        public event XmlSerializerHandler OnDeSerializeObject;
        public event PreDragDropHandler OnBeginDragDrop;

        #endregion //Public Attributes

        #region Construction
        public KryptonToolBox()
        {
            Initialize();
        }
        #endregion //Construction

        #region Initialization

        private void Initialize()
        {
            //ContextMenu theMenu;
            //MenuItem    menuItem;

            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);

            AllowDrop = true;
            _toolBoxTabs = new ToolBoxTabCollection();
            _smallImageList = new ImageList();
            _largeImageList = new ImageList();
            _upScroll = new ToolScrollButton(ToolBoxScrollDirection.UP, _tabHeight, _tabHeight);
            _dnScroll = new ToolScrollButton(ToolBoxScrollDirection.DOWN, _tabHeight, _tabHeight);
            _toolTip = new ToolTip();
            _textBox = new TextBox();


            _defTxtBoxBgColour = _textBox.BackColor;
            _defTxtBoxTxColour = _textBox.ForeColor;
            _textBox.Font = Font;
            _textBox.BorderStyle = BorderStyle.None;
            _textBox.Visible = false;
            //_textBox.Multiline    = true;
            _textBox.WordWrap = false;
            _textBox.ScrollBars = ScrollBars.None;//RichTextBox
            _textBox.KeyDown += new KeyEventHandler(OnTextBox_KeyDown);
            _textBox.LostFocus += new EventHandler(OnTextBox_LostFocus);

            //Prepare richTextbox's context menu.

            /*theMenu         = new ContextMenu();

            menuItem        = new MenuItem("Undo");
            menuItem.Click += new EventHandler(OnTexBoxMenu_Undo);
            theMenu.MenuItems.Add(menuItem);

            menuItem        = new MenuItem("-");
            theMenu.MenuItems.Add(menuItem);

            menuItem        = new MenuItem("Cut");
            menuItem.Click += new EventHandler(OnTexBoxMenu_Cut);
            theMenu.MenuItems.Add(menuItem);

            menuItem        = new MenuItem("Copy");
            menuItem.Click += new EventHandler(OnTexBoxMenu_Copy);
            theMenu.MenuItems.Add(menuItem);

            menuItem        = new MenuItem("Paste");
            menuItem.Click += new EventHandler(OnTexBoxMenu_Paste);
            theMenu.MenuItems.Add(menuItem);

            menuItem        = new MenuItem("Delete");
            menuItem.Click += new EventHandler(OnTexBoxMenu_Delete);
            theMenu.MenuItems.Add(menuItem);

            menuItem        = new MenuItem("-");
            theMenu.MenuItems.Add(menuItem);

            menuItem        = new MenuItem("Select All");
            menuItem.Click += new EventHandler(OnTexBoxMenu_SelectAll);
            theMenu.MenuItems.Add(menuItem);

            theMenu.Popup += new EventHandler(OnTexBoxMenu_Popup);

            //_textBox.ContextMenu = theMenu;*/

            Controls.Add(_textBox);

            _upScroll.Enabled = false;
            _dnScroll.Enabled = false;

            //Create redirection object to the base palette
            if (((_palette != null)))
            {
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
            }
            KryptonManager.GlobalPaletteChanged += new EventHandler(OnGlobalPaletteChanged);
            _palette = KryptonManager.CurrentGlobalPalette;
            _paletteRedirect = new PaletteRedirect(_palette);

            //Create accessor objects for the back, border and content
            _paletteBack = new PaletteBackInheritRedirect(_paletteRedirect);

            _paletteBorder = new PaletteBorderInheritRedirect(_paletteRedirect);

            _paletteContent = new PaletteContentInheritRedirect(_paletteRedirect);

            InitColours();
        }

        #endregion //Initialization

        #region Properties

        [Category("ToolBox")]
        public int LayoutDelay
        {
            get { return _layoutDelay; }
            set { _layoutDelay = value; }
        }

        [Category("ToolBox")]
        public int ScrollDelay
        {
            get { return _scrollDelay; }
            set { _scrollDelay = value; }
        }

        [Category("ToolBox")]
        public int InitialScrollDelay
        {
            get { return _scrollWait; }
            set { _scrollWait = value; }
        }

        [Category("ToolBox")]
        public Color ItemBackgroundColour
        {
            get { return _itemBgColour; }
            set
            {
                if (value != _itemBgColour)
                {
                    _itemBgColour = value;
                    Invalidate();
                }
            }
        }

        [Category("ToolBox")]
        public Color ItemBorderColour
        {
            get { return _itemBorderColour; }
            set
            {
                if (value != _itemBorderColour)
                {
                    _itemBorderColour = value;
                    Invalidate();
                }
            }
        }

        [Category("ToolBox")]
        public Color ItemSelectedColour
        {
            get { return _selectedItemColour; }
            set
            {
                if (value != _selectedItemColour)
                {
                    _selectedItemColour = value;
                    Invalidate();
                }
            }
        }

        [Category("ToolBox")]
        public bool ShowOnlyOneItemPerRow
        {
            get { return _onlyOneItemPerRow; }
            set
            {
                if (value != _onlyOneItemPerRow)
                {
                    _onlyOneItemPerRow = value;
                    LayoutNonSelectedTabs();
                    DoLayout(true, true, true);
                }
            }
        }

        [Category("ToolBox")]
        public Color ItemHoverColour
        {
            get { return _itemHoverColour; }
            set
            {
                if (value != _itemHoverColour)
                {
                    _itemHoverColour = value;
                    Invalidate();
                }
            }
        }

        [Category("ToolBox")]
        public Color ItemNormalColour
        {
            get { return _itemNormalColour; }
            set
            {
                if (value != _itemNormalColour)
                {
                    _itemNormalColour = value;
                    Invalidate();
                }
            }
        }

        [Category("ToolBox")]
        public Color TabSelectedTextColour
        {
            get { return _tabTxtSelectColour.IsEmpty ? SystemColors.ControlText : _tabTxtSelectColour; }
            set
            {
                if (value != _tabTxtSelectColour)
                {
                    if (value != SystemColors.ControlText)
                    {
                        _tabTxtSelectColour = value;
                    }
                    else
                    {
                        _tabTxtSelectColour = Color.Empty;
                    }
                    Invalidate();
                }
            }
        }

        [Category("ToolBox")]
        public Color TabNormalTextColour
        {
            get { return _tabTxtNormalColour.IsEmpty ? SystemColors.ControlText : _tabTxtNormalColour; }
            set
            {
                if (value != _tabTxtNormalColour)
                {
                    if (value != SystemColors.ControlText)
                    {
                        _tabTxtNormalColour = value;
                    }
                    else
                    {
                        _tabTxtNormalColour = Color.Empty;
                    }
                    Invalidate();
                }
            }
        }

        [Category("ToolBox")]
        public Color TabHoverTextColour
        {
            get { return _tabTxtHoverColour.IsEmpty ? SystemColors.ControlText : _tabTxtHoverColour; }
            set
            {
                if (value != _tabTxtHoverColour)
                {
                    if (value != SystemColors.ControlText)
                    {
                        _tabTxtHoverColour = value;
                    }
                    else
                    {
                        _tabTxtHoverColour = Color.Empty;
                    }
                    Invalidate();
                }
            }
        }

        [Category("ToolBox")]
        public Color ItemSelectedTextColour
        {
            get { return _itemTxtSelectColour.IsEmpty ? SystemColors.ControlText : _itemTxtSelectColour; }
            set
            {
                if (value != _itemTxtSelectColour)
                {
                    if (value != SystemColors.ControlText)
                    {
                        _itemTxtSelectColour = value;
                    }
                    else
                    {
                        _itemTxtSelectColour = Color.Empty;
                    }
                    Invalidate();
                }
            }
        }

        [Category("ToolBox")]
        public Color ItemNormalTextColour
        {
            get { return _itemTxtNormalColour.IsEmpty ? SystemColors.ControlText : _itemTxtNormalColour; }
            set
            {
                if (value != _itemTxtNormalColour)
                {
                    if (value != SystemColors.ControlText)
                    {
                        _itemTxtNormalColour = value;
                    }
                    else
                    {
                        _itemTxtNormalColour = Color.Empty;
                    }
                    Invalidate();
                }
            }
        }

        [Category("ToolBox")]
        public Color ItemHoverTextColour
        {
            get { return _itemTxtHoverColor.IsEmpty ? SystemColors.ControlText : _itemTxtHoverColor; }
            set
            {
                if (value != _itemHoverColour)
                {
                    if (value != SystemColors.ControlText)
                    {
                        _itemTxtHoverColor = value;
                    }
                    else
                    {
                        _itemTxtHoverColor = Color.Empty;
                    }
                    Invalidate();
                }
            }
        }

        [Category("ToolBox"), XmlIgnore]
        public ImageList SmallImageList
        {
            get { return _smallImageList; }
            set
            {
                if (value != _smallImageList)
                {
                    _smallImageList = value;

                    VerifyDimensions(false);
                    Invalidate();
                }
            }
        }

        [Category("ToolBox"), XmlIgnore]
        public ImageList LargeImageList
        {
            get { return _largeImageList; }
            set
            {
                if (value != _largeImageList)
                {
                    _largeImageList = value;

                    VerifyDimensions(false);
                    Invalidate();
                }
            }
        }

        [Category("ToolBox")]
        public int TabHeight
        {
            get { return _tabHeight; }
            set
            {
                if (value != _tabHeight && IsHeightValid(value, false))
                {
                    _tabHeight = value;
                    _origTabHeight = value;

                    DoLayout(true, true, true);
                }
            }
        }

        [Category("ToolBox")]
        public int ItemHeight
        {
            get { return _itemHeight; }
            set
            {
                if (value != _itemHeight && IsHeightValid(value, false))
                {
                    _itemHeight = value;
                    _origItemHeight = value;

                    LayoutNonSelectedTabs();
                    DoLayout(true, true, true);
                }
            }
        }

        [Category("ToolBox")]
        public Size LargeItemSize
        {
            get { return _largeItemSize; }
            set
            {
                if (value != _largeItemSize && IsHeightValid(value.Height, true))
                {
                    _largeItemSize = value;
                    _origLargeItemSize = value;

                    LayoutNonSelectedTabs();
                    DoLayout(true, true, true);
                }
            }
        }

        [Category("ToolBox")]
        public Size SmallItemSize
        {
            get { return _smallItemSize; }
            set
            {
                if (value != _smallItemSize && IsHeightValid(value.Height, false))
                {
                    _smallItemSize = value;
                    _origSmallItemSize = value;

                    LayoutNonSelectedTabs();
                    DoLayout(true, true, true);
                }
            }
        }

        [Category("ToolBox")]
        public int ItemSpacing
        {
            get { return _itemSpacing; }
            set
            {
                if (value != _itemSpacing)
                {
                    _itemSpacing = value;
                    LayoutNonSelectedTabs();
                    DoLayout(true, true, true);
                }
            }
        }

        [Category("ToolBox")]
        public int TabSpacing
        {
            get { return _tabSpacing; }
            set
            {
                if (value != _tabSpacing)
                {
                    _tabSpacing = value;
                    //LayoutNonSelectedTabs();
                    DoLayout(true, true, true);
                }
            }
        }
        /*
        * UnComment this property if you are using XmlSerializer
        * [Category("ToolBox"), Browsable(false)]
        * public ToolBoxTabCollection Tabs
        * {
        *    get{return _toolBoxTabs;}
        *    set
        *    {
        *        if(null != value && value != _toolBoxTabs)
        *        {
        *            _toolBoxTabs = value;
        *            RefreshTabs();
        *        }
        *    }
        * }
        */

        [Category("ToolBox"), Browsable(false), XmlIgnore]
        public ToolBoxTab this[int tabIndex]
        {
            get
            {
                ToolBoxTab tab = null;
                try
                {
                    if (0 <= tabIndex && tabIndex < _toolBoxTabs.Count)
                    {
                        tab = _toolBoxTabs[tabIndex];
                    }
                }
                catch
                {
                    tab = null;
                }
                return tab;
            }
        }

        [Category("ToolBox"), Browsable(false), XmlIgnore]
        public ToolBoxTab this[string caption]
        {
            get
            {
                ToolBoxTab tab = null;
                int iLoop = 0;
                try
                {
                    for (iLoop = 0; iLoop < _toolBoxTabs.Count; iLoop++)
                    {
                        if (_toolBoxTabs[iLoop].Caption.Equals(caption))
                        {
                            tab = _toolBoxTabs[iLoop];
                            iLoop = _toolBoxTabs.Count + 1;
                        }
                    }
                }
                catch
                {
                }
                return tab;
            }
        }

        [Category("ToolBox"), XmlIgnore]
        public ToolBoxTab SelectedTab
        {
            get { return _selectedTab; }
        }

        [Category("ToolBox"), Browsable(false), XmlIgnore]
        public ToolBoxItem EditingItem
        {
            get { return _textBox.Tag as ToolBoxItem; }
        }

        [Category("ToolBox")]
        public int SelectedTabIndex
        {
            get
            {
                int index = -1;
                try
                {
                    index = _toolBoxTabs.IndexOf(_selectedTab);
                }
                catch
                {
                    index = -1;
                }
                return index;
            }
            set
            {
                int selIndex = -1;
                int newIndex = -1;
                selIndex = _toolBoxTabs.IndexOf(_selectedTab);
                newIndex = value;

                if (0 <= newIndex && newIndex < _toolBoxTabs.Count && selIndex != newIndex)
                {
                    _oldselectedTab = _selectedTab;
                    if (null != _oldselectedTab)
                    {
                        _oldselectedTab.Selected = false;
                    }
                    _selectedTab = this[newIndex];
                    _selectedTab.Selected = true;
                    DoLayout(true, true);

                    try
                    {
                        if (null != TabSelectionChanged)
                        {
                            TabSelectionChanged(_selectedTab, EventArgs.Empty);
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }

        [Category("ToolBox"), Browsable(false), XmlIgnore]
        public int SmallImageWidth
        {
            get { return _smallImageList.ImageSize.Width; }
        }

        [Category("ToolBox"), Browsable(false), XmlIgnore]
        public int SmallImageHeight
        {
            get { return _smallImageList.ImageSize.Height; }
        }

        [Category("ToolBox"), Browsable(false), XmlIgnore]
        public ImageAttributes DisabledImageAttribs
        {
            get
            {
                if (null == _dImgAttr)
                {
                    ColorMatrix cmtx = null;
                    float[][] matrix = new float[][]
                        {
                            new float[] {0.3f ,0.3f ,0.3f ,1, 1},
                            new float[] {0.1f ,0.1f ,0.1f ,1, 1},
                            new float[] {0.1f ,0.1f ,0.1f ,1, 1},
                            new float[] {0.3f ,0.3f ,0.3f ,1, 1},
                            new float[] {0.08f,0.08f,0.08f,0, 1},
                            new float[] {1    ,1    ,1    ,1, 1},
                    };
                    cmtx = new ColorMatrix(matrix);
                    _dImgAttr = new ImageAttributes();

                    _dImgAttr.SetColorMatrix(cmtx);
                }
                return _dImgAttr;
            }
        }

        [Category("ToolBox"), Browsable(false)]
        public ToolScrollButton UpScroll
        {
            get { return _upScroll; }
        }

        [Category("ToolBox"), Browsable(false)]
        public ToolScrollButton DownScroll
        {
            get { return _dnScroll; }
        }

        [Category("ToolBox"), Browsable(false), XmlIgnore]
        public bool LayoutTimerActive
        {
            get { return null != _timer && _timerIsForLayout; }
        }

        [Category("ToolBox")]
        public bool SelectAllTextWhileRenaming
        {
            get { return _selAllTextInRename; }
            set { _selAllTextInRename = value; }
        }

        [Category("ToolBox")]
        public bool AllowSwappingByDragDrop
        {
            get { return _allowDragSwap; }
            set { _allowDragSwap = value; }
        }

        [Category("ToolBox")]
        public bool UseItemColorInRename
        {
            get { return _useItemClrInRename; }
            set { _useItemClrInRename = value; }
        }

        [Category("ToolBox"), XmlIgnore, Browsable(false)]
        public bool IsLoading
        {
            get { return _isLoading; }
        }

        #endregion //Properties

        #region Internal Methods

        internal void LockMouseMove()
        {
            _mouseMoveFreezed = true;
        }

        internal void UnLockMouseMove()
        {
            _mouseMoveFreezed = false;
        }

        internal void PatBltOnItem(ToolBoxItem item)
        {
            Graphics g = null;
            IntPtr hdc = IntPtr.Zero;
            Rectangle rct = Rectangle.Empty;
            Point offset = Point.Empty;

            try
            {
                if (null != _patBltItem || null != item)
                {
                    g = CreateGraphics();
                    hdc = g.GetHdc();
                    if (null != _patBltItem)
                    {
                        rct = _patBltItem.Rectangle;
                        if (_patBltItem.ParentItem is ToolBoxTab)
                        {
                            offset = ((ToolBoxTab)_patBltItem.ParentItem).ItemArea.Location;

                            rct.X += offset.X;
                            rct.Y += offset.Y;

                            if (rct.Bottom > ((ToolBoxTab)_patBltItem.ParentItem).ItemArea.Bottom)
                            {
                                rct.Height = ((ToolBoxTab)_patBltItem.ParentItem).ItemArea.Bottom - rct.Top;
                            }
                        }

                        PatBlt(hdc, rct.X + 1, rct.Y + 1, rct.Width - 2, rct.Height - 2, DSTINVERT);
                    }
                    if (_patBltItem != item && null != item)
                    {
                        rct = item.Rectangle;
                        if (item.ParentItem is ToolBoxTab)
                        {
                            offset = ((ToolBoxTab)item.ParentItem).ItemArea.Location;

                            rct.X += offset.X;
                            rct.Y += offset.Y;

                            if (rct.Bottom > ((ToolBoxTab)item.ParentItem).ItemArea.Bottom)
                            {
                                rct.Height = ((ToolBoxTab)item.ParentItem).ItemArea.Bottom - rct.Top;
                            }
                        }

                        PatBlt(hdc, rct.X + 1, rct.Y + 1, rct.Width - 2, rct.Height - 2, DSTINVERT);

                    }

                    _patBltItem = item;

                }
            }
            catch
            {
            }
            finally
            {
                if (IntPtr.Zero != hdc && null != g)
                {
                    g.ReleaseHdc(hdc);
                }
                if (null != g)
                {
                    g.Dispose();
                }
            }
        }

        internal void StopTimer()
        {
            if (null != _timer)
            {
                _timer.Enabled = false;

                if (_timerIsForLayout)
                {
                    _oldselectedTab = null;
                    DoLayout(false, true);
                }
                _timer.Dispose();
            }
            _timer = null;
        }

        internal void UpdateToolTip(ToolObject obj)
        {
            if (null == obj.ToolTip || 0 >= obj.ToolTip.Length && obj.ForceCaptionToolTip || !obj.FullyVisible)
            {
                UpdateToolTip(obj.Caption);
            }
            else
            {
                UpdateToolTip(obj.ToolTip);
            }
        }

        internal void UpdateToolTip(string toolTip)
        {
            if (!toolTip.Equals(_toolTip.GetToolTip(this)))
            {
                _toolTip.SetToolTip(this, toolTip);
            }
        }

        internal void OnTabSelectionChanged(ToolBoxTab tab, LayoutFinished layoutFinished)
        {
            ToolBoxTab oldTab = _selectedTab;

            if (!_isLoading)
            {

                StopTimer();

                _layoutFinished = layoutFinished;

                if (oldTab != tab)
                {
                    if (null != oldTab)
                    {
                        oldTab.Selected = false;
                        oldTab.MouseHover = false;
                    }

                    _selectedTab = tab;
                    _selectedTab.Selected = true;
                    _selectedTab.MouseHover = false;

                    _oldselectedTab = oldTab;
                    //_oldselectedTab.ItemArea = oldTab.ItemArea;

                    if (this.Created)
                    {
                        _timer = new System.Windows.Forms.Timer();
                        _timer.Tick += new EventHandler(OnTimer_LayoutElapsed);
                        _timer.Interval = _layoutDelay;
                        _timer.Enabled = true;
                        _timerIsForLayout = true;

                        if (null != TabSelectionChanged)
                        {
                            TabSelectionChanged(tab, null);
                        }
                    }
                    else
                    {
                        DoLayout(true, true, false);
                    }
                }
            }
        }

        internal void OnItemSelectionChanged(ToolBoxItem item, ToolBoxTab tab)
        {
            try
            {
                if (null != ItemSelectionChanged)
                {
                    ItemSelectionChanged(item, EventArgs.Empty);
                }
            }
            catch
            {
            }
        }

        internal void OnTabMouseDown(ToolBoxTab tab, MouseEventArgs e)
        {
            try
            {
                if (null != TabMouseDown)
                {
                    TabMouseDown(tab, e);
                }
            }
            catch
            {
            }
        }

        internal void OnTabMouseUp(ToolBoxTab tab, MouseEventArgs e)
        {
            try
            {
                if (null != TabMouseUp)
                {
                    TabMouseUp(tab, e);
                }
            }
            catch
            {
            }
        }

        internal void OnItemMouseDown(ToolBoxItem sender, ToolBoxTab parent, MouseEventArgs e)
        {
            try
            {
                if (null != ItemMouseDown)
                {
                    ItemMouseDown(sender, e);
                }
            }
            catch
            {
            }
        }

        internal void OnItemMouseUp(ToolBoxItem sender, ToolBoxTab parent, MouseEventArgs e)
        {
            try
            {
                if (null != ItemMouseUp)
                {
                    ItemMouseUp(sender, e);
                }
            }
            catch
            {
            }
        }

        internal void RenameItem(ToolBoxItem item)
        {
            Point ptLocation = Point.Empty;
            bool bOK = true;
            bool bIsTab = true;
            bool imageFound = false;
            ToolBoxTab tab = null;
            ImageList imgList = null;

            try
            {
                if (item.GetType() != typeof(ToolBoxTab))
                {
                    bOK = null != _selectedTab && _selectedTab.Contains(item);

                    if (bOK && item.Renamable)
                    {
                        _selectedTab.View = ToolBoxViewMode.LIST;
                        _selectedTab.EnsureItemVisible(item);
                    }

                    bIsTab = false;
                }

                if (bOK)
                {
                    bOK = EndRenameItem();
                }

                if (bOK && item.Renamable)
                {
                    RestoreTextBoxColors();

                    if (!bIsTab)
                    {
                        tab = item.ParentItem as ToolBoxTab;
                    }

                    _textBox.Font = this.Font;
                    _textBox.Text = item.Caption;
                    _textBox.Width = item.Width - 6;
                    //_textBox.Height = item.Height - 2;
                    ptLocation = item.Location;

                    if (_textBox.Height < item.Height)
                    {
                        ptLocation.Y += (item.Height - _textBox.Height) / 2;
                    }

                    if (null != tab)
                    {
                        ptLocation.Y += tab.ItemArea.Y;
                    }
                    /*else
                    {
                        _textBox.Width -= 4;
                    }*/

                    imgList = _smallImageList;

                    if (-1 != item.SmallImageIndex &&
                        null != this._smallImageList &&
                        0 < this._smallImageList.Images.Count &&
                        item.SmallImageIndex < this._smallImageList.Images.Count)
                    {
                        _textBox.Width -= imgList.ImageSize.Width + 4;
                        ptLocation.X += imgList.ImageSize.Width + 4;

                        imageFound = true;
                    }

                    if (null != tab)
                    {
                        ptLocation.X += 4;
                    }
                    else
                    {
                        ptLocation.X += 3;
                    }

                    if (imageFound)
                    {
                        ptLocation.X -= 1;
                    }

                    if (_selAllTextInRename)
                    {
                        _textBox.SelectAll();
                    }
                    else
                    {
                        _textBox.Select(item.Caption.Length, 0);
                    }

                    if (_useItemClrInRename)
                    {
                        if (!bIsTab)
                        {
                            if (item.Selected)
                            {
                                _textBox.BackColor = _selectedItemColour.IsEmpty ? _textBox.BackColor : _selectedItemColour;
                                _textBox.ForeColor = _itemTxtSelectColour.IsEmpty ? _textBox.ForeColor : _itemTxtSelectColour;
                            }
                            else
                            {
                                _textBox.ForeColor = _itemTxtNormalColour.IsEmpty ? _textBox.ForeColor : _itemTxtNormalColour;
                                _textBox.BackColor = _itemNormalColour.IsEmpty ? _textBox.BackColor : _itemNormalColour;
                            }
                        }
                        else
                        {
                            if (item.Selected)
                            {
                                _textBox.ForeColor = _tabTxtSelectColour.IsEmpty ? _textBox.ForeColor : _tabTxtSelectColour;
                            }
                            else
                            {
                                _textBox.ForeColor = _tabTxtNormalColour.IsEmpty ? _textBox.ForeColor : _tabTxtNormalColour;
                            }

                            _textBox.BackColor = this.BackColor;
                        }
                    }
                    _textBox.Location = ptLocation;
                    _textBox.Tag = item;
                    _textBox.Visible = true;
                    _textBox.Focus();
                }
            }
            catch
            {
            }
        }

        #endregion //Internal Methods

        #region Public Methods

        public DragDropEffects DoDragDropItem(ToolBoxItem item, DragDropEffects allowedEffects)
        {
            DragDropEffects e = DragDropEffects.None;
            DataObject dobj = null;


            _dragItem = item;

            dobj = new DataObject();
            dobj.SetData(_dragItem);
            dobj.SetData(DataFormats.Text, item.Caption);

            try
            {
                // Allow user to add custom data types based on the object associated
                // with the item being drag dropped.
                if (null != OnBeginDragDrop)
                {
                    OnBeginDragDrop(item, new ToolBoxPreDragDropEventArgs(dobj, item.Object));
                }
            }
            catch
            {
            }

            e = DoDragDrop(dobj, allowedEffects);

            try
            {
                if (null != DragDropFinished)
                {
                    DragDropFinished(item, e);
                }
            }
            catch
            {
            }

            if (null != _patBltItem)
            {
                _patBltItem.Invalidate();
            }

            _patBltItem = null;
            _dragItem = null;

            return e;
        }

        public void EndTimedLayout()
        {
            StopTimer();
        }

        public int HitTestTab(int x, int y)
        {
            int index = -1;

            for (int iLoop = 0; iLoop < _toolBoxTabs.Count; iLoop++)
            {
                if (_toolBoxTabs[iLoop].HitTest(x, y))
                {
                    index = iLoop;
                    iLoop = _toolBoxTabs.Count + 1;
                }
            }
            return index;
        }

        public int IndexOfTab(ToolBoxTab tab)
        {
            return _toolBoxTabs.IndexOf(tab);
        }

        public bool CanMoveTabUp(ToolBoxTab tab)
        {
            bool bCanMoveUp = false;
            int index1 = -1;
            ToolBoxTab prev = null;

            try
            {
                index1 = _toolBoxTabs.IndexOf(tab);
                prev = _toolBoxTabs[index1 - 1];
                bCanMoveUp = tab.Movable && prev.Movable;
            }
            catch
            {
                bCanMoveUp = false;
            }

            return bCanMoveUp;
        }

        public bool CanMoveTabDown(ToolBoxTab tab)
        {
            bool bCanMoveDn = false;
            int index1 = -1;
            ToolBoxTab next = null;

            try
            {
                index1 = _toolBoxTabs.IndexOf(tab);
                next = _toolBoxTabs[index1 + 1];
                bCanMoveDn = tab.Movable && next.Movable;
            }
            catch
            {
                bCanMoveDn = false;
            }

            return bCanMoveDn;
        }

        public bool MoveTabUp(ToolBoxTab tab)
        {
            bool bMoved = false;
            int index1 = -1;

            try
            {
                index1 = _toolBoxTabs.IndexOf(tab);
                bMoved = SwapTabs(index1, index1 - 1);
            }
            catch
            {
                bMoved = false;
            }
            return bMoved;
        }

        public bool MoveTabDown(ToolBoxTab tab)
        {
            bool bMoved = false;
            int index1 = -1;
            try
            {
                index1 = _toolBoxTabs.IndexOf(tab);
                bMoved = SwapTabs(index1, index1 + 1);
            }
            catch
            {
                bMoved = false;
            }

            return bMoved;
        }

        public bool SwapTabs(ToolBoxTab tab1, ToolBoxTab tab2)
        {
            bool bSwaped = false;
            int index1 = -1;
            int index2 = -1;

            try
            {
                index1 = _toolBoxTabs.IndexOf(tab1);
                index2 = _toolBoxTabs.IndexOf(tab2);
                bSwaped = SwapTabs(index1, index2);
            }
            catch
            {
                bSwaped = false;
            }

            return bSwaped;
        }

        public bool EndRenameItem()
        {
            return EndRenameItem(false, false);
        }

        public void RefreshTabs()
        {
            DoLayout(true, false);

            LayoutTabs(false);

            if (null != _selectedTab)
            {
                _upScroll.Enabled = _selectedTab.CanScroll(ToolBoxScrollDirection.UP);
                _dnScroll.Enabled = _selectedTab.CanScroll(ToolBoxScrollDirection.DOWN);
            }
            else
            {
                _upScroll.Enabled = false;
                _dnScroll.Enabled = false;
            }

            Invalidate();
        }

        public bool SetImageList(Image image, Size size, Color transparentColor, bool small)
        {
            bool bOk = false;

            if (small)
            {
                _smallImageList.Images.Clear();

                if (null != image)
                {
                    _smallImageList = CreateImageListFromImage(image, size, transparentColor);
                }

                bOk = (_smallImageList.Images.Count > 0);
            }
            else
            {
                _largeImageList.Images.Clear();

                if (null != image)
                {
                    _largeImageList = CreateImageListFromImage(image, size, transparentColor);
                }

                bOk = (_largeImageList.Images.Count > 0);

            }

            return bOk;
        }


        public bool SetImageList(Image image, Size size, Color transparentColor)
        {
            return SetImageList(image, size, transparentColor, true);
        }

        public bool SetSmallImageList(Image image, Size size, Color transparentColor)
        {
            return SetImageList(image, size, transparentColor, true);
        }

        public bool SetLargeImageList(Image image, Size size, Color transparentColor)
        {
            return SetImageList(image, size, transparentColor, false);
        }

        public int AddTab(string caption)
        {
            return AddTab(caption, -1, true);
        }

        public int AddTab(string caption, int smallImageIndex)
        {
            return AddTab(caption, smallImageIndex, true);
        }

        public int AddTab(string caption, int smallImageIndex, bool bRedraw)
        {
            ToolBoxTab tab = new ToolBoxTab(caption, smallImageIndex);
            return AddTab(tab, bRedraw);
        }

        public int AddTab(ToolBoxTab tab)
        {
            return AddTab(tab, true);
        }

        public int AddTab(ToolBoxTab tab, bool bRedraw)
        {
            int index = -1;
            try
            {
                if (EndRenameItem())
                {

                    index = _toolBoxTabs.Add(tab);

                    tab.Parent = this;
                    tab.Selected = true;
                    tab.RegisterEvents();

                    if (Created)
                    {
                        DoLayout(true, bRedraw);
                    }
                }
            }
            catch
            {
                index = -1;
            }
            return index;
        }

        public bool DeleteTab(ToolBoxTab tab)
        {
            return DeleteTab(tab, true);
        }

        public bool DeleteTab(ToolBoxTab tab, bool bRedraw)
        {
            bool bOK = true;
            int index = -1;
            try
            {
                index = _toolBoxTabs.IndexOf(tab);
                bOK = DeleteTab(index, bRedraw);
            }
            catch
            {
                bOK = false;
            }
            return bOK;
        }

        public bool DeleteTab(int index)
        {
            return DeleteTab(index, true);
        }

        public bool DeleteTab(int index, bool bRedraw)
        {
            bool bOK = true;
            bool bSel = false;
            ToolBoxTab tab = null;

            try
            {
                // Hack to prevent timer callback by tab being set as selected.
                // Set back to false in finally block.
                _isLoading = true;

                if (EditingItem != this[index])
                {
                    bOK = EndRenameItem();
                }

                if (bOK)
                {
                    tab = this[index];
                    bSel = tab.Selected;

                    tab.UnRegisterEvents();

                    if (null != tab.Control)
                    {
                        this.Controls.Remove(tab.Control);
                    }

                    _toolBoxTabs.RemoveAt(index);

                    // Selected tab is deleted. Set the previous tab to selected state.
                    // If there is no previous, next tab, or zeroth tab will be used.
                    if (bSel)
                    {
                        tab = this[index - 1];

                        if (null == tab)
                        {
                            tab = this[index];
                        }

                        if (null == tab)
                        {
                            tab = this[0];
                        }

                        if (null != tab)
                        {
                            if (null != _oldselectedTab)
                            {
                                _oldselectedTab.Selected = false;
                            }

                            _oldselectedTab = _selectedTab;
                            _selectedTab = tab;
                            _selectedTab.Selected = true;

                            try
                            {
                                // Invoke tab selection changed event.
                                if (null != TabSelectionChanged)
                                {
                                    TabSelectionChanged(_selectedTab, null);
                                }
                            }
                            catch
                            {
                            }
                        }
                        else
                        {
                            _selectedTab = null;
                        }
                    }
                    DoLayout(true, bRedraw);
                }
            }
            catch
            {
                bOK = false;
            }
            finally
            {
                _isLoading = false;
            }

            return bOK;
        }

        public void DeleteAllTabs()
        {
            DeleteAllTabs(true);
        }

        public void DeleteAllTabs(bool refresh)
        {
            int iLoop1 = 0;

            try
            {
                for (iLoop1 = 0; iLoop1 < _toolBoxTabs.Count;)
                {
                    if (null != _toolBoxTabs[iLoop1].Control)
                    {
                        this.Controls.Remove(_toolBoxTabs[iLoop1].Control);
                    }

                    _toolBoxTabs[iLoop1].UnRegisterEvents();
                    _toolBoxTabs.RemoveAt(iLoop1);
                }

                if (refresh)
                {
                    RefreshTabs();
                }
            }
            catch
            {
            }
        }

        #endregion //Public Methods

        #region Private Methods

        private void RestoreTextBoxColors()
        {
            if (_useItemClrInRename)
            {
                _textBox.BackColor = _defTxtBoxBgColour;
                _textBox.ForeColor = _defTxtBoxTxColour;
            }
        }

        private bool EndRenameItem(bool byLostFocus, bool byEscapeKey)
        {
            bool bContinueRename = false;
            bool bSave = true;

            if (_textBox.Visible)
            {
                OnRenameFinished(ref bSave, ref bContinueRename, byEscapeKey);

                if (bSave && !byEscapeKey)
                {
                    UpdateItemFromTextBox();
                }
                else
                {
                    if (!bContinueRename)
                    {
                        _textBox.Visible = false;
                    }

                    RestoreTextBoxColors();
                }

                if (!byLostFocus)
                {
                    Focus();
                }
            }

            return bSave;
        }

        private void OnRenameFinished(ref bool bSave, ref bool bContinueRename, bool byEscapeKey)
        {
            ToolBoxRenameFinishedEventArgs e = null;

            bSave = true;
            bContinueRename = false;

            try
            {
                if (null != RenameFinished)
                {
                    e = new ToolBoxRenameFinishedEventArgs(_textBox.Text, byEscapeKey);
                    RenameFinished(_textBox.Tag as ToolBoxItem, e);

                    bSave = !e.Cancel;
                    bContinueRename = e.ContinueRenaming;
                }
            }
            catch
            {
            }
        }

        private void UpdateItemFromTextBox()
        {
            try
            {
                if (_textBox.Visible)
                {
                    ToolBoxItem item = _textBox.Tag as ToolBoxItem;
                    item.Caption = _textBox.Text;
                    _textBox.Visible = false;
                    _textBox.Tag = null;

                    RestoreTextBoxColors();
                    //Focus();
                }
            }
            catch
            {
            }
        }

        private bool SwapTabs(int index1, int index2)
        {
            bool bSwaped = false;
            ToolBoxTab tab1 = null;
            ToolBoxTab tab2 = null;

            try
            {
                if (index1 != index2)
                {
                    tab1 = _toolBoxTabs[index1];
                    tab2 = _toolBoxTabs[index2];

                    _toolBoxTabs[index2] = tab1;
                    _toolBoxTabs[index1] = tab2;

                    DoLayout(true, false);

                    if (tab1 == _selectedTab || tab2 == _selectedTab)
                    {
                        _selectedTab.UpdateItemRects(false);
                    }

                    Invalidate();

                    bSwaped = true;
                }
            }
            catch
            {
                bSwaped = false;
            }

            return bSwaped;
        }

        private void CreateScrollTimer(ToolBoxScrollDirection dir)
        {
            StopTimer();
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = _scrollWait;

            _timerIsForLayout = false;
            if (ToolBoxScrollDirection.UP == dir)
            {
                _timer.Tick += new EventHandler(OnTimer_UpScrollElapsed);
            }
            else
            {
                _timer.Tick += new EventHandler(OnTimer_DnScrollElapsed);
            }
            _timer.Enabled = true;
        }

        private void HandleScrollTimerElapsed(ToolBoxScrollDirection dir, ToolBoxTab tab, ToolScrollButton sb)
        {
            if (null != tab)
            {
                tab.ScrollItems(dir);

                if (!tab.CanScroll(dir))
                {
                    StopTimer();
                    sb.MouseDown = false;
                    sb.Enabled = false;
                    Invalidate(sb.Rectangle);
                }
                else if (null != _timer && _scrollWait == _timer.Interval)
                {
                    _timer.Interval = _scrollDelay;
                }

            }
        }

        private bool DoTimedLayout(ToolBoxTab oldSelectedTab)
        {
            bool bFinished = false;
            bool selItemAreaBad = false;
            int oldTabIndex = -1;
            int selTabIndex = -1;
            int iLoop = 0;
            int maxY = 0;
            int inc = 0;
            ToolBoxTab tab = null;
            Rectangle paintRect = DisplayRectangle;
            Rectangle oldItemArea;
            Rectangle selItemArea;

            oldTabIndex = _toolBoxTabs.IndexOf(_oldselectedTab);
            selTabIndex = _toolBoxTabs.IndexOf(_selectedTab);

            oldItemArea = _oldselectedTab.ItemArea;
            selItemArea = _selectedTab.ItemArea;

            if (0 >= selItemArea.Width || 0 >= selItemArea.Height)
            {
                selItemAreaBad = true;
            }

            if (null != _selectedTab.Control && !_selectedTab.ItemArea.IsEmpty && _selectedTab.ItemArea.Bottom < _dnScroll.Bottom)
            {
                _selectedTab.Control.Visible = true;
                this.Controls.Add(_selectedTab.Control);
            }

            if (null != _selectedTab.Control)
            {
                System.Diagnostics.Debug.WriteLine("Control Location " + _selectedTab.Control.Location + " Item Area " + _selectedTab.ItemArea);
            }

            if (null != _oldselectedTab)
            {

                inc = (_tabHeight / 2 >= inc) ? (oldItemArea.Height / 6) - 2 : inc;
                inc = (_tabHeight / 2 >= inc) ? (oldItemArea.Height / 3) - 2 : inc;
                inc = (_tabHeight / 2 >= inc) ? (oldItemArea.Height / 2) - 2 : inc;
                inc = (_tabHeight / 2 >= inc) ? _tabHeight / 2 : inc;

                if (oldTabIndex < selTabIndex)
                {
                    // Selected tab is below the old tab.
                    tab = this[oldTabIndex + 1];

                    maxY = _oldselectedTab.Bottom + _tabSpacing;

                    if ((tab.Y - inc) <= maxY)
                    {
                        inc = tab.Y - maxY;
                    }

                    paintRect.Y = _oldselectedTab.Top;

                    for (iLoop = oldTabIndex + 1; iLoop <= selTabIndex; iLoop++)
                    {
                        this[iLoop].Y -= inc;
                    }

                    tab = this[oldTabIndex + 1];
                    tab.Width = DisplayRectangle.Width - 2;

                    oldItemArea.Height = (tab.Top - 1) - (_oldselectedTab.Bottom - 1);
                    _selectedTab.Width = (DisplayRectangle.Width - 2) - (_upScroll.Width + 1);
                    _oldselectedTab.Width = DisplayRectangle.Width - 2;
                    tab = this[selTabIndex + 1];
                    if (null != tab)
                    {
                        tab.Width = (DisplayRectangle.Width - 2) - (_upScroll.Width + 1);
                        _dnScroll.Y = tab.Y;
                        paintRect.Height = _dnScroll.Bottom - paintRect.Y;
                    }
                    else
                    {
                        _dnScroll.Y = _selectedTab.Bottom + _tabSpacing + _itemHeight;
                        _dnScroll.Y = _dnScroll.Bottom < DisplayRectangle.Bottom ? DisplayRectangle.Bottom - (_tabHeight + _tabSpacing) : _dnScroll.Y;
                    }

                    _upScroll.Y = _selectedTab.Y;

                    tab = this[oldTabIndex + 1];

                    if (tab.Y <= maxY)
                    {
                        oldItemArea.Height = 0;
                        bFinished = true;
                    }
                }
                else
                {
                    maxY = DisplayRectangle.Bottom - ((_tabHeight + _tabSpacing) * (_toolBoxTabs.Count - (selTabIndex + 1)));
                    //maxY = (maxY <= _selectedTab.Y + (_itemHeight + _itemSpacing) ) ? _selectedTab.Y + (2*_itemHeight) + 2*_itemSpacing : maxY; 
                    maxY = (maxY <= _selectedTab.Y + (_itemHeight + _itemSpacing)) ? _selectedTab.Bottom + (_itemHeight + _itemSpacing + _tabSpacing) : maxY;

                    paintRect.Y = _selectedTab.Top;

                    tab = this[selTabIndex + 1];
                    if ((tab.Y + inc) >= maxY)
                    {
                        inc = maxY - tab.Y;
                    }

                    for (iLoop = selTabIndex + 1; iLoop <= oldTabIndex; iLoop++)
                    {
                        this[iLoop].Y += inc;
                    }

                    tab = this[selTabIndex + 1];

                    _selectedTab.Width = (DisplayRectangle.Width - 2) - (_upScroll.Width + 1);
                    tab.Width = _selectedTab.Width;
                    _upScroll.Y = _selectedTab.Y;
                    _dnScroll.Y = tab.Y;

                    if (selTabIndex + 1 != oldTabIndex)
                    {
                        oldSelectedTab.Width = DisplayRectangle.Width - 2;
                    }

                    tab = this[oldTabIndex + 1];

                    if (null != tab)
                    {
                        tab.Width = DisplayRectangle.Width - 2;
                        paintRect.Height = tab.Bottom - paintRect.Y;
                        oldItemArea.Height = (tab.Top - 1) - (_oldselectedTab.Bottom + 1);

                    }
                    else
                    {
                        oldItemArea.Height = (DisplayRectangle.Bottom) - ((_oldselectedTab.Bottom - 1) + _itemHeight);
                    }

                    tab = this[selTabIndex + 1];

                    if (tab.Y >= maxY)
                    {
                        oldItemArea.Height = 0;
                        bFinished = true;
                    }

                }

                selItemArea.X = _selectedTab.X;
                selItemArea.Y = _selectedTab.Bottom;
                selItemArea.Width = DisplayRectangle.Width - 2;

                oldItemArea.X = _oldselectedTab.X;
                oldItemArea.Y = _oldselectedTab.Bottom;
                oldItemArea.Width = DisplayRectangle.Width - 2;

                selItemArea.Height = (_dnScroll.Y - _selectedTab.Bottom) + 0;

                _oldselectedTab.ItemArea = oldItemArea;
                _selectedTab.ItemArea = selItemArea;

                if (selItemAreaBad)
                {
                    _selectedTab.UpdateItemRects(true, true, false);
                }
                else
                {
                    _selectedTab.DoItemLayout();
                }

                if (bFinished)
                {
                    if (null != _oldselectedTab.Control)
                    {
                        //_selectedTab.Control.TabIndex    = 2;
                        _oldselectedTab.Control.Visible = false;
                        this.Controls.Remove(_oldselectedTab.Control);
                    }

                    if (null != _selectedTab.Control)
                    {
                        _selectedTab.Control.TabIndex = 1;
                        _selectedTab.Control.Visible = true;
                        _selectedTab.Control.Focus();
                    }
                    else if (!Focused)
                    {
                        Focus();
                    }
                }

                _upScroll.Enabled = _selectedTab.CanScroll(ToolBoxScrollDirection.UP);
                _dnScroll.Enabled = _selectedTab.CanScroll(ToolBoxScrollDirection.DOWN);

                Invalidate(paintRect);
            }
            else
            {
                bFinished = true;
            }

            return bFinished;
        }

        private void DoLayout(bool bInitial, bool bRepaint)
        {
            DoLayout(bInitial, false, bRepaint);
        }

        private void DoLayout(bool bInitial, bool bUpdateItems, bool bRepaint)
        {
            ToolBoxTab tab1 = null;
            ToolBoxTab tab2 = null;
            Rectangle rect = Rectangle.Empty;
            Rectangle rcItem = Rectangle.Empty;

            bool bOK = true;
            bool bScrollUpSet = false;
            bool bScrollDnSet = false;
            int iLoop = 0;

            if (!Created)
            {
                return;
            }

            System.Diagnostics.Debug.WriteLine("ToolBox DoLayout called...");

            rect.Height = _tabHeight;
            rect.Width = DisplayRectangle.Width - 2;
            rect.X = 1;
            rect.Y = 1;

            if (_upScroll.Height != _tabHeight)
            {
                _upScroll.Height = _tabHeight;
            }

            if (_dnScroll.Height != _tabHeight)
            {
                _dnScroll.Height = _tabHeight;
            }

            _upScroll.Width = _tabHeight;
            _dnScroll.Width = _tabHeight;

            for (iLoop = 0; bOK && iLoop < _toolBoxTabs.Count; iLoop++)
            {
                if (!bInitial && (_tabHeight + (_toolBoxTabs.Count * rect.Height)) > DisplayRectangle.Height)
                {
                    bOK = false;
                    bScrollUpSet = true;
                    bScrollDnSet = true;
                }

                if (bOK)
                {
                    tab1 = _toolBoxTabs[iLoop];
                    tab1.Rectangle = rect;
                    tab1.ItemArea = Rectangle.Empty; //ATTN

                    if (null != tab2)
                    {
                        tab2 = null;
                        tab1.Width = tab1.Width - (_dnScroll.Width + 1);
                        _dnScroll.X = tab1.Right + 1;
                        _dnScroll.Y = tab1.Y;
                        bScrollDnSet = true;

                    }
                    else if (tab1.Selected)
                    {
                        int newY = 0;
                        tab1.Width = tab1.Width - (_upScroll.Width + 1);
                        _upScroll.X = tab1.Right + 1;
                        _upScroll.Y = tab1.Y;
                        tab2 = this[iLoop + 1];
                        bScrollUpSet = true;

                        if (null != tab2)
                        {
                            newY = (DisplayRectangle.Bottom - ((_tabHeight + _tabSpacing) * (_toolBoxTabs.Count - (iLoop))));
                            newY = (newY <= rect.Y + (_itemHeight + _itemSpacing)) ? rect.Y + (_itemHeight + _itemSpacing) : newY;
                            rect.Y = newY;
                        }
                        else
                        {
                            rect.Y += (_tabHeight + _tabSpacing + _itemSpacing);
                        }
                    }
                    rect.Y += _tabHeight + _tabSpacing;
                }
            }

            if (0 < _toolBoxTabs.Count)
            {

                // Scroll button positions
                if (!bScrollUpSet)
                {
                    _upScroll.X = DisplayRectangle.Right - (_upScroll.Rectangle.Width + 1);
                    _upScroll.Y = 1;
                }

                if (!bScrollDnSet)
                {
                    rect.Y = Math.Max(rect.Bottom, DisplayRectangle.Bottom);
                    _dnScroll.X = DisplayRectangle.Right - (_dnScroll.Rectangle.Width + 1);
                    _dnScroll.Y = rect.Y - (_tabHeight + _tabSpacing);
                }

                if (null != _selectedTab)
                {
                    rcItem.X = _selectedTab.X;
                    rcItem.Y = _selectedTab.Bottom;
                    rcItem.Width = DisplayRectangle.Width - 2;
                    rcItem.Height = (_dnScroll.Y - rcItem.Y) + 0;

                    _selectedTab.ItemArea = rcItem;
                }

            }

            if (null != _oldselectedTab && null != _oldselectedTab.Control)
            {
                _oldselectedTab.Control.Visible = false;
                this.Controls.Remove(_oldselectedTab.Control);
            }

            if (null != _selectedTab)
            {
                if (null != _selectedTab.Control)
                {
                    this.Controls.Add(_selectedTab.Control);
                    _selectedTab.Control.TabIndex = 1;

                    bUpdateItems = true;
                }

                if (bUpdateItems)
                {
                    _selectedTab.UpdateItemRects(false);
                }

                if (null != _selectedTab.Control)
                {
                    _selectedTab.Control.Visible = true;
                    _selectedTab.Control.Focus();
                }
                else if (!Focused)
                {
                    Focus();
                }

                //_selectedTab.DoItemLayout();
                _upScroll.Enabled = _selectedTab.CanScroll(ToolBoxScrollDirection.UP);
                _dnScroll.Enabled = _selectedTab.CanScroll(ToolBoxScrollDirection.DOWN);
            }

            if (bRepaint && Visible)
            {
                Invalidate();
            }
        }

        private void PaintBackground(Graphics g, Rectangle clipRect)
        {
            Brush brush = null;

            brush = new SolidBrush(BackColor);
            g.FillRectangle(brush, clipRect);
            brush.Dispose();

        }

        private void PaintScrollButtons(Graphics g, Rectangle clipRect)
        {
            if (0 < _toolBoxTabs.Count)
            {
                _upScroll.Paint(g, clipRect, this.Enabled);

                if (_dnScroll.Y >= _upScroll.Bottom)
                {
                    _dnScroll.Paint(g, clipRect, this.Enabled);
                }
            }
        }

        private bool IsHeightValid(int height, bool forLargeIcons)
        {
            return (height >= GetMinimumHeight(forLargeIcons));
        }

        private int GetMinimumHeight(bool forLargeIcons)
        {
            int minHeight = 0;

            minHeight = this.Font.Height + 4;

            if (forLargeIcons)
            {
                minHeight = Math.Max(minHeight, null != _largeImageList ? _largeImageList.ImageSize.Height : 0);
            }
            else
            {
                minHeight = Math.Max(minHeight, null != _smallImageList ? _smallImageList.ImageSize.Height : 0);
            }

            return minHeight;
        }

        private void LayoutTabs()
        {
            LayoutTabs(true);
        }

        private void LayoutTabs(bool redraw)
        {
            LayoutTabs(redraw, null);
        }

        private void LayoutTabs(bool redraw, ToolBoxTab skipTab)
        {
            int iLoop = 0;

            for (iLoop = 0; iLoop < _toolBoxTabs.Count; iLoop++)
            {
                if (_toolBoxTabs[iLoop] != skipTab)
                {
                    _toolBoxTabs[iLoop].UpdateItemRects(true, true, redraw);
                }
            }
        }

        private void LayoutNonSelectedTabs()
        {
            LayoutTabs(true, _selectedTab);
        }

        private void LayoutNonSelectedTabs(bool redraw)
        {
            LayoutTabs(redraw, _selectedTab);
        }

        private void VerifyDimensions(bool updateOriginals)
        {
            bool doTabLayout = false;
            bool doItemLayout = false;

            // First restore original dimensions.
            if (_tabHeight != _origTabHeight)
            {
                _tabHeight = _origTabHeight;
                doTabLayout = true;
            }

            if (_itemHeight != _origItemHeight)
            {
                _itemHeight = _origItemHeight;
                doItemLayout = true;
            }

            if (_largeItemSize != _origLargeItemSize)
            {
                _largeItemSize = _origLargeItemSize;
                doItemLayout = true;
            }

            if (_smallItemSize != _origSmallItemSize)
            {
                _smallItemSize = _origSmallItemSize;
                doItemLayout = true;
            }

            // Verify original dimensions with current font.
            if (!IsHeightValid(_tabHeight, false))
            {
                _tabHeight = GetMinimumHeight(false);
                doTabLayout = true;
            }

            if (!IsHeightValid(_itemHeight, false))
            {
                _itemHeight = GetMinimumHeight(false);
                doItemLayout = true;
            }

            if (!IsHeightValid(_largeItemSize.Height, true))
            {
                _largeItemSize.Height = GetMinimumHeight(true);
                doItemLayout = true;
            }

            if (!IsHeightValid(_smallItemSize.Height, false))
            {
                _smallItemSize.Height = GetMinimumHeight(false);
                doItemLayout = true;
            }

            // Do layout or item layout as needed.
            if (doTabLayout)
            {
                DoLayout(true, true, true);
            }
            if (doItemLayout)
            {
                LayoutNonSelectedTabs();
            }

            // Save the current values to original values if specified.
            if (updateOriginals)
            {
                _origTabHeight = _tabHeight;
                _origItemHeight = _itemHeight;
                _origSmallItemSize = _smallItemSize;
                _origLargeItemSize = _largeItemSize;
            }

        }

        private string ColorToHtmlString(Color c)
        {
            string color = null;

            if (c.IsNamedColor)
            {
                color = c.Name;
            }
            else
            {
                color = "#";

                if (c.R < 16) color += "0";
                color += Convert.ToString(c.R, 16);

                if (c.G < 16) color += "0";
                color += Convert.ToString(c.G, 16);

                if (c.B < 16) color += "0";
                color += Convert.ToString(c.B, 16);

            }

            return color;
        }

        private Color ColorFromHtmlString(string color, Color defColor)
        {
            Color c = defColor;
            int rgb = -1;

            try
            {
                if (null != color && 0 < color.Length)
                {
                    if (color.StartsWith("#"))
                    {
                        color = color.Remove(0, 1);
                        rgb = Convert.ToInt32(color, 16);
                        rgb = (int)(rgb & 0x00ffffff);
                        c = Color.FromArgb(0xff, ((rgb & 0xff0000) >> 16), ((rgb & 0x00ff00) >> 8), (rgb & 0x0000ff));
                    }
                    else
                    {
                        c = Color.FromName(color);
                    }
                }
            }
            catch
            {
                c = defColor;
            }

            return c;
        }

        private int SafeInt32FromString(string s, int defVal)
        {
            int retVal = defVal;

            try
            {
                retVal = Convert.ToInt32(s);
            }
            catch
            {
            }
            return retVal;
        }

        private bool SafeBoolFromString(string s, bool defVal)
        {
            bool retVal = defVal;

            try
            {
                retVal = Convert.ToBoolean(s);
            }
            catch
            {
            }
            return retVal;
        }

        private void HandleToolBoxTabDragOver(DragEventArgs e)
        {
            int index = -1;
            Point ptPos = Point.Empty;
            ToolBoxTab dragTab = null;

            ptPos.X = e.X;
            ptPos.Y = e.Y;
            ptPos = PointToClient(ptPos);
            index = HitTestTab(ptPos.X, ptPos.Y);

            if (-1 != index)
            {
                dragTab = this[index];
            }

            if (_dragItem == dragTab)
            {
                index = -1;
                dragTab = null;
            }

            if (null != dragTab && !dragTab.Movable)
            {
                index = -1;
                dragTab = null;
            }

            e.Effect = -1 != index ? DragDropEffects.Move : DragDropEffects.None;

            if (null != dragTab && _patBltItem != dragTab)
            {
                PatBltOnItem(dragTab);
            }
            else if (null == dragTab)
            {
                PatBltOnItem(null);
            }

            _dropItem = dragTab;

        }

        private void HandleToolBoxItemDragOver(DragEventArgs e)
        {
            int index = -1;
            Point ptPos = Point.Empty;
            ToolBoxItem dragItem = null;

            ptPos.X = e.X;
            ptPos.Y = e.Y;
            ptPos = PointToClient(ptPos);

            if (null != _selectedTab)
            {
                if (ptPos.X < _selectedTab.ItemArea.X + 4)
                {
                    ptPos.X = -100;
                    ptPos.Y = -100;
                }

                if (ptPos.X > _selectedTab.ItemArea.Right - 4)
                {
                    ptPos.X = -100;
                    ptPos.Y = -100;
                }

                index = _selectedTab.HitTestItem(ptPos.X, ptPos.Y);

                if (-1 != index)
                {
                    dragItem = _selectedTab[index];
                }

                if (_dragItem == dragItem)
                {
                    dragItem = null;
                }

                if (null != dragItem && !dragItem.Movable)
                {
                    dragItem = null;
                }

                e.Effect = null != dragItem ? DragDropEffects.Move : DragDropEffects.None;

                //System.Diagnostics.Debug.WriteLine(Environment.TickCount + " Drag item index " + index + " Item " + dragItem + " in " + ptPos);

                if (null != dragItem && _patBltItem != dragItem)
                {
                    PatBltOnItem(dragItem);
                }
                else if (null == dragItem)
                {
                    PatBltOnItem(null);
                }

                _dropItem = dragItem;
            }
        }

        private void HandleToolBoxTabDrop(DragEventArgs e)
        {
            ToolBoxTab dragTab = null;

            try
            {
                dragTab = (ToolBoxTab)e.Data.GetData(typeof(ToolBoxTab));
                SwapTabs(dragTab, (ToolBoxTab)_dropItem);
            }
            catch
            {
            }
        }

        private void HandleToolBoxItemDrop(DragEventArgs e)
        {
            ToolBoxItem dragItem = null;

            try
            {
                dragItem = (ToolBoxItem)e.Data.GetData(typeof(ToolBoxItem));
                _selectedTab.SwapItems(dragItem, (ToolBoxItem)_dropItem);
            }
            catch
            {
            }
        }

        private void SwitchTabs(bool shiftPressed)
        {
            int newSelIndex = -1;
            int curSelIndex = -1;
            bool doSwitch = true;

            try
            {
                if (null != _timer && _timer.Enabled)
                {
                    doSwitch = false;
                }

                if (doSwitch)
                {
                    curSelIndex = SelectedTabIndex;
                    newSelIndex = curSelIndex;
                    newSelIndex += shiftPressed ? -1 : +1;

                    if (curSelIndex != newSelIndex && 0 <= newSelIndex && newSelIndex < _toolBoxTabs.Count)
                    {
                        _toolBoxTabs[newSelIndex].Selected = true;
                    }
                }
            }
            catch
            {
            }
        }

        private XmlElement SerializeToolBoxItem(ToolBoxItem item, XmlDocument xmlDoc, string nodeName)
        {
            XmlElement itemElement = null;
            XmlElement element2 = null;

            // Create the node
            itemElement = xmlDoc.CreateElement(nodeName);

            // Caption
            element2 = xmlDoc.CreateElement(Xml_Caption_Node);
            if (null != item.Caption && 0 < item.Caption.Length)
            {
                element2.AppendChild(xmlDoc.CreateTextNode(item.Caption));
            }
            itemElement.AppendChild(element2);

            // Image index
            element2 = xmlDoc.CreateElement(Xml_ImageIdxs_Node);
            element2.SetAttribute(Xml_SmallImgIdx_Attr, item.SmallImageIndex.ToString());
            element2.SetAttribute(Xml_LargeImgIdx_Attr, item.SmallImageIndex.ToString());
            itemElement.AppendChild(element2);

            // Tool tip
            element2 = xmlDoc.CreateElement(Xml_ToolTip_Node);
            if (null != item.ToolTip && 0 < item.ToolTip.Length)
            {
                element2.AppendChild(xmlDoc.CreateTextNode(item.ToolTip));
            }
            itemElement.AppendChild(element2);

            // Enabled
            itemElement.SetAttribute(Xml_Enabled_Attr, item.Enabled.ToString().ToLower());

            // Movable
            itemElement.SetAttribute(Xml_Movable_Attr, item.Movable.ToString().ToLower());

            // Renamable
            itemElement.SetAttribute(Xml_Renamable_Attr, item.Renamable.ToString().ToLower());

            // Deletable
            itemElement.SetAttribute(Xml_Deletable_Attr, item.Deletable.ToString().ToLower());

            // Allow drag
            itemElement.SetAttribute(Xml_AllowDrag_Attr, item.AllowDrag.ToString().ToLower());

            return itemElement;
        }

        private void DeSerializeToolBoxItem(ToolBoxItem item, XmlElement itemNode)
        {
            XmlElement element2 = null;
            string tempString = null;

            // Caption
            element2 = (XmlElement)itemNode.SelectSingleNode(Xml_Caption_Node);
            tempString = element2.InnerText;

            if (null != tempString && 0 < tempString.Length)
            {
                item.Caption = tempString;
            }

            // Tool tip
            element2 = (XmlElement)itemNode.SelectSingleNode(Xml_ToolTip_Node);
            tempString = element2.InnerText.Replace("\t", "").Trim();
            //tempString        = tempString.Replace("\t","");

            if (null != tempString && 0 < tempString.Length)
            {
                item.ToolTip = tempString;
            }

            // Image indices
            element2 = (XmlElement)itemNode.SelectSingleNode(Xml_ImageIdxs_Node);
            item.SmallImageIndex = SafeInt32FromString(element2.GetAttribute(Xml_SmallImgIdx_Attr), -1);
            item.LargeImageIndex = SafeInt32FromString(element2.GetAttribute(Xml_LargeImgIdx_Attr), -1);

            // Movable, Renamable, Deletable, Allow Drag
            item.Movable = SafeBoolFromString(itemNode.GetAttribute(Xml_Movable_Attr), true);
            item.Renamable = SafeBoolFromString(itemNode.GetAttribute(Xml_Renamable_Attr), true);
            item.Deletable = SafeBoolFromString(itemNode.GetAttribute(Xml_Deletable_Attr), true);
            item.AllowDrag = SafeBoolFromString(itemNode.GetAttribute(Xml_AllowDrag_Attr), true);

        }

        #endregion //Private Methods

        #region General Overrides

        protected override void Dispose(bool disposing)
        {
            int iLoop;
            IDisposable dispObject;

            base.Dispose(disposing);

            if (disposing)
            {
                foreach (ToolBoxTab tab in _toolBoxTabs)
                {
                    for (iLoop = 0; iLoop < tab.ItemCount; iLoop++)
                    {
                        dispObject = tab[iLoop].Object as IDisposable;

                        if (null != dispObject)
                        {
                            dispObject.Dispose();
                        }

                        dispObject = null;
                    }
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            RefreshTabs();
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            VerifyDimensions(false);
        }

        protected override bool IsInputKey(Keys keyData)
        {
            /*bool isInput = false;

            switch(keyData)
            {
                case Keys.Down:
                case Keys.Up:
                case Keys.Left:
                case Keys.Right:
                case Keys.PageDown:
                case Keys.PageUp:
                case Keys.Home:
                case Keys.End:
                case Keys.F2:
                case Keys.Tab:
                case Keys.ShiftKey:
                    isInput = true;
                    break;
                default:
                    isInput = false;
                    break;
            }

            return isInput;*/

            return true;
        }

        private bool moveMsgLocked;

        protected override void OnKeyDown(KeyEventArgs e)
        {
            bool ctrlPressed = false;

            ctrlPressed = Keys.Control == (ModifierKeys & Keys.Control);

            if (null != _selectedTab)
            {
                if (Keys.F2 == e.KeyCode)
                {
                    if (!ctrlPressed && null != _selectedTab.SelectedItem)
                    {
                        _selectedTab.SelectedItem.Rename();
                    }
                }
                else
                {
                    moveMsgLocked = Keys.Enter == e.KeyCode || Keys.Space == e.KeyCode;
                    _selectedTab.HandleKeyDown(e);
                }
                try
                {
                    if (null != ItemKeyDown)
                    {
                        ItemKeyDown(_selectedTab.SelectedItem, e);
                    }
                }
                catch
                {
                }
            }

            base.OnKeyDown(e);

        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            try
            {
                if (null != _selectedTab && null != ItemKeyPress)
                {
                    ItemKeyPress(_selectedTab.SelectedItem, e);
                }
            }
            catch
            {
            }

            base.OnKeyPress(e);

        }

        protected override void OnKeyUp(KeyEventArgs e)
        {

            try
            {
                moveMsgLocked = false;

                if (null != _selectedTab)
                {
                    _selectedTab.HandleKeyUp(e);

                    if (null != ItemKeyUp)
                    {
                        ItemKeyUp(_selectedTab.SelectedItem, e);
                    }
                }
            }
            catch
            {
            }

            base.OnKeyUp(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            moveMsgLocked = false;

            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            if (moveMsgLocked && null != _selectedTab)
            {
                _selectedTab.HandleKeyUp(new KeyEventArgs(Keys.Enter));
            }

            moveMsgLocked = false;

            base.OnLostFocus(e);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool processed = false;
            bool ctrlPressed = false;

            ctrlPressed = Keys.Control == (Keys.Control & keyData);

            if (ctrlPressed && null != _selectedTab)
            {
                if (Keys.Tab == (Keys.Tab & keyData))
                {
                    SwitchTabs(Keys.Shift == (Keys.Shift & keyData));
                    processed = true;
                }
                else if (Keys.F2 == (Keys.F2 & keyData))
                {
                    _selectedTab.Rename();
                    processed = true;
                }
            }

            if (!processed)
            {
                processed = base.ProcessCmdKey(ref msg, keyData);
            }

            return processed;
        }


        #endregion //General Overrides

        #region Sizing Overrides
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            DoLayout(false, false, false);

            foreach (ToolBoxTab tab in _toolBoxTabs)
            {
                tab.UpdateItemRects(ToolBoxViewMode.LIST != tab.View, true, false);
            }

            if (null != _selectedTab)
            {
                _upScroll.Enabled = _selectedTab.CanScroll(ToolBoxScrollDirection.UP);
                _dnScroll.Enabled = _selectedTab.CanScroll(ToolBoxScrollDirection.DOWN);
            }

            Invalidate();
        }

        #endregion //Sizing Overrides

        #region Paint Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle r = e.ClipRectangle;


            PaintBackground(g, r);

            //System.Diagnostics.Debug.WriteLine("Paint clip rect " + r);
            //g.FillRectangle(new SolidBrush(GetRandomColor()),r);
            PaintScrollButtons(g, r);

            base.OnPaint(e);
        }

        protected Color GetRandomColor()
        {
            Random r = new Random();

            return Color.FromArgb(r.Next(100, 255), r.Next(100, 255), r.Next(100, 255));
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
        }

        #endregion //Paint Overrides

        #region Mouse Overrides

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (moveMsgLocked)
            {
                return;
            }

            if (!LayoutTimerActive && !_textBox.Visible)
            {
                //UpdateToolTip("");
                if (_upScroll.HitTest(e.X, e.Y))
                {
                    if (null != _selectedTab)
                    {
                        _selectedTab.CancelHotItemHover();
                        _selectedTab.CancelHover();
                    }
                    UpdateToolTip(_upScroll);
                }
                else if (_dnScroll.HitTest(e.X, e.Y))
                {
                    if (null != _selectedTab)
                    {
                        _selectedTab.CancelHotItemHover();
                        _selectedTab.CancelHover();
                    }
                    UpdateToolTip(_dnScroll);
                }
                else
                {
                    //UpdateToolTip("");
                    if (!_mouseMoveFreezed)
                    {
                        base.OnMouseMove(e);
                    }
                }
            }
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            bool oldUpScrollState = _upScroll.Enabled;
            bool oldDnScrollState = _dnScroll.Enabled;

            if (moveMsgLocked)
            {
                return;
            }

            UpdateItemFromTextBox();

            if (!LayoutTimerActive && null != _selectedTab)
            {
                if (0 < e.Delta)
                {
                    _selectedTab.ScrollItems(ToolBoxScrollDirection.UP);
                    _upScroll.Enabled = _selectedTab.CanScroll(ToolBoxScrollDirection.UP);
                    _dnScroll.Enabled = _selectedTab.CanScroll(ToolBoxScrollDirection.DOWN);
                }
                else
                {
                    _selectedTab.ScrollItems(ToolBoxScrollDirection.DOWN);
                    _upScroll.Enabled = _selectedTab.CanScroll(ToolBoxScrollDirection.UP);
                    _dnScroll.Enabled = _selectedTab.CanScroll(ToolBoxScrollDirection.DOWN);
                }

                if (_dnScroll.Enabled != oldDnScrollState)
                {
                    Invalidate(_dnScroll.Rectangle);
                }

                if (_upScroll.Enabled != oldUpScrollState)
                {
                    Invalidate(_upScroll.Rectangle);
                }
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            bool bOldState;

            if (moveMsgLocked)
            {
                return;
            }

            if (LayoutTimerActive)
            {
                return;
            }

            if (_textBox.Visible && !EndRenameItem())
            {
                //_textBox.Visible = false;
                return;
            }

            if (!Focused)
            {
                Focus();
            }

            System.Diagnostics.Debug.WriteLine("Control is Focused ? " + Focused);

            if (_upScroll.HitTest(e.X, e.Y))
            {
                if (_upScroll.Enabled)
                {
                    bOldState = _dnScroll.Enabled;
                    _upScroll.MouseDown = true;

                    _selectedTab.ScrollItems(ToolBoxScrollDirection.UP);

                    _upScroll.Enabled = _selectedTab.CanScroll(ToolBoxScrollDirection.UP);
                    _dnScroll.Enabled = _selectedTab.CanScroll(ToolBoxScrollDirection.DOWN);

                    if (bOldState != _dnScroll.Enabled)
                    {
                        _dnScroll.MouseDown = false;
                        Invalidate(_dnScroll.Rectangle);
                    }
                    Invalidate(_upScroll.Rectangle);

                    StopTimer();
                    CreateScrollTimer(ToolBoxScrollDirection.UP);
                }
            }
            else if (_dnScroll.HitTest(e.X, e.Y))
            {
                if (_dnScroll.Enabled)
                {
                    bOldState = _upScroll.Enabled;
                    _dnScroll.MouseDown = true;

                    _selectedTab.ScrollItems(ToolBoxScrollDirection.DOWN);

                    _upScroll.Enabled = _selectedTab.CanScroll(ToolBoxScrollDirection.UP);
                    _dnScroll.Enabled = _selectedTab.CanScroll(ToolBoxScrollDirection.DOWN);

                    if (!_dnScroll.Enabled)
                    {
                        //_dnScroll.MouseDown = false;
                    }

                    if (bOldState != _upScroll.Enabled)
                    {
                        _upScroll.MouseDown = false;
                        Invalidate(_upScroll.Rectangle);
                    }
                    Invalidate(_dnScroll.Rectangle);

                    StopTimer();
                    CreateScrollTimer(ToolBoxScrollDirection.DOWN);
                }
            }
            else
            {
                base.OnMouseDown(e);
            }

        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            Rectangle rcPaint = Rectangle.Empty;

            if (moveMsgLocked)
            {
                return;
            }

            if (_upScroll.MouseDown)
            {
                StopTimer();
                _upScroll.MouseDown = false;
                rcPaint = Rectangle.Union(rcPaint, _upScroll.Rectangle);
            }

            if (_dnScroll.MouseDown)
            {
                StopTimer();
                _dnScroll.MouseDown = false;
                rcPaint = Rectangle.Union(rcPaint, _dnScroll.Rectangle);
            }

            if (!_upScroll.HitTest(e.X, e.Y) && !_dnScroll.HitTest(e.X, e.Y))
            {
                base.OnMouseUp(e);
            }

            if (!rcPaint.IsEmpty)
            {
                Invalidate(rcPaint);
            }
        }

        #endregion //Mouse Overrides

        #region Drag Drop

        protected override void OnDragEnter(DragEventArgs e)
        {
            if (_allowDragSwap)
            {
                if (e.Data.GetDataPresent(typeof(ToolBoxItem)))
                {
                    e.Effect = DragDropEffects.Move;
                }
            }
            base.OnDragEnter(e);
        }

        protected override void OnDragOver(DragEventArgs e)
        {
            if (_allowDragSwap)
            {
                if (e.Data.GetDataPresent(typeof(ToolBoxTab)))
                {
                    HandleToolBoxTabDragOver(e);
                }
                else if (e.Data.GetDataPresent(typeof(ToolBoxItem)))
                {
                    HandleToolBoxItemDragOver(e);
                }
            }
            base.OnDragOver(e);
        }

        protected override void OnDragLeave(EventArgs e)
        {
            if (_allowDragSwap)
            {
                PatBltOnItem(_patBltItem);
                _patBltItem = null;
            }
            base.OnDragLeave(e);
        }


        protected override void OnDragDrop(DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ToolBoxTab)))
            {
                HandleToolBoxTabDrop(e);
            }
            else if (e.Data.GetDataPresent(typeof(ToolBoxItem)))
            {
                HandleToolBoxItemDrop(e);
            }

            _dropItem = null;

            base.OnDragDrop(e);

        }

        #endregion //Drag Drop

        #region Internal Events

        private void OnTimer_UpScrollElapsed(object sender, EventArgs e)
        {
            HandleScrollTimerElapsed(ToolBoxScrollDirection.UP, _selectedTab, _upScroll);
        }

        private void OnTimer_DnScrollElapsed(object sender, EventArgs e)
        {
            HandleScrollTimerElapsed(ToolBoxScrollDirection.DOWN, _selectedTab, _dnScroll);
        }

        private void OnTimer_LayoutElapsed(object sender, EventArgs e)
        {
            try
            {
                if (DoTimedLayout(_oldselectedTab))
                {
                    _timer.Stop();
                    _timer.Dispose();
                    _timer = null;
                    if (null != _selectedTab)
                    {
                        if (null != _layoutFinished)
                        {
                            _layoutFinished();
                            _layoutFinished = null;
                        }
                        else
                        {
                            _selectedTab.DoItemLayout();
                        }
                    }
                }
            }
            catch
            {
                _timer.Stop();
                _timer.Dispose();
                _timer = null;
                DoLayout(true, true);
            }
        }

        private void OnTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode || Keys.Escape == e.KeyCode)
            {
                EndRenameItem(false, Keys.Escape == e.KeyCode);
            }
        }

        private void OnTextBox_LostFocus(object sender, EventArgs e)
        {
            if (_textBox.Visible && !_textBox.Focused)
            {
                EndRenameItem(true, false);
            }
        }

        #endregion //Internal Events

        #region Serialization

        /* 
         * XmlSerializer is not used for the moment, as ToolBox is subclassed from System.Windows.UserControl,
         * and it will throw InvalidOperationException and stuff while using XmlSerializer as below
         *
         * "Cannot serialize member System.ComponentModel.Component.Site of type System.ComponentModel.ISite 
         *  because it is an interface."
         *
         * If there is a work arround, you can modify the code and use it (and let me know, if you don't mind).
         * 
         * In the following methods for serializing/deserializing, you can use OnSerializeObject and 
         * OnDeSerializeObject events to save/load the object associated with a tab/tabItem.
         */

        public bool XmlSerialize(string file)
        {
            bool serialized = false;
            XmlDocument xmlDoc = null;

            try
            {
                xmlDoc = new XmlDocument();
                serialized = XmlSerialize(xmlDoc);

                xmlDoc.Save(file);
            }
            catch
            {
            }

            return serialized;
        }

        public bool XmlSerialize(XmlDocument xmlDoc)
        {
            return XmlSerialize((XmlNode)xmlDoc);
        }

        public bool XmlSerialize(XmlNode xmlNode)
        {
            bool serialized = false;
            XmlDocument xmlDoc = null;
            XmlElement elementRoot = null;
            XmlElement element0 = null;
            XmlElement element1 = null;
            XmlElement element2 = null;
            XmlElement tabElement = null;
            XmlElement itemElement = null;
            ToolBoxTab tab = null;
            ToolBoxItem item = null;
            int iLoop1 = 0;
            int iLoop2 = 0;

            try
            {
                if (xmlNode is XmlDocument)
                {
                    xmlDoc = (XmlDocument)xmlNode;
                }
                else
                {
                    xmlDoc = xmlNode.OwnerDocument;
                }
                //Main toolbox node and its properties.
                elementRoot = xmlDoc.CreateElement(Xml_Root_Node);
                elementRoot.SetAttribute(Xml_Version_Attr, "1");

                element0 = elementRoot;

                xmlNode.AppendChild(element0);

                // Toolbox main config
                element1 = xmlDoc.CreateElement(Xml_Config_Node);
                element0.AppendChild(element1);

                element0 = element1;
                element2 = element1;

                // Tab height
                element1 = xmlDoc.CreateElement(Xml_TabHeight_Node);
                element1.AppendChild(xmlDoc.CreateTextNode(_tabHeight.ToString()));
                element0.AppendChild(element1);

                // Item height
                element1 = xmlDoc.CreateElement(Xml_ItemHeight_Node);
                element1.AppendChild(xmlDoc.CreateTextNode(_itemHeight.ToString()));
                element0.AppendChild(element1);

                // Tab spacing
                element1 = xmlDoc.CreateElement(Xml_TabSpacing_Node);
                element1.AppendChild(xmlDoc.CreateTextNode(_tabSpacing.ToString()));
                element0.AppendChild(element1);

                // Item spacing
                element1 = xmlDoc.CreateElement(Xml_ItemSpacing_Node);
                element1.AppendChild(xmlDoc.CreateTextNode(_itemSpacing.ToString()));
                element0.AppendChild(element1);

                // Layout delay
                element1 = xmlDoc.CreateElement(Xml_LayoutDelay_Node);
                element1.AppendChild(xmlDoc.CreateTextNode(_layoutDelay.ToString()));
                element0.AppendChild(element1);

                // Scroll delay
                element1 = xmlDoc.CreateElement(Xml_ScrollDelay_Node);
                element1.AppendChild(xmlDoc.CreateTextNode(_scrollDelay.ToString()));
                element0.AppendChild(element1);

                // Scroll wait
                element1 = xmlDoc.CreateElement(Xml_ScrollWait_Node);
                element1.AppendChild(xmlDoc.CreateTextNode(_scrollWait.ToString()));
                element0.AppendChild(element1);

                // Background color
                element1 = xmlDoc.CreateElement(Xml_BgColor_Node);
                if (!BackColor.IsEmpty)
                {
                    element1.AppendChild(xmlDoc.CreateTextNode(ColorToHtmlString(BackColor)));
                }
                element0.AppendChild(element1);

                // Item background color
                element1 = xmlDoc.CreateElement(Xml_ItemBgColor_Node);
                if (!_itemBgColour.IsEmpty)
                {
                    element1.AppendChild(xmlDoc.CreateTextNode(ColorToHtmlString(_itemBgColour)));
                }
                element0.AppendChild(element1);

                // Item border color
                element1 = xmlDoc.CreateElement(Xml_ItemBorderColor_Node);
                if (!_itemBorderColour.IsEmpty)
                {
                    element1.AppendChild(xmlDoc.CreateTextNode(ColorToHtmlString(_itemBorderColour)));
                }
                element0.AppendChild(element1);

                // Normal item color
                element1 = xmlDoc.CreateElement(Xml_NormItemColor_Node);
                element1.AppendChild(xmlDoc.CreateTextNode(ColorToHtmlString(_itemNormalColour)));
                element0.AppendChild(element1);

                // Selected item color
                element1 = xmlDoc.CreateElement(Xml_SelItemColor_Node);
                element1.AppendChild(xmlDoc.CreateTextNode(ColorToHtmlString(_selectedItemColour)));
                element0.AppendChild(element1);

                // Hover item color
                element1 = xmlDoc.CreateElement(Xml_HoverItemColor_Node);
                element1.AppendChild(xmlDoc.CreateTextNode(ColorToHtmlString(_itemHoverColour)));
                element0.AppendChild(element1);

                // Normal item text color
                element1 = xmlDoc.CreateElement(Xml_NormItemTxtColor_Node);
                if (!_itemTxtNormalColour.IsEmpty)
                {
                    element1.AppendChild(xmlDoc.CreateTextNode(ColorToHtmlString(_itemTxtNormalColour)));
                }
                element0.AppendChild(element1);

                // Selected item text color
                element1 = xmlDoc.CreateElement(Xml_SelItemTxtColor_Node);
                if (!_itemTxtSelectColour.IsEmpty)
                {
                    element1.AppendChild(xmlDoc.CreateTextNode(ColorToHtmlString(_itemTxtSelectColour)));
                }
                element0.AppendChild(element1);

                // Hover item text color
                element1 = xmlDoc.CreateElement(Xml_HoverItemTxtColor_Node);
                if (!_itemTxtHoverColor.IsEmpty)
                {
                    element1.AppendChild(xmlDoc.CreateTextNode(ColorToHtmlString(_itemTxtHoverColor)));
                }
                element0.AppendChild(element1);

                // Normal tab text color
                element1 = xmlDoc.CreateElement(Xml_NormTabTxtColor_Node);
                if (!_tabTxtNormalColour.IsEmpty)
                {
                    element1.AppendChild(xmlDoc.CreateTextNode(ColorToHtmlString(_tabTxtNormalColour)));
                }
                element0.AppendChild(element1);

                // Selected tab text color
                element1 = xmlDoc.CreateElement(Xml_SelTabTxtColor_Node);
                if (!_tabTxtSelectColour.IsEmpty)
                {
                    element1.AppendChild(xmlDoc.CreateTextNode(ColorToHtmlString(_tabTxtSelectColour)));
                }
                element0.AppendChild(element1);

                // Hover tab text color
                element1 = xmlDoc.CreateElement(Xml_HoverTabTxtColor_Node);
                if (!_tabTxtHoverColour.IsEmpty)
                {
                    element1.AppendChild(xmlDoc.CreateTextNode(ColorToHtmlString(_tabTxtHoverColour)));
                }
                element0.AppendChild(element1);

                // "Select All text while renaming" flag
                element1 = xmlDoc.CreateElement(Xml_SelAllTxtInRename_Node);
                element1.AppendChild(xmlDoc.CreateTextNode(_selAllTextInRename.ToString().ToLower()));
                element0.AppendChild(element1);

                // "Show only one item per row" flag
                element1 = xmlDoc.CreateElement(Xml_ShowOneItemPerRow_Node);
                element1.AppendChild(xmlDoc.CreateTextNode(_onlyOneItemPerRow.ToString().ToLower()));
                element0.AppendChild(element1);

                // "Allow swapping by drag drop" flag
                element1 = xmlDoc.CreateElement(Xml_AllowDragSwap_Node);
                element1.AppendChild(xmlDoc.CreateTextNode(_allowDragSwap.ToString().ToLower()));
                element0.AppendChild(element1);

                // "use item color in rename" flag
                element1 = xmlDoc.CreateElement(Xml_UseItemClrInRen_Node);
                element1.AppendChild(xmlDoc.CreateTextNode(_useItemClrInRename.ToString().ToLower()));
                element0.AppendChild(element1);

                // Large item size
                element1 = xmlDoc.CreateElement(Xml_LargeItemSize_Node);
                element1.SetAttribute(Xml_Width_Attr, _largeItemSize.Width.ToString());
                element1.SetAttribute(Xml_Height_Attr, _largeItemSize.Height.ToString());
                element0.AppendChild(element1);

                // Small item size
                element1 = xmlDoc.CreateElement(Xml_SmallItemSize_Node);
                element1.SetAttribute(Xml_Width_Attr, _smallItemSize.Width.ToString());
                element1.SetAttribute(Xml_Height_Attr, _smallItemSize.Height.ToString());
                element0.AppendChild(element1);

                // Scroll buttons
                element1 = xmlDoc.CreateElement(Xml_Scrolls_Node);
                element0.AppendChild(element1);

                //Up Scroll
                itemElement = xmlDoc.CreateElement(_upScroll.ScrollDirection.ToString());
                itemElement.SetAttribute(Xml_Enabled_Attr, _upScroll.Enabled.ToString().ToLower());
                if (0 < _upScroll.ToolTip.Length)
                {
                    element2 = xmlDoc.CreateElement(Xml_ToolTip_Node);
                    element2.AppendChild(xmlDoc.CreateTextNode(_upScroll.ToolTip));
                    itemElement.AppendChild(element2);
                }
                element1.AppendChild(itemElement);

                //Down Scroll
                itemElement = xmlDoc.CreateElement(_dnScroll.ScrollDirection.ToString());
                itemElement.SetAttribute(Xml_Enabled_Attr, _dnScroll.Enabled.ToString().ToLower());
                if (0 < _dnScroll.ToolTip.Length)
                {
                    element2 = xmlDoc.CreateElement(Xml_ToolTip_Node);
                    element2.AppendChild(xmlDoc.CreateTextNode(_dnScroll.ToolTip));
                    itemElement.AppendChild(element2);
                }

                element1.AppendChild(itemElement);

                // Back to root node.
                element0 = elementRoot;

                //Tabs
                element1 = xmlDoc.CreateElement(Xml_Tabs_Node);
                element0.AppendChild(element1);

                element1.SetAttribute(Xml_SelTabIdx_Attr, _toolBoxTabs.IndexOf(_selectedTab).ToString());

                for (iLoop1 = 0; iLoop1 < _toolBoxTabs.Count; iLoop1++)
                {
                    tab = this[iLoop1];

                    // Create the node
                    tabElement = SerializeToolBoxItem(tab, xmlDoc, Xml_Tab_Node);

                    //View Type
                    tabElement.SetAttribute(Xml_ViewMode_Attr, tab.View.ToString().ToLower());

                    // Item spacing
                    if (0 < tab.ItemSpacing)
                    {
                        tabElement.SetAttribute(Xml_ItemSpacing_Attr, tab.ItemSpacing.ToString());
                    }

                    // One item per row
                    if (tab.ShowOnlyOneItemPerRow)
                    {
                        tabElement.SetAttribute(Xml_OneItemPerRow_Attr, tab.ShowOnlyOneItemPerRow.ToString().ToLower());
                    }

                    // Item bg color
                    if (!tab.ItemBackgroundColour.IsEmpty)
                    {
                        tabElement.SetAttribute(Xml_ItemBgClr_Attr, ColorToHtmlString(tab.ItemBackgroundColour));
                    }

                    //Item border color
                    if (!tab.ItemBorderColour.IsEmpty)
                    {
                        tabElement.SetAttribute(Xml_ItemBorderClr_Attr, ColorToHtmlString(tab.ItemBorderColour));
                    }

                    //Item normal color
                    if (!tab.ItemNormalColour.IsEmpty)
                    {
                        tabElement.SetAttribute(Xml_ItemNormClr_Attr, ColorToHtmlString(tab.ItemNormalColour));
                    }

                    //Item selected color
                    if (!tab.ItemSelectedColour.IsEmpty)
                    {
                        tabElement.SetAttribute(Xml_ItemSelClr_Attr, ColorToHtmlString(tab.ItemSelectedColour));
                    }

                    //Item hover color
                    if (!tab.ItemHoverColour.IsEmpty)
                    {
                        tabElement.SetAttribute(Xml_ItemHoverClr_Attr, ColorToHtmlString(tab.ItemHoverColour));
                    }

                    element1.AppendChild(tabElement);

                    try
                    {
                        // Invoke serialize event (if any) to serialize the object for this tab.
                        if (null != OnSerializeObject)
                        {
                            OnSerializeObject(tab, new ToolBoxXmlSerializationEventArgs(tab.Object, tabElement, false));
                        }
                    }
                    catch
                    {
                    }

                    // Tab items
                    element0 = xmlDoc.CreateElement(Xml_TabItems_Node);
                    element0.SetAttribute(Xml_SelItemIdx_Attr, tab.SelectedItemIndex.ToString());

                    tabElement.AppendChild(element0);

                    for (iLoop2 = 0; iLoop2 < tab.ItemCount; iLoop2++)
                    {
                        item = tab[iLoop2];
                        itemElement = SerializeToolBoxItem(item, xmlDoc, Xml_TabItem_Node);

                        try
                        {
                            // Invoke serialize event (if any) to serialize the object for this tabItem.
                            if (null != OnSerializeObject)
                            {
                                OnSerializeObject(item, new ToolBoxXmlSerializationEventArgs(item.Object, itemElement, false));
                            }
                        }
                        catch
                        {
                        }

                        element0.AppendChild(itemElement);
                    }
                }

                serialized = true;
            }
            catch
            {
                serialized = false;
            }

            return serialized;
        }

        public bool XmlDeSerialize(string file)
        {
            bool deSerialized = false;
            XmlDocument xmlDoc = null;

            try
            {
                xmlDoc = new XmlDocument();
                xmlDoc.Load(file);

                deSerialized = XmlDeSerialize(xmlDoc.DocumentElement);
            }
            catch
            {
            }

            return deSerialized;
        }

        public bool XmlDeSerialize(XmlElement element)
        {
            bool deSerialized = false;
            string tempString = null;
            XmlElement element0 = null;
            XmlElement element1 = null;
            XmlElement element2 = null;
            XmlElement tabElement = null;
            XmlElement itemElement = null;
            XmlNodeList tabNodes = null;
            XmlNodeList itemNodes = null;
            ToolBoxTab tab = null;
            ToolBoxItem tabItem = null;
            ToolBoxXmlSerializationEventArgs evtArgs = null;

            try
            {
                _isLoading = true;

                if (element.Name != Xml_Root_Node)
                {
                    element = (XmlElement)element.SelectSingleNode(Xml_Root_Node);
                }

                // Config
                element0 = (XmlElement)element.SelectSingleNode(Xml_Config_Node);

                // Tab height
                element1 = (XmlElement)element0.SelectSingleNode(Xml_TabHeight_Node);
                _tabHeight = SafeInt32FromString(element1.InnerText, 18);

                // Item height
                element1 = (XmlElement)element0.SelectSingleNode(Xml_ItemHeight_Node);
                _itemHeight = SafeInt32FromString(element1.InnerText, 20);

                // Tab spacing
                element1 = (XmlElement)element0.SelectSingleNode(Xml_TabSpacing_Node);
                _tabSpacing = SafeInt32FromString(element1.InnerText, 1);

                // Item spacing
                element1 = (XmlElement)element0.SelectSingleNode(Xml_ItemSpacing_Node);
                _itemSpacing = SafeInt32FromString(element1.InnerText, 1);

                // Layout delay
                element1 = (XmlElement)element0.SelectSingleNode(Xml_LayoutDelay_Node);
                _layoutDelay = SafeInt32FromString(element1.InnerText, 10);

                // Scroll delay
                element1 = (XmlElement)element0.SelectSingleNode(Xml_ScrollDelay_Node);
                _scrollDelay = SafeInt32FromString(element1.InnerText, 60);

                // Scroll wait
                element1 = (XmlElement)element0.SelectSingleNode(Xml_ScrollWait_Node);
                _scrollWait = SafeInt32FromString(element1.InnerText, 500);

                // Background color
                element1 = (XmlElement)element0.SelectSingleNode(Xml_BgColor_Node);
                BackColor = ColorFromHtmlString(element1.InnerText, BackColor);

                // Item background color
                element1 = (XmlElement)element0.SelectSingleNode(Xml_ItemBgColor_Node);
                _itemBgColour = ColorFromHtmlString(element1.InnerText, Color.Empty);

                // Item border color
                element1 = (XmlElement)element0.SelectSingleNode(Xml_ItemBorderColor_Node);
                _itemBorderColour = ColorFromHtmlString(element1.InnerText, Color.Empty);

                // Normal item color
                element1 = (XmlElement)element0.SelectSingleNode(Xml_NormItemColor_Node);
                _itemNormalColour = ColorFromHtmlString(element1.InnerText, SystemColors.Control);

                // Selected item color
                element1 = (XmlElement)element0.SelectSingleNode(Xml_SelItemColor_Node);
                _selectedItemColour = ColorFromHtmlString(element1.InnerText, Color.White);

                // Hover item color
                element1 = (XmlElement)element0.SelectSingleNode(Xml_HoverItemColor_Node);
                _itemHoverColour = ColorFromHtmlString(element1.InnerText, SystemColors.Control);

                // Normal item text color
                element1 = (XmlElement)element0.SelectSingleNode(Xml_NormItemTxtColor_Node);
                _itemTxtNormalColour = ColorFromHtmlString(element1.InnerText, Color.Empty);

                // Selected item text color
                element1 = (XmlElement)element0.SelectSingleNode(Xml_SelItemTxtColor_Node);
                _itemTxtSelectColour = ColorFromHtmlString(element1.InnerText, Color.Empty);

                // Hover item text color
                element1 = (XmlElement)element0.SelectSingleNode(Xml_HoverItemTxtColor_Node);
                _itemTxtHoverColor = ColorFromHtmlString(element1.InnerText, Color.Empty);

                // Normal tab text color
                element1 = (XmlElement)element0.SelectSingleNode(Xml_NormTabTxtColor_Node);
                _tabTxtNormalColour = ColorFromHtmlString(element1.InnerText, Color.Empty);

                // Selected tab text color
                element1 = (XmlElement)element0.SelectSingleNode(Xml_SelTabTxtColor_Node);
                _tabTxtSelectColour = ColorFromHtmlString(element1.InnerText, Color.Empty);

                // Hover tab text color
                element1 = (XmlElement)element0.SelectSingleNode(Xml_HoverTabTxtColor_Node);
                _tabTxtHoverColour = ColorFromHtmlString(element1.InnerText, Color.Empty);

                // "Show only one item per row" flag
                element1 = (XmlElement)element0.SelectSingleNode(Xml_ShowOneItemPerRow_Node);
                _onlyOneItemPerRow = SafeBoolFromString(element1.InnerText, false);

                // "Select All text while renaming" flag
                element1 = (XmlElement)element0.SelectSingleNode(Xml_SelAllTxtInRename_Node);
                _selAllTextInRename = SafeBoolFromString(element1.InnerText, true);

                // "Allow swapping by drag drop" flag
                element1 = (XmlElement)element0.SelectSingleNode(Xml_AllowDragSwap_Node);
                _allowDragSwap = SafeBoolFromString(element1.InnerText, true);

                // "use item color in rename" flag
                element1 = (XmlElement)element0.SelectSingleNode(Xml_UseItemClrInRen_Node);
                _useItemClrInRename = SafeBoolFromString(element1.InnerText, true);

                // Large item size
                element1 = (XmlElement)element0.SelectSingleNode(Xml_LargeItemSize_Node);
                _largeItemSize.Width = SafeInt32FromString(element1.GetAttribute(Xml_Width_Attr), 64);
                _largeItemSize.Height = SafeInt32FromString(element1.GetAttribute(Xml_Height_Attr), 64);

                // Small item size
                element1 = (XmlElement)element0.SelectSingleNode(Xml_SmallItemSize_Node);
                _smallItemSize.Width = SafeInt32FromString(element1.GetAttribute(Xml_Width_Attr), 32);
                _smallItemSize.Height = SafeInt32FromString(element1.GetAttribute(Xml_Height_Attr), 32);

                // Scroll buttons
                element1 = (XmlElement)element0.SelectSingleNode(Xml_Scrolls_Node);

                //Up Scroll
                itemElement = (XmlElement)element1.SelectSingleNode(ToolBoxScrollDirection.UP.ToString());
                _upScroll.Enabled = SafeBoolFromString(itemElement.GetAttribute(Xml_Enabled_Attr), true);
                element2 = (XmlElement)itemElement.SelectSingleNode(Xml_ToolTip_Node);
                tempString = element2.InnerText;

                if (null != tempString && 0 < tempString.Length)
                {
                    _upScroll.ToolTip = tempString;
                }

                // Down Scroll
                itemElement = (XmlElement)element1.SelectSingleNode(ToolBoxScrollDirection.DOWN.ToString());
                _dnScroll.Enabled = SafeBoolFromString(itemElement.GetAttribute(Xml_Enabled_Attr), true);
                element2 = (XmlElement)itemElement.SelectSingleNode(Xml_ToolTip_Node);
                tempString = element2.InnerText;

                if (null != tempString && 0 < tempString.Length)
                {
                    _dnScroll.ToolTip = tempString;
                }

                int selTabIdx = 0;
                int selItemIdx = 0;
                int iLoop1 = 0;
                int iLoop2 = 0;

                // Back to root node.
                element0 = element;

                // Tabs
                element1 = (XmlElement)element0.SelectSingleNode(Xml_Tabs_Node);
                selTabIdx = SafeInt32FromString(element1.GetAttribute(Xml_SelTabIdx_Attr), -1);

                tabNodes = element1.SelectNodes(Xml_Tab_Node);

                DeleteAllTabs(false);

                for (iLoop1 = 0; iLoop1 < tabNodes.Count; iLoop1++)
                {
                    tab = new ToolBoxTab();
                    tabElement = (XmlElement)tabNodes[iLoop1];

                    // View Mode.
                    try
                    {
                        tab.View = (ToolBoxViewMode)Enum.Parse(typeof(ToolBoxViewMode), tabElement.GetAttribute(Xml_ViewMode_Attr), true);
                    }
                    catch
                    {
                        tab.View = ToolBoxViewMode.LIST;
                    }

                    // Item spacing
                    tab.ItemSpacing = SafeInt32FromString(tabElement.GetAttribute(Xml_ItemSpacing_Attr), 0);

                    // One item per row
                    tab.ShowOnlyOneItemPerRow = SafeBoolFromString(tabElement.GetAttribute(Xml_OneItemPerRow_Attr), false);

                    // Item bg color
                    tab.ItemBackgroundColour = ColorFromHtmlString(tabElement.GetAttribute(Xml_ItemBgClr_Attr), Color.Empty);

                    // Item border color
                    tab.ItemBorderColour = ColorFromHtmlString(tabElement.GetAttribute(Xml_ItemBorderClr_Attr), Color.Empty);

                    //Item normal color
                    tab.ItemNormalColour = ColorFromHtmlString(tabElement.GetAttribute(Xml_ItemNormClr_Attr), Color.Empty);

                    //Item selected color
                    tab.ItemSelectedColour = ColorFromHtmlString(tabElement.GetAttribute(Xml_ItemSelClr_Attr), Color.Empty);

                    //Item hover color
                    tab.ItemHoverColour = ColorFromHtmlString(tabElement.GetAttribute(Xml_ItemHoverClr_Attr), Color.Empty);

                    DeSerializeToolBoxItem(tab, tabElement);

                    tab.Parent = this;

                    _toolBoxTabs.Add(tab);

                    // Invoke deserialize event (if any) to deserialize the object for this tab
                    if (null != OnDeSerializeObject)
                    {
                        evtArgs = new ToolBoxXmlSerializationEventArgs(null, tabElement, true);

                        OnDeSerializeObject(tab, evtArgs);

                        tab.Object = evtArgs.Object;
                    }

                    element1 = (XmlElement)tabElement.SelectSingleNode(Xml_TabItems_Node);
                    itemNodes = element1.SelectNodes(Xml_TabItem_Node);
                    selItemIdx = SafeInt32FromString(element1.GetAttribute(Xml_SelItemIdx_Attr), 0);

                    for (iLoop2 = 0; iLoop2 < itemNodes.Count; iLoop2++)
                    {
                        tabItem = new ToolBoxItem();
                        itemElement = (XmlElement)itemNodes[iLoop2];

                        DeSerializeToolBoxItem(tabItem, itemElement);

                        tabItem.ParentItem = tab;
                        tabItem.Parent = this;

                        tab.AddItemRaw(tabItem);

                        try
                        {
                            // Invoke deserialize event (if any) to deserialize the object for this tabItem
                            if (null != OnDeSerializeObject)
                            {
                                evtArgs = new ToolBoxXmlSerializationEventArgs(null, itemElement, true);

                                OnDeSerializeObject(tabItem, evtArgs);

                                tabItem.Object = evtArgs.Object;
                            }
                        }
                        catch
                        {
                        }
                    }

                    // Assign Selected item index.
                    tab.SelectedItemIndex = selItemIdx;

                    // Set selected item.
                    try
                    {
                        tab[tab.SelectedItemIndex].Selected = true;
                    }
                    catch
                    {
                    }

                    // Register events after every thing went O.K.
                    tab.RegisterEvents();
                }

                // DeSerialization finished. 
                // Set the selected tab, do the layout and ensure the selected item visible.
                try
                {
                    _selectedTab = this[selTabIdx];

                    if (null != _selectedTab)
                    {
                        _selectedTab.Selected = true;
                    }

                    RefreshTabs();

                    if (null != _selectedTab)
                    {
                        _selectedTab.EnsureItemVisible(_selectedTab.SelectedItemIndex);
                    }
                }
                catch
                {
                }

                deSerialized = true;
            }
            catch
            {
                deSerialized = false;
            }
            finally
            {
                _isLoading = false;
            }

            return deSerialized;
        }

        #endregion //Serialization

        #region Krypton
        //Krypton Events
        private void OnPalettePaint(object sender, PaletteLayoutEventArgs e)
        {
            base.Invalidate();
        }

        private void OnGlobalPaletteChanged(object sender, EventArgs e)
        {
            if (((_palette != null)))
            {
                _palette.PalettePaint -= new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
            }
            _palette = KryptonManager.CurrentGlobalPalette;
            _paletteRedirect.Target = _palette;
            if (((_palette != null)))
            {
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
                InitColours();
            }
            base.Invalidate();

        }


        private void InitColours()
        {
            BorderStyle = BorderStyle.None;
            ItemNormalColour = _palette.ColorTable.OverflowButtonGradientBegin;
            TabNormalTextColour = _palette.ColorTable.MenuItemText;
            ForeColor = _palette.ColorTable.MenuStripText;
            TabSelectedTextColour = _palette.ColorTable.StatusStripText;
            ItemHoverColour = _palette.ColorTable.ButtonCheckedGradientBegin;
            TabHoverTextColour = _palette.ColorTable.ButtonSelectedHighlight;
            ItemSelectedTextColour = _palette.ColorTable.ButtonSelectedGradientBegin;
            ItemNormalTextColour = _palette.ColorTable.ToolStripText;
            ItemHoverTextColour = _palette.ColorTable.ButtonSelectedGradientMiddle;
            BackColor = _palette.ColorTable.ToolStripPanelGradientBegin;
        }
        #endregion
    }
}