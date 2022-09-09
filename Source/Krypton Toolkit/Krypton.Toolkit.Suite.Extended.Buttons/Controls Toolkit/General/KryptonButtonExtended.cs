#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Buttons
{
    [Designer(typeof(KryptonButtonExtendedDesigner))]
    public class KryptonButtonExtended : KryptonButton
    {
        #region Instance Fields

        private bool _useAssociatedDialogResult, _useAcceptDenyColours, _isAcceptButton, _isDenyButton;

        private Color _acceptButtonBackColour1,
                      _acceptButtonBackColour2,
                      _denyButtonBackColour1,
                      _denyButtonBackColour2,
                      _acceptButtonTextColour1,
                      _acceptButtonTextColour2,
                      _denyButtonTextColour1,
                      _denyButtonTextColour2;

        private KryptonButtonBuiltInDisplayString _displayString;

        #endregion

        #region Public

        [DefaultValue(false)]
        public bool UseAssociatedDialogResult { get => _useAssociatedDialogResult; set => _useAssociatedDialogResult = value; }

        [DefaultValue(false)]
        public bool UseAcceptDenyColours { get => _useAcceptDenyColours; set { _useAcceptDenyColours = value; Invalidate(); } }

        [DefaultValue(false)]
        public bool IsAcceptButton { get => _isAcceptButton; set => _isAcceptButton = value; }

        [DefaultValue(false)]
        public bool IsDenyButton { get => _isDenyButton; set => _isDenyButton = value; }

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

        [DefaultValue(typeof(KryptonButtonBuiltInDisplayString), @"KryptonButtonBuiltInDisplayString.Custom")]
        public KryptonButtonBuiltInDisplayString DisplayString
        {
            get => _displayString;

            set
            {
                if (_displayString != value)
                {
                    _displayString = value;

                    ChangeText(value);
                }
            }
        }

        #endregion

        #region Identity

        /// <summary>Initializes a new instance of the <see cref="KryptonButtonExtended" /> class.</summary>
        public KryptonButtonExtended()
        {
            _isAcceptButton = false;

            _isDenyButton = false;

            _useAssociatedDialogResult = false;

            _acceptButtonBackColour1 = Color.Green;

            _acceptButtonBackColour2 = Color.Green;

            _acceptButtonTextColour1 = Color.Empty;

            _acceptButtonTextColour2 = Color.Empty;

            _denyButtonBackColour1 = Color.Red;

            _denyButtonBackColour2 = Color.Red;

            _denyButtonTextColour1 = Color.Empty;

            _denyButtonTextColour2 = Color.Empty;

            _displayString = KryptonButtonBuiltInDisplayString.Custom;
        }

        #endregion

        #region Implementation

        /// <summary>Changes the text.</summary>
        /// <param name="displayString">The display string.</param>
        /// <param name="customText">The custom text.</param>
        /// <param name="customDialogResult">The custom dialog result.</param>
        private void ChangeText(KryptonButtonBuiltInDisplayString displayString, string customText = "", DialogResult customDialogResult = DialogResult.None)
        {
            switch (displayString)
            {
                case KryptonButtonBuiltInDisplayString.Abort:
                    Text = KryptonManager.Strings.Abort;

                    DialogResult = DialogResult.Abort;

                    SetDenyButton(true);
                    break;
                case KryptonButtonBuiltInDisplayString.Apply:
                    Text = KryptonManager.Strings.Apply;

                    SetAcceptButton(true);
                    break;
                case KryptonButtonBuiltInDisplayString.Cancel:
                    Text = KryptonManager.Strings.Cancel;

                    DialogResult = DialogResult.Cancel;

                    SetDenyButton(false);
                    break;
                case KryptonButtonBuiltInDisplayString.Collapse:
                    Text = KryptonManager.Strings.Collapse;
                    break;
                case KryptonButtonBuiltInDisplayString.Continue:
                    Text = KryptonManager.Strings.Continue;

                    SetAcceptButton(true);
                    break;
                case KryptonButtonBuiltInDisplayString.Close:
                    Text = KryptonManager.Strings.Close;

                    DialogResult = DialogResult.Cancel;

                    SetDenyButton(true);
                    break;
                case KryptonButtonBuiltInDisplayString.Custom:
                    Text = customText;

                    DialogResult = customDialogResult;
                    break;
                case KryptonButtonBuiltInDisplayString.Yes:
                    Text = KryptonManager.Strings.Yes;

                    DialogResult = DialogResult.Yes;

                    SetAcceptButton(true);
                    break;
                case KryptonButtonBuiltInDisplayString.No:
                    Text = KryptonManager.Strings.No;

                    DialogResult = DialogResult.No;

                    SetDenyButton(true);
                    break;
                case KryptonButtonBuiltInDisplayString.Ok:
                    Text = KryptonManager.Strings.OK;

                    DialogResult = DialogResult.OK;

                    SetAcceptButton(true);
                    break;
                case KryptonButtonBuiltInDisplayString.Retry:
                    Text = KryptonManager.Strings.Retry;

                    DialogResult = DialogResult.Retry;
                    break;
                case KryptonButtonBuiltInDisplayString.Ignore:
                    Text = KryptonManager.Strings.Ignore;

                    DialogResult = DialogResult.Ignore;
                    break;
                case KryptonButtonBuiltInDisplayString.Help:
                    Text = KryptonManager.Strings.Help;
                    break;
                case KryptonButtonBuiltInDisplayString.TryAgain:
                    Text = KryptonManager.Strings.TryAgain;
                    break;
                case KryptonButtonBuiltInDisplayString.Expand:
                    Text = KryptonManager.Strings.Expand;
                    break;
                case KryptonButtonBuiltInDisplayString.Today:
                    Text = KryptonManager.Strings.Today;
                    break;
            }

            DisplayString = ReturnDisplayString(Text);
        }

        /// <summary>Changes the button text.</summary>
        /// <param name="buttonText">The button text.</param>
        private void ChangeButtonText(string buttonText)
        {


            DisplayString = ReturnDisplayString(buttonText);
        }

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

        #endregion

        #region Protected

        /// <summary>Raises the <see cref="E:System.Windows.Forms.Control.TextChanged">TextChanged</see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs">EventArgs</see> that contains the event data.</param>
        protected override void OnTextChanged(EventArgs e)
        {
            ChangeText(_displayString);

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

        #endregion
    }
}