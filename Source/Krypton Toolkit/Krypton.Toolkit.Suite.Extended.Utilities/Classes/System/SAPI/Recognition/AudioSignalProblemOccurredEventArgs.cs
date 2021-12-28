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
    public class AudioSignalProblemOccurredEventArgs : EventArgs
    {
        private AudioSignalProblem _audioSignalProblem;

        private TimeSpan _recognizerPosition;

        private TimeSpan _audioPosition;

        private int _audioLevel;

        public AudioSignalProblem AudioSignalProblem => _audioSignalProblem;

        public int AudioLevel => _audioLevel;

        public TimeSpan AudioPosition => _audioPosition;

        public TimeSpan RecognizerAudioPosition => _recognizerPosition;

        internal AudioSignalProblemOccurredEventArgs(AudioSignalProblem audioSignalProblem, int audioLevel, TimeSpan audioPosition, TimeSpan recognizerPosition)
        {
            _audioSignalProblem = audioSignalProblem;
            _audioLevel = audioLevel;
            _audioPosition = audioPosition;
            _recognizerPosition = recognizerPosition;
        }
    }
}