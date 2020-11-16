#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Wizard
{
    /// <summary>Button state for buttons controlling the wizard.</summary>
    public enum WizardCommandButtonState
    {
        /// <summary>Button is enabled and can be clicked.</summary>
        Enabled,
        /// <summary>Button is disabled and cannot be clicked.</summary>
        Disabled,
        /// <summary>Button is hidden from the user.</summary>
        Hidden
    }

    /// <summary>Control providing a collection of wizard style navigable pages.</summary>
    [Designer(typeof(WizardBaseDesigner))]
    [ToolboxItem(true), ToolboxBitmap(typeof(WizardControl), "Resources\\WizardControl.bmp")]
    [Description("Provides a container for wizard pages.")]
    [DefaultProperty("Pages"), DefaultEvent("SelectedPageChanged")]
    public class WizardPageContainer : ContainerControl, ISupportInitialize
    {
        private string finishBtnText;
        private bool initialized;
        private bool initializing;
        private bool nextButtonShieldEnabled;
        private string nextBtnText;
        private readonly Stack<WizardPage> pageHistory;
        private Timer progressTimer;
        private WizardPage selectedPage;
        private bool showProgressInTaskbarIcon;
        private NativeMethods.ITaskbarList4 taskbar;
        private ButtonBase backButton, cancelButton, nextButton;

        /// <summary>Initializes a new instance of the <see cref="Control"/> class.</summary>
        public WizardPageContainer()
        {
            pageHistory = new Stack<WizardPage>();

            Pages = new WizardPageCollection(this);
            Pages.ItemAdded += Pages_AddItem;
            Pages.ItemDeleted += Pages_RemoveItem;
            Pages.Reset += Pages_Reset;

            OnRightToLeftChanged(EventArgs.Empty);

            // Get localized defaults for button text
            ResetBackButtonText();
            ResetCancelButtonText();
            ResetFinishButtonText();
            ResetNextButtonText();
        }

        /// <summary>Occurs when the button's state has changed.</summary>
        [Category("Property Changed"), Description("Occurs when any of the button's state has changed.")]
        public event EventHandler ButtonStateChanged;

        /// <summary>Occurs when the user clicks the Cancel button and allows for programmatic cancellation.</summary>
        [Category("Behavior"), Description("Occurs when the user clicks the Cancel button and allows for programmatic cancellation.")]
        public event CancelEventHandler Cancelling;

        /// <summary>
        /// Occurs when the user clicks the Next/Finish button and the page is set to <see cref="WizardPage.IsFinishPage"/> or this is the last page in the
        /// <see cref="Pages"/> collection.
        /// </summary>
        [Category("Behavior"), Description("Occurs when the user clicks the Next/Finish button on last page.")]
        public event EventHandler Finished;

        /// <summary>Occurs when the <see cref="SelectedPage"/> property has changed. Use this to effectively be notified after a new wizard page is displayed.</summary>
        [Category("Property Changed"), Description("Occurs when the SelectedPage property has changed.")]
        public event EventHandler SelectedPageChanged;

        /// <summary>Gets or sets the button assigned to control backing up through the pages.</summary>
        /// <value>The back button control.</value>
        [Category("Wizard"), Description("Button used to command backward wizard flow.")]
        public ButtonBase BackButton
        {
            get => backButton;
            set
            {
                if (backButton != null)
                    backButton.Click -= backButton_Click;
                if (value == null) return;
                backButton = value;
                backButton.Click += backButton_Click;
            }
        }

        /// <summary>Gets or sets the state of the back button.</summary>
        /// <value>The state of the back button.</value>
        [Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public WizardCommandButtonState BackButtonState
        {
            get => GetCmdButtonState(BackButton);
            internal set => SetCmdButtonState(BackButton, value);
        }

        /// <summary>Gets or sets the back button text.</summary>
        /// <value>The cancel button text.</value>
        [Category("Wizard"), Localizable(true), Description("The back button text")]
        public string BackButtonText
        {
            get => GetCmdButtonText(BackButton);
            set => SetCmdButtonText(BackButton, value);
        }

        /// <summary>Gets or sets the button assigned to canceling the page flow.</summary>
        /// <value>The cancel button control.</value>
        [Category("Wizard"), Description("Button used to cancel wizard flow.")]
        public ButtonBase CancelButton
        {
            get => cancelButton;
            set
            {
                if (cancelButton != null)
                    cancelButton.Click -= cancelButton_Click;
                if (value == null) return;
                cancelButton = value;
                cancelButton.Click += cancelButton_Click;
            }
        }

        /// <summary>Gets the state of the cancel button.</summary>
        /// <value>The state of the cancel button.</value>
        [Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public WizardCommandButtonState CancelButtonState
        {
            get => GetCmdButtonState(CancelButton);
            internal set => SetCmdButtonState(CancelButton, value);
        }

        /// <summary>Gets or sets the cancel button text.</summary>
        /// <value>The cancel button text.</value>
        [Category("Wizard"), Localizable(true), Description("The cancel button text")]
        public string CancelButtonText
        {
            get => GetCmdButtonText(CancelButton);
            set => SetCmdButtonText(CancelButton, value);
        }

        /// <summary>Gets or sets the finish button text.</summary>
        /// <value>The finish button text.</value>
        [Category("Wizard"), Localizable(true), Description("The finish button text")]
        public string FinishButtonText
        {
            get => finishBtnText;
            set
            {
                finishBtnText = value;
                if (selectedPage != null && selectedPage.IsFinishPage && !this.IsDesignMode())
                {
                    SetCmdButtonText(NextButton, value);
                }
            }
        }

        /// <summary>Gets or sets the button assigned to control moving forward through the pages.</summary>
        /// <value>The next button control.</value>
        [Category("Wizard"), Description("Button used to command forward wizard flow.")]
        public ButtonBase NextButton
        {
            get => nextButton;
            set
            {
                if (nextButton != null)
                    nextButton.Click -= nextButton_Click;
                if (value == null) return;
                nextButton = value;
                nextButton.Click += nextButton_Click;
            }
        }

        /// <summary>Gets or sets the shield icon on the next button.</summary>
        /// <value><c>true</c> if Next button should display a shield; otherwise, <c>false</c>.</value>
        /// <exception cref="PlatformNotSupportedException">Setting a UAF shield on a button only works on Vista and later versions of Windows.</exception>
        [DefaultValue(false), Category("Wizard"), Description("Show a shield icon on the next button")]
        public Boolean NextButtonShieldEnabled
        {
            get => nextButtonShieldEnabled;
            set
            {
                if (nextButtonShieldEnabled == value) return;
                nextButtonShieldEnabled = value;
                NextButton.SetElevationRequiredState(value);
            }
        }

        /// <summary>Gets the state of the next button.</summary>
        /// <value>The state of the next button.</value>
        [Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public WizardCommandButtonState NextButtonState
        {
            get => GetCmdButtonState(NextButton);
            internal set => SetCmdButtonState(NextButton, value);
        }

        /// <summary>Gets or sets the next button text.</summary>
        /// <value>The next button text.</value>
        [Category("Wizard"), Localizable(true), Description("The next button text.")]
        public string NextButtonText
        {
            get => nextBtnText;
            set
            {
                nextBtnText = value;
                if (!this.IsDesignMode() && (selectedPage == null || !selectedPage.IsFinishPage))
                {
                    SetCmdButtonText(NextButton, value);
                }
            }
        }

        /// <summary>Gets the collection of wizard pages in this wizard control.</summary>
        /// <value>The <see cref="WizardPageCollection"/> that contains the <see cref="WizardPage"/> objects in this <see cref="WizardControl"/>.</value>
        [Category("Wizard"), Description("Collection of wizard pages.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public WizardPageCollection Pages { get; }

        /// <summary>Gets how far the wizard has progressed, as a percentage.</summary>
        /// <value>A value between 0 and 100.</value>
        [Browsable(false), Description("The percentage of the current page against all pages at run-time.")]
        public virtual short PercentComplete
        {
            get
            {
                var pg = SelectedPage;
                if (pg == null)
                    return 0;
                return IsLastPage(pg) ? (short)100 : Convert.ToInt16(Math.Ceiling(((double)Pages.IndexOf(SelectedPage) + 1) * 100f / Pages.Count));
            }
        }

        /// <summary>Gets the currently selected wizard page.</summary>
        /// <value>The selected wizard page. <c>null</c> if no page is active.</value>
        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual WizardPage SelectedPage
        {
            get => selectedPage == null || Pages.Count == 0 ? null : selectedPage;
            internal set
            {
                if (value != null && !Pages.Contains(value))
                    throw new ArgumentException("WizardPage is not in the Pages collection for the control.");

                System.Diagnostics.Debug.WriteLine($"SelectPage: New={(value == null ? "null" : value.Name)},Prev={(selectedPage == null ? "null" : selectedPage.Name)}");
                if (value == selectedPage) return;
                var prev = selectedPage;
                selectedPage?.Hide();
                selectedPage = value;
                var idx = SelectedPageIndex;
                if (!this.IsDesignMode())
                {
                    while (selectedPage != null && idx < Pages.Count - 1 && selectedPage.Suppress)
                        selectedPage = Pages[++idx];
                }
                if (selectedPage != null)
                {
                    //this.HeaderText = selectedPage.Text;
                    selectedPage.InitializePage(prev);
                    selectedPage.Dock = DockStyle.Fill;
                    selectedPage.PerformLayout();
                    selectedPage.Show();
                    selectedPage.BringToFront();
                    selectedPage.Focus();
                }
                UpdateUIDependencies();
                OnSelectedPageChanged();
            }
        }

        /// <summary>Gets or sets a value indicating whether to show progress in form's taskbar icon.</summary>
        /// <remarks>This will only work on Windows 7 or later and the parent form must be showing its icon in the taskbar. No exception is thrown on failure.</remarks>
        /// <value><c>true</c> to show progress in taskbar icon; otherwise, <c>false</c>.</value>
        [Category("Wizard"), DefaultValue(false), Description("Indicates whether to show progress in form's taskbar icon")]
        public bool ShowProgressInTaskbarIcon
        {
            get => showProgressInTaskbarIcon;
            set
            {
                if (!RunningOnWin7) return;
                showProgressInTaskbarIcon = value;
                UpdateTaskbarProgress();
            }
        }

        /// <summary>Gets a value indicating whether running on win7.</summary>
        /// <value><c>true</c> if [running on win7]; otherwise, <c>false</c>.</value>
        private static bool RunningOnWin7 => (Environment.OSVersion.Platform == PlatformID.Win32NT) && (Environment.OSVersion.Version.CompareTo(new Version(6, 1)) >= 0);

        /// <summary>Gets the task bar interface for the current form.</summary>
        /// <value>The task bar.</value>
        private NativeMethods.ITaskbarList4 TaskBar
        {
            get
            {
                if (taskbar != null) return taskbar;
                taskbar = (NativeMethods.ITaskbarList4)new NativeMethods.CTaskbarList();
                taskbar.HrInit();
                if (ParentForm != null) taskbar.SetProgressState(ParentForm.Handle, NativeMethods.TBPF.NORMAL);
                return taskbar;
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal bool DesignerSelected { get; set; }

        /// <summary>Gets the index of the currently selected page.</summary>
        /// <value>The index of the selected page.</value>
        internal int SelectedPageIndex => selectedPage == null ? -1 : Pages.IndexOf(selectedPage);

        /// <summary>Signals the object that initialization is starting.</summary>
        public void BeginInit()
        {
            initializing = true;
        }

        /// <summary>Signals the object that initialization is complete.</summary>
        public void EndInit()
        {
            initializing = false;
        }

        /// <summary>Advances to the specified page.</summary>
        /// <param name="nextPage">The wizard page to go to next.</param>
        /// <param name="skipCommit">if set to <c>true</c> prevent the <see cref="WizardPage.Commit"/> event from firing for the current page.</param>
        /// <exception cref="ArgumentException">When specifying a value for nextPage, it must already be in the Pages collection.</exception>
        public virtual void NextPage(WizardPage nextPage = null, bool skipCommit = false)
        {
            if (this.IsDesignMode())
            {
                var idx = SelectedPageIndex;
                if (idx < Pages.Count - 1)
                    SelectedPage = Pages[idx + 1];
                return;
            }

            if (!skipCommit && !SelectedPage.CommitPage()) return;
            if (nextPage != null)
            {
                if (!Pages.Contains(nextPage))
                    throw new ArgumentException(@"When specifying a value for nextPage, it must already be in the Pages collection.", nameof(nextPage));
                pageHistory.Push(SelectedPage);
                SelectedPage = nextPage;
            }
            else
            {
                var selNext = GetNextPage(SelectedPage);

                // Check for last page
                if (SelectedPage.IsFinishPage || selNext == null)
                {
                    OnFinished();
                    return;
                }

                // Set new SelectedPage value
                pageHistory.Push(SelectedPage);
                SelectedPage = selNext;
            }
        }

        /// <summary>Returns to the previous page.</summary>
        public virtual void PreviousPage()
        {
            if (this.IsDesignMode())
            {
                var idx = SelectedPageIndex;
                if (idx > 0)
                    SelectedPage = Pages[idx - 1];
                return;
            }

            if (SelectedPage.RollbackPage())
                SelectedPage = pageHistory.Pop();
        }

        /// <summary>Restarts the wizard pages from the first page.</summary>
        public void RestartPages()
        {
            initialized = false;
            InitialSetup();
        }

        /// <summary>Raises the <see cref="WizardControl.Cancelling"/> event.</summary>
        /// <param name="arg">The <see cref="CancelEventArgs"/> instance containing the event data.</param>
        protected virtual void OnCancelling(CancelEventArgs arg)
        {
            Cancelling?.Invoke(this, arg);
        }

        /// <summary>Raises the <see cref="WizardControl.Finished"/> event.</summary>
        protected virtual void OnFinished()
        {
            Finished?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>Raises the <see cref="E:System.Windows.Forms.Control.GotFocus"/> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            selectedPage?.Focus();
        }

        /// <summary>Raises the <see cref="E:System.Windows.Forms.Control.HandleCreated"/> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            InitialSetup();
        }

        /// <summary>Raises the <see cref="WizardControl.SelectedPageChanged"/> event.</summary>
        protected void OnSelectedPageChanged()
        {
            SelectedPageChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>Updates the buttons and taskbar according to current sequence and history.</summary>
        protected internal void UpdateUIDependencies()
        {
            System.Diagnostics.Debug.WriteLine($"UpdBtn: hstCnt={pageHistory.Count},pgIdx={SelectedPageIndex}:{Pages.Count},isFin={selectedPage != null && selectedPage.IsFinishPage}");
            if (selectedPage == null)
            {
                CancelButtonState = this.IsDesignMode() ? WizardCommandButtonState.Disabled : WizardCommandButtonState.Enabled;
                NextButtonState = BackButtonState = WizardCommandButtonState.Hidden;
            }
            else
            {
                if (this.IsDesignMode())
                {
                    CancelButtonState = WizardCommandButtonState.Disabled;
                    NextButtonState = SelectedPageIndex == Pages.Count - 1 ? WizardCommandButtonState.Disabled : WizardCommandButtonState.Enabled;
                    BackButtonState = SelectedPageIndex <= 0 ? WizardCommandButtonState.Disabled : WizardCommandButtonState.Enabled;
                }
                else
                {
                    CancelButtonState = selectedPage.ShowCancel ? (selectedPage.AllowCancel && !this.IsDesignMode() ? WizardCommandButtonState.Enabled : WizardCommandButtonState.Disabled) : WizardCommandButtonState.Hidden;
                    NextButtonState = selectedPage.ShowNext ? (selectedPage.AllowNext ? WizardCommandButtonState.Enabled : WizardCommandButtonState.Disabled) : WizardCommandButtonState.Hidden;
                    if (selectedPage.IsFinishPage || IsLastPage(SelectedPage))
                        SetCmdButtonText(NextButton, FinishButtonText);
                    else
                        SetCmdButtonText(NextButton, NextButtonText);
                    BackButtonState = pageHistory.Count == 0 || !selectedPage.AllowBack ? WizardCommandButtonState.Disabled : WizardCommandButtonState.Enabled;

                    UpdateTaskbarProgress();
                }
            }
            if (Controls.ContainsKey("stepList"))
                Controls["stepList"].Refresh();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            PreviousPage();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            var arg = new CancelEventArgs(true);
            OnCancelling(arg);
        }

        internal WizardCommandButtonState GetCmdButtonState(ButtonBase btn)
        {
            if (btn?.Tag == null)
                return WizardCommandButtonState.Hidden;
            if (btn.Tag is WizardCommandButtonState buttonState)
                return buttonState;
            if (btn.Enabled)
                return WizardCommandButtonState.Enabled;
            if (!btn.Visible)
                return WizardCommandButtonState.Hidden;
            return WizardCommandButtonState.Disabled;
        }

        private string GetCmdButtonText(ButtonBase btn) => btn == null ? string.Empty : btn.Text;

        private WizardPage GetNextPage(WizardPage page)
        {
            if (page == null || page.IsFinishPage)
                return null;

            do
            {
                var pgIdx = Pages.IndexOf(page);
                if (page.NextPage != null)
                    page = page.NextPage;
                else if (pgIdx == Pages.Count - 1)
                    page = null;
                else
                    page = Pages[pgIdx + 1];
            } while (page != null && page.Suppress);

            return page;
        }

        private void InitialSetup()
        {
            if (initialized) return;
            pageHistory.Clear();
            selectedPage = null;
            var firstPage = Pages.Find(p => !p.Suppress);
            if (firstPage != null) SelectedPage = firstPage;
            if (selectedPage == null)
                UpdateUIDependencies();
            if (showProgressInTaskbarIcon)
            {
                progressTimer = new Timer() { Interval = 1000, Enabled = true };
                progressTimer.Tick += progressTimer_Tick;
            }
            initialized = true;
        }

        private bool IsLastPage(WizardPage page) => GetNextPage(page) == null;

        private void nextButton_Click(object sender, EventArgs e)
        {
            NextPage();
        }

        private void Pages_AddItem(object sender, EventedList<WizardPage>.ListChangedEventArgs<WizardPage> e)
        {
            Pages_AddItemHandler(e.Item, !initializing);
        }

        private void Pages_AddItemHandler(WizardPage item, bool selectAfterAdd)
        {
            System.Diagnostics.Debug.WriteLine($"AddPage: {(item == null ? "null" : item.Text)},sel={selectAfterAdd}");
            item.Owner = this;
            item.Visible = false;
            if (!Contains(item))
                Controls.Add(item);
            if (selectAfterAdd)
                SelectedPage = item;
        }

        private void Pages_RemoveItem(object sender, EventedList<WizardPage>.ListChangedEventArgs<WizardPage> e)
        {
            Controls.Remove(e.Item);
            if (e.Item == selectedPage && Pages.Count > 0)
                SelectedPage = Pages[e.ItemIndex == Pages.Count ? e.ItemIndex - 1 : e.ItemIndex];
            else
                UpdateUIDependencies();
        }

        private void Pages_Reset(object sender, EventedList<WizardPage>.ListChangedEventArgs<WizardPage> e)
        {
            var curPage = selectedPage;
            SelectedPage = null;
            Controls.Clear();
            foreach (var item in Pages)
                Pages_AddItemHandler(item, false);
            if (Pages.Count > 0)
                SelectedPage = Pages.Contains(curPage) ? curPage : Pages[0];
        }

        private void progressTimer_Tick(object sender, EventArgs e)
        {
            if (ParentForm == null || !ParentForm.Visible) return;
            progressTimer.Enabled = false;
            progressTimer = null;
            UpdateTaskbarProgress();
        }

        private void UpdateTaskbarProgress()
        {
            if (showProgressInTaskbarIcon && selectedPage != null && Pages.Count > 0 && !this.IsDesignMode() && ParentForm != null && ParentForm.ShowInTaskbar)
                TaskBar.SetProgressValue(ParentForm.Handle, Convert.ToUInt64(PercentComplete), 100ul);
        }

        internal void ResetBackButtonText()
        {
            BackButtonText = Properties.Resources.WizardBackText;
        }

        internal void ResetCancelButtonText()
        {
            CancelButtonText = Properties.Resources.WizardCancelText;
        }

        internal void ResetFinishButtonText()
        {
            FinishButtonText = Properties.Resources.WizardFinishText;
        }

        internal void ResetNextButtonText()
        {
            NextButtonText = Properties.Resources.WizardNextText;
        }

        private void SetCmdButtonState(ButtonBase btn, WizardCommandButtonState value)
        {
            if (btn == null)
                return;

            var prevVal = GetCmdButtonState(btn);
            switch (value)
            {
                case WizardCommandButtonState.Disabled:
                    btn.Enabled = false;
                    btn.Visible = true;
                    break;
                case WizardCommandButtonState.Hidden:
                    btn.Enabled = false;
                    if (btn != BackButton)
                        btn.Visible = false;
                    break;
                case WizardCommandButtonState.Enabled:
                    btn.Enabled = true;
                    btn.Visible = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }

            if (prevVal != value)
            {
                btn.Tag = value;
                ButtonStateChanged?.Invoke(btn, EventArgs.Empty);
            }

            Invalidate();
        }

        private void SetCmdButtonText(ButtonBase btn, string text)
        {
            if (btn == null) return;
            btn.Text = text;
            Invalidate();
        }

        internal bool ShouldSerializeBackButtonText() => BackButtonText != Properties.Resources.WizardBackText;

        internal bool ShouldSerializeCancelButtonText() => CancelButtonText != Properties.Resources.WizardCancelText;

        internal bool ShouldSerializeFinishButtonText() => FinishButtonText != Properties.Resources.WizardFinishText;

        internal bool ShouldSerializeNextButtonText() => NextButtonText != Properties.Resources.WizardNextText;
    }
}