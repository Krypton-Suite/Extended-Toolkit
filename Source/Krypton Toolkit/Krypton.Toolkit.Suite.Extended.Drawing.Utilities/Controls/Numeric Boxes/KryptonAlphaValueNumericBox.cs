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

public class KryptonAlphaValueNumericBox : KryptonNumericUpDown
{
    #region Constants
    private const int DEFAULT_VALUE = 0, MINIMUM_DEFAULT_VALUE = 0, MAXIMUM_DEFAULT_VALUE = 255;

    private Font DEFAULT_TYPEFACE = new Font("Segoe UI", 11f);
    #endregion

    #region Variable
    private Font _typeface;
    #endregion

    #region Property

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Font Typeface { get => _typeface; set { _typeface = value; Invalidate(); } }

    #endregion

    #region Constructor
    public KryptonAlphaValueNumericBox()
    {
        Minimum = MINIMUM_DEFAULT_VALUE;

        Maximum = MAXIMUM_DEFAULT_VALUE;

        Value = DEFAULT_VALUE;
    }
    #endregion

    #region Method
    private void AlterTypeface(Font typeface) => StateCommon.Content.Font = typeface;
    #endregion

    #region Overrides
    protected override void OnPaint(PaintEventArgs? e)
    {
        AlterTypeface(_typeface);

        base.OnPaint(e);
    }
    #endregion
}