namespace Krypton.Toolkit.Suite.Extended.Common
{
    /// <summary>Handles the value property for the <see cref="CommonKryptonKnobControlEnhanced" /></summary>
    public class KnobValueChangedEventArgs : EventArgs
    {
        private int _value;

        /// <summary>Gets or sets the value for the <see cref="CommonKryptonKnobControlEnhanced" />.</summary>
        /// <value>The value.</value>
        public int Value { get => _value; set => _value = value; }

        /// <summary>Initializes a new instance of the <see cref="KnobValueChangedEventArgs" /> class.</summary>
        /// <param name="value">The value.</param>
        public KnobValueChangedEventArgs(int value) => Value = value;
    }
}