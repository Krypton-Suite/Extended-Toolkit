#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

#pragma warning disable CS8602, CS8765
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
            IWindowsFormsEditorService? service = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;

            FloatableToolStrip? floatableToolStrip = context.Instance as FloatableToolStrip;

            ToolStripExistingComponentChooser ecc = new ToolStripExistingComponentChooser(floatableToolStrip.ToolStripPanelExtendedList);

            ecc.Text = @"ToolStripPanelCollectionEditor";

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

            return floatableToolStrip.ToolStripPanelExtendedList;
        }
        #endregion
    }
}