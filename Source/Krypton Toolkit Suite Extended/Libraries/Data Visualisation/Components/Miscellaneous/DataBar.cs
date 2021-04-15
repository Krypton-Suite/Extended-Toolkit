#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    [ToolboxBitmap(typeof(DataBar)), ToolboxItem(true)]
    public class DataBar : UserControl
    {
        #region Design Code
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DataBar
            // 
            this.Name = "DataBar";
            this.Size = new System.Drawing.Size(128, 16);
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private Container components = null;

        private int _value;

        private Color _colourBar;
        #endregion

        #region Properties
        [Description("Gets or sets the current Bar Color in chart"), Category("Appearance")]
        public Color BarColour { get => _colourBar; set => _colourBar = value; }

        [Description("Gets or sets the current value in data bar"), Category("Behavior")]
        public int Value
        {
            get => _value;

            set
            {
                _value = value;

                Invalidate();
            }
        }
        #endregion

        #region Constructor
        public DataBar()
        {
            InitializeComponent();

            BackColor = Color.Silver;

            _value = 0;

            _colourBar = Color.DarkBlue;
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
            Rectangle rectangle = ClientRectangle;

            e.Graphics.FillRectangle(new SolidBrush(_colourBar), 0, 0, rectangle.Width * _value / 100, rectangle.Height);

            base.OnPaint(e);
        }
        #endregion
    }
}