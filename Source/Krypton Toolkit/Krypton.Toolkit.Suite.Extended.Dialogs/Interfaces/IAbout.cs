#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
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