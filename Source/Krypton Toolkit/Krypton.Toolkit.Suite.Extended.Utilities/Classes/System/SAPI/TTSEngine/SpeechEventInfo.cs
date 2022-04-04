#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.TTSEngine
{
    [ImmutableObject(true)]
    public struct SpeechEventInfo : IEquatable<SpeechEventInfo>
    {
        private short _eventId;

        private short _parameterType;

        private int _param1;

        private IntPtr _param2;

        public short EventId
        {
            get
            {
                return _eventId;
            }
            internal set
            {
                _eventId = value;
            }
        }

        public short ParameterType
        {
            get
            {
                return _parameterType;
            }
            internal set
            {
                _parameterType = value;
            }
        }

        public int Param1
        {
            get
            {
                return _param1;
            }
            internal set
            {
                _param1 = value;
            }
        }

        public IntPtr Param2
        {
            get
            {
                return _param2;
            }
            internal set
            {
                _param2 = value;
            }
        }

        public SpeechEventInfo(short eventId, short parameterType, int param1, IntPtr param2)
        {
            _eventId = eventId;
            _parameterType = parameterType;
            _param1 = param1;
            _param2 = param2;
        }

        public static bool operator ==(SpeechEventInfo event1, SpeechEventInfo event2)
        {
            if (event1.EventId == event2.EventId && event1.ParameterType == event2.ParameterType && event1.Param1 == event2.Param1)
            {
                return event1.Param2 == event2.Param2;
            }
            return false;
        }

        public static bool operator !=(SpeechEventInfo event1, SpeechEventInfo event2)
        {
            return !(event1 == event2);
        }

        public bool Equals(SpeechEventInfo other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is SpeechEventInfo))
            {
                return false;
            }
            return Equals((SpeechEventInfo)obj);
        }

        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            return ((ValueType)this).GetHashCode();
        }
    }
}
