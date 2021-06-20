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
        #endregion

        #region Methods
        /// <summary>Propagates the theme list.</summary>
        public static void PropagateThemeList()
        {
            ThemeManager manager = new ThemeManager();

            manager._themeList.Add("Professional - System");

            manager._themeList.Add("Professional - Office 2003");

            manager._themeList.Add("Office 2007 - Black");

            manager._themeList.Add("Office 2007 - Blue");

            manager._themeList.Add("Office 2007 - Silver");

            manager._themeList.Add("Office 2007 - White");

            manager._themeList.Add("Office 2010 - Black");

            manager._themeList.Add("Office 2010 - Blue");

            manager._themeList.Add("Office 2010 - Silver");

            manager._themeList.Add("Office 2010 - White");

            manager._themeList.Add("Office 2013");

            manager._themeList.Add("Office 2013 - White");

            manager._themeList.Add("Office 365 - Black");

            manager._themeList.Add("Office 365 - Blue");

            manager._themeList.Add("Office 365 - Silver");

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

            themeList.Items.Add("Office 2007 - Blue");

            themeList.Items.Add("Office 2007 - Silver");

            themeList.Items.Add("Office 2007 - White");

            themeList.Items.Add("Office 2010 - Black");

            themeList.Items.Add("Office 2010 - Blue");

            themeList.Items.Add("Office 2010 - Silver");

            themeList.Items.Add("Office 2010 - White");

            themeList.Items.Add("Office 2013");

            themeList.Items.Add("Office 2013 - White");

            themeList.Items.Add("Office 365 - Black");

            themeList.Items.Add("Office 365 - Blue");

            themeList.Items.Add("Office 365 - Silver");

            themeList.Items.Add("Office 365 - White");

            themeList.Items.Add("Sparkle - Blue");

            themeList.Items.Add("Sparkle - Orange");

            themeList.Items.Add("Sparkle - Purple");

            themeList.Items.Add("Custom");
        }
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