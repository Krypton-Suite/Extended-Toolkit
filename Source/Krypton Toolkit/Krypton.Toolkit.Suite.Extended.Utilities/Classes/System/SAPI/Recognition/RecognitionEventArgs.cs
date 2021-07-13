#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;

namespace Krypton.Toolkit.Suite.Extended.Utilities
{
    [Serializable]
    public abstract class RecognitionEventArgs : EventArgs
    {
        private RecognitionResult _result;

        public RecognitionResult Result => _result;

        internal RecognitionEventArgs(RecognitionResult result)
        {
            _result = result;
        }
    }
}
