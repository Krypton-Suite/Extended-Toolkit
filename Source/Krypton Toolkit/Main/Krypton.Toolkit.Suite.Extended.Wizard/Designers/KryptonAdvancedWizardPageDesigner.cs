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