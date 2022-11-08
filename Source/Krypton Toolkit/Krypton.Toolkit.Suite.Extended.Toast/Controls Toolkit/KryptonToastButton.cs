namespace Krypton.Toolkit.Suite.Extended.Toast
{
    [ToolboxItem(false)]
    public class KryptonToastButton : KryptonButton
    {
        #region Instance Fields

        private ActionType _actionType;

        private bool _useAcceptDenyColours, _isAcceptButton, _isDenyButton, _openInExplorer;

        private Color _acceptButtonBackColour1,
                      _acceptButtonBackColour2,
                      _denyButtonBackColour1,
                      _denyButtonBackColour2,
                      _acceptButtonTextColour1,
                      _acceptButtonTextColour2,
                      _denyButtonTextColour1,
                      _denyButtonTextColour2;

        private object _optionalParameters;

        private string _processNane;

        #endregion

        #region Public

        [DefaultValue(typeof(ActionType), @"ActionType.Default")]
        public ActionType ActionType { get => _actionType; set { _actionType = value; Invalidate(); } }

        [DefaultValue(false)]
        public bool UseAcceptDenyColours { get => _useAcceptDenyColours; set { _useAcceptDenyColours = value; Invalidate(); } }

        [DefaultValue(false)]
        public bool IsAcceptButton { get => _isAcceptButton; set => _isAcceptButton = value; }

        [DefaultValue(false)]
        public bool IsDenyButton { get => _isDenyButton; set => _isDenyButton = value; }

        [DefaultValue(false)]
        public bool OpenInExplorer { get => _openInExplorer; set => _openInExplorer = value; }

        [DefaultValue(typeof(Color), @"Color.Green")]
        public Color AcceptButtonBackColour1 { get => _acceptButtonBackColour1; set { _acceptButtonBackColour1 = value; Invalidate(); } }

        [DefaultValue(typeof(Color), @"Color.Empty")]
        public Color AcceptButtonBackColour2 { get => _acceptButtonBackColour2; set { _acceptButtonBackColour2 = value; Invalidate(); } }

        [DefaultValue(typeof(Color), @"Color.Red")]
        public Color DenyButtonBackColour1 { get => _denyButtonBackColour1; set { _denyButtonBackColour1 = value; Invalidate(); } }

        [DefaultValue(typeof(Color), @"Color.Empty")]
        public Color DenyButtonBackColour2 { get => _denyButtonBackColour2; set { _denyButtonBackColour2 = value; Invalidate(); } }

        [DefaultValue(typeof(Color), @"Color.Empty")]
        public Color AcceptButtonTextColour1 { get => _acceptButtonTextColour1; set { _acceptButtonTextColour1 = value; Invalidate(); } }

        [DefaultValue(typeof(Color), @"Color.Empty")]
        public Color AcceptButtonTextColour2 { get => _acceptButtonTextColour2; set { _acceptButtonTextColour2 = value; Invalidate(); } }

        [DefaultValue(typeof(Color), @"Color.Empty")]
        public Color DenyButtonTextColour1 { get => _denyButtonTextColour1; set { _denyButtonTextColour1 = value; Invalidate(); } }

        [DefaultValue(typeof(Color), @"Color.Empty")]
        public Color DenyButtonTextColour2 { get => _denyButtonTextColour2; set { _denyButtonTextColour2 = value; Invalidate(); } }

        [DefaultValue(null)]
        public object OptionalParameters { get => _optionalParameters; set => _optionalParameters = value; }

        [DefaultValue(null)]
        public string ProcessName { get => _processNane; set => _processNane = value; }

        #endregion

        #region Identity

        /// <summary>Initializes a new instance of the <see cref="KryptonToastButton" /> class.</summary>
        public KryptonToastButton()
        {
            _actionType = ActionType.Default;

            _isAcceptButton = false;

            _isDenyButton = false;

            _openInExplorer = false;

            _acceptButtonBackColour1 = Color.Green;

            _acceptButtonBackColour2 = Color.Green;

            _acceptButtonTextColour1 = Color.Empty;

            _acceptButtonTextColour2 = Color.Empty;

            _denyButtonBackColour1 = Color.Red;

            _denyButtonBackColour2 = Color.Red;

            _denyButtonTextColour1 = Color.Empty;

            _denyButtonTextColour2 = Color.Empty;

            _optionalParameters = null;

            _processNane = null;
        }

        #endregion

        #region Implementation

        /// <summary>Returns the display string.</summary>
        /// <param name="buttonText">The button text.</param>
        /// <returns></returns>
        private KryptonButtonBuiltInDisplayString ReturnDisplayString(string buttonText)
        {
            if (buttonText == KryptonManager.Strings.Abort)
            {
                return KryptonButtonBuiltInDisplayString.Abort;
            }
            else if (buttonText == KryptonManager.Strings.Apply)
            {
                return KryptonButtonBuiltInDisplayString.Apply;
            }
            else if (buttonText == KryptonManager.Strings.Cancel)
            {
                return KryptonButtonBuiltInDisplayString.Cancel;
            }
            else if (buttonText == KryptonManager.Strings.Close)
            {
                return KryptonButtonBuiltInDisplayString.Close;
            }
            else if (buttonText == KryptonManager.Strings.Collapse)
            {
                return KryptonButtonBuiltInDisplayString.Collapse;
            }
            else if (buttonText == KryptonManager.Strings.Continue)
            {
                return KryptonButtonBuiltInDisplayString.Continue;
            }
            else if (buttonText == KryptonManager.Strings.Expand)
            {
                return KryptonButtonBuiltInDisplayString.Expand;
            }
            else if (buttonText == KryptonManager.Strings.Help)
            {
                return KryptonButtonBuiltInDisplayString.Help;
            }
            else if (buttonText == KryptonManager.Strings.Ignore)
            {
                return KryptonButtonBuiltInDisplayString.Ignore;
            }
            else if (buttonText == KryptonManager.Strings.No)
            {
                return KryptonButtonBuiltInDisplayString.No;
            }
            else if (buttonText == KryptonManager.Strings.OK)
            {
                return KryptonButtonBuiltInDisplayString.Ok;
            }
            else if (buttonText == KryptonManager.Strings.Retry)
            {
                return KryptonButtonBuiltInDisplayString.Retry;
            }
            else if (buttonText == KryptonManager.Strings.Today)
            {
                return KryptonButtonBuiltInDisplayString.Today;
            }
            else if (buttonText == KryptonManager.Strings.TryAgain)
            {
                return KryptonButtonBuiltInDisplayString.TryAgain;
            }
            else if (buttonText == KryptonManager.Strings.Yes)
            {
                return KryptonButtonBuiltInDisplayString.Yes;
            }
            else
            {
                return KryptonButtonBuiltInDisplayString.Custom;
            }
        }

        /// <summary>Changes the back colour.</summary>
        /// <param name="backColour">The first back colour.</param>
        /// <param name="backColour2">The second back colour.</param>
        private void ChangeBackColour(Color backColour, Color? backColour2)
        {
            if (backColour2 != null)
            {
                StateCommon.Back.Color1 = backColour;

                StateCommon.Back.Color2 = backColour2 ?? backColour;
            }
            else
            {
                StateCommon.Back.Color1 = backColour;

                StateCommon.Back.Color2 = backColour;
            }
        }

        /// <summary>Changes the text colour.</summary>
        /// <param name="textColour1">The text colour1.</param>
        /// <param name="textColour2">The text colour2.</param>
        private void ChangeTextColour(Color textColour1, Color? textColour2)
        {
            if (textColour2 != null)
            {
                StateCommon.Content.ShortText.Color1 = textColour1;

                StateCommon.Content.ShortText.Color2 = textColour2 ?? textColour1;
            }
            else
            {
                StateCommon.Content.ShortText.Color1 = textColour1;

                StateCommon.Content.ShortText.Color2 = textColour1;
            }
        }

        /// <summary>Sets the accept button.</summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        private void SetAcceptButton(bool value) => _isAcceptButton = value;

        /// <summary>Sets the deny button.</summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        private bool SetDenyButton(bool value) => _isDenyButton = value;

        private void LaunchProcess(object value)
        {
            try
            {
                Process.Start(value.ToString());
            }
            catch (Exception e)
            {
                ExceptionCapture.CaptureException(e);
            }
        }

        private void OpenProcess(object value, string processName, bool openInExplorer = false)
        {
            try
            {
                if (openInExplorer)
                {
                    processName = null;

                    Process.Start(@"explorer.exe", value.ToString());
                }
                else
                {
                    Process.Start(processName, value.ToString());
                }
            }
            catch (Exception e)
            {
                ExceptionCapture.CaptureException(e);
            }
        }

        #endregion

        #region Protected

        /// <summary>Raises the <see cref="E:System.Windows.Forms.Control.TextChanged">TextChanged</see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs">EventArgs</see> that contains the event data.</param>
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
        }

        /// <summary>Raises the <see cref="E:Paint" /> event.</summary>
        /// <param name="e">The <see cref="PaintEventArgs" /> instance containing the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (_useAcceptDenyColours)
            {
                if (_isAcceptButton)
                {
                    if (_acceptButtonBackColour2 != Color.Empty)
                    {
                        ChangeBackColour(AcceptButtonBackColour1, AcceptButtonBackColour2);
                    }
                    else
                    {
                        ChangeBackColour(AcceptButtonBackColour1, null);
                    }

                }
                else if (_isDenyButton)
                {
                    if (_denyButtonTextColour2 != Color.Empty)
                    {
                        ChangeBackColour(DenyButtonBackColour1, DenyButtonBackColour2);
                    }
                    else
                    {
                        ChangeBackColour(DenyButtonBackColour1, null);
                    }
                }
                else
                {
                    ChangeBackColour(Color.Empty, Color.Empty);
                }
            }
            else
            {
                ChangeBackColour(Color.Empty, Color.Empty);
            }

            base.OnPaint(e);
        }

        protected override void OnClick(EventArgs e)
        {
            if (_actionType == ActionType.LaunchProcess)
            {
                LaunchProcess(_optionalParameters);
            }
            else if (_actionType == ActionType.Open)
            {
                OpenProcess(_optionalParameters, _processNane, _openInExplorer);
            }

            base.OnClick(e);
        }

        #endregion
    }
}