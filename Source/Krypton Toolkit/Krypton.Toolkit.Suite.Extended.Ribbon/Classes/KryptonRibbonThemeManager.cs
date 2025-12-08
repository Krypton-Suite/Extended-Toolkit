#region MIT License
/*
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

namespace Krypton.Toolkit.Suite.Extended.Ribbon;

internal class KryptonRibbonThemeManager
{
    #region Theme Array

    /// <summary>
    /// The supported themes
    /// </summary>
    // TODO: This should use the list from Z:\GitHub\Krypton-Suite\Standard-Toolkit\Source\Krypton Components\Krypton.Toolkit\Converters\PaletteModeConverter.cs
    private static readonly BiDictionary<string, PaletteMode> _supportedThemes = new(
        new Dictionary<string, PaletteMode>
        {
            { @"Professional - System", PaletteMode.ProfessionalSystem },
            { @"Professional - Office 2003", PaletteMode.ProfessionalOffice2003 },
            { @"Office 2007 - Blue", PaletteMode.Office2007Blue },
            { @"Office 2007 - Blue (Dark Mode)", PaletteMode.Office2007BlueDarkMode },
            { @"Office 2007 - Blue (Light Mode)", PaletteMode.Office2007BlueLightMode },
            { @"Office 2007 - Silver", PaletteMode.Office2007Silver },
            { @"Office 2007 - Silver (Dark Mode)", PaletteMode.Office2007SilverDarkMode },
            { @"Office 2007 - Silver (Light Mode)", PaletteMode.Office2007SilverLightMode },
            { @"Office 2007 - White", PaletteMode.Office2007White },
            { @"Office 2007 - Black", PaletteMode.Office2007Black },
            { @"Office 2007 - Black (Dark Mode)", PaletteMode.Office2007BlackDarkMode },
            //{ @"Office 2007 - Dark Gray", PaletteMode.Office2007DarkGray },
            { @"Office 2010 - Blue", PaletteMode.Office2010Blue },
            { @"Office 2010 - Blue (Dark Mode)", PaletteMode.Office2010BlueDarkMode },
            { @"Office 2010 - Blue (Light Mode)", PaletteMode.Office2010BlueLightMode },
            { @"Office 2010 - Silver", PaletteMode.Office2010Silver },
            { @"Office 2010 - Silver (Dark Mode)", PaletteMode.Office2010SilverDarkMode },
            { @"Office 2010 - Silver (Light Mode)", PaletteMode.Office2010SilverLightMode },
            { @"Office 2010 - White", PaletteMode.Office2010White },
            { @"Office 2010 - Black", PaletteMode.Office2010Black },
            { @"Office 2010 - Black (Dark Mode)", PaletteMode.Office2010BlackDarkMode },
            //{ @"Office 2010 - Dark Gray", PaletteMode.Office2010DarkGray },
            //{ @"Office 2013 - Dark Gray", PaletteMode.Office2013DarkGray },
            //{ @"Office 2013", PaletteMode.Office2013 },
            { @"Office 2013 - White", PaletteMode.Office2013White },
            { @"Sparkle - Blue", PaletteMode.SparkleBlue },
            { @"Sparkle - Blue (Dark Mode)", PaletteMode.SparkleBlueDarkMode },
            { @"Sparkle - Blue (Light Mode)", PaletteMode.SparkleBlueLightMode },
            { @"Sparkle - Orange", PaletteMode.SparkleOrange },
            { @"Sparkle - Orange (Dark Mode)", PaletteMode.SparkleOrangeDarkMode },
            { @"Sparkle - Orange (Light Mode)", PaletteMode.SparkleOrangeLightMode },
            { @"Sparkle - Purple", PaletteMode.SparklePurple },
            { @"Sparkle - Purple (Dark Mode)", PaletteMode.SparklePurpleDarkMode },
            { @"Sparkle - Purple (Light Mode)", PaletteMode.SparklePurpleLightMode },
            { @"Microsoft 365 - Blue", PaletteMode.Microsoft365Blue },
            { @"Microsoft 365 - Blue (Dark Mode)", PaletteMode.Microsoft365BlueDarkMode },
            { @"Microsoft 365 - Blue (Light Mode)", PaletteMode.Microsoft365BlueLightMode },
            { @"Microsoft 365 - Silver", PaletteMode.Microsoft365Silver },
            { @"Microsoft 365 - Silver (Dark Mode)", PaletteMode.Microsoft365SilverDarkMode },
            { @"Microsoft 365 - Silver (Light Mode)", PaletteMode.Microsoft365SilverLightMode },
            { @"Microsoft 365 - White", PaletteMode.Microsoft365White },
            { @"Microsoft 365 - Black", PaletteMode.Microsoft365Black },
            { @"Microsoft 365 - Black (Dark Mode)", PaletteMode.Microsoft365BlackDarkMode },
            //{ @"Microsoft 365 - Dark Gray", PaletteMode.Microsoft365DarkGray },
            { @"Custom", PaletteMode.Custom }
        });

    #endregion

    #region Instance Fields

    #endregion

    #region Properties        
    /// <summary>
    /// Gets the supported theme array.
    /// </summary>
    /// <value>
    /// The supported theme array.
    /// </value>
    public static ICollection<string> SupportedInternalThemeNames => _supportedThemes.GetAllFirsts();

    #endregion

    #region Methods
    /// <summary>
    /// Applies the theme.
    /// </summary>
    /// <param name="mode">The mode.</param>
    /// <param name="manager">The manager.</param>
    private static void ApplyTheme(PaletteMode mode, KryptonManager manager) => manager.GlobalPaletteMode = mode;

    /// <summary>Gets the palette mode.</summary>
    /// <param name="manager">The manager.</param>
    /// <returns>The current <see cref="PaletteMode"/>.</returns>
    public static PaletteMode GetPaletteMode(KryptonManager manager) => ReturnPaletteMode(manager.GlobalPaletteMode);

    private static PaletteMode ReturnPaletteMode(string themeName)
    {
        // Note: Needs to be filled out
        return PaletteMode.Custom;
    }

    /// <summary>Returns the palette mode.</summary>
    /// <param name="paletteMode">The palette mode manager.</param>
    /// <returns>The selected <see cref="PaletteMode"/>.</returns>
    private static PaletteMode ReturnPaletteMode(PaletteMode paletteMode)
    {
        return paletteMode;
    }

    /// <summary>
    /// Applies the theme.
    /// </summary>
    /// <param name="themeName">Name of the theme.</param>
    /// <param name="manager">The manager.</param>
    public static void ApplyTheme(string themeName, KryptonManager manager)
    {
        ApplyTheme(_supportedThemes.GetByFirst(themeName), manager);
    }

    /// <summary>
    /// Sets the theme.
    /// </summary>
    /// <param name="themeName">Name of the theme.</param>
    /// <param name="manager">The manager.</param>
    public static void SetTheme(string themeName, KryptonManager manager)
    {
        try
        {
            ApplyTheme(themeName, manager);

            ApplyGlobalTheme(manager, GetPaletteMode(manager));
        }
        catch (Exception exc)
        {
            DebugUtilities.NotImplemented(exc.ToString());
        }
    }

    /// <summary>
    /// Returns the palette mode manager as string.
    /// </summary>
    /// <param name="PaletteMode">The palette mode manager.</param>
    /// <param name="manager">The manager.</param>
    /// <returns>The chosen theme as a string.</returns>
    public static string ReturnPaletteModeAsString(PaletteMode PaletteMode, KryptonManager? manager = null)
    {
        var paletteMode = manager?.GlobalPaletteMode ?? PaletteMode;

        return _supportedThemes.GetBySecond(paletteMode);
    }

    /// <summary>
    /// Loads the custom theme.
    /// </summary>
    /// <param name="palette">The palette.</param>
    /// <param name="manager">The manager.</param>
    /// <param name="themeFile">A custom theme file.</param>
    /// <param name="silent">if set to <c>true</c> [silent].</param>
    public static void LoadCustomTheme(KryptonCustomPaletteBase palette, KryptonManager manager, string themeFile = "", bool silent = false)
    {
        try
        {
            //throw new ApplicationException(@"Currently not implemented correctly");

            // Declare new instances
            palette = new KryptonCustomPaletteBase();

            manager = new KryptonManager();

            // Prompt user for palette definition

            // TODO: Add silent option
            if (silent)
            {
                if (themeFile is not ("" and ""))
                {
                    palette.Import(themeFile, silent);
                }
            }
            else
            {
                palette.Import();
            }

            // Set manager
            manager.GlobalCustomPalette = palette;

            ApplyTheme(PaletteMode.Custom, manager);
        }
        catch (Exception exc)
        {
            DebugUtilities.NotImplemented(exc.ToString());
        }
    }

    /// <summary>
    /// Returns the palette mode as string.
    /// </summary>
    /// <param name="paletteMode">The palette mode.</param>
    /// <returns></returns>
    public static string ReturnPaletteModeAsString(PaletteMode paletteMode)
    {
        PaletteModeConverter modeConverter = new();

        return modeConverter.ConvertToString(paletteMode);
    }

    /// <summary>
    /// Applies the global theme.
    /// </summary>
    /// <param name="manager">The manager.</param>
    /// <param name="paletteMode">The palette mode manager.</param>
    public static void ApplyGlobalTheme(KryptonManager manager, PaletteMode paletteMode)
    {
        try
        {
            manager.GlobalPaletteMode = paletteMode;
        }
        catch (Exception exc)
        {
            DebugUtilities.NotImplemented(exc.ToString());
        }
    }

    /// <summary>
    /// Propagates the theme selector.
    /// </summary>
    /// <param name="target">The target.</param>
    /// <param name="excludePartials">do not include any string containing</param>
    public static void PropagateThemeSelector(KryptonRibbonGroupComboBox target, params string[] excludePartials) => AddToCollection(target.Items, excludePartials);

    /// <summary>
    /// Propagates the theme selector.
    /// </summary>
    /// <param name="target">The target.</param>
    /// <param name="excludePartials">do not include any string containing</param>
    public static void PropagateThemeSelector(KryptonRibbonGroupDomainUpDown target, params string[] excludePartials) => AddToCollection(target.Items, excludePartials);

    private static void AddToCollection(IList target, string[] excludes)
    {
        try
        {
            foreach (var theme in SupportedInternalThemeNames)
            {
                if (!excludes.Any(t => theme.IndexOf(t, StringComparison.InvariantCultureIgnoreCase) > -1))
                {
                    target.Add(theme);
                }
            }
        }
        catch (Exception exc)
        {
            DebugUtilities.NotImplemented(exc.ToString());
        }
    }

    /// <summary>
    /// Applies the theme manager mode.
    /// </summary>
    /// <param name="themeName">Name of the theme.</param>
    /// <returns>The <see cref="PaletteMode"/> equivalent.</returns>
    public static PaletteMode GetThemeManagerMode(string themeName) => _supportedThemes.GetByFirst(themeName);
    #endregion
}