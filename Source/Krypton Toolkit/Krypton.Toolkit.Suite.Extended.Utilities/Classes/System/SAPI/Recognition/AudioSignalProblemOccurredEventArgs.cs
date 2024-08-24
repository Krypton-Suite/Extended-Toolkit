#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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