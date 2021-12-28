#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Software.Updater.SharpUpdate
{
    internal class Hasher
    {
        #region Methods
        internal static string HashFile(string filePath, HashType hashType)
        {
            switch (hashType)
            {
                case HashType.MD5:
                    return MakeHashString(MD5.Create().ComputeHash(new FileStream(filePath, FileMode.Open)));
                case HashType.SHA1:
                    return MakeHashString(SHA1.Create().ComputeHash(new FileStream(filePath, FileMode.Open)));
                case HashType.SHA256:
                    return MakeHashString(SHA256.Create().ComputeHash(new FileStream(filePath, FileMode.Open)));
                case HashType.SHA384:
                    return MakeHashString(SHA384.Create().ComputeHash(new FileStream(filePath, FileMode.Open)));
                case HashType.SHA512:
                    return MakeHashString(SHA512.Create().ComputeHash(new FileStream(filePath, FileMode.Open)));
                default:
                    return string.Empty;
            }
        }

        private static string MakeHashString(byte[] hash)
        {
            StringBuilder builder = new StringBuilder();

            foreach (byte b in hash)
            {
                builder.Append(b.ToString("x2").ToLower());
            }

            return builder.ToString();
        }
        #endregion 
    }
}