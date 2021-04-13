using System.ComponentModel.Design;
using System.Windows.Forms.Design;

namespace Krypton.Toolkit.Suite.Extended.Buttons
{
    public class KryptonAbortDialogButtonDesigner : ControlDesigner
    {
        #region Identity
        /// <summary>
        /// Initialize a new instance of the KryptonButtonDesigner class.
        /// </summary>
        public KryptonAbortDialogButtonDesigner()
        {
            // The resizing handles around the control need to change depending on the
            // value of the AutoSize and AutoSizeMode properties. When in AutoSize you
            // do not get the resizing handles, otherwise you do.
            AutoResizeHandles = true;
        }
        #endregion

        #region Public Overrides
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                DesignerActionListCollection actionLists = new DesignerActionListCollection
                {
                    new KryptonAbortDialogButtonActionList(this)
                };

                return actionLists;
            }
        }
        #endregion
    }
}