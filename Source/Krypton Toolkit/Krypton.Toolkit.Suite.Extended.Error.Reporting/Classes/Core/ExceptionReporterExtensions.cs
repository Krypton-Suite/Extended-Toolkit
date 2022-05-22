namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
    /// <summary>
    /// All extension methods for ExceptionReporter
    /// It's important this class is internal/not public - else it will pollute the available extensions for users of this library
    /// </summary>
    internal static class ExceptionReporterExtensions
    {
        public static bool IsEmpty(this string input)
        {
            return string.IsNullOrWhiteSpace(input);
        }

        /// <summary>
        /// Truncate the specified value and length
        /// </summary>
        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value))
            {
                return value;
            }

            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
    }
}