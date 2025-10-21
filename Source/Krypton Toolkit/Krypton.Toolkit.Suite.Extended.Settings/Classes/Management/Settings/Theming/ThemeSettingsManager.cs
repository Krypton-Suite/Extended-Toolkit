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

namespace Krypton.Toolkit.Suite.Extended.Settings;

public class ThemeSettingsManager
{
    #region Variables
    private ThemeSettings _themeSettings = new();

    private GlobalThemeSettings _globalThemeSettings = new();
    #endregion

    #region Constuctor
    public ThemeSettingsManager()
    {

    }
    #endregion

    #region Setters & Getters
    /// <summary>Sets the ShowResetButton to the value of value.</summary>
    /// <param name="value">The desired value of ShowResetButton.</param>
    public void SetShowResetButton(bool value) => _globalThemeSettings.ShowResetButton = value;

    /// <summary>Returns the value of the ShowResetButton.</summary>
    /// <returns>The value of the ShowResetButton.</returns>
    public bool GetShowResetButton() => _globalThemeSettings.ShowResetButton;

    /// <summary>Sets the ShowImportButton to the value of value.</summary>
    /// <param name="value">The desired value of ShowImportButton.</param>
    public void SetShowImportButton(bool value) => _globalThemeSettings.ShowImportButton = value;

    /// <summary>Returns the value of the ShowImportButton.</summary>
    /// <returns>The value of the ShowImportButton.</returns>
    public bool GetShowImportButton() => _globalThemeSettings.ShowImportButton;

    /// <summary>Sets the CustomThemePath to the value of value.</summary>
    /// <param name="value">The desired value of CustomThemePath.</param>
    public void SetCustomThemePath(string value) => _globalThemeSettings.CustomThemePath = value;

    /// <summary>Returns the value of the CustomThemePath.</summary>
    /// <returns>The value of the CustomThemePath.</returns>
    public string GetCustomThemePath() => _globalThemeSettings.CustomThemePath;

    /// <summary>Sets the SelectedThemePaletteMode to the value of value.</summary>
    /// <param name="value">The desired value of SelectedThemePaletteMode.</param>
    public void SetSelectedThemePaletteMode(PaletteMode value) => _globalThemeSettings.SelectedThemePaletteMode = value;

    /// <summary>Returns the value of the SelectedThemePaletteMode.</summary>
    /// <returns>The value of the SelectedThemePaletteMode.</returns>
    public PaletteMode GetSelectedThemePaletteMode() => _globalThemeSettings.SelectedThemePaletteMode;

    /// <summary>Sets the DarkModeThemePaletteMode to the value of value.</summary>
    /// <param name="value">The desired value of DarkModeThemePaletteMode.</param>
    public void SetDarkModeThemePaletteMode(PaletteMode value) => _globalThemeSettings.DarkModeThemePaletteMode = value;

    /// <summary>Returns the value of the DarkModeThemePaletteMode.</summary>
    /// <returns>The value of the DarkModeThemePaletteMode.</returns>
    public PaletteMode GetDarkModeThemePaletteMode() => _globalThemeSettings.DarkModeThemePaletteMode;

    /// <summary>Sets the LightModeThemePaletteMode to the value of value.</summary>
    /// <param name="value">The desired value of LightModeThemePaletteMode.</param>
    public void SetLightModeThemePaletteMode(PaletteMode value) => _globalThemeSettings.LightModeThemePaletteMode = value;

    /// <summary>Returns the value of the LightModeThemePaletteMode.</summary>
    /// <returns>The value of the LightModeThemePaletteMode.</returns>
    public PaletteMode GetLightModeThemePaletteMode() => _globalThemeSettings.LightModeThemePaletteMode;
    #endregion

    #region Save & Reset Methods
    public void SaveThemeSettings(bool usePrompt = false)
    {
        if (usePrompt)
        {
            DialogResult result = KryptonMessageBox.Show("Do you want to save the current theme settings?", "Save Confirmation", KryptonMessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _globalThemeSettings.Save();
            }
            else
            {
                ResetThemeSettings(usePrompt);
            }
        }
        else
        {
            _globalThemeSettings.Save();
        }
    }

    public void ResetThemeSettings(bool usePrompt)
    {
        if (usePrompt)
        {
            DialogResult result = KryptonMessageBox.Show("Are you sure that you want to reset the current theme settings back to their defaults?", "Reset Theme Settings", KryptonMessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ResetThemeSettings();
            }
        }
        else
        {
            ResetThemeSettings();
        }
    }

    private void ResetThemeSettings()
    {
        SetCustomThemePath(string.Empty);

        SetDarkModeThemePaletteMode(PaletteMode.Microsoft365Black);

        SetLightModeThemePaletteMode(PaletteMode.Microsoft365Blue);

        SetSelectedThemePaletteMode(PaletteMode.Microsoft365Blue);

        SetShowImportButton(true);

        SetShowResetButton(true);
    }
    #endregion
}