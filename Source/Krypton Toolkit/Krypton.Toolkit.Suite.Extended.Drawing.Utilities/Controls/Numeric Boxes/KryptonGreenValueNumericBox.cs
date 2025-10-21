#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities;

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

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool UseAccessibleUI { get => _useAccessibleUI; set { _useAccessibleUI = value; Invalidate(); } }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

        //ToolTipValues.Image = Properties.Resources.Green;
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
    protected override void OnPaint(PaintEventArgs? e)
    {
        AlterAppearance(_useAccessibleUI);

        AlterTypeface(_typeface);

        base.OnPaint(e);
    }
    #endregion
}