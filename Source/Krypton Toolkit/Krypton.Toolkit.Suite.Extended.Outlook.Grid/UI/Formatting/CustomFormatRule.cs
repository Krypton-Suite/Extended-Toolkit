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
        private KryptonPanel _kryptonPanel1;
        private KryptonBorderEdge _kryptonBorderEdge1;
        private KryptonButton _kbtnOk;
        private KryptonButton _kbtnCancel;
        private KryptonGroup _kryptonGroup1;
        private KryptonColorButton _kcbMinColour;
        private PictureBox _pbxPreview;
        private KryptonLabel _klblPreview;
        private KryptonComboBox _kcmbStyle;
        private KryptonLabel _klblFormat;
        private KryptonComboBox _kcmbFillMode;
        private KryptonLabel _klblFill;
        private KryptonColorButton _kcbMaxColour;
        private KryptonColorButton _kcbMediumColour;
        private KryptonPanel _kryptonPanel2;

        private void InitializeComponent()
        {
            ComponentResourceManager resources = new(typeof(CustomFormatRule));
            _kryptonPanel1 = new();
            _kbtnOk = new();
            _kbtnCancel = new();
            _kryptonBorderEdge1 = new();
            _kryptonPanel2 = new();
            _kcmbFillMode = new();
            _klblFill = new();
            _kryptonGroup1 = new();
            _kcbMaxColour = new();
            _kcbMediumColour = new();
            _kcbMinColour = new();
            _pbxPreview = new();
            _klblPreview = new();
            _kcmbStyle = new();
            _klblFormat = new();
            ((ISupportInitialize)(_kryptonPanel1)).BeginInit();
            _kryptonPanel1.SuspendLayout();
            ((ISupportInitialize)(_kryptonPanel2)).BeginInit();
            _kryptonPanel2.SuspendLayout();
            ((ISupportInitialize)(_kcmbFillMode)).BeginInit();
            ((ISupportInitialize)(_kryptonGroup1)).BeginInit();
            ((ISupportInitialize)(_kryptonGroup1.Panel)).BeginInit();
            _kryptonGroup1.Panel.SuspendLayout();
            _kryptonGroup1.SuspendLayout();
            ((ISupportInitialize)(_pbxPreview)).BeginInit();
            ((ISupportInitialize)(_kcmbStyle)).BeginInit();
            SuspendLayout();
            // 
            // kryptonPanel1
            // 
            _kryptonPanel1.Controls.Add(_kbtnOk);
            _kryptonPanel1.Controls.Add(_kbtnCancel);
            _kryptonPanel1.Controls.Add(_kryptonBorderEdge1);
            _kryptonPanel1.Dock = DockStyle.Bottom;
            _kryptonPanel1.Location = new(0, 169);
            _kryptonPanel1.Name = "_kryptonPanel1";
            _kryptonPanel1.PanelBackStyle = PaletteBackStyle.PanelAlternate;
            _kryptonPanel1.Size = new(540, 50);
            _kryptonPanel1.TabIndex = 0;
            // 
            // kbtnOk
            // 
            _kbtnOk.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            _kbtnOk.CornerRoundingRadius = -1F;
            _kbtnOk.DialogResult = DialogResult.OK;
            _kbtnOk.Location = new(342, 13);
            _kbtnOk.Name = "_kbtnOk";
            _kbtnOk.Size = new(90, 25);
            _kbtnOk.TabIndex = 3;
            _kbtnOk.Values.Image = ((Image)(resources.GetObject("kbtnOk.Values.Image")));
            _kbtnOk.Values.Text = "&OK";
            _kbtnOk.Click += kbtnOk_Click;
            // 
            // kbtnCancel
            // 
            _kbtnCancel.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            _kbtnCancel.CornerRoundingRadius = -1F;
            _kbtnCancel.DialogResult = DialogResult.Cancel;
            _kbtnCancel.Location = new(438, 13);
            _kbtnCancel.Name = "_kbtnCancel";
            _kbtnCancel.Size = new(90, 25);
            _kbtnCancel.TabIndex = 2;
            _kbtnCancel.Values.Image = ((Image)(resources.GetObject("kbtnCancel.Values.Image")));
            _kbtnCancel.Values.Text = "Cance&l";
            _kbtnCancel.Click += kbtnCancel_Click;
            // 
            // kryptonBorderEdge1
            // 
            _kryptonBorderEdge1.BorderStyle = PaletteBorderStyle.HeaderPrimary;
            _kryptonBorderEdge1.Dock = DockStyle.Top;
            _kryptonBorderEdge1.Location = new(0, 0);
            _kryptonBorderEdge1.Name = "_kryptonBorderEdge1";
            _kryptonBorderEdge1.Size = new(540, 1);
            _kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel2
            // 
            _kryptonPanel2.Controls.Add(_kcmbFillMode);
            _kryptonPanel2.Controls.Add(_klblFill);
            _kryptonPanel2.Controls.Add(_kryptonGroup1);
            _kryptonPanel2.Controls.Add(_pbxPreview);
            _kryptonPanel2.Controls.Add(_klblPreview);
            _kryptonPanel2.Controls.Add(_kcmbStyle);
            _kryptonPanel2.Controls.Add(_klblFormat);
            _kryptonPanel2.Dock = DockStyle.Fill;
            _kryptonPanel2.Location = new(0, 0);
            _kryptonPanel2.Name = "_kryptonPanel2";
            _kryptonPanel2.Size = new(540, 169);
            _kryptonPanel2.TabIndex = 1;
            // 
            // kcmbFillMode
            // 
            _kcmbFillMode.CornerRoundingRadius = -1F;
            _kcmbFillMode.DropDownStyle = ComboBoxStyle.DropDownList;
            _kcmbFillMode.DropDownWidth = 198;
            _kcmbFillMode.IntegralHeight = false;
            _kcmbFillMode.Items.AddRange(new object[] {
            "&Solid",
            "Gra&dient"});
            _kcmbFillMode.Location = new(93, 131);
            _kcmbFillMode.Name = "_kcmbFillMode";
            _kcmbFillMode.Size = new(198, 21);
            _kcmbFillMode.StateCommon.ComboBox.Content.TextH = PaletteRelativeAlign.Near;
            _kcmbFillMode.TabIndex = 6;
            _kcmbFillMode.SelectedIndexChanged += kcmbFillMode_SelectedIndexChanged;
            // 
            // klblFill
            // 
            _klblFill.LabelStyle = LabelStyle.NormalControl;
            _klblFill.Location = new(13, 131);
            _klblFill.Name = "_klblFill";
            _klblFill.Size = new(28, 20);
            _klblFill.TabIndex = 5;
            _klblFill.Values.Text = "Fill:";
            // 
            // kryptonGroup1
            // 
            _kryptonGroup1.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
            | AnchorStyles.Right)));
            _kryptonGroup1.Location = new(13, 78);
            _kryptonGroup1.Name = "_kryptonGroup1";
            // 
            // kryptonGroup1.Panel
            // 
            _kryptonGroup1.Panel.Controls.Add(_kcbMaxColour);
            _kryptonGroup1.Panel.Controls.Add(_kcbMediumColour);
            _kryptonGroup1.Panel.Controls.Add(_kcbMinColour);
            _kryptonGroup1.Size = new(515, 38);
            _kryptonGroup1.TabIndex = 4;
            // 
            // kcbMaxColour
            // 
            _kcbMaxColour.CustomColorPreviewShape = KryptonColorButtonCustomColorPreviewShape.Circle;
            _kcbMaxColour.Location = new(319, 5);
            _kcbMaxColour.Name = "_kcbMaxColour";
            _kcbMaxColour.SelectedColor = Color.Transparent;
            _kcbMaxColour.SelectedRect = new(0, 0, 40, 20);
            _kcbMaxColour.Size = new(150, 25);
            _kcbMaxColour.Splitter = false;
            _kcbMaxColour.TabIndex = 2;
            _kcbMaxColour.Values.Image = ((Image)(resources.GetObject("kcbMaxColour.Values.Image")));
            _kcbMaxColour.Values.RoundedCorners = 8;
            _kcbMaxColour.Values.Text = "M&ax Colour";
            _kcbMaxColour.VisibleNoColor = false;
            _kcbMaxColour.SelectedColorChanged += kcbMaxColour_SelectedColorChanged;
            // 
            // kcbMediumColour
            // 
            _kcbMediumColour.CustomColorPreviewShape = KryptonColorButtonCustomColorPreviewShape.Circle;
            _kcbMediumColour.Location = new(163, 5);
            _kcbMediumColour.Name = "_kcbMediumColour";
            _kcbMediumColour.SelectedColor = Color.Transparent;
            _kcbMediumColour.SelectedRect = new(0, 0, 40, 20);
            _kcbMediumColour.Size = new(150, 25);
            _kcbMediumColour.Splitter = false;
            _kcbMediumColour.TabIndex = 1;
            _kcbMediumColour.Values.Image = ((Image)(resources.GetObject("kcbMediumColour.Values.Image")));
            _kcbMediumColour.Values.RoundedCorners = 8;
            _kcbMediumColour.Values.Text = "M&edium Colour";
            _kcbMediumColour.VisibleNoColor = false;
            _kcbMediumColour.SelectedColorChanged += kcbMediumColour_SelectedColorChanged;
            // 
            // kcbMinColour
            // 
            _kcbMinColour.CustomColorPreviewShape = KryptonColorButtonCustomColorPreviewShape.Circle;
            _kcbMinColour.Location = new(7, 5);
            _kcbMinColour.Name = "_kcbMinColour";
            _kcbMinColour.SelectedColor = Color.Transparent;
            _kcbMinColour.SelectedRect = new(0, 0, 40, 20);
            _kcbMinColour.Size = new(150, 25);
            _kcbMinColour.Splitter = false;
            _kcbMinColour.TabIndex = 0;
            _kcbMinColour.Values.Image = ((Image)(resources.GetObject("kcbMinColour.Values.Image")));
            _kcbMinColour.Values.RoundedCorners = 8;
            _kcbMinColour.Values.Text = "Mi&n Colour";
            _kcbMinColour.VisibleNoColor = false;
            _kcbMinColour.SelectedColorChanged += kcbMinColour_SelectedColorChanged;
            // 
            // pbxPreview
            // 
            _pbxPreview.BackColor = Color.Transparent;
            _pbxPreview.Location = new(93, 51);
            _pbxPreview.Name = "_pbxPreview";
            _pbxPreview.Size = new(290, 20);
            _pbxPreview.TabIndex = 3;
            _pbxPreview.TabStop = false;
            _pbxPreview.Paint += pbxPreview_Paint;
            // 
            // klblPreview
            // 
            _klblPreview.LabelStyle = LabelStyle.BoldControl;
            _klblPreview.Location = new(13, 51);
            _klblPreview.Name = "_klblPreview";
            _klblPreview.Size = new(60, 20);
            _klblPreview.TabIndex = 2;
            _klblPreview.Values.Text = "Preview:";
            // 
            // kcmbStyle
            // 
            _kcmbStyle.CornerRoundingRadius = -1F;
            _kcmbStyle.DropDownStyle = ComboBoxStyle.DropDownList;
            _kcmbStyle.DropDownWidth = 290;
            _kcmbStyle.IntegralHeight = false;
            _kcmbStyle.Location = new(93, 13);
            _kcmbStyle.Name = "_kcmbStyle";
            _kcmbStyle.Size = new(290, 21);
            _kcmbStyle.StateCommon.ComboBox.Content.TextH = PaletteRelativeAlign.Near;
            _kcmbStyle.TabIndex = 1;
            _kcmbStyle.SelectedIndexChanged += kcmbStyle_SelectedIndexChanged;
            // 
            // klblFormat
            // 
            _klblFormat.LabelStyle = LabelStyle.BoldControl;
            _klblFormat.Location = new(13, 13);
            _klblFormat.Name = "_klblFormat";
            _klblFormat.Size = new(56, 20);
            _klblFormat.TabIndex = 0;
            _klblFormat.Values.Text = "Format:";
            // 
            // CustomFormatRule
            // 
            ClientSize = new(540, 219);
            Controls.Add(_kryptonPanel2);
            Controls.Add(_kryptonPanel1);
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
            ((ISupportInitialize)(_kryptonPanel1)).EndInit();
            _kryptonPanel1.ResumeLayout(false);
            _kryptonPanel1.PerformLayout();
            ((ISupportInitialize)(_kryptonPanel2)).EndInit();
            _kryptonPanel2.ResumeLayout(false);
            _kryptonPanel2.PerformLayout();
            ((ISupportInitialize)(_kcmbFillMode)).EndInit();
            ((ISupportInitialize)(_kryptonGroup1.Panel)).EndInit();
            _kryptonGroup1.Panel.ResumeLayout(false);
            ((ISupportInitialize)(_kryptonGroup1)).EndInit();
            _kryptonGroup1.ResumeLayout(false);
            ((ISupportInitialize)(_pbxPreview)).EndInit();
            ((ISupportInitialize)(_kcmbStyle)).EndInit();
            ResumeLayout(false);

        }
        #endregion

        #region Variables
        /// <summary>
        /// The colors
        /// </summary>
        public Color ColMin, ColMedium, ColMax;
        /// <summary>
        /// The Conditional Formatting type
        /// </summary>
        public EnumConditionalFormatType Mode;
        /// <summary>
        /// Gradient boolean
        /// </summary>
        public bool Gradient;
        #endregion

        #region Public

        public static OutlookGridLanguageStrings Strings => KryptonOutlookGrid.Strings;

        #endregion

        #region Constructors
        public CustomFormatRule(EnumConditionalFormatType initialFormatType)
        {
            InitializeComponent();

            _kcmbFillMode.SelectedIndex = 0;

            _kcmbStyle.SelectedIndex = -1;

            Mode = initialFormatType;

            ColMin = Color.FromArgb(84, 179, 122);

            ColMedium = Color.FromArgb(252, 229, 130);

            ColMax = Color.FromArgb(243, 120, 97);

            _kcbMaxColour.Text = Strings.MaximumColour;

            _kcbMinColour.Text = Strings.MinimumColour;

            _kcbMediumColour.Text = Strings.MediumColour;
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
            switch (Mode)
            {
                case EnumConditionalFormatType.Bar:
                    if (Gradient)
                    {
                        using (LinearGradientBrush br = new(e.ClipRectangle, ColMin, Color.White,
                            LinearGradientMode.Horizontal))
                        {
                            e.Graphics.FillRectangle(br, e.ClipRectangle);
                        }
                    }
                    else
                    {
                        using (SolidBrush br = new(ColMin))
                        {
                            e.Graphics.FillRectangle(br, e.ClipRectangle);
                        }
                    }

                    using (Pen pen = new(ColMin)) //Color.FromArgb(255, 140, 197, 66)))
                    {
                        Rectangle rect = e.ClipRectangle;
                        rect.Inflate(-1, -1);
                        e.Graphics.DrawRectangle(pen, rect);
                    }

                    break;
                case EnumConditionalFormatType.TwoColoursRange:
                    // Draw the background gradient.
                    using (LinearGradientBrush br = new(e.ClipRectangle, ColMin, ColMax,
                        LinearGradientMode.Horizontal))
                    {
                        e.Graphics.FillRectangle(br, e.ClipRectangle);
                    }

                    break;
                case EnumConditionalFormatType.ThreeColoursRange:
                    // Draw the background gradient.              
                    using (LinearGradientBrush br = new(e.ClipRectangle, ColMin, ColMax,
                        LinearGradientMode.Horizontal))
                    {
                        ColorBlend blend = new();
                        blend.Colors = new Color[] { ColMin, ColMedium, ColMax };
                        blend.Positions = new float[] { 0f, 0.5f, 1.0f };
                        br.InterpolationColors = blend;
                        e.Graphics.FillRectangle(br, e.ClipRectangle);
                    }

                    break;
            }
        }

        private void kcbMinColour_SelectedColorChanged(object sender, ColorEventArgs e)
        {
            ColMin = _kcbMinColour.SelectedColor;

            _pbxPreview.Invalidate();
        }

        private void kcbMediumColour_SelectedColorChanged(object sender, ColorEventArgs e)
        {
            ColMedium = _kcbMediumColour.SelectedColor;

            _pbxPreview.Invalidate();
        }

        private void kcbMaxColour_SelectedColorChanged(object sender, ColorEventArgs e)
        {
            ColMax = _kcbMaxColour.SelectedColor;

            _pbxPreview.Invalidate();
        }

        private void kcmbStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mode = (EnumConditionalFormatType)Enum.Parse(typeof(EnumConditionalFormatType), ((KryptonListItem)_kcmbStyle.Items[_kcmbStyle.SelectedIndex]).Tag.ToString());

            UpdateUi();
        }

        private void kcmbFillMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Gradient = _kcmbFillMode.SelectedIndex == 1;

            UpdateUi();
        }

        private void CustomFormatRule_Load(object sender, EventArgs e)
        {
            _kcbMinColour.SelectedColor = ColMin;

            _kcbMediumColour.SelectedColor = ColMedium;

            _kcbMaxColour.SelectedColor = ColMax;

            int selected = -1;

            string[] names = Enum.GetNames(typeof(EnumConditionalFormatType));

            for (int i = 0; i < names.Length; i++)
            {
                if (Mode.ToString().Equals(names[i]))
                {
                    selected = i;
                }

                _kcmbStyle.Items.Add(new KryptonListItem(LanguageManager.Instance.GetString(names[i])) { Tag = names[i] });
            }

            _kcmbStyle.SelectedIndex = selected;
        }
        #endregion

        #region Methods

        private void UpdateUi()
        {
            switch (Mode)
            {
                case EnumConditionalFormatType.Bar:
                    _klblFill.Visible = true;

                    _kcmbFillMode.Visible = true;

                    _kcbMinColour.Visible = true;

                    _kcbMediumColour.Visible = false;

                    _kcbMaxColour.Visible = false;
                    break;
                case EnumConditionalFormatType.TwoColoursRange:
                    _klblFill.Visible = false;

                    _kcmbFillMode.Visible = false;

                    _kcbMinColour.Visible = true;

                    _kcbMediumColour.Visible = false;

                    _kcbMaxColour.Visible = true;
                    break;
                case EnumConditionalFormatType.ThreeColoursRange:
                    _klblFill.Visible = false;

                    _kcmbFillMode.Visible = false;

                    _kcbMinColour.Visible = true;

                    _kcbMediumColour.Visible = true;

                    _kcbMaxColour.Visible = true;
                    break;
            }

            _pbxPreview.Invalidate();
        }
        #endregion
    }
}