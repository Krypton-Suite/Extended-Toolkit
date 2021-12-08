#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public class GlobalUtilityMethods
    {
        #region Constructor
        public GlobalUtilityMethods()
        {

        }
        #endregion

        #region Methods        
        /// <summary>
        /// Not the implemented yet.
        /// </summary>
        /// <param name="featureName">Name of the feature.</param>
        public static void NotImplementedYet(string featureName = null)
        {
            if (featureName != null)
            {
                KryptonMessageBox.Show($"The feature: { featureName } is not implemented or fully functional yet. Please check back again later.", "Incomplete Feature", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                KryptonMessageBox.Show("This is not implemented or fully functional yet. Please check back again later.", "Incomplete Feature", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }
}