#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */

//--------------------------------------------------------------------------------
// Copyright (C) 2013-2021 JDH Software - <support@jdhsoftware.com>
//
// This program is provided to you under the terms of the Microsoft Public
// License (Ms-PL) as published at https://github.com/Cocotteseb/Krypton-OutlookGrid/blob/master/LICENSE.md
//
// Visit https://www.jdhsoftware.com and follow @jdhsoftware on Twitter
//
//--------------------------------------------------------------------------------
#endregion

namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
{
    public class CustomFormatRule : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonButton kbtnOk;
        private KryptonButton kbtnCancel;
        private KryptonGroup kryptonGroup1;
        private KryptonColorButton kcbMinColour;
        private PictureBox pbxPreview;
        private KryptonLabel klblPreview;
        private KryptonComboBox kcmbStyle;
        private KryptonLabel klblFormat;
        private KryptonComboBox kcmbFillMode;
        private KryptonLabel klblFill;
        private KryptonColorButton kcbMaxColour;
        private KryptonColorButton kcbMediumColour;
        private KryptonPanel kryptonPanel2;

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(CustomFormatRule));
            kryptonPanel1 = new KryptonPanel();
            kbtnOk = new KryptonButton();
            kbtnCancel = new KryptonButton();
            kryptonBorderEdge1 = new KryptonBorderEdge();
            kryptonPanel2 = new KryptonPanel();
            kcmbFillMode = new KryptonComboBox();
            klblFill = new KryptonLabel();
            kryptonGroup1 = new KryptonGroup();
            kcbMaxColour = new KryptonColorButton();
            kcbMediumColour = new KryptonColorButton();
            kcbMinColour = new KryptonColorButton();
            pbxPreview = new PictureBox();
            klblPreview = new KryptonLabel();
            kcmbStyle = new KryptonComboBox();
            klblFormat = new KryptonLabel();
            ((ISupportInitialize)(kryptonPanel1)).BeginInit();
            kryptonPanel1.SuspendLayout();
            ((ISupportInitialize)(kryptonPanel2)).BeginInit();
            kryptonPanel2.SuspendLayout();
            ((ISupportInitialize)(kcmbFillMode)).BeginInit();
            ((ISupportInitialize)(kryptonGroup1)).BeginInit();
            ((ISupportInitialize)(kryptonGroup1.Panel)).BeginInit();
            kryptonGroup1.Panel.SuspendLayout();
            kryptonGroup1.SuspendLayout();
            ((ISupportInitialize)(pbxPreview)).BeginInit();
            ((ISupportInitialize)(kcmbStyle)).BeginInit();
            SuspendLayout();
            // 
            // kryptonPanel1
            // 
            kryptonPanel1.Controls.Add(kbtnOk);
            kryptonPanel1.Controls.Add(kbtnCancel);
            kryptonPanel1.Controls.Add(kryptonBorderEdge1);
            kryptonPanel1.Dock = DockStyle.Bottom;
            kryptonPanel1.Location = new Point(0, 169);
            kryptonPanel1.Name = "kryptonPanel1";
            kryptonPanel1.PanelBackStyle = PaletteBackStyle.PanelAlternate;
            kryptonPanel1.Size = new Size(440, 50);
            kryptonPanel1.TabIndex = 0;
            // 
            // kbtnOk
            // 
            kbtnOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            kbtnOk.AutoSizeMode = AutoSizeMode.GrowOnly;
            kbtnOk.DialogResult = DialogResult.OK;
            kbtnOk.Location = new Point(242, 13);
            kbtnOk.Name = "kbtnOk";
            kbtnOk.Orientation = VisualOrientation.Top;
            kbtnOk.Size = new Size(90, 25);
            kbtnOk.TabIndex = 3;
            kbtnOk.Values.Image = ((Image)(resources.GetObject("kbtnOk.Values.Image")));
            kbtnOk.Values.Text = "&OK";
            kbtnOk.Click += kbtnOk_Click;
            // 
            // kbtnCancel
            // 
            kbtnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            kbtnCancel.AutoSizeMode = AutoSizeMode.GrowOnly;
            kbtnCancel.DialogResult = DialogResult.Cancel;
            kbtnCancel.Location = new Point(338, 13);
            kbtnCancel.Name = "kbtnCancel";
            kbtnCancel.Orientation = VisualOrientation.Top;
            kbtnCancel.Size = new Size(90, 25);
            kbtnCancel.TabIndex = 2;
            kbtnCancel.Values.Image = ((Image)(resources.GetObject("kbtnCancel.Values.Image")));
            kbtnCancel.Values.Text = "Cance&l";
            kbtnCancel.Click += kbtnCancel_Click;
            // 
            // kryptonBorderEdge1
            // 
            kryptonBorderEdge1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            kryptonBorderEdge1.BorderStyle = PaletteBorderStyle.HeaderPrimary;
            kryptonBorderEdge1.Dock = DockStyle.Top;
            kryptonBorderEdge1.Location = new Point(0, 0);
            kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            kryptonBorderEdge1.Orientation = Orientation.Horizontal;
            kryptonBorderEdge1.Size = new Size(440, 1);
            kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel2
            // 
            kryptonPanel2.Controls.Add(kcmbFillMode);
            kryptonPanel2.Controls.Add(klblFill);
            kryptonPanel2.Controls.Add(kryptonGroup1);
            kryptonPanel2.Controls.Add(pbxPreview);
            kryptonPanel2.Controls.Add(klblPreview);
            kryptonPanel2.Controls.Add(kcmbStyle);
            kryptonPanel2.Controls.Add(klblFormat);
            kryptonPanel2.Dock = DockStyle.Fill;
            kryptonPanel2.Location = new Point(0, 0);
            kryptonPanel2.Name = "kryptonPanel2";
            kryptonPanel2.Size = new Size(440, 169);
            kryptonPanel2.TabIndex = 1;
            // 
            // kcmbFillMode
            // 
            kcmbFillMode.AutoCompleteMode = AutoCompleteMode.None;
            kcmbFillMode.AutoCompleteSource = AutoCompleteSource.None;
            kcmbFillMode.DrawMode = DrawMode.OwnerDrawVariable;
            kcmbFillMode.DropDownStyle = ComboBoxStyle.DropDownList;
            kcmbFillMode.DropDownWidth = 198;
            kcmbFillMode.IntegralHeight = false;
            kcmbFillMode.Items.AddRange(new object[] {
            "&Solid",
            "Gra&dient"});
            kcmbFillMode.Location = new Point(93, 131);
            kcmbFillMode.Name = "kcmbFillMode";
            kcmbFillMode.Size = new Size(198, 21);
            kcmbFillMode.StateCommon.ComboBox.Content.TextH = PaletteRelativeAlign.Near;
            kcmbFillMode.TabIndex = 6;
            kcmbFillMode.SelectedIndexChanged += kcmbFillMode_SelectedIndexChanged;
            // 
            // klblFill
            // 
            klblFill.LabelStyle = LabelStyle.NormalControl;
            klblFill.Location = new Point(13, 131);
            klblFill.Name = "klblFill";
            klblFill.Size = new Size(28, 20);
            klblFill.TabIndex = 5;
            klblFill.Values.Text = "Fill:";
            // 
            // kryptonGroup1
            // 
            kryptonGroup1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            kryptonGroup1.Location = new Point(13, 78);
            kryptonGroup1.Name = "kryptonGroup1";
            // 
            // kryptonGroup1.Panel
            // 
            kryptonGroup1.Panel.Controls.Add(kcbMaxColour);
            kryptonGroup1.Panel.Controls.Add(kcbMediumColour);
            kryptonGroup1.Panel.Controls.Add(kcbMinColour);
            kryptonGroup1.Size = new Size(415, 38);
            kryptonGroup1.TabIndex = 4;
            // 
            // kcbMaxColour
            // 
            kcbMaxColour.AutoSizeMode = AutoSizeMode.GrowOnly;
            kcbMaxColour.ButtonOrientation = VisualOrientation.Top;
            kcbMaxColour.DialogResult = DialogResult.None;
            kcbMaxColour.DropDownOrientation = VisualOrientation.Bottom;
            kcbMaxColour.DropDownPosition = VisualOrientation.Right;
            kcbMaxColour.EmptyBorderColor = Color.DarkGray;
            kcbMaxColour.Location = new Point(242, 5);
            kcbMaxColour.Name = "kcbMaxColour";
            kcbMaxColour.SchemeStandard = ColorScheme.OfficeStandard;
            kcbMaxColour.SchemeThemes = ColorScheme.OfficeThemes;
            kcbMaxColour.SelectedColor = Color.Transparent;
            kcbMaxColour.SelectedRect = new Rectangle(0, 0, 40, 20);
            kcbMaxColour.Size = new Size(107, 25);
            kcbMaxColour.Splitter = false;
            kcbMaxColour.TabIndex = 2;
            kcbMaxColour.Values.Image = ((Image)(resources.GetObject("kcbMaxColour.Values.Image")));
            kcbMaxColour.Values.Text = "M&ax Colour";
            kcbMaxColour.VisibleNoColor = false;
            kcbMaxColour.SelectedColorChanged += kcbMaxColour_SelectedColorChanged;
            // 
            // kcbMediumColour
            // 
            kcbMediumColour.AutoSizeMode = AutoSizeMode.GrowOnly;
            kcbMediumColour.ButtonOrientation = VisualOrientation.Top;
            kcbMediumColour.DialogResult = DialogResult.None;
            kcbMediumColour.DropDownOrientation = VisualOrientation.Bottom;
            kcbMediumColour.DropDownPosition = VisualOrientation.Right;
            kcbMediumColour.EmptyBorderColor = Color.DarkGray;
            kcbMediumColour.Location = new Point(113, 5);
            kcbMediumColour.Name = "kcbMediumColour";
            kcbMediumColour.SchemeStandard = ColorScheme.OfficeStandard;
            kcbMediumColour.SchemeThemes = ColorScheme.OfficeThemes;
            kcbMediumColour.SelectedColor = Color.Transparent;
            kcbMediumColour.SelectedRect = new Rectangle(0, 0, 40, 20);
            kcbMediumColour.Size = new Size(123, 25);
            kcbMediumColour.Splitter = false;
            kcbMediumColour.TabIndex = 1;
            kcbMediumColour.Values.Image = ((Image)(resources.GetObject("kcbMediumColour.Values.Image")));
            kcbMediumColour.Values.Text = "M&edium Colour";
            kcbMediumColour.VisibleNoColor = false;
            kcbMediumColour.SelectedColorChanged += kcbMediumColour_SelectedColorChanged;
            // 
            // kcbMinColour
            // 
            kcbMinColour.AutoSizeMode = AutoSizeMode.GrowOnly;
            kcbMinColour.ButtonOrientation = VisualOrientation.Top;
            kcbMinColour.DialogResult = DialogResult.None;
            kcbMinColour.DropDownOrientation = VisualOrientation.Bottom;
            kcbMinColour.DropDownPosition = VisualOrientation.Right;
            kcbMinColour.EmptyBorderColor = Color.DarkGray;
            kcbMinColour.Location = new Point(7, 5);
            kcbMinColour.Name = "kcbMinColour";
            kcbMinColour.SchemeStandard = ColorScheme.OfficeStandard;
            kcbMinColour.SchemeThemes = ColorScheme.OfficeThemes;
            kcbMinColour.SelectedColor = Color.Transparent;
            kcbMinColour.SelectedRect = new Rectangle(0, 0, 40, 20);
            kcbMinColour.Size = new Size(100, 25);
            kcbMinColour.Splitter = false;
            kcbMinColour.TabIndex = 0;
            kcbMinColour.Values.Image = ((Image)(resources.GetObject("kcbMinColour.Values.Image")));
            kcbMinColour.Values.Text = "Mi&n Colour";
            kcbMinColour.VisibleNoColor = false;
            kcbMinColour.SelectedColorChanged += kcbMinColour_SelectedColorChanged;
            // 
            // pbxPreview
            // 
            pbxPreview.BackColor = Color.Transparent;
            pbxPreview.Location = new Point(93, 51);
            pbxPreview.Name = "pbxPreview";
            pbxPreview.Size = new Size(290, 20);
            pbxPreview.TabIndex = 3;
            pbxPreview.TabStop = false;
            pbxPreview.Paint += pbxPreview_Paint;
            // 
            // klblPreview
            // 
            klblPreview.LabelStyle = LabelStyle.BoldControl;
            klblPreview.Location = new Point(13, 51);
            klblPreview.Name = "klblPreview";
            klblPreview.Size = new Size(60, 20);
            klblPreview.TabIndex = 2;
            klblPreview.Values.Text = "Preview:";
            // 
            // kcmbStyle
            // 
            kcmbStyle.AutoCompleteMode = AutoCompleteMode.None;
            kcmbStyle.AutoCompleteSource = AutoCompleteSource.None;
            kcmbStyle.DrawMode = DrawMode.OwnerDrawVariable;
            kcmbStyle.DropDownStyle = ComboBoxStyle.DropDownList;
            kcmbStyle.DropDownWidth = 290;
            kcmbStyle.IntegralHeight = false;
            kcmbStyle.Location = new Point(93, 13);
            kcmbStyle.Name = "kcmbStyle";
            kcmbStyle.Size = new Size(290, 21);
            kcmbStyle.StateCommon.ComboBox.Content.TextH = PaletteRelativeAlign.Near;
            kcmbStyle.TabIndex = 1;
            kcmbStyle.SelectedIndexChanged += kcmbStyle_SelectedIndexChanged;
            // 
            // klblFormat
            // 
            klblFormat.LabelStyle = LabelStyle.BoldControl;
            klblFormat.Location = new Point(13, 13);
            klblFormat.Name = "klblFormat";
            klblFormat.Size = new Size(56, 20);
            klblFormat.TabIndex = 0;
            klblFormat.Values.Text = "Format:";
            // 
            // CustomFormatRule
            // 
            ClientSize = new Size(440, 219);
            Controls.Add(kryptonPanel2);
            Controls.Add(kryptonPanel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CustomFormatRule";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Custom Rule";
            Load += CustomFormatRule_Load;
            ((ISupportInitialize)(kryptonPanel1)).EndInit();
            kryptonPanel1.ResumeLayout(false);
            kryptonPanel1.PerformLayout();
            ((ISupportInitialize)(kryptonPanel2)).EndInit();
            kryptonPanel2.ResumeLayout(false);
            kryptonPanel2.PerformLayout();
            ((ISupportInitialize)(kcmbFillMode)).EndInit();
            ((ISupportInitialize)(kryptonGroup1.Panel)).EndInit();
            kryptonGroup1.Panel.ResumeLayout(false);
            ((ISupportInitialize)(kryptonGroup1)).EndInit();
            kryptonGroup1.ResumeLayout(false);
            ((ISupportInitialize)(pbxPreview)).EndInit();
            ((ISupportInitialize)(kcmbStyle)).EndInit();
            ResumeLayout(false);

        }
        #endregion

        #region Variables
        /// <summary>
        /// The colors
        /// </summary>
        public Color _colMin, _colMedium, _colMax;
        /// <summary>
        /// The Conditional Formatting type
        /// </summary>
        public EnumConditionalFormatType _mode;
        /// <summary>
        /// Gradient boolean
        /// </summary>
        public bool _gradient;
        #endregion

        #region Constructors
        public CustomFormatRule(EnumConditionalFormatType initialFormatType)
        {
            InitializeComponent();

            kcmbFillMode.SelectedIndex = 0;

            kcmbStyle.SelectedIndex = -1;

            _mode = initialFormatType;

            _colMin = Color.FromArgb(84, 179, 122);

            _colMedium = Color.FromArgb(252, 229, 130);

            _colMax = Color.FromArgb(243, 120, 97);
        }
        #endregion

        #region Event Handlers
        private void kbtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void kbtnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void pbxPreview_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            switch (_mode)
            {
                case EnumConditionalFormatType.Bar:
                    if (_gradient)
                    {
                        using (LinearGradientBrush br = new LinearGradientBrush(e.ClipRectangle, _colMin, Color.White,
                            LinearGradientMode.Horizontal))
                        {
                            e.Graphics.FillRectangle(br, e.ClipRectangle);
                        }
                    }
                    else
                    {
                        using (SolidBrush br = new SolidBrush(_colMin))
                        {
                            e.Graphics.FillRectangle(br, e.ClipRectangle);
                        }
                    }

                    using (Pen pen = new Pen(_colMin)) //Color.FromArgb(255, 140, 197, 66)))
                    {
                        Rectangle rect = e.ClipRectangle;
                        rect.Inflate(-1, -1);
                        e.Graphics.DrawRectangle(pen, rect);
                    }

                    break;
                case EnumConditionalFormatType.TwoColoursRange:
                    // Draw the background gradient.
                    using (LinearGradientBrush br = new LinearGradientBrush(e.ClipRectangle, _colMin, _colMax,
                        LinearGradientMode.Horizontal))
                    {
                        e.Graphics.FillRectangle(br, e.ClipRectangle);
                    }

                    break;
                case EnumConditionalFormatType.ThreeColoursRange:
                    // Draw the background gradient.              
                    using (LinearGradientBrush br = new LinearGradientBrush(e.ClipRectangle, _colMin, _colMax,
                        LinearGradientMode.Horizontal))
                    {
                        ColorBlend blend = new ColorBlend();
                        blend.Colors = new[] { _colMin, _colMedium, _colMax };
                        blend.Positions = new[] { 0f, 0.5f, 1.0f };
                        br.InterpolationColors = blend;
                        e.Graphics.FillRectangle(br, e.ClipRectangle);
                    }

                    break;
            }
        }

        private void kcbMinColour_SelectedColorChanged(object sender, ColorEventArgs e)
        {
            _colMin = kcbMinColour.SelectedColor;

            pbxPreview.Invalidate();
        }

        private void kcbMediumColour_SelectedColorChanged(object sender, ColorEventArgs e)
        {
            _colMedium = kcbMediumColour.SelectedColor;

            pbxPreview.Invalidate();
        }

        private void kcbMaxColour_SelectedColorChanged(object sender, ColorEventArgs e)
        {
            _colMax = kcbMaxColour.SelectedColor;

            pbxPreview.Invalidate();
        }

        private void kcmbStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            _mode = (EnumConditionalFormatType)Enum.Parse(typeof(EnumConditionalFormatType), ((KryptonListItem)kcmbStyle.Items[kcmbStyle.SelectedIndex]).Tag.ToString());

            UpdateUI();
        }

        private void kcmbFillMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            _gradient = kcmbFillMode.SelectedIndex == 1;

            UpdateUI();
        }

        private void CustomFormatRule_Load(object sender, EventArgs e)
        {
            kcbMinColour.SelectedColor = _colMin;

            kcbMediumColour.SelectedColor = _colMedium;

            kcbMaxColour.SelectedColor = _colMax;

            int selected = -1;

            string[] names = Enum.GetNames(typeof(EnumConditionalFormatType));

            for (int i = 0; i < names.Length; i++)
            {
                if (_mode.ToString().Equals(names[i]))
                {
                    selected = i;
                }

                // Note: What's going on here...
                kcmbStyle.Items.Add(new KryptonListItem(LanguageManagerOld.Instance.GetString(names[i])) { Tag = names[i] });
            }

            kcmbStyle.SelectedIndex = selected;
        }
        #endregion

        #region Methods

        private void UpdateUI()
        {
            switch (_mode)
            {
                case EnumConditionalFormatType.Bar:
                    klblFill.Visible = true;

                    kcmbFillMode.Visible = true;

                    kcbMinColour.Visible = true;

                    kcbMediumColour.Visible = false;

                    kcbMaxColour.Visible = false;
                    break;
                case EnumConditionalFormatType.TwoColoursRange:
                    klblFill.Visible = false;

                    kcmbFillMode.Visible = false;

                    kcbMinColour.Visible = true;

                    kcbMediumColour.Visible = false;

                    kcbMaxColour.Visible = true;
                    break;
                case EnumConditionalFormatType.ThreeColoursRange:
                    klblFill.Visible = false;

                    kcmbFillMode.Visible = false;

                    kcbMinColour.Visible = true;

                    kcbMediumColour.Visible = true;

                    kcbMaxColour.Visible = true;
                    break;
            }

            pbxPreview.Invalidate();
        }
        #endregion
    }
}