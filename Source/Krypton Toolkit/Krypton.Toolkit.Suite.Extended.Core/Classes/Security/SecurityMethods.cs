#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Security.Cryptography;
using System.Text;

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public class SecurityMethods
    {
        /// <summary>
        /// Creates the password. Code from: https://stackoverflow.com/questions/54991/generating-random-passwords
        /// </summary>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        public static string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();


            RNGCryptoServiceProvider rnd = new RNGCryptoServiceProvider();

            Random random = new Random();

            while (0 < length--)
            {
                res.Append(valid[random.Next(valid.Length)]);
            }
            return res.ToString();
        }
    }
}