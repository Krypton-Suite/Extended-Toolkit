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
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonTableLayoutPanel1 = new Krypton.Toolkit.KryptonTableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.messageButton1 = new Krypton.Toolkit.Suite.Extended.Messagebox.MessageButton();
            this.messageButton2 = new Krypton.Toolkit.Suite.Extended.Messagebox.MessageButton();
            this.messageButton3 = new Krypton.Toolkit.Suite.Extended.Messagebox.MessageButton();
            this.messageButton4 = new Krypton.Toolkit.Suite.Extended.Messagebox.MessageButton();
            this.messageButton5 = new Krypton.Toolkit.Suite.Extended.Messagebox.MessageButton();
            this.kryptonWrapLabel1 = new Krypton.Toolkit.KryptonWrapLabel();
            this.kryptonPanel4 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonRichTextBox1 = new Krypton.Toolkit.KryptonRichTextBox();
            this.kryptonCheckBox1 = new Krypton.Toolkit.KryptonCheckBox();
            this.kryptonLinkLabel1 = new Krypton.Toolkit.KryptonLinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.knlBase)).BeginInit();
            this.knlBase.SuspendLayout();
            this.ktlpContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._panelButtons)).BeginInit();
            this._panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._messageIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlDetails)).BeginInit();
            this.kpnlDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.kryptonTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel4)).BeginInit();
            this.kryptonPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // knlBase
            // 
            this.knlBase.Controls.Add(this.ktlpContent);
            this.knlBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.knlBase.Location = new System.Drawing.Point(0, 0);
            this.knlBase.Margin = new System.Windows.Forms.Padding(2);
            this.knlBase.Name = "knlBase";
            this.knlBase.Size = new System.Drawing.Size(188, 81);
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
            this.ktlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ktlpContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.ktlpContent.Size = new System.Drawing.Size(188, 81);
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
            this._messageText.Size = new System.Drawing.Size(139, 40);
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
            this._panelButtons.Location = new System.Drawing.Point(0, 40);
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
            this._messageIcon.Size = new System.Drawing.Size(33, 32);
            this._messageIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this._messageIcon.TabIndex = 0;
            this._messageIcon.TabStop = false;
            // 
            // kpnlDetails
            // 
            this.ktlpContent.SetColumnSpan(this.kpnlDetails, 2);
            this.kpnlDetails.Controls.Add(this.krtbDetails);
            this.kpnlDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpnlDetails.Location = new System.Drawing.Point(3, 64);
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
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonTableLayoutPanel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(188, 81);
            this.kryptonPanel1.TabIndex = 3;
            // 
            // kryptonTableLayoutPanel1
            // 
            this.kryptonTableLayoutPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("kryptonTableLayoutPanel1.BackgroundImage")));
            this.kryptonTableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.kryptonTableLayoutPanel1.ColumnCount = 2;
            this.kryptonTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.kryptonTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.kryptonTableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.kryptonTableLayoutPanel1.Controls.Add(this.kryptonPanel2, 0, 1);
            this.kryptonTableLayoutPanel1.Controls.Add(this.kryptonWrapLabel1, 1, 0);
            this.kryptonTableLayoutPanel1.Controls.Add(this.kryptonPanel4, 0, 2);
            this.kryptonTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonTableLayoutPanel1.Name = "kryptonTableLayoutPanel1";
            this.kryptonTableLayoutPanel1.RowCount = 3;
            this.kryptonTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.kryptonTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.kryptonTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.kryptonTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.kryptonTableLayoutPanel1.Size = new System.Drawing.Size(188, 81);
            this.kryptonTableLayoutPanel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(8, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // kryptonPanel2
            // 
            this.kryptonTableLayoutPanel1.SetColumnSpan(this.kryptonPanel2, 2);
            this.kryptonPanel2.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel2.Controls.Add(this.messageButton1);
            this.kryptonPanel2.Controls.Add(this.messageButton2);
            this.kryptonPanel2.Controls.Add(this.messageButton3);
            this.kryptonPanel2.Controls.Add(this.messageButton4);
            this.kryptonPanel2.Controls.Add(this.messageButton5);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 40);
            this.kryptonPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel2.Size = new System.Drawing.Size(188, 21);
            this.kryptonPanel2.TabIndex = 2;
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
            // messageButton1
            // 
            this.messageButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.messageButton1.AutoSize = true;
            this.messageButton1.CornerRoundingRadius = -1F;
            this.messageButton1.Enabled = false;
            this.messageButton1.IgnoreAltF4 = false;
            this.messageButton1.Location = new System.Drawing.Point(188, 0);
            this.messageButton1.Margin = new System.Windows.Forms.Padding(0);
            this.messageButton1.MinimumSize = new System.Drawing.Size(38, 21);
            this.messageButton1.Name = "messageButton1";
            this.messageButton1.Size = new System.Drawing.Size(38, 23);
            this.messageButton1.TabIndex = 2;
            this.messageButton1.Values.Text = "B4";
            this.messageButton1.Visible = false;
            // 
            // messageButton2
            // 
            this.messageButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.messageButton2.AutoSize = true;
            this.messageButton2.CornerRoundingRadius = -1F;
            this.messageButton2.Enabled = false;
            this.messageButton2.IgnoreAltF4 = false;
            this.messageButton2.Location = new System.Drawing.Point(151, 0);
            this.messageButton2.Margin = new System.Windows.Forms.Padding(0);
            this.messageButton2.MinimumSize = new System.Drawing.Size(38, 21);
            this.messageButton2.Name = "messageButton2";
            this.messageButton2.Size = new System.Drawing.Size(38, 23);
            this.messageButton2.TabIndex = 2;
            this.messageButton2.Values.Text = "B3";
            this.messageButton2.Visible = false;
            // 
            // messageButton3
            // 
            this.messageButton3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.messageButton3.AutoSize = true;
            this.messageButton3.CornerRoundingRadius = -1F;
            this.messageButton3.Enabled = false;
            this.messageButton3.IgnoreAltF4 = false;
            this.messageButton3.Location = new System.Drawing.Point(75, 0);
            this.messageButton3.Margin = new System.Windows.Forms.Padding(0);
            this.messageButton3.MinimumSize = new System.Drawing.Size(38, 21);
            this.messageButton3.Name = "messageButton3";
            this.messageButton3.Size = new System.Drawing.Size(38, 23);
            this.messageButton3.TabIndex = 0;
            this.messageButton3.Values.Text = "B1";
            this.messageButton3.Visible = false;
            // 
            // messageButton4
            // 
            this.messageButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.messageButton4.AutoSize = true;
            this.messageButton4.CornerRoundingRadius = -1F;
            this.messageButton4.Enabled = false;
            this.messageButton4.IgnoreAltF4 = false;
            this.messageButton4.Location = new System.Drawing.Point(113, 0);
            this.messageButton4.Margin = new System.Windows.Forms.Padding(0);
            this.messageButton4.MinimumSize = new System.Drawing.Size(38, 21);
            this.messageButton4.Name = "messageButton4";
            this.messageButton4.Size = new System.Drawing.Size(38, 23);
            this.messageButton4.TabIndex = 1;
            this.messageButton4.Values.Text = "B2";
            this.messageButton4.Visible = false;
            // 
            // messageButton5
            // 
            this.messageButton5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.messageButton5.AutoSize = true;
            this.messageButton5.CornerRoundingRadius = -1F;
            this.messageButton5.Enabled = false;
            this.messageButton5.IgnoreAltF4 = false;
            this.messageButton5.Location = new System.Drawing.Point(0, 0);
            this.messageButton5.Margin = new System.Windows.Forms.Padding(0);
            this.messageButton5.MinimumSize = new System.Drawing.Size(38, 21);
            this.messageButton5.Name = "messageButton5";
            this.messageButton5.Size = new System.Drawing.Size(38, 23);
            this.messageButton5.TabIndex = 4;
            this.messageButton5.Values.Text = "BM";
            this.messageButton5.Visible = false;
            // 
            // kryptonWrapLabel1
            // 
            this.kryptonWrapLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonWrapLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonWrapLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kryptonWrapLabel1.LabelStyle = Krypton.Toolkit.LabelStyle.NormalControl;
            this.kryptonWrapLabel1.Location = new System.Drawing.Point(46, 0);
            this.kryptonWrapLabel1.Name = "kryptonWrapLabel1";
            this.kryptonWrapLabel1.Size = new System.Drawing.Size(139, 40);
            this.kryptonWrapLabel1.Text = "kryptonWrapLabel1";
            this.kryptonWrapLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // kryptonPanel4
            // 
            this.kryptonTableLayoutPanel1.SetColumnSpan(this.kryptonPanel4, 2);
            this.kryptonPanel4.Controls.Add(this.kryptonRichTextBox1);
            this.kryptonPanel4.Controls.Add(this.kryptonCheckBox1);
            this.kryptonPanel4.Controls.Add(this.kryptonLinkLabel1);
            this.kryptonPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel4.Location = new System.Drawing.Point(3, 64);
            this.kryptonPanel4.Name = "kryptonPanel4";
            this.kryptonPanel4.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel4.Size = new System.Drawing.Size(182, 14);
            this.kryptonPanel4.TabIndex = 4;
            // 
            // kryptonRichTextBox1
            // 
            this.kryptonRichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonRichTextBox1.InputControlStyle = Krypton.Toolkit.InputControlStyle.PanelAlternate;
            this.kryptonRichTextBox1.Location = new System.Drawing.Point(0, 0);
            this.kryptonRichTextBox1.Name = "kryptonRichTextBox1";
            this.kryptonRichTextBox1.ReadOnly = true;
            this.kryptonRichTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.kryptonRichTextBox1.Size = new System.Drawing.Size(182, 14);
            this.kryptonRichTextBox1.TabIndex = 0;
            this.kryptonRichTextBox1.Text = "";
            // 
            // kryptonCheckBox1
            // 
            this.kryptonCheckBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonCheckBox1.Location = new System.Drawing.Point(0, 0);
            this.kryptonCheckBox1.Name = "kryptonCheckBox1";
            this.kryptonCheckBox1.Size = new System.Drawing.Size(182, 14);
            this.kryptonCheckBox1.TabIndex = 1;
            this.kryptonCheckBox1.Values.Text = "CB1";
            this.kryptonCheckBox1.Visible = false;
            // 
            // kryptonLinkLabel1
            // 
            this.kryptonLinkLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonLinkLabel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonLinkLabel1.Name = "kryptonLinkLabel1";
            this.kryptonLinkLabel1.Size = new System.Drawing.Size(182, 14);
            this.kryptonLinkLabel1.TabIndex = 2;
            this.kryptonLinkLabel1.Values.Text = "LL1";
            this.kryptonLinkLabel1.Visible = false;
            // 
            // KryptonMessageBoxExtendedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(188, 81);
            this.Controls.Add(this.kryptonPanel1);
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
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonTableLayoutPanel1.ResumeLayout(false);
            this.kryptonTableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel4)).EndInit();
            this.kryptonPanel4.ResumeLayout(false);
            this.kryptonPanel4.PerformLayout();
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
        private KryptonPanel kryptonPanel1;
        private KryptonTableLayoutPanel kryptonTableLayoutPanel1;
        private PictureBox pictureBox1;
        private KryptonPanel kryptonPanel2;
        private KryptonBorderEdge kryptonBorderEdge1;
        private MessageButton messageButton1;
        private MessageButton messageButton2;
        private MessageButton messageButton3;
        private MessageButton messageButton4;
        private MessageButton messageButton5;
        private KryptonWrapLabel kryptonWrapLabel1;
        private KryptonPanel kryptonPanel4;
        private KryptonRichTextBox kryptonRichTextBox1;
        private KryptonCheckBox kryptonCheckBox1;
        private KryptonLinkLabel kryptonLinkLabel1;
    }
}