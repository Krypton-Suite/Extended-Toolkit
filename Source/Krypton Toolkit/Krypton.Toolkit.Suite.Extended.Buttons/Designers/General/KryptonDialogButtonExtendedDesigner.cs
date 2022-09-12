using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Buttons
{
    internal class KryptonDialogButtonExtendedDesigner : ControlDesigner
    {
        #region Identity

        /// <summary>Initializes a new instance of the <see cref="KryptonDialogButtonExtendedDesigner" /> class.</summary>
        public KryptonDialogButtonExtendedDesigner()
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
                DesignerActionListCollection actionList = new()
                {
                    new KryptonDialogButtonExtendedActionList(this)
                };

                return actionList;
            }
        }

        #endregion
    }
}
