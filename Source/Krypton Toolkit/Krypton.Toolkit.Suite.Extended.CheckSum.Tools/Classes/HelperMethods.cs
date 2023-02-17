#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
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
        public string[] HashTypes => _hashTypes;

        public string[] SafeNetCoreAndNewerHashTypes => _safeNETCoreAndNewerHashTypes;

        #endregion

        #region Methods
        public static void PropagateHashBox(KryptonComboBox? hashBox)
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