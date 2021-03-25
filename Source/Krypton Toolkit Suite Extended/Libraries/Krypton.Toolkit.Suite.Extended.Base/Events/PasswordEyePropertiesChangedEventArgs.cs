using System;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    public class PasswordEyePropertiesChangedEventArgs : EventArgs
    {
        #region Variables
        public Color _backColour;
        public KryptonButton _button;
        public Control _control;
        public Color _foreColour;
        public int _maximumWidth;
        public Panel _panel;
        public KryptonTextBox _textBox;
        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="PasswordEyePropertiesChangedEventArgs" /> class.</summary>
        /// <param name="backColour">The back colour.</param>
        /// <param name="button">The button.</param>
        /// <param name="control">The control.</param>
        /// <param name="foreColour">The fore colour.</param>
        /// <param name="maximumWidth">The maximum width.</param>
        /// <param name="panel">The panel.</param>
        /// <param name="textBox">The text box.</param>
        public PasswordEyePropertiesChangedEventArgs(Color backColour, KryptonButton button, Control control, Color foreColour, int maximumWidth, Panel panel, KryptonTextBox textBox)
        {
            _backColour = backColour;

            _button = button;

            _control = control;

            _foreColour = foreColour;

            _maximumWidth = maximumWidth;

            _panel = panel;

            _textBox = textBox;
        }
        #endregion
    }
}