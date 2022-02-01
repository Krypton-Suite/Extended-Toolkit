#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;

using Krypton.Toolkit.Suite.Extended.Developer.Utilities;
using Krypton.Toolkit.Suite.Extended.Tools;

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
                case SelectedLanguage.CZECH:
                    _buttonTextArray = "OK,Ano,Ne,Storno,Přerušení,Opakovat".Split(',');
                    break;
                case SelectedLanguage.FRANÇAIS:
                    _buttonTextArray = "OK,Oui,Non,Annuler,Annuler,Réessayer".Split(',');
                    break;
                case SelectedLanguage.DEUTSCH:
                    _buttonTextArray = "OK,Ja,Nein,Streichen,Abbrechen,Wiederholen".Split(',');
                    break;
                case SelectedLanguage.SLOVAKIAN:
                    _buttonTextArray = "OK,Áno,Nie,Zrušiť,Prerušiť,Zopakujte".Split(',');
                    break;
                case SelectedLanguage.ESPAÑOL:
                    _buttonTextArray = "OK,Sí,No,Cancelar,Aborta,Reintentar".Split(',');
                    break;
                case SelectedLanguage.CUSTOM:
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
                    if (!MissingFrameWorkAPIs.IsNullOrWhiteSpace(value))
                    {
                        switch (language)
                        {
                            case SelectedLanguage.CZECH:
                                if (type == DialogButtonType.ABORT)
                                {
                                    button.Text = _buttonTextArray[4];
                                }

                                if (type == DialogButtonType.CANCEL)
                                {
                                    button.Text = _buttonTextArray[3];
                                }

                                if (type == DialogButtonType.IGNORE)
                                {
                                    button.Text = _buttonTextArray[5];
                                }

                                if (type == DialogButtonType.NO)
                                {
                                    button.Text = _buttonTextArray[2];
                                }

                                if (type == DialogButtonType.OK)
                                {
                                    button.Text = _buttonTextArray[0];
                                }

                                if (type == DialogButtonType.RETRY)
                                {
                                    button.Text = _buttonTextArray[6];
                                }

                                if (type == DialogButtonType.YES)
                                {
                                    button.Text = _buttonTextArray[1];
                                }
                                break;
                            case SelectedLanguage.ENGLISH:
                                if (type == DialogButtonType.ABORT)
                                {
                                    button.Text = @"A&bort";
                                }

                                if (type == DialogButtonType.CANCEL)
                                {
                                    button.Text = @"&Cancel";
                                }

                                if (type == DialogButtonType.IGNORE)
                                {
                                    button.Text = @"Ig&nore";
                                }

                                if (type == DialogButtonType.NO)
                                {
                                    button.Text = @"&N&o";
                                }

                                if (type == DialogButtonType.OK)
                                {
                                    button.Text = @"&Ok";
                                }

                                if (type == DialogButtonType.RETRY)
                                {
                                    button.Text = @"Re&try";
                                }

                                if (type == DialogButtonType.YES)
                                {
                                    button.Text = @"Y&es";
                                }
                                break;
                            case SelectedLanguage.FRANÇAIS:
                                if (type == DialogButtonType.ABORT)
                                {
                                    button.Text = _buttonTextArray[4];
                                }

                                if (type == DialogButtonType.CANCEL)
                                {
                                    button.Text = _buttonTextArray[3];
                                }

                                if (type == DialogButtonType.IGNORE)
                                {
                                    button.Text = _buttonTextArray[5];
                                }

                                if (type == DialogButtonType.NO)
                                {
                                    button.Text = _buttonTextArray[2];
                                }

                                if (type == DialogButtonType.OK)
                                {
                                    button.Text = _buttonTextArray[0];
                                }

                                if (type == DialogButtonType.RETRY)
                                {
                                    button.Text = _buttonTextArray[6];
                                }

                                if (type == DialogButtonType.YES)
                                {
                                    button.Text = _buttonTextArray[1];
                                }
                                break;
                            case SelectedLanguage.DEUTSCH:
                                if (type == DialogButtonType.ABORT)
                                {
                                    button.Text = _buttonTextArray[4];
                                }

                                if (type == DialogButtonType.CANCEL)
                                {
                                    button.Text = _buttonTextArray[3];
                                }

                                if (type == DialogButtonType.IGNORE)
                                {
                                    button.Text = _buttonTextArray[5];
                                }

                                if (type == DialogButtonType.NO)
                                {
                                    button.Text = _buttonTextArray[2];
                                }

                                if (type == DialogButtonType.OK)
                                {
                                    button.Text = _buttonTextArray[0];
                                }

                                if (type == DialogButtonType.RETRY)
                                {
                                    button.Text = _buttonTextArray[6];
                                }

                                if (type == DialogButtonType.YES)
                                {
                                    button.Text = _buttonTextArray[1];
                                }
                                break;
                            case SelectedLanguage.SLOVAKIAN:
                                if (type == DialogButtonType.ABORT)
                                {
                                    button.Text = _buttonTextArray[4];
                                }

                                if (type == DialogButtonType.CANCEL)
                                {
                                    button.Text = _buttonTextArray[3];
                                }

                                if (type == DialogButtonType.IGNORE)
                                {
                                    button.Text = _buttonTextArray[5];
                                }

                                if (type == DialogButtonType.NO)
                                {
                                    button.Text = _buttonTextArray[2];
                                }

                                if (type == DialogButtonType.OK)
                                {
                                    button.Text = _buttonTextArray[0];
                                }

                                if (type == DialogButtonType.RETRY)
                                {
                                    button.Text = _buttonTextArray[6];
                                }

                                if (type == DialogButtonType.YES)
                                {
                                    button.Text = _buttonTextArray[1];
                                }
                                break;
                            case SelectedLanguage.ESPAÑOL:
                                if (type == DialogButtonType.ABORT)
                                {
                                    button.Text = _buttonTextArray[4];
                                }

                                if (type == DialogButtonType.CANCEL)
                                {
                                    button.Text = _buttonTextArray[3];
                                }

                                if (type == DialogButtonType.IGNORE)
                                {
                                    button.Text = _buttonTextArray[5];
                                }

                                if (type == DialogButtonType.NO)
                                {
                                    button.Text = _buttonTextArray[2];
                                }

                                if (type == DialogButtonType.OK)
                                {
                                    button.Text = _buttonTextArray[0];
                                }

                                if (type == DialogButtonType.RETRY)
                                {
                                    button.Text = _buttonTextArray[6];
                                }

                                if (type == DialogButtonType.YES)
                                {
                                    button.Text = _buttonTextArray[1];
                                }
                                break;
                            case SelectedLanguage.CUSTOM:
                                if (type == DialogButtonType.ABORT)
                                {
                                    button.Text = _buttonTextArray[4];
                                }

                                if (type == DialogButtonType.CANCEL)
                                {
                                    button.Text = _buttonTextArray[3];
                                }

                                if (type == DialogButtonType.IGNORE)
                                {
                                    button.Text = _buttonTextArray[5];
                                }

                                if (type == DialogButtonType.NO)
                                {
                                    button.Text = _buttonTextArray[2];
                                }

                                if (type == DialogButtonType.OK)
                                {
                                    button.Text = _buttonTextArray[0];
                                }

                                if (type == DialogButtonType.RETRY)
                                {
                                    button.Text = _buttonTextArray[6];
                                }

                                if (type == DialogButtonType.YES)
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
                ExceptionCapture.CaptureException(e);
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

            tempArray = $"{ okText },{ yesText },{ noText },{ cancelText },{ abortText },{ ignoreText },{ retryText }".Split(',');

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
                case DialogButtonsType.OKCANCEL:
                    break;
                case DialogButtonsType.YESNO:
                    break;
                case DialogButtonsType.YESNOCANCEL:
                    break;
                case DialogButtonsType.RETRYCANCEL:
                    break;
                case DialogButtonsType.ABORTRETRYIGNORE:
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