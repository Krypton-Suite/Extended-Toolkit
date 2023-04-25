namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    partial class NaviOptionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NaviOptionsForm));
            this.labelDesc = new Krypton.Toolkit.KryptonLabel();
            this.buttonMoveUp = new Krypton.Toolkit.KryptonButton();
            this.buttonReset = new Krypton.Toolkit.KryptonButton();
            this.buttonMoveDown = new Krypton.Toolkit.KryptonButton();
            this.buttonOk = new Krypton.Toolkit.KryptonButton();
            this.buttonCancel = new Krypton.Toolkit.KryptonButton();
            this.checkedListBoxBands = new Krypton.Toolkit.Suite.Extended.Navi.Suite.NaviCheckedListBox();
            this.kclbBands = new Krypton.Toolkit.KryptonCheckedListBox();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelDesc
            // 
            resources.ApplyResources(this.labelDesc, "labelDesc");
            this.labelDesc.LabelStyle = Krypton.Toolkit.LabelStyle.NormalPanel;
            this.labelDesc.Name = "labelDesc";
            this.labelDesc.Values.ExtraText = resources.GetString("labelDesc.Values.ExtraText");
            this.labelDesc.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("labelDesc.Values.ImageTransparentColor")));
            this.labelDesc.Values.Text = resources.GetString("labelDesc.Values.Text");
            // 
            // buttonMoveUp
            // 
            resources.ApplyResources(this.buttonMoveUp, "buttonMoveUp");
            this.buttonMoveUp.Name = "buttonMoveUp";
            this.buttonMoveUp.Values.ExtraText = resources.GetString("buttonMoveUp.Values.ExtraText");
            this.buttonMoveUp.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("buttonMoveUp.Values.ImageTransparentColor")));
            this.buttonMoveUp.Values.Text = resources.GetString("buttonMoveUp.Values.Text");
            this.buttonMoveUp.Click += new System.EventHandler(this.buttonMoveUp_Click);
            // 
            // buttonReset
            // 
            resources.ApplyResources(this.buttonReset, "buttonReset");
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Values.ExtraText = resources.GetString("buttonReset.Values.ExtraText");
            this.buttonReset.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("buttonReset.Values.ImageTransparentColor")));
            this.buttonReset.Values.Text = resources.GetString("buttonReset.Values.Text");
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonMoveDown
            // 
            resources.ApplyResources(this.buttonMoveDown, "buttonMoveDown");
            this.buttonMoveDown.Name = "buttonMoveDown";
            this.buttonMoveDown.Values.ExtraText = resources.GetString("buttonMoveDown.Values.ExtraText");
            this.buttonMoveDown.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("buttonMoveDown.Values.ImageTransparentColor")));
            this.buttonMoveDown.Values.Text = resources.GetString("buttonMoveDown.Values.Text");
            this.buttonMoveDown.Click += new System.EventHandler(this.buttonMoveDown_Click);
            // 
            // buttonOk
            // 
            resources.ApplyResources(this.buttonOk, "buttonOk");
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Values.ExtraText = resources.GetString("buttonOk.Values.ExtraText");
            this.buttonOk.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("buttonOk.Values.ImageTransparentColor")));
            this.buttonOk.Values.Text = resources.GetString("buttonOk.Values.Text");
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            resources.ApplyResources(this.buttonCancel, "buttonCancel");
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Values.ExtraText = resources.GetString("buttonCancel.Values.ExtraText");
            this.buttonCancel.Values.ImageTransparentColor = ((System.Drawing.Color)(resources.GetObject("buttonCancel.Values.ImageTransparentColor")));
            this.buttonCancel.Values.Text = resources.GetString("buttonCancel.Values.Text");
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // checkedListBoxBands
            // 
            resources.ApplyResources(this.checkedListBoxBands, "checkedListBoxBands");
            this.checkedListBoxBands.FormattingEnabled = true;
            this.checkedListBoxBands.Name = "checkedListBoxBands";
            // 
            // kclbBands
            // 
            resources.ApplyResources(this.kclbBands, "kclbBands");
            this.kclbBands.Name = "kclbBands";
            // 
            // kryptonPanel1
            // 
            resources.ApplyResources(this.kryptonPanel1, "kryptonPanel1");
            this.kryptonPanel1.Controls.Add(this.labelDesc);
            this.kryptonPanel1.Name = "kryptonPanel1";
            // 
            // NaviOptionsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kclbBands);
            this.Controls.Add(this.checkedListBoxBands);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonMoveDown);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonMoveUp);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NaviOptionsForm";
            this.Controls.SetChildIndex(this.kryptonPanel1, 0);
            this.Controls.SetChildIndex(this.buttonMoveUp, 0);
            this.Controls.SetChildIndex(this.buttonReset, 0);
            this.Controls.SetChildIndex(this.buttonMoveDown, 0);
            this.Controls.SetChildIndex(this.buttonOk, 0);
            this.Controls.SetChildIndex(this.buttonCancel, 0);
            this.Controls.SetChildIndex(this.checkedListBoxBands, 0);
            this.Controls.SetChildIndex(this.kclbBands, 0);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Krypton.Toolkit.KryptonLabel labelDesc;
        private Krypton.Toolkit.KryptonButton buttonMoveUp;
        private Krypton.Toolkit.KryptonButton buttonReset;
        private Krypton.Toolkit.KryptonButton buttonMoveDown;
        private Krypton.Toolkit.KryptonButton buttonOk;
        private Krypton.Toolkit.KryptonButton buttonCancel;
        private NaviCheckedListBox checkedListBoxBands;
        private KryptonCheckedListBox kclbBands;
        private KryptonPanel kryptonPanel1;
    }
}