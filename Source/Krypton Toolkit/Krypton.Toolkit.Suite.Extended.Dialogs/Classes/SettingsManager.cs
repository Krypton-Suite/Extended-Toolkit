namespace Krypton.Toolkit.Suite.Extended.Dialogs;

internal class SettingsManager
{
    #region Instance Fields

    private Properties.Settings _mySettings = new();

    #endregion

    #region Identity

    public SettingsManager()
    {

    }

    #endregion

    #region Implementation

    public void SetShowApplicationIconPreview(bool showApplicationIconPreview) => _mySettings.ShowApplicationIconPreview = showApplicationIconPreview;

    public bool GetShowApplicationIconPreview() => _mySettings.ShowApplicationIconPreview;

    public void SetShowOptionsButton(bool showOptionsButton) => _mySettings.ShowOptionsButton = showOptionsButton;

    public bool GetShowOptionsButton() => _mySettings.ShowOptionsButton;

    public void GetRunDialogHistory(StringCollection runDialogHistory) => _mySettings.RunDialogHistory = runDialogHistory;

    public StringCollection GetRunDialogHistory() => _mySettings.RunDialogHistory;

    #endregion
}