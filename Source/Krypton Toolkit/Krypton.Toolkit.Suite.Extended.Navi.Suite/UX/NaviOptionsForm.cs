#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    public class NaviOptionsForm : KryptonForm
    {
        #region Designer Code

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
            this.labelDesc.Location = new System.Drawing.Point(12, 4);
            this.labelDesc.Name = "labelDesc";
            this.labelDesc.Size = new System.Drawing.Size(165, 20);
            this.labelDesc.TabIndex = 0;
            this.labelDesc.Values.Text = "Display buttons in this order";
            // 
            // buttonMoveUp
            // 
            this.buttonMoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMoveUp.Location = new System.Drawing.Point(208, 43);
            this.buttonMoveUp.Name = "buttonMoveUp";
            this.buttonMoveUp.Size = new System.Drawing.Size(75, 23);
            this.buttonMoveUp.TabIndex = 1;
            this.buttonMoveUp.Values.Text = "Move up";
            this.buttonMoveUp.Click += new System.EventHandler(this.buttonMoveUp_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonReset.Location = new System.Drawing.Point(208, 101);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 2;
            this.buttonReset.Values.Text = "Reset";
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonMoveDown
            // 
            this.buttonMoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonMoveDown.Location = new System.Drawing.Point(208, 72);
            this.buttonMoveDown.Name = "buttonMoveDown";
            this.buttonMoveDown.Size = new System.Drawing.Size(75, 23);
            this.buttonMoveDown.TabIndex = 3;
            this.buttonMoveDown.Values.Text = "Move down";
            this.buttonMoveDown.Click += new System.EventHandler(this.buttonMoveDown_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(124, 231);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 4;
            this.buttonOk.Values.Text = "Ok";
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(205, 231);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Values.Text = "Cancel";
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // checkedListBoxBands
            // 
            this.checkedListBoxBands.FormattingEnabled = true;
            this.checkedListBoxBands.Location = new System.Drawing.Point(12, 30);
            this.checkedListBoxBands.Name = "checkedListBoxBands";
            this.checkedListBoxBands.Size = new System.Drawing.Size(187, 184);
            this.checkedListBoxBands.TabIndex = 6;
            // 
            // kclbBands
            // 
            this.kclbBands.Location = new System.Drawing.Point(12, 28);
            this.kclbBands.Name = "kclbBands";
            this.kclbBands.Size = new System.Drawing.Size(187, 197);
            this.kclbBands.TabIndex = 7;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.labelDesc);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(292, 266);
            this.kryptonPanel1.TabIndex = 8;
            // 
            // NaviOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
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
            this.Text = "Options of the Navigation Pane";
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

        #endregion

        private KryptonCheckedListBox kclbBands;
        private KryptonPanel kryptonPanel1;
        private NaviBar bar;

        public NaviOptionsForm()
        {
            InitializeComponent();
        }

        public void Initialize(NaviBar bar)
        {
            this.bar = bar;
            checkedListBoxBands.Items.Clear();
            foreach (NaviBand band in bar.Bands)
            {
                checkedListBoxBands.Items.Add(band.Text, band.Visible);
            }
            Translate();
        }

        private void Translate()
        {
            ResourceManager rm = new ResourceManager(
               "Krypton.Toolkit.Extended.Navi.Suite.Properties.Resources.Text", Assembly.GetExecutingAssembly());

            buttonCancel.Text = rm.GetString("OptionsCancel");
            buttonOk.Text = rm.GetString("OptionsOk");
            labelDesc.Text = rm.GetString("OptionsIntro");
            buttonMoveDown.Text = rm.GetString("OptionsMoveDown");
            buttonMoveUp.Text = rm.GetString("OptionsMoveUp");
            buttonReset.Text = rm.GetString("OptionsReset");
            Text = rm.GetString("OptionsTitle");
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            // Set the new order
            for (int i = 0; i < bar.Bands.Count; i++)
            {
                int loc = kclbBands.Items.IndexOf(bar.Bands[i].Text);
                bar.Bands[i].Visible = kclbBands.CheckedItems.Contains(bar.Bands[i].Text);
                bar.Bands[i].Order = loc;
            }

            // And sort the list based on the new order
            bar.Bands.Sort(new NaviBandOrderComparer());
        }

        private void buttonMoveUp_Click(object sender, EventArgs e)
        {
            if (kclbBands.SelectedIndex > 0)
            {
                bool oldChecked = kclbBands.CheckedIndices.Contains(kclbBands.SelectedIndex - 1);
                bool oldChecked2 = kclbBands.CheckedIndices.Contains(kclbBands.SelectedIndex);

                object oldItem = kclbBands.Items[kclbBands.SelectedIndex - 1];
                kclbBands.Items[kclbBands.SelectedIndex - 1] = kclbBands.SelectedItem;

                kclbBands.SetItemChecked(kclbBands.SelectedIndex, oldChecked);
                kclbBands.SetItemChecked(kclbBands.SelectedIndex - 1, oldChecked2);

                kclbBands.Items[kclbBands.SelectedIndex] = oldItem;
                kclbBands.SelectedIndex -= 1;
            }
        }

        private void buttonMoveDown_Click(object sender, EventArgs e)
        {
            if ((kclbBands.SelectedIndex > 0)
            && (kclbBands.SelectedIndex < kclbBands.Items.Count - 1))
            {
                bool oldChecked = kclbBands.CheckedIndices.Contains(
                   kclbBands.SelectedIndex + 1);
                bool oldChecked2 = kclbBands.CheckedIndices.Contains(
                   kclbBands.SelectedIndex);

                object oldItem = kclbBands.Items[kclbBands.SelectedIndex + 1];
                kclbBands.Items[kclbBands.SelectedIndex + 1] =
                   kclbBands.SelectedItem;

                kclbBands.SetItemChecked(kclbBands.SelectedIndex,
                   oldChecked);
                kclbBands.SetItemChecked(kclbBands.SelectedIndex + 1,
                   oldChecked2);

                kclbBands.Items[kclbBands.SelectedIndex] = oldItem;
                kclbBands.SelectedIndex += 1;
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            // Sort list based on original order
            bar.Bands.Sort(new NaviBandOrgOrderComparer());
            Initialize(bar);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            // Reset ordering posibly caused by reset button
            bar.Bands.Sort(new NaviBandOrderComparer());
        }
    }
}