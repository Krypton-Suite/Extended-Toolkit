using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Permissions;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    [ToolboxBitmap(typeof(ListView))]
    public class KryptonListView : ListView
    {
        #region Designer
        private void InitializeComponent()
        {
            components = new Container();

            ComponentResourceManager resources = new ComponentResourceManager(typeof(KryptonListView));

            ilCheckBoxes = new ImageList(components);

            ilHeight = new ImageList(components);

            SuspendLayout();

            this.ilCheckBoxes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilCheckBoxes.ImageStream")));
            this.ilCheckBoxes.TransparentColor = System.Drawing.Color.Transparent;
            this.ilCheckBoxes.Images.SetKeyName(0, "XpNotChecked.gif");
            this.ilCheckBoxes.Images.SetKeyName(1, "XpChecked.gif");
            this.ilCheckBoxes.Images.SetKeyName(2, "VistaNotChecked.png");
            this.ilCheckBoxes.Images.SetKeyName(3, "VistaChecked.png");

            ilHeight.ColorDepth = ColorDepth.Depth32Bit;

            ilHeight.ImageSize = new Size(1, 16);

            ilHeight.TransparentColor = Color.Transparent;

            ResumeLayout(false);
        }
        #endregion

        #region Constants
        private const int MINIMUM_ITEM_HEIGHT = 18;
        #endregion

        #region Variables
        private bool _hasFocus = false, _selectEntireRowOnSubItem, _enableVistaCheckBoxes, _designMode, _persistentColours, _useStyledColours, _alternateRowColourEnabled, _useKryptonRenderer;

        private Color _alternateRowColour = Color.LightGray, _originalForeColour, _gradientStartColour = Color.White, _gradientMiddleColour = Color.LightGray, _gradientEndColour = Color.Gray;

        private Font _originalTypeface;

        private ListViewColumnSorter lvwColumnSorter;

        #region Krypton
        private IPalette _palette;

        private PaletteRedirect _paletteRedirect;

        private PaletteBackInheritRedirect _paletteBack;

        private PaletteBorderInheritRedirect _paletteBorder;

        private PaletteContentInheritRedirect _paletteContent;

        private IDisposable _momentoContent, _momentoBack1, _momentoBack2;
        #endregion

        #region Designer
        private IContainer components;

        private ImageList ilCheckBoxes, ilHeight;
        #endregion

        #endregion

        #region Properties
        //for setting the minimum height of an item
        public virtual int ItemHeight { get; set; }

        ///
        /// Indicates if the current view is being utilized in the VS.NET IDE or not.
        ///
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
        public Color AlternateRowColour
        {
            get { return _alternateRowColour; }
            set { _alternateRowColour = value; Invalidate(); }
        }

        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("true")]
        public Boolean AlternateRowColourEnabled
        {
            get { return _alternateRowColourEnabled; }
            set { _alternateRowColourEnabled = value; Invalidate(); }
        }


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("Color.White")]
        public Color GradientStartColour
        {
            get { return _gradientStartColour; }
            set { _gradientStartColour = value; Invalidate(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("Color.Gray")]
        public Color GradientEndColour
        {
            get { return _gradientEndColour; }
            set { _gradientEndColour = value; Invalidate(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("Color.Gray")]
        public Color GradientMiddleColour
        {
            get { return _gradientMiddleColour; }
            set { _gradientMiddleColour = value; Invalidate(); }
        }


        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("False")]
        public Boolean PersistentColours
        {
            get { return _persistentColours; }
            set { _persistentColours = value; Invalidate(); }
        }

        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("False")]
        public Boolean UseStyledColours
        {
            get { return _useStyledColours; }
            set { _useStyledColours = value; Invalidate(); }
        }


        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("True")]
        public Boolean UseKryptonRenderer
        {
            get { return _useKryptonRenderer; }
            set { _useKryptonRenderer = value; Invalidate(); }
        }

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

        #region Constructor
        public KryptonListView()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.SupportsTransparentBackColor | ControlStyles.EnableNotifyMessage, true);

            UpdateStyles();

            OwnerDraw = true;

            _originalTypeface = (Font)Font.Clone();

            _originalForeColour = (Color)ForeColor;

            _palette = KryptonManager.CurrentGlobalPalette;

            if (_palette != null)
            {
                _palette.PalettePaint += OnPalettePaint;
            }

            KryptonManager.GlobalPaletteChanged += OnGlobalPaletteChanged;

            _paletteRedirect = new PaletteRedirect(_palette);

            _paletteBack = new PaletteBackInheritRedirect(_paletteRedirect);

            _paletteBorder = new PaletteBorderInheritRedirect(_paletteRedirect);

            _paletteContent = new PaletteContentInheritRedirect(_paletteRedirect);

            InitialiseColours();

            lvwColumnSorter = new ListViewColumnSorter();

            ListViewItemSorter = lvwColumnSorter;

            if (_selectEntireRowOnSubItem)
            {
                FullRowSelect = true;
            }

            _enableVistaCheckBoxes = Utility.IsVistaOrHigher();

            InitializeComponent();

            _designMode = (Process.GetCurrentProcess().ProcessName == "devenv");

            if (SmallImageList == null)
            {
                SmallImageList = ilHeight;
            }
        }
        #endregion

        #region Krypton
        private void InitialiseColours()
        {
            if (_persistentColours == false)
            {
                if (_useStyledColours)
                {
                    _gradientStartColour = Color.FromArgb(255, 246, 215);

                    _gradientEndColour = Color.FromArgb(255, 213, 77);

                    _gradientMiddleColour = Color.FromArgb(252, 224, 133);
                }
                else
                {
                    _gradientStartColour = _palette.ColorTable.StatusStripGradientBegin;

                    _gradientEndColour = _palette.ColorTable.OverflowButtonGradientEnd;

                    _gradientMiddleColour = _palette.ColorTable.StatusStripGradientEnd;
                }
            }

            _alternateRowColour = _palette.ColorTable.ToolStripContentPanelGradientBegin;
        }

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
                InitialiseColours();
            }

            // Change of palette means we should repaint to show any changes
            Invalidate();
        }

        private void OnPalettePaint(object sender, PaletteLayoutEventArgs e) => Invalidate();
        #endregion

        #region Overrides
        protected override void OnDrawItem(DrawListViewItemEventArgs e)
        {
            ForeColor = GetForeTextColour(PaletteState.Normal);

            Font = GetForeTextFont(PaletteState.Normal);

            if (!DesignMode)
            {
                Rectangle rect = e.Bounds;
                Graphics g = e.Graphics;

                //minimum item height
                if (rect.Height < MINIMUM_ITEM_HEIGHT)
                { rect.Height = (int)MINIMUM_ITEM_HEIGHT; }


                rect.Height -= 1;
                rect.Width -= 1;

                if (_palette == null)
                {
                    EventArgs Ev = new EventArgs();
                    OnGlobalPaletteChanged(this, Ev);
                }

                //force Left align on items
                if (_forceLeftAlign == true)
                {
                    foreach (ColumnHeader col in this.Columns)
                    {
                        col.TextAlign = HorizontalAlignment.Left;
                    }
                }

                if (this.View == View.Details)
                {
                    if (((e.State & ListViewItemStates.Selected) != 0) && (e.Item.Selected == true))
                    {
                        // Draw the background and focus rectangle for a selected item.
                        if (_useKryptonRenderer)
                        {
                            if (_hasFocus)
                                KryptonRenderer(PaletteState.Pressed, ref g, ref rect); //KryptonRenderer
                            else
                                KryptonRenderer(PaletteState.Normal, ref g, ref rect);
                        }
                        else
                            InternalRenderer(ref g, ref rect); //InternalRenderer
                    }
                    else
                    {
                        // Draw the background for an unselected item.
                        e.DrawDefault = true;
                    }
                }
                // Draw the item text for views other than the Details view.
                else
                {
                    // Draw the background for an unselected item.
                    e.DrawDefault = true;
                }
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        protected override void OnDrawSubItem(DrawListViewSubItemEventArgs e)
        {
            //set font 
            //get Colors And Font
            this.ForeColor = GetForeTextColour(PaletteState.Normal);
            this.Font = GetForeTextFont(PaletteState.Normal);

            if (!DesignMode)
            {
                Rectangle rect = e.Bounds;
                Graphics g = e.Graphics;

                //minimum item height
                if (rect.Height < MINIMUM_ITEM_HEIGHT)
                { rect.Height = (int)MINIMUM_ITEM_HEIGHT; }

                rect.Height -= 1;
                rect.Width -= 1;

                //for correct string drawing Space
                int MeasureStringWidth = e.Header.Width;

                // We want to anti alias the drawing for nice smooth curves
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                //force Left align on items
                if (_forceLeftAlign == true)
                {
                    foreach (ColumnHeader col in this.Columns)
                    {
                        col.TextAlign = HorizontalAlignment.Left;
                    }
                }

                if (this.View == View.Details)
                {
                    if ((e.ItemState & ListViewItemStates.Selected) != 0)
                    {

                        //set offset for krypton
                        if (_useKryptonRenderer) rect.Offset(0, +1);

                        //CheckBox present?
                        if ((this.CheckBoxes == true) && (e.ColumnIndex == 0))
                        {
                            //string CheckState = "V";

                            Image Check;
                            if (e.Item.Checked == true)
                            {
                                //CheckState = "V";
                                if (_enableVistaCheckBoxes == true)
                                    Check = ilCheckBoxes.Images[3];
                                else
                                    Check = ilCheckBoxes.Images[1];
                            }
                            else
                            {
                                //CheckState = "O";
                                if (_enableVistaCheckBoxes == true)
                                    Check = ilCheckBoxes.Images[2];
                                else
                                    Check = ilCheckBoxes.Images[0];
                            }

                            //vista pixel fix
                            if (Utility.IsVistaOrHigher() == true)
                                rect.Offset(-2, 0);

                            //e.Graphics.DrawString(CheckState, this.Font, new SolidBrush(textColor), rect);
                            g.DrawImage(Check, rect.X + 4, rect.Y - 1, 16, 16);
                            rect.Offset(19, 0);

                            //fix for string drawing
                            MeasureStringWidth -= 19;

                            //vista pixel fix
                            if (Utility.IsVistaOrHigher() == true)
                                rect.Offset(-1, 0);
                        }

                        //Picture Present?
                        if (e.ColumnIndex == 0)
                        {
                            if (this.SmallImageList != null)
                            {
                                Size imgSize = this.SmallImageList.ImageSize;
                                try
                                { this.SmallImageList.Draw(g, rect.X + 4, rect.Y, imgSize.Width, imgSize.Height, e.Item.ImageIndex); }
                                catch
                                { }
                                rect.Offset(imgSize.Width, 0);

                                //fix for string drawing
                                MeasureStringWidth -= imgSize.Width;
                            }
                        }

                        rect.Offset(4, 2);

                        //set offset for krypton
                        if (_useKryptonRenderer) rect.Offset(0, -2);

                        //drawText
                        Color textColour = GetForeTextColour(PaletteState.CheckedPressed);
                        //if (!_hasFocus)
                        //    textColor = GetForeTextColor(PaletteState.Normal);


                        //compact the text:
                        string TextToDraw = CompactString(e.SubItem.Text, MeasureStringWidth, this.Font, TextFormatFlags.EndEllipsis);

                        //Draw String
                        e.Graphics.DrawString(TextToDraw, this.Font, new SolidBrush(textColour), rect);


                        //e.DrawFocusRectangle(rect);
                    }
                    else
                    {
                        // Draw the background for an unselected item.
                        e.DrawDefault = true;

                    }

                }
                // Draw the item text for views other than the Details view.
                else
                {
                    // Draw the background for an unselected item.
                    e.DrawDefault = true;
                }

            }
            else
            {
                e.DrawDefault = true;
            }
        }
        #endregion

        #region Renderers
        private Color GetForeTextColourHeader(PaletteState buttonState)
        {
            Color textColour = _originalForeColour;

            textColour = _palette.ColorTable.MenuItemText;// StatusStripText;
            if (buttonState == PaletteState.CheckedPressed) textColour = _palette.ColorTable.StatusStripText;

            if (_useKryptonRenderer)
                textColour = _palette.GetContentShortTextColor1(PaletteContentStyle.ButtonStandalone, buttonState);

            return textColour;
        }

        private Color GetForeTextColour(PaletteState buttonState)
        {
            Color textColour = _originalForeColour;

            if ((_persistentColours == false) || _useKryptonRenderer)
            {
                //init color values
                //if (_useStyledColors == true)
                //    textColor = _palette.ColorTable.MenuItemText;
                //else
                textColour = _palette.ColorTable.MenuItemText;// StatusStripText;
                if (buttonState == PaletteState.CheckedPressed)
                {
                    if (_useKryptonRenderer) textColour = _palette.GetContentShortTextColor1(PaletteContentStyle.ButtonStandalone, buttonState);
                    else textColour = _palette.ColorTable.StatusStripText;
                }
            }

            return textColour;
        }

        private Font GetForeTextFont(PaletteState buttonState)
        {
            Font textFont = (Font)_originalTypeface;

            if (_useKryptonRenderer)
                textFont = _palette.GetContentShortTextFont(PaletteContentStyle.ButtonStandalone, buttonState);

            //return value
            return textFont;
        }

        private PaletteState GetPaletteState(ref DrawListViewColumnHeaderEventArgs e, bool isTracking)
        {
            PaletteState State = PaletteState.Normal;

            if (e.State == ListViewItemStates.Selected)
            {
                State = PaletteState.CheckedPressed;
            }
            else
            {
                if (isTracking)
                    State = PaletteState.Tracking;
                else
                    State = PaletteState.Normal;
            }
            return State;
        }


        private void KryptonRenderer(PaletteState State, ref Graphics g, ref Rectangle rect)
        {
            // Get the renderer associated with this palette
            IRenderer renderer = _palette.GetRenderer();


            // we need to find the correct palette state based on if the mouse 
            // is over the control if the mouse button is pressed down or not.
            PaletteState buttonState = PaletteState.Normal;

            //get button state
            buttonState = State;

            // Create a rectangle inset, this is where we will draw the node
            Rectangle innerRect = rect;
            Rectangle innerContent = new Rectangle(innerRect.X + 1, innerRect.Y + 1, innerRect.Width - 2, innerRect.Height - 2);

            // Set the style of control we want to draw
            _paletteBack.Style = PaletteBackStyle.ButtonStandalone;
            _paletteBorder.Style = PaletteBorderStyle.ButtonStandalone;
            _paletteContent.Style = PaletteContentStyle.ButtonStandalone;

            //clear contents
            g.FillRectangle(new SolidBrush(this.BackColor), innerRect.X - 1, innerRect.Y, innerRect.Width + 2, innerRect.Height);

            //force disabled mode
            if (this.Enabled == false) buttonState = PaletteState.Disabled;

            // Create the rendering context that is passed into all renderer calls
            using (RenderContext renderContext = new RenderContext(this, g, rect, renderer))
            {
                using (GraphicsPath path = renderer.RenderStandardBorder.GetBackPath(renderContext, innerRect, _paletteBorder, VisualOrientation.Top, buttonState))
                {
                    // Ask renderer to draw the background
                    _momentoBack1 = renderer.RenderStandardBack.DrawBack(renderContext, innerContent, path, _paletteBack, VisualOrientation.Top, buttonState, _momentoBack1);
                }

                // Now we draw the border of the inner area, also in ButtonStandalone style
                renderer.RenderStandardBorder.DrawBorder(renderContext, innerRect, _paletteBorder, VisualOrientation.Top, buttonState);
            }
        }

        private void InternalRenderer(ref Graphics g, ref Rectangle rect)
        {
            //set colors
            if (_persistentColours == false)
            {
                //init color values
                if (_useStyledColours == true)
                {
                    _gradientStartColour = Color.FromArgb(255, 246, 215);
                    _gradientEndColour = Color.FromArgb(255, 213, 77);
                    _gradientMiddleColour = Color.FromArgb(252, 224, 133);
                }
                else
                {
                    _gradientStartColour = _palette.ColorTable.StatusStripGradientBegin;
                    _gradientEndColour = _palette.ColorTable.OverflowButtonGradientEnd;
                    _gradientMiddleColour = _palette.ColorTable.StatusStripGradientEnd;
                }
            }


            //draw
            DrawingMethods.DrawGradient(g, rect, _gradientStartColour, _gradientEndColour, 90F, _enableSelectionBorder, _gradientMiddleColour, 1);
        }

        private void KryptonRendererHeader(ref Graphics g, ref Rectangle rect, bool bHot, ref DrawListViewColumnHeaderEventArgs e)
        {
            // Get the renderer associated with this palette
            IRenderer renderer = _palette.GetRenderer();

            // we need to find the correct palette state based on if the mouse 
            // is over the control if the mouse button is pressed down or not.
            PaletteState buttonState = PaletteState.Normal;

            buttonState = GetPaletteState(ref e, bHot);

            // Create a rectangle inset, this is where we will draw the node
            Rectangle innerRect = rect;
            Rectangle innerContent = new Rectangle(innerRect.X + 1, innerRect.Y + 1, innerRect.Width - 2, innerRect.Height - 2);

            // Set the style of control we want to draw
            _paletteBack.Style = PaletteBackStyle.ButtonStandalone;
            _paletteBorder.Style = PaletteBorderStyle.HeaderPrimary;
            _paletteContent.Style = PaletteContentStyle.ButtonStandalone;

            //clear contents
            g.FillRectangle(new SolidBrush(this.BackColor), innerRect.X - 1, innerRect.Y, innerRect.Width + 2, innerRect.Height);

            //force disabled mode
            if (this.Enabled == false) buttonState = PaletteState.Disabled;


            // Create the rendering context that is passed into all renderer calls
            using (RenderContext renderContext = new RenderContext(this, g, rect, renderer))
            {
                using (GraphicsPath path = renderer.RenderStandardBorder.GetBackPath(renderContext, innerRect, _paletteBorder, VisualOrientation.Top, buttonState))
                {
                    // Ask renderer to draw the background
                    _momentoBack2 = renderer.RenderStandardBack.DrawBack(renderContext, innerContent, path, _paletteBack, VisualOrientation.Top, buttonState, _momentoBack2);
                }

                // Now we draw the border of the inner area, also in ButtonStandalone style
                renderer.RenderStandardBorder.DrawBorder(renderContext, innerRect, _paletteBorder, VisualOrientation.Top, buttonState);
            }
        }

        private void InternalRendererHeader(ref Graphics g, ref Rectangle rect, bool bHot, ref DrawListViewColumnHeaderEventArgs e)
        {
            //set colors
            Color gradStartColour;
            Color gradEndColour;
            Color gradMiddleColour;
            Color borderColor = _palette.ColorTable.ToolStripBorder;

            if (e.State == ListViewItemStates.Selected)
            {
                gradStartColour = Color.White;// _palette.ColorTable.ButtonSelectedGradientBegin;
                gradMiddleColour = _palette.ColorTable.ButtonCheckedGradientEnd;
                gradEndColour = _palette.ColorTable.ButtonCheckedGradientBegin;

            }
            else
            {
                if (bHot)
                {
                    gradStartColour = Color.White;// _palette.ColorTable.ButtonSelectedGradientBegin;
                    gradMiddleColour = _palette.ColorTable.ButtonSelectedGradientEnd;
                    gradEndColour = _palette.ColorTable.ButtonSelectedGradientBegin;
                }
                else
                {
                    gradStartColour = Color.White;//_palette.ColorTable.ToolStripGradientBegin;
                    gradMiddleColour = _palette.ColorTable.ToolStripGradientEnd;
                    gradEndColour = _palette.ColorTable.ToolStripGradientBegin;
                }
            }
            //Fill Gradient
            using (LinearGradientBrush brush = new LinearGradientBrush(rect, gradStartColour, gradMiddleColour, LinearGradientMode.Vertical))
            {
                if (!_enableHeaderGlow)
                    g.FillRectangle(brush, rect);
                else
                    DrawingMethods.DrawListViewHeader(g, rect, gradStartColour, gradMiddleColour, 90F);
            }

            //DrawBorder
            g.DrawRectangle(new Pen(borderColor), rect);

            //Draw light lines
            //oriz
            g.DrawLine(new Pen(Color.White), new Point(rect.X + 1, rect.Y + 1), new Point(rect.X + rect.Width - 1, rect.Y + 1));
            //vert
            g.DrawLine(new Pen(Color.White), new Point(rect.X + 1, rect.Y + 1), new Point(rect.X + 1, rect.Y + rect.Height - 1));

            if (e.ColumnIndex == this.Columns.Count - 1)
                g.DrawLine(new Pen(borderColor), new Point(rect.X + rect.Width - 1, rect.Y), new Point(rect.X + rect.Width - 1, rect.Y + rect.Height + 0));

        }


        private void HeaderPressedOffset(ref Rectangle rect, ListViewItemStates State)
        {
            //min rect height for SystemColors (Theme disabled)
            if ((int)rect.Height > (int)15)
            {
                //Draw Normal
                if (State == ListViewItemStates.Selected)
                { rect.Offset(3, 3); }
                else
                { rect.Offset(2, 2); }
            }
            else
            {
                //draw a little up
                if (State == ListViewItemStates.Selected)
                { rect.Offset(3, 2); }
                else
                { rect.Offset(2, 1); }
            }
        }
        #endregion

        #region Draw Headers
        protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
        {
            if (!DesignMode)
            {

                if (_enableHeaderRendering == true)
                {
                    Rectangle rect = e.Bounds;
                    rect.Height = rect.Height;// -2;
                    rect.Width = rect.Width - 0;
                    Graphics g = e.Graphics;

                    Point mouse = new Point();
                    mouse = PointToClient(Control.MousePosition);

                    //Header HotTrack
                    bool bHot = false;
                    if (_enableHeaderHotTrack)
                    {
                        //Mod
                        Invalidate();

                        Rectangle mouserect = new Rectangle();
                        mouserect = e.Bounds;
                        mouserect.Width += 2; //expand the rectangle to make the check more stable
                        mouserect.Height += 2;

                        if (mouserect.Contains(mouse))
                            bHot = true;
                    }

                    //ClearType
                    try
                    { e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit; }
                    catch
                    { }


                    //Empty Area
                    g.FillRectangle(new SolidBrush(Color.White), rect);

                    //design with The Correct renderer
                    try
                    {
                        if (_useKryptonRenderer)
                            KryptonRendererHeader(ref g, ref rect, bHot, ref e); //KryptonRendererHeader
                        else
                            InternalRendererHeader(ref g, ref rect, bHot, ref e); //InternalRendererHeader
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                    }

                    //OffSet Header
                    HeaderPressedOffset(ref rect, e.State);

                    //get Colors And Font
                    Color textColor = GetForeTextColourHeader(GetPaletteState(ref e, bHot));
                    Font textFont = GetForeTextFont(GetPaletteState(ref e, bHot));

                    //set text properties
                    StringFormat TextFormat = new StringFormat();
                    TextFormat.FormatFlags = StringFormatFlags.NoWrap;
                    TextFormat.Alignment = ConvertHorizontalAlignmentToStringAlignment(e.Header.TextAlign);

                    //string Ellipsis
                    string ColumnHeaderString = CompactString(e.Header.Text, rect.Width, textFont, TextFormatFlags.EndEllipsis);

                    //draw Text
                    g.DrawString(ColumnHeaderString, textFont, new SolidBrush(textColor), rect, TextFormat);
                    //e.DrawText();


                    //Draw sort indicator
                    if (this.Columns[e.ColumnIndex].Tag != null)
                    {
                        SortOrder sort = (SortOrder)this.Columns[e.ColumnIndex].Tag;

                        // Prepare arrow
                        if (sort == SortOrder.Ascending)
                            g.FillRectangle(new SolidBrush(Color.Red), rect.X + rect.Width - 8, rect.Y, 8, 8);
                        else if (sort == SortOrder.Descending)
                            g.FillRectangle(new SolidBrush(Color.Green), rect.X + rect.Width - 8, rect.Y, 8, 8);
                    }

                }
                else
                    e.DrawDefault = true;

            }
            else
            {
                e.DrawDefault = true;
            }
        }
        #endregion

        #region Helpers
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

        #region Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        // The LVItem being dragged
        private ListViewItem _itemDnD = null;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (_enableDragDrop)
            {
                _itemDnD = GetItemAt(e.X, e.Y);
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (_enableDragDrop)
            {
                if (_itemDnD == null)
                    return;

                try
                {
                    // calculate the bottom of the last item in the LV so that you don't have to stop your drag at the last item
                    int lastItemBottom = Math.Min(e.Y, this.Items[this.Items.Count - 1].GetBounds(ItemBoundsPortion.Entire).Bottom - 1);

                    // use 0 instead of e.X so that you don't have to keep inside the columns while dragging
                    ListViewItem itemOver = this.GetItemAt(0, lastItemBottom);

                    if (itemOver == null)
                        return;

                    Rectangle rc = itemOver.GetBounds(ItemBoundsPortion.Entire);

                    // find out if we insert before or after the item the mouse is over
                    bool insertBefore;
                    if (e.Y < rc.Top + (rc.Height / 2))
                    {
                        insertBefore = true;
                    }
                    else
                    {
                        insertBefore = false;
                    }

                    if (_itemDnD != itemOver) // if we dropped the item on itself, nothing is to be done
                    {
                        if (insertBefore)
                        {
                            this.Items.Remove(_itemDnD);
                            this.Items.Insert(itemOver.Index, _itemDnD);
                        }
                        else
                        {
                            this.Items.Remove(_itemDnD);
                            this.Items.Insert(itemOver.Index + 1, _itemDnD);
                        }
                    }

                    // clear the insertion line
                    this.LineAfter =
                    this.LineBefore = -1;

                    this.Invalidate();

                }
                finally
                {
                    // finish drag&drop operation
                    _itemDnD = null;
                    Cursor = Cursors.Default;
                }
            }

            base.OnMouseUp(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            _hasFocus = true;

            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            _hasFocus = false;

            base.OnLostFocus(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (_enableDragDrop)
            {
                if (_itemDnD == null)
                    return;

                // Show the user that a drag operation is happening
                Cursor = Cursors.Hand;

                // calculate the bottom of the last item in the LV so that you don't have to stop your drag at the last item
                int lastItemBottom = Math.Min(e.Y, this.Items[this.Items.Count - 1].GetBounds(ItemBoundsPortion.Entire).Bottom - 1);

                // use 0 instead of e.X so that you don't have to keep inside the columns while dragging
                ListViewItem itemOver = this.GetItemAt(0, lastItemBottom);

                if (itemOver == null)
                    return;

                Rectangle rc = itemOver.GetBounds(ItemBoundsPortion.Entire);
                if (e.Y < rc.Top + (rc.Height / 2))
                {
                    this.LineBefore = itemOver.Index;
                    this.LineAfter = -1;
                }
                else
                {
                    this.LineBefore = -1;
                    this.LineAfter = itemOver.Index;
                }

                // invalidate the LV so that the insertion line is shown
                Invalidate();
            }

            base.OnMouseMove(e);
        }

        protected override void OnItemMouseHover(ListViewItemMouseHoverEventArgs e)
        {
            base.OnItemMouseHover(e);
        }

        protected override void OnColumnClick(ColumnClickEventArgs e)
        {
            base.OnColumnClick(e);

            if (_enableSorting == true)
            {
                // Determine if clicked column is already the column that is being sorted.
                if (e.Column == lvwColumnSorter.SortColumn)
                {
                    // Reverse the current sort direction for this column.
                    if (lvwColumnSorter.Order == SortOrder.Ascending)
                    {
                        lvwColumnSorter.Order = SortOrder.Descending;
                    }
                    else
                    {
                        lvwColumnSorter.Order = SortOrder.Ascending;
                    }
                }
                else
                {
                    // Set the column number that is to be sorted; default to ascending.
                    lvwColumnSorter.SortColumn = e.Column;
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }

                //set info for sort image
                //CleanColumnsTag();
                //this.Columns[e.Column].Tag = lvwColumnSorter.Order;

                // Perform the sort with these new sort options.
                this.Sort();
            }
        }

        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref Message m)
        {
            //To avoid errors on designer
            if (!DesignMode)
            {
                if (_autoSizeLastColumn)
                {
                    // if the control is in details view mode and columns
                    // have been added, then intercept the WM_PAINT message
                    // and reset the last column width to fill the list view
                    switch (m.Msg)
                    {
                        case Win32.WM_PAINT:
                            if (this.View == View.Details && this.Columns.Count > 0)
                                this.Columns[this.Columns.Count - 1].Width = -2;
                            for (int i = 0; i < this.Columns.Count - 1; i++)
                            {
                                this.Columns[i].Width = this.Columns[i].Width;
                            }
                            if (_enableDragDrop)
                            {
                                if (LineBefore >= 0 && LineBefore < Items.Count)
                                {
                                    Rectangle rc = Items[LineBefore].GetBounds(ItemBoundsPortion.Entire);
                                    DrawInsertionLine(rc.Left, rc.Right, rc.Top);
                                }
                                if (LineAfter >= 0 && LineBefore < Items.Count)
                                {
                                    Rectangle rc = Items[LineAfter].GetBounds(ItemBoundsPortion.Entire);
                                    DrawInsertionLine(rc.Left, rc.Right, rc.Bottom);
                                }
                            }
                            break;

                        case Win32.WM_NCHITTEST:
                            //DRAWITEMSTRUCT dis = (DRAWITEMSTRUCT)Marshal.PtrToStructure(message.LParam, typeof(DRAWITEMSTRUCT));

                            //ColumnHeader ch = this.Columns[dis.itemID];
                            break;
                    }

                }
            }

            // pass messages on to the base control for processing
            base.WndProc(ref m);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_momentoContent != null)
                {
                    _momentoContent.Dispose();
                    _momentoContent = null;
                }

                if (_momentoBack1 != null)
                {
                    _momentoBack1.Dispose();
                    _momentoBack1 = null;
                }

                if (_momentoBack2 != null)
                {
                    _momentoBack2.Dispose();
                    _momentoBack2 = null;
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

        protected override void OnNotifyMessage(Message m)
        {
            if (m.Msg != 0x14)
            {
                base.OnNotifyMessage(m);
            }
        }
        #endregion
    }

    #region ListViewColumnSorter : Class
    internal class ListViewColumnSorter : IComparer
    {
        /// <summary>
        /// Specifies the column to be sorted
        /// </summary>
        private int ColumnToSort;
        /// <summary>
        /// Specifies the order in which to sort (i.e. 'Ascending').
        /// </summary>
        private SortOrder OrderOfSort;
        /// <summary>
        /// Case insensitive comparer object
        /// </summary>
        private CaseInsensitiveComparer ObjectCompare;

        /// <summary>
        /// Class constructor.  Initializes various elements
        /// </summary>
        public ListViewColumnSorter()
        {
            // Initialize the column to '0'
            ColumnToSort = 0;

            // Initialize the sort order to 'none'
            OrderOfSort = SortOrder.None;

            // Initialize the CaseInsensitiveComparer object
            ObjectCompare = new CaseInsensitiveComparer();
        }

        /// <summary>
        /// This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive comparison.
        /// </summary>
        /// <param name="x">First object to be compared</param>
        /// <param name="y">Second object to be compared</param>
        /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem listviewX, listviewY;

            // Cast the objects to be compared to ListViewItem objects
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;

            // Compare the two items
            string itemX;
            try
            {
                itemX = listviewX.SubItems[ColumnToSort].Text;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                itemX = " ";
            }
            string itemY;
            try
            {
                itemY = listviewY.SubItems[ColumnToSort].Text;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                itemY = " ";
            }
            compareResult = ObjectCompare.Compare(itemX, itemY);

            // Calculate correct return value based on object comparison
            if (OrderOfSort == SortOrder.Ascending)
            {
                // Ascending sort is selected, return normal result of compare operation
                return compareResult;
            }
            else if (OrderOfSort == SortOrder.Descending)
            {
                // Descending sort is selected, return negative result of compare operation
                return (-compareResult);
            }
            else
            {
                // Return '0' to indicate they are equal
                return 0;
            }
        }

        /// <summary>
        /// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
        /// </summary>
        public int SortColumn
        {
            set
            {
                ColumnToSort = value;
            }
            get
            {
                return ColumnToSort;
            }
        }

        /// <summary>
        /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
        /// </summary>
        public SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }
    }
    #endregion
}