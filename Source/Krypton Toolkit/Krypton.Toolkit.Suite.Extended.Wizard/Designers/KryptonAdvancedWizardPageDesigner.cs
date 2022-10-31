#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
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
 * Base code by Steve Bate 2003 - 2017 (https://github.com/SteveBate/AdvancedWizard), modifications by Peter Wagner (aka Wagnerp) 2021 - 2023.
 *
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Wizard
{
    /// <summary>
    /// WizardPageDesigner: 
    /// 
    /// Allows drag-drop operations to be performed on our pages;
    /// 
    /// Stops a user from selecting pages and being able to drag them out of the
    /// Wizard control;
    /// 
    /// Assigned to a WizardPage through the [Designer(typeof(WizardPageDesigner))]
    /// attribute;
    /// </summary>
    internal class KryptonAdvancedWizardPageDesigner : ParentControlDesigner
    {
        public override void Initialize(IComponent c)
        {
            base.Initialize(c);
            _page = (KryptonAdvancedWizardPage)Control;
            _page.AllowDrop = false;
            DrawGrid = true;
            EnableDragDrop(true);
        }

        public override SelectionRules SelectionRules => base.SelectionRules & SelectionRules.None;

        protected override void OnDragDrop(DragEventArgs de)
        {
            de.Effect = DragDropEffects.Move;
            base.OnDragDrop(de);
        }

        private KryptonAdvancedWizardPage _page;
    }
}