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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KryptonMessageBoxExtendedForm));
            this.knlBase = new Krypton.Toolkit.KryptonPanel();
            this.ktlpContent = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this._messageText = new Krypton.Toolkit.KryptonWrapLabel();
            this._panelButtons = new Krypton.Toolkit.KryptonPanel();
            this._borderEdge = new Krypton.Toolkit.KryptonBorderEdge();
            this._button4 = new Krypton.Toolkit.Suite.Extended.Messagebox.MessageButton();
            this._button3 = new Krypton.Toolkit.Suite.Extended.Messagebox.MessageButton();
            this._button1 = new Krypton.Toolkit.Suite.Extended.Messagebox.MessageButton();
            this._button2 = new Krypton.Toolkit.Suite.Extended.Messagebox.MessageButton();
            this._buttonDetails = new Krypton.Toolkit.Suite.Extended.Messagebox.MessageButton();
            this._messageIcon = new System.Windows.Forms.PictureBox();
            this.kpnlDetails = new Krypton.Toolkit.KryptonPanel();
            this.krtbDetails = new Krypton.Toolkit.KryptonRichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.knlBase)).BeginInit();
            this.knlBase.SuspendLayout();
            this.ktlpContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._panelButtons)).BeginInit();
            this._panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._messageIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlDetails)).BeginInit();
            this.kpnlDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // knlBase
            // 
            this.knlBase.Controls.Add(this.ktlpContent);
            this.knlBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.knlBase.Location = new System.Drawing.Point(0, 0);
            this.knlBase.Margin = new System.Windows.Forms.Padding(2);
            this.knlBase.Name = "knlBase";
            this.knlBase.Size = new System.Drawing.Size(188, 63);
            this.knlBase.TabIndex = 2;
            // 
            // ktlpContent
            // 
            this.ktlpContent.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ktlpContent.BackgroundImage")));
            this.ktlpContent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ktlpContent.ColumnCount = 2;
            this.ktlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ktlpContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ktlpContent.Controls.Add(this._messageText, 1, 0);
            this.ktlpContent.Controls.Add(this._panelButtons, 0, 1);
            this.ktlpContent.Controls.Add(this._messageIcon, 0, 0);
            this.ktlpContent.Controls.Add(this.kpnlDetails, 0, 2);
            this.ktlpContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ktlpContent.Location = new System.Drawing.Point(0, 0);
            this.ktlpContent.Margin = new System.Windows.Forms.Padding(2);
            this.ktlpContent.Name = "ktlpContent";
            this.ktlpContent.RowCount = 3;
            this.ktlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ktlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ktlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ktlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ktlpContent.Size = new System.Drawing.Size(188, 63);
            this.ktlpContent.TabIndex = 0;
            // 
            // _messageText
            // 
            this._messageText.AutoSize = false;
            this._messageText.Dock = System.Windows.Forms.DockStyle.Fill;
            this._messageText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._messageText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this._messageText.LabelStyle = Krypton.Toolkit.LabelStyle.NormalControl;
            this._messageText.Location = new System.Drawing.Point(49, 0);
            this._messageText.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this._messageText.Name = "_messageText";
            this._messageText.Size = new System.Drawing.Size(139, 22);
            this._messageText.Text = "Message Text";
            this._messageText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _panelButtons
            // 
            this.ktlpContent.SetColumnSpan(this._panelButtons, 2);
            this._panelButtons.Controls.Add(this._borderEdge);
            this._panelButtons.Controls.Add(this._button4);
            this._panelButtons.Controls.Add(this._button3);
            this._panelButtons.Controls.Add(this._button1);
            this._panelButtons.Controls.Add(this._button2);
            this._panelButtons.Controls.Add(this._buttonDetails);
            this._panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panelButtons.Location = new System.Drawing.Point(0, 22);
            this._panelButtons.Margin = new System.Windows.Forms.Padding(0);
            this._panelButtons.Name = "_panelButtons";
            this._panelButtons.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this._panelButtons.Size = new System.Drawing.Size(188, 21);
            this._panelButtons.TabIndex = 0;
            // 
            // _borderEdge
            // 
            this._borderEdge.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderPrimary;
            this._borderEdge.Dock = System.Windows.Forms.DockStyle.Top;
            this._borderEdge.Location = new System.Drawing.Point(0, 0);
            this._borderEdge.Margin = new System.Windows.Forms.Padding(2);
            this._borderEdge.Name = "_borderEdge";
            this._borderEdge.Size = new System.Drawing.Size(188, 1);
            this._borderEdge.Text = "kryptonBorderEdge1";
            // 
            // _button4
            // 
            this._button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._button4.AutoSize = true;
            this._button4.CornerRoundingRadius = -1F;
            this._button4.Enabled = false;
            this._button4.IgnoreAltF4 = false;
            this._button4.Location = new System.Drawing.Point(188, 0);
            this._button4.Margin = new System.Windows.Forms.Padding(0);
            this._button4.MinimumSize = new System.Drawing.Size(38, 21);
            this._button4.Name = "_button4";
            this._button4.Size = new System.Drawing.Size(38, 23);
            this._button4.TabIndex = 2;
            this._button4.Values.Text = "B4";
            this._button4.Visible = false;
            // 
            // _button3
            // 
            this._button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._button3.AutoSize = true;
            this._button3.CornerRoundingRadius = -1F;
            this._button3.Enabled = false;
            this._button3.IgnoreAltF4 = false;
            this._button3.Location = new System.Drawing.Point(151, 0);
            this._button3.Margin = new System.Windows.Forms.Padding(0);
            this._button3.MinimumSize = new System.Drawing.Size(38, 21);
            this._button3.Name = "_button3";
            this._button3.Size = new System.Drawing.Size(38, 23);
            this._button3.TabIndex = 2;
            this._button3.Values.Text = "B3";
            this._button3.Visible = false;
            // 
            // _button1
            // 
            this._button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._button1.AutoSize = true;
            this._button1.CornerRoundingRadius = -1F;
            this._button1.Enabled = false;
            this._button1.IgnoreAltF4 = false;
            this._button1.Location = new System.Drawing.Point(75, 0);
            this._button1.Margin = new System.Windows.Forms.Padding(0);
            this._button1.MinimumSize = new System.Drawing.Size(38, 21);
            this._button1.Name = "_button1";
            this._button1.Size = new System.Drawing.Size(38, 23);
            this._button1.TabIndex = 0;
            this._button1.Values.Text = "B1";
            this._button1.Visible = false;
            // 
            // _button2
            // 
            this._button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._button2.AutoSize = true;
            this._button2.CornerRoundingRadius = -1F;
            this._button2.Enabled = false;
            this._button2.IgnoreAltF4 = false;
            this._button2.Location = new System.Drawing.Point(113, 0);
            this._button2.Margin = new System.Windows.Forms.Padding(0);
            this._button2.MinimumSize = new System.Drawing.Size(38, 21);
            this._button2.Name = "_button2";
            this._button2.Size = new System.Drawing.Size(38, 23);
            this._button2.TabIndex = 1;
            this._button2.Values.Text = "B2";
            this._button2.Visible = false;
            // 
            // _buttonDetails
            // 
            this._buttonDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonDetails.AutoSize = true;
            this._buttonDetails.CornerRoundingRadius = -1F;
            this._buttonDetails.Enabled = false;
            this._buttonDetails.IgnoreAltF4 = false;
            this._buttonDetails.Location = new System.Drawing.Point(0, 0);
            this._buttonDetails.Margin = new System.Windows.Forms.Padding(0);
            this._buttonDetails.MinimumSize = new System.Drawing.Size(38, 21);
            this._buttonDetails.Name = "_buttonDetails";
            this._buttonDetails.Size = new System.Drawing.Size(38, 23);
            this._buttonDetails.TabIndex = 4;
            this._buttonDetails.Values.Text = "BM";
            this._buttonDetails.Visible = false;
            this._buttonDetails.Click += new System.EventHandler(this.MoreDetails_Click);
            // 
            // _messageIcon
            // 
            this._messageIcon.BackColor = System.Drawing.Color.Transparent;
            this._messageIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this._messageIcon.Location = new System.Drawing.Point(8, 4);
            this._messageIcon.Margin = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this._messageIcon.Name = "_messageIcon";
            this._messageIcon.Size = new System.Drawing.Size(33, 14);
            this._messageIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this._messageIcon.TabIndex = 0;
            this._messageIcon.TabStop = false;
            // 
            // kpnlDetails
            // 
            this.ktlpContent.SetColumnSpan(this.kpnlDetails, 2);
            this.kpnlDetails.Controls.Add(this.krtbDetails);
            this.kpnlDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpnlDetails.Location = new System.Drawing.Point(3, 46);
            this.kpnlDetails.Name = "kpnlDetails";
            this.kpnlDetails.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kpnlDetails.Size = new System.Drawing.Size(182, 14);
            this.kpnlDetails.TabIndex = 1;
            // 
            // krtbDetails
            // 
            this.krtbDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.krtbDetails.InputControlStyle = Krypton.Toolkit.InputControlStyle.PanelAlternate;
            this.krtbDetails.Location = new System.Drawing.Point(0, 0);
            this.krtbDetails.Name = "krtbDetails";
            this.krtbDetails.ReadOnly = true;
            this.krtbDetails.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.krtbDetails.Size = new System.Drawing.Size(182, 14);
            this.krtbDetails.TabIndex = 0;
            this.krtbDetails.Text = "";
            // 
            // KryptonMessageBoxExtendedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(188, 63);
            this.Controls.Add(this.knlBase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonMessageBoxExtendedForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.knlBase)).EndInit();
            this.knlBase.ResumeLayout(false);
            this.ktlpContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._panelButtons)).EndInit();
            this._panelButtons.ResumeLayout(false);
            this._panelButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._messageIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlDetails)).EndInit();
            this.kpnlDetails.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonPanel knlBase;
        private KryptonTableLayoutPanel ktlpContent;
        private KryptonWrapLabel _messageText;
        private KryptonPanel _panelButtons;
        private KryptonBorderEdge _borderEdge;
        private MessageButton _button4;
        private MessageButton _button3;
        private MessageButton _button1;
        private MessageButton _button2;
        private PictureBox _messageIcon;
        private MessageButton _buttonDetails;
        private KryptonPanel kpnlDetails;
        private KryptonRichTextBox krtbDetails;
    }
}