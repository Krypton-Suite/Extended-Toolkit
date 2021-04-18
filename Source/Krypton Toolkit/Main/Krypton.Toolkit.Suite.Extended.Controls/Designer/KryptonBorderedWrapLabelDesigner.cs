﻿using System.ComponentModel.Design;
using System.Windows.Forms.Design;

namespace Krypton.Toolkit.Suite.Extended.Controls
{
    internal class KryptonBorderedWrapLabelDesigner : ControlDesigner
    {
        #region Identity
        /// <summary>
        /// Initialize a new instance of the KryptonWrapLabelDesigner class.
        /// </summary>
        public KryptonBorderedWrapLabelDesigner()
        {
            // The resizing handles around the control need to change depending on the
            // value of the AutoSize and AutoSizeMode properties. When in AutoSize you
            // do not get the resizing handles, otherwise you do.
            AutoResizeHandles = true;
        }
        #endregion

        #region Public Overrides
        /// <summary>
        ///  Gets the design-time action lists supported by the component associated with the designer.
        /// </summary>
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                // Create a collection of action lists
                DesignerActionListCollection actionLists = new DesignerActionListCollection
                {

                    // Add the wrpa label specific list
                    new KryptonBorderedWrapLabelActionList(this)
                };

                return actionLists;
            }
        }
        #endregion
    }
}