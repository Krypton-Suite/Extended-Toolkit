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

namespace Krypton.Toolkit.Suite.Extended.Wizard
{
    public partial class KryptonAdvancedWizard
    {
        #region Design Code
        private KryptonPanel _kpnlButtons;
        private KryptonBorderEdge _kryptonBorderEdge1;
        private KryptonButton _kbtnHelp;
        private KryptonButton _kbtnFinish;
        private KryptonButton _kbtnCancel;
        private KryptonButton _kbtnBack;
        private KryptonPanel _kryptonPanel1;
        private KryptonButton _kbtnNext;

        private void InitializeComponent()
        {
            this._kpnlButtons = new Krypton.Toolkit.KryptonPanel();
            this._kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this._kbtnBack = new Krypton.Toolkit.KryptonButton();
            this._kbtnNext = new Krypton.Toolkit.KryptonButton();
            this._kbtnFinish = new Krypton.Toolkit.KryptonButton();
            this._kbtnHelp = new Krypton.Toolkit.KryptonButton();
            this._kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            this._kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            ((System.ComponentModel.ISupportInitialize)(this._kpnlButtons)).BeginInit();
            this._kpnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._kryptonPanel1)).BeginInit();
            this.SuspendLayout();
            // 
            // kpnlButtons
            // 
            this._kpnlButtons.Controls.Add(this._kbtnCancel);
            this._kpnlButtons.Controls.Add(this._kbtnBack);
            this._kpnlButtons.Controls.Add(this._kbtnNext);
            this._kpnlButtons.Controls.Add(this._kbtnFinish);
            this._kpnlButtons.Controls.Add(this._kbtnHelp);
            this._kpnlButtons.Controls.Add(this._kryptonBorderEdge1);
            this._kpnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._kpnlButtons.Location = new System.Drawing.Point(0, 277);
            this._kpnlButtons.Name = "_kpnlButtons";
            this._kpnlButtons.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this._kpnlButtons.Size = new System.Drawing.Size(557, 50);
            this._kpnlButtons.TabIndex = 0;
            // 
            // kbtnCancel
            // 
            this._kbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._kbtnCancel.Location = new System.Drawing.Point(167, 9);
            this._kbtnCancel.Name = "_kbtnCancel";
            this._kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this._kbtnCancel.TabIndex = 0;
            this._kbtnCancel.Values.Text = "&Cancel";
            this._kbtnCancel.Click += KbtnCancelClick;
            // 
            // kbtnBack
            // 
            this._kbtnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._kbtnBack.Location = new System.Drawing.Point(263, 9);
            this._kbtnBack.Name = "_kbtnBack";
            this._kbtnBack.Size = new System.Drawing.Size(90, 25);
            this._kbtnBack.TabIndex = 0;
            this._kbtnBack.Values.Text = "< &Back";
            this._kbtnBack.Click += KbtnBackClick;
            // 
            // kbtnNext
            // 
            this._kbtnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._kbtnNext.Location = new System.Drawing.Point(359, 9);
            this._kbtnNext.Name = "_kbtnNext";
            this._kbtnNext.Size = new System.Drawing.Size(90, 25);
            this._kbtnNext.TabIndex = 0;
            this._kbtnNext.Values.Text = "N&ext >";
            this._kbtnNext.Click += KbtnNextClick;
            // 
            // kbtnFinish
            // 
            this._kbtnFinish.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._kbtnFinish.Location = new System.Drawing.Point(455, 9);
            this._kbtnFinish.Name = "_kbtnFinish";
            this._kbtnFinish.Size = new System.Drawing.Size(90, 25);
            this._kbtnFinish.TabIndex = 0;
            this._kbtnFinish.Values.Text = "Fi&nish";
            this._kbtnFinish.Click += KbtnFinishClick;
            // 
            // kbtnHelp
            // 
            this._kbtnHelp.Location = new System.Drawing.Point(11, 9);
            this._kbtnHelp.Name = "_kbtnHelp";
            this._kbtnHelp.Size = new System.Drawing.Size(90, 25);
            this._kbtnHelp.TabIndex = 1;
            this._kbtnHelp.Values.Text = "H&elp";
            this._kbtnHelp.Click += KbtnHelpClick;
            // 
            // kryptonBorderEdge1
            // 
            this._kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderSecondary;
            this._kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this._kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this._kryptonBorderEdge1.Name = "_kryptonBorderEdge1";
            this._kryptonBorderEdge1.Size = new System.Drawing.Size(557, 1);
            this._kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // kryptonPanel1
            // 
            this._kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this._kryptonPanel1.Name = "_kryptonPanel1";
            this._kryptonPanel1.Size = new System.Drawing.Size(557, 277);
            this._kryptonPanel1.TabIndex = 1;
            // 
            // KryptonAdvancedWizard
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this._kryptonPanel1);
            this.Controls.Add(this._kpnlButtons);
            this.Name = "KryptonAdvancedWizard";
            this.Size = new System.Drawing.Size(557, 327);
            ((System.ComponentModel.ISupportInitialize)(this._kpnlButtons)).EndInit();
            this._kpnlButtons.ResumeLayout(false);
            this._kpnlButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._kryptonPanel1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private void AllowKeyPressesToNavigateWizard() => Application.AddMessageFilter(this);

        private void SetButtonLocationsForOfficeLayout()
        {
            _kbtnHelp.Left = _kpnlButtons.Width - _kbtnHelp.Width - 12;
            _kbtnCancel.Left = _kbtnHelp.Left - _kbtnCancel.Width - 5;
            _kbtnFinish.Left = _kbtnCancel.Left - _kbtnFinish.Width - 5;
            _kbtnNext.Left = _finishButton ? _kbtnFinish.Left - _kbtnNext.Width - 5 : _kbtnFinish.Left;
            _kbtnBack.Left = _kbtnNext.Left - _kbtnBack.Width;
        }

        private void SetTabOrderForOfficeLayout()
        {
            // set the tab orders
            _kbtnHelp.TabIndex = 4;
            _kbtnCancel.TabIndex = 3;
            _kbtnBack.TabIndex = 0;
            _kbtnNext.TabIndex = 1;
            _kbtnFinish.TabIndex = 2;
        }

        private void ChangeOfficeLayout(bool hasFinishButton)
        {
            if (hasFinishButton)
            {
                _kbtnFinish.Visible = true;
                _kbtnCancel.Left = _kbtnHelp.Visible ? _kbtnHelp.Left - _kbtnCancel.Width - 5 : _kbtnHelp.Left;
                _kbtnNext.Left = _kbtnFinish.Left - _kbtnFinish.Width - 5;
                _kbtnBack.Left = _kbtnNext.Left - _kbtnNext.Width;
                _kbtnNext.Text = _nextButtonText;
            }
            else
            {
                _kbtnFinish.Visible = false;
                _kbtnCancel.Left = _kbtnHelp.Visible ? _kbtnHelp.Left - _kbtnCancel.Width - 5 : _kbtnHelp.Left;
                _kbtnNext.Left = _kbtnFinish.Left;
                _kbtnBack.Left = _kbtnNext.Left - _kbtnNext.Width;
                _kbtnNext.Text = IndexOfCurrentPage() == WizardPages.Count - 1 ? _finishButtonText : _nextButtonText;
            }
        }

        private void SetButtonLocationsForDefaultLayout()
        {
            _kbtnFinish.Left = _kpnlButtons.Width - _kbtnFinish.Width - 12;
            _kbtnNext.Left = _kbtnFinish.Left - _kbtnNext.Width - 5;
            _kbtnBack.Left = _kbtnNext.Left - _kbtnBack.Width - 5;
            _kbtnCancel.Left = _kbtnBack.Left - _kbtnCancel.Width - 5;
            _kbtnHelp.Left = 12;
        }

        private void SetTabOrderForDefaultLayout()
        {
            // set the tab orders
            _kbtnHelp.TabIndex = 0;
            _kbtnCancel.TabIndex = 1;
            _kbtnBack.TabIndex = 2;
            _kbtnNext.TabIndex = 3;
            _kbtnFinish.TabIndex = 4;
        }

        private void ChangeDefaultLayout(bool hasFinishButton)
        {
            if (hasFinishButton)
            {
                _kbtnFinish.Visible = true;
                _kbtnNext.Left = _kbtnFinish.Left - _kbtnFinish.Width - 5;
                _kbtnBack.Left = _kbtnNext.Left - _kbtnNext.Width;
                _kbtnCancel.Left = _kbtnBack.Left - _kbtnBack.Width - 5;
                _kbtnNext.Text = _nextButtonText;
            }
            else
            {
                _kbtnFinish.Visible = false;
                _kbtnNext.Left = _kbtnFinish.Left;
                _kbtnBack.Left = _kbtnNext.Left - _kbtnNext.Width;
                _kbtnCancel.Left = _kbtnBack.Left - _kbtnBack.Width - 5;
                _kbtnNext.Text = IndexOfCurrentPage() == WizardPages.Count - 1 ? _finishButtonText : _nextButtonText;
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
                _kpnlButtons.Height = 60;

                _kbtnHelp.Height = 46;
                _kbtnCancel.Height = 46;
                _kbtnBack.Height = 46;
                _kbtnNext.Height = 46;
                _kbtnFinish.Height = 46;
            }
            else
            {
                _kpnlButtons.Height = 40;
                _kbtnHelp.Height = 23;
                _kbtnCancel.Height = 23;
                _kbtnBack.Height = 23;
                _kbtnNext.Height = 23;
                _kbtnFinish.Height = 23;
            }

            _kbtnHelp.Top = 8;
            _kbtnCancel.Top = 8;
            _kbtnBack.Top = 8;
            _kbtnNext.Top = 8;
            _kbtnFinish.Top = 8;
        }

        private const int VK_ESCAPE = 27;
        private const int VK_RETURN = 13;
        private const int WM_KEYDOWN = 0x0100;

        private bool _finishButton = true;
        private bool _helpButton = true;
        private KryptonAdvancedWizardPage? _lastPage;

        internal bool NextButtonEnabledState;
        private bool _pageSetAsFinishPage;
        private int _selectedPage;
        private ISelectionService? _selectionService;
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