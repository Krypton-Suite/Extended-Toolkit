namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    public partial class SharpUpdateAcceptForm : KryptonForm
    {
        #region Instance Fields

        /// <summary>
        /// The program to update's info
        /// </summary>
        private SharpUpdateLocalAppInfo _applicationInfo;

        /// <summary>
        /// The update info from the update.xml
        /// </summary>
        private SharpUpdateXml _updateInfo;

        /// <summary>
        /// The update info display form
        /// </summary>
        private SharpUpdateInfoForm _updateInfoForm;

        #endregion

        public SharpUpdateAcceptForm(SharpUpdateLocalAppInfo applicationInfo, SharpUpdateXml updateInfo, int numCurUpdate, int numTotalUpdate)
        {
            InitializeComponent();

            _applicationInfo = applicationInfo;

            _updateInfo = updateInfo;

            Text = $@"{_applicationInfo.ApplicationName} - ({numCurUpdate}/{numTotalUpdate}) {SharpUpdateLanguageManager.GeneralStrings.Title}";

            // Assigns the icon if it isn't null
            if (_applicationInfo.ApplicationIcon != null)
            {
                Icon = _applicationInfo.ApplicationIcon;
            }

            // Adds the update version # to the form
            kwlNewVersion.Text = updateInfo.Tag != JobType.REMOVE ?
                string.Format(updateInfo.Tag == JobType.UPDATE ? $"{SharpUpdateLanguageManager.GeneralStrings.Update}: {Path.GetFileName(_applicationInfo.ApplicationPath)}\n{SharpUpdateLanguageManager.GeneralStrings.NewVersion}: {_updateInfo.Version}" : $"{SharpUpdateLanguageManager.GeneralStrings.New}: {Path.GetFileName(_applicationInfo.ApplicationPath)}\n{SharpUpdateLanguageManager.GeneralStrings.Version}: {_updateInfo.Version}") :
                $"{SharpUpdateLanguageManager.AcceptFormStrings.Remove}: {Path.GetFileName(_applicationInfo.ApplicationPath)}";

            kbtnNo.Text = KryptonManager.Strings.GeneralStrings.No;

            kbtnYes.Text = KryptonManager.Strings.GeneralStrings.Yes;
        }

        private void kbtnYes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;

            Close();
        }

        private void kbtnNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;

            Close();
        }

        private void kbtnDetails_Click(object sender, EventArgs e)
        {
            if (_updateInfoForm == null)
            {
                _updateInfoForm = new SharpUpdateInfoForm(_applicationInfo, _updateInfo);
            }

            // Shows the details form
            _updateInfoForm.ShowDialog(this);
        }
    }
}