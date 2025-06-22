namespace Krypton.Toolkit.Suite.Extended.Settings.Classes;

public class SpecialisedDialogBooleanSettingsManager
{
    #region Instance Fields

    private SpecialisedDialogBooleanSettings _specialisedDialogBooleanSettings = new();

    #endregion

    #region Identity

    public SpecialisedDialogBooleanSettingsManager()
    {

    }

    #endregion

    #region Setters and Getters

    /// <summary>Sets the is run dialog uac shield shown.</summary>
    /// <param name="isRunDialogUACShieldShown">if set to <c>true</c> [is run dialog uac shield shown].</param>
    public void SetIsRunDialogUACShieldShown(bool isRunDialogUACShieldShown) => _specialisedDialogBooleanSettings.IsRunDialogUACShieldShown = isRunDialogUACShieldShown;

    /// <summary>Gets the is run dialog uac shield shown.</summary>
    /// <returns></returns>
    public bool GetIsRunDialogUACShieldShown() => _specialisedDialogBooleanSettings.IsRunDialogUACShieldShown;

    #endregion

    #region Implementation

    public void SaveSpecialisedDialogBooleanSettings(bool usePrompt = false)
    {
        if (usePrompt)
        {
            DialogResult result = KryptonMessageBox.Show("Do you want to save the current specialised dialog settings?", "Save Confirmation", KryptonMessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _specialisedDialogBooleanSettings.Save();
            }
            else
            {
                ResetSpecialisedDialogBooleanSettings(usePrompt);
            }
        }
        else
        {
            _specialisedDialogBooleanSettings.Save();
        }
    }

    public void ResetSpecialisedDialogBooleanSettings(bool usePrompt = false)
    {
        if (usePrompt)
        {
            DialogResult result = KryptonMessageBox.Show("This action will reset the specialised dialog values. Do you want to continue?", "Reset Colour Values", KryptonMessageBoxButtons.YesNo, KryptonMessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ResetSpecialisedDialogBooleanSettings();

                SaveSpecialisedDialogBooleanSettings(usePrompt);
            }
            else
            {
                ResetSpecialisedDialogBooleanSettings();

                SaveSpecialisedDialogBooleanSettings();
            }
        }
    }

    private void ResetSpecialisedDialogBooleanSettings()
    {
        SetIsRunDialogUACShieldShown(false);
    }

    #endregion
}