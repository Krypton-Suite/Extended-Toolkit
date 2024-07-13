namespace Krypton.Toolkit.Suite.Extended.ToastNotification
{
    partial class VisualToastNotificationBasicPBForm
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
            this.kpnlButtons = new Krypton.Toolkit.KryptonPanel();
            this.tlpButtonsAndControls = new System.Windows.Forms.TableLayoutPanel();
            this.kbtnDismiss = new Krypton.Toolkit.KryptonButton();
            this.kbtnExtraAction = new Krypton.Toolkit.KryptonButton();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kpnlMain = new Krypton.Toolkit.KryptonPanel();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.pbxNotificationIcon = new System.Windows.Forms.PictureBox();
            this.klblNotificationTitle = new Krypton.Toolkit.KryptonLabel();
            this.krtbNotificationContent = new Krypton.Toolkit.KryptonRichTextBox();
            this.kbtnClose = new Krypton.Toolkit.KryptonButton();
            this.kpbCountDown = new Krypton.Toolkit.KryptonProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlButtons)).BeginInit();
            this.kpnlButtons.SuspendLayout();
            this.tlpButtonsAndControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlMain)).BeginInit();
            this.kpnlMain.SuspendLayout();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxNotificationIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // kpnlButtons
            // 
            this.kpnlButtons.Controls.Add(this.tlpButtonsAndControls);
            this.kpnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kpnlButtons.Location = new System.Drawing.Point(0, 180);
            this.kpnlButtons.Name = "kpnlButtons";
            this.kpnlButtons.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kpnlButtons.Size = new System.Drawing.Size(439, 50);
            this.kpnlButtons.TabIndex = 1;
            // 
            // tlpButtonsAndControls
            // 
            this.tlpButtonsAndControls.BackColor = System.Drawing.Color.Transparent;
            this.tlpButtonsAndControls.ColumnCount = 3;
            this.tlpButtonsAndControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtonsAndControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpButtonsAndControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpButtonsAndControls.Controls.Add(this.kbtnDismiss, 2, 0);
            this.tlpButtonsAndControls.Controls.Add(this.kbtnExtraAction, 1, 0);
            this.tlpButtonsAndControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpButtonsAndControls.Location = new System.Drawing.Point(0, 0);
            this.tlpButtonsAndControls.Name = "tlpButtonsAndControls";
            this.tlpButtonsAndControls.RowCount = 1;
            this.tlpButtonsAndControls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtonsAndControls.Size = new System.Drawing.Size(439, 50);
            this.tlpButtonsAndControls.TabIndex = 0;
            // 
            // kbtnDismiss
            // 
            this.kbtnDismiss.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.kbtnDismiss.AutoSize = true;
            this.kbtnDismiss.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnDismiss.Location = new System.Drawing.Point(335, 14);
            this.kbtnDismiss.Margin = new System.Windows.Forms.Padding(10);
            this.kbtnDismiss.Name = "kbtnDismiss";
            this.kbtnDismiss.Size = new System.Drawing.Size(94, 22);
            this.kbtnDismiss.TabIndex = 0;
            this.kbtnDismiss.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.kbtnDismiss.Values.Text = "kryptonButton1";
            this.kbtnDismiss.Click += new System.EventHandler(this.kbtnDismiss_Click);
            // 
            // kbtnExtraAction
            // 
            this.kbtnExtraAction.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.kbtnExtraAction.AutoSize = true;
            this.kbtnExtraAction.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnExtraAction.Location = new System.Drawing.Point(221, 14);
            this.kbtnExtraAction.Margin = new System.Windows.Forms.Padding(10);
            this.kbtnExtraAction.Name = "kbtnExtraAction";
            this.kbtnExtraAction.Size = new System.Drawing.Size(94, 22);
            this.kbtnExtraAction.TabIndex = 1;
            this.kbtnExtraAction.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.kbtnExtraAction.Values.Text = "kryptonButton2";
            this.kbtnExtraAction.Visible = false;
            this.kbtnExtraAction.Click += new System.EventHandler(this.kbtnExtraAction_Click);
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderPrimary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 179);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(439, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kpnlMain
            // 
            this.kpnlMain.Controls.Add(this.tlpMain);
            this.kpnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpnlMain.Location = new System.Drawing.Point(0, 0);
            this.kpnlMain.Name = "kpnlMain";
            this.kpnlMain.Size = new System.Drawing.Size(439, 179);
            this.kpnlMain.TabIndex = 3;
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.Color.Transparent;
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.pbxNotificationIcon, 0, 0);
            this.tlpMain.Controls.Add(this.klblNotificationTitle, 1, 1);
            this.tlpMain.Controls.Add(this.krtbNotificationContent, 1, 2);
            this.tlpMain.Controls.Add(this.kbtnClose, 1, 0);
            this.tlpMain.Controls.Add(this.kpbCountDown, 0, 3);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 4;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.Size = new System.Drawing.Size(439, 179);
            this.tlpMain.TabIndex = 0;
            // 
            // pbxNotificationIcon
            // 
            this.pbxNotificationIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbxNotificationIcon.Location = new System.Drawing.Point(5, 5);
            this.pbxNotificationIcon.Margin = new System.Windows.Forms.Padding(5);
            this.pbxNotificationIcon.Name = "pbxNotificationIcon";
            this.pbxNotificationIcon.Padding = new System.Windows.Forms.Padding(5);
            this.tlpMain.SetRowSpan(this.pbxNotificationIcon, 3);
            this.pbxNotificationIcon.Size = new System.Drawing.Size(128, 133);
            this.pbxNotificationIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbxNotificationIcon.TabIndex = 0;
            this.pbxNotificationIcon.TabStop = false;
            // 
            // klblNotificationTitle
            // 
            this.klblNotificationTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klblNotificationTitle.LabelStyle = Krypton.Toolkit.LabelStyle.TitlePanel;
            this.klblNotificationTitle.Location = new System.Drawing.Point(141, 29);
            this.klblNotificationTitle.Name = "klblNotificationTitle";
            this.klblNotificationTitle.Size = new System.Drawing.Size(295, 29);
            this.klblNotificationTitle.TabIndex = 2;
            this.klblNotificationTitle.Values.Text = "kryptonLabel2";
            // 
            // krtbNotificationContent
            // 
            this.krtbNotificationContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.krtbNotificationContent.InputControlStyle = Krypton.Toolkit.InputControlStyle.PanelClient;
            this.krtbNotificationContent.Location = new System.Drawing.Point(141, 64);
            this.krtbNotificationContent.Name = "krtbNotificationContent";
            this.krtbNotificationContent.Size = new System.Drawing.Size(295, 76);
            this.krtbNotificationContent.StateCommon.Border.Color1 = System.Drawing.Color.Transparent;
            this.krtbNotificationContent.StateCommon.Border.Color2 = System.Drawing.Color.Transparent;
            this.krtbNotificationContent.TabIndex = 3;
            this.krtbNotificationContent.Text = "kryptonRichTextBox1";
            // 
            // kbtnClose
            // 
            this.kbtnClose.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.kbtnClose.AutoSize = true;
            this.kbtnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kbtnClose.ButtonStyle = Krypton.Toolkit.ButtonStyle.FormClose;
            this.kbtnClose.Location = new System.Drawing.Point(422, 3);
            this.kbtnClose.Name = "kbtnClose";
            this.kbtnClose.Size = new System.Drawing.Size(14, 20);
            this.kbtnClose.TabIndex = 4;
            this.kbtnClose.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this.kbtnClose.Values.Text = "X";
            this.kbtnClose.Click += new System.EventHandler(this.kbtnClose_Click);
            // 
            // kpbCountDown
            // 
            this.tlpMain.SetColumnSpan(this.kpbCountDown, 2);
            this.kpbCountDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpbCountDown.Location = new System.Drawing.Point(5, 148);
            this.kpbCountDown.Margin = new System.Windows.Forms.Padding(5);
            this.kpbCountDown.Name = "kpbCountDown";
            this.kpbCountDown.Size = new System.Drawing.Size(429, 26);
            this.kpbCountDown.StateCommon.Back.Color1 = System.Drawing.Color.Green;
            this.kpbCountDown.StateDisabled.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.OneNote;
            this.kpbCountDown.StateNormal.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.OneNote;
            this.kpbCountDown.TabIndex = 5;
            this.kpbCountDown.Values.Text = "";
            // 
            // VisualToastNotificationBasicWithProgressBarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 230);
            this.Controls.Add(this.kpnlMain);
            this.Controls.Add(this.kryptonBorderEdge1);
            this.Controls.Add(this.kpnlButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VisualToastNotificationBasicWithProgressBarForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.VisualToastNotificationBasicWithProgressBarForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kpnlButtons)).EndInit();
            this.kpnlButtons.ResumeLayout(false);
            this.tlpButtonsAndControls.ResumeLayout(false);
            this.tlpButtonsAndControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlMain)).EndInit();
            this.kpnlMain.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxNotificationIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KryptonPanel kpnlButtons;
        private TableLayoutPanel tlpButtonsAndControls;
        private KryptonButton kbtnDismiss;
        private KryptonButton kbtnExtraAction;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonPanel kpnlMain;
        private TableLayoutPanel tlpMain;
        private PictureBox pbxNotificationIcon;
        private KryptonLabel klblNotificationTitle;
        private KryptonRichTextBox krtbNotificationContent;
        private KryptonButton kbtnClose;
        private KryptonProgressBar kpbCountDown;
    }
}