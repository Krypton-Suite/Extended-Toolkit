using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Effects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            this.kbtnClose.Location = new System.Drawing.Point(97, 102);
            this.kbtnClose.Name = "kbtnClose";
            this.kbtnClose.Size = new System.Drawing.Size(90, 25);
            this.kbtnClose.TabIndex = 0;
            this.kbtnClose.Values.Text = "Close";
            this.kbtnClose.Click += new System.EventHandler(this.kbtnClose_Click);
            // 
            // TestWindow
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.kbtnClose);
            this.Name = "TestWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TestWindow_FormClosing);
            this.ResumeLayout(false);

        }

        public TestWindow()
        {
            InitializeComponent();
        }

        private void TestWindow_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
           
        }

        private void kbtnClose_Click(object sender, EventArgs e)
        {
 FadeController.FadeOutAndClose(this, 5);
        }
    }
}