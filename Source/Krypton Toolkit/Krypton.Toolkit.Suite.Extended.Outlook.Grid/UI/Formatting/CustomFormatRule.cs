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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomFormatRule));
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnOk = new Krypton.Toolkit.KryptonButton();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kcmbFillMode = new Krypton.Toolkit.KryptonComboBox();
            this.klblFill = new Krypton.Toolkit.KryptonLabel();
            this.kryptonGroup1 = new Krypton.Toolkit.KryptonGroup();
            this.kcbMaxColour = new Krypton.Toolkit.KryptonColorButton();
            this.kcbMediumColour = new Krypton.Toolkit.KryptonColorButton();
            this.kcbMinColour = new Krypton.Toolkit.KryptonColorButton();
            this.pbxPreview = new System.Windows.Forms.PictureBox();
            this.klblPreview = new Krypton.Toolkit.KryptonLabel();
            this.kcmbStyle = new Krypton.Toolkit.KryptonComboBox();
            this.klblFormat = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbFillMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1.Panel)).BeginInit();
            this.kryptonGroup1.Panel.SuspendLayout();
            this.kryptonGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbStyle)).BeginInit();
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
            this.kbtnOk.Values.Image = ((System.Drawing.Image)(resources.GetObject("kbtnOk.Values.Image")));
            this.kbtnOk.Values.Text = "&OK";
            this.kbtnOk.Click += new System.EventHandler(this.kbtnOk_Click);
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
            this.kbtnCancel.Values.Image = ((System.Drawing.Image)(resources.GetObject("kbtnCancel.Values.Image")));
            this.kbtnCancel.Values.Text = "Cance&l";
            this.kbtnCancel.Click += new System.EventHandler(this.kbtnCancel_Click);
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
            this.kryptonPanel2.Controls.Add(this.klblFill);
            this.kryptonPanel2.Controls.Add(this.kryptonGroup1);
            this.kryptonPanel2.Controls.Add(this.pbxPreview);
            this.kryptonPanel2.Controls.Add(this.klblPreview);
            this.kryptonPanel2.Controls.Add(this.kcmbStyle);
            this.kryptonPanel2.Controls.Add(this.klblFormat);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(440, 169);
            this.kryptonPanel2.TabIndex = 1;
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
            this.kcmbFillMode.SelectedIndexChanged += new System.EventHandler(this.kcmbFillMode_SelectedIndexChanged);
            // 
            // klblFill
            // 
            this.klblFill.LabelStyle = Krypton.Toolkit.LabelStyle.NormalControl;
            this.klblFill.Location = new System.Drawing.Point(13, 131);
            this.klblFill.Name = "klblFill";
            this.klblFill.Size = new System.Drawing.Size(28, 20);
            this.klblFill.TabIndex = 5;
            this.klblFill.Values.Text = "Fill:";
            // 
            // kryptonGroup1
            // 
            this.kryptonGroup1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.kryptonGroup1.Location = new System.Drawing.Point(13, 78);
            this.kryptonGroup1.Name = "kryptonGroup1";
            // 
            // kryptonGroup1.Panel
            // 
            this.kryptonGroup1.Panel.Controls.Add(this.kcbMaxColour);
            this.kryptonGroup1.Panel.Controls.Add(this.kcbMediumColour);
            this.kryptonGroup1.Panel.Controls.Add(this.kcbMinColour);
            this.kryptonGroup1.Size = new System.Drawing.Size(415, 38);
            this.kryptonGroup1.TabIndex = 4;
            // 
            // kcbMaxColour
            // 
            this.kcbMaxColour.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.kcbMaxColour.ButtonOrientation = Krypton.Toolkit.VisualOrientation.Top;
            this.kcbMaxColour.DialogResult = System.Windows.Forms.DialogResult.None;
            this.kcbMaxColour.DropDownOrientation = Krypton.Toolkit.VisualOrientation.Bottom;
            this.kcbMaxColour.DropDownPosition = Krypton.Toolkit.VisualOrientation.Right;
            this.kcbMaxColour.EmptyBorderColor = System.Drawing.Color.DarkGray;
            this.kcbMaxColour.Location = new System.Drawing.Point(242, 5);
            this.kcbMaxColour.Name = "kcbMaxColour";
            this.kcbMaxColour.SchemeStandard = Krypton.Toolkit.ColorScheme.OfficeStandard;
            this.kcbMaxColour.SchemeThemes = Krypton.Toolkit.ColorScheme.OfficeThemes;
            this.kcbMaxColour.SelectedColor = System.Drawing.Color.Transparent;
            this.kcbMaxColour.SelectedRect = new System.Drawing.Rectangle(0, 0, 40, 20);
            this.kcbMaxColour.Size = new System.Drawing.Size(107, 25);
            this.kcbMaxColour.Splitter = false;
            this.kcbMaxColour.TabIndex = 2;
            this.kcbMaxColour.Values.Image = ((System.Drawing.Image)(resources.GetObject("kcbMaxColour.Values.Image")));
            this.kcbMaxColour.Values.Text = "M&ax Colour";
            this.kcbMaxColour.VisibleNoColor = false;
            this.kcbMaxColour.SelectedColorChanged += new System.EventHandler<Krypton.Toolkit.ColorEventArgs>(this.kcbMaxColour_SelectedColorChanged);
            // 
            // kcbMediumColour
            // 
            this.kcbMediumColour.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.kcbMediumColour.ButtonOrientation = Krypton.Toolkit.VisualOrientation.Top;
            this.kcbMediumColour.DialogResult = System.Windows.Forms.DialogResult.None;
            this.kcbMediumColour.DropDownOrientation = Krypton.Toolkit.VisualOrientation.Bottom;
            this.kcbMediumColour.DropDownPosition = Krypton.Toolkit.VisualOrientation.Right;
            this.kcbMediumColour.EmptyBorderColor = System.Drawing.Color.DarkGray;
            this.kcbMediumColour.Location = new System.Drawing.Point(113, 5);
            this.kcbMediumColour.Name = "kcbMediumColour";
            this.kcbMediumColour.SchemeStandard = Krypton.Toolkit.ColorScheme.OfficeStandard;
            this.kcbMediumColour.SchemeThemes = Krypton.Toolkit.ColorScheme.OfficeThemes;
            this.kcbMediumColour.SelectedColor = System.Drawing.Color.Transparent;
            this.kcbMediumColour.SelectedRect = new System.Drawing.Rectangle(0, 0, 40, 20);
            this.kcbMediumColour.Size = new System.Drawing.Size(123, 25);
            this.kcbMediumColour.Splitter = false;
            this.kcbMediumColour.TabIndex = 1;
            this.kcbMediumColour.Values.Image = ((System.Drawing.Image)(resources.GetObject("kcbMediumColour.Values.Image")));
            this.kcbMediumColour.Values.Text = "M&edium Colour";
            this.kcbMediumColour.VisibleNoColor = false;
            this.kcbMediumColour.SelectedColorChanged += new System.EventHandler<Krypton.Toolkit.ColorEventArgs>(this.kcbMediumColour_SelectedColorChanged);
            // 
            // kcbMinColour
            // 
            this.kcbMinColour.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.kcbMinColour.ButtonOrientation = Krypton.Toolkit.VisualOrientation.Top;
            this.kcbMinColour.DialogResult = System.Windows.Forms.DialogResult.None;
            this.kcbMinColour.DropDownOrientation = Krypton.Toolkit.VisualOrientation.Bottom;
            this.kcbMinColour.DropDownPosition = Krypton.Toolkit.VisualOrientation.Right;
            this.kcbMinColour.EmptyBorderColor = System.Drawing.Color.DarkGray;
            this.kcbMinColour.Location = new System.Drawing.Point(7, 5);
            this.kcbMinColour.Name = "kcbMinColour";
            this.kcbMinColour.SchemeStandard = Krypton.Toolkit.ColorScheme.OfficeStandard;
            this.kcbMinColour.SchemeThemes = Krypton.Toolkit.ColorScheme.OfficeThemes;
            this.kcbMinColour.SelectedColor = System.Drawing.Color.Transparent;
            this.kcbMinColour.SelectedRect = new System.Drawing.Rectangle(0, 0, 40, 20);
            this.kcbMinColour.Size = new System.Drawing.Size(100, 25);
            this.kcbMinColour.Splitter = false;
            this.kcbMinColour.TabIndex = 0;
            this.kcbMinColour.Values.Image = ((System.Drawing.Image)(resources.GetObject("kcbMinColour.Values.Image")));
            this.kcbMinColour.Values.Text = "Mi&n Colour";
            this.kcbMinColour.VisibleNoColor = false;
            this.kcbMinColour.SelectedColorChanged += new System.EventHandler<Krypton.Toolkit.ColorEventArgs>(this.kcbMinColour_SelectedColorChanged);
            // 
            // pbxPreview
            // 
            this.pbxPreview.BackColor = System.Drawing.Color.Transparent;
            this.pbxPreview.Location = new System.Drawing.Point(93, 51);
            this.pbxPreview.Name = "pbxPreview";
            this.pbxPreview.Size = new System.Drawing.Size(290, 20);
            this.pbxPreview.TabIndex = 3;
            this.pbxPreview.TabStop = false;
            this.pbxPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.pbxPreview_Paint);
            // 
            // klblPreview
            // 
            this.klblPreview.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.klblPreview.Location = new System.Drawing.Point(13, 51);
            this.klblPreview.Name = "klblPreview";
            this.klblPreview.Size = new System.Drawing.Size(60, 20);
            this.klblPreview.TabIndex = 2;
            this.klblPreview.Values.Text = "Preview:";
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
            this.kcmbStyle.SelectedIndexChanged += new System.EventHandler(this.kcmbStyle_SelectedIndexChanged);
            // 
            // klblFormat
            // 
            this.klblFormat.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.klblFormat.Location = new System.Drawing.Point(13, 13);
            this.klblFormat.Name = "klblFormat";
            this.klblFormat.Size = new System.Drawing.Size(56, 20);
            this.klblFormat.TabIndex = 0;
            this.klblFormat.Values.Text = "Format:";
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
            this.Load += new System.EventHandler(this.CustomFormatRule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbFillMode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1.Panel)).EndInit();
            this.kryptonGroup1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroup1)).EndInit();
            this.kryptonGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbStyle)).EndInit();
            this.ResumeLayout(false);

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
                        blend.Colors = new Color[] { _colMin, _colMedium, _colMax };
                        blend.Positions = new float[] { 0f, 0.5f, 1.0f };
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

                kcmbStyle.Items.Add(new KryptonListItem(LanguageManager.Instance.GetString(names[i])) { Tag = names[i] });
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