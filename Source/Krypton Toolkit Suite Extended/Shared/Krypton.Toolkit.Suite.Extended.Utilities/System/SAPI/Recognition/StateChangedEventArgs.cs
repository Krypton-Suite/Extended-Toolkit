#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition
{
    public class StateChangedEventArgs : EventArgs
    {
        private RecognizerState _recognizerState;

        public RecognizerState RecognizerState => _recognizerState;

        internal StateChangedEventArgs(RecognizerState recognizerState)
        {
            _recognizerState = recognizerState;
        }
    }
}
