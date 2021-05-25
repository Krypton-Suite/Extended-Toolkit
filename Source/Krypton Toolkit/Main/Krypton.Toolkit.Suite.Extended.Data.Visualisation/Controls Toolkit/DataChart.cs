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
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    /// <summary>
    /// Summary description for DataChart.
    /// </summary>
    [ToolboxBitmap(typeof(DataChart)), ToolboxItem(true)]
    public class DataChart : UserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        private ArrayList _arrayList;

        private Color _colourLine;
        private Color _colourGrid;

        private int _yMaxInit;
        private int _gridPixel;
        private ChartType _chartType;

        #region Constructor/Dispose
        public DataChart()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            BackColor = Color.Silver;

            _colourLine = Color.DarkBlue;
            _colourGrid = Color.Yellow;

            _yMaxInit = 1000;
            _gridPixel = 0;
            _chartType = ChartType.Stick;

            _arrayList = new ArrayList();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        #endregion

        public void UpdateChart(double d)
        {
            Rectangle rt = this.ClientRectangle;
            int dataCount = rt.Width / 2;

            if (_arrayList.Count >= dataCount)
                _arrayList.RemoveAt(0);

            _arrayList.Add(d);

            Invalidate();
        }

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Name = "DataChart";
            this.Size = new System.Drawing.Size(150, 16);
        }
        #endregion

        #region "Properties"

        [Description("Gets or sets the current Line Colour in chart"), Category("DataChart")]
        public Color LineColour
        {
            get { return _colourLine; }
            set { _colourLine = value; }
        }

        [Description("Gets or sets the current Grid Colour in chart"), Category("DataChart")]
        public Color GridColour
        {
            get { return _colourGrid; }
            set { _colourGrid = value; }
        }

        [Description("Gets or sets the initial maximum Height for sticks in chart"), Category("DataChart")]
        public int InitialHeight
        {
            get { return _yMaxInit; }
            set { _yMaxInit = value; }
        }

        [Description("Gets or sets the current chart Type for stick or Line"), Category("DataChart")]
        public ChartType ChartType
        {
            get { return _chartType; }
            set { _chartType = value; }
        }

        [Description("Enables grid drawing with spacing of the Pixel number"), Category("DataChart")]
        public int GridPixels
        {
            get { return _gridPixel; }
            set { _gridPixel = value; }
        }

        #endregion

        #region Drawing
        protected override void OnPaint(PaintEventArgs e)
        {
            int count = _arrayList.Count;
            if (count == 0) return;

            double y = 0, yMax = InitialHeight;
            for (int i = 0; i < count; i++)
            {
                y = Convert.ToDouble(_arrayList[i]);
                if (y > yMax) yMax = y;
            }

            Rectangle rt = this.ClientRectangle;
            y = yMax == 0 ? 1 : rt.Height / yMax;		// y ratio

            int xStart = rt.Width;
            int yStart = rt.Height;
            int nX, nY;

            Pen pen = null;
            e.Graphics.Clear(BackColor);

            if (GridPixels != 0)
            {
                pen = new Pen(GridColour, 1);
                nX = rt.Width / GridPixels;
                nY = rt.Height / GridPixels;

                for (int i = 1; i <= nX; i++)
                    e.Graphics.DrawLine(pen, i * GridPixels, 0, i * GridPixels, yStart);

                for (int i = 1; i < nY; i++)
                    e.Graphics.DrawLine(pen, 0, i * GridPixels, xStart, i * GridPixels);
            }

            // From the most recent data, so X <--------------|	
            // Get data from _arrayList	 a[0]..<--...a[count-1]

            if (ChartType == ChartType.Stick)
            {
                pen = new Pen(LineColour, 2);

                for (int i = count - 1; i >= 0; i--)
                {
                    nX = xStart - 2 * (count - i);
                    if (nX <= 0) break;

                    nY = (int)(yStart - y * Convert.ToDouble(_arrayList[i]));
                    e.Graphics.DrawLine(pen, nX, yStart, nX, nY);
                }
            }
            else
                if (ChartType == ChartType.Line)
            {
                pen = new Pen(LineColour, 1);

                int nX0 = xStart - 2;
                int nY0 = (int)(yStart - y * Convert.ToDouble(_arrayList[count - 1]));
                for (int i = count - 2; i >= 0; i--)
                {
                    nX = xStart - 2 * (count - i);
                    if (nX <= 0) break;

                    nY = (int)(yStart - y * Convert.ToDouble(_arrayList[i]));
                    e.Graphics.DrawLine(pen, nX0, nY0, nX, nY);

                    nX0 = nX;
                    nY0 = nY;
                }
            }

            base.OnPaint(e);
            pen.Dispose();
        }
        #endregion
    }

    public enum ChartType { Stick, Line }

}