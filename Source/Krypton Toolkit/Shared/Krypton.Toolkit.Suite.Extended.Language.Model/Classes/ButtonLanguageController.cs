namespace Krypton.Toolkit.Suite.Extended.Language.Model
{
    public class ButtonLanguageController
    {
        #region Variables
        private static string[] _buttonTextArray = new string[6];
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
        private static void SetLanguage(SelectedLanguage language, string okText = "", string yesText = "", string noText = "", string cancelText = "", string abortText = "", string ignoreText = "")
        {
            switch (language)
            {
                case SelectedLanguage.CZECH:
                    _buttonTextArray = "OK,Ano,Ne,Storno,Přerušení".Split(',');
                    break;
                case SelectedLanguage.FRANÇAIS:
                    _buttonTextArray = "OK,Oui,Non,Annuler,Annuler".Split(',');
                    break;
                case SelectedLanguage.DEUTSCH:
                    _buttonTextArray = "OK,Ja,Nein,Abbrechen,Abbrechen".Split(',');
                    break;
                case SelectedLanguage.SLOVAKIAN:
                    _buttonTextArray = "OK,Áno,Nie,Zrušiť,Prerušiť".Split(',');
                    break;
                case SelectedLanguage.ESPAÑOL:
                    _buttonTextArray = "OK,Sí,No,Cancelar,Aborta".Split(',');
                    break;
                case SelectedLanguage.CUSTOM:
                    _buttonTextArray = SetCustomText(okText, yesText, noText, cancelText, abortText, ignoreText);
                    break;
                default:
                    _buttonTextArray = "OK,Yes,No,Cancel,Abort,Ignore".Split(',');
                    break;
            }
        }

        /// <summary>Sets the custom text.</summary>
        /// <param name="okText">The ok text.</param>
        /// <param name="yesText">The yes text.</param>
        /// <param name="noText">The no text.</param>
        /// <param name="cancelText">The cancel text.</param>
        /// <param name="abortText">The abort text.</param>
        /// <param name="ignoreText">The ignore text.</param>
        /// <returns>An array of text.</returns>
        private static string[] SetCustomText(string okText, string yesText, string noText, string cancelText, string abortText, string ignoreText)
        {
            string[] tempArray = new string[6];

            tempArray = $"{ okText },{ yesText },{ noText },{ cancelText },{ abortText },{ ignoreText }".Split(',');

            return tempArray;
        }

        /// <summary>Adapts the selected button text.</summary>
        /// <param name="okButton">The ok button.</param>
        /// <param name="yesButton">The yes button.</param>
        /// <param name="noButton">The no button.</param>
        /// <param name="cancelButton">The cancel button.</param>
        /// <param name="abortButton">The abort button.</param>
        /// <param name="ignoreButton">The ignore button.</param>
        private static void AdaptButtonText(KryptonButton okButton, KryptonButton yesButton, KryptonButton noButton, KryptonButton cancelButton, KryptonButton abortButton, KryptonButton ignoreButton)
        {
            okButton.Text = _buttonTextArray[0];

            yesButton.Text = _buttonTextArray[1];

            noButton.Text = _buttonTextArray[2];

            cancelButton.Text = _buttonTextArray[3];

            abortButton.Text = _buttonTextArray[4];

            ignoreButton.Text = _buttonTextArray[5];
        }

        /// <summary>Adapts the selected button visibility.</summary>
        /// <param name="buttonType">Type of the button.</param>
        /// <param name="okButton">The ok button.</param>
        /// <param name="yesButton">The yes button.</param>
        /// <param name="noButton">The no button.</param>
        /// <param name="cancelButton">The cancel button.</param>
        /// <param name="abortButton">The abort button.</param>
        /// <param name="ignoreButton">The ignore button.</param>
        // TODO: Complete this method
        private static void AdaptButtonVisibility(ButtonType buttonType, KryptonButton okButton, KryptonButton yesButton, KryptonButton noButton, KryptonButton cancelButton, KryptonButton abortButton, KryptonButton ignoreButton)
        {
            AdaptButtonText(okButton, yesButton, noButton, cancelButton, abortButton, ignoreButton);

            switch (buttonType)
            {
                case ButtonType.OK:
                    break;
                case ButtonType.OKCANCEL:
                    break;
                case ButtonType.YESNO:
                    break;
                case ButtonType.YESNOCANCEL:
                    break;
                case ButtonType.RETRYCANCEL:
                    break;
                case ButtonType.ABORTRETRYIGNORE:
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}