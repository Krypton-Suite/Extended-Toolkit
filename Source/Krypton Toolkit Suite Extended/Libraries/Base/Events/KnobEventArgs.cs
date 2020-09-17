using System;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    public class KnobEventArgs : EventArgs
    {
        private float _value;

        public float Value { get => _value; set => _value = value; }

        public KnobEventArgs()
        {

        }
    }
}
