namespace Krypton.Toolkit.Suite.Extended.CheckSum.Tools
{
    public class HashingHelpers
    {
        #region Methods
        public static SupportedHashAlgorithims ReturnHashType(string hashType)
        {
            if (hashType == "MD-5")
            {
                return SupportedHashAlgorithims.MD5;
            }

            return SupportedHashAlgorithims.MD5;
        }

        public static string BuildMD5HashString(byte[] hashBytes)
        {
            StringBuilder builder = new StringBuilder(32);

            foreach (byte b in hashBytes)
            {
                builder.Append(b.ToString("X2"));
            }

            return builder.ToString();
        }
        #endregion
    }
}