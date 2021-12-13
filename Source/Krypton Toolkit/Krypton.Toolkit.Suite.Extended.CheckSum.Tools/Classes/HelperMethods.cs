#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.CheckSum.Tools
{
    public class HelperMethods
    {
        #region Variables
        private string[] _hashTypes = new string[] { "MD5", "SHA1", "SHA256", "SHA384", "SHA512", "RIPEMD160" }, _safeNETCoreAndNewerHashTypes = new string[] { "MD5", "SHA1", "SHA256", "SHA384", "SHA512" };
        #endregion

        #region Properties
        public string[] HashTypes { get => _hashTypes; }

        public string[] SafeNetCoreAndNewerHashTypes { get => _safeNETCoreAndNewerHashTypes; }
        #endregion

        #region Methods
        public static void PropagateHashBox(KryptonComboBox hashBox)
        {
            HelperMethods helperMethods = new HelperMethods();

#if NETCOREAPP3_0_OR_GREATER
            foreach (string hashType in helperMethods.SafeNetCoreAndNewerHashTypes)
	        {
                hashBox.Items.Add(hashType);
	        }
#else
            foreach (string hashType in helperMethods.HashTypes)
            {
                hashBox.Items.Add(hashType);
            }
#endif
        }

        public static bool IsValid(string fileCheckSum, string checkSumToCompare) => checkSumToCompare.Contains(fileCheckSum);
        #endregion
    }
}