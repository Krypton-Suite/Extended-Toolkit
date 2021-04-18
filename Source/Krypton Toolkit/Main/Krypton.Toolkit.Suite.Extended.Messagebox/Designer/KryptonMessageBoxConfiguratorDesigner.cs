using System.ComponentModel.Design;
using System.Windows.Forms.Design;

namespace Krypton.Toolkit.Suite.Extended.Messagebox
{
    public class KryptonMessageBoxConfiguratorDesigner : ControlDesigner
    {
        #region Identity
        public KryptonMessageBoxConfiguratorDesigner()
        {
            AutoResizeHandles = true;
        }
        #endregion

        #region Overrides
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                DesignerActionListCollection actionLists = new DesignerActionListCollection();

                actionLists.Add(new KryptonMessageBoxConfiguratorActionList(this));

                return actionLists;
            }
        }
        #endregion
    }
}