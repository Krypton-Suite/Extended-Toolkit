using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Settings
{
    internal class General
    {
        #region Identity

        public General()
        {
            
        }

        #endregion

        #region Implementation

        public static DialogResult ResetSettings(string settingsType, bool useKrypton = true)
        {
            if (useKrypton)
            {
                return KryptonMessageBox.Show($"WARNING! You are about to reset the {settingsType} settings back to their original state. This action cannot be undone!\nDo you want to proceed?",
                                          $"Reset {settingsType} Settings", MessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question);
            }
            else
            {
                return MessageBox.Show(
                    $"WARNING! You are about to reset the {settingsType} settings back to their original state. This action cannot be undone!\nDo you want to proceed?",
                    $"Reset {settingsType} Settings", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
        }

        public static DialogResult SaveSettings(string settingsType, bool useKrypton = true)
        {
            if (useKrypton)
            {
                return KryptonMessageBox.Show(
                    $"You have changed a {settingsType} setting value. Do you want to save these changes?",
                    $"{settingsType} Settings Changed", MessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question);
            }
            else
            {
                return MessageBox.Show(
                    $"You have changed a {settingsType} setting value. Do you want to save these changes?",
                    $"{settingsType} Settings Changed", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
        }

        #endregion
    }
}