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
    public struct ProsodyNumber : IEquatable<ProsodyNumber>
    {
        public const int AbsoluteNumber = int.MaxValue;

        private int _ssmlAttributeId;

        private bool _isPercent;

        private float _number;

        private ProsodyUnit _unit;

        public int SsmlAttributeId
        {
            get
            {
                return _ssmlAttributeId;
            }
            internal set
            {
                _ssmlAttributeId = value;
            }
        }

        public bool IsNumberPercent
        {
            get
            {
                return _isPercent;
            }
            internal set
            {
                _isPercent = value;
            }
        }

        public float Number
        {
            get
            {
                return _number;
            }
            internal set
            {
                _number = value;
            }
        }

        public ProsodyUnit Unit
        {
            get
            {
                return _unit;
            }
            internal set
            {
                _unit = value;
            }
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
