#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Theme.Switcher
{
    public class ThemeManager
    {
        #region Variables
        private ArrayList _themeList = new ArrayList();

        private SettingsManager _settingsManager = new SettingsManager();
        #endregion

        #region Methods
        /// <summary>Propagates the theme list.</summary>
        public static void PropagateThemeList()
        {
            ThemeManager manager = new ThemeManager();

            manager._themeList.Add("Professional - System");

            manager._themeList.Add("Professional - Office 2003");

            manager._themeList.Add("Office 2007 - Black");

            manager._themeList.Add("Office 2007 - Black (Dark Mode)");

            manager._themeList.Add("Office 2007 - Blue");

            manager._themeList.Add("Office 2007 - Blue (Dark Mode)");

            manager._themeList.Add("Office 2007 - Blue (Light Mode)");

            manager._themeList.Add("Office 2007 - Silver");

            manager._themeList.Add("Office 2007 - Silver (Dark Mode)");

            manager._themeList.Add("Office 2007 - Silver (Light Mode)");

            manager._themeList.Add("Office 2007 - White");

            manager._themeList.Add("Office 2010 - Black");

            manager._themeList.Add("Office 2010 - Black (Dark Mode)");

            manager._themeList.Add("Office 2010 - Blue");

            manager._themeList.Add("Office 2010 - Blue (Dark Mode)");

            manager._themeList.Add("Office 2010 - Blue (Light Mode)");

            manager._themeList.Add("Office 2010 - Silver");

            manager._themeList.Add("Office 2010 - Silver (Dark Mode)");

            manager._themeList.Add("Office 2010 - Silver (Light Mode)");

            manager._themeList.Add("Office 2010 - White");

            manager._themeList.Add("Office 2013");

            manager._themeList.Add("Office 2013 - White");

            manager._themeList.Add("Office 365 - Black");

            manager._themeList.Add("Office 365 - Black (Dark Mode)");

            manager._themeList.Add("Office 365 - Blue");

            manager._themeList.Add("Office 365 - Blue (Dark Mode)");

            manager._themeList.Add("Office 365 - Blue (Light Mode)");

            manager._themeList.Add("Office 365 - Silver");

            manager._themeList.Add("Office 365 - Silver (Dark Mode)");

            manager._themeList.Add("Office 365 - Silver (Light Mode)");

            manager._themeList.Add("Office 365 - White");

            manager._themeList.Add("Sparkle - Blue");

            manager._themeList.Add("Sparkle - Orange");

            manager._themeList.Add("Sparkle - Purple");

            manager._themeList.Add("Custom");
        }

        public static void PropagateThemeList(KryptonComboBox themeList)
        {
            themeList.Items.Add("Professional - System");

            themeList.Items.Add("Professional - Office 2003");

            themeList.Items.Add("Office 2007 - Black");

            themeList.Items.Add("Office 2007 - Black (Dark Mode)");

            themeList.Items.Add("Office 2007 - Blue");

            themeList.Items.Add("Office 2007 - Blue (Dark Mode)");

            themeList.Items.Add("Office 2007 - Blue (Light Mode)");

            themeList.Items.Add("Office 2007 - Silver");

            themeList.Items.Add("Office 2007 - Silver (Dark Mode)");

            themeList.Items.Add("Office 2007 - Silver (Light Mode)");

            themeList.Items.Add("Office 2007 - White");

            themeList.Items.Add("Office 2010 - Black");

            themeList.Items.Add("Office 2010 - Black (Dark Mode)");

            themeList.Items.Add("Office 2010 - Blue");

            themeList.Items.Add("Office 2010 - Blue (Dark Mode)");

            themeList.Items.Add("Office 2010 - Blue (Light Mode)");

            themeList.Items.Add("Office 2010 - Silver");

            themeList.Items.Add("Office 2010 - Silver (Dark Mode)");

            themeList.Items.Add("Office 2010 - Silver (Light Mode)");

            themeList.Items.Add("Office 2010 - White");

            themeList.Items.Add("Office 2013");

            themeList.Items.Add("Office 2013 - White");

            themeList.Items.Add("Office 365 - Black");

            themeList.Items.Add("Office 365 - Black (Dark Mode)");

            themeList.Items.Add("Office 365 - Blue");

            themeList.Items.Add("Office 365 - Blue (Dark Mode)");

            themeList.Items.Add("Office 365 - Blue (Light Mode)");

            themeList.Items.Add("Office 365 - Silver");

            themeList.Items.Add("Office 365 - Silver (Dark Mode)");

            themeList.Items.Add("Office 365 - Silver (Light Mode)");

            themeList.Items.Add("Office 365 - White");

            themeList.Items.Add("Sparkle - Blue");

            themeList.Items.Add("Sparkle - Orange");

            themeList.Items.Add("Sparkle - Purple");

            themeList.Items.Add("Custom");

            themeList.AutoCompleteCustomSource.Add("Professional - System");

            themeList.AutoCompleteCustomSource.Add("Professional - Office 2003");

            themeList.AutoCompleteCustomSource.Add("Office 2007 - Black");

            themeList.AutoCompleteCustomSource.Add("Office 2007 - Black (Dark Mode)");

            themeList.AutoCompleteCustomSource.Add("Office 2007 - Blue");

            themeList.AutoCompleteCustomSource.Add("Office 2007 - Blue (Dark Mode)");

            themeList.AutoCompleteCustomSource.Add("Office 2007 - Blue (Light Mode)");

            themeList.AutoCompleteCustomSource.Add("Office 2007 - Silver");

            themeList.AutoCompleteCustomSource.Add("Office 2007 - Silver (Dark Mode)");

            themeList.AutoCompleteCustomSource.Add("Office 2007 - Silver (Light Mode)");

            themeList.AutoCompleteCustomSource.Add("Office 2007 - White");

            themeList.AutoCompleteCustomSource.Add("Office 2010 - Black");

            themeList.AutoCompleteCustomSource.Add("Office 2010 - Black (Dark Mode)");

            themeList.AutoCompleteCustomSource.Add("Office 2010 - Blue");

            themeList.AutoCompleteCustomSource.Add("Office 2010 - Blue (Dark Mode)");

            themeList.AutoCompleteCustomSource.Add("Office 2010 - Blue (Light Mode)");

            themeList.AutoCompleteCustomSource.Add("Office 2010 - Silver");

            themeList.AutoCompleteCustomSource.Add("Office 2010 - Silver (Dark Mode)");

            themeList.AutoCompleteCustomSource.Add("Office 2010 - Silver (Light Mode)");

            themeList.AutoCompleteCustomSource.Add("Office 2010 - White");

            themeList.AutoCompleteCustomSource.Add("Office 2013");

            themeList.AutoCompleteCustomSource.Add("Office 2013 - White");

            themeList.AutoCompleteCustomSource.Add("Office 365 - Black");

            themeList.AutoCompleteCustomSource.Add("Office 365 - Black (Dark Mode)");

            themeList.AutoCompleteCustomSource.Add("Office 365 - Blue");

            themeList.AutoCompleteCustomSource.Add("Office 365 - Blue (Dark Mode)");

            themeList.AutoCompleteCustomSource.Add("Office 365 - Blue (Light Mode)");

            themeList.AutoCompleteCustomSource.Add("Office 365 - Silver");

            themeList.AutoCompleteCustomSource.Add("Office 365 - Silver (Dark Mode)");

            themeList.AutoCompleteCustomSource.Add("Office 365 - Silver (Light Mode)");

            themeList.AutoCompleteCustomSource.Add("Office 365 - White");

            themeList.AutoCompleteCustomSource.Add("Sparkle - Blue");

            themeList.AutoCompleteCustomSource.Add("Sparkle - Orange");

            themeList.AutoCompleteCustomSource.Add("Sparkle - Purple");

            themeList.AutoCompleteCustomSource.Add("Custom");

            themeList.AutoCompleteSource = AutoCompleteSource.CustomSource;

            themeList.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        }

        public static void SetPaletteTheme(PaletteModeManager modeManager, KryptonComboBox themeList)
        {
            switch (modeManager)
            {
                case PaletteModeManager.ProfessionalSystem:
                    themeList.SelectedIndex = 0;
                    break;
                case PaletteModeManager.ProfessionalOffice2003:
                    themeList.SelectedIndex = 1;
                    break;
                case PaletteModeManager.Office2007Blue:
                    themeList.SelectedIndex = 3;
                    break;
                case PaletteModeManager.Office2007Silver:
                    themeList.SelectedIndex = 4;
                    break;
                case PaletteModeManager.Office2007White:
                    themeList.SelectedIndex = 5;
                    break;
                case PaletteModeManager.Office2007Black:
                    themeList.SelectedIndex = 2;
                    break;
                case PaletteModeManager.Office2010Blue:
                    themeList.SelectedIndex = 7;
                    break;
                case PaletteModeManager.Office2010Silver:
                    themeList.SelectedIndex = 8;
                    break;
                case PaletteModeManager.Office2010White:
                    themeList.SelectedIndex = 9;
                    break;
                case PaletteModeManager.Office2010Black:
                    themeList.SelectedIndex = 6;
                    break;
                case PaletteModeManager.Office2013White:
                    themeList.SelectedIndex = 10;
                    break;
                case PaletteModeManager.Office365Black:
                    themeList.SelectedIndex = 11;
                    break;
                case PaletteModeManager.Office365Blue:
                    themeList.SelectedIndex = 12;
                    break;
                case PaletteModeManager.Office365Silver:
                    themeList.SelectedIndex = 13;
                    break;
                case PaletteModeManager.Office365White:
                    themeList.SelectedIndex = 14;
                    break;
                case PaletteModeManager.SparkleBlue:
                    themeList.SelectedIndex = 15;
                    break;
                case PaletteModeManager.SparkleOrange:
                    themeList.SelectedIndex = 16;
                    break;
                case PaletteModeManager.SparklePurple:
                    themeList.SelectedIndex = 17;
                    break;
                case PaletteModeManager.Custom:
                    themeList.SelectedIndex = 18;
                    break;
            }
        }

        public void ApplyTheme(string themeType, KryptonManager manager)
        {
            if (themeType == "Professional - System")
            {
                manager.GlobalPaletteMode = PaletteModeManager.ProfessionalSystem;

                ApplyTheme(PaletteModeManager.ProfessionalSystem);
            }
            else if (themeType == "Professional - Office 2003")
            {
                manager.GlobalPaletteMode = PaletteModeManager.ProfessionalOffice2003;

                ApplyTheme(PaletteModeManager.ProfessionalOffice2003);
            }
            else if (themeType == "Office 2007 - Black")
            {
                manager.GlobalPaletteMode = PaletteModeManager.Office2007Black;

                ApplyTheme(PaletteModeManager.Office2007Black);
            }
            else if (themeType == "Office 2007 - Blue")
            {
                manager.GlobalPaletteMode = PaletteModeManager.Office2007Blue;

                ApplyTheme(PaletteModeManager.Office2007Blue);
            }
            else if (themeType == "Office 2007 - Silver")
            {
                manager.GlobalPaletteMode = PaletteModeManager.Office2007Silver;

                ApplyTheme(PaletteModeManager.Office2007Silver);
            }
            else if (themeType == "Office 2007 - White")
            {
                manager.GlobalPaletteMode = PaletteModeManager.Office2007White;

                ApplyTheme(PaletteModeManager.Office2007White);
            }
            else if (themeType == "Office 2010 - Black")
            {
                manager.GlobalPaletteMode = PaletteModeManager.Office2010Black;

                ApplyTheme(PaletteModeManager.Office2010Black);
            }
            else if (themeType == "Office 2010 - Blue")
            {
                manager.GlobalPaletteMode = PaletteModeManager.Office2010Blue;

                ApplyTheme(PaletteModeManager.Office2010Blue);
            }
            else if (themeType == "Office 2010 - Silver")
            {
                manager.GlobalPaletteMode = PaletteModeManager.Office2010Silver;

                ApplyTheme(PaletteModeManager.Office2010Silver);
            }
            else if (themeType == "Office 2010 - White")
            {
                manager.GlobalPaletteMode = PaletteModeManager.Office2010White;

                ApplyTheme(PaletteModeManager.Office2010White);
            }
            else if (themeType == "Office 2013 - White")
            {
                manager.GlobalPaletteMode = PaletteModeManager.Office2013White;

                ApplyTheme(PaletteModeManager.Office2013White);
            }
            else if (themeType == "Office 365 - Black")
            {
                manager.GlobalPaletteMode = PaletteModeManager.Office365Black;

                ApplyTheme(PaletteModeManager.Office365Black);
            }
            else if (themeType == "Office 365 - Blue")
            {
                manager.GlobalPaletteMode = PaletteModeManager.Office365Blue;

                ApplyTheme(PaletteModeManager.Office365Blue);
            }
            else if (themeType == "Office 365 - Silver")
            {
                manager.GlobalPaletteMode = PaletteModeManager.Office365Silver;

                ApplyTheme(PaletteModeManager.Office365Silver);
            }
            else if (themeType == "Office 365 - White")
            {
                manager.GlobalPaletteMode = PaletteModeManager.Office365White;

                ApplyTheme(PaletteModeManager.Office365White);
            }
            else if (themeType == "Sparkle - Blue")
            {
                manager.GlobalPaletteMode = PaletteModeManager.SparkleBlue;

                ApplyTheme(PaletteModeManager.SparkleBlue);
            }
            else if (themeType == "Sparkle - Orange")
            {
                manager.GlobalPaletteMode = PaletteModeManager.SparkleOrange;

                ApplyTheme(PaletteModeManager.SparkleOrange);
            }
            else if (themeType == "Sparkle - Purple")
            {
                manager.GlobalPaletteMode = PaletteModeManager.SparklePurple;

                ApplyTheme(PaletteModeManager.SparklePurple);
            }
            else if (themeType == "Custom")
            {
                manager.GlobalPaletteMode = PaletteModeManager.Custom;

                ApplyTheme(PaletteModeManager.Custom);
            }
        }

        /// <summary>Applies the theme.</summary>
        /// <param name="theme">The theme.</param>
        private void ApplyTheme(PaletteModeManager theme) => _settingsManager.SetSelectedTheme(theme);
        #endregion

        #region Setters and Getters
        /// <summary>Sets the ThemeList to the value of value.</summary>
        /// <param name="value">The desired value of ThemeList.</param>
        public void SetThemeList(ArrayList value) => _themeList = value;

        /// <summary>Returns the value of the ThemeList.</summary>
        /// <returns>The value of the ThemeList.</returns>
        public ArrayList GetThemeList() => _themeList;

        #endregion
    }
}