#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Core;
using System;

namespace Krypton.Toolkit.Suite.Extended.IO
{
    [Author("Gustavo Franco")]
    public class MixerException : Exception
    {
        #region Variables Declaration
        private readonly MMErrors mErrorCode;
        #endregion

        #region Constructors
        public MixerException(MMErrors errorCode, string errorMessage) : base(errorMessage)
        {
            mErrorCode = errorCode;
        }
        #endregion

        #region Properties
        public MMErrors ErrorCode
        {
            get { return mErrorCode; }
        }
        #endregion
    }
}