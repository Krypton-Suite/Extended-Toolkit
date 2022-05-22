#region BSD License
/*
 *
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 *
 * Base code by Steve Bate 2003 - 2017 (https://github.com/SteveBate/AdvancedWizard), modifications by Peter Wagner (aka Wagnerp) 2021.
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