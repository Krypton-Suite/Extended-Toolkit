#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis
{
    /// <filterpriority>2</filterpriority>
    public class VisemeReachedEventArgs : PromptEventArgs
    {
        private int _currentViseme;

        private TimeSpan _audioPosition;

        private TimeSpan _duration;

        private SynthesizerEmphasis _emphasis;

        private int _nextViseme;

        public int Viseme => _currentViseme;

        public TimeSpan AudioPosition => _audioPosition;

        public TimeSpan Duration => _duration;

        public SynthesizerEmphasis Emphasis => _emphasis;

        public int NextViseme => _nextViseme;

        internal VisemeReachedEventArgs(Prompt speakPrompt, int currentViseme, TimeSpan audioPosition, TimeSpan duration, SynthesizerEmphasis emphasis, int nextViseme)
            : base(speakPrompt)
        {
            _currentViseme = currentViseme;
            _audioPosition = audioPosition;
            _duration = duration;
            _emphasis = emphasis;
            _nextViseme = nextViseme;
        }
    }
}
