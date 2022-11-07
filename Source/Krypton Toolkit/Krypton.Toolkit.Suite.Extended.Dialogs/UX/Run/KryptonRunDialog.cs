namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    public partial class KryptonRunDialog : KryptonFormExtended
    {
        #region Instance Fields

        private bool _showApplicationIconPreview, _showOptionsButton, _showResetButton;

        #endregion

        public KryptonRunDialog(RunDialogStartPosition startPosition, bool showApplicationIconPreview = true, bool showOptionsButton = false, bool showResetButton = true)
        {
            InitializeComponent();

            _showApplicationIconPreview = showApplicationIconPreview;

            _showOptionsButton = showOptionsButton;

            _showResetButton = showResetButton;

            Setup();

            AdjustStartPosition(startPosition);
        }

        private void KryptonRunDialog_Load(object sender, EventArgs e)
        {

        }

        #region Implementation
        private void Setup()
        {
            kwlHeader.Text = Properties.Resources.DefaultRunDialogContentText;

            kryptonLabel1.Text = Properties.Resources.OpenDefaultText;

            pictureBox1.Image = Properties.Resources.Run_481;

            Icon = Properties.Resources.Run_48;

            kbtnSettings.Values.Image = Properties.Resources.Settings_16_x_16;

            bsReset.Image = Properties.Resources.Reset_16_x_16;

            bsReset.Visible = _showResetButton;

            kbtnSettings.Visible = _showOptionsButton;

            kcmbFilePath.CueHint.CueHintText = Properties.Resources.InputBoxCueText;

            kcmdOpenAsAdministrator.Text = Properties.Resources.OpenAsAdministratorCommandText;

            kcmdOpenInExplorer.Text = Properties.Resources.OpenInExplorerCommandText;
        }

        private void AdjustStartPosition(RunDialogStartPosition startPosition)
        {
            switch (startPosition)
            {
                case RunDialogStartPosition.BottomLeft:
                    Location = new Point(0, Screen.PrimaryScreen.WorkingArea.Bottom - Height);
                    break;
                case RunDialogStartPosition.BottomRight:
                    break;
                case RunDialogStartPosition.CentreScreen:
                    StartPosition = FormStartPosition.CenterScreen;
                    break;
                default:
                    StartPosition = FormStartPosition.Manual;
                    break;
            }
        }

        #endregion
    }
}
