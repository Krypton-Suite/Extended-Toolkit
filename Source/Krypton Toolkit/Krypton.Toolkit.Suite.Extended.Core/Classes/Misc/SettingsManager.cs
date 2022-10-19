#region MIT License
/*
 *
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

using Krypton.Toolkit.Suite.Extended.Core.Settings;

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public class SettingsManagerAlternative
    {
        #region Variables
        private CoreSettings _mySettings = new CoreSettings();
        #endregion

        #region Constructor
        public SettingsManagerAlternative()
        {

        }
        #endregion

        #region Setters & Getters
        /// <summary>
        /// Sets the UpdateInRealTime to the value of value.
        /// </summary>
        /// <param name="value">The value of value.</param>
        public void SetUpdateInRealTime(bool value)
        {
            _mySettings.UpdateInRealTime = value;
        }

        /// <summary>
        /// Gets the UpdateInRealTime value.
        /// </summary>
        /// <returns>The value of value.</returns>
        public bool GetUpdateInRealTime()
        {
            return _mySettings.UpdateInRealTime;
        }
        #endregion

        #region Methods
        public void SaveSettings(bool useDialoguePrompt = false)
        {
            if (useDialoguePrompt)
            {
                DialogResult result = KryptonMessageBox.Show("Do you want to store and save the current setting values?", "Save Settings", MessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _mySettings.Save();
                }
            }
            else
            {
                _mySettings.Save();
            }
        }
        #endregion
    }
}