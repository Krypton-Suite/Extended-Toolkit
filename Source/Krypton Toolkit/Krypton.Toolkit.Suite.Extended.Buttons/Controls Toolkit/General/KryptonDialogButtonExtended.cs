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
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Buttons
{
    [Designer(typeof(KryptonDialogButtonExtendedDesigner))]
    public class KryptonDialogButtonExtended : KryptonButton
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

        //[EditorBrowsable(EditorBrowsableState.Never)]
        //public override string Text { get; set; }

        [DefaultValue(typeof(KryptonButtonBuiltInDisplayString), @"KryptonButtonBuiltInDisplayString.Ok"), Description(@"Controls what the button does. The text is controlled via 'KryptonManager.Strings'.")]
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

        /// <summary>Initializes a new instance of the <see cref="KryptonDialogButtonExtended" /> class.</summary>
        public KryptonDialogButtonExtended()
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

            _displayString = KryptonButtonBuiltInDisplayString.Ok;
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
                    Text = KryptonLanguageManager.GeneralToolkitStrings.Abort;

                    DialogResult = DialogResult.Abort;

                    SetDenyButton(true);
                    break;
                case KryptonButtonBuiltInDisplayString.Apply:
                    Text = KryptonLanguageManager.CustomToolkitStrings.Apply;

                    SetAcceptButton(true);
                    break;
                case KryptonButtonBuiltInDisplayString.Cancel:
                    Text = KryptonLanguageManager.GeneralToolkitStrings.Cancel;

                    DialogResult = DialogResult.Cancel;

                    SetDenyButton(false);
                    break;
                case KryptonButtonBuiltInDisplayString.Collapse:
                    Text = KryptonLanguageManager.CustomToolkitStrings.Collapse;
                    break;
                case KryptonButtonBuiltInDisplayString.Continue:
                    Text = KryptonLanguageManager.GeneralToolkitStrings.Continue;

                    SetAcceptButton(true);
                    break;
                case KryptonButtonBuiltInDisplayString.Close:
                    Text = KryptonLanguageManager.GeneralToolkitStrings.Close;

                    DialogResult = DialogResult.Cancel;

                    SetDenyButton(true);
                    break;
                case KryptonButtonBuiltInDisplayString.Yes:
                    Text = KryptonLanguageManager.GeneralToolkitStrings.Yes;

                    DialogResult = DialogResult.Yes;

                    SetAcceptButton(true);
                    break;
                case KryptonButtonBuiltInDisplayString.No:
                    Text = KryptonLanguageManager.GeneralToolkitStrings.No;

                    DialogResult = DialogResult.No;

                    SetDenyButton(true);
                    break;
                case KryptonButtonBuiltInDisplayString.Ok:
                    Text = KryptonLanguageManager.GeneralToolkitStrings.OK;

                    DialogResult = DialogResult.OK;

                    SetAcceptButton(true);
                    break;
                case KryptonButtonBuiltInDisplayString.Retry:
                    Text = KryptonLanguageManager.GeneralToolkitStrings.Retry;

                    DialogResult = DialogResult.Retry;
                    break;
                case KryptonButtonBuiltInDisplayString.Ignore:
                    Text = KryptonLanguageManager.GeneralToolkitStrings.Ignore;

                    DialogResult = DialogResult.Ignore;
                    break;
                case KryptonButtonBuiltInDisplayString.Help:
                    Text = KryptonLanguageManager.GeneralToolkitStrings.Help;
                    break;
                case KryptonButtonBuiltInDisplayString.TryAgain:
                    Text = KryptonLanguageManager.GeneralToolkitStrings.TryAgain;
                    break;
                case KryptonButtonBuiltInDisplayString.Expand:
                    Text = KryptonLanguageManager.CustomToolkitStrings.Expand;
                    break;
                case KryptonButtonBuiltInDisplayString.Today:
                    Text = KryptonLanguageManager.GeneralToolkitStrings.Today;
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
            if (buttonText == KryptonLanguageManager.GeneralToolkitStrings.Abort)
            {
                return KryptonButtonBuiltInDisplayString.Abort;
            }
            else if (buttonText == KryptonLanguageManager.CustomToolkitStrings.Apply)
            {
                return KryptonButtonBuiltInDisplayString.Apply;
            }
            else if (buttonText == KryptonLanguageManager.GeneralToolkitStrings.Cancel)
            {
                return KryptonButtonBuiltInDisplayString.Cancel;
            }
            else if (buttonText == KryptonLanguageManager.GeneralToolkitStrings.Close)
            {
                return KryptonButtonBuiltInDisplayString.Close;
            }
            else if (buttonText == KryptonLanguageManager.CustomToolkitStrings.Collapse)
            {
                return KryptonButtonBuiltInDisplayString.Collapse;
            }
            else if (buttonText == KryptonLanguageManager.GeneralToolkitStrings.Continue)
            {
                return KryptonButtonBuiltInDisplayString.Continue;
            }
            else if (buttonText == KryptonLanguageManager.CustomToolkitStrings.Expand)
            {
                return KryptonButtonBuiltInDisplayString.Expand;
            }
            else if (buttonText == KryptonLanguageManager.GeneralToolkitStrings.Help)
            {
                return KryptonButtonBuiltInDisplayString.Help;
            }
            else if (buttonText == KryptonLanguageManager.GeneralToolkitStrings.Ignore)
            {
                return KryptonButtonBuiltInDisplayString.Ignore;
            }
            else if (buttonText == KryptonLanguageManager.GeneralToolkitStrings.No)
            {
                return KryptonButtonBuiltInDisplayString.No;
            }
            else if (buttonText == KryptonLanguageManager.GeneralToolkitStrings.OK)
            {
                return KryptonButtonBuiltInDisplayString.Ok;
            }
            else if (buttonText == KryptonLanguageManager.GeneralToolkitStrings.Retry)
            {
                return KryptonButtonBuiltInDisplayString.Retry;
            }
            else if (buttonText == KryptonLanguageManager.GeneralToolkitStrings.Today)
            {
                return KryptonButtonBuiltInDisplayString.Today;
            }
            else if (buttonText == KryptonLanguageManager.GeneralToolkitStrings.TryAgain)
            {
                return KryptonButtonBuiltInDisplayString.TryAgain;
            }
            else if (buttonText == KryptonLanguageManager.GeneralToolkitStrings.Yes)
            {
                return KryptonButtonBuiltInDisplayString.Yes;
            }
            else
            {
                return KryptonButtonBuiltInDisplayString.Ok;
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