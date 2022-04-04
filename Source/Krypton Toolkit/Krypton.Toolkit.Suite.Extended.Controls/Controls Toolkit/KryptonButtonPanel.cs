#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Controls
{
    /// <summary>Provides a panel to contain buttons, similar to a KryptonMessageBox button panel.</summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    [Description("Provides a panel to contain buttons, similar to a KryptonMessageBox button panel."),
     ToolboxBitmap(typeof(KryptonPanel)),ToolboxItem(false)]
    public class KryptonButtonPanel : UserControl
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private KryptonBorderEdge kryptonBorderEdge1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(398, 50);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderPrimary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(398, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // KryptonButtonPanel
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "KryptonButtonPanel";
            this.Size = new System.Drawing.Size(398, 50);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region Constructors
        /// <summary>Initializes a new instance of the <see cref="KryptonButtonPanel" /> class.</summary>
        public KryptonButtonPanel()
        {
            InitializeComponent();
        }
        #endregion

        #region Protected
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        protected override void OnParentChanged(EventArgs e)
        {
            Dock = DockStyle.Bottom;

            base.OnParentChanged(e);
        }
        #endregion
    }
}