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
    public partial class CustomFormatRule : KryptonForm
    {
        #region Instance Fields

        private bool _gradient;

        private Color _minimumColour;

        private Color _maximumColour;

        private Color _intermediateColour;

        private EnumConditionalFormatType _conditionalFormatType;

        #endregion

        #region Public

        public bool Gradient => _gradient;

        public Color MaximumColour => _maximumColour;

        public Color MinimumColour => _minimumColour;

        public Color IntermediateColour => _intermediateColour;

        #endregion

        #region Identity

        public CustomFormatRule(EnumConditionalFormatType conditionalFormatType)
        {
            InitializeComponent();

            _conditionalFormatType = conditionalFormatType;

            StartUp();
        }

        #endregion

        #region Implementation

        private void StartUp()
        {
            kbtnCancel.Text = KryptonManager.Strings.GeneralStrings.Cancel;

            kbtnOk.Text = KryptonManager.Strings.GeneralStrings.OK;

            kcmbFillMode.SelectedIndex = 0;

            kcmbFormatStyle.SelectedIndex = -1;

            _maximumColour = Color.FromArgb(243, 120, 97);

            _intermediateColour = Color.FromArgb(252, 229, 130);

            _minimumColour = Color.FromArgb(84, 179, 122);


        }

        private void UpdateFormatType(EnumConditionalFormatType conditionalFormatType)
        {
            switch (conditionalFormatType)
            {
                case EnumConditionalFormatType.TwoColoursRange:
                    klblFill.Visible = false;
                    kcmbFillMode.Visible = false;
                    kcolbtnMinimumColour.Visible = true;
                    kcolbtnIntermediateColour.Visible = false;
                    kcolbtnMaximumColour.Visible = true;
                    break;
                case EnumConditionalFormatType.ThreeColoursRange:
                    klblFill.Visible = false;
                    kcmbFillMode.Visible = false;
                    kcolbtnMinimumColour.Visible = true;
                    kcolbtnIntermediateColour.Visible = true;
                    kcolbtnMaximumColour.Visible = true;
                    break;
                case EnumConditionalFormatType.Bar:
                    klblFill.Visible = true;
                    kcmbFillMode.Visible = true;
                    kcolbtnMinimumColour.Visible = true;
                    kcolbtnIntermediateColour.Visible = false;
                    kcolbtnMaximumColour.Visible = false;
                    break;
            }

            pbxPreview.Invalidate();
        }

        private void CustomFormatRule_Load(object sender, EventArgs e)
        {
            kcolbtnMinimumColour.SelectedColor = _minimumColour;

            kcolbtnIntermediateColour.SelectedColor = _intermediateColour;

            kcolbtnMaximumColour.SelectedColor = _maximumColour;

            int selected = -1;

            string[] names = Enum.GetNames(typeof(EnumConditionalFormatType));

            for (int i = 0; i < names.Length; i++)
            {
                if (_conditionalFormatType.ToString().Equals(names[i]))
                {
                    selected = i;
                }

                kcmbFormatStyle.Items.Add(new KryptonListItem(LanguageManager.Instance.GetString(names[i])));
            }

            kcmbFormatStyle.SelectedIndex = selected;
        }

        private void pbxPreview_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            switch (_conditionalFormatType)
            {
                case EnumConditionalFormatType.Bar:
                    if (_gradient)
                    {
                        using (LinearGradientBrush br = new LinearGradientBrush(e.ClipRectangle, _minimumColour, Color.White, LinearGradientMode.Horizontal))
                        {
                            e.Graphics.FillRectangle(br, e.ClipRectangle);
                        }
                    }
                    else
                    {
                        using (SolidBrush br = new SolidBrush(_minimumColour))
                        {
                            e.Graphics.FillRectangle(br, e.ClipRectangle);
                        }
                    }
                    using (Pen pen = new Pen(_minimumColour)) //Color.FromArgb(255, 140, 197, 66)))
                    {
                        Rectangle rect = e.ClipRectangle;
                        rect.Inflate(-1, -1);
                        e.Graphics.DrawRectangle(pen, rect);
                    }
                    break;
                case EnumConditionalFormatType.TwoColoursRange:
                    // Draw the background gradient.
                    using (LinearGradientBrush br = new LinearGradientBrush(e.ClipRectangle, _minimumColour, _maximumColour, LinearGradientMode.Horizontal))
                    {
                        e.Graphics.FillRectangle(br, e.ClipRectangle);
                    }
                    break;
                case EnumConditionalFormatType.ThreeColoursRange:
                    // Draw the background gradient.              
                    using (LinearGradientBrush br = new LinearGradientBrush(e.ClipRectangle, _minimumColour, _maximumColour, LinearGradientMode.Horizontal))
                    {
                        ColorBlend blend = new ColorBlend();
                        blend.Colors = [_minimumColour, _intermediateColour, _maximumColour];
                        blend.Positions = [0f, 0.5f, 1.0f];
                        br.InterpolationColors = blend;
                        e.Graphics.FillRectangle(br, e.ClipRectangle);
                    }
                    break;
            }
        }

        private void kbtnOk_Click(object sender, EventArgs e) => DialogResult = DialogResult.OK;

        private void kbtnCancel_Click(object sender, EventArgs e) => DialogResult = DialogResult.Cancel;

        private void kcolbtnMinimumColour_SelectedColorChanged(object sender, ColorEventArgs e)
        {
            _minimumColour = e.Color;

            pbxPreview.Invalidate();
        }

        private void kcolbtnIntermediateColour_SelectedColorChanged(object sender, ColorEventArgs e)
        {
            _intermediateColour = e.Color;

            pbxPreview.Invalidate();
        }

        private void kcolbtnMaximumColour_SelectedColorChanged(object sender, ColorEventArgs e)
        {
            _maximumColour = e.Color;

            pbxPreview.Invalidate();
        }

        private void kcmbFormatStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tag = ((KryptonListItem)kcmbFormatStyle.Items[kcmbFormatStyle.SelectedIndex]).Tag;

            if (tag != null)
            {
                _conditionalFormatType = (EnumConditionalFormatType)Enum.Parse(typeof(EnumConditionalFormatType), tag.ToString());
            }

            UpdateFormatType(_conditionalFormatType);
        }
    }

    #endregion
}
