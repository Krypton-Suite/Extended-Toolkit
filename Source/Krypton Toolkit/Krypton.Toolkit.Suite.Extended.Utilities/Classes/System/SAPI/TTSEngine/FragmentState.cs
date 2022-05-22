#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
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
            get
            {
                return _action;
            }
            internal set
            {
                _action = value;
            }
        }

        public int LangId
        {
            get
            {
                return _langId;
            }
            internal set
            {
                _langId = value;
            }
        }

        public int Emphasis
        {
            get
            {
                return _emphasis;
            }
            internal set
            {
                _emphasis = value;
            }
        }

        public int Duration
        {
            get
            {
                return _duration;
            }
            internal set
            {
                _duration = value;
            }
        }

        public SayAs SayAs
        {
            get
            {
                return _sayAs;
            }
            internal set
            {
                Helpers.ThrowIfNull(value, "value");
                _sayAs = value;
            }
        }

        public Prosody Prosody
        {
            get
            {
                return _prosody;
            }
            internal set
            {
                Helpers.ThrowIfNull(value, "value");
                _prosody = value;
            }
        }

        public char[] Phoneme
        {
            get
            {
                return _phoneme;
            }
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
