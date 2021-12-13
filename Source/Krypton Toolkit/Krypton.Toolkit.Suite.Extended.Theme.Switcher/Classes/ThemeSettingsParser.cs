#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Theme.Switcher
{
    internal class ThemeSettingsParser
    {
        #region Variables
        private SettingsManager _settingsManager;

        private ThemeSettingsManager _themeSettings = new ThemeSettingsManager();
        #endregion

        #region Constructor
        public ThemeSettingsParser()
        {

        }
        #endregion

        #region Methods
        public void ExportSettings()
        {
            _themeSettings.SetCustomThemePath(_settingsManager.GetCustomThemePath());

            _themeSettings.SetDarkModeThemePaletteMode(_settingsManager.GetDarkModeThemePaletteMode());

            _themeSettings.SetLightModeThemePaletteMode(_settingsManager.GetLightModeThemePaletteMode());

            _themeSettings.SetSelectedThemePaletteMode(_settingsManager.GetSelectedThemePaletteMode());

            _themeSettings.SetShowImportButton(_settingsManager.GetShowImportButton());

            _themeSettings.SetShowResetButton(_settingsManager.GetShowResetButton());

            _themeSettings.SaveThemeSettings();
        }
        #endregion
    }
}