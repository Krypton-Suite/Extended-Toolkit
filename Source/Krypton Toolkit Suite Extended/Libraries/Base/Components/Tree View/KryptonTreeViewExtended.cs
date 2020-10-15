using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
#if !NETCOREAPP31 && !NET5
    [ToolboxBitmap(typeof(TreeView))]
    public class KryptonTreeViewExtended : TreeView
    {

        #region "   Members   "
        private ImageList ilSigns;
        private IContainer components;
        private ImageList ilCheckBoxes;
        private bool _hasFocus = false;
        private IPalette _palette;
        private PaletteRedirect _paletteRedirect;
        private PaletteBackInheritRedirect _paletteBack;
        private PaletteBorderInheritRedirect _paletteBorder;
        private PaletteContentInheritRedirect _paletteContent;
        private IDisposable _mementoContent;
        private IDisposable _mementoBack1;
        private IDisposable _mementoBack2;
        #endregion

        #region   "   Properties   "
        Color _gradientStartColour = Color.White;
        Color _gradientStartColourTmp = Color.White;
        [Browsable(true), Category("Appearance-Extended")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [DefaultValue("Color.White")]
        public Color GradientStartColour
        {
            get { return _gradientStartColour; }
            set { _gradientStartColour = value; _gradientStartColourTmp = value; Invalidate(); }
        }

        Color _gradientEndColour = Color.Gray;
        Color _gradientEndColourTmp = Color.Gray;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("Color.Gray")]
        public Color GradientEndColour
        {
            get { return _gradientEndColour; }
            set { _gradientEndColour = value; _gradientEndColourTmp = value; Invalidate(); }
        }

        Color _gradientStartColourStyled = Color.White;
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("Color.White")]
        public Color GradientStartColourStyled
        {
            get { return _gradientStartColourStyled; }
            set { _gradientStartColourStyled = value; Invalidate(); }
        }

        Color _gradientEndColourStyled = Color.Gray;
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("Color.Gray")]
        public Color GradientEndColourStyled
        {
            get { return _gradientEndColourStyled; }
            set { _gradientEndColourStyled = value; Invalidate(); }
        }

        Color _gradientStartColourLostFocus = Color.WhiteSmoke;
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("Color.WhiteSmoke")]
        public Color GradientStartColourLostFocus
        {
            get { return _gradientStartColourLostFocus; }
            set { _gradientStartColourLostFocus = value; Invalidate(); }
        }

        Color _gradientEndColourLostFocus = Color.LightGray;
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("Color.LightGray")]
        public Color GradientEndColourLostFocus
        {
            get { return _gradientEndColourLostFocus; }
            set { _gradientEndColourLostFocus = value; Invalidate(); }
        }

        LinearGradientMode _gradientDirection = LinearGradientMode.Vertical;
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("Vertical")]
        public LinearGradientMode GradientDirection
        {
            get { return _gradientDirection; }
            set { _gradientDirection = value; Invalidate(); }
        }

        bool _persistentColours = false;
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("False")]
        public bool PersistentColours
        {
            get { return _persistentColours; }
            set { _persistentColours = value; InitColors(); Invalidate(); }
        }

        private bool _useKryptonRenderer = true;
        [Browsable(false), Category("Appearance-Extended")]
        [DefaultValue("True")]
        public Boolean UseKryptonRenderer
        {
            get { return _useKryptonRenderer; }
            set { _useKryptonRenderer = value; Invalidate(); }
        }

        Boolean _useStyledColours = false;
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("False")]
        public Boolean UseStyledColours
        {
            get { return _useStyledColours; }
            set { _useStyledColours = value; InitColors(); Invalidate(); }
        }

        Boolean _flatDesign = false;
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("False")]
        public Boolean FlatDesign
        {
            get { return _flatDesign; }
            set { _flatDesign = value; InitColors(); Invalidate(); }
        }

        Color _flatDesignColour = Color.Gray;
        Color _flatDesignColourTmp = Color.Gray;
        [Browsable(true), Category("Appearance-Extended")]
        public Color FlatDesignColour
        {
            get { return _flatDesignColour; }
            set
            {
                _flatDesignColour = value;
                _flatDesignColourTmp = value;
                Invalidate();
            }
        }

        Color _nodeTextColour = Color.Gray;
        Color _nodeTextColourTmp = Color.Gray;
        [Browsable(true), Category("Appearance-Extended")]
        public Color NodeTextColour
        {
            get { return _nodeTextColour; }
            set
            { _nodeTextColour = value; _nodeTextColourTmp = value; Invalidate(); }
        }

        Color _nodeFocusColour = Color.Gray;
        [Browsable(true), Category("Appearance-Extended")]
        public Color NodeFocusColour
        {
            get { return _nodeFocusColour; }
            set
            { _nodeFocusColour = value; Invalidate(); }
        }

        Color _flatDesignColourLostFocus = Color.FromArgb(231, 231, 231);
        [Browsable(true), Category("Appearance-Extended")]
        public Color FlatDesignColourLostFocus
        {
            get { return _flatDesignColourLostFocus; }
            set { _flatDesignColourLostFocus = value; Invalidate(); }
        }

        Boolean _drawFocus = false;
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("false")]
        public Boolean DrawFocus
        {
            get { return _drawFocus; }
            set { _drawFocus = value; Invalidate(); }
        }

        Boolean _enableVistaSigns = true;
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("True")]
        public Boolean EnableVistaSigns
        {
            get { return _enableVistaSigns; }
            set { _enableVistaSigns = value; Invalidate(); }
        }

        Boolean _enableVisualSigns = true;
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("True")]
        public Boolean EnableVisualSigns
        {
            get { return _enableVisualSigns; }
            set { _enableVisualSigns = value; Invalidate(); }
        }

        Boolean _enableVistaCheckBoxes = true;
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("True")]
        public Boolean EnableVistaCheckBoxes
        {
            get { return _enableVistaCheckBoxes; }
            set { _enableVistaCheckBoxes = value; Invalidate(); }
        }

        Boolean _enableSelectionBorder = true;
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("True")]
        public Boolean EnableSelectionBorder
        {
            get { return _enableSelectionBorder; }
            set { _enableSelectionBorder = value; Invalidate(); }
        }

        #endregion

        #region "   Ctor   "
        public KryptonTreeViewExtended()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            UpdateStyles();
            this.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            //SetStyle(ControlStyles.UserPaint, true);

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

            //vista
            _enableVistaCheckBoxes = Utility.IsVistaOrHigher();
            _enableVistaSigns = Utility.IsVistaOrHigher();

            InitColors();

            //for image list
            InitializeComponent();
        }

        #endregion

        #region   "   Init   "
        private void InitColors()
        {
            //set colors
            if (_persistentColours == false)
            {

                _gradientStartColour = _palette.ColorTable.StatusStripGradientBegin;
                _gradientEndColour = _palette.ColorTable.OverflowButtonGradientEnd;
                _gradientStartColourTmp = _palette.ColorTable.StatusStripGradientBegin;
                _gradientEndColourTmp = _palette.ColorTable.OverflowButtonGradientEnd;
                //nodeFocusColor = new SolidBrush(_palette.ColorTable.ToolStripGradientEnd);

                //init color values
                _gradientStartColourStyled = Color.FromArgb(255, 246, 215);
                _gradientEndColourStyled = Color.FromArgb(255, 213, 77);
                //nodeFocusColor = new SolidBrush(Color.FromArgb(255, 213, 77));

                _nodeTextColour = _palette.ColorTable.StatusStripText; //new SolidBrush(_palette.ColorTable.ToolStripText);
                _nodeTextColourTmp = _palette.ColorTable.StatusStripText;
                _nodeFocusColour = _palette.ColorTable.ToolStripGradientEnd;

                if (_useStyledColours)
                {
                    _nodeTextColour = Color.Black;
                    _nodeFocusColour = Color.FromArgb(255, 213, 77);
                }

                if (_flatDesign)
                {
                    _nodeTextColour = Color.Black;
                    _nodeFocusColour = Color.Gray;
                }


            }

            _nodeTextColourTmp = _nodeTextColour;
            _flatDesignColour = _palette.ColorTable.OverflowButtonGradientMiddle;// _palette.ColorTable.ToolStripGradientMiddle;
            _flatDesignColourTmp = _palette.ColorTable.OverflowButtonGradientMiddle;//_palette.ColorTable.ToolStripGradientMiddle;

        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KryptonTreeViewExtended));
            this.ilSigns = new System.Windows.Forms.ImageList(this.components);
            this.ilCheckBoxes = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // ilSigns
            // 
            this.ilSigns.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilSigns.ImageStream")));
            this.ilSigns.TransparentColor = System.Drawing.Color.Transparent;
            this.ilSigns.Images.SetKeyName(0, "XPPlus.png");
            this.ilSigns.Images.SetKeyName(1, "XPMinus.png");
            this.ilSigns.Images.SetKeyName(2, "VistaPlus.png");
            this.ilSigns.Images.SetKeyName(3, "VistaMinus.png");
            // 
            // ilCheckBoxes
            // 
            this.ilCheckBoxes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilCheckBoxes.ImageStream")));
            this.ilCheckBoxes.TransparentColor = System.Drawing.Color.Transparent;
            this.ilCheckBoxes.Images.SetKeyName(0, "XpNotChecked.gif");
            this.ilCheckBoxes.Images.SetKeyName(1, "XpChecked.gif");
            this.ilCheckBoxes.Images.SetKeyName(2, "VistaNotChecked.png");
            this.ilCheckBoxes.Images.SetKeyName(3, "VistaChecked.png");
            // 
            // KryptonTreeViewExt
            // 
            this.LineColor = System.Drawing.Color.Black;
            this.ResumeLayout(false);

        }
        #endregion

        #region "   Palette Change Event & Dispose   "
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


        //Kripton Palette Events
        private void OnPalettePaint(object sender, PaletteLayoutEventArgs e)
        {
            // Palette indicates we might need to repaint, so lets do it
            Invalidate();
        }

        //Dispose Event
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_mementoContent != null)
                {
                    _mementoContent.Dispose();
                    _mementoContent = null;
                }

                if (_mementoBack1 != null)
                {
                    _mementoBack1.Dispose();
                    _mementoBack1 = null;
                }

                if (_mementoBack2 != null)
                {
                    _mementoBack2.Dispose();
                    _mementoBack2 = null;
                }

                // Unhook from the palette events
                if (_palette != null)
                {
                    _palette.PalettePaint -= new EventHandler<PaletteLayoutEventArgs>(OnPalettePaint);
                    _palette = null;
                }

                // Unhook from the static events, otherwise we cannot be garbage collected
                KryptonManager.GlobalPaletteChanged -= new EventHandler(OnGlobalPaletteChanged);
            }

            base.Dispose(disposing);
        }
        #endregion

        #region "   Overrides & Draw  "
        // Create a Font object for the node tags.
        Font tagFont = new Font("Helvetica", 8, FontStyle.Bold);

        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            try
            {
                //init expanded, collapsed, item values
                string expanded = ">>";
                string collapsed = "<<";
                string item = " ";

                Image exp;
                Image col;
                if (_enableVistaSigns == true)
                {
                    exp = ilSigns.Images[2];
                    col = ilSigns.Images[3];
                }
                else
                {
                    exp = ilSigns.Images[0];
                    col = ilSigns.Images[1];
                }


                //node font color
                Brush nodeTextColor = new SolidBrush(_nodeTextColour); //new SolidBrush(_palette.ColorTable.ToolStripText);
                Brush nodeFocusColor = new SolidBrush(_nodeFocusColour);

                Graphics g = e.Graphics;
                Rectangle rect = e.Bounds;

                //ClearType
                try
                {
                    e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }

                // for background and for expanded, collapsed indicator
                Rectangle bgnrect = e.Bounds;
                bgnrect.Height -= 1;
                bgnrect.Width -= 1;


                Color gradStartColor = _gradientStartColour;
                Color gradEndColor = _gradientEndColour;

                //set colors
                if (_persistentColours == false)
                {
                    //init color values
                    if (_useStyledColours == true)
                    {
                        gradStartColor = _gradientStartColourStyled;
                        gradEndColor = _gradientEndColourStyled;
                    }
                    else
                    {
                        gradStartColor = _gradientStartColour;
                        gradEndColor = _gradientEndColour;
                    }
                }

                //BackColors 



                //TreeNodeStates stat = e.State;
                //Console.Write(stat);

                // Draw the background and node text for a selected node.
                if (((e.State & TreeNodeStates.Selected) != 0) || ((e.State & TreeNodeStates.Focused) != 0) || ((e.State & TreeNodeStates.Checked) != 0))
                {
                    // Draw the background of the selected node. The NodeBounds
                    // method makes the highlight rectangle large enough to
                    // include the text of a node tag, if one is present.

                    using (LinearGradientBrush brush = new LinearGradientBrush(e.Bounds, gradStartColor, gradEndColor, LinearGradientMode.Vertical))
                    {
                        g.FillRectangle(Brushes.White, rect);
                    }

                    if (_flatDesign)
                    {
                        g.FillRectangle(new SolidBrush(_flatDesignColour), rect);
                    }
                    else
                    {
                        DrawingMethods.DrawGradient(g, bgnrect, gradStartColor, gradEndColor, 90F, _enableSelectionBorder, gradEndColor, 1);
                    }
                    //DrawingMethods.DrawBlendGradient(g, rect, gradStartColor, gradEndColor, gradMiddleColor, 90F);

                    // Retrieve the node font. If the node font has not been set,
                    // use the TreeView font.
                    Font nodeFont = e.Node.NodeFont;
                    if (nodeFont == null) nodeFont = this.Font;


                    //if root node, less offset
                    if (e.Node.Level != 0)
                    {
                        //others
                        //progress by 19 starting with 41
                        rect.Offset(41 + 19 * (e.Node.Level - 1), 0);
                        bgnrect.Offset(41 + 19 * (e.Node.Level - 1) - 18, 0);

                        //if (e.Node.Level == 1) rect.Offset(41, 0);
                        //if (e.Node.Level == 2) rect.Offset(60, 0);
                        //if (e.Node.Level == 3) rect.Offset(79, 0);
                        //if (e.Node.Level == 4) rect.Offset(98, 0);

                    }
                    else
                    {
                        //root
                        rect.Offset(22, 0);
                        bgnrect.Offset(22 - 18, 0);
                    }


                    //expanded, collapsed, item? --> Draw Indicator
                    if (e.Node.Nodes.Count > 0)
                    {
                        if (e.Node.IsExpanded) //Expanded
                        {
                            if (_enableVisualSigns == true) //image or string?
                            {
                                g.DrawImage(col, bgnrect.X - 1, bgnrect.Y, 16, 16);
                            }
                            else
                            {
                                g.DrawString(collapsed, nodeFont, nodeTextColor, bgnrect);
                            }

                        }
                        else // Collapsed
                        {
                            if (_enableVisualSigns == true)
                            {
                                g.DrawImage(exp, bgnrect.X - 1, bgnrect.Y, 16, 16);
                            }
                            else
                            {
                                g.DrawString(expanded, nodeFont, nodeTextColor, bgnrect);
                            }

                        }
                    }
                    else //Item
                    {
                        g.DrawString(item, nodeFont, nodeTextColor, bgnrect);
                    }

                    //CheckBox present?
                    if (this.CheckBoxes == true)
                    {
                        //string CheckState = "V";
                        Image Check;
                        if (e.Node.Checked == true)
                        {
                            //CheckState = "V";
                            if (_enableVistaCheckBoxes == true)
                            {
                                Check = ilCheckBoxes.Images[3];
                            }
                            else
                            {
                                Check = ilCheckBoxes.Images[1];
                            }

                        }
                        else
                        {
                            //CheckState = "O";
                            if (_enableVistaCheckBoxes == true)
                            {
                                Check = ilCheckBoxes.Images[2];
                            }
                            else
                            {
                                Check = ilCheckBoxes.Images[0];
                            }
                        }

                        //vista Pixel fix
                        if (Utility.IsVistaOrHigher() == true)
                        {
                            rect.Offset(-2, -1);
                        }

                        //e.Graphics.DrawString(CheckState, this.Font, new SolidBrush(textColor), rect);
                        g.DrawImage(Check, rect.X, rect.Y, 16, 16);
                        rect.Offset(16, 0);

                        //vista Pixel fix
                        if (Utility.IsVistaOrHigher() == true)
                        {
                            rect.Offset(-1, 1);
                        }
                    }

                    //Picture Present?
                    if (this.ImageList != null && e.Node.ImageIndex >= 0 && e.Node.ImageIndex < ImageList.Images.Count)
                    {
                        this.ImageList.Draw(g, rect.X, rect.Y + 0, 16, 16, e.Node.ImageIndex);
                        rect.Offset(19, 0);
                    }
                    else
                    {
                        if (this.ImageList != null)
                        {
                            this.ImageList.Draw(g, rect.X, rect.Y + 0, 16, 16, this.ImageIndex);
                            rect.Offset(19, 0);
                        }
                    }

                    //ofset for aligning the text
                    rect.Offset(0, 1);

                    // Draw the node text.
                    g.DrawString(e.Node.Text, nodeFont, nodeTextColor, rect);
                }


                // Use the default background and node text.
                else
                {

                    e.DrawDefault = true;
                }

                // If a node tag is present, draw its string representation 
                // to the right of the label text.
                if (e.Node.Tag != null)
                {
                    e.Graphics.DrawString(e.Node.Tag.ToString(), tagFont,
                        nodeTextColor, e.Bounds.Right + 2, e.Bounds.Top);
                }

                // If the node has focus, draw the focus rectangle large, making
                // it large enough to include the text of the node tag, if present.
                if ((e.State & TreeNodeStates.Focused) != 0)
                {
                    using (Pen focusPen = new Pen(nodeFocusColor))
                    {
                        focusPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                        Rectangle focusBounds = NodeBounds(e.Node);
                        focusBounds.Size = new Size(focusBounds.Width - 1,
                        focusBounds.Height - 2);
                        //uncomment for focus area
                        if (_drawFocus == true)
                        {
                            e.Graphics.DrawRectangle(focusPen, focusBounds);
                        }
                    }
                }
                nodeTextColor.Dispose();
                nodeFocusColor.Dispose();

            }

            catch
            {
            }
        }
        protected override void OnLostFocus(EventArgs e)
        {
            _flatDesignColour = _flatDesignColourLostFocus;

            _nodeTextColour = Color.Black;

            _gradientStartColour = _gradientStartColourLostFocus;
            _gradientEndColour = _gradientEndColourLostFocus;
            Invalidate();
            base.OnLostFocus(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            _flatDesignColour = _flatDesignColourTmp;

            _nodeTextColour = _nodeTextColourTmp;

            _gradientStartColour = _gradientStartColourTmp;
            _gradientEndColour = _gradientEndColourTmp;

            Invalidate();
            base.OnGotFocus(e);
        }

        // Returns the bounds of the specified node, including the region 
        // occupied by the node label and any node tag displayed.
        private Rectangle NodeBounds(TreeNode node)
        {

            Rectangle bounds = new Rectangle();

            // Set the return value to the normal node bounds.
            if (node != null)
            {
                bounds = node.Bounds;
                if (node.Tag != null)
                {
                    // Retrieve a Graphics object from the TreeView handle
                    // and use it to calculate the display width of the tag.
                    Graphics g = this.CreateGraphics();
                    int tagWidth = (int)g.MeasureString
                        (node.Tag.ToString(), tagFont).Width + 6;

                    // Adjust the node bounds using the calculated value.
                    bounds.Offset(tagWidth / 2, 0);
                    bounds = Rectangle.Inflate(bounds, tagWidth / 2, 0);

                }
            }

            return bounds;

        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            //Invalidate();
            base.OnMouseUp(e);
        }
        // Selects a node that is clicked on its label or tag text.
        protected override void OnMouseDown(MouseEventArgs e)
        {
            TreeNode clickedNode = this.GetNodeAt(e.X, e.Y);
            if (NodeBounds(clickedNode).Contains(e.X, e.Y))
            {
                this.SelectedNode = clickedNode;
            }
            //base.OnMouseDown(e);
            //Invalidate();

        } //myTreeView_MouseDown




        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);

            /*if (this.DesignMode==true)
            {
                base.OnPaintBackground(pevent);
            }
            else
            {
                Rectangle rect = this.Bounds;
                pevent.Graphics.TranslateTransform(-this.Left, -this.Top);

            Color gradStartColor = _gradientStartColor;
            Color gradEndColor = _gradientEndColor;
            Color gradMiddleColor = _gradientMiddleColor;
            using (LinearGradientBrush brush = new LinearGradientBrush(rect,
                gradStartColor,
                gradMiddleColor,
                GradientDirection))
            {   
                pevent.Graphics.FillRectangle(brush, rect);
            }

            PaintEventArgs pe = new PaintEventArgs(pevent.Graphics, rect);
            InvokePaintBackground(this.Parent, pe);
            pevent.Graphics.ResetTransform();
        }
           */
        }

        #endregion

        #region "   DrawBackGround   "
        private static int WM_NCPAINT = 0x0085;    // WM_NCPAINT message
        private static int WM_ERASEBKGND = 0x0014; // WM_ERASEBKGND message
        private static int WM_PAINT = 0x000F;      // WM_PAINT message

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            //DrawBack(ref m, this.Width, this.Height);

        }

        public void DrawBack(ref Message message, int width, int height)
        {
            if (message.Msg == WM_NCPAINT || message.Msg == WM_ERASEBKGND || message.Msg == WM_PAINT)
            {
                IntPtr hdc = Win32.GetDCEx(message.HWnd, (IntPtr)1, 1 | 0x0020);

                if (hdc != IntPtr.Zero)
                {
                    Graphics graphics = Graphics.FromHdc(hdc);
                    Rectangle rectangle = new Rectangle(0, 0, width, height);
                    graphics.FillRectangle(new SolidBrush(Color.Transparent), rectangle);

                    message.Result = (IntPtr)1;
                    Win32.ReleaseDC(message.HWnd, hdc);
                }
            }
        }
        #endregion
    }
#endif
}