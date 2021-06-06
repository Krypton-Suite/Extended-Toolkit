namespace Krypton.Toolkit.Suite.Extended.Wizard
{
    public abstract class WizardStrategy
    {
        public abstract void Loading();
        public abstract void SetButtonStates();
        public abstract void Cancel();
        public abstract void Help();
        public abstract void Finish();
        public abstract void Next(ISelectionService selection);
        public abstract void Back(ISelectionService selection);
        public abstract void GoToPage(int pageIndex);
        public abstract void GoToPage(KryptonAdvancedWizardPage page);

        public static WizardStrategy CreateWizard(bool DesignMode, KryptonAdvancedWizard wizard)
        {
            if (DesignMode)
                return new DesignTimeWizardStrategy(wizard);

            return new RuntimeWizardStrategy(wizard);
        }
    }
}