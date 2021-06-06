namespace Krypton.Toolkit.Suite.Extended.Wizard
{
    public class WizardPageEventArgs : EventArgs
    {
        public WizardPageEventArgs(KryptonAdvancedWizardPage page)
        {
            Page = page;
        }

        public KryptonAdvancedWizardPage Page { get; }
    }
}