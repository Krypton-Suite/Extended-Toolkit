#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Messagebox
{
    partial class KryptonMessageBoxExtendedForm
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
            this.ktlpContent = new System.Windows.Forms.TableLayoutPanel();
            this.kpnlButtons = new Krypton.Toolkit.KryptonPanel();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.mbButton4 = new Krypton.Toolkit.Suite.Extended.Messagebox.MessageButton();
            this.mbButton3 = new Krypton.Toolkit.Suite.Extended.Messagebox.MessageButton();
            this.mbButton1 = new Krypton.Toolkit.Suite.Extended.Messagebox.MessageButton();
            this.mbButton2 = new Krypton.Toolkit.Suite.Extended.Messagebox.MessageButton();
            this.mbMoreDetails = new Krypton.Toolkit.Suite.Extended.Messagebox.MessageButton();
            this.kpnlExpandableFooter = new Krypton.Toolkit.KryptonPanel();
            this.krtbMoreDetails = new Krypton.Toolkit.KryptonRichTextBox();
            this.kcbOptionalCheckBox = new Krypton.Toolkit.KryptonCheckBox();
            this.kllOptionalLink = new Krypton.Toolkit.KryptonLinkLabel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.pbxMessageIcon = new System.Windows.Forms.PictureBox();
            this.kryptonPanel3 = new Krypton.Toolkit.KryptonPanel();
            this.kwlMessageText = new Krypton.Toolkit.KryptonWrapLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlBase)).BeginInit();
            this.kpnlBase.SuspendLayout();
            this.ktlpContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlButtons)).BeginInit();
            this.kpnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlExpandableFooter)).BeginInit();
            this.kpnlExpandableFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxMessageIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).BeginInit();
            this.kryptonPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // kpnlBase
            // 
            this.kpnlBase.Controls.Add(this.ktlpContent);
            this.kpnlBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpnlBase.Location = new System.Drawing.Point(0, 0);
            this.kpnlBase.Name = "kpnlBase";
            this.kpnlBase.Size = new System.Drawing.Size(188, 81);
            this.kpnlBase.TabIndex = 3;
            // 
            // ktlpContent
            // 
            this.ktlpContent.BackColor = System.Drawing.Color.Transparent;
            this.ktlpContent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ktlpContent.ColumnCount = 2;
            this.ktlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ktlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ktlpContent.Controls.Add(this.kpnlButtons, 0, 1);
            this.ktlpContent.Controls.Add(this.kpnlExpandableFooter, 0, 2);
            this.ktlpContent.Controls.Add(this.kryptonPanel2, 0, 0);
            this.ktlpContent.Controls.Add(this.kryptonPanel3, 1, 0);
            this.ktlpContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ktlpContent.Location = new System.Drawing.Point(0, 0);
            this.ktlpContent.Name = "ktlpContent";
            this.ktlpContent.RowCount = 3;
            this.ktlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.ktlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ktlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ktlpContent.Size = new System.Drawing.Size(188, 81);
            this.ktlpContent.TabIndex = 0;
            // 
            // kpnlButtons
            // 
            this.ktlpContent.SetColumnSpan(this.kpnlButtons, 2);
            this.kpnlButtons.Controls.Add(this.kryptonBorderEdge1);
            this.kpnlButtons.Controls.Add(this.mbButton4);
            this.kpnlButtons.Controls.Add(this.mbButton3);
            this.kpnlButtons.Controls.Add(this.mbButton1);
            this.kpnlButtons.Controls.Add(this.mbButton2);
            this.kpnlButtons.Controls.Add(this.mbMoreDetails);
            this.kpnlButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpnlButtons.Location = new System.Drawing.Point(0, 39);
            this.kpnlButtons.Margin = new System.Windows.Forms.Padding(0);
            this.kpnlButtons.Name = "kpnlButtons";
            this.kpnlButtons.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kpnlButtons.Size = new System.Drawing.Size(188, 21);
            this.kpnlButtons.TabIndex = 2;
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderPrimary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(188, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // mbButton4
            // 
            this.mbButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mbButton4.AutoSize = true;
            this.mbButton4.CornerRoundingRadius = -1F;
            this.mbButton4.Enabled = false;
            this.mbButton4.IgnoreAltF4 = false;
            this.mbButton4.Location = new System.Drawing.Point(188, 0);
            this.mbButton4.Margin = new System.Windows.Forms.Padding(0);
            this.mbButton4.MinimumSize = new System.Drawing.Size(38, 21);
            this.mbButton4.Name = "mbButton4";
            this.mbButton4.Size = new System.Drawing.Size(38, 23);
            this.mbButton4.TabIndex = 2;
            this.mbButton4.Values.Text = "B4";
            this.mbButton4.Visible = false;
            // 
            // mbButton3
            // 
            this.mbButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mbButton3.AutoSize = true;
            this.mbButton3.CornerRoundingRadius = -1F;
            this.mbButton3.Enabled = false;
            this.mbButton3.IgnoreAltF4 = false;
            this.mbButton3.Location = new System.Drawing.Point(151, 0);
            this.mbButton3.Margin = new System.Windows.Forms.Padding(0);
            this.mbButton3.MinimumSize = new System.Drawing.Size(38, 21);
            this.mbButton3.Name = "mbButton3";
            this.mbButton3.Size = new System.Drawing.Size(38, 23);
            this.mbButton3.TabIndex = 2;
            this.mbButton3.Values.Text = "B3";
            this.mbButton3.Visible = false;
            // 
            // mbButton1
            // 
            this.mbButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mbButton1.AutoSize = true;
            this.mbButton1.CornerRoundingRadius = -1F;
            this.mbButton1.Enabled = false;
            this.mbButton1.IgnoreAltF4 = false;
            this.mbButton1.Location = new System.Drawing.Point(75, 0);
            this.mbButton1.Margin = new System.Windows.Forms.Padding(0);
            this.mbButton1.MinimumSize = new System.Drawing.Size(38, 21);
            this.mbButton1.Name = "mbButton1";
            this.mbButton1.Size = new System.Drawing.Size(38, 23);
            this.mbButton1.TabIndex = 0;
            this.mbButton1.Values.Text = "B1";
            this.mbButton1.Visible = false;
            // 
            // mbButton2
            // 
            this.mbButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mbButton2.AutoSize = true;
            this.mbButton2.CornerRoundingRadius = -1F;
            this.mbButton2.Enabled = false;
            this.mbButton2.IgnoreAltF4 = false;
            this.mbButton2.Location = new System.Drawing.Point(113, 0);
            this.mbButton2.Margin = new System.Windows.Forms.Padding(0);
            this.mbButton2.MinimumSize = new System.Drawing.Size(38, 21);
            this.mbButton2.Name = "mbButton2";
            this.mbButton2.Size = new System.Drawing.Size(38, 23);
            this.mbButton2.TabIndex = 1;
            this.mbButton2.Values.Text = "B2";
            this.mbButton2.Visible = false;
            // 
            // mbMoreDetails
            // 
            this.mbMoreDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mbMoreDetails.AutoSize = true;
            this.mbMoreDetails.CornerRoundingRadius = -1F;
            this.mbMoreDetails.Enabled = false;
            this.mbMoreDetails.IgnoreAltF4 = false;
            this.mbMoreDetails.Location = new System.Drawing.Point(0, 0);
            this.mbMoreDetails.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.mbMoreDetails.MinimumSize = new System.Drawing.Size(38, 21);
            this.mbMoreDetails.Name = "mbMoreDetails";
            this.mbMoreDetails.Size = new System.Drawing.Size(38, 23);
            this.mbMoreDetails.TabIndex = 4;
            this.mbMoreDetails.Values.Text = "BM";
            this.mbMoreDetails.Visible = false;
            this.mbMoreDetails.Click += new System.EventHandler(this.MoreDetails_Click);
            // 
            // kpnlExpandableFooter
            // 
            this.ktlpContent.SetColumnSpan(this.kpnlExpandableFooter, 2);
            this.kpnlExpandableFooter.Controls.Add(this.krtbMoreDetails);
            this.kpnlExpandableFooter.Controls.Add(this.kcbOptionalCheckBox);
            this.kpnlExpandableFooter.Controls.Add(this.kllOptionalLink);
            this.kpnlExpandableFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpnlExpandableFooter.Location = new System.Drawing.Point(3, 63);
            this.kpnlExpandableFooter.Name = "kpnlExpandableFooter";
            this.kpnlExpandableFooter.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kpnlExpandableFooter.Size = new System.Drawing.Size(182, 15);
            this.kpnlExpandableFooter.TabIndex = 4;
            this.kpnlExpandableFooter.Visible = false;
            // 
            // krtbMoreDetails
            // 
            this.krtbMoreDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.krtbMoreDetails.InputControlStyle = Krypton.Toolkit.InputControlStyle.PanelAlternate;
            this.krtbMoreDetails.Location = new System.Drawing.Point(0, 0);
            this.krtbMoreDetails.Name = "krtbMoreDetails";
            this.krtbMoreDetails.ReadOnly = true;
            this.krtbMoreDetails.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.krtbMoreDetails.Size = new System.Drawing.Size(182, 15);
            this.krtbMoreDetails.TabIndex = 0;
            this.krtbMoreDetails.Text = "";
            this.krtbMoreDetails.Visible = false;
            // 
            // kcbOptionalCheckBox
            // 
            this.kcbOptionalCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kcbOptionalCheckBox.Location = new System.Drawing.Point(0, 0);
            this.kcbOptionalCheckBox.Name = "kcbOptionalCheckBox";
            this.kcbOptionalCheckBox.Size = new System.Drawing.Size(182, 15);
            this.kcbOptionalCheckBox.TabIndex = 1;
            this.kcbOptionalCheckBox.Values.Text = "CB1";
            this.kcbOptionalCheckBox.Visible = false;
            this.kcbOptionalCheckBox.CheckedChanged += new System.EventHandler(this.kcbOptionalCheckBox_CheckedChanged);
            // 
            // kllOptionalLink
            // 
            this.kllOptionalLink.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kllOptionalLink.Location = new System.Drawing.Point(0, 0);
            this.kllOptionalLink.Name = "kllOptionalLink";
            this.kllOptionalLink.Size = new System.Drawing.Size(182, 15);
            this.kllOptionalLink.TabIndex = 2;
            this.kllOptionalLink.Values.Text = "LL1";
            this.kllOptionalLink.Visible = false;
            this.kllOptionalLink.LinkClicked += new System.EventHandler(this.kllOptionalLink_LinkClicked);
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.pbxMessageIcon);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(3, 3);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(32, 33);
            this.kryptonPanel2.TabIndex = 5;
            // 
            // pbxMessageIcon
            // 
            this.pbxMessageIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbxMessageIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxMessageIcon.Location = new System.Drawing.Point(0, 0);
            this.pbxMessageIcon.Margin = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this.pbxMessageIcon.Name = "pbxMessageIcon";
            this.pbxMessageIcon.Size = new System.Drawing.Size(32, 33);
            this.pbxMessageIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxMessageIcon.TabIndex = 0;
            this.pbxMessageIcon.TabStop = false;
            // 
            // kryptonPanel3
            // 
            this.kryptonPanel3.Controls.Add(this.kwlMessageText);
            this.kryptonPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel3.Location = new System.Drawing.Point(41, 3);
            this.kryptonPanel3.Name = "kryptonPanel3";
            this.kryptonPanel3.Size = new System.Drawing.Size(144, 33);
            this.kryptonPanel3.TabIndex = 6;
            // 
            // kwlMessageText
            // 
            this.kwlMessageText.AutoSize = false;
            this.kwlMessageText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kwlMessageText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kwlMessageText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlMessageText.LabelStyle = Krypton.Toolkit.LabelStyle.NormalControl;
            this.kwlMessageText.Location = new System.Drawing.Point(0, 0);
            this.kwlMessageText.Name = "kwlMessageText";
            this.kwlMessageText.Size = new System.Drawing.Size(144, 33);
            this.kwlMessageText.Text = "Dummy message text...";
            this.kwlMessageText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // KryptonMessageBoxExtendedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(188, 81);
            this.Controls.Add(this.kpnlBase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonMessageBoxExtendedForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.kpnlBase)).EndInit();
            this.kpnlBase.ResumeLayout(false);
            this.ktlpContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kpnlButtons)).EndInit();
            this.kpnlButtons.ResumeLayout(false);
            this.kpnlButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlExpandableFooter)).EndInit();
            this.kpnlExpandableFooter.ResumeLayout(false);
            this.kpnlExpandableFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxMessageIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).EndInit();
            this.kryptonPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private KryptonPanel kpnlBase;
        private TableLayoutPanel ktlpContent;
        private PictureBox pbxMessageIcon;
        private KryptonPanel kpnlButtons;
        private KryptonBorderEdge kryptonBorderEdge1;
        private MessageButton mbButton4;
        private MessageButton mbButton3;
        private MessageButton mbButton1;
        private MessageButton mbButton2;
        private MessageButton mbMoreDetails;
        private KryptonWrapLabel kwlMessageText;
        private KryptonPanel kpnlExpandableFooter;
        private KryptonRichTextBox krtbMoreDetails;
        private KryptonCheckBox kcbOptionalCheckBox;
        private KryptonLinkLabel kllOptionalLink;
        private KryptonPanel kryptonPanel2;
        private KryptonPanel kryptonPanel3;
    }
}