using Krypton.Toolkit.Suite.Extended.Language.Model;
using System;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Dialogs
{
    public class EnumerationTranslator
    {
        public EnumerationTranslator()
        {

        }

        /// <summary>Translates the input box buttons.</summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static InputBoxButtons TranslateInputBoxButtons(string value) => (InputBoxButtons)Enum.Parse(typeof(InputBoxButtons), ConvertToUpper(value));

        /// <summary>Translates the input box default button.</summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static InputBoxDefaultButton TranslateInputBoxDefaultButton(string value) => (InputBoxDefaultButton)Enum.Parse(typeof(InputBoxDefaultButton), ConvertToUpper(value));

        /// <summary>Translates the input box icon.</summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static InputBoxIcon TranslateInputBoxIcon(string value) => (InputBoxIcon)Enum.Parse(typeof(InputBoxIcon), ConvertToUpper(value));

        /// <summary>Translates the size of the input box icon image.</summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static InputBoxIconImageSize TranslateInputBoxIconImageSize(string value) => (InputBoxIconImageSize)Enum.Parse(typeof(InputBoxIconImageSize), ConvertToUpper(value));

        /// <summary>Translates the input box message right to left.</summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static InputBoxMessageRightToLeft TranslateInputBoxMessageRightToLeft(string value) => (InputBoxMessageRightToLeft)Enum.Parse(typeof(InputBoxMessageRightToLeft), ConvertToUpper(value));

        /// <summary>Translates the input box message text alignment.</summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static InputBoxMessageTextAlignment TranslateInputBoxMessageTextAlignment(string value) => (InputBoxMessageTextAlignment)Enum.Parse(typeof(InputBoxMessageTextAlignment), ConvertToUpper(value));

        /// <summary>Translates the type of the input box.</summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static InputBoxType TranslateInputBoxType(string value) => (InputBoxType)Enum.Parse(typeof(InputBoxType), ConvertToUpper(value));

        /// <summary>Translates the input box user input text alignment.</summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static InputBoxUserInputTextAlignment TranslateInputBoxUserInputTextAlignment(string value) => (InputBoxUserInputTextAlignment)Enum.Parse(typeof(InputBoxUserInputTextAlignment), ConvertToUpper(value));

        /// <summary>Translates the input box user selection text alignment.</summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static InputBoxUserSelectionTextAlignment TranslateInputBoxUserSelectionTextAlignment(string value) => (InputBoxUserSelectionTextAlignment)Enum.Parse(typeof(InputBoxUserSelectionTextAlignment), ConvertToUpper(value));

        /// <summary>Translates the form start position.</summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static FormStartPosition TranslateFormStartPosition(string value) => (FormStartPosition)Enum.Parse(typeof(FormStartPosition), value);

        /// <summary>Converts to uppercase.</summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        private static string ConvertToUpper(string value) => value.ToUpper();

        /// <summary>Translates the input language.</summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static Language TranslateInputLanguage(string value) => (Language)Enum.Parse(typeof(Language), value);
    }
}