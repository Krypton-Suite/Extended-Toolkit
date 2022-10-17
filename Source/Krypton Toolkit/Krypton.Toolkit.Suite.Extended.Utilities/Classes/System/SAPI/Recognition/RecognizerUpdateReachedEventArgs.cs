#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition
{
    /// <filterpriority>2</filterpriority>
    public class RecognizerUpdateReachedEventArgs : EventArgs
    {
        private object _userToken;

        private TimeSpan _audioPosition;

        public object UserToken => _userToken;

        public TimeSpan AudioPosition => _audioPosition;

        internal RecognizerUpdateReachedEventArgs(object userToken, TimeSpan audioPosition)
        {
            _userToken = userToken;
            _audioPosition = audioPosition;
        }
    }
}
