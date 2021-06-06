namespace Krypton.Toolkit.Suite.Extended.Wizard
{
    public class WizardPageChangedEventArgs : EventArgs
    {
        public WizardPageChangedEventArgs(KryptonAdvancedWizardPage page, int pageIndex)
        {
            Page = page;
            PageIndex = pageIndex;
        }

        public KryptonAdvancedWizardPage Page { get; set; }

        public int PageIndex { get; }
    }
}