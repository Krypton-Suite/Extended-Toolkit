#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Controls
{
    /// <summary>Handles the value property for the <see cref="KryptonKnobControlVersion1" /></summary>
    public class KnobValueChangedEventArgs : EventArgs
    {
        private int _value;

        /// <summary>Gets or sets the value for the <see cref="KryptonKnobControlVersion1" />.</summary>
        /// <value>The value.</value>
        public int Value { get => _value; set => _value = value; }

        /// <summary>Initializes a new instance of the <see cref="KnobValueChangedEventArgs" /> class.</summary>
        /// <param name="value">The value.</param>
        public KnobValueChangedEventArgs(int value) => Value = value;
    }
}