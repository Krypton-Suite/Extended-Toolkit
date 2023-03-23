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

        public static OutlookGridLanguageStrings Strings => KryptonOutlookGrid.Strings;

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
            kbtnCancel.Text = KryptonManager.Strings.Cancel;

            kbtnOk.Text = KryptonManager.Strings.OK;

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
                    break;
                case EnumConditionalFormatType.ThreeColoursRange:
                    break;
                case EnumConditionalFormatType.Bar:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(conditionalFormatType), conditionalFormatType, null);
            }
        }

        #endregion
    }
}
