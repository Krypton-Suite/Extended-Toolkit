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

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite;

public class NaviToolstripColourTable : ProfessionalColorTable
{
    /// <summary>
    /// Overriden. Gets the color of the border of an menu item
    /// </summary>
    public override Color MenuItemBorder => Color.FromArgb(255, 189, 105);

    /// <summary>
    /// Overriden. Gets the color of selected menu item
    /// </summary>
    public override Color MenuItemSelected => Color.FromArgb(255, 231, 162);

    /// <summary>
    /// Overriden. Gets the color of the image margin 
    /// </summary>
    public override Color ImageMarginGradientBegin => Color.FromArgb(233, 238, 238);

    /// <summary>
    /// Overriden. Gets the color of the image margin
    /// </summary>
    public override Color ImageMarginGradientMiddle => Color.FromArgb(233, 238, 238);

    /// <summary>
    /// Overriden. Gets the color of image margin
    /// </summary>
    public override Color ImageMarginGradientEnd => Color.FromArgb(233, 238, 238);

    /// <summary>
    /// Overriden. Gets the background color of an menu item check
    /// </summary>
    public override Color CheckBackground => Color.FromArgb(255, 189, 105);

    /// <summary>
    /// Overriden. Gets the background color of an pressed menu item check
    /// </summary>
    public override Color CheckPressedBackground => Color.FromArgb(251, 140, 60);

    /// <summary>
    /// Overriden. Gets the background color of an selected menu item check
    /// </summary>
    public override Color CheckSelectedBackground => Color.FromArgb(251, 140, 60);

    /// <summary>
    /// Overriden. Gets the color of the border of the item check
    /// </summary>
    public override Color ButtonSelectedBorder => Color.FromArgb(255, 0, 0);
}