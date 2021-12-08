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
