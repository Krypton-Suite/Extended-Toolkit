using System;

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
