#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Collections;

namespace Krypton.Toolkit.Suite.Extended.Core
{
    internal class ThemeManager
    {
        #region Variables
        private ArrayList _themeList;
        private AutoCompleteStringCollection _themeCollection;
        private PaletteThemeSettingsManager _themeSettingsManager = new PaletteThemeSettingsManager();
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
            _themeCollection = new AutoCompleteStringCollection();

            _themeList = new ArrayList();

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
            _themeList = new ArrayList();

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

        private void SetTheme(PaletteModeManager mode, KryptonManager manager)
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
        public static void SwitchTheme(PaletteModeManager mode, KryptonManager manager)
        {
            ThemeManager themeManager = new ThemeManager();

            switch (mode)
            {
                case PaletteModeManager.ProfessionalSystem:
                    manager.GlobalPaletteMode = PaletteModeManager.ProfessionalSystem;
                    break;
                case PaletteModeManager.ProfessionalOffice2003:
                    manager.GlobalPaletteMode = PaletteModeManager.ProfessionalOffice2003;
                    break;
                case PaletteModeManager.Office2007Blue:
                    manager.GlobalPaletteMode = PaletteModeManager.Office2007Blue;
                    break;
                case PaletteModeManager.Office2007Silver:
                    manager.GlobalPaletteMode = PaletteModeManager.Office2007Silver;
                    break;
                case PaletteModeManager.Office2007Black:
                    manager.GlobalPaletteMode = PaletteModeManager.Office2007Black;
                    break;
                case PaletteModeManager.Office2010Blue:
                    manager.GlobalPaletteMode = PaletteModeManager.Office2010Blue;
                    break;
                case PaletteModeManager.Office2010Silver:
                    manager.GlobalPaletteMode = PaletteModeManager.Office2010Silver;
                    break;
                case PaletteModeManager.Office2010Black:
                    manager.GlobalPaletteMode = PaletteModeManager.Office2010Black;
                    break;
                case PaletteModeManager.Office2013White:
                    manager.GlobalPaletteMode = PaletteModeManager.Office2013White;
                    break;
                case PaletteModeManager.SparkleBlue:
                    manager.GlobalPaletteMode = PaletteModeManager.SparkleBlue;
                    break;
                case PaletteModeManager.SparkleOrange:
                    manager.GlobalPaletteMode = PaletteModeManager.SparkleOrange;
                    break;
                case PaletteModeManager.SparklePurple:
                    manager.GlobalPaletteMode = PaletteModeManager.SparklePurple;
                    break;
                case PaletteModeManager.Custom:
                    manager.GlobalPaletteMode = PaletteModeManager.Custom;
                    break;
                default:
                    manager.GlobalPaletteMode = PaletteModeManager.Office2010Blue;
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
        public static void SetCustomTheme(KryptonManager manager, KryptonPalette palette, string paletteFileName)
        {
            PaletteThemeSettingsManager paletteThemeSettingsManager = new PaletteThemeSettingsManager();

            ThemeManager themeManager = new ThemeManager();

            themeManager.SetTheme(PaletteModeManager.Custom, manager);

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
}