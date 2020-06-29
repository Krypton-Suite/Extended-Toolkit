using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    public class KnobValueChangedEventArgs : EventArgs
    {
        private int _value;

        public int Value { get => _value; set => _value = value; }

        public KnobValueChangedEventArgs(int value)
        {
            Value = value;
        }
    }
}