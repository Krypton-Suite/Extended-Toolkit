using System.ComponentModel.Design;

namespace Krypton.Toolkit.Suite.Extended.Buttons
{
    internal class KryptonAbortDialogButtonActionList : DesignerActionList
    {
        #region Instance Fields
        private readonly KryptonAbortDialogButton _button;
        private readonly IComponentChangeService _service;
        #endregion

        #region Identity
        /// <summary>
        /// Initialize a new instance of the KryptonButtonActionList class.
        /// </summary>
        /// <param name="owner">Designer that owns this action list instance.</param>
        public KryptonAbortDialogButtonActionList(KryptonAbortDialogButtonDesigner owner) : base(owner.Component)
        {
            // Remember the button instance
            _button = owner.Component as KryptonAbortDialogButton;

            // Cache service used to notify when a property has changed
            _service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
        }
        #endregion

        #region Public
        public KryptonForm ParentWindow
        {
            get => _button.ParentWindow;

            set
            {
                if (_button.ParentWindow != value)
                {
                    _service.OnComponentChanged(_button, null, _button.ParentWindow, value);

                    _button.ParentWindow = value;
                }
            }
        }
        #endregion

        #region Public Overrides
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection actions = new DesignerActionItemCollection();

            if (_button != null)
            {
                actions.Add(new DesignerActionHeaderItem("Button Values"));
                actions.Add(new DesignerActionPropertyItem("ParentWindow", "ParentWindow", "Button Values", "Specifies the parent window of the button."));
            }

            return actions;
        }
        #endregion
    }
}