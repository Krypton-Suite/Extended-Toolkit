namespace Krypton.Toolkit.Suite.Extended.ComboBox
{
    public class KryptonEnumerationComboBox : KryptonComboBox
    {
        #region Instance Fields

        private Type? _targetEnum;

        #endregion

        #region Public

        [DefaultValue(null)]
        public Type? TargetEnum { get => _targetEnum; set => _targetEnum = value; }

        #endregion

        #region Identity

        public KryptonEnumerationComboBox()
        {
            _targetEnum = null;
        }

        #endregion

        #region Protected

        protected override void OnCreateControl()
        {
            if (_targetEnum != null)
            {
                var enumValues = Enum.GetValues(_targetEnum);

                foreach (var value in enumValues)
                {
                    Items.Add(value);
                }

                SelectedIndex = 0;
            }

            base.OnCreateControl();
        }

        #endregion
    }
}