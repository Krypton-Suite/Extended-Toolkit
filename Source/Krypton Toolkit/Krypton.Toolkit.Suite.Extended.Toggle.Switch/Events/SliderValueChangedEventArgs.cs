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