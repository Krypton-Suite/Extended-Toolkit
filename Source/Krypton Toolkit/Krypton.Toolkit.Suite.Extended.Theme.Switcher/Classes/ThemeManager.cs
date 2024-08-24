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

            manager._themeList.Add("Microsoft 365 - Black");

            manager._themeList.Add("Microsoft 365 - Black (Dark Mode)");

            manager._themeList.Add("Microsoft 365 - Blue");

            manager._themeList.Add("Microsoft 365 - Blue (Dark Mode)");

            manager._themeList.Add("Microsoft 365 - Blue (Light Mode)");

            manager._themeList.Add("Microsoft 365 - Silver");

            manager._themeList.Add("Microsoft 365 - Silver (Dark Mode)");

            manager._themeList.Add("Microsoft 365 - Silver (Light Mode)");

            manager._themeList.Add("Microsoft 365 - White");

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

            themeList.Items.Add("Microsoft 365 - Black");

            themeList.Items.Add("Microsoft 365 - Black (Dark Mode)");

            themeList.Items.Add("Microsoft 365 - Blue");

            themeList.Items.Add("Microsoft 365 - Blue (Dark Mode)");

            themeList.Items.Add("Microsoft 365 - Blue (Light Mode)");

            themeList.Items.Add("Microsoft 365 - Silver");

            themeList.Items.Add("Microsoft 365 - Silver (Dark Mode)");

            themeList.Items.Add("Microsoft 365 - Silver (Light Mode)");

            themeList.Items.Add("Microsoft 365 - White");

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

            themeList.AutoCompleteCustomSource.Add("Microsoft 365 - Black");

            themeList.AutoCompleteCustomSource.Add("Microsoft 365 - Black (Dark Mode)");

            themeList.AutoCompleteCustomSource.Add("Microsoft 365 - Blue");

            themeList.AutoCompleteCustomSource.Add("Microsoft 365 - Blue (Dark Mode)");

            themeList.AutoCompleteCustomSource.Add("Microsoft 365 - Blue (Light Mode)");

            themeList.AutoCompleteCustomSource.Add("Microsoft 365 - Silver");

            themeList.AutoCompleteCustomSource.Add("Microsoft 365 - Silver (Dark Mode)");

            themeList.AutoCompleteCustomSource.Add("Microsoft 365 - Silver (Light Mode)");

            themeList.AutoCompleteCustomSource.Add("Microsoft 365 - White");

            themeList.AutoCompleteCustomSource.Add("Sparkle - Blue");

            themeList.AutoCompleteCustomSource.Add("Sparkle - Orange");

            themeList.AutoCompleteCustomSource.Add("Sparkle - Purple");

            themeList.AutoCompleteCustomSource.Add("Custom");

            themeList.AutoCompleteSource = AutoCompleteSource.CustomSource;

            if (themeList.DropDownStyle == ComboBoxStyle.DropDownList)
            {
                themeList.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }
        }

        public static void SetPaletteTheme(PaletteMode modeManager, KryptonComboBox themeList)
        {
            switch (modeManager)
            {
                case PaletteMode.ProfessionalSystem:
                    themeList.SelectedIndex = 0;
                    break;
                case PaletteMode.ProfessionalOffice2003:
                    themeList.SelectedIndex = 1;
                    break;
                case PaletteMode.Office2007Blue:
                    themeList.SelectedIndex = 3;
                    break;
                case PaletteMode.Office2007Silver:
                    themeList.SelectedIndex = 4;
                    break;
                case PaletteMode.Office2007White:
                    themeList.SelectedIndex = 5;
                    break;
                case PaletteMode.Office2007Black:
                    themeList.SelectedIndex = 2;
                    break;
                case PaletteMode.Office2010Blue:
                    themeList.SelectedIndex = 7;
                    break;
                case PaletteMode.Office2010Silver:
                    themeList.SelectedIndex = 8;
                    break;
                case PaletteMode.Office2010White:
                    themeList.SelectedIndex = 9;
                    break;
                case PaletteMode.Office2010Black:
                    themeList.SelectedIndex = 6;
                    break;
                case PaletteMode.Office2013White:
                    themeList.SelectedIndex = 10;
                    break;
                case PaletteMode.Microsoft365Black:
                    themeList.SelectedIndex = 11;
                    break;
                case PaletteMode.Microsoft365Blue:
                    themeList.SelectedIndex = 12;
                    break;
                case PaletteMode.Microsoft365Silver:
                    themeList.SelectedIndex = 13;
                    break;
                case PaletteMode.Microsoft365White:
                    themeList.SelectedIndex = 14;
                    break;
                case PaletteMode.SparkleBlue:
                    themeList.SelectedIndex = 15;
                    break;
                case PaletteMode.SparkleOrange:
                    themeList.SelectedIndex = 16;
                    break;
                case PaletteMode.SparklePurple:
                    themeList.SelectedIndex = 17;
                    break;
                case PaletteMode.Custom:
                    themeList.SelectedIndex = 18;
                    break;
            }
        }

        public void ApplyTheme(string themeType, KryptonManager manager)
        {
            if (themeType == "Professional - System")
            {
                manager.GlobalPaletteMode = PaletteMode.ProfessionalSystem;

                ApplyTheme(PaletteMode.ProfessionalSystem);
            }
            else if (themeType == "Professional - Office 2003")
            {
                manager.GlobalPaletteMode = PaletteMode.ProfessionalOffice2003;

                ApplyTheme(PaletteMode.ProfessionalOffice2003);
            }
            else if (themeType == "Office 2007 - Black")
            {
                manager.GlobalPaletteMode = PaletteMode.Office2007Black;

                ApplyTheme(PaletteMode.Office2007Black);
            }
            else if (themeType == "Office 2007 - Blue")
            {
                manager.GlobalPaletteMode = PaletteMode.Office2007Blue;

                ApplyTheme(PaletteMode.Office2007Blue);
            }
            else if (themeType == "Office 2007 - Silver")
            {
                manager.GlobalPaletteMode = PaletteMode.Office2007Silver;

                ApplyTheme(PaletteMode.Office2007Silver);
            }
            else if (themeType == "Office 2007 - White")
            {
                manager.GlobalPaletteMode = PaletteMode.Office2007White;

                ApplyTheme(PaletteMode.Office2007White);
            }
            else if (themeType == "Office 2010 - Black")
            {
                manager.GlobalPaletteMode = PaletteMode.Office2010Black;

                ApplyTheme(PaletteMode.Office2010Black);
            }
            else if (themeType == "Office 2010 - Blue")
            {
                manager.GlobalPaletteMode = PaletteMode.Office2010Blue;

                ApplyTheme(PaletteMode.Office2010Blue);
            }
            else if (themeType == "Office 2010 - Silver")
            {
                manager.GlobalPaletteMode = PaletteMode.Office2010Silver;

                ApplyTheme(PaletteMode.Office2010Silver);
            }
            else if (themeType == "Office 2010 - White")
            {
                manager.GlobalPaletteMode = PaletteMode.Office2010White;

                ApplyTheme(PaletteMode.Office2010White);
            }
            else if (themeType == "Office 2013 - White")
            {
                manager.GlobalPaletteMode = PaletteMode.Office2013White;

                ApplyTheme(PaletteMode.Office2013White);
            }
            else if (themeType == "Microsoft 365 - Black")
            {
                manager.GlobalPaletteMode = PaletteMode.Microsoft365Black;

                ApplyTheme(PaletteMode.Microsoft365Black);
            }
            else if (themeType == "Microsoft 365 - Blue")
            {
                manager.GlobalPaletteMode = PaletteMode.Microsoft365Blue;

                ApplyTheme(PaletteMode.Microsoft365Blue);
            }
            else if (themeType == "Microsoft 365 - Silver")
            {
                manager.GlobalPaletteMode = PaletteMode.Microsoft365Silver;

                ApplyTheme(PaletteMode.Microsoft365Silver);
            }
            else if (themeType == "Microsoft 365 - White")
            {
                manager.GlobalPaletteMode = PaletteMode.Microsoft365White;

                ApplyTheme(PaletteMode.Microsoft365White);
            }
            else if (themeType == "Sparkle - Blue")
            {
                manager.GlobalPaletteMode = PaletteMode.SparkleBlue;

                ApplyTheme(PaletteMode.SparkleBlue);
            }
            else if (themeType == "Sparkle - Orange")
            {
                manager.GlobalPaletteMode = PaletteMode.SparkleOrange;

                ApplyTheme(PaletteMode.SparkleOrange);
            }
            else if (themeType == "Sparkle - Purple")
            {
                manager.GlobalPaletteMode = PaletteMode.SparklePurple;

                ApplyTheme(PaletteMode.SparklePurple);
            }
            else if (themeType == "Custom")
            {
                manager.GlobalPaletteMode = PaletteMode.Custom;

                ApplyTheme(PaletteMode.Custom);
            }
        }

        /// <summary>Applies the theme.</summary>
        /// <param name="theme">The theme.</param>
        private void ApplyTheme(PaletteMode theme) => _settingsManager.SetSelectedTheme(theme);
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