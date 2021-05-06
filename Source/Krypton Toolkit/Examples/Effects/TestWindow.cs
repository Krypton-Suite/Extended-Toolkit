using System;
using System.Windows.Forms;

using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Effects;

namespace Effects
{
    public class TestWindow : KryptonForm
    {
        private KryptonButton kbtnClose;

        private void InitializeComponent()
        {
            this.kbtnClose = new Krypton.Toolkit.KryptonButton();
            this.SuspendLayout();
            // 
            // kbtnClose
            // 
            this.kbtnClose.Enabled = false;
            this.kbtnClose.Location = new System.Drawing.Point(97, 102);
            this.kbtnClose.Name = "kbtnClose";
            this.kbtnClose.Size = new System.Drawing.Size(130, 25);
            this.kbtnClose.TabIndex = 0;
            this.kbtnClose.Values.Text = "Slow Fade In";
            this.kbtnClose.Click += new System.EventHandler(this.kbtnClose_Click);
            // 
            // TestWindow
            // 
            this.ClientSize = new System.Drawing.Size(314, 261);
            this.Controls.Add(this.kbtnClose);
            this.Name = "TestWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fade In, and Out on Close";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TestWindow_FormClosing);
            this.ResumeLayout(false);

        }

        public TestWindow()
        {
            InitializeComponent();
        }

        private void TestWindow_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            // this will also be fired from the btnClose as well, but then the window form will be `disposed` or `opacity == 0` of already !
            FadeController.FadeOut(this, FadeSpeed.Slow);
        }

        private void kbtnClose_Click(object sender, EventArgs e)
        {
            FadeController.FadeOutAndClose(this, FadeSpeed.Slow);
        }

        public void FadeInComplete()
        {
            kbtnClose.Text = @"Fade Out";
            kbtnClose.Enabled = true;
        }
    }
}