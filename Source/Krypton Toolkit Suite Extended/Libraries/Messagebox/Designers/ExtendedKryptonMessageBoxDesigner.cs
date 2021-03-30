using System.ComponentModel.Design;
using System.Windows.Forms.Design;

namespace Krypton.Toolkit.Suite.Extended.Messagebox
{
    internal class ExtendedKryptonMessageBoxDesigner : ControlDesigner
    {
        #region Identity
        public ExtendedKryptonMessageBoxDesigner()
        {

        }
        #endregion

        #region Public Overrides
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                DesignerActionListCollection actionLists = new DesignerActionListCollection() { new ExtendedKryptonMessageBoxActionList(this) };

                return actionLists;
            }
        }
        #endregion
    }
}