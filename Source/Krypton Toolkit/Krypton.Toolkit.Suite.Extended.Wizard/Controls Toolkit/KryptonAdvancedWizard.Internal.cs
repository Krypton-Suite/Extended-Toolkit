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

namespace Krypton.Toolkit.Suite.Extended.Wizard;

public partial class KryptonAdvancedWizard
{
    internal void SetButtonStates()
    {
        _wizardStrategy.SetButtonStates();
    }

    internal void StoreIndexOfCurrentPage(int index) => WizardPages[_selectedPage].PreviousPage = index;

    internal int ReadIndexOfPreviousPage() => WizardPages[_selectedPage].PreviousPage;

    internal bool HasExplicitFinishButton() => _finishButton;

    internal bool HasPages() => WizardPages.Count > 0;

    internal int IndexOfCurrentPage() => _selectedPage;

    internal int IndexOfNextPage() => _selectedPage + 1;

    internal bool HasOnePage() => WizardPages.Count == 1;

    internal bool MoreThanOnePageExists() => WizardPages.Count > 1;

    internal bool OnFirstPage() => _selectedPage == 0;

    internal bool OnLastPage() => _selectedPage == WizardPages.Count - 1 || _lastPage == CurrentPage && CurrentPageIsFinishPage;

    internal bool OnAMiddlePage() => !OnFirstPage() && !OnLastPage();

    internal string ReadNextText() => _tempNextText;

    internal void SelectFirstPage()
    {
        _selectedPage = 0;
        KryptonAdvancedWizardPage page = WizardPages[_selectedPage];
        page.BringToFront();
        SetButtonStates();
    }

    internal void SelectWizardPage(int index)
    {
        if (index < 0 || index > WizardPages.Count)
        {
            return;
        }

        _selectedPage = index;
        KryptonAdvancedWizardPage page = WizardPages[index];
        page.BringToFront();
        SetButtonStates();
    }

    internal void SelectWizardPage(KryptonAdvancedWizardPage page)
    {
        if (!WizardPages.Contains(page))
        {
            return;
        }

        _selectedPage = WizardPages.IndexOf(page);
        page.BringToFront();
        SetButtonStates();
    }

    internal void SelectPreviousPage()
    {
        if (_selectedPage <= 0)
        {
            return;
        }

        _selectedPage--;
        KryptonAdvancedWizardPage page = WizardPages[_selectedPage];
        page.BringToFront();
        SetButtonStates();
    }

    internal void SelectNextPage()
    {
        if (_selectedPage >= WizardPages.Count - 1)
        {
            return;
        }

        _selectedPage++;
        KryptonAdvancedWizardPage page = WizardPages[_selectedPage];
        page.BringToFront();
        SetButtonStates();
    }

    internal void SetButtonText(Button b, string text) => b.Text = text;

    internal void SetButtonText(string buttonName, string text)
    {
        foreach (Control c in _kpnlButtons.Controls)
        {
            if (c.Name == buttonName)
            {
                c.Text = text;
            }
        }
    }

    internal bool WizardHasNoPages() => WizardPages.Count == 0;

    /// <summary>
    /// Check for design-time mouse clicks so that wizard pages can be navigated 
    /// at design-time. This method is called from our WizardDesigner through
    /// the overridden GetHitTest method.
    /// </summary>
    /// <param name="point"></param>
    /// <returns></returns>
    internal bool UserClickedAButtonAtDesignTime(Point point)
    {
        Control? c = GetChildAtPoint(point);
        if (c == null || c.Name != "kpnlButtons")
        {
            return false;
        }

        Control? b = c.GetChildAtPoint(c.PointToClient(Cursor.Position));
        if (b != null)
        {
            return WizardButtonWasClicked(b);
        }

        return false;
    }

    internal bool WizardButtonWasClicked(Control b) => b is Button;

    internal void FirePageChanged(int index) => PageChanged.Invoke(this, new WizardPageChangedEventArgs(WizardPages[index], index));

    internal void FireLastPage() => LastPage.Invoke(this, EventArgs.Empty);

    internal WizardEventArgs FireNextEvent(int currentTabIndex)
    {
        var ev = new WizardEventArgs(currentTabIndex);
        Next.Invoke(this, ev);
        return ev;
    }

    internal WizardEventArgs FireBackEvent(int currentTabIndex)
    {
        var ev = new WizardEventArgs(currentTabIndex, Direction.Backward);
        Back.Invoke(this, ev);
        return ev;
    }

    internal void FireFinishEvent() => Finish.Invoke(this, EventArgs.Empty);

    internal void FireHelpEvent() => Help.Invoke(this, EventArgs.Empty);

    internal void FireCancelEvent() => Cancel.Invoke(this, EventArgs.Empty);

    internal void CheckForUserChangesToEventParameters(WizardEventArgs ev, out bool allowPageToChange, out int newTabIndex)
    {
        allowPageToChange = ev.AllowPageChange;
        newTabIndex = ev.NextPageIndex;
    }

    internal void KbtnNextClick(object sender, EventArgs e) => _wizardStrategy.Next(_selectionService);

    internal void KbtnBackClick(object sender, EventArgs e) => _wizardStrategy.Back(_selectionService);

    internal void KbtnFinishClick(object sender, EventArgs e) => _wizardStrategy.Finish();

    internal void KbtnCancelClick(object sender, EventArgs e) => _wizardStrategy.Cancel();

    internal void KbtnHelpClick(object sender, EventArgs e) => _wizardStrategy.Help();
}