#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    /// <summary>
    /// For 'About' windows.
    /// </summary>
    public interface IAbout
    {
        /// <summary>
        /// Gets or sets a value indicating whether [use icon].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [use icon]; otherwise, <c>false</c>.
        /// </value>
        bool UseIcon { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [show system information button].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show system information button]; otherwise, <c>false</c>.
        /// </value>
        bool ShowSystemInformationButton { get; set; }

        /// <summary>
        /// Gets or sets the creation date time.
        /// </summary>
        /// <value>
        /// The creation date time.
        /// </value>
        DateTime CreationDateTime { get; set; }

        /// <summary>
        /// Gets or sets the name of the application.
        /// </summary>
        /// <value>
        /// The name of the application.
        /// </value>
        String ApplicationName { get; set; }

        /// <summary>
        /// Gets or sets the application version.
        /// </summary>
        /// <value>
        /// The application version.
        /// </value>
        Version ApplicationVersion { get; set; }

        /// <summary>
        /// Gets or sets the framework version.
        /// </summary>
        /// <value>
        /// The framework version.
        /// </value>
        Version FrameworkVersion { get; set; }

        /// <summary>
        /// Gets or sets the application icon.
        /// </summary>
        /// <value>
        /// The application icon.
        /// </value>
        Icon ApplicationIcon { get; set; }

        /// <summary>
        /// Gets or sets the application icon image.
        /// </summary>
        /// <value>
        /// The application icon image.
        /// </value>
        Image ApplicationIconImage { get; set; }

        /// <summary>
        /// Gets or sets the name of the authour.
        /// </summary>
        /// <value>
        /// The name of the authour.
        /// </value>
        string AuthourName { get; set; }

        /// <summary>
        /// Gets or sets the install location.
        /// </summary>
        /// <value>
        /// The install location.
        /// </value>
        string InstallLocation { get; set; }
    }
}