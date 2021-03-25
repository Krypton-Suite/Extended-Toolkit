namespace Krypton.Toolkit.Suite.Extended.Networking
{
    public static class FTPStringExtensions
    {
        public static FTPStatusCode ToStatusCode(this string operand)
        {
            int statusCodeValue;

            int.TryParse(operand.Substring(0, 3), out statusCodeValue);

            return statusCodeValue.ToNullableEnum<FTPStatusCode>() ?? FTPStatusCode.UNDEFINED;
        }
    }
}