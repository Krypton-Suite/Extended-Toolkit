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
            get => _eventId;
            internal set => _eventId = value;
        }

        public short ParameterType
        {
            get => _parameterType;
            internal set => _parameterType = value;
        }

        public int Param1
        {
            get => _param1;
            internal set => _param1 = value;
        }

        public IntPtr Param2
        {
            get => _param2;
            internal set => _param2 = value;
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
