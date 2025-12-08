#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
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
 * Base code by Steve Bate 2003 - 2017 (https://github.com/SteveBate/AdvancedWizard), modifications by Peter Wagner (aka Wagnerp) 2021 - 2025.
 *
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Wizard;

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
        if (UserAllowsMoveToProceed(Direction.Backward, out var args))
        {
            MoveToPreviousPage(args);
            SetButtonStates();
        }
    }

    public override void Next(ISelectionService selection)
    {
        if (Finishing())
        {
            return;
        }

        if (UserAllowsMoveToProceed(Direction.Forward, out var args) && _wizard.MoreThanOnePageExists())
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
        eventArgs = direction == Direction.Forward
            ? AttemptMoveToNextPage()
            : AttemptMoveToPreviousPage();

        return eventArgs.AllowPageChange;
    }

    private void MoveToPreviousPage(WizardEventArgs args)
    {
        if (!CanMoveToPreviousPage(args))
        {
            return;
        }

        int pageIndex = _wizard.IndexOfCurrentPage();
        _wizard.SelectWizardPage(_wizard.ReadIndexOfPreviousPage());
        _wizard.NextButtonEnabledState = true;
        _wizard.WizardPages[pageIndex].FirePageShowEvent();
        _wizard.FirePageChanged(pageIndex);
    }

    private void MoveToNextPage(WizardEventArgs args)
    {
        if (!CanMoveToNextPage(args))
        {
            return;
        }

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
        if (!_wizard.OnLastPage() || _wizard.HasExplicitFinishButton())
        {
            return false;
        }

        _wizard.FireFinishEvent();
        return true;
    }

    private readonly KryptonAdvancedWizard _wizard;
}