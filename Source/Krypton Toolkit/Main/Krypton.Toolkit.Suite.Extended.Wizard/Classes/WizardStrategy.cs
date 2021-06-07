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