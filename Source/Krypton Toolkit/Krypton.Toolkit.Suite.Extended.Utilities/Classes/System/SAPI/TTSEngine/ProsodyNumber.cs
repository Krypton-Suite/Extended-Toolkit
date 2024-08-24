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
    public struct ProsodyNumber : IEquatable<ProsodyNumber>
    {
        public const int AbsoluteNumber = int.MaxValue;

        private int _ssmlAttributeId;

        private bool _isPercent;

        private float _number;

        private ProsodyUnit _unit;

        public int SsmlAttributeId
        {
            get => _ssmlAttributeId;
            internal set => _ssmlAttributeId = value;
        }

        public bool IsNumberPercent
        {
            get => _isPercent;
            internal set => _isPercent = value;
        }

        public float Number
        {
            get => _number;
            internal set => _number = value;
        }

        public ProsodyUnit Unit
        {
            get => _unit;
            internal set => _unit = value;
        }

        public ProsodyNumber(int ssmlAttributeId)
        {
            _ssmlAttributeId = ssmlAttributeId;
            _number = 1f;
            _isPercent = true;
            _unit = ProsodyUnit.Default;
        }

        public ProsodyNumber(float number)
        {
            _ssmlAttributeId = int.MaxValue;
            _number = number;
            _isPercent = false;
            _unit = ProsodyUnit.Default;
        }

        public static bool operator ==(ProsodyNumber prosodyNumber1, ProsodyNumber prosodyNumber2)
        {
            if (prosodyNumber1._ssmlAttributeId == prosodyNumber2._ssmlAttributeId && prosodyNumber1.Number.Equals(prosodyNumber2.Number) && prosodyNumber1.IsNumberPercent == prosodyNumber2.IsNumberPercent)
            {
                return prosodyNumber1.Unit == prosodyNumber2.Unit;
            }
            return false;
        }

        public static bool operator !=(ProsodyNumber prosodyNumber1, ProsodyNumber prosodyNumber2)
        {
            return !(prosodyNumber1 == prosodyNumber2);
        }

        public bool Equals(ProsodyNumber other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ProsodyNumber))
            {
                return false;
            }
            return Equals((ProsodyNumber)obj);
        }

        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            return ((ValueType)this).GetHashCode();
        }
    }
}
