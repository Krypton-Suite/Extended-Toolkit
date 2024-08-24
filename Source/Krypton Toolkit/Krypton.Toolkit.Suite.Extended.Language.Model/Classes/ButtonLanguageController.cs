#region MIT License
/*
 *
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
 */
#endregion

using DebugUtilities = Krypton.Toolkit.Suite.Extended.Debug.Tools.DebugUtilities;

namespace Krypton.Toolkit.Suite.Extended.Language.Model
{
    public class ButtonLanguageController
    {
        #region Variables
        private static string[] _buttonTextArray = new string[7];
        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="ButtonLanguageController"/> class.</summary>
        public ButtonLanguageController()
        {

        }
        #endregion

        #region Methods
        /// <summary>Sets the language.</summary>
        /// <param name="language">The language.</param>
        /// <param name="okText">The ok text.</param>
        /// <param name="yesText">The yes text.</param>
        /// <param name="noText">The no text.</param>
        /// <param name="cancelText">The cancel text.</param>
        /// <param name="abortText">The abort text.</param>
        /// <param name="ignoreText">The ignore text.</param>
        /// <param name="retryText">The retry text.</param>
        private static void SetLanguage(SelectedLanguage language, string okText = "", string yesText = "", string noText = "", string cancelText = "", string abortText = "", string ignoreText = "", string retryText = "")
        {
            switch (language)
            {
                case SelectedLanguage.Czech:
                    _buttonTextArray = "OK,Ano,Ne,Storno,Přerušení,Opakovat".Split(',');
                    break;
                case SelectedLanguage.Français:
                    _buttonTextArray = "OK,Oui,Non,Annuler,Annuler,Réessayer".Split(',');
                    break;
                case SelectedLanguage.Deutsch:
                    _buttonTextArray = "OK,Ja,Nein,Streichen,Abbrechen,Wiederholen".Split(',');
                    break;
                case SelectedLanguage.Slovakian:
                    _buttonTextArray = "OK,Áno,Nie,Zrušiť,Prerušiť,Zopakujte".Split(',');
                    break;
                case SelectedLanguage.Español:
                    _buttonTextArray = "OK,Sí,No,Cancelar,Aborta,Reintentar".Split(',');
                    break;
                case SelectedLanguage.Custom:
                    _buttonTextArray = SetCustomText(okText, yesText, noText, cancelText, abortText, ignoreText, retryText);
                    break;
                default:
                    _buttonTextArray = "OK,Yes,No,Cancel,Abort,Ignore,Retry".Split(',');
                    break;
            }
        }

