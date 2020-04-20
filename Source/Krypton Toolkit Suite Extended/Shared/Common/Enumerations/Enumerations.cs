namespace Krypton.Toolkit.Extended.Common
{
    public enum SupportedHashAlgorithims
    {
        MESSAGEDIGEST5 = 0,
        SECUREHASHALGORITHIM1 = 1,
        SECUREHASHALGORITHIM256 = 2,
        SECUREHASHALGORITHIM384 = 3,
        SECUREHASHALGORITHIM512 = 4,
        RACEINTEGRITYPRIMITIVESEVALUATIONMESSAGEDIGEST = 5
    }

    /// <summary>The icon type.</summary>
    public enum IconType
    {
        /// <summary>The warning icon.</summary>
        WARNING = 101,
        /// <summary>The help icon.</summary>
        HELP = 102,
        /// <summary>The error icon.</summary>
        ERROR = 103,
        /// <summary>The information icon.</summary>
        INFO = 104,
        /// <summary>The shield icon.</summary>
        SHIELD = 106
    }

	/// <summary>The current development/support state of the application.</summary>
    public enum DevelopmentState
    {
		/// <summary>The application is in a pre-alpha state.</summary>
        PREALPHA,
		/// <summary>The application is in a alpha state.</summary>
        ALPHA,
		/// <summary>The application is in a beta state.</summary>
        BETA,
		/// <summary>The application is in the relese to manufacturing state.</summary>
        RTM,
		/// <summary>The application is in the current support state.</summary>
        CURRENT,
		/// <summary>The application has reached its end of life.</summary>
        EOL
    }

    /// <summary>The dialog result for use with the KryptonMemoryBox.</summary>
    public enum KryptonMemoryBoxDialogResult
    {
        /// <summary>A yes dialog result</summary>
        YES = 0,
		/// <summary>A yes to all dialog result</summary>
        YESTOALL = 1,
		/// <summary>A no dialog result</summary>
        NO = 2,
		/// <summary>A no to all dialog result</summary>
        NOTOALL = 3,
		/// <summary>A cancel dialog result</summary>
        CANCEL = 4
    }
}