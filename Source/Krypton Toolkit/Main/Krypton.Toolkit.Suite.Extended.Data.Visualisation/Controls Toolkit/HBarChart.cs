#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    [ToolboxBitmap(typeof(PerformanceCounter))]
    public class HBarChart : UserControl
    {
        #region Properties

        // Description line at the bottom of the chart
        private CDescriptionProperty description;
        public CDescriptionProperty Description
        {
            get { return description; }
            set { description = value; }
        }

        private CLabelProperty label;
        public CLabelProperty Label
        {
            get { return label; }
            set { label = value; }
        }

        private CValueProperty values;
        public CValueProperty Values
        {
            get { return values; }
            set { values = value; }
        }

        private CBackgroundProperty background;
        public CBackgroundProperty Background
        {
            get { return background; }
            set { background = value; }
        }

        private int nBarWidth;
        public int BarWidth
        {
            get { return nBarWidth; }

            set
            {
                nBarWidth = value;
                this.Refresh();
            }
        }
        /*
        private Font fontTooltip;
        public Font FontTooltip
        {
            get { return fontTooltip; }
            set { fontTooltip = value; }
        }
        */
        // Space between bars of the bar graph
        private int nBarsGap;
        public int BarsGap
        {
            get { return nBarsGap; }
            set { nBarsGap = value; }
        }

        public enum BarSizingMode
        {
            Normal,         // Use variable values for width of the bar
            AutoScale       // Automatically calculate the bounding rectangle and fit all bars inside the control
        }
        public BarSizingMode SizingMode;

        #endregion //"Properties"

        // A collection of all bars data
        protected HItems bars;

        // Tooltip of the chart
        protected ToolTip tooltip;

        // A back buffer for double buffering to have flicker-free drawing
        private Bitmap bmpBackBuffer;

        #region "Designer stuff"

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // HBarChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Name = "HBarChart";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            this.Resize += new System.EventHandler(this.OnSize);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            this.ResumeLayout(false);

        }

        #endregion        

        #endregion

        public void RedrawChart()
        {
            if (bmpBackBuffer != null)
            {
                bmpBackBuffer.Dispose();
                bmpBackBuffer = null;
            }
            this.Refresh();
        }

        public void Add(double dValue, string strLabel, Color colorBar)
        {
            bars.Add(dValue, strLabel, colorBar);
        }

        public bool RemoveAt(int nIndex)
        {
            return bars.RemoveAt(nIndex);
        }

        public int Count
        {
            get { return bars.Count; }
        }

        public bool GetAt(int nIndex, out HBarData bar)
        {
            return bars.GetAt(nIndex, out bar);
        }


        // Constructor
        public HBarChart()
        {
            // Designer
            InitializeComponent();

            description = new CDescriptionProperty();
            label = new CLabelProperty();
            values = new CValueProperty();
            background = new CBackgroundProperty();

            // Initialize members
            nBarWidth = 24;
            nBarsGap = 4;

            SizingMode = BarSizingMode.Normal;

            //fontTooltip = new Font("Verdana", 12);

            bars = new HItems();

            bmpBackBuffer = null;

            tooltip = new ToolTip();
            tooltip.IsBalloon = true;
            tooltip.ShowAlways = true;
            tooltip.InitialDelay = 0;
            tooltip.ReshowDelay = 0;
            tooltip.AutoPopDelay = Int16.MaxValue;
        }


        // Control needs repainting
        private void OnPaint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (bmpBackBuffer == null)
            {
                // Redraw the char into back buffer
                DrawChart(ref bmpBackBuffer);
            }

            // Blot the buffer to view
            if (bmpBackBuffer != null)
            {
                e.Graphics.DrawImageUnscaled(bmpBackBuffer, 0, 0);
            }
        }

        // Draws a chart on the given bitmap
        private void DrawChart(ref Bitmap bmp)
        {

            if (bmp == null)
            {
                bmp = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            }

            using (Graphics gr = Graphics.FromImage(bmp))
            {
                // Draw background
                DrawBackground(gr, bmp);

                //Draw graph and all texts
                DrawBars(gr, bmp);
            }
        }

        private void DrawBackground(Graphics gr, Bitmap bmpChart)
        {
            if (Background.PaintingMode == CBackgroundProperty.PaintingModes.LinearGradient)
            {
                LinearGradientBrush br = new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(0, bmpChart.Height),
                    Background.GradientColor1, Background.GradientColor2);

                gr.FillRectangle(br, new Rectangle(0, 0, bmpChart.Width, bmpChart.Height));
            }
            else if (Background.PaintingMode == CBackgroundProperty.PaintingModes.SolidColor)
            {
                gr.FillRectangle(new SolidBrush(Background.SolidColor), new Rectangle(0, 0, bmpChart.Width, bmpChart.Height));
            }
            else
            {
                gr.FillRectangle(new SolidBrush(Background.SolidColor), new Rectangle(0, 0, bmpChart.Width, bmpChart.Height));
            }
        }

        private void DrawBars(Graphics gr, Bitmap bmpChart)
        {
            #region Variables
            HBarData bar;
            RectangleF rectBar = new Rectangle();
            SizeF sizeDesc = Size.Empty;
            SizeF sizeBar = Size.Empty;
            float nLabelHeight = 0;
            float fValueHeight = 0;
            float nStartX = 0;
            #endregion

            if (description == null) return;
            if (label == null) return;
            if (values == null) return;

            // Store some original values
            #region StoreObjects

            int nLastBarGaps = nBarsGap;
            //Font fntTip = fontTooltip;

            Description.SaveObject();
            Label.SaveObject();
            Values.SaveObject();

            #endregion

            #region Calculations
            if (SizingMode == BarSizingMode.AutoScale)
            {
                // Calculate gap size
                if (bars.Count > 0) nBarsGap = 4 + (12 * bmpChart.Size.Width) / (int)(345 * bars.Count * 7);
                if (nBarsGap > 50) nBarsGap = 50;

                // Calculate maximum bar size
                sizeBar = new SizeF(this.nBarWidth, bmpChart.Size.Height - 2 * nBarsGap);
                if (bars.Count > 0) sizeBar.Width = (bmpChart.Size.Width - ((bars.Count + 1) * nBarsGap)) / bars.Count;
                if (sizeBar.Width <= 0) sizeBar.Width = 24;

                // Calcuate font sizes & create fonts
                CreateLabelFont(gr, sizeBar);
                nLabelHeight = Label.Font.GetHeight(gr);

                CreateValueFont(gr, sizeBar);
                fValueHeight = Values.Font.GetHeight(gr);

                CreateDescFont(gr, bmpChart.Size);
                sizeDesc = new SizeF(bmpChart.Size.Width - 2 * nBarsGap, description.Font.GetHeight(gr) + 2 * nBarsGap);

                // Calculate actual bar size (depends to font sizes)
                if (description.Visible) sizeBar.Height -= sizeDesc.Height;
                if (Label.Visible) sizeBar.Height -= nLabelHeight;
                if (Values.Visible) sizeBar.Height -= fValueHeight;
                nStartX = this.ClientRectangle.Left;
            }
            else if (SizingMode == BarSizingMode.Normal)
            {
                //fontTooltip = fntTip;
                Values.RestoreObject();
                nBarsGap = nLastBarGaps;

                Description.RestoreObject();
                Label.RestoreObject();

                float fFntHeight = description.Font.GetHeight(gr) + 2 * nBarsGap;
                sizeDesc = new SizeF(bmpChart.Size.Width - 2 * nBarsGap, fFntHeight);

                nLabelHeight = Label.Font.GetHeight(gr);
                fValueHeight = Values.Font.GetHeight(gr);

                sizeBar = new SizeF(this.nBarWidth, bmpChart.Size.Height - 2 * nBarsGap);
                if (Description.Visible) sizeBar.Height -= sizeDesc.Height;
                if (Label.Visible) sizeBar.Height -= nLabelHeight;
                if (Values.Visible) sizeBar.Height -= fValueHeight;

                // Bars start from here (This align graph to the center of the control)
                nStartX = (bmpChart.Size.Width - bars.Count * sizeBar.Width - (bars.Count + 1) * nBarsGap) / 2;
            }
            #endregion

            // Draw description label
            if (description.Visible)
            {

                StringFormat stringFormat = StringFormat.GenericDefault;
                stringFormat.LineAlignment = StringAlignment.Center;
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.Trimming = StringTrimming.None;
                stringFormat.FormatFlags = StringFormatFlags.NoWrap |
                                            StringFormatFlags.LineLimit;

                gr.DrawString(
                    description.Text,
                    description.Font,
                    new SolidBrush(description.Colour),
                    new RectangleF(
                        nBarsGap,
                        bmpChart.Height - sizeDesc.Height,
                        sizeDesc.Width,
                        sizeDesc.Height),
                        stringFormat);
            }

            // Draw bars (A bar, label and it's value)
            for (int i = 0; i < bars.Count; i++)
            {
                if (bars.GetAt(i, out bar))
                {
                    rectBar.Width = sizeBar.Width;
                    rectBar.Height = (float)((bar.Value * sizeBar.Height) / bars.MaxValue);
                    rectBar.X = nStartX + i * sizeBar.Width + (i + 1) * nBarsGap;
                    rectBar.Y = nBarsGap + sizeBar.Height - rectBar.Height;
                    if (Values.Visible) rectBar.Y += fValueHeight;


                    // Set this bar rectangle area on screen. This will be used later for displaying
                    // tooltips for example. Note that the saved value is not the bar bounding rectangle
                    // it's the rectangle that bar is drawn inside, so height might be longer than
                    // the bar.
                    // If you need to have exact rectangle, replace current value with commented value below
                    bar.BarRect = new RectangleF(rectBar.Left, /*rectBar.Top*/0, sizeBar.Width, /*sizeBar.Height*/ this.ClientRectangle.Height);

                    DrawBar(gr, rectBar, bar);
                }
            }

            // restore values that changed during the transition to auto scale mode
            #region RestoreObjects

            nBarsGap = nLastBarGaps;
            //fontTooltip = fntTip;
            Description.RestoreObject();
            Label.RestoreObject();
            Values.RestoreObject();

            #endregion
        }

        private void CreateValueFont(Graphics gr, SizeF sizeBar)
        {
            // Set font style
            string strFontName;
            FontStyle fntStyle;
            float fFontSize = 100 + (sizeBar.Width / 24);
            if (fFontSize <= 0) fFontSize = 1;

            if (Values.Font == null)
            {
                strFontName = "Tahoma";
                fntStyle = FontStyle.Regular;
            }
            else
            {
                strFontName = Values.Font.Name;
                fntStyle = Values.Font.Style;
            }

            Values.Font = new Font(strFontName, fFontSize, fntStyle);

            // Get lengthiest label
            HBarData bar = null;
            string strValue = string.Empty;
            string strLargestValue = string.Empty;
            double dTotal = bars.TotalValue;
            for (int i = 0; i < bars.Count; i++)
            {
                if (bars.GetAt(i, out bar))
                {
                    if (Values.Mode == CValueProperty.ValueMode.Digit)
                    {
                        strValue = String.Format("{0:F1}", bar.Value);
                    }
                    else if (Values.Mode == CValueProperty.ValueMode.Percent)
                    {
                        if (dTotal > 0) strValue = ((double)(bar.Value / dTotal)).ToString("P1", System.Globalization.CultureInfo.CurrentCulture);
                    }

                    if (strValue.Length > strLargestValue.Length)
                    {
                        strLargestValue = strValue;
                    }
                }
            }

            SizeF sizeText = gr.MeasureString(strValue, Values.Font);

            // Fit text in client area if needed
            if (sizeText.Width > sizeBar.Width)
            {
                float fWidthRatio = sizeBar.Width / sizeText.Width;
                fFontSize = (Values.Font.Size * fWidthRatio);

                // Recreate font if needed
                if (fFontSize > 0)
                {
                    Values.Font.Dispose();
                    Values.Font = null;
                    Values.Font = new Font(strFontName, fFontSize, fntStyle);
                }
            }
        }

        private void CreateLabelFont(Graphics gr, SizeF sizeBar)
        {
            float fFontSize = 100 + (sizeBar.Width / 24);
            if (fFontSize <= 0) fFontSize = 1;


            // Set font style
            string strFontName;
            FontStyle fntStyle;

            if (Label.Font == null)
            {
                strFontName = "Tahoma";
                fntStyle = FontStyle.Regular;
            }
            else
            {
                strFontName = Label.Font.Name;
                fntStyle = Label.Font.Style;
            }

            Label.Font = new Font(strFontName, fFontSize, fntStyle);

            // Get lengthiest label
            HBarData bar = null;
            SizeF sizeMax = new SizeF(0, 0);
            SizeF sizeText;
            for (int i = 0; i < bars.Count; i++)
            {
                if (bars.GetAt(i, out bar))
                {
                    sizeText = gr.MeasureString(bar.Label, Label.Font);
                    if (sizeText.Width > sizeMax.Width)
                    {
                        sizeMax = sizeText;
                    }
                }
            }

            sizeText = sizeMax;

            // Fit text in client area if needed
            if (sizeText.Width > sizeBar.Width)
            {
                float fWidthRatio = sizeBar.Width / sizeText.Width;
                fFontSize = (Label.Font.Size * fWidthRatio);

                // Recreate font if needed
                if (fFontSize > 0)
                {
                    Label.Font.Dispose();
                    Label.Font = null;
                    Label.Font = new Font(strFontName, fFontSize, fntStyle);
                }
            }
        }

        // Calculates best size for description font and creates it. used in auto scaling mode
        private void CreateDescFont(Graphics gr, SizeF sizeBound)
        {
            // A default size to make sure height is far more smaller than bounding rectangle
            float fFontSize = sizeBound.Height / 15;
            if (fFontSize <= 0) fFontSize = 1;

            // Set font style
            string strFontName;
            FontStyle fntStyle;

            if (description.Font == null)
            {
                strFontName = "Tahoma";
                fntStyle = FontStyle.Regular;
            }
            else
            {
                strFontName = description.Font.Name;
                fntStyle = description.Font.Style;
            }

            // Create the font
            description.Font = new Font(strFontName, fFontSize, fntStyle);
            SizeF sizeText = gr.MeasureString(description.Text, description.Font);

            // Fit text in client area if needed
            if (sizeText.Width > sizeBound.Width)
            {
                float fWidthRatio = (sizeBound.Width - 2 * nBarsGap) / sizeText.Width;
                fFontSize = (description.Font.Size * fWidthRatio);

                // Recreate font if needed
                if (fFontSize > 0)
                {
                    description.Font.Dispose();
                    description.Font = null;
                    description.Font = new Font(strFontName, fFontSize, fntStyle);
                }
            }
        }

        // Draw a bar with label & valu using specified index bouned to the 
        // specified rectangle of the selected bitmap of specified graphics object
        private void DrawBar(Graphics gr, RectangleF rectBar, HBarData bar)
        {
            // Some calculations
            if (rectBar.Height <= 0) rectBar.Height = 1;
            int nAlphaStart = (int)(185 + 5 * rectBar.Width / 24),
                nAlphaEnd = (int)(10 + 4 * rectBar.Width / 24);

            if (nAlphaStart > 255) nAlphaStart = 255;
            else if (nAlphaStart < 0) nAlphaStart = 0;

            if (nAlphaEnd > 255) nAlphaEnd = 255;
            else if (nAlphaEnd < 0) nAlphaEnd = 0;


            Color ColorBacklight = bar.Colour;
            Color ColorBacklightEnd = Color.FromArgb(50, 0, 0, 0);
            Color ColorGlowStart = Color.FromArgb(nAlphaEnd, 255, 255, 255);
            Color ColorGlowEnd = Color.FromArgb(nAlphaStart, 255, 255, 255);
            Color ColorFillBK = GetDarkerColor(bar.Colour, 85);
            Color ColorBorder = GetDarkerColor(bar.Colour, 100);

            // Draw a single bar.
            #region BarItself
            RectangleF er = new RectangleF(rectBar.Left, rectBar.Top - rectBar.Height / 2, rectBar.Width * 2, rectBar.Height * 2);
            GraphicsPath rctPath = new GraphicsPath();
            rctPath.AddEllipse(er);

            PathGradientBrush pgr = new PathGradientBrush(rctPath);
            pgr.CenterPoint = new PointF(rectBar.Right, rectBar.Top + rectBar.Height / 2);
            pgr.CenterColor = ColorBacklight;
            pgr.SurroundColors = new Color[] { ColorBacklightEnd };

            RectangleF rectGlow = new RectangleF(rectBar.Left, rectBar.Top, rectBar.Width / 2, rectBar.Height);
            LinearGradientBrush brGlow = new LinearGradientBrush(
                new PointF(rectGlow.Right + 1, rectGlow.Top), new PointF(rectGlow.Left - 1, rectGlow.Top),
                ColorGlowStart, ColorGlowEnd);

            gr.FillRectangle(new SolidBrush(ColorFillBK), rectBar);
            //gr.FillRectangle(new SolidBrush(Color.FromArgb(255, 0, 0, 0)), rectBar);
            gr.FillRectangle(pgr, rectBar);
            gr.FillRectangle(brGlow, rectGlow);
            gr.DrawRectangle(new Pen(ColorBorder, 1), rectBar.Left, rectBar.Top, rectBar.Width, rectBar.Height);
            #endregion

            // Draw label
            if (Label.Visible)
            {
                float nLabelHeight = Label.Font.GetHeight(gr);
                gr.DrawString(
                    bar.Label,
                    Label.Font,
                    new SolidBrush(Label.Colour),
                    new RectangleF(
                        rectBar.X,
                        rectBar.Bottom + nBarsGap,
                        rectBar.Width,
                        nLabelHeight));
            }

            // Draw value or %
            if (Values.Visible)
            {
                string strValue = string.Empty;
                if (Values.Mode == CValueProperty.ValueMode.Digit)
                {
                    strValue = bar.Value.ToString("F1");
                }
                else if (Values.Mode == CValueProperty.ValueMode.Percent)
                {
                    double dTotal = bars.TotalValue;
                    if (dTotal > 0) strValue =
                        ((double)(bar.Value / dTotal)).ToString("P1",
                        System.Globalization.CultureInfo.CurrentCulture);
                }

                float fValueHeight = Values.Font.GetHeight(gr);
                gr.DrawString(
                    strValue,
                    Values.Font,
                    new SolidBrush(Values.Color),
                    new RectangleF(
                        rectBar.X,
                        rectBar.Top - fValueHeight - 1,
                        rectBar.Width + 2 * nBarsGap,
                        fValueHeight));
            }
        }

        // Decrease all RGB values as much as 'intensity' says
        private Color GetDarkerColor(Color color, byte intensity)
        {
            int r, g, b;

            r = color.R - intensity;
            g = color.G - intensity;
            b = color.B - intensity;

            if (r > 255 || r < 0) r *= -1;
            if (g > 255 || g < 0) g *= -1;
            if (b > 255 || b < 0) b *= -1;

            return Color.FromArgb(255, (byte)r, (byte)g, (byte)b);
        }

        // Redraw the chart
        private void OnSize(object sender, EventArgs e)
        {
            RedrawChart();
        }

        // Do nothing
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {

            //Don't allow the background to paint = reduce flicker

        }

        // Why this function is called when mouse is not moving but 
        // we are hiding/showing the tooltip?
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            //To verify when this function is called & 
            //because adding a breakpoint drives me crazy: I have to constantly press F5
            /*
            Random r = new Random();
            System.Diagnostics.Debug.WriteLine(String.Format("{0}", r.Next()));
            */

            HBarData bar;
            string strCaption = string.Empty;
            double dTotal = bars.TotalValue;
            string strPercent = string.Empty;

            for (int i = 0; i < bars.Count; i++)
            {
                if (bars.GetAt(i, out bar))
                {
                    if (bar.BarRect.Contains(e.Location))
                    {
                        if (dTotal > 0)
                        {
                            strPercent = ((double)(bar.Value / dTotal)).
                                ToString("P2", System.Globalization.CultureInfo.CurrentCulture);
                        }

                        strCaption = String.Format("{0}\r\n{1}",
                            bar.Value,
                            strPercent);
                        tooltip.Hide(this);
                        tooltip.RemoveAll();

                        tooltip.ToolTipTitle = bar.Label;
                        tooltip.SetToolTip(this, strCaption.ToString());

                        return;
                    }
                }
            }

            tooltip.Hide(this);
            tooltip.RemoveAll();
        }

        // Simplest print function: WYSIWYG
        public bool Print(bool bFitToPaper, string strDocName)
        {
            CPrinter printer = new CPrinter();

            // Ask user to select a printer and set options for it
            printer.ShowOptions();

            // Customize the document and sizing mode
            printer.Document.DocumentName = strDocName;
            printer.FitToPaper = bFitToPaper;

            // Create and prepare a bitmap to be printed into printer DC
            Bitmap bmpChart;
            if (bFitToPaper)
            {
                // Full screen
                bmpChart = new Bitmap(
                    printer.Document.DefaultPageSettings.Bounds.Width,
                    printer.Document.DefaultPageSettings.Bounds.Height);
            }
            else
            {
                // WYSIWYG
                bmpChart = (Bitmap)bmpBackBuffer.Clone();
            }
            // Draw On the bitmap
            DrawChart(ref bmpChart);

            // Set bitmap for printing
            printer.BmpBuffer = bmpChart;

            // Ask printer class to print its bitmap.
            bool bRet = false;
            bRet = printer.Print();

            // Remove bitmap from memory
            bmpChart.Dispose();
            bmpChart = null;

            return bRet;
        }

    }

    // Holds information about a single bar of the bar chart.
    public class HBarData
    {
        protected RectangleF rectBar;
        public RectangleF BarRect
        {
            get { return rectBar; }
            set { rectBar = value; }
        }

        protected Color colourBar;
        public Color Colour
        {
            get { return colourBar; }
            set { colourBar = value; }
        }

        protected string strLabel;
        [Localizable(true)]
        public string Label
        {
            get { return strLabel; }
            set { strLabel = value; }
        }

        protected double dValue;
        public double Value
        {
            get { return dValue; }
            set { dValue = value; }
        }

        public HBarData(double dValue, string strLabel, Color colorBar)
        {
            this.dValue = dValue;
            this.strLabel = strLabel;
            this.colourBar = colorBar;

            Random r = new Random();
            colorBar = Color.FromArgb(r.Next(16777215));

            dValue = 0;

            strLabel = string.Empty;
        }

        public HBarData()
        {
            Random r = new Random();
            colourBar = Color.FromArgb(r.Next(16777215));

            dValue = 0;

            strLabel = string.Empty;
        }
    }

    // Holds all bar objects of the chart
    public class HItems
    {
        // Wish I had enough time to create my own class and don't to use an ArrayList
        private ArrayList arrItem;
        private ArrayList Items
        {
            get { return arrItem; }
            set { arrItem = value; }
        }

        //Holding maximum value to speedup later calculations
        private double dMaximumValue;

        // Constructor
        public HItems()
        {
            arrItem = new ArrayList();
            dMaximumValue = 0;
        }



        // Add a new bar item
        protected void AddItem(HBarData item)
        {
            arrItem.Add(item);

            // Set first value as the maximum. If control modified to support negeative numbers
            // This will help to calculate true maximum, the reason is that the default is 0
            // which is always bigger than negative values, thus it's always bigger than all
            // values, while maximum value of array is something else(it's also negative) not 0
            if (arrItem.Count == 1)
            {
                dMaximumValue = item.Value;
            }
            else if (dMaximumValue < item.Value)
            {
                dMaximumValue = item.Value;
            }
        }

        // Add a new bar
        protected void AddItem(double dValue, string strLabel, Color colorBar)
        {
            HBarData item = new HBarData(dValue, strLabel, colorBar);
            AddItem(item);
        }

        // Insert a bar item at a specified index
        protected void InsertItem(int nIndex, HBarData item)
        {
            arrItem.Insert(nIndex, item);
            if (dMaximumValue < item.Value)
            {
                dMaximumValue = item.Value;
            }
        }

        // Insert a bar at a specified index
        protected void InsertItem(int nIndex, double dValue, string strLabel, Color colorBar)
        {
            HBarData item = new HBarData(dValue, strLabel, colorBar);
            InsertItem(nIndex, item);
        }

        // Remove an item from a specified index
        protected void RemoveItem(int nIndex)
        {
            // Get the value for later calculations
            double dValue = ((HBarData)arrItem[nIndex]).Value;

            arrItem.RemoveAt(nIndex);
            // If removing maximum item, maximum mustbe recalculated
            if (dValue == dMaximumValue)
            {
                // Recalculate maximum value in array
                CalculteMaximum();
            }

        }

        protected void CalculteMaximum()
        {
            if (arrItem.Count <= 0) return;

            dMaximumValue = ((HBarData)arrItem[0]).Value;
            for (int i = 0; i < arrItem.Count; i++)
            {
                if (dMaximumValue < ((HBarData)arrItem[i]).Value)
                {
                    dMaximumValue = ((HBarData)arrItem[i]).Value;
                }
            }
        }



        // Add a bar to the end of the list
        public void Add(double dValue, string strLabel, Color colorBar)
        {
            AddItem(dValue, strLabel, colorBar);
        }

        // Insert a bar at a specified index
        public bool SetAt(int nIndex, double dValue, string strLabel, Color colorBar)
        {
            if (nIndex < 0 || arrItem.Count < nIndex) return false;
            else if (arrItem.Count == nIndex)
            {
                AddItem(dValue, strLabel, colorBar);
                return true;
            }
            else
            {
                InsertItem(nIndex, dValue, strLabel, colorBar);
                return true;
            }
        }

        // Get a bar value
        public bool GetAt(int nIndex, out double dValue)
        {
            dValue = 0;
            if (nIndex < 0 || arrItem.Count <= nIndex) return false;

            dValue = ((HBarData)arrItem[nIndex]).Value;
            return true;
        }

        // Get a bar item
        public bool GetAt(int nIndex, out HBarData bar)
        {
            bar = null;
            if (nIndex < 0 || arrItem.Count <= nIndex) return false;

            bar = ((HBarData)arrItem[nIndex]);
            return true;
        }

        // Remove a bar
        public bool RemoveAt(int nIndex)
        {
            if (nIndex < 0 || arrItem.Count <= nIndex) return false;

            RemoveItem(nIndex);
            return true;
        }

        // Get number of bars
        public int Count
        {
            get { return arrItem.Count; }
        }

        // Get maximum value of bars vaues
        public double MaxValue
        {
            get { return dMaximumValue; }
        }

        // Get total value of summation all bars
        public double TotalValue
        {
            get
            {
                double dTotal = 0;
                for (int i = 0; i < arrItem.Count; i++)
                {
                    dTotal += ((HBarData)arrItem[i]).Value;
                }

                return dTotal;
            }
        }
    }

    // A set of classes for storing GUI elements and properties in BarChart class
    public class CDescriptionProperty
    {
        private string text;
        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        private bool bVisible;
        public bool Visible
        {
            get { return bVisible; }
            set { bVisible = value; }
        }

        private Font font;
        public Font Font
        {
            get { return font; }
            set { font = value; }
        }

        private Color colour;
        public Color Colour
        {
            get { return colour; }
            set { colour = value; }
        }

        public CDescriptionProperty()
        {

            Font = new Font("Tahoma", 14, FontStyle.Bold);
            Colour = Color.FromArgb(255, 255, 255, 255);
            Text = string.Empty;
            Visible = true;
        }

        private CDescriptionProperty m_clone = null;

        public void SaveObject()
        {
            m_clone = new CDescriptionProperty();
            m_clone.Text = this.Text;
            m_clone.Visible = this.Visible;
            m_clone.Font = this.Font;
            m_clone.Colour = this.Colour;
        }

        public void RestoreObject()
        {
            if (m_clone != null)
            {
                this.Text = m_clone.Text;
                this.Visible = m_clone.Visible;
                this.Font = m_clone.Font;
                this.Colour = m_clone.Colour;
            }
        }
    }

    public class CLabelProperty
    {
        private bool bVisible;
        public bool Visible
        {
            get { return bVisible; }
            set { bVisible = value; }
        }

        private Font font;
        public Font Font
        {
            get { return font; }
            set { font = value; }
        }

        private Color colour;
        public Color Colour
        {
            get { return colour; }
            set { colour = value; }
        }

        public CLabelProperty()
        {

            Font = new Font("Tahoma", 8, FontStyle.Bold);
            Colour = Color.FromArgb(255, 255, 255, 255);
            Visible = true;
        }

        private CLabelProperty m_clone = null;

        public void SaveObject()
        {
            m_clone = new CLabelProperty();
            m_clone.Visible = this.Visible;
            m_clone.Font = this.Font;
            m_clone.Colour = this.Colour;
        }

        public void RestoreObject()
        {
            if (m_clone != null)
            {
                this.Visible = m_clone.Visible;
                this.Font = m_clone.Font;
                this.Colour = m_clone.Colour;
            }
        }
    }

    public class CValueProperty
    {
        private bool bVisible;
        public bool Visible
        {
            get { return bVisible; }
            set { bVisible = value; }
        }

        private Font font;
        public Font Font
        {
            get { return font; }
            set { font = value; }
        }

        private Color color;
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        public enum ValueMode
        {
            Digit,      // Display the value of each bar at the top of it
            Percent     // Display a percentage depending on the other values
        }
        private ValueMode mode;
        public ValueMode Mode
        {
            get { return mode; }
            set { mode = value; }
        }

        public CValueProperty()
        {
            Mode = ValueMode.Digit;
            Font = new Font("Tahoma", 7);
            Color = Color.FromArgb(255, 255, 255, 255);
            Visible = true;
        }

        private CValueProperty m_clone = null;

        public void SaveObject()
        {
            m_clone = new CValueProperty();
            m_clone.Visible = this.Visible;
            m_clone.Font = this.Font;
            m_clone.Color = this.Color;
            m_clone.Mode = this.Mode;
        }

        public void RestoreObject()
        {
            if (m_clone != null)
            {
                this.Visible = m_clone.Visible;
                this.Font = m_clone.Font;
                this.Color = m_clone.Color;
                this.Mode = m_clone.Mode;
            }
        }
    }

    public class CBackgroundProperty
    {
        // Firs Gradient color( at the moment top)
        private Color gradientColor1;
        public Color GradientColor1
        {
            get { return gradientColor1; }
            set { gradientColor1 = value; }
        }

        // Second gradient color (at the moment, bottom)
        private Color gradientColor2;
        public Color GradientColor2
        {
            get { return gradientColor2; }
            set { gradientColor2 = value; }
        }

        // Color for solid background
        private Color solidColor;
        public Color SolidColor
        {
            get { return solidColor; }
            set { solidColor = value; }
        }

        // How to paint background
        public enum PaintingModes
        {
            SolidColor,
            LinearGradient
        }

        private PaintingModes paintingMode;
        public PaintingModes PaintingMode
        {
            get { return paintingMode; }
            set { paintingMode = value; }
        }

        public CBackgroundProperty()
        {
            paintingMode = PaintingModes.LinearGradient;
            gradientColor1 = Color.FromArgb(255, 200, 210, 255);
            gradientColor2 = Color.FromArgb(255, 100, 100, 155);
            solidColor = gradientColor2;
        }
    }

    // A print helper class for a bitmap buffer. Landscape or portrate, but
    // does NOT support any angles in between. It does not check for maximum printable
    // pages, which I think might cause spoolsv.exe to fail if overflows.
    public class CPrinter
    {
        private Bitmap bmpBuffer;
        public Bitmap BmpBuffer
        {
            get { return bmpBuffer; }
            set { bmpBuffer = value; }
        }

        private int nPageCount;
        public int PageCount
        {
            get { return nPageCount; }
            set { nPageCount = value; }
        }

        private int nPagesPrinted;
        public int PagesPrinted
        {
            get { return nPagesPrinted; }
            set { nPagesPrinted = value; }
        }

        private PrintDocument document;
        public PrintDocument Document
        {
            get { return document; }
            set { /*document = value;*/ }
        }

        private bool bFitToPaper;
        public bool FitToPaper
        {
            get { return bFitToPaper; }
            set { bFitToPaper = value; }
        }

        public CPrinter()
        {
            //printSettings = new PrinterSettings();
            bmpBuffer = null;

            document = new PrintDocument();
            document.PrintPage += new PrintPageEventHandler(this.OnPrintPage);
        }

        public bool ShowOptions()
        {
            bool ret = false;

            DialogResult res;
            PrintDialog pdlg;

            pdlg = new PrintDialog();
            pdlg.Document = document;
            pdlg.UseEXDialog = true;

            res = pdlg.ShowDialog();
            if (res == DialogResult.OK || res == DialogResult.Yes)
            {
                ret = true;
            }
            pdlg.Dispose();
            pdlg = null;

            return ret;
        }

        public bool Print()
        {
            if (BmpBuffer == null) return false;

            PageCount = 0;

            document.Print();

            return true;
        }

        private void OnPrintPage(object sender, PrintPageEventArgs e)
        {
            if (FitToPaper)
            {
                e.Graphics.DrawImage(
                    BmpBuffer,
                    e.PageBounds,
                    new Rectangle(
                    0,
                    0,
                    BmpBuffer.Width,
                    BmpBuffer.Height),
                    GraphicsUnit.Pixel);
            }
            else
            {
                e.Graphics.DrawImageUnscaled(
                    BmpBuffer,
                    e.PageBounds.Left,
                    e.PageBounds.Top);
            }

            e.HasMorePages = false;
            /*
            // Prepare for next pageas
            PagesPrinted++;
            if (PagesPrinted >= PageCount)
            {
                e.HasMorePages = false;
                BmpBuffer.Dispose();
                BmpBuffer = null;
            }
            else e.HasMorePages = true;
             */
        }
    }
}