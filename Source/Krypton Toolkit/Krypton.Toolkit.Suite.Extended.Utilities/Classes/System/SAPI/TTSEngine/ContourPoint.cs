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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.TTSEngine
{
    [ImmutableObject(true)]
    public struct ContourPoint : IEquatable<ContourPoint>
    {
        private float _start;

        private float _change;

        private ContourPointChangeType _changeType;

        public float Start => _start;

        public float Change => _change;

        public ContourPointChangeType ChangeType => _changeType;

        public ContourPoint(float start, float change, ContourPointChangeType changeType)
        {
            _start = start;
            _change = change;
            _changeType = changeType;
        }

        /// <filterpriority>2</filterpriority>
        public static bool operator ==(ContourPoint point1, ContourPoint point2)
        {
            if (point1.Start.Equals(point2.Start) && point1.Change.Equals(point2.Change))
            {
                return point1.ChangeType.Equals(point2.ChangeType);
            }
            return false;
        }

        /// <filterpriority>2</filterpriority>
        public static bool operator !=(ContourPoint point1, ContourPoint point2)
        {
            return !(point1 == point2);
        }

        public bool Equals(ContourPoint other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ContourPoint))
            {
                return false;
            }
            return Equals((ContourPoint)obj);
        }

        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            return ((ValueType)this).GetHashCode();
        }
    }
}
