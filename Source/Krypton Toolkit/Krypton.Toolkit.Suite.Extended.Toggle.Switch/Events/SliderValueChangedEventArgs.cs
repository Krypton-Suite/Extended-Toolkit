#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Toggle.Switch
{
    public class SliderValueChangedEventArgs : EventArgs
    {
        #region Variables
        private bool _toggleValue;
        #endregion

        #region Properties
        public bool ToggleValue { get => _toggleValue; set => _toggleValue = value; }
        #endregion

        #region Constructor
        public SliderValueChangedEventArgs(bool toggleValue)
        {
            _toggleValue = toggleValue;
        }
        #endregion
    }
}