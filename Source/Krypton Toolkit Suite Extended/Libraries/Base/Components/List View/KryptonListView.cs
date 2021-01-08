using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            throw new NotImplementedException();
        }

        private void OnPalettePaint(object sender, PaletteLayoutEventArgs e)
        {
            throw new NotImplementedException();
        }
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
                    _momentoBack2 = renderer.RenderStandardBack.DrawBack(renderContext, innerContent, path, _paletteBack, VisualOrientation.Top, buttonState, _mementoBack2);
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
    }

    #region ListViewColumnSorter : Class
    internal class ListViewColumnSorter
    {

    }
    #endregion
}