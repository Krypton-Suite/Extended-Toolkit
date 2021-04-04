#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Krypton.Toolkit.Suite.Extended.Floating.Toolbars
{
    internal class MenuStripPanelCollectionEditor : UITypeEditor
    {
        #region Overrides
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return base.GetEditStyle(context);
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService service = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;

            FloatableMenuStrip floatableMenuStrip = context.Instance as FloatableMenuStrip;

            MenuStripExistingComponentChooser ecc = new MenuStripExistingComponentChooser(floatableMenuStrip.MenuStripPanelExtenedList);

            ecc.Text = "MenuStripPanelCollectionEditor";

            if (floatableMenuStrip.OriginalParent != null)
            {
                if (floatableMenuStrip.OriginalParent is KryptonForm)
                {
                    ecc.SourceComponentContainer = floatableMenuStrip.OriginalParent;
                }
                else
                {
                    ecc.SourceComponentContainer = floatableMenuStrip.OriginalParent.Parent;
                }
            }

            if (service != null)
            {
                if (service.ShowDialog(ecc) == DialogResult.OK)
                {
                    return ecc.SelectedComponents;
                }
            }

            return floatableMenuStrip.MenuStripPanelExtenedList;
        }
        #endregion
    }
}