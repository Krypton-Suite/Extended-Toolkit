namespace Microsoft.Windows.API.Code.Pack.Core
{
    /// <summary>
    /// Specifies the icon displayed in a task dialog.
    /// </summary>
    public enum TaskDialogStandardIcon
    {
        /// <summary>
        /// Displays no icons (default).
        /// </summary>
        None = 0,

        /// <summary>
        /// Displays the warning icon.
        /// </summary>
        Warning = 65535,

        /// <summary>
        /// Displays the error icon.
        /// </summary>
        Error = 65534,

        /// <summary>
        /// Displays the Information icon.
        /// </summary>
        Information = 65533,

        /// <summary>
        /// Displays the User Account Control shield.
        /// </summary>
        Shield = 65532,

        /// <summary>
        /// Displays the User Account Control shield (gray) header.
        /// </summary>
        ShieldGrayHeader = 65527,

        /// <summary>
        /// Displays the security success header.
        /// </summary>
        SecuritySuccessHeader = 65528,

        /// <summary>
        /// Displays the security error header.
        /// </summary>
        SecurityErrorHeader = 65529,

        /// <summary>
        /// Displays the User Account Control warning header.
        /// </summary>
        SecurityWarningHeader = 65530,

        /// <summary>
        /// Displays the User Account Control shield (blue) header.
        /// </summary>
        ShieldBlueHeader = 65531,
    }
}