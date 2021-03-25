#region MS-PL License
/*
* Copyright (C) 2013 - 2018 JDH Software - <support@jdhsoftware.com>
*
* This program is provided to you under the terms of the Microsoft Public
* License (Ms-PL) as published at https://kryptonoutlookgrid.codeplex.com/license
*
* Visit http://www.jdhsoftware.com and follow @jdhsoftware on Twitter
*/
#endregion

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
{
    public class CustomFormatRule : KryptonForm
    {
        #region Designer Code
        private KryptonButton kbtnOk;
        private KryptonButton kbtnCancel;
        private System.Windows.Forms.Panel panel1;
        private KryptonPanel kryptonPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private KryptonColorButton kcbMinimumColour;
        private KryptonColorButton kcbMediumColour;
        private KryptonColorButton kcbMaximumColour;
        private System.Windows.Forms.PictureBox pbxPreview;
        private KryptonComboBox kcmbStyle;
        private KryptonLabel kryptonLabel2;
        private KryptonLabel kryptonLabel1;
        private KryptonComboBox kcmbFillMode;
        private KryptonLabel klblFill;
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnOk = new Krypton.Toolkit.KryptonButton();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kcmbFillMode = new Krypton.Toolkit.KryptonComboBox();
            this.klblFill = new Krypton.Toolkit.KryptonLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.kcbMinimumColour = new Krypton.Toolkit.KryptonColorButton();
            this.kcbMediumColour = new Krypton.Toolkit.KryptonColorButton();
            this.kcbMaximumColour = new Krypton.Toolkit.KryptonColorButton();
            this.pbxPreview = new System.Windows.Forms.PictureBox();
            this.kcmbStyle = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbFillMode)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbStyle)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnOk);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 185);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(575, 48);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnOk
            // 
            this.kbtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnOk.Location = new System.Drawing.Point(377, 11);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new System.Drawing.Size(90, 25);
            this.kbtnOk.TabIndex = 1;
            this.kbtnOk.Values.Text = "&Ok";
            this.kbtnOk.Click += new System.EventHandler(this.kbtnOk_Click);
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(473, 11);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 2;
            this.kbtnCancel.Values.Text = "C&ancel";
            this.kbtnCancel.Click += new System.EventHandler(this.kbtnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 183);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(575, 2);
            this.panel1.TabIndex = 1;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kcmbFillMode);
            this.kryptonPanel2.Controls.Add(this.klblFill);
            this.kryptonPanel2.Controls.Add(this.flowLayoutPanel1);
            this.kryptonPanel2.Controls.Add(this.pbxPreview);
            this.kryptonPanel2.Controls.Add(this.kcmbStyle);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(575, 183);
            this.kryptonPanel2.TabIndex = 2;
            // 
            // kcmbFillMode
            // 
            this.kcmbFillMode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.kcmbFillMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbFillMode.DropDownWidth = 213;
            this.kcmbFillMode.IntegralHeight = false;
            this.kcmbFillMode.Items.AddRange(new object[] {
            "Solid",
            "Gradient"});
            this.kcmbFillMode.Location = new System.Drawing.Point(87, 150);
            this.kcmbFillMode.Name = "kcmbFillMode";
            this.kcmbFillMode.Size = new System.Drawing.Size(213, 21);
            this.kcmbFillMode.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbFillMode.TabIndex = 8;
            this.kcmbFillMode.SelectedIndexChanged += new System.EventHandler(this.kcmbFillMode_SelectedIndexChanged);
            // 
            // klblFill
            // 
            this.klblFill.Location = new System.Drawing.Point(13, 150);
            this.klblFill.Name = "klblFill";
            this.klblFill.Size = new System.Drawing.Size(64, 20);
            this.klblFill.TabIndex = 7;
            this.klblFill.Values.Text = "Fill Mode:";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.kcbMinimumColour);
            this.flowLayoutPanel1.Controls.Add(this.kcbMediumColour);
            this.flowLayoutPanel1.Controls.Add(this.kcbMaximumColour);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(13, 98);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(550, 31);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // kcbMinimumColour
            // 
            this.kcbMinimumColour.Location = new System.Drawing.Point(3, 3);
            this.kcbMinimumColour.Name = "kcbMinimumColour";
            this.kcbMinimumColour.SelectedColor = System.Drawing.Color.White;
            this.kcbMinimumColour.Size = new System.Drawing.Size(156, 25);
            this.kcbMinimumColour.Splitter = false;
            this.kcbMinimumColour.TabIndex = 0;
            this.kcbMinimumColour.Values.Text = "Minim&um Colour";
            this.kcbMinimumColour.VisibleNoColor = false;
            this.kcbMinimumColour.SelectedColorChanged += new System.EventHandler<Krypton.Toolkit.ColorEventArgs>(this.kcbMinimumColour_SelectedColorChanged);
            // 
            // kcbMediumColour
            // 
            this.kcbMediumColour.Location = new System.Drawing.Point(165, 3);
            this.kcbMediumColour.Name = "kcbMediumColour";
            this.kcbMediumColour.SelectedColor = System.Drawing.Color.White;
            this.kcbMediumColour.Size = new System.Drawing.Size(156, 25);
            this.kcbMediumColour.Splitter = false;
            this.kcbMediumColour.TabIndex = 1;
            this.kcbMediumColour.Values.Text = "M&edium Colour";
            this.kcbMediumColour.VisibleNoColor = false;
            this.kcbMediumColour.SelectedColorChanged += new System.EventHandler<Krypton.Toolkit.ColorEventArgs>(this.kcbMediumColour_SelectedColorChanged);
            // 
            // kcbMaximumColour
            // 
            this.kcbMaximumColour.Location = new System.Drawing.Point(327, 3);
            this.kcbMaximumColour.Name = "kcbMaximumColour";
            this.kcbMaximumColour.SelectedColor = System.Drawing.Color.White;
            this.kcbMaximumColour.Size = new System.Drawing.Size(156, 25);
            this.kcbMaximumColour.Splitter = false;
            this.kcbMaximumColour.TabIndex = 2;
            this.kcbMaximumColour.Values.Text = "M&aximum Colour";
            this.kcbMaximumColour.VisibleNoColor = false;
            this.kcbMaximumColour.SelectedColorChanged += new System.EventHandler<Krypton.Toolkit.ColorEventArgs>(this.kcbMaximumColour_SelectedColorChanged);
            // 
            // pbxPreview
            // 
            this.pbxPreview.BackColor = System.Drawing.Color.Transparent;
            this.pbxPreview.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pbxPreview.Location = new System.Drawing.Point(87, 51);
            this.pbxPreview.Name = "pbxPreview";
            this.pbxPreview.Size = new System.Drawing.Size(476, 22);
            this.pbxPreview.TabIndex = 6;
            this.pbxPreview.TabStop = false;
            this.pbxPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.pbxPreview_Paint);
            // 
            // kcmbStyle
            // 
            this.kcmbStyle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.kcmbStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbStyle.DropDownWidth = 476;
            this.kcmbStyle.IntegralHeight = false;
            this.kcmbStyle.Location = new System.Drawing.Point(87, 13);
            this.kcmbStyle.Name = "kcmbStyle";
            this.kcmbStyle.Size = new System.Drawing.Size(476, 21);
            this.kcmbStyle.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbStyle.TabIndex = 2;
            this.kcmbStyle.SelectedIndexChanged += new System.EventHandler(this.kcmbStyle_SelectedIndexChanged);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.kryptonLabel2.Location = new System.Drawing.Point(13, 51);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(60, 20);
            this.kryptonLabel2.TabIndex = 1;
            this.kryptonLabel2.Values.Text = "Preview:";
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
            // CustomFormatRule
            // 
            this.ClientSize = new System.Drawing.Size(575, 233);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
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
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbFillMode)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbStyle)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        /// <summary>
        /// The colors
        /// </summary>
        public Color colMin, colMedium, colMax;
        /// <summary>
        /// The Conditional Formatting type
        /// </summary>
        public EnumConditionalFormatType mode;

        /// <summary>
        /// Gradient boolean
        /// </summary>
        public bool gradient;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomFormatRule"/> class.
        /// </summary>
        /// <param name="initialmode">The  Conditional Formatting type.</param>
        public CustomFormatRule(EnumConditionalFormatType initialmode)
        {
            InitializeComponent();
            kcmbFillMode.SelectedIndex = 0;
            kcmbStyle.SelectedIndex = -1;
            mode = initialmode;
            colMin = Color.FromArgb(84, 179, 112);
            colMedium = Color.FromArgb(252, 229, 130);
            colMax = Color.FromArgb(243, 120, 97);
        }
        #endregion

        private void kbtnCancel_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void kbtnOk_Click(object sender, EventArgs e) => DialogResult = DialogResult.OK;

        private void kcbMinimumColour_SelectedColorChanged(object sender, ColorEventArgs e)
        {
            colMin = kcbMinimumColour.SelectedColor;
            
            pbxPreview.Invalidate();
        }

        private void kcbMediumColour_SelectedColorChanged(object sender, ColorEventArgs e)
        {
            colMedium = kcbMediumColour.SelectedColor;
            
            pbxPreview.Invalidate();
        }

        private void kcbMaximumColour_SelectedColorChanged(object sender, ColorEventArgs e)
        {
            colMax = kcbMaximumColour.SelectedColor;
            
            pbxPreview.Invalidate();
        }

        private void kcmbFillMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            gradient = kcmbFillMode.SelectedIndex == 1;

            UpdateUI();
        }

        private void UpdateUI()
        {
            switch (mode)
            {
                case EnumConditionalFormatType.Bar:
                    klblFill.Visible = true;
                    kcmbFillMode.Visible = true;
                    kcbMinimumColour.Visible = true;
                    kcbMediumColour.Visible = false;
                    kcbMaximumColour.Visible = false;
                    break;
                case EnumConditionalFormatType.TwoColoursRange:
                    klblFill.Visible = false;
                    kcmbFillMode.Visible = false;
                    kcbMinimumColour.Visible = true;
                    kcbMediumColour.Visible = false;
                    kcbMaximumColour.Visible = true;
                    break;
                case EnumConditionalFormatType.ThreeColoursRange:
                    klblFill.Visible = false;
                    kcmbFillMode.Visible = false;
                    kcbMinimumColour.Visible = true;
                    kcbMediumColour.Visible = true;
                    kcbMaximumColour.Visible = true;
                    break;
            }
            pbxPreview.Invalidate();
        }

        private void kcmbStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            mode = (EnumConditionalFormatType)Enum.Parse(typeof(EnumConditionalFormatType), ((KryptonListItem)kcmbStyle.Items[kcmbStyle.SelectedIndex]).Tag.ToString());
            
            UpdateUI();
        }

        private void CustomFormatRule_Load(object sender, EventArgs e)
        {
            kcbMinimumColour.SelectedColor = colMin;
            kcbMediumColour.SelectedColor = colMedium;
            kcbMaximumColour.SelectedColor = colMax;

            int selected = -1;
            string[] names = Enum.GetNames(typeof(EnumConditionalFormatType));
            for (int i = 0; i < names.Length; i++)
            {
                if (mode.ToString().Equals(names[i]))
                    selected = i;
                kcmbStyle.Items.Add(new KryptonListItem(LanguageManager.Instance.GetLocalisedString(names[i])) { Tag = names[i] });
            }
            kcmbStyle.SelectedIndex = selected;
        }

        private void pbxPreview_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            switch (mode)
            {
                case EnumConditionalFormatType.Bar:
                    if (gradient)
                    {
                        using (LinearGradientBrush br = new LinearGradientBrush(e.ClipRectangle, colMin, Color.White, LinearGradientMode.Horizontal))
                        {
                            e.Graphics.FillRectangle(br, e.ClipRectangle);
                        }
                    }
                    else
                    {
                        using (SolidBrush br = new SolidBrush(colMin))
                        {
                            e.Graphics.FillRectangle(br, e.ClipRectangle);
                        }
                    }
                    using (Pen pen = new Pen(colMin)) //Color.FromArgb(255, 140, 197, 66)))
                    {
                        Rectangle rect = e.ClipRectangle;
                        rect.Inflate(-1, -1);
                        e.Graphics.DrawRectangle(pen, rect);
                    }
                    break;
                case EnumConditionalFormatType.TwoColoursRange:
                    // Draw the background gradient.
                    using (LinearGradientBrush br = new LinearGradientBrush(e.ClipRectangle, colMin, colMax, LinearGradientMode.Horizontal))
                    {
                        e.Graphics.FillRectangle(br, e.ClipRectangle);
                    }
                    break;
                case EnumConditionalFormatType.ThreeColoursRange:
                    // Draw the background gradient.              
                    using (LinearGradientBrush br = new LinearGradientBrush(e.ClipRectangle, colMin, colMax, LinearGradientMode.Horizontal))
                    {
                        ColorBlend blend = new ColorBlend();
                        blend.Colors = new Color[] { colMin, colMedium, colMax };
                        blend.Positions = new float[] { 0f, 0.5f, 1.0f };
                        br.InterpolationColors = blend;
                        e.Graphics.FillRectangle(br, e.ClipRectangle);
                    }
                    break;
            }
        }
    }
}