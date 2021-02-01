#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Collections.Specialized;

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public class SecurityAssistant
    {
        #region Variables
        private string[] _supportedHashAlgorithims = new string[] { "MD-5", "SHA-1", "SHA-256", "SHA-384", "SHA-512", "RIPEMD-160" };

        private StringCollection _supportedHashAlgorithimCollection = null;
        #endregion

        #region Constructor
        public SecurityAssistant()
        {

        }
        #endregion

        #region Methods
        /// <summary>Returns the supported hash algorithims.</summary>
        /// <returns></returns>
        public string[] ReturnSupportedHashAlgorithims() => _supportedHashAlgorithims;

        public void PropagateSupportedHashAlgorithimCollection()
        {
            _supportedHashAlgorithimCollection = new StringCollection();

            foreach (string item in ReturnSupportedHashAlgorithims())
            {
                _supportedHashAlgorithimCollection.Add(item);
            }
        }

        public StringCollection ReturnSupportedHashAlgorithimCollection() => _supportedHashAlgorithimCollection;
        #endregion
    }
}