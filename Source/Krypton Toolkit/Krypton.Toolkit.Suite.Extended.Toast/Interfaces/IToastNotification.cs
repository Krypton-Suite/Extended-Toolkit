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

namespace Krypton.Toolkit.Suite.Extended.Toast
{
    /// <summary>Contains elements of <see cref="KryptonToastNotificationWindow"/>.</summary>
    public interface IToastNotification
    {
        /// <summary>Gets or sets the button location.</summary>
        /// <value>The action button location.</value>
        public ActionButtonLocation ButtonLocation { get; set; }

        /// <summary>
        /// Gets or sets the type of the action.
        /// </summary>
        /// <value>
        /// The type of the action.
        /// </value>
        public ActionType Action { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="KryptonToastNotificationWindow"/> is fade.
        /// </summary>
        /// <value>
        ///   <c>true</c> if fade; otherwise, <c>false</c>.
        /// </value>
        public bool Fade { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [show action button].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show action button]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowActionButton { get; set; }

        /// <summary>
        /// Gets or sets the sound path.
        /// </summary>
        /// <value>
        /// The sound path.
        /// </value>
        public string SoundPath { get; set; }

        /// <summary>
        /// Gets or sets the sound stream.
        /// </summary>
        /// <value>
        /// The sound stream.
        /// </value>
        public Stream SoundStream { get; set; }

        /// <summary>
        /// Gets or sets the header text.
        /// </summary>
        /// <value>
        /// The header text.
        /// </value>
        public string HeaderText { get; set; }

        /// <summary>
        /// Gets or sets the content text.
        /// </summary>
        /// <value>
        /// The content text.
        /// </value>
        public string ContentText { get; set; }

        /// <summary>
        /// Gets or sets the name of the process.
        /// </summary>
        /// <value>
        /// The name of the process.
        /// </value>
        public string ProcessName { get; set; }

        /// <summary>
        /// Gets or sets the icon image.
        /// </summary>
        /// <value>
        /// The icon image.
        /// </value>
        public Image IconImage { get; set; }

        /// <summary>
        /// Gets or sets the seconds.
        /// </summary>
        /// <value>
        /// The seconds.
        /// </value>
        public int Seconds { get; set; }

        /// <summary>Gets or sets the corner radius.</summary>
        /// <value>The corner radius.</value>
        public int CornerRadius { get; set; }

        /// <summary>Gets or sets the palette draw borders.</summary>
        /// <value>The palette draw borders.</value>
        public PaletteDrawBorders PaletteDrawBorders { get; set; }

        /// <summary>Gets or sets the type of the icon.</summary>
        /// <value>The type of the icon.</value>
        public IconType IconType { get; set; }

        /// <summary>
        /// Gets or sets the right to left support.
        /// </summary>
        /// <value>
        /// The right to left support.
        /// </value>
        public RightToLeftSupport RightToLeft { get; set; }

        /// <summary>Gets or sets the dismiss text.</summary>
        /// <value>The dismiss text.</value>
        public string DismissText { get; set; }

        /// <summary>Gets or sets the action text.</summary>
        /// <value>The action text.</value>
        public string ActionText { get; set; }

        /// <summary>Gets or sets the icon size mode.</summary>
        /// <value>The icon size mode.</value>
        public PictureBoxSizeMode IconSizeMode { get; set; }
    }
}