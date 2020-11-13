using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    internal class HotkeysEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if ((provider != null) && (((IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService))) != null))
            {
                var form = new HotkeysEditorWindow(HotkeysMapping.Parse(value as string));

                if (form.ShowDialog() == DialogResult.OK)
                    value = form.GetHotkeys().ToString();
            }
            return value;
        }
    }
}