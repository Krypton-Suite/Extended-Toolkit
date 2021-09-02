namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
{
    public class CustomFormatRule : KryptonForm
    {
        #region Design Code

        #endregion

        private KryptonPanel kryptonPanel1;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonButton kbtnOk;
        private KryptonButton kbtnCancel;
        private KryptonGroup kryptonGroup1;
        private KryptonColorButton kryptonColorButton1;
        private PictureBox pbxPreview;
        private KryptonLabel kryptonLabel2;
        private KryptonComboBox kcmbStyle;
        private KryptonLabel kryptonLabel1;
        private KryptonComboBox kcmbFillMode;
        private KryptonLabel kryptonLabel3;
        private KryptonColorButton kryptonColorButton3;
        private KryptonColorButton kryptonColorButton2;
        private KryptonPanel kryptonPanel2;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.kbtnOk = new Krypton.Toolkit.KryptonButton();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kcmbStyle = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonGroup1 = new Krypton.Toolkit.KryptonGroup();
            this.kryptonColorButton1 = new Krypton.Toolkit.KryptonColorButton();
            this.kryptonColorButton2 = new Krypton.Toolkit.KryptonColorButton();
            this.kryptonColorButton3 = new Krypton.Toolkit.KryptonColorButton();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.kcmbFillMode = new Krypton.Toolkit.KryptonComboBox();
            this.pbxPreview = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbStyle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1.Panel)).BeginInit();
            this.kryptonGroup1.Panel.SuspendLayout();
            this.kryptonGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbFillMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnOk);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 169);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(440, 50);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderPrimary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(440, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kcmbFillMode);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel3);
            this.kryptonPanel2.Controls.Add(this.kryptonGroup1);
            this.kryptonPanel2.Controls.Add(this.pbxPreview);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel2.Controls.Add(this.kcmbStyle);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(440, 169);
            this.kryptonPanel2.TabIndex = 1;
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(338, 13);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Orientation = Krypton.Toolkit.VisualOrientation.Top;
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 2;
            this.kbtnCancel.Values.Text = "Cance&l";
            // 
            // kbtnOk
            // 
            this.kbtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnOk.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.kbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnOk.Location = new System.Drawing.Point(242, 13);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Orientation = Krypton.Toolkit.VisualOrientation.Top;
            this.kbtnOk.Size = new System.Drawing.Size(90, 25);
            this.kbtnOk.TabIndex = 3;
            this.kbtnOk.Values.Text = "&OK";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel1.Location = new System.Drawing.Point(13, 13);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(56, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Format:";
            // 
            // kcmbStyle
            // 
            this.kcmbStyle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.kcmbStyle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.kcmbStyle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.kcmbStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbStyle.DropDownWidth = 290;
            this.kcmbStyle.IntegralHeight = false;
            this.kcmbStyle.Location = new System.Drawing.Point(93, 13);
            this.kcmbStyle.Name = "kcmbStyle";
            this.kcmbStyle.Size = new System.Drawing.Size(290, 21);
            this.kcmbStyle.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbStyle.TabIndex = 1;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel2.Location = new System.Drawing.Point(13, 51);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(60, 20);
            this.kryptonLabel2.TabIndex = 2;
            this.kryptonLabel2.Values.Text = "Preview:";
            // 
            // kryptonGroup1
            // 
            this.kryptonGroup1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kryptonGroup1.Location = new System.Drawing.Point(13, 78);
            this.kryptonGroup1.Name = "kryptonGroup1";
            // 
            // kryptonGroup1.Panel
            // 
            this.kryptonGroup1.Panel.Controls.Add(this.kryptonColorButton3);
            this.kryptonGroup1.Panel.Controls.Add(this.kryptonColorButton2);
            this.kryptonGroup1.Panel.Controls.Add(this.kryptonColorButton1);
            this.kryptonGroup1.Size = new System.Drawing.Size(415, 38);
            this.kryptonGroup1.TabIndex = 4;
            // 
            // kryptonColorButton1
            // 
            this.kryptonColorButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.kryptonColorButton1.ButtonOrientation = Krypton.Toolkit.VisualOrientation.Top;
            this.kryptonColorButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.kryptonColorButton1.DropDownOrientation = Krypton.Toolkit.VisualOrientation.Bottom;
            this.kryptonColorButton1.DropDownPosition = Krypton.Toolkit.VisualOrientation.Right;
            this.kryptonColorButton1.EmptyBorderColor = System.Drawing.Color.DarkGray;
            this.kryptonColorButton1.Location = new System.Drawing.Point(7, 5);
            this.kryptonColorButton1.Name = "kryptonColorButton1";
            this.kryptonColorButton1.SchemeStandard = Krypton.Toolkit.ColorScheme.OfficeStandard;
            this.kryptonColorButton1.SchemeThemes = Krypton.Toolkit.ColorScheme.OfficeThemes;
            this.kryptonColorButton1.SelectedColor = System.Drawing.Color.White;
            this.kryptonColorButton1.SelectedRect = new System.Drawing.Rectangle(0, 12, 16, 4);
            this.kryptonColorButton1.Size = new System.Drawing.Size(100, 25);
            this.kryptonColorButton1.Splitter = false;
            this.kryptonColorButton1.TabIndex = 0;
            this.kryptonColorButton1.Values.Image = null;
            this.kryptonColorButton1.Values.Text = "Mi&n Colour";
            this.kryptonColorButton1.VisibleNoColor = false;
            // 
            // kryptonColorButton2
            // 
            this.kryptonColorButton2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.kryptonColorButton2.ButtonOrientation = Krypton.Toolkit.VisualOrientation.Top;
            this.kryptonColorButton2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.kryptonColorButton2.DropDownOrientation = Krypton.Toolkit.VisualOrientation.Bottom;
            this.kryptonColorButton2.DropDownPosition = Krypton.Toolkit.VisualOrientation.Right;
            this.kryptonColorButton2.EmptyBorderColor = System.Drawing.Color.DarkGray;
            this.kryptonColorButton2.Location = new System.Drawing.Point(113, 5);
            this.kryptonColorButton2.Name = "kryptonColorButton2";
            this.kryptonColorButton2.SchemeStandard = Krypton.Toolkit.ColorScheme.OfficeStandard;
            this.kryptonColorButton2.SchemeThemes = Krypton.Toolkit.ColorScheme.OfficeThemes;
            this.kryptonColorButton2.SelectedColor = System.Drawing.Color.White;
            this.kryptonColorButton2.SelectedRect = new System.Drawing.Rectangle(0, 12, 16, 4);
            this.kryptonColorButton2.Size = new System.Drawing.Size(143, 25);
            this.kryptonColorButton2.Splitter = false;
            this.kryptonColorButton2.TabIndex = 1;
            this.kryptonColorButton2.Values.Image = null;
            this.kryptonColorButton2.Values.Text = "M&edium Colour";
            this.kryptonColorButton2.VisibleNoColor = false;
            // 
            // kryptonColorButton3
            // 
            this.kryptonColorButton3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.kryptonColorButton3.ButtonOrientation = Krypton.Toolkit.VisualOrientation.Top;
            this.kryptonColorButton3.DialogResult = System.Windows.Forms.DialogResult.None;
            this.kryptonColorButton3.DropDownOrientation = Krypton.Toolkit.VisualOrientation.Bottom;
            this.kryptonColorButton3.DropDownPosition = Krypton.Toolkit.VisualOrientation.Right;
            this.kryptonColorButton3.EmptyBorderColor = System.Drawing.Color.DarkGray;
            this.kryptonColorButton3.Location = new System.Drawing.Point(262, 5);
            this.kryptonColorButton3.Name = "kryptonColorButton3";
            this.kryptonColorButton3.SchemeStandard = Krypton.Toolkit.ColorScheme.OfficeStandard;
            this.kryptonColorButton3.SchemeThemes = Krypton.Toolkit.ColorScheme.OfficeThemes;
            this.kryptonColorButton3.SelectedColor = System.Drawing.Color.White;
            this.kryptonColorButton3.SelectedRect = new System.Drawing.Rectangle(0, 12, 16, 4);
            this.kryptonColorButton3.Size = new System.Drawing.Size(107, 25);
            this.kryptonColorButton3.Splitter = false;
            this.kryptonColorButton3.TabIndex = 2;
            this.kryptonColorButton3.Values.Image = null;
            this.kryptonColorButton3.Values.Text = "M&ax Colour";
            this.kryptonColorButton3.VisibleNoColor = false;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.LabelStyle = Krypton.Toolkit.LabelStyle.NormalControl;
            this.kryptonLabel3.Location = new System.Drawing.Point(13, 131);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(28, 20);
            this.kryptonLabel3.TabIndex = 5;
            this.kryptonLabel3.Values.Text = "Fill:";
            // 
            // kcmbFillMode
            // 
            this.kcmbFillMode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.kcmbFillMode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.kcmbFillMode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.kcmbFillMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbFillMode.DropDownWidth = 198;
            this.kcmbFillMode.IntegralHeight = false;
            this.kcmbFillMode.Items.AddRange(new object[] {
            "&Solid",
            "Gra&dient"});
            this.kcmbFillMode.Location = new System.Drawing.Point(93, 131);
            this.kcmbFillMode.Name = "kcmbFillMode";
            this.kcmbFillMode.Size = new System.Drawing.Size(198, 21);
            this.kcmbFillMode.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbFillMode.TabIndex = 6;
            // 
            // pbxPreview
            // 
            this.pbxPreview.BackColor = System.Drawing.Color.Transparent;
            this.pbxPreview.Location = new System.Drawing.Point(93, 51);
            this.pbxPreview.Name = "pbxPreview";
            this.pbxPreview.Size = new System.Drawing.Size(290, 20);
            this.pbxPreview.TabIndex = 3;
            this.pbxPreview.TabStop = false;
            // 
            // CustomFormatRule
            // 
            this.ClientSize = new System.Drawing.Size(440, 219);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomFormatRule";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Custom Rule";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbStyle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1.Panel)).EndInit();
            this.kryptonGroup1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1)).EndInit();
            this.kryptonGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kcmbFillMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPreview)).EndInit();
            this.ResumeLayout(false);

        }
    }
}