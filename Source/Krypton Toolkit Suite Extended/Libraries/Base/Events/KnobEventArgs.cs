#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

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
