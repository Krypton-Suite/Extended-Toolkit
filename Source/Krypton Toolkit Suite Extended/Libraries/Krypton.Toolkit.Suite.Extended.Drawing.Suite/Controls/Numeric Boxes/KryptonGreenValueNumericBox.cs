﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Drawing.Suite.Properties;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Drawing.Suite
{
    public class KryptonGreenValueNumericBox : KryptonNumericUpDown
    {
        #region Constants
        private const int DEFAULT_VALUE = 0, MINIMUM_DEFAULT_VALUE = 0, MAXIMUM_DEFAULT_VALUE = 255;
        #endregion

        #region Variables
        private bool _useAccessibleUI;

        private Color _backColour, _foreColour;

        private Font _typeface;
        #endregion

        #region Properties
        public bool UseAccessibleUI { get => _useAccessibleUI; set { _useAccessibleUI = value; Invalidate(); } }

        public Font Typeface { get => _typeface; set { _typeface = value; Invalidate(); } }
        #endregion

        #region Constructor
        public KryptonGreenValueNumericBox()
        {
            Minimum = MINIMUM_DEFAULT_VALUE;

            Maximum = MAXIMUM_DEFAULT_VALUE;

            Value = DEFAULT_VALUE;

            UseAccessibleUI = false;

            StateCommon.Content.Font = Typeface;

            ToolTipValues.Description = "The green value";

            ToolTipValues.Heading = "Green Value";

            ToolTipValues.EnableToolTips = true;

            ToolTipValues.Image = Properties.Resources.Green;
        }
        #endregion

        #region Methods
        private void AlterAppearance(bool useAccessibleUI)
        {
            if (useAccessibleUI)
            {
                StateCommon.Back.Color1 = Color.Empty;

                StateCommon.Content.Color1 = Color.Empty;
            }
            else
            {
                StateCommon.Back.Color1 = Color.Green;

                StateCommon.Content.Color1 = Color.White;
            }
        }

        private void AlterTypeface(Font typeface) => StateCommon.Content.Font = typeface;
        #endregion

        #region Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            AlterAppearance(_useAccessibleUI);

            AlterTypeface(_typeface);

            base.OnPaint(e);
        }
        #endregion
    }
}