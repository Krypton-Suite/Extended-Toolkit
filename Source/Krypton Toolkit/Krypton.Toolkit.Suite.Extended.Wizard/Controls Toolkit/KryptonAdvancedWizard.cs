#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
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
 * Base code by Steve Bate 2003 - 2017 (https://github.com/SteveBate/AdvancedWizard), modifications by Peter Wagner (aka Wagnerp) 2021 - 2023.
 *
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Wizard.Properties;

namespace Krypton.Toolkit.Suite.Extended.Wizard
{
    /// <summary>
    /// AdvancedWizard is a wizard control for the .Net platform
    /// </summary>
    [DefaultProperty("Pages")]
    [DefaultEvent("Finish")]
    [ToolboxBitmap(typeof(Bitmap))]
    [Designer(typeof(AdvancedWizardDesigner))]
    public partial class KryptonAdvancedWizard : UserControl, IMessageFilter
    {
        #region Instance Fields

        private Bitmap? _wizardImage;

        #endregion

        #region Identity

        public KryptonAdvancedWizard()
        {
            InitializeComponent();
            WizardPages = new KryptonAdvancedWizardPageCollection();
            _wizardStrategy = WizardStrategy.CreateWizard(DesignMode, this);

            _wizardImage = Resources.Installer48;

            Dock = DockStyle.Fill;
        }

        #endregion

        #region Events

        [Category("WizardAction")]
        [Description("Fires when the Cancel button is clicked.")]
        public event EventHandler Cancel = delegate { };

        [Category("WizardAction")]
        [Description("Fires when the Next button is clicked.")]
        public event EventHandler<WizardEventArgs> Next = delegate { };

        [Category("WizardAction")]
        [Description("Fires when the Back button is clicked.")]
        public event EventHandler<WizardEventArgs> Back = delegate { };

        [Category("WizardAction")]
        [Description("Fires when the Finish button is clicked.")]
        public event EventHandler Finish = delegate { };

        [Category("WizardAction")]
        [Description("Fires when the Help button is clicked.")]
        public event EventHandler Help = delegate { };

        [Category("WizardAction")]
        [Description("Fires when the page changes.")]
        public event EventHandler<WizardPageChangedEventArgs> PageChanged = delegate { };

        [Category("WizardAction")]
        [Description("Fires when the last page is reached.")]
        public event EventHandler LastPage = delegate { };

        #endregion

        #region Public

        [Category("Wizard")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Description("Add pages to the wizard.")]
        [Editor(typeof(KryptonAdvancedWizardCollectionEditor), typeof(UITypeEditor))]
        public KryptonAdvancedWizardPageCollection WizardPages { get; }

        [Browsable(false)]
        public KryptonAdvancedWizardPage CurrentPage => WizardPages[_selectedPage];

        [Category("Wizard")]
        [Description("Allows user to control the wizard through the Escape and Enter keys.")]
        public bool ProcessKeys { get; set; }


        [Category("Wizard")]
        [Description("Alters the layout of the buttons.")]
        [RefreshProperties(RefreshProperties.Repaint)]
        public ButtonLayoutKind ButtonLayout
        {
            get => _buttonLayoutKind;
            set
            {
                _buttonLayoutKind = value;
                switch (value)
                {
                    case ButtonLayoutKind.Default:
                        _kpnlButtons.SuspendLayout();
                        try
                        {
                            SetButtonLocationsForDefaultLayout();
                            SetTabOrderForDefaultLayout();
                            ShowAllButtons();
                        }
                        finally
                        {
                            _kpnlButtons.ResumeLayout();
                        }
                        break;

                    case ButtonLayoutKind.Office97:
                        _kpnlButtons.SuspendLayout();
                        try
                        {
                            SetButtonLocationsForOfficeLayout();
                            SetTabOrderForOfficeLayout();
                            ShowAllButtons();
                        }
                        finally
                        {
                            _kpnlButtons.ResumeLayout();
                        }
                        break;
                }
            }
        }

        [Category("Wizard")]
        [Browsable(true)]
        [Description("Show or hide the buttons. You can still access the pages programmatically if you hide them.")]
        public bool ButtonsVisible
        {
            get => _buttonsVisible;
            set => _kpnlButtons.Visible = _buttonsVisible = value;
        }

        [Description("Shows or hides the Cancel button")]
        [Category("Wizard")]
        public bool CancelButton
        {
            get => _kbtnCancel.Visible;
            set => _kbtnCancel.Visible = value;
        }

        [Category("Wizard")]
        [Browsable(true)]
        [Description("Increase the button size for easier use on a touchscreen")]
        public bool TouchScreen
        {
            get => _touchScreen;
            set => ProcessTouchScreenValue(value);
        }

        /// <summary>
        /// This property determines the layout of navigation buttons.
        /// True means an explicit Finish button is present whereas False
        /// means the Next button wil become a Finish button on the last
        /// page of the wizard.
        /// </summary>
        [Category("Wizard")]
        [Description("Allows a choice of a dedicated button to complete the wizard steps or to use the Next button.")]
        public bool FinishButton
        {
            get => _finishButton;
            set
            {
                _finishButton = value;

                if (_buttonLayoutKind == ButtonLayoutKind.Default)
                {
                    ChangeDefaultLayout(_finishButton);
                }
                else
                {
                    ChangeOfficeLayout(_finishButton);
                }
            }
        }

        [Category("Wizard")]
        [Description("Allows a choice of a dedicated button to complete the wizard steps or to use the Next button.")]
        public bool HelpButton
        {
            get => _helpButton;
            set
            {
                _helpButton = value;
                switch (_buttonLayoutKind)
                {
                    case ButtonLayoutKind.Default:
                        switch (_helpButton)
                        {
                            case true:
                                _kbtnHelp.Visible = true;
                                _kbtnHelp.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
                                break;

                            case false:
                                _kbtnHelp.Visible = false;
                                _kbtnHelp.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
                                break;
                        }
                        break;

                    case ButtonLayoutKind.Office97:
                        switch (_helpButton)
                        {
                            case true:
                                _kbtnHelp.Visible = true;
                                _kbtnHelp.Left = _kpnlButtons.Width - _kbtnHelp.Width - 12;
                                _kbtnHelp.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                                _kbtnCancel.Left = _kbtnHelp.Left - _kbtnCancel.Width - 5;
                                _kbtnFinish.Left = _kbtnCancel.Left - _kbtnFinish.Width - 5;
                                _kbtnNext.Left = _kbtnFinish.Visible ? _kbtnFinish.Left - _kbtnFinish.Width - 5 : _kbtnFinish.Left;
                                _kbtnBack.Left = _kbtnNext.Left - _kbtnNext.Width;
                                break;

                            case false:
                                _kbtnHelp.Visible = false;
                                _kbtnHelp.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                                _kbtnCancel.Left = _kpnlButtons.Width - _kbtnCancel.Width - 12;
                                _kbtnFinish.Left = _kbtnCancel.Left - _kbtnFinish.Width - 5;
                                _kbtnNext.Left = _kbtnFinish.Visible ? _kbtnFinish.Left - _kbtnNext.Width - 5 : _kbtnFinish.Left;
                                _kbtnBack.Left = _kbtnNext.Left - _kbtnBack.Width;
                                break;
                        }
                        break;
                }
            }
        }

        [Category("Wizard")]
        [Description("Customise the text of the Cancel button.")]
        [Localizable(true)]
        [DefaultValue(typeof(string), "KryptonManager.Strings.Help")]
        public string HelpButtonText
        {
            get => _kbtnHelp.Text;
            set
            {
                _helpButtonText = value;
                _kbtnHelp.Text = value;
            }
        }

        [Category("Wizard")]
        [Description("Customise the text of the Cancel button.")]
        [Localizable(true)]
        [DefaultValue(typeof(string), "KryptonManager.Strings.Cancel")]
        public string CancelButtonText
        {
            get => _kbtnCancel.Text;
            set
            {
                _cancelButtonText = value;
                _kbtnCancel.Text = value;
            }
        }

        [Category("Wizard")]
        [Description("Customise the text of the Finish button.")]
        [Localizable(true)]
        [DefaultValue(typeof(string), "KryptonManager.Strings.Finish")]
        public string FinishButtonText
        {
            get => _kbtnFinish.Text;
            set
            {
                _finishButtonText = value;
                _kbtnFinish.Text = value;
            }
        }

        [Category("Wizard")]
        [Description("Customise the text of the Back button.")]
        [Localizable(true)]
        [DefaultValue(typeof(string), "KryptonManager.Strings.Back")]
        public string BackButtonText
        {
            get => _kbtnBack.Text;
            set
            {
                _backButtonText = value;
                _kbtnBack.Text = value;
            }
        }

        [Category("Wizard")]
        [Description("Customise the text of the Next button.")]
        [Localizable(true)]
        [DefaultValue(typeof(string), "KryptonManager.Strings.Next")]
        public string NextButtonText
        {
            get => _kbtnNext.Text;
            set
            {
                _tempNextText = _nextButtonText;
                _nextButtonText = value;
                _kbtnNext.Text = value;
            }
        }

        [Category("Wizard")]
        [Description("Indicates whether the control is enabled.")]
        [Localizable(true)]
        [Browsable(false)]
        public bool BackButtonEnabled
        {
            get => _kbtnBack.Enabled;
            set
            {
                _kbtnBack.Enabled = value;
                _kbtnBack.Invalidate();
            }
        }

        [Category("Wizard")]
        [Description("Indicates whether the control is enabled.")]
        [Localizable(true)]
        [Browsable(false)]
        public bool NextButtonEnabled
        {
            get => NextButtonEnabledState;
            set
            {
                NextButtonEnabledState = value;
                _kbtnNext.Enabled = NextButtonEnabledState;
                _kbtnNext.Invalidate();
            }
        }

        // When FinishButton is set to false the NextButton "becomes" the Finish button
        // To enable or disable this button you had to call NextButtonEnabled even though
        // to the application developer it looked like the actual finish button. Therefore,
        // it makes more sense to call FinishButtonEnabled. This changed works with the
        // appropriate button depending on the value of the FinishButton property
        [Category("Wizard")]
        [Description("Indicates whether the control is enabled.")]
        [Localizable(true)]
        [Browsable(false)]
        public bool FinishButtonEnabled
        {
            get => _finishButton ? _kbtnFinish.Enabled : _kbtnNext.Enabled;
            set
            {
                if (_finishButton)
                {
                    _kbtnFinish.Enabled = value;
                }
                else if (_finishButton == false)
                {
                    _kbtnNext.Enabled = value;
                    NextButtonEnabledState = value;
                }
            }
        }

        [Browsable(false)]
        public bool CurrentPageIsFinishPage
        {
            get => _pageSetAsFinishPage && _lastPage == CurrentPage;
            set
            {
                _pageSetAsFinishPage = value;
                _lastPage = value ? CurrentPage : null;
                if (HasExplicitFinishButton())
                {
                    NextButtonEnabled = !value;
                }
                else
                {
                    _kbtnNext.Text = value ? FinishButtonText : _tempNextText;
                }
            }
        }

        public Bitmap? WizardHeaderImage
        {
            get => _wizardImage ?? Resources.Installer48;

            set
            {
                if (_wizardImage != null)
                {
                    _wizardImage = value;

                    Invalidate();
                }
            }
        }

        #endregion

        #region Implementation

        /// <summary>
        /// IMessageFilter implementation
        /// </summary>
        public bool PreFilterMessage(ref Message msg)
        {
            switch (msg.Msg)
            {
                case WM_KEYDOWN:
                    if (!DesignMode && ProcessKeys)
                    {
                        switch ((int)msg.WParam)
                        {
                            case VK_ESCAPE:
                                _wizardStrategy.Cancel();
                                break;

                            case VK_RETURN:
                                if (OnLastPage())
                                {
                                    _wizardStrategy.Finish();
                                }
                                else if (NextButtonEnabled)
                                {
                                    _wizardStrategy.Next(null);
                                }

                                break;
                        }
                    }
                    break;
            }
            return false;
        }
        public void GoToPage(int pageIndex) => _wizardStrategy.GoToPage(pageIndex);

        public void GoToPage(KryptonAdvancedWizardPage page) => _wizardStrategy.GoToPage(page);

        public void ClickNext() => _wizardStrategy.Next(_selectionService);

        public void ClickBack() => _wizardStrategy.Back(_selectionService);

        public void ClickFinish() => _wizardStrategy.Finish();

        public void ClickCancel() => _wizardStrategy.Cancel();

        public void ClickHelp() => _wizardStrategy.Help();

        #endregion

        #region Protected

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _selectionService = GetService(typeof(ISelectionService)) as ISelectionService;
            _kpnlButtons.SendToBack();
            _tempNextText = NextButtonText;
            _wizardStrategy.Loading();
            AllowKeyPressesToNavigateWizard();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            foreach (KryptonAdvancedWizardPage page in WizardPages)
            {
                page.HeaderImage = _wizardImage ?? Resources.Installer48;
            }

            base.OnPaint(e);
        }

        #endregion
    }
}
