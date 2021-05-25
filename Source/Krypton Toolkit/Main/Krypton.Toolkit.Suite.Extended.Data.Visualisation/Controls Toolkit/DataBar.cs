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
    /// <summary>
    /// Summary description for DataBar.
    /// </summary>
    [ToolboxBitmap(typeof(DataBar)), ToolboxItem(true)]
    public class DataBar : UserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        private int _value;
        private Color _colourBar;

        #region Constructor/Dispose
        public DataBar()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
            BackColor = Color.Silver;

            _value = 0;
            _colourBar = Color.DarkBlue;
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

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Name = "DataBar";
            this.Size = new System.Drawing.Size(128, 16);
        }
        #endregion

        #region "Properties"
        [Description("Gets or sets the current Bar Colour in chart"), Category("Appearance")]
        public Color BarColour
        {
            get { return _colourBar; }
            set { _colourBar = value; }
        }

        [Description("Gets or sets the current value in data bar"), Category("Behavior")]
        public int Value
        {
            get { return _value; }
            set
            {
                _value = value;
                Invalidate();
            }
        }
        #endregion


        #region Drawing
        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rt = this.ClientRectangle;
            e.Graphics.FillRectangle(new SolidBrush(_colourBar), 0, 0, rt.Width * _value / 100, rt.Height);

            base.OnPaint(e);
        }
        #endregion

    }
}