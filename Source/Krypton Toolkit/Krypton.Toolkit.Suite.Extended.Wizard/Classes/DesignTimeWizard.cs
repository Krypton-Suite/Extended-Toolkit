#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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

#pragma warning disable CS0618
namespace Krypton.Toolkit.Suite.Extended.Wizard;

public class DesignTimeWizardStrategy : WizardStrategy
{
    public DesignTimeWizardStrategy(KryptonAdvancedWizard wizard) => _wizard = wizard;

    public override void Loading()
    {
        if (_wizard.HasPages())
        {
            _wizard.SelectFirstPage();
        }
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
        SelectPageInPropertyGrid(selection);
    }

    public override void Next(ISelectionService selection)
    {
        _wizard.SelectNextPage();
        SetButtonStates();
        SelectPageInPropertyGrid(selection);
    }

    public override void Cancel() { /* stub - not required at design time */ }

    public override void Help() { /* stub - not required at design time */ }

    public override void Finish() { /* tub - not required at design time */ }

    public override void GoToPage(int pageIndex) { /*stub - not required at design time*/ }

    public override void GoToPage(KryptonAdvancedWizardPage page) { /* stub - not required at design time */ }

    private void SelectPageInPropertyGrid(ISelectionService selection) => selection.SetSelectedComponents(new object[] { _wizard.CurrentPage }, SelectionTypes.MouseDown);

    private readonly KryptonAdvancedWizard _wizard;
}