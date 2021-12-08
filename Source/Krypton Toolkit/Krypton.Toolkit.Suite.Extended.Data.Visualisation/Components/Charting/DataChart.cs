#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Collections;

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    [ToolboxBitmap(typeof(DataChart)), ToolboxItem(true)]
    public class DataChart : UserControl
    {
        #region Design Code
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DataChart
            // 
            this.Name = "DataChart";
            this.Size = new System.Drawing.Size(150, 16);
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private Container components = null;

        private ArrayList _arrayList;

        private Color _colourLine, _colourGrid;

        private int _yMaxInit, _gridPixel;

        private ChartType _chartType;
        #endregion

        #region "Properties"

        [Description("Gets or sets the current Line Color in chart"), Category("DataChart")]
        public Color LineColour { get => _colourLine; set => _colourLine = value; }

        [Description("Gets or sets the current Grid Color in chart"), Category("DataChart")]
        public Color GridColour { get => _colourGrid; set => _colourGrid = value; }

        [Description("Gets or sets the initial maximum Height for sticks in chart"), Category("DataChart")]
        public int InitialHeight { get => _yMaxInit; set => _yMaxInit = value; }

        [Description("Gets or sets the current chart Type for stick or Line"), Category("DataChart")]
        public ChartType ChartType { get => _chartType; set => _chartType = value; }

        [Description("Enables grid drawing with spacing of the Pixel number"), Category("DataChart")]
        public int GridPixels { get => _gridPixel; set => _gridPixel = value; }
        #endregion

        #region Constructor
        public DataChart()
        {
            InitializeComponent();

            BackColor = Color.Silver;

            _colourLine = Color.DarkBlue;

            _colourGrid = Color.Yellow;

            _yMaxInit = 1000;

            _gridPixel = 0;

            _chartType = ChartType.STICK;

            _arrayList = new ArrayList();
        }
        #endregion

        #region Overrides
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

            if (ChartType == ChartType.STICK)
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
                if (ChartType == ChartType.LINE)
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

        #region Methods
        public void UpdateChart(double value)
        {
            Rectangle rectangle = ClientRectangle;

            int dataCount = rectangle.Width / 2;

            if (_arrayList.Count >= dataCount)
            {
                _arrayList.RemoveAt(0);
            }

            _arrayList.Add(value);

            Invalidate();
        }
        #endregion
    }
}