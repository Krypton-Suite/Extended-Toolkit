#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.NetSparkle
{
    /// <summary>
    /// Everytime when NetSparkleUpdater detects an update, the
    /// consumer can decide what should happen next with the help
    /// of the <see cref="UpdateDetected"/> event
    /// </summary>
    public enum NextUpdateAction
    {
        /// <summary>
        /// Show the user interface
        /// </summary>
        ShowStandardUserInterface = 1,
        /// <summary>
        /// Perform an unattended install
        /// </summary>
        PerformUpdateUnattended = 2,
        /// <summary>
        /// Prohibit the update
        /// </summary>
        ProhibitUpdate = 3
    }

    /// <summary>
    /// Controls the situations where files have to be signed with the DSA private key.
    /// If both a DSA public key and a signature are present, they always have to be valid.
    /// </summary>
    public enum SecurityMode
    {
        /// <summary>
        /// All files (with or without signature) will be accepted.
        /// This mode is strongly NOT recommended. It can cause critical security issues.
        /// </summary>
        Unsafe = 1,

        /// <summary>
        /// If there is a DSA public key, the app cast and download file have to be signed. 
        /// If there isn't a DSA public key, files without a signature will also be accepted. 
        /// This mode is a mix between Unsafe and Strict and can have some security issues if the 
        /// DSA public key gets lost in the application.
        /// </summary>
        UseIfPossible = 2,

        /// <summary>
        /// The app cast and download file have to be signed. This means the DSA public key must exist. This is the default mode.
        /// </summary>
        Strict = 3,
    }

    /// <summary>
    /// Possible Result values for IUpdateAvailable implementation.
    /// </summary>
    public enum UpdateAvailableResult
    {
        /// <summary>
        /// No result specified. Default value.
        /// </summary>
        None = 0,

        /// <summary>
        /// User chose to install the update immediately.
        /// </summary>
        InstallUpdate,

        /// <summary>
        /// User chose to skip the update.
        /// </summary>
        SkipUpdate,

        /// <summary>
        /// User chose to remind them later about this update.
        /// </summary>
        RemindMeLater
    }

    /// <summary>
    /// Possibilities for the status of an update request
    /// </summary>
    public enum UpdateStatus
    {
        /// <summary>
        /// An update is available
        /// </summary>
        UpdateAvailable,
        /// <summary>
        /// No updates are available
        /// </summary>
        UpdateNotAvailable,
        /// <summary>
        /// An update is available, but the user has chosen to skip this version
        /// </summary>
        UserSkipped,
        /// <summary>
        /// There was a problem fetching the appcast
        /// </summary>
        CouldNotDetermine
    }

    /// <summary>
    /// Allows for updating the application with or without user interaction.
    /// </summary>
    public enum UserInteractionMode
    {
        /// <summary>
        /// Shows the changelog UI automatically (this is the default)
        /// </summary>
        NotSilent,
        /// <summary>
        /// Downloads the latest update file and changelog automatically, but does not
        /// show any UI until asked to show UI.
        /// </summary>
        DownloadNoInstall,
        /// <summary>
        /// Downloads the latest update file and automatically runs it as an installer file.
        /// <para>WARNING: if you don't tell the user that the application is about to quit
        /// to update/run an installer, this setting might be quite the shock to the user!
        /// Make sure to implement AboutToExitForInstallerRun or AboutToExitForInstallerRunAsync
        /// so that you can show your users what is about to happen.</para>
        /// </summary>
        DownloadAndInstall,
    }

    /// <summary>
    /// Return value of the DSA verification check functions.
    /// </summary>
    public enum ValidationResult
    {
        /// <summary>
        /// The DSA public key and signature exists and they are valid.
        /// </summary>
        Valid = 1,

        /// <summary>
        /// Depending on the SecurityMode at least one of DSA public key or the signature dosn't exist or
        /// they exists but they are not valid. In this case the file will be rejected.
        /// </summary>
        Invalid = 2,

        /// <summary>
        /// There wasn't any DSA public key or signature and SecurityMode said this is okay.
        /// </summary>
        Unchecked = 3,
    }
}