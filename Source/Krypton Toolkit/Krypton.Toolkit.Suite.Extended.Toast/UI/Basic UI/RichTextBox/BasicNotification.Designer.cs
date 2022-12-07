namespace Krypton.Toolkit.Suite.Extended.Toast
{
    partial class BasicNotification
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
            this.kpnlBase = new Krypton.Toolkit.KryptonPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pbxIcon = new System.Windows.Forms.PictureBox();
            this.kwlblPrompt = new Krypton.Toolkit.KryptonWrapLabel();
            this.krbUserInput = new Krypton.Toolkit.KryptonRichTextBox();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.kbtnToastButtonPanel3 = new Krypton.Toolkit.KryptonPanel();
            this.ktbActionButton3 = new Krypton.Toolkit.Suite.Extended.Toast.KryptonToastButton();
            this.kbtnToastButton3 = new Krypton.Toolkit.KryptonButton();
            this.kbtnToastButtonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.ktbActionButton2 = new Krypton.Toolkit.Suite.Extended.Toast.KryptonToastButton();
            this.kbtnToastButton2 = new Krypton.Toolkit.KryptonButton();
            this.kbtnToastButtonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.ktbActionButton1 = new Krypton.Toolkit.Suite.Extended.Toast.KryptonToastButton();
            this.kbtnToastButton1 = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlBase)).BeginInit();
            this.kpnlBase.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.tlpButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kbtnToastButtonPanel3)).BeginInit();
            this.kbtnToastButtonPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kbtnToastButtonPanel2)).BeginInit();
            this.kbtnToastButtonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kbtnToastButtonPanel1)).BeginInit();
            this.kbtnToastButtonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kpnlBase
            // 
            this.kpnlBase.Controls.Add(this.tableLayoutPanel1);
            this.kpnlBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpnlBase.Location = new System.Drawing.Point(0, 0);
            this.kpnlBase.Name = "kpnlBase";
            this.kpnlBase.Size = new System.Drawing.Size(609, 232);
            this.kpnlBase.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pbxIcon, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.kwlblPrompt, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.krbUserInput, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.kryptonBorderEdge1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.kryptonPanel1, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(609, 232);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // pbxIcon
            // 
            this.pbxIcon.Location = new System.Drawing.Point(3, 3);
            this.pbxIcon.Name = "pbxIcon";
            this.tableLayoutPanel1.SetRowSpan(this.pbxIcon, 2);
            this.pbxIcon.Size = new System.Drawing.Size(128, 128);
            this.pbxIcon.TabIndex = 0;
            this.pbxIcon.TabStop = false;
            // 
            // kwlblPrompt
            // 
            this.kwlblPrompt.AutoSize = false;
            this.kwlblPrompt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kwlblPrompt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlblPrompt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlblPrompt.LabelStyle = Krypton.Toolkit.LabelStyle.NormalControl;
            this.kwlblPrompt.Location = new System.Drawing.Point(137, 0);
            this.kwlblPrompt.Name = "kwlblPrompt";
            this.kwlblPrompt.Size = new System.Drawing.Size(469, 74);
            this.kwlblPrompt.StateCommon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlblPrompt.Text = "{0}";
            this.kwlblPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // krbUserInput
            // 
            this.krbUserInput.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.krbUserInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.krbUserInput.Location = new System.Drawing.Point(137, 77);
            this.krbUserInput.Name = "krbUserInput";
            this.krbUserInput.ReadOnly = true;
            this.krbUserInput.Size = new System.Drawing.Size(469, 96);
            this.krbUserInput.TabIndex = 2;
            this.krbUserInput.Text = "";
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderSecondary;
            this.tableLayoutPanel1.SetColumnSpan(this.kryptonBorderEdge1, 2);
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(3, 179);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(603, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.kryptonPanel1, 2);
            this.kryptonPanel1.Controls.Add(this.tlpButtons);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(3, 186);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(603, 44);
            this.kryptonPanel1.TabIndex = 4;
            // 
            // tlpButtons
            // 
            this.tlpButtons.ColumnCount = 3;
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpButtons.Controls.Add(this.kbtnToastButtonPanel3, 0, 0);
            this.tlpButtons.Controls.Add(this.kbtnToastButtonPanel2, 0, 0);
            this.tlpButtons.Controls.Add(this.kbtnToastButtonPanel1, 0, 0);
            this.tlpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpButtons.Location = new System.Drawing.Point(0, 0);
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.RowCount = 1;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtons.Size = new System.Drawing.Size(603, 44);
            this.tlpButtons.TabIndex = 0;
            // 
            // kbtnToastButtonPanel3
            // 
            this.kbtnToastButtonPanel3.Controls.Add(this.ktbActionButton3);
            this.kbtnToastButtonPanel3.Controls.Add(this.kbtnToastButton3);
            this.kbtnToastButtonPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kbtnToastButtonPanel3.Location = new System.Drawing.Point(73, 3);
            this.kbtnToastButtonPanel3.Name = "kbtnToastButtonPanel3";
            this.kbtnToastButtonPanel3.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kbtnToastButtonPanel3.Size = new System.Drawing.Size(527, 38);
            this.kbtnToastButtonPanel3.TabIndex = 4;
            // 
            // ktbActionButton3
            // 
            this.ktbActionButton3.AcceptButtonBackColour1 = System.Drawing.Color.Green;
            this.ktbActionButton3.AcceptButtonBackColour2 = System.Drawing.Color.Green;
            this.ktbActionButton3.AcceptButtonTextColour1 = System.Drawing.Color.Empty;
            this.ktbActionButton3.AcceptButtonTextColour2 = System.Drawing.Color.Empty;
            this.ktbActionButton3.ActionType = Krypton.Toolkit.Suite.Extended.Toast.ActionType.Default;
            this.ktbActionButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ktbActionButton3.AutoSize = true;
            this.ktbActionButton3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ktbActionButton3.CornerRoundingRadius = -1F;
            this.ktbActionButton3.DenyButtonBackColour1 = System.Drawing.Color.Red;
            this.ktbActionButton3.DenyButtonBackColour2 = System.Drawing.Color.Red;
            this.ktbActionButton3.DenyButtonTextColour1 = System.Drawing.Color.Empty;
            this.ktbActionButton3.DenyButtonTextColour2 = System.Drawing.Color.Empty;
            this.ktbActionButton3.Location = new System.Drawing.Point(488, 7);
            this.ktbActionButton3.Name = "ktbActionButton3";
            this.ktbActionButton3.Size = new System.Drawing.Size(30, 22);
            this.ktbActionButton3.TabIndex = 2;
            this.ktbActionButton3.Values.Text = "AB3";
            // 
            // kbtnToastButton3
            // 
            this.kbtnToastButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnToastButton3.AutoSize = true;
            this.kbtnToastButton3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnToastButton3.CornerRoundingRadius = -1F;
            this.kbtnToastButton3.Location = new System.Drawing.Point(496, 7);
            this.kbtnToastButton3.Name = "kbtnToastButton3";
            this.kbtnToastButton3.Size = new System.Drawing.Size(22, 22);
            this.kbtnToastButton3.TabIndex = 0;
            this.kbtnToastButton3.Values.Text = "B3";
            // 
            // kbtnToastButtonPanel2
            // 
            this.kbtnToastButtonPanel2.Controls.Add(this.ktbActionButton2);
            this.kbtnToastButtonPanel2.Controls.Add(this.kbtnToastButton2);
            this.kbtnToastButtonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kbtnToastButtonPanel2.Location = new System.Drawing.Point(59, 3);
            this.kbtnToastButtonPanel2.Name = "kbtnToastButtonPanel2";
            this.kbtnToastButtonPanel2.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kbtnToastButtonPanel2.Size = new System.Drawing.Size(8, 38);
            this.kbtnToastButtonPanel2.TabIndex = 3;
            // 
            // ktbActionButton2
            // 
            this.ktbActionButton2.AcceptButtonBackColour1 = System.Drawing.Color.Green;
            this.ktbActionButton2.AcceptButtonBackColour2 = System.Drawing.Color.Green;
            this.ktbActionButton2.AcceptButtonTextColour1 = System.Drawing.Color.Empty;
            this.ktbActionButton2.AcceptButtonTextColour2 = System.Drawing.Color.Empty;
            this.ktbActionButton2.ActionType = Krypton.Toolkit.Suite.Extended.Toast.ActionType.Default;
            this.ktbActionButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ktbActionButton2.AutoSize = true;
            this.ktbActionButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ktbActionButton2.CornerRoundingRadius = -1F;
            this.ktbActionButton2.DenyButtonBackColour1 = System.Drawing.Color.Red;
            this.ktbActionButton2.DenyButtonBackColour2 = System.Drawing.Color.Red;
            this.ktbActionButton2.DenyButtonTextColour1 = System.Drawing.Color.Empty;
            this.ktbActionButton2.DenyButtonTextColour2 = System.Drawing.Color.Empty;
            this.ktbActionButton2.Location = new System.Drawing.Point(-26, 7);
            this.ktbActionButton2.Name = "ktbActionButton2";
            this.ktbActionButton2.Size = new System.Drawing.Size(30, 22);
            this.ktbActionButton2.TabIndex = 2;
            this.ktbActionButton2.Values.Text = "AB2";
            // 
            // kbtnToastButton2
            // 
            this.kbtnToastButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnToastButton2.AutoSize = true;
            this.kbtnToastButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnToastButton2.CornerRoundingRadius = -1F;
            this.kbtnToastButton2.Location = new System.Drawing.Point(-17, 7);
            this.kbtnToastButton2.Name = "kbtnToastButton2";
            this.kbtnToastButton2.Size = new System.Drawing.Size(22, 22);
            this.kbtnToastButton2.TabIndex = 0;
            this.kbtnToastButton2.Values.Text = "B2";
            // 
            // kbtnToastButtonPanel1
            // 
            this.kbtnToastButtonPanel1.Controls.Add(this.ktbActionButton1);
            this.kbtnToastButtonPanel1.Controls.Add(this.kbtnToastButton1);
            this.kbtnToastButtonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kbtnToastButtonPanel1.Location = new System.Drawing.Point(3, 3);
            this.kbtnToastButtonPanel1.Name = "kbtnToastButtonPanel1";
            this.kbtnToastButtonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kbtnToastButtonPanel1.Size = new System.Drawing.Size(50, 38);
            this.kbtnToastButtonPanel1.TabIndex = 2;
            this.kbtnToastButtonPanel1.Visible = false;
            // 
            // ktbActionButton1
            // 
            this.ktbActionButton1.AcceptButtonBackColour1 = System.Drawing.Color.Green;
            this.ktbActionButton1.AcceptButtonBackColour2 = System.Drawing.Color.Green;
            this.ktbActionButton1.AcceptButtonTextColour1 = System.Drawing.Color.Empty;
            this.ktbActionButton1.AcceptButtonTextColour2 = System.Drawing.Color.Empty;
            this.ktbActionButton1.ActionType = Krypton.Toolkit.Suite.Extended.Toast.ActionType.Default;
            this.ktbActionButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ktbActionButton1.AutoSize = true;
            this.ktbActionButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ktbActionButton1.CornerRoundingRadius = -1F;
            this.ktbActionButton1.DenyButtonBackColour1 = System.Drawing.Color.Red;
            this.ktbActionButton1.DenyButtonBackColour2 = System.Drawing.Color.Red;
            this.ktbActionButton1.DenyButtonTextColour1 = System.Drawing.Color.Empty;
            this.ktbActionButton1.DenyButtonTextColour2 = System.Drawing.Color.Empty;
            this.ktbActionButton1.Location = new System.Drawing.Point(9, 7);
            this.ktbActionButton1.Name = "ktbActionButton1";
            this.ktbActionButton1.Size = new System.Drawing.Size(30, 22);
            this.ktbActionButton1.TabIndex = 1;
            this.ktbActionButton1.Values.Text = "AB1";
            // 
            // kbtnToastButton1
            // 
            this.kbtnToastButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kbtnToastButton1.AutoSize = true;
            this.kbtnToastButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnToastButton1.CornerRoundingRadius = -1F;
            this.kbtnToastButton1.Location = new System.Drawing.Point(9, 7);
            this.kbtnToastButton1.Name = "kbtnToastButton1";
            this.kbtnToastButton1.Size = new System.Drawing.Size(22, 22);
            this.kbtnToastButton1.TabIndex = 0;
            this.kbtnToastButton1.Values.Text = "B1";
            // 
            // BasicNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 232);
            this.Controls.Add(this.kpnlBase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BasicNotification";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.BasicNotification_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kpnlBase)).EndInit();
            this.kpnlBase.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.tlpButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kbtnToastButtonPanel3)).EndInit();
            this.kbtnToastButtonPanel3.ResumeLayout(false);
            this.kbtnToastButtonPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kbtnToastButtonPanel2)).EndInit();
            this.kbtnToastButtonPanel2.ResumeLayout(false);
            this.kbtnToastButtonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kbtnToastButtonPanel1)).EndInit();
            this.kbtnToastButtonPanel1.ResumeLayout(false);
            this.kbtnToastButtonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonPanel kpnlBase;
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pbxIcon;
        private KryptonWrapLabel kwlblPrompt;
        private KryptonRichTextBox krbUserInput;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonPanel kryptonPanel1;
        private TableLayoutPanel tlpButtons;
        private KryptonPanel kbtnToastButtonPanel1;
        private KryptonToastButton ktbActionButton1;
        private KryptonButton kbtnToastButton1;
        private KryptonPanel kbtnToastButtonPanel2;
        private KryptonToastButton ktbActionButton2;
        private KryptonButton kbtnToastButton2;
        private KryptonPanel kbtnToastButtonPanel3;
        private KryptonToastButton ktbActionButton3;
        private KryptonButton kbtnToastButton3;
    }
}