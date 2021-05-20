#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Circular.ProgressBar
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