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
    /// <summary>
    /// Handles attributes for the <see cref="KryptonKnobControl" /> control.
    /// </summary>
    /// <seealso cref="EventArgs" />
    public class KnobEventArgs : EventArgs
    {
        private float _value;

        /// <summary>Gets or sets the value of the <seealso cref="KryptonKnobControl">control.</seealso></summary>
        /// <value>
        /// The value.
        /// </value>
        public float Value { get => _value; set => _value = value; }

        /// <summary>Initializes a new instance of the <see cref="KnobEventArgs" /> class.</summary>
        public KnobEventArgs()
        {

        }
    }
}
