using System;

namespace Krypton.Toolkit.Suite.Extended.IO
{
    public class GoToWindow : KryptonForm
    {
        #region Design Code
        private KryptonTextBox ktxtLineNumber;
        private KryptonLabel klblLineNumber;
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.klblLineNumber = new Krypton.Toolkit.KryptonLabel();
            this.ktxtLineNumber = new Krypton.Toolkit.KryptonTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.ktxtLineNumber);
            this.kryptonPanel1.Controls.Add(this.klblLineNumber);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(343, 118);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // klblLineNumber
            // 
            this.klblLineNumber.Location = new System.Drawing.Point(12, 12);
            this.klblLineNumber.Name = "klblLineNumber";
            this.klblLineNumber.Size = new System.Drawing.Size(128, 20);
            this.klblLineNumber.TabIndex = 1;
            this.klblLineNumber.Values.Text = "Line Number: ({0}/{1})";
            // 
            // ktxtLineNumber
            // 
            this.ktxtLineNumber.Location = new System.Drawing.Point(12, 38);
            this.ktxtLineNumber.Name = "ktxtLineNumber";
            this.ktxtLineNumber.Size = new System.Drawing.Size(319, 23);
            this.ktxtLineNumber.TabIndex = 1;
            // 
            // GoToWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 118);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GoToWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Go To Line";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region Properties
        public int SelectedLineNumber { get; set; }
        public int TotalLineCount { get; set; }
        #endregion

        #region Constructor
        public GoToWindow()
        {
            InitializeComponent();
        }
        #endregion

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ktxtLineNumber.Text = this.SelectedLineNumber.ToString();

            klblLineNumber.Text = String.Format("Line number (1 - {0}):", this.TotalLineCount);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            ktxtLineNumber.Focus();
        }

        private void kbtnOk_Click(object sender, EventArgs e)
        {
            int enteredLine;
            if (int.TryParse(this.ktxtLineNumber.Text, out enteredLine))
            {
                enteredLine = Math.Min(enteredLine, this.TotalLineCount);
                enteredLine = Math.Max(1, enteredLine);

                this.SelectedLineNumber = enteredLine;
            }
            this.Close();
        }

        private void kbtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}