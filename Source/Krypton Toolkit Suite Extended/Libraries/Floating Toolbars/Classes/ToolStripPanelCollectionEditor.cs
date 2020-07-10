using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Krypton.Toolkit.Suite.Extended.Floating.Toolbars
{
    internal class ToolStripPanelCollectionEditor : UITypeEditor
    {
        #region Overrides
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return base.GetEditStyle(context);
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService service = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;

            FloatableToolStrip floatableToolStrip = context.Instance as FloatableToolStrip;

            ToolStripExistingComponentChooser ecc = new ToolStripExistingComponentChooser(floatableToolStrip.ToolStripPanelExtenedList);

            ecc.Text = "ToolStripPanelCollectionEditor";

            if (floatableToolStrip.OriginalParent != null)
            {
                if (floatableToolStrip.OriginalParent is KryptonForm)
                {
                    ecc.SourceComponentContainer = floatableToolStrip.OriginalParent;
                }
                else
                {
                    ecc.SourceComponentContainer = floatableToolStrip.OriginalParent.Parent;
                }
            }

            if (service != null)
            {
                if (service.ShowDialog(ecc) == DialogResult.OK)
                {
                    return ecc.SelectedComponents;
                }
            }

            return floatableToolStrip.ToolStripPanelExtenedList;
        }
        #endregion
    }
}