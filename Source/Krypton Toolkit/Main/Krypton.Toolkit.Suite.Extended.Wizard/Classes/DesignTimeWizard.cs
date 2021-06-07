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
    public class DesignTimeWizardStrategy : WizardStrategy
    {
        public DesignTimeWizardStrategy(KryptonAdvancedWizard wizard)
        {
            _wizard = wizard;
        }

        public override void Loading()
        {
            if (_wizard.HasPages())
                _wizard.SelectFirstPage();
        }

        public override void SetButtonStates()
        {
            if (!_wizard.HasPages() || _wizard.HasOnePage())
            {
                _wizard.BackButtonEnabled = false;
                _wizard.NextButtonEnabled = false;
                return;
            }

            if (_wizard.OnFirstPage() && _wizard.MoreThanOnePageExists())
            {
                _wizard.BackButtonEnabled = false;
                _wizard.NextButtonEnabled = true;
                _wizard.SetButtonText("btnNext", _wizard.ReadNextText());
                return;
            }

            if (_wizard.OnLastPage() && _wizard.HasExplicitFinishButton())
            {
                _wizard.BackButtonEnabled = true;
                _wizard.NextButtonEnabled = false;
                return;
            }

            if (_wizard.OnLastPage())
            {
                _wizard.BackButtonEnabled = true;
                _wizard.FinishButtonEnabled = true;
                _wizard.SetButtonText("btnNext", _wizard.FinishButtonText);
                return;
            }

            if (_wizard.OnFirstPage())
            {
                _wizard.BackButtonEnabled = false;
                _wizard.NextButtonEnabled = false;
                _wizard.SetButtonText("btnNext", _wizard.ReadNextText());
            }

            if (_wizard.OnAMiddlePage())
            {
                _wizard.BackButtonEnabled = true;
                _wizard.NextButtonEnabled = true;
            }
        }

        public override void Back(ISelectionService selection)
        {
            _wizard.SelectPreviousPage();
            SetButtonStates();
            SelectPageInProperyGrid(selection);
        }

        public override void Next(ISelectionService selection)
        {
            _wizard.SelectNextPage();
            SetButtonStates();
            SelectPageInProperyGrid(selection);
        }

        public override void Cancel() { /* stub - not required at design time */ }

        public override void Help() { /* stub - not required at design time */ }

        public override void Finish() { /* tub - not required at design time */ }

        public override void GoToPage(int pageIndex) { /*stub - not required at design time*/ }

        public override void GoToPage(KryptonAdvancedWizardPage page) { /* stub - not required at design time */ }

        private void SelectPageInProperyGrid(ISelectionService selection) => selection.SetSelectedComponents(new object[] { _wizard.CurrentPage }, SelectionTypes.MouseDown);

        private readonly KryptonAdvancedWizard _wizard;
    }
}