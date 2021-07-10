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

        public static string BuildSHA1HashString(byte[] hashBytes)
        {
            StringBuilder builder = new StringBuilder(40);

            foreach (byte b in hashBytes)
            {
                builder.Append(b.ToString("X2"));
            }

            return builder.ToString();
        }

        public static string BuildSHA256HashString(byte[] hashBytes)
        {
            StringBuilder builder = new StringBuilder(64);

            foreach (byte b in hashBytes)
            {
                builder.Append(b.ToString("X2"));
            }

            return builder.ToString();
        }

        public static string BuildSHA384HashString(byte[] hashBytes)
        {
            StringBuilder builder = new StringBuilder(96);

            foreach (byte b in hashBytes)
            {
                builder.Append(b.ToString("X2"));
            }

            return builder.ToString();
        }

        public static string BuildSHA512HashString(byte[] hashBytes)
        {
            StringBuilder builder = new StringBuilder(128);

            foreach (byte b in hashBytes)
            {
                builder.Append(b.ToString("X2"));
            }

            return builder.ToString();
        }

        public static string BuildRIPEMD160HashString(byte[] hashBytes)
        {
            StringBuilder builder = new StringBuilder();

            foreach (byte b in hashBytes)
            {
                builder.Append(b.ToString("X2"));
            }

            return builder.ToString();
        }
        #endregion
    }
}