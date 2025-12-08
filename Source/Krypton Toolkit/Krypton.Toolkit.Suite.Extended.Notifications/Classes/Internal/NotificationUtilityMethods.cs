#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Notifications;

/// <summary>Provides useful methods for specified tasks.</summary>
internal class NotificationUtilityMethods
{
    #region Constructor
    /// <summary>Initializes a new instance of the <see cref="NotificationUtilityMethods" /> class.</summary>
    public NotificationUtilityMethods() { }
    #endregion

    #region Methods
    /// <summary>Changes the control location.</summary>
    /// <param name="control">The control.</param>
    /// <param name="location">The location.</param>
    public static void ChangeControlLocation(Control control, Point location) => control.Location = location;

    /// <summary>
    /// Converts a bitmaps to an image.
    /// </summary>
    /// <param name="bitmap">The bitmap.</param>
    /// <returns></returns>
    public static Image BitmapToImage(Bitmap bitmap)
    {
        Image tmp = new Bitmap(bitmap);

        return tmp;
    }
    #endregion
}