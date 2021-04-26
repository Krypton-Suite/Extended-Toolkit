#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Language.Model;
using System;

namespace Krypton.Toolkit.Suite.Extended.Buttons
{
    /// <summary>
    ///   <br />
    /// </summary>
    public class SelectedLanguageChangedEventArgs : EventArgs
    {
        #region Variables
        private bool _hasSelectedLanguageChanged;

        private SelectedLanguage _selectedLanguage;
        #endregion

        #region Constants
        private const SelectedLanguage DEFAULT_LANGUAGE = SelectedLanguage.ENGLISH;
        #endregion

        #region Properties
        /// <summary>Gets or sets a value indicating whether this instance has selected language changed.</summary>
        /// <value><c>true</c> if this instance has selected language changed; otherwise, <c>false</c>.</value>
        public bool HasSelectedLanguageChanged { get => _hasSelectedLanguageChanged; set => _hasSelectedLanguageChanged = value; }

        /// <summary>Gets or sets the selected language.</summary>
        /// <value>The selected language.</value>
        public SelectedLanguage SelectedLanguage { get => _selectedLanguage; set => _selectedLanguage = value; }
        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="SelectedLanguageChangedEventArgs" /> class.</summary>
        /// <param name="language">The language.</param>
        public SelectedLanguageChangedEventArgs(SelectedLanguage language)
        {
            SetSelectedLanguage(language);

            if (GetSelectedLanguage() != DEFAULT_LANGUAGE)
            {
                SetHasSelectedLanguageChanged(true);
            }
            else
            {
                SetHasSelectedLanguageChanged(false);
            }
        }
        #endregion

        #region Setters & Getters
        /// <summary>Sets the HasSelectedLanguageChanged to the value of value.</summary>
        /// <param name="value">The desired value of HasSelectedLanguageChanged.</param>
        public void SetHasSelectedLanguageChanged(bool value) => _hasSelectedLanguageChanged = value;

        /// <summary>Returns the value of the HasSelectedLanguageChanged.</summary>
        /// <returns>The value of the HasSelectedLanguageChanged.</returns>
        public bool GetHasSelectedLanguageChanged() => _hasSelectedLanguageChanged;

        /// <summary>Sets the SelectedLanguage to the value of value.</summary>
        /// <param name="value">The desired value of SelectedLanguage.</param>
        public void SetSelectedLanguage(SelectedLanguage value) => _selectedLanguage = value;

        /// <summary>Returns the value of the SelectedLanguage.</summary>
        /// <returns>The value of the SelectedLanguage.</returns>
        public SelectedLanguage GetSelectedLanguage() => _selectedLanguage;

        #endregion

        #region Methods
        /// <summary>Checks the has selected language changed.</summary>
        /// <returns>The value of _hasSelectedLanguageChanged.</returns>
        public bool CheckHasSelectedLanguageChanged()
        {
            bool tmp;

            if (_selectedLanguage != DEFAULT_LANGUAGE)
            {
                tmp = true;
            }
            else
            {
                tmp = false;
            }

            return tmp;
        }
        #endregion
    }
}