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
    public partial class KryptonAdvancedWizard
    {
        #region Design Code
        private KryptonPanel kpnlButtons;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonButton kbtnHelp;
        private KryptonButton kbtnFinish;
        private KryptonButton kbtnCancel;
        private KryptonButton kbtnBack;
        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnNext;

        private void InitializeComponent()
        {
            this.kpnlButtons = new Krypton.Toolkit.KryptonPanel();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.kbtnBack = new Krypton.Toolkit.KryptonButton();
            this.kbtnNext = new Krypton.Toolkit.KryptonButton();
            this.kbtnFinish = new Krypton.Toolkit.KryptonButton();
            this.kbtnHelp = new Krypton.Toolkit.KryptonButton();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlButtons)).BeginInit();
            this.kpnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.SuspendLayout();
            // 
            // kpnlButtons
            // 
            this.kpnlButtons.Controls.Add(this.kbtnCancel);
            this.kpnlButtons.Controls.Add(this.kbtnBack);
            this.kpnlButtons.Controls.Add(this.kbtnNext);
            this.kpnlButtons.Controls.Add(this.kbtnFinish);
            this.kpnlButtons.Controls.Add(this.kbtnHelp);
            this.kpnlButtons.Controls.Add(this.kryptonBorderEdge1);
            this.kpnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kpnlButtons.Location = new System.Drawing.Point(0, 277);
            this.kpnlButtons.Name = "kpnlButtons";
            this.kpnlButtons.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kpnlButtons.Size = new System.Drawing.Size(557, 50);
            this.kpnlButtons.TabIndex = 0;
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnCancel.Location = new System.Drawing.Point(167, 9);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 0;
            this.kbtnCancel.Values.Text = "&Cancel";
            this.kbtnCancel.Click += KbtnCancelClick;
            // 
            // kbtnBack
            // 
            this.kbtnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnBack.Location = new System.Drawing.Point(263, 9);
            this.kbtnBack.Name = "kbtnBack";
            this.kbtnBack.Size = new System.Drawing.Size(90, 25);
            this.kbtnBack.TabIndex = 0;
            this.kbtnBack.Values.Text = "< &Back";
            this.kbtnBack.Click += KbtnBackClick;
            // 
            // kbtnNext
            // 
            this.kbtnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnNext.Location = new System.Drawing.Point(359, 9);
            this.kbtnNext.Name = "kbtnNext";
            this.kbtnNext.Size = new System.Drawing.Size(90, 25);
            this.kbtnNext.TabIndex = 0;
            this.kbtnNext.Values.Text = "N&ext >";
            this.kbtnNext.Click += KbtnNextClick;
            // 
            // kbtnFinish
            // 
            this.kbtnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnFinish.Location = new System.Drawing.Point(455, 9);
            this.kbtnFinish.Name = "kbtnFinish";
            this.kbtnFinish.Size = new System.Drawing.Size(90, 25);
            this.kbtnFinish.TabIndex = 0;
            this.kbtnFinish.Values.Text = "Fi&nish";
            this.kbtnFinish.Click += KbtnFinishClick;
            // 
            // kbtnHelp
            // 
            this.kbtnHelp.Location = new System.Drawing.Point(11, 9);
            this.kbtnHelp.Name = "kbtnHelp";
            this.kbtnHelp.Size = new System.Drawing.Size(90, 25);
            this.kbtnHelp.TabIndex = 1;
            this.kbtnHelp.Values.Text = "H&elp";
            this.kbtnHelp.Click += KbtnHelpClick;
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderSecondary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(557, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(557, 277);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // KryptonAdvancedWizard
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.kpnlButtons);
            this.Name = "KryptonAdvancedWizard";
            this.Size = new System.Drawing.Size(557, 327);
            ((System.ComponentModel.ISupportInitialize)(this.kpnlButtons)).EndInit();
            this.kpnlButtons.ResumeLayout(false);
            this.kpnlButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private void AllowKeyPressesToNavigateWizard() => Application.AddMessageFilter(this);

        private void SetButtonLocationsForOfficeLayout()
        {
            kbtnHelp.Left = kpnlButtons.Width - kbtnHelp.Width - 12;
            kbtnCancel.Left = kbtnHelp.Left - kbtnCancel.Width - 5;
            kbtnFinish.Left = kbtnCancel.Left - kbtnFinish.Width - 5;
            kbtnNext.Left = _finishButton ? kbtnFinish.Left - kbtnNext.Width - 5 : kbtnFinish.Left;
            kbtnBack.Left = kbtnNext.Left - kbtnBack.Width;
        }

        private void SetTabOrderForOfficeLayout()
        {
            // set the tab orders
            kbtnHelp.TabIndex = 4;
            kbtnCancel.TabIndex = 3;
            kbtnBack.TabIndex = 0;
            kbtnNext.TabIndex = 1;
            kbtnFinish.TabIndex = 2;
        }

        private void ChangeOfficeLayout(bool hasFinishButton)
        {
            if (hasFinishButton)
            {
                kbtnFinish.Visible = true;
                kbtnCancel.Left = kbtnHelp.Visible ? kbtnHelp.Left - kbtnCancel.Width - 5 : kbtnHelp.Left;
                kbtnNext.Left = kbtnFinish.Left - kbtnFinish.Width - 5;
                kbtnBack.Left = kbtnNext.Left - kbtnNext.Width;
                kbtnNext.Text = _nextButtonText;
            }
            else
            {
                kbtnFinish.Visible = false;
                kbtnCancel.Left = kbtnHelp.Visible ? kbtnHelp.Left - kbtnCancel.Width - 5 : kbtnHelp.Left;
                kbtnNext.Left = kbtnFinish.Left;
                kbtnBack.Left = kbtnNext.Left - kbtnNext.Width;
                kbtnNext.Text = IndexOfCurrentPage() == WizardPages.Count - 1 ? _finishButtonText : _nextButtonText;
            }
        }

        private void SetButtonLocationsForDefaultLayout()
        {
            kbtnFinish.Left = kpnlButtons.Width - kbtnFinish.Width - 12;
            kbtnNext.Left = kbtnFinish.Left - kbtnNext.Width - 5;
            kbtnBack.Left = kbtnNext.Left - kbtnBack.Width - 5;
            kbtnCancel.Left = kbtnBack.Left - kbtnCancel.Width - 5;
            kbtnHelp.Left = 12;
        }

        private void SetTabOrderForDefaultLayout()
        {
            // set the tab orders
            kbtnHelp.TabIndex = 0;
            kbtnCancel.TabIndex = 1;
            kbtnBack.TabIndex = 2;
            kbtnNext.TabIndex = 3;
            kbtnFinish.TabIndex = 4;
        }

        private void ChangeDefaultLayout(bool hasFinishButton)
        {
            if (hasFinishButton)
            {
                kbtnFinish.Visible = true;
                kbtnNext.Left = kbtnFinish.Left - kbtnFinish.Width - 5;
                kbtnBack.Left = kbtnNext.Left - kbtnNext.Width;
                kbtnCancel.Left = kbtnBack.Left - kbtnBack.Width - 5;
                kbtnNext.Text = _nextButtonText;
            }
            else
            {
                kbtnFinish.Visible = false;
                kbtnNext.Left = kbtnFinish.Left;
                kbtnBack.Left = kbtnNext.Left - kbtnNext.Width;
                kbtnCancel.Left = kbtnBack.Left - kbtnBack.Width - 5;
                kbtnNext.Text = IndexOfCurrentPage() == WizardPages.Count - 1 ? _finishButtonText : _nextButtonText;
            }
        }

        private void ShowAllButtons()
        {
            FinishButton = true;
            HelpButton = true;
            CancelButton = true;
        }

        private void ProcessTouchScreenValue(bool val)
        {
            _touchScreen = val;

            if (val)
            {
                kpnlButtons.Height = 60;

                kbtnHelp.Height = 46;
                kbtnCancel.Height = 46;
                kbtnBack.Height = 46;
                kbtnNext.Height = 46;
                kbtnFinish.Height = 46;
            }
            else
            {
                kpnlButtons.Height = 40;
                kbtnHelp.Height = 23;
                kbtnCancel.Height = 23;
                kbtnBack.Height = 23;
                kbtnNext.Height = 23;
                kbtnFinish.Height = 23;
            }

            kbtnHelp.Top = 8;
            kbtnCancel.Top = 8;
            kbtnBack.Top = 8;
            kbtnNext.Top = 8;
            kbtnFinish.Top = 8;
        }

        private const int VkEscape = 27;
        private const int VkReturn = 13;
        private const int WmKeydown = 0x0100;

        private bool _finishButton = true;
        private bool _helpButton = true;
        private KryptonAdvancedWizardPage _lastPage;

        internal bool NextButtonEnabledState;
        private bool _pageSetAsFinishPage;
        private int _selectedPage;
        private ISelectionService _selectionService;
        private readonly WizardStrategy _wizardStrategy;

        private string _backButtonText = "< Back";
        private ButtonLayoutKind _buttonLayoutKind;
        private bool _buttonsVisible = true;
        private string _cancelButtonText = "&Cancel";
        private string _finishButtonText = "&Finish";
        private string _helpButtonText = "&Help";
        private string _nextButtonText = "Next >";
        private string _tempNextText = "Next >";
        private bool _touchScreen;
    }
}