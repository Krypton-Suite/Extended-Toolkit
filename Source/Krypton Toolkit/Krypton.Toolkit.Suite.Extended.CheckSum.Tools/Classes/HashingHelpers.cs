#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

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
            // Set aside 32 bits in memory, for the total string length of the MD5 hash
            StringBuilder builder = new StringBuilder(32);

            foreach (byte b in hashBytes)
            {
                builder.Append(b.ToString("X2"));
            }

            return builder.ToString();
        }

        public static string BuildSHA1HashString(byte[] hashBytes)
        {
            // Set aside 40 bits in memory, for the total string length of the SHA-1 hash
            StringBuilder builder = new StringBuilder(40);

            foreach (byte b in hashBytes)
            {
                builder.Append(b.ToString("X2"));
            }

            return builder.ToString();
        }

        public static string BuildSHA256HashString(byte[] hashBytes)
        {
            // Set aside 64 bits in memory, for the total string length of the SHA-256 hash
            StringBuilder builder = new StringBuilder(64);

            foreach (byte b in hashBytes)
            {
                builder.Append(b.ToString("X2"));
            }

            return builder.ToString();
        }

        public static string BuildSHA384HashString(byte[] hashBytes)
        {
            // Set aside 96 bits in memory, for the total string length of the SHA-384 hash
            StringBuilder builder = new StringBuilder(96);

            foreach (byte b in hashBytes)
            {
                builder.Append(b.ToString("X2"));
            }

            return builder.ToString();
        }

        public static string BuildSHA512HashString(byte[] hashBytes)
        {
            // Set aside 128 bits in memory, for the total string length of the SHA-512 hash
            StringBuilder builder = new StringBuilder(128);

            foreach (byte b in hashBytes)
            {
                builder.Append(b.ToString("X2"));
            }

            return builder.ToString();
        }

        public static string BuildRIPEMD160HashString(byte[] hashBytes)
        {
            // Set aside 40 bits in memory, for the total string length of the RIPEMD-160 hash
            StringBuilder builder = new StringBuilder(40);

            foreach (byte b in hashBytes)
            {
                builder.Append(b.ToString("X2"));
            }

            return builder.ToString();
        }
        #endregion
    }
}