        /// <summary>Adapts the button text.</summary>
        /// <param name="language">The language.</param>
        /// <param name="type">The type.</param>
        /// <param name="button">The button.</param>
        public static void AdaptButtonText(SelectedLanguage language, DialogButtonType type, KryptonButton button)
        {
            try
            {
                foreach (string value in _buttonTextArray)
                {
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        switch (language)
                        {
                            case SelectedLanguage.Czech:
                                if (type == DialogButtonType.Abort)
                                {
                                    button.Text = _buttonTextArray[4];
                                }

                                if (type == DialogButtonType.Cancel)
                                {
                                    button.Text = _buttonTextArray[3];
                                }

                                if (type == DialogButtonType.Ignore)
                                {
                                    button.Text = _buttonTextArray[5];
                                }

                                if (type == DialogButtonType.No)
                                {
                                    button.Text = _buttonTextArray[2];
                                }

                                if (type == DialogButtonType.OK)
                                {
                                    button.Text = _buttonTextArray[0];
                                }

                                if (type == DialogButtonType.Retry)
                                {
                                    button.Text = _buttonTextArray[6];
                                }

                                if (type == DialogButtonType.Yes)
                                {
                                    button.Text = _buttonTextArray[1];
                                }
                                break;
                            case SelectedLanguage.English:
                                if (type == DialogButtonType.Abort)
                                {
                                    button.Text = @"A&bort";
                                }

                                if (type == DialogButtonType.Cancel)
                                {
                                    button.Text = @"&Cancel";
                                }

                                if (type == DialogButtonType.Ignore)
                                {
                                    button.Text = @"Ig&nore";
                                }

                                if (type == DialogButtonType.No)
                                {
                                    button.Text = @"&N&o";
                                }

                                if (type == DialogButtonType.OK)
                                {
                                    button.Text = @"&Ok";
                                }

                                if (type == DialogButtonType.Retry)
                                {
                                    button.Text = @"Re&try";
                                }

                                if (type == DialogButtonType.Yes)
                                {
                                    button.Text = @"Y&es";
                                }
                                break;
                            case SelectedLanguage.Français:
                                if (type == DialogButtonType.Abort)
                                {
                                    button.Text = _buttonTextArray[4];
                                }

                                if (type == DialogButtonType.Cancel)
                                {
                                    button.Text = _buttonTextArray[3];
                                }

                                if (type == DialogButtonType.Ignore)
                                {
                                    button.Text = _buttonTextArray[5];
                                }

                                if (type == DialogButtonType.No)
                                {
                                    button.Text = _buttonTextArray[2];
                                }

                                if (type == DialogButtonType.OK)
                                {
                                    button.Text = _buttonTextArray[0];
                                }

                                if (type == DialogButtonType.Retry)
                                {
                                    button.Text = _buttonTextArray[6];
                                }

                                if (type == DialogButtonType.Yes)
                                {
                                    button.Text = _buttonTextArray[1];
                                }
                                break;
                            case SelectedLanguage.Deutsch:
                                if (type == DialogButtonType.Abort)
                                {
                                    button.Text = _buttonTextArray[4];
                                }

                                if (type == DialogButtonType.Cancel)
                                {
                                    button.Text = _buttonTextArray[3];
                                }

                                if (type == DialogButtonType.Ignore)
                                {
                                    button.Text = _buttonTextArray[5];
                                }

                                if (type == DialogButtonType.No)
                                {
                                    button.Text = _buttonTextArray[2];
                                }

                                if (type == DialogButtonType.OK)
                                {
                                    button.Text = _buttonTextArray[0];
                                }

                                if (type == DialogButtonType.Retry)
                                {
                                    button.Text = _buttonTextArray[6];
                                }

                                if (type == DialogButtonType.Yes)
                                {
                                    button.Text = _buttonTextArray[1];
                                }
                                break;
                            case SelectedLanguage.Slovakian:
                                if (type == DialogButtonType.Abort)
                                {
                                    button.Text = _buttonTextArray[4];
                                }

                                if (type == DialogButtonType.Cancel)
                                {
                                    button.Text = _buttonTextArray[3];
                                }

                                if (type == DialogButtonType.Ignore)
                                {
                                    button.Text = _buttonTextArray[5];
                                }

                                if (type == DialogButtonType.No)
                                {
                                    button.Text = _buttonTextArray[2];
                                }

                                if (type == DialogButtonType.OK)
                                {
                                    button.Text = _buttonTextArray[0];
                                }

                                if (type == DialogButtonType.Retry)
                                {
                                    button.Text = _buttonTextArray[6];
                                }

                                if (type == DialogButtonType.Yes)
                                {
                                    button.Text = _buttonTextArray[1];
                                }
                                break;
                            case SelectedLanguage.Español:
                                if (type == DialogButtonType.Abort)
                                {
                                    button.Text = _buttonTextArray[4];
                                }

                                if (type == DialogButtonType.Cancel)
                                {
                                    button.Text = _buttonTextArray[3];
                                }

                                if (type == DialogButtonType.Ignore)
                                {
                                    button.Text = _buttonTextArray[5];
                                }

                                if (type == DialogButtonType.No)
                                {
                                    button.Text = _buttonTextArray[2];
                                }

                                if (type == DialogButtonType.OK)
                                {
                                    button.Text = _buttonTextArray[0];
                                }

                                if (type == DialogButtonType.Retry)
                                {
                                    button.Text = _buttonTextArray[6];
                                }

                                if (type == DialogButtonType.Yes)
                                {
                                    button.Text = _buttonTextArray[1];
                                }
                                break;
                            case SelectedLanguage.Custom:
                                if (type == DialogButtonType.Abort)
                                {
                                    button.Text = _buttonTextArray[4];
                                }

                                if (type == DialogButtonType.Cancel)
                                {
                                    button.Text = _buttonTextArray[3];
                                }

                                if (type == DialogButtonType.Ignore)
                                {
                                    button.Text = _buttonTextArray[5];
                                }

                                if (type == DialogButtonType.No)
                                {
                                    button.Text = _buttonTextArray[2];
                                }

                                if (type == DialogButtonType.OK)
                                {
                                    button.Text = _buttonTextArray[0];
                                }

                                if (type == DialogButtonType.Retry)
                                {
                                    button.Text = _buttonTextArray[6];
                                }

                                if (type == DialogButtonType.Yes)
                                {
                                    button.Text = _buttonTextArray[1];
                                }
                                break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                DebugUtilities.NotImplemented(e.ToString());
            }
        }

        /// <summary>Sets the custom text.</summary>
        /// <param name="okText">The ok text.</param>
        /// <param name="yesText">The yes text.</param>
        /// <param name="noText">The no text.</param>
        /// <param name="cancelText">The cancel text.</param>
        /// <param name="abortText">The abort text.</param>
        /// <param name="ignoreText">The ignore text.</param>
        /// <param name="retryText">The retry text.</param>
        /// <returns>An array of text.</returns>
        private static string[] SetCustomText(string okText, string yesText, string noText, string cancelText, string abortText, string ignoreText, string retryText)
        {
            string[] tempArray = new string[7];

            tempArray = $"{okText},{yesText},{noText},{cancelText},{abortText},{ignoreText},{retryText}".Split(',');

            return tempArray;
        }

        /// <summary>Adapts the selected button text.</summary>
        /// <param name="okButton">The ok button.</param>
        /// <param name="yesButton">The yes button.</param>
        /// <param name="noButton">The no button.</param>
        /// <param name="cancelButton">The cancel button.</param>
        /// <param name="abortButton">The abort button.</param>
        /// <param name="ignoreButton">The ignore button.</param>
        /// <param name="retryButton">The retry button.</param>
        private static void AdaptButtonText(KryptonButton okButton, KryptonButton yesButton, KryptonButton noButton, KryptonButton cancelButton, KryptonButton abortButton, KryptonButton ignoreButton, KryptonButton retryButton)
        {
            okButton.Text = _buttonTextArray[0];

            yesButton.Text = _buttonTextArray[1];

            noButton.Text = _buttonTextArray[2];

            cancelButton.Text = _buttonTextArray[3];

            abortButton.Text = _buttonTextArray[4];

            ignoreButton.Text = _buttonTextArray[5];

            retryButton.Text = _buttonTextArray[6];
        }

        /// <summary>Adapts the selected button visibility.</summary>
        /// <param name="buttonType">Type of the button.</param>
        /// <param name="okButton">The ok button.</param>
        /// <param name="yesButton">The yes button.</param>
        /// <param name="noButton">The no button.</param>
        /// <param name="cancelButton">The cancel button.</param>
        /// <param name="abortButton">The abort button.</param>
        /// <param name="ignoreButton">The ignore button.</param>
        /// <param name="retryButton">The retry button.</param>
        // TODO: Complete this method
        private static void AdaptButtonVisibility(DialogButtonsType buttonType, KryptonButton okButton, KryptonButton yesButton, KryptonButton noButton, KryptonButton cancelButton, KryptonButton abortButton, KryptonButton ignoreButton, KryptonButton retryButton)
        {
            AdaptButtonText(okButton, yesButton, noButton, cancelButton, abortButton, ignoreButton, retryButton);

            switch (buttonType)
            {
                case DialogButtonsType.OK:
                    break;
                case DialogButtonsType.OKCancel:
                    break;
                case DialogButtonsType.YesNo:
                    break;
                case DialogButtonsType.YesNoCancel:
                    break;
                case DialogButtonsType.RetryCancel:
                    break;
                case DialogButtonsType.AbortRetryIgnore:
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Setters and Getters
        /// <summary>Sets the button text array.</summary>
        /// <param name="values">The values to go in the array.</param>
        public void SetButtonTextArray(string[] values) => _buttonTextArray = values;

        /// <summary>Gets the button text array.</summary>
        /// <returns>The button text array.</returns>
        public string[] GetButtonTextArray() => _buttonTextArray;
        #endregion
    }
}