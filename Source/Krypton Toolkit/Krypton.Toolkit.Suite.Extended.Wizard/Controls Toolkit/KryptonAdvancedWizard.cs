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
    /// <summary>
    /// AdvancedWizard is a wizard control for the .Net platform
    /// </summary>
    [DefaultProperty("Pages")]
    [DefaultEvent("Finish")]
    [ToolboxBitmap(typeof(Bitmap))]
    [Designer(typeof(AdvancedWizardDesigner))]
    public partial class KryptonAdvancedWizard : UserControl, IMessageFilter
    {
        public KryptonAdvancedWizard()
        {
            InitializeComponent();
            WizardPages = new KryptonAdvancedWizardPageCollection();
            _wizardStrategy = WizardStrategy.CreateWizard(DesignMode, this);

            Dock = DockStyle.Fill;
        }

        /// <summary>
        /// IMessageFilter implementation
        /// </summary>
        public bool PreFilterMessage(ref Message msg)
        {
            switch (msg.Msg)
            {
                case WmKeydown:
                    if (!DesignMode && ProcessKeys)
                    {
                        switch ((int)msg.WParam)
                        {
                            case VkEscape:
                                _wizardStrategy.Cancel();
                                break;

                            case VkReturn:
                                if (OnLastPage())
                                    _wizardStrategy.Finish();
                                else if (NextButtonEnabled)
                                    _wizardStrategy.Next(null);
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }
            return false;
        }

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
                    case ButtonLayoutKind.DEFAULT:
                        kpnlButtons.SuspendLayout();
                        try
                        {
                            SetButtonLocationsForDefaultLayout();
                            SetTabOrderForDefaultLayout();
                            ShowAllButtons();
                        }
                        finally
                        {
                            kpnlButtons.ResumeLayout();
                        }
                        break;

                    case ButtonLayoutKind.OFFICE97:
                        kpnlButtons.SuspendLayout();
                        try
                        {
                            SetButtonLocationsForOfficeLayout();
                            SetTabOrderForOfficeLayout();
                            ShowAllButtons();
                        }
                        finally
                        {
                            kpnlButtons.ResumeLayout();
                        }
                        break;
                    default:
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
            set => kpnlButtons.Visible = _buttonsVisible = value;
        }

        [Description("Shows or hides the Cancel button")]
        [Category("Wizard")]
        public bool CancelButton
        {
            get => kbtnCancel.Visible;
            set => kbtnCancel.Visible = value;
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

                if (_buttonLayoutKind == ButtonLayoutKind.DEFAULT)
                    ChangeDefaultLayout(_finishButton);
                else
                    ChangeOfficeLayout(_finishButton);
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
                    case ButtonLayoutKind.DEFAULT:
                        switch (_helpButton)
                        {
                            case true:
                                kbtnHelp.Visible = true;
                                kbtnHelp.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
                                break;

                            case false:
                                kbtnHelp.Visible = false;
                                kbtnHelp.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
                                break;
                        }
                        break;

                    case ButtonLayoutKind.OFFICE97:
                        switch (_helpButton)
                        {
                            case true:
                                kbtnHelp.Visible = true;
                                kbtnHelp.Left = kpnlButtons.Width - kbtnHelp.Width - 12;
                                kbtnHelp.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                                kbtnCancel.Left = kbtnHelp.Left - kbtnCancel.Width - 5;
                                kbtnFinish.Left = kbtnCancel.Left - kbtnFinish.Width - 5;
                                kbtnNext.Left = kbtnFinish.Visible ? kbtnFinish.Left - kbtnFinish.Width - 5 : kbtnFinish.Left;
                                kbtnBack.Left = kbtnNext.Left - kbtnNext.Width;
                                break;

                            case false:
                                kbtnHelp.Visible = false;
                                kbtnHelp.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                                kbtnCancel.Left = kpnlButtons.Width - kbtnCancel.Width - 12;
                                kbtnFinish.Left = kbtnCancel.Left - kbtnFinish.Width - 5;
                                kbtnNext.Left = kbtnFinish.Visible ? kbtnFinish.Left - kbtnNext.Width - 5 : kbtnFinish.Left;
                                kbtnBack.Left = kbtnNext.Left - kbtnBack.Width;
                                break;
                        }
                        break;
                }
            }
        }

        [Category("Wizard")]
        [Description("Customise the text of the Cancel button.")]
        [Localizable(true)]
        public string HelpButtonText
        {
            get => kbtnHelp.Text;
            set
            {
                _helpButtonText = value;
                kbtnHelp.Text = value;
            }
        }

        [Category("Wizard")]
        [Description("Customise the text of the Cancel button.")]
        [Localizable(true)]
        public string CancelButtonText
        {
            get => kbtnCancel.Text;
            set
            {
                _cancelButtonText = value;
                kbtnCancel.Text = value;
            }
        }

        [Category("Wizard")]
        [Description("Customise the text of the Finish button.")]
        [Localizable(true)]
        public string FinishButtonText
        {
            get => kbtnFinish.Text;
            set
            {
                _finishButtonText = value;
                kbtnFinish.Text = value;
            }
        }

        [Category("Wizard")]
        [Description("Customise the text of the Back button.")]
        [Localizable(true)]
        public string BackButtonText
        {
            get => kbtnBack.Text;
            set
            {
                _backButtonText = value;
                kbtnBack.Text = value;
            }
        }

        [Category("Wizard")]
        [Description("Customise the text of the Next button.")]
        [Localizable(true)]
        public string NextButtonText
        {
            get => kbtnNext.Text;
            set
            {
                _tempNextText = _nextButtonText;
                _nextButtonText = value;
                kbtnNext.Text = value;
            }
        }

        [Category("Wizard")]
        [Description("Indicates whether the control is enabled.")]
        [Localizable(true)]
        [Browsable(false)]
        public bool BackButtonEnabled
        {
            get => kbtnBack.Enabled;
            set
            {
                kbtnBack.Enabled = value;
                kbtnBack.Invalidate();
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
                kbtnNext.Enabled = NextButtonEnabledState;
                kbtnNext.Invalidate();
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
            get { return _finishButton ? kbtnFinish.Enabled : kbtnNext.Enabled; }
            set
            {
                if (_finishButton)
                {
                    kbtnFinish.Enabled = value;
                }
                else if (_finishButton == false)
                {
                    kbtnNext.Enabled = value;
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
                    NextButtonEnabled = !value;
                else
                    kbtnNext.Text = value ? FinishButtonText : _tempNextText;
            }
        }

        public void GoToPage(int pageIndex) => _wizardStrategy.GoToPage(pageIndex);

        public void GoToPage(KryptonAdvancedWizardPage page) => _wizardStrategy.GoToPage(page);

        public void ClickNext() => _wizardStrategy.Next(_selectionService);

        public void ClickBack() => _wizardStrategy.Back(_selectionService);

        public void ClickFinish() => _wizardStrategy.Finish();

        public void ClickCancel() => _wizardStrategy.Cancel();

        public void ClickHelp() => _wizardStrategy.Help();

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _selectionService = (ISelectionService)GetService(typeof(ISelectionService));
            kpnlButtons.SendToBack();
            _tempNextText = NextButtonText;
            _wizardStrategy.Loading();
            AllowKeyPressesToNavigateWizard();
        }
    }
}
