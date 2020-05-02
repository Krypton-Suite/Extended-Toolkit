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

    /// <summary>
    /// The icon type.
    /// </summary>
    public enum IconType
    {
        /// <summary>
        /// The warning
        /// </summary>
        WARNING = 101,
        /// <summary>
        /// The help
        /// </summary>
        HELP = 102,
        /// <summary>
        /// The error
        /// </summary>
        ERROR = 103,
        /// <summary>
        /// The information
        /// </summary>
        INFO = 104,
        /// <summary>
        /// The shield
        /// </summary>
        SHIELD = 106
    }

    public enum DevelopmentState
    {
        PREALPHA,
        ALPHA,
        BETA,
        RTM,
        CURRENT,
        EOL
    }
}