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
    internal struct SpeechEventSapi
    {
        public short EventId;

        public short ParameterType;

        public int StreamNumber;

        public long AudioStreamOffset;

        public IntPtr Param1;

        public IntPtr Param2;

        public static bool operator ==(SpeechEventSapi event1, SpeechEventSapi event2)
        {
            if (event1.EventId == event2.EventId && event1.ParameterType == event2.ParameterType && event1.StreamNumber == event2.StreamNumber && event1.AudioStreamOffset == event2.AudioStreamOffset && event1.Param1 == event2.Param1)
            {
                return event1.Param2 == event2.Param2;
            }
            return false;
        }

        public static bool operator !=(SpeechEventSapi event1, SpeechEventSapi event2)
        {
            return !(event1 == event2);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is SpeechEventSapi))
            {
                return false;
            }
            return this == (SpeechEventSapi)obj;
        }

        public override int GetHashCode()
        {
            return ((ValueType)this).GetHashCode();
        }
    }
}