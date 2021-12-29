using System;
using System.Drawing;

using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot;

namespace DataVisualisation.ScottPlot.Demos
{
    public partial class TransparentBackground : KryptonForm
    {
        public TransparentBackground()
        {
            InitializeComponent();

            int pointCount = 51;
            double[] x = DataGen.Consecutive(pointCount);
            double[] sin = DataGen.Sin(pointCount);
            double[] cos = DataGen.Cos(pointCount);

            formsPlot1.Plot.AddScatter(x, sin);
            formsPlot1.Plot.AddScatter(x, cos);

            formsPlot1.Plot.Style(figureBackground: Color.Transparent, dataBackground: Color.Transparent);
            formsPlot1.BackColor = Color.Transparent;
            kbtnImage_Click(null, null);
        }

        private void SetBackground(Color bgcolor)
        {
            BackgroundImage = null;
            BackColor = bgcolor;
            formsPlot1.Refresh();
        }

        private void kbtnRed_Click(object sender, EventArgs e)
        {
            SetBackground(Color.Red);
        }

        private void kbtnGreen_Click(object sender, EventArgs e)
        {
            SetBackground(Color.Green);
        }

        private void kbtnBlue_Click(object sender, EventArgs e)
        {
            SetBackground(Color.Blue);
        }

        private void kbtnWhite_Click(object sender, EventArgs e)
        {
            SetBackground(Color.White);
        }

        private void kbtnControl_Click(object sender, EventArgs e)
        {
            SetBackground(SystemColors.Control);
        }

        private void kbtnImage_Click(object sender, EventArgs e)
        {
            // apply a Bitmap to the background of this form
            Random rand = new Random();
            Bitmap bmp = new Bitmap(200, 200);
            Graphics gfx = Graphics.FromImage(bmp);
            gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            gfx.Clear(SystemColors.Control);
            Pen pen = Pens.LightGray;
            Size circleSize = new Size(20, 20);
            for (int i = 0; i < 100; i++)
            {
                Point randomPoint = new Point(rand.Next(bmp.Width - circleSize.Width), rand.Next(bmp.Height - circleSize.Height));
                Rectangle rect = new Rectangle(randomPoint, circleSize);
                gfx.DrawEllipse(pen, rect);
            }

            BackgroundImage = bmp;
            formsPlot1.Refresh();
        }
    }
}
