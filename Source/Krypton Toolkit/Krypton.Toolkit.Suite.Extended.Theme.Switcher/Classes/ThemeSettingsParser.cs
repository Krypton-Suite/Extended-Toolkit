#region MIT License
/*
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

namespace Krypton.Toolkit.Suite.Extended.Theme.Switcher;

internal class ThemeSettingsParser
{
    #region Variables
    private SettingsManager? _settingsManager;

    private ThemeSettingsManager _themeSettings = new ThemeSettingsManager();
    #endregion

    #region Constructor
    public ThemeSettingsParser()
    {
        _settingsManager = null;
    }
    #endregion

    #region Methods
    public void ExportSettings()
    {
        _themeSettings.SetCustomThemePath(_settingsManager?.GetCustomThemePath());

        _themeSettings.SetDarkModeThemePaletteMode(_settingsManager!.GetDarkModeThemePaletteMode());

        _themeSettings.SetLightModeThemePaletteMode(_settingsManager!.GetLightModeThemePaletteMode());

        _themeSettings.SetSelectedThemePaletteMode(_settingsManager.GetSelectedThemePaletteMode());

        _themeSettings.SetShowImportButton(_settingsManager.GetShowImportButton());

        _themeSettings.SetShowResetButton(_settingsManager.GetShowResetButton());

        _themeSettings.SaveThemeSettings();
    }
    #endregion
}