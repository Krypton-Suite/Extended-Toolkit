#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Panels
{
    [ToolboxBitmap(typeof(KryptonPanel)), Description("Implements a panel for buttons, similar to the one found in the KryptonMessageBox.")]
    public class KryptonButtonPanel : UserControl
    {
        #region Design Code
        private KryptonPanel kpnlContents;
        private KryptonBorderEdge kbeEdge;

        private void InitializeComponent()
        {
            this.kpnlContents = new Krypton.Toolkit.KryptonPanel();
            this.kbeEdge = new Krypton.Toolkit.KryptonBorderEdge();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlContents)).BeginInit();
            this.kpnlContents.SuspendLayout();
            this.SuspendLayout();
            // 
            // kpnlContents
            // 
            this.kpnlContents.Controls.Add(this.kbeEdge);
            this.kpnlContents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpnlContents.Location = new System.Drawing.Point(0, 0);
            this.kpnlContents.Name = "kpnlContents";
            this.kpnlContents.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kpnlContents.Size = new System.Drawing.Size(614, 50);
            this.kpnlContents.TabIndex = 1;
            // 
            // kbeEdge
            // 
            this.kbeEdge.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderPrimary;
            this.kbeEdge.Dock = System.Windows.Forms.DockStyle.Top;
            this.kbeEdge.Location = new System.Drawing.Point(0, 0);
            this.kbeEdge.Name = "kbeEdge";
            this.kbeEdge.Size = new System.Drawing.Size(614, 1);
            this.kbeEdge.Text = "kryptonBorderEdge1";
            // 
            // KryptonButtonPanel
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.kpnlContents);
            this.Name = "KryptonButtonPanel";
            this.Size = new System.Drawing.Size(614, 50);
            ((System.ComponentModel.ISupportInitialize)(this.kpnlContents)).EndInit();
            this.kpnlContents.ResumeLayout(false);
            this.kpnlContents.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region Instance Fields

        private KryptonButton[] _buttons;

        private PaletteBackStyle _panelPaletteBackStyle;

        private PaletteBorderStyle _edgeBorderStyle;

        #endregion

        #region Properties

        public KryptonButton[] Buttons { get => _buttons; set => _buttons = value; }

        public PaletteBackStyle PanelPaletteBackStyle { get => _panelPaletteBackStyle; set { _panelPaletteBackStyle = value; Invalidate(); } }

        public PaletteBorderStyle EdgeBorderStyle { get => _edgeBorderStyle; set { _edgeBorderStyle = value; Invalidate(); } }

        #endregion

        #region Constructor

        public KryptonButtonPanel()
        {
            InitializeComponent();

            _buttons = null;

            _panelPaletteBackStyle = PaletteBackStyle.PanelAlternate;

            _edgeBorderStyle = PaletteBorderStyle.HeaderPrimary;
        }

        #endregion

        #region Overrides

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            if (e.Control is KryptonButton)
            {
                AddToButtonArray(e);
            }

            base.OnControlAdded(e);
        }

        private void AddToButtonArray(ControlEventArgs control)
        {
            if (control.Control is KryptonButton)
            {
                //_buttons += (KryptonButton)control.Control;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            kpnlContents.PanelBackStyle = _panelPaletteBackStyle;

            kbeEdge.BorderStyle = _edgeBorderStyle;

            base.OnPaint(e);
        }

        #endregion
    }
}
