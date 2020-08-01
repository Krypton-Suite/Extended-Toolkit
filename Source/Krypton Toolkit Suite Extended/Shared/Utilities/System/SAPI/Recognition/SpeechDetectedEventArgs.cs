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
