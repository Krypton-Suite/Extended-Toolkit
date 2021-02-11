using System;
using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Circular.Progress.Bar
{
    public class ValueChangedEventArgs : EventArgs
    {
        #region Variables
        private int _progressValue;

        private Color _progressColour;
        #endregion

        #region Properties
        public Color ProgressColour { get => _progressColour; set => _progressColour = value; }

        public int ProgressValue { get => _progressValue; set => _progressValue = value; }
        #endregion

        #region Constructors
        public ValueChangedEventArgs(int progressValue) => ProgressValue = progressValue;

        public ValueChangedEventArgs(Color progressColour, int progressValue)
        {
            ProgressColour = progressColour;

            ProgressValue = progressValue;
        }
        #endregion
    }
}