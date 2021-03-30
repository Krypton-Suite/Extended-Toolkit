using System.ComponentModel.Design;

namespace Krypton.Toolkit.Suite.Extended.Messagebox
{
    internal class ExtendedKryptonMessageBoxActionList : DesignerActionList
    {
        #region Instance Fields
        private readonly ExtendedKryptonMessageBox _messageBoxExtended;

        private readonly IComponentChangeService _service;
        #endregion

        #region Identity
        public ExtendedKryptonMessageBoxActionList(ExtendedKryptonMessageBoxDesigner owner) : base(owner.Component)
        {
            _messageBoxExtended = owner.Component as ExtendedKryptonMessageBox;

            _service = (IComponentChangeService)GetService(typeof(IComponentChangeService));
        }
        #endregion

        #region Public

        #endregion

        #region Public Override
        public override DesignerActionItemCollection GetSortedActionItems()
        {
            DesignerActionItemCollection actions = new DesignerActionItemCollection();

            if (_messageBoxExtended != null)
            {

            }

            return actions;
        }
        #endregion
    }
}