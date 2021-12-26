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
    public class RuntimeWizardStrategy : WizardStrategy
    {
        public RuntimeWizardStrategy(KryptonAdvancedWizard wizard)
        {
            _wizard = wizard;
        }

        public override void Loading()
        {
            if (_wizard.HasPages())
            {
                GoToPage(0);
            }
        }

        public override void SetButtonStates()
        {
            if (_wizard.OnLastPage() && _wizard.HasOnePage())
            {
                _wizard.BackButtonEnabled = false;
                _wizard.NextButtonEnabled = false;
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
                _wizard.SetButtonText("kbtnNext", _wizard.FinishButtonText);
                return;
            }

            if (_wizard.OnFirstPage())
            {
                _wizard.BackButtonEnabled = false;
                _wizard.NextButtonEnabled = _wizard.WizardPages.Count > 1;
                _wizard.SetButtonText("kbtnNext", _wizard.ReadNextText());
                return;
            }

            if (_wizard.OnAMiddlePage())
            {
                _wizard.BackButtonEnabled = true;
                _wizard.NextButtonEnabled = _wizard.NextButtonEnabledState;
                _wizard.SetButtonText("kbtnNext", _wizard.ReadNextText());
            }
        }

        public override void Back(ISelectionService selection)
        {
            if (UserAllowsMoveToProceed(Direction.BACKWARD, out var args))
            {
                MoveToPreviousPage(args);
                SetButtonStates();
            }
        }

        public override void Next(ISelectionService selection)
        {
            if (Finishing()) return;

            if (UserAllowsMoveToProceed(Direction.FORWARD, out var args) && _wizard.MoreThanOnePageExists())
            {
                MoveToNextPage(args);
                SetButtonStates();
            }
        }

        public override void Cancel() => _wizard.FireCancelEvent();

        public override void Help() => _wizard.FireHelpEvent();

        public override void Finish() => _wizard.FireFinishEvent();

        public override void GoToPage(int pageIndex)
        {
            int index = _wizard.IndexOfCurrentPage();
            _wizard.SelectWizardPage(pageIndex);
            _wizard.StoreIndexOfCurrentPage(index);
            _wizard.CurrentPage.FirePageShowEvent();
            _wizard.FirePageChanged(_wizard.IndexOfCurrentPage());
        }

        public override void GoToPage(KryptonAdvancedWizardPage page)
        {
            int index = _wizard.IndexOfCurrentPage();
            _wizard.SelectWizardPage(page);
            _wizard.StoreIndexOfCurrentPage(index);
            SetButtonStates();
            page.FirePageShowEvent();
            _wizard.FirePageChanged(_wizard.IndexOfCurrentPage());
        }

        private bool UserAllowsMoveToProceed(Direction direction, out WizardEventArgs eventArgs)
        {
            eventArgs = direction == Direction.FORWARD
                ? AttemptMoveToNextPage()
                : AttemptMoveToPreviousPage();

            return eventArgs.AllowPageChange;
        }

        private void MoveToPreviousPage(WizardEventArgs args)
        {
            if (!CanMoveToPreviousPage(args)) return;

            int pageIndex = _wizard.IndexOfCurrentPage();
            _wizard.SelectWizardPage(_wizard.ReadIndexOfPreviousPage());
            _wizard.NextButtonEnabledState = true;
            _wizard.WizardPages[pageIndex].FirePageShowEvent();
            _wizard.FirePageChanged(pageIndex);
        }

        private void MoveToNextPage(WizardEventArgs args)
        {
            if (!CanMoveToNextPage(args)) return;

            _wizard.SelectWizardPage(args.NextPageIndex);
            _wizard.StoreIndexOfCurrentPage(args.CurrentPageIndex);
            _wizard.WizardPages[args.NextPageIndex].FirePageShowEvent();
            _wizard.FirePageChanged(args.NextPageIndex);
            if (NextPageIsLast(args))
            {
                _wizard.FireLastPage();
            }
        }

        private bool NextPageIsLast(WizardEventArgs args) => args.NextPageIndex == _wizard.WizardPages.Count - 1;

        private bool CanMoveToPreviousPage(WizardEventArgs args) => args.NextPageIndex < _wizard.IndexOfCurrentPage();

        private bool CanMoveToNextPage(WizardEventArgs args) => args.NextPageIndex < _wizard.WizardPages.Count;

        private WizardEventArgs AttemptMoveToPreviousPage() => FireBackEvent();

        private WizardEventArgs AttemptMoveToNextPage() => FireNextEvent();

        private WizardEventArgs FireBackEvent() => _wizard.FireBackEvent(_wizard.IndexOfCurrentPage());

        private WizardEventArgs FireNextEvent() => _wizard.FireNextEvent(_wizard.IndexOfCurrentPage());

        private bool Finishing()
        {
            if (!_wizard.OnLastPage() || _wizard.HasExplicitFinishButton()) return false;
            _wizard.FireFinishEvent();
            return true;
        }

        private readonly KryptonAdvancedWizard _wizard;
    }
}