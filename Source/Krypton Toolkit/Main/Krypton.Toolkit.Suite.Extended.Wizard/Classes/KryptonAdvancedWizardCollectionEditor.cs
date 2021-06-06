namespace Krypton.Toolkit.Suite.Extended.Wizard
{
    /// <summary>
    /// WizardCollectionEditor:
    /// 
    /// Enables WizardPages to be added to our control through the propertygrid;
    /// 
    /// Assigned to the AdvancedWizard WizardPages property through the 
    /// [Editor(typeof(WizardCollectionEditor), typeof(UITypeEditor))] attribute;
    /// </summary>
    public class KryptonAdvancedWizardCollectionEditor : CollectionEditor
    {
        public KryptonAdvancedWizardCollectionEditor(Type wizardPage)
            : base(wizardPage)
        {
        }

        protected override Type[] CreateNewItemTypes()
        {
            return new[] { typeof(KryptonAdvancedWizardPage) };
        }
    }
}