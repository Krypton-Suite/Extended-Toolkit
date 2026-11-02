#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Core;

internal class ThemeManager
{
    #region Variables
    private ArrayList _themeList;
    private AutoCompleteStringCollection _themeCollection;
    private PaletteThemeSettingsManager _themeSettingsManager = new();
    #endregion

    public ThemeManager()
    {

    }

    #region Methods
    public void PropagateThemes(KryptonComboBox input)
    {
        InitialiseThemes();

        input.AutoCompleteCustomSource = _themeCollection;

        foreach (string theme in _themeList)
        {
            input.Items.Add(theme);
        }
    }

    private void InitialiseThemes()
    {
        _themeCollection = new();

        _themeList = new();

        #region Autocomplete
        _themeCollection.Add("Professional System");

        _themeCollection.Add("Professional Office 2003");

        _themeCollection.Add("Office 2007 Blue");

        _themeCollection.Add("Office 2007 Silver");

        _themeCollection.Add("Office 2007 Black");

        _themeCollection.Add("Office 2010 Blue");

        _themeCollection.Add("Office 2010 Silver");

        _themeCollection.Add("Office 2010 Black");

        _themeCollection.Add("Office 2013");

        _themeCollection.Add("Office 2013 White");

        _themeCollection.Add("Sparkle Blue");

        _themeCollection.Add("Sparkle Orange");

        _themeCollection.Add("Sparkle Purple");

        _themeCollection.Add("Custom");
        #endregion

        #region ArrayList
        _themeList = new();

        _themeList.Add("Professional System");

        _themeList.Add("Professional Office 2003");

        _themeList.Add("Office 2007 Blue");

        _themeList.Add("Office 2007 Silver");

        _themeList.Add("Office 2007 Black");

        _themeList.Add("Office 2010 Blue");

        _themeList.Add("Office 2010 Silver");

        _themeList.Add("Office 2010 Black");

        _themeList.Add("Office 2013");

        _themeList.Add("Office 2013 White");

        _themeList.Add("Sparkle Blue");

        _themeList.Add("Sparkle Orange");

        _themeList.Add("Sparkle Purple");

        _themeList.Add("Custom");
        #endregion
    }

    private void SetTheme(PaletteMode mode, KryptonManager manager)
    {
        manager.GlobalPaletteMode = mode;

        _themeSettingsManager.SetTheme(mode);
    }

    public void SaveCurrentThemeSettings(bool askPermission = false)
    {
        _themeSettingsManager.SavePaletteThemeSettings(askPermission);
    }
    #endregion

    #region Static Methods        
    /// <summary>
    /// Switches the theme.
    /// </summary>
    /// <param name="mode">The mode.</param>
    /// <param name="manager">The manager.</param>
    public static void SwitchTheme(PaletteMode mode, KryptonManager manager)
    {
        ThemeManager themeManager = new();

        switch (mode)
        {
            case PaletteMode.ProfessionalSystem:
                manager.GlobalPaletteMode = PaletteMode.ProfessionalSystem;
                break;
            case PaletteMode.ProfessionalOffice2003:
                manager.GlobalPaletteMode = PaletteMode.ProfessionalOffice2003;
                break;
            case PaletteMode.Office2007Blue:
                manager.GlobalPaletteMode = PaletteMode.Office2007Blue;
                break;
            case PaletteMode.Office2007Silver:
                manager.GlobalPaletteMode = PaletteMode.Office2007Silver;
                break;
            case PaletteMode.Office2007Black:
                manager.GlobalPaletteMode = PaletteMode.Office2007Black;
                break;
            case PaletteMode.Office2010Blue:
                manager.GlobalPaletteMode = PaletteMode.Office2010Blue;
                break;
            case PaletteMode.Office2010Silver:
                manager.GlobalPaletteMode = PaletteMode.Office2010Silver;
                break;
            case PaletteMode.Office2010Black:
                manager.GlobalPaletteMode = PaletteMode.Office2010Black;
                break;
            case PaletteMode.Office2013White:
                manager.GlobalPaletteMode = PaletteMode.Office2013White;
                break;
            case PaletteMode.SparkleBlue:
                manager.GlobalPaletteMode = PaletteMode.SparkleBlue;
                break;
            case PaletteMode.SparkleOrange:
                manager.GlobalPaletteMode = PaletteMode.SparkleOrange;
                break;
            case PaletteMode.SparklePurple:
                manager.GlobalPaletteMode = PaletteMode.SparklePurple;
                break;
            case PaletteMode.Custom:
                manager.GlobalPaletteMode = PaletteMode.Custom;
                break;
            default:
                manager.GlobalPaletteMode = PaletteMode.Office2010Blue;
                break;
        }

        themeManager.SetTheme(mode, manager);
    }

    /// <summary>
    /// Sets the custom theme.
    /// </summary>
    /// <param name="manager">The manager.</param>
    /// <param name="palette">The palette.</param>
    /// <param name="paletteFileName">Name of the palette file.</param>
    public static void SetCustomTheme(KryptonManager manager, KryptonCustomPaletteBase palette, string paletteFileName)
    {
        PaletteThemeSettingsManager paletteThemeSettingsManager = new();

        ThemeManager themeManager = new();

        themeManager.SetTheme(PaletteMode.Custom, manager);

        palette.Import(paletteFileName);

        paletteThemeSettingsManager.SetCustomThemeFilePath(paletteFileName);
    }

    internal static void EnableCustomThemeControls(KryptonLabel CustomTheme, KryptonTextBox CustomPath, KryptonButton ImportPalette, bool enabled)
    {
        CustomTheme.Enabled = enabled;

        CustomPath.Enabled = enabled;

        ImportPalette.Enabled = enabled;
    }
    #endregion
}