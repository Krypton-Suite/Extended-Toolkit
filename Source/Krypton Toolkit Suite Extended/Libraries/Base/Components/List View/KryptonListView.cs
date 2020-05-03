using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Base
{
    [ToolboxBitmap(typeof(ListView))]
    public partial class KryptonListView : ListView
    {
        #region Constants
        private const int MINIMUM_ITEM_HEIGHT = 18;
        #endregion

        #region Variables
        private bool _hasFocus = false;
        private IPalette _palette;
        private PaletteRedirect _paletteRedirect;
        private PaletteBackInheritRedirect _paletteBack;
        private PaletteBorderInheritRedirect _paletteBorder;
        private PaletteContentInheritRedirect _paletteContent;
        private IDisposable _mementoContent;
        private IDisposable _mementoBack1;
        private IDisposable _mementoBack2;
        private ListViewColumnSorter lvwColumnSorter;
        private ListViewItem _itemDnD = null;
        private Font _originalFont;
        private Color _originalForeColor;
        #endregion

        #region Properties

        //for setting the minimum height of an item
        public virtual int ItemHeight { get; set; }

        ///
        /// Indicates if the current view is being utilized in the VS.NET IDE or not.
        ///
        private bool _designMode;
        public new bool DesignMode
        {
            get
            {
                //return (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv");
                return _designMode; ;
            }
        }

        private int _lineBefore = -1;
        [Browsable(true), Category("Appearance-Extended")]
        public int LineBefore
        {
            get { return _lineBefore; }
            set { _lineBefore = value; }
        }

        private int _lineAfter = -1;
        [Browsable(true), Category("Appearance-Extended")]
        public int LineAfter
        {
            get { return _lineAfter; }
            set { _lineAfter = value; }
        }
        Boolean _enableDragDrop = false;
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("False")]
        public Boolean EnableDragDrop
        {
            get { return _enableDragDrop; }
            set { _enableDragDrop = value; }
        }

        Color _alternateRowColor = Color.LightGray;
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("Color.Gray")]
        public Color AlternateRowColor
        {
            get { return _alternateRowColor; }
            set { _alternateRowColor = value; Invalidate(); }
        }

        Boolean _alternateRowColorEnabled = true;
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("true")]
        public Boolean AlternateRowColorEnabled
        {
            get { return _alternateRowColorEnabled; }
            set { _alternateRowColorEnabled = value; Invalidate(); }
        }

        Color _gradientStartColor = Color.White;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("Color.White")]
        public Color GradientStartColor
        {
            get { return _gradientStartColor; }
            set { _gradientStartColor = value; Invalidate(); }
        }

        Color _gradientEndColor = Color.Gray;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("Color.Gray")]
        public Color GradientEndColor
        {
            get { return _gradientEndColor; }
            set { _gradientEndColor = value; Invalidate(); }
        }

        Color _gradientMiddleColor = Color.LightGray;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("Color.Gray")]
        public Color GradientMiddleColor
        {
            get { return _gradientMiddleColor; }
            set { _gradientMiddleColor = value; Invalidate(); }
        }

        Boolean _persistentColors = false;
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("False")]
        public Boolean PersistentColors
        {
            get { return _persistentColors; }
            set { _persistentColors = value; Invalidate(); }
        }

        Boolean _useStyledColors = false;
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("False")]
        public Boolean UseStyledColors
        {
            get { return _useStyledColors; }
            set { _useStyledColors = value; Invalidate(); }
        }

        private bool _useKryptonRenderer = true;
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("True")]
        public Boolean UseKryptonRenderer
        {
            get { return _useKryptonRenderer; }
            set { _useKryptonRenderer = value; Invalidate(); }
        }

        Boolean _selectEntireRowOnSubItem = true;
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("True")]
        public Boolean SelectEntireRowOnSubItem
        {
            get { return _selectEntireRowOnSubItem; }
            set { _selectEntireRowOnSubItem = value; }
        }

        //Boolean _indendFirstItem = true;
        /*[Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("True")]
        public Boolean IndendFirstItem
        {
            get { return _indendFirstItem; }
            set { _indendFirstItem = value; }
        }*/

        Boolean _forceLeftAlign = false;
        [Browsable(false), Category("Appearance-Extended")]
        [DefaultValue("True")]
        public Boolean ForceLeftAlign
        {
            get { return _forceLeftAlign; }
            set { _forceLeftAlign = value; }
        }

        Boolean _autoSizeLastColumn = true;
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("True")]
        public Boolean AutoSizeLastColumn
        {
            get { return _autoSizeLastColumn; }
            set { _autoSizeLastColumn = value; Invalidate(); }
        }

        Boolean _enableSorting = true;
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("True")]
        public Boolean EnableSorting
        {
            get { return _enableSorting; }
            set { _enableSorting = value; }
        }

        Boolean _enableHeaderRendering = true;
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("False")]
        public Boolean EnableHeaderRendering
        {
            get { return _enableHeaderRendering; }
            set { _enableHeaderRendering = value; Invalidate(); }
        }

        Boolean _enableHeaderGlow = false;
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("False")]
        public Boolean EnableHeaderGlow
        {
            get { return _enableHeaderGlow; }
            set { _enableHeaderGlow = value; Invalidate(); }
        }

        Boolean _enableHeaderHotTrack = false;
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("False")]
        public Boolean EnableHeaderHotTrack
        {
            get { return _enableHeaderHotTrack; }
            set
            {
                _enableHeaderHotTrack = value;
                if (value)
                {
                    this.SetStyle(ControlStyles.OptimizedDoubleBuffer, false);
                }
                else
                {
                    this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                }
                UpdateStyles();
                ; Invalidate();
            }
        }

        Boolean _enableVistaCheckBoxes = true;
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("True")]
        public Boolean EnableVistaCheckBoxes
        {
            get { return _enableVistaCheckBoxes; }
            set { _enableVistaCheckBoxes = value; Invalidate(); }
        }

        Boolean _enableSelectionBorder = false;
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("True")]
        public Boolean EnableSelectionBorder
        {
            get { return _enableSelectionBorder; }
            set { _enableSelectionBorder = value; Invalidate(); }
        }

        #endregion

        #region Constructors
        public KryptonListView()
        {
            //this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.EnableNotifyMessage, true);
            UpdateStyles();

            this.OwnerDraw = true;

            //store the original font
            _originalFont = (Font)this.Font.Clone();

            //store the original foreColor
            _originalForeColor = (Color)this.ForeColor;

            // add Palette Handler
            // Cache the current global palette setting
            _palette = KryptonManager.CurrentGlobalPalette;

            // Hook into palette events
            if (_palette != null)
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);

            // We want to be notified whenever the global palette changes
            KryptonManager.GlobalPaletteChanged += new EventHandler(OnGlobalPaletteChanged);

            // Create redirection object to the base palette
            _paletteRedirect = new PaletteRedirect(_palette);

            // Create accessor objects for the back, border and content
            _paletteBack = new PaletteBackInheritRedirect(_paletteRedirect);
            _paletteBorder = new PaletteBorderInheritRedirect(_paletteRedirect);
            _paletteContent = new PaletteContentInheritRedirect(_paletteRedirect);

            InitColors();

            // Create an instance of a ListView column sorter and assign it 
            // to the ListView control.
            lvwColumnSorter = new ListViewColumnSorter();
            this.ListViewItemSorter = lvwColumnSorter;

            if (_selectEntireRowOnSubItem == true)
            {
                this.FullRowSelect = true;
            }

            //vista
            _enableVistaCheckBoxes = Utility.IsVista();

            //for image list
            InitializeComponent();

            //Design Mode
            _designMode = (System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv");

            //set a minimum item height
            if (this.SmallImageList == null)
            {

                this.SmallImageList = ilHeight;
            }
        }
        #endregion


        #region Methods
        public StringAlignment ConvertHorizontalAlignmentToStringAlignment(HorizontalAlignment input)
        {

            switch (input)
            {
                case HorizontalAlignment.Center:
                    return StringAlignment.Center;

                case HorizontalAlignment.Right:
                    return StringAlignment.Far;

                case HorizontalAlignment.Left:
                    return StringAlignment.Near;

            }
            return StringAlignment.Center;
        }

        private void CleanColumnsTags()
        {
            int i;

            for (i = 0; i < this.Columns.Count; i++)
            {
                this.Columns[i].Tag = null;
            }
            Invalidate();
        }

        //create Graphics Path
        private GraphicsPath CreateRectGraphicsPath(Rectangle rect)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddRectangle(rect);
            return path;
        }

        /// <summary>
        /// Draw a line with insertion marks at each end
        /// </summary>
        /// <param name="X1">Starting position (X) of the line</param>
        /// <param name="X2">Ending position (X) of the line</param>
        /// <param name="Y">Position (Y) of the line</param>
        private void DrawInsertionLine(int X1, int X2, int Y)
        {
            using (Graphics g = this.CreateGraphics())
            {
                g.DrawLine(Pens.Red, X1, Y, X2 - 1, Y);

                Point[] leftTriangle = new Point[3] {
                            new Point(X1,      Y-4),
                            new Point(X1 + 7,  Y),
                            new Point(X1,      Y+4)
                        };
                Point[] rightTriangle = new Point[3] {
                            new Point(X2,     Y-4),
                            new Point(X2 - 8, Y),
                            new Point(X2,     Y+4)
                        };
                g.FillPolygon(Brushes.Red, leftTriangle);
                g.FillPolygon(Brushes.Red, rightTriangle);
            }
        }


        private string CompactString(string MyString, int Width, Font Font, TextFormatFlags FormatFlags)
        {
            string result = string.Copy(MyString);

            TextRenderer.MeasureText(result, Font, new Size(Width, 0), FormatFlags | TextFormatFlags.ModifyString);

            return result;
        }
        #endregion

        #region Krypton
        private void InitColors()
        {
            //set colors
            if (_persistentColors == false)
            {
                //init color values
                if (_useStyledColors == true)
                {
                    _gradientStartColor = Color.FromArgb(255, 246, 215);
                    _gradientEndColor = Color.FromArgb(255, 213, 77);
                    _gradientMiddleColor = Color.FromArgb(252, 224, 133);
                }
                else
                {
                    _gradientStartColor = _palette.ColorTable.StatusStripGradientBegin;
                    _gradientEndColor = _palette.ColorTable.OverflowButtonGradientEnd;
                    _gradientMiddleColor = _palette.ColorTable.StatusStripGradientEnd;
                }
            }
            _alternateRowColor = _palette.ColorTable.ToolStripContentPanelGradientBegin;
        }

        //Krypton Palette Events
        private void OnGlobalPaletteChanged(object sender, EventArgs e)
        {
            // Unhook events from old palette
            if (_palette != null)
                _palette.PalettePaint -= new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);

            // Cache the new IPalette that is the global palette
            _palette = KryptonManager.CurrentGlobalPalette;
            _paletteRedirect.Target = _palette;

            // Hook into events for the new palette
            if (_palette != null)
            {
                _palette.PalettePaint += new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
                InitColors();
            }

            // Change of palette means we should repaint to show any changes
            Invalidate();
        }

        //Krypton Palette Events
        private void OnPalettePaint(object sender, PaletteLayoutEventArgs e)
        {
            Invalidate();
        }
        #endregion
    }
}
