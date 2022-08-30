#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Buttons
{
    public class KryptonButtonExtended : KryptonButton
    {
        #region Instance Fields

        private bool _useAssociatedDialogResult;

        private KryptonButtonBuiltInDisplayString _displayString;

        #endregion

        #region Public

        [DefaultValue(false)]
        public bool UseAssociatedDialogResult { get => _useAssociatedDialogResult; set => _useAssociatedDialogResult = value; }

        [DefaultValue(typeof(KryptonButtonBuiltInDisplayString), "KryptonButtonBuiltInDisplayString.Custom")]
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

        public KryptonButtonExtended()
        {
            _useAssociatedDialogResult = false;

            _displayString = KryptonButtonBuiltInDisplayString.Custom;
        }

        #endregion

        #region Implementation

        private void ChangeText(KryptonButtonBuiltInDisplayString displayString, string customText = "", DialogResult customDialogResult = DialogResult.None)
        {
            switch (displayString)
            {
                case KryptonButtonBuiltInDisplayString.Abort:
                    Text = KryptonManager.Strings.Abort;

                    DialogResult = DialogResult.Abort;
                    break;
                case KryptonButtonBuiltInDisplayString.Apply:
                    Text = KryptonManager.Strings.Apply;
                    break;
                case KryptonButtonBuiltInDisplayString.Cancel:
                    Text = KryptonManager.Strings.Cancel;

                    DialogResult = DialogResult.Cancel;
                    break;
                case KryptonButtonBuiltInDisplayString.Collapse:
                    Text = KryptonManager.Strings.Collapse;
                    break;
                case KryptonButtonBuiltInDisplayString.Continue:
                    Text = KryptonManager.Strings.Continue;
                    break;
                case KryptonButtonBuiltInDisplayString.Close:
                    Text = KryptonManager.Strings.Close;

                    DialogResult = DialogResult.Cancel;
                    break;
                case KryptonButtonBuiltInDisplayString.Custom:
                    Text = customText;

                    DialogResult = customDialogResult;
                    break;
                case KryptonButtonBuiltInDisplayString.Yes:
                    Text = KryptonManager.Strings.Yes;

                    DialogResult = DialogResult.Yes;
                    break;
                case KryptonButtonBuiltInDisplayString.No:
                    Text = KryptonManager.Strings.No;

                    DialogResult = DialogResult.No;
                    break;
                case KryptonButtonBuiltInDisplayString.Ok:
                    Text = KryptonManager.Strings.OK;

                    DialogResult = DialogResult.OK;
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

        private void ChangeButtonText(string buttonText)
        {


            DisplayString = ReturnDisplayString(buttonText);
        }

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

        #endregion

        #region Protected

        protected override void OnTextChanged(EventArgs e)
        {
            ChangeText(_displayString);

            base.OnTextChanged(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
           

            base.OnPaint(e);
        }

        #endregion
    }
}