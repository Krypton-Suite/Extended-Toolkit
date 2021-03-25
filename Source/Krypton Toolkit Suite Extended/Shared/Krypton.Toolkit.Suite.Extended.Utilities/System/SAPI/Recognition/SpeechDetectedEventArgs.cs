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
    public class SpeechDetectedEventArgs : EventArgs
    {
        private TimeSpan _audioPosition;

        public TimeSpan AudioPosition => _audioPosition;

        internal SpeechDetectedEventArgs(TimeSpan audioPosition)
        {
            _audioPosition = audioPosition;
        }
    }
}
