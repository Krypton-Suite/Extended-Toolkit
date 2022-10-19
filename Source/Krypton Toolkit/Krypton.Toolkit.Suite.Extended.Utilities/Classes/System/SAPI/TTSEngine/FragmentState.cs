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

using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.TTSEngine
{
    [ImmutableObject(true)]
    public struct FragmentState : IEquatable<FragmentState>
    {
        private TtsEngineAction _action;

        private int _langId;

        private int _emphasis;

        private int _duration;

        private SayAs _sayAs;

        private Prosody _prosody;

        private char[] _phoneme;

        public TtsEngineAction Action
        {
            get => _action;
            internal set => _action = value;
        }

        public int LangId
        {
            get => _langId;
            internal set => _langId = value;
        }

        public int Emphasis
        {
            get => _emphasis;
            internal set => _emphasis = value;
        }

        public int Duration
        {
            get => _duration;
            internal set => _duration = value;
        }

        public SayAs SayAs
        {
            get => _sayAs;
            internal set
            {
                Helpers.ThrowIfNull(value, "value");
                _sayAs = value;
            }
        }

        public Prosody Prosody
        {
            get => _prosody;
            internal set
            {
                Helpers.ThrowIfNull(value, "value");
                _prosody = value;
            }
        }

        public char[] Phoneme
        {
            get => _phoneme;
            internal set
            {
                Helpers.ThrowIfNull(value, "value");
                _phoneme = value;
            }
        }

        public FragmentState(TtsEngineAction action, int langId, int emphasis, int duration, SayAs sayAs, Prosody prosody, char[] phonemes)
        {
            _action = action;
            _langId = langId;
            _emphasis = emphasis;
            _duration = duration;
            _sayAs = sayAs;
            _prosody = prosody;
            _phoneme = phonemes;
        }

        /// <filterpriority>2</filterpriority>
        public static bool operator ==(FragmentState state1, FragmentState state2)
        {
            if (state1.Action == state2.Action && state1.LangId == state2.LangId && state1.Emphasis == state2.Emphasis && state1.Duration == state2.Duration && state1.SayAs == state2.SayAs && state1.Prosody == state2.Prosody)
            {
                return object.Equals(state1.Phoneme, state2.Phoneme);
            }
            return false;
        }

        /// <filterpriority>2</filterpriority>
        public static bool operator !=(FragmentState state1, FragmentState state2)
        {
            return !(state1 == state2);
        }

        public bool Equals(FragmentState other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is FragmentState))
            {
                return false;
            }
            return Equals((FragmentState)obj);
        }

        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            return ((ValueType)this).GetHashCode();
        }
    }
}
