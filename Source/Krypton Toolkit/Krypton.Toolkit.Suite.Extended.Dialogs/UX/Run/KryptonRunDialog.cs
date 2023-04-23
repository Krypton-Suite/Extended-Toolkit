
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

            kcmdOpenInExplorer.ImageLarge = GraphicsExtensions.SetIcon(GraphicsExtensions.ExtractIconFromFilePath(@"C:\Windows\explorer.exe").ToBitmap(), new(64, 64));

            kcmdOpenInExplorer.ImageSmall = GraphicsExtensions.SetIcon(GraphicsExtensions.ExtractIconFromFilePath(@"C:\Windows\explorer.exe").ToBitmap(), new(16, 16));
        }

        private void bsBrowse_Click(object sender, EventArgs e)
        {
            kcmbFilePath.Text = Browse();
        }

        private void kcmbFilePath_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(kcmbFilePath.Text))
            {
                bsReset.Visible = true;

                ksbRun.Enabled = true;

                pbxProcessIcon.Image = GraphicsExtensions.SetIcon(GraphicsExtensions.ExtractIconFromFilePath(kcmbFilePath.Text).ToBitmap(), new(32, 32));

                FileVersionInfo? info = null;

                //info

                FileInfo fi = new(kcmbFilePath.Text);

                ttAppIcon.SetToolTip(pbxProcessIcon, $"Name: {Path.GetFileName(kcmbFilePath.Text)}");
            }
            else
            {
                bsReset.Visible = false;

                ksbRun.Enabled = false;

                pbxProcessIcon.Image = null;
            }
        }

        private void AdjustStartPosition(RunDialogStartPosition startPosition)
        {
            switch (startPosition)
            {
                case RunDialogStartPosition.BottomLeft:
                    Location = new(0, Screen.PrimaryScreen.WorkingArea.Bottom - Height);
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

        private void pbxProcessIcon_MouseEnter(object sender, EventArgs e)
        {
        }

        private void kbtnSettings_Click(object sender, EventArgs e)
        {
            KryptonRunDialogOptions runDialogOptions = new();

            runDialogOptions.ShowDialog();
        }

        private string Browse(bool isFolderPicker = false)
        {
            string result = string.Empty;

            try
            {
                CommonOpenFileDialog cofd = new();

                cofd.IsFolderPicker = isFolderPicker;

                cofd.Title = @"Browse for a resource:";

                if (cofd.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    result = Path.GetFullPath(cofd.FileName);
                }
            }
            catch (Exception e)
            {
                ExceptionCapture.CaptureException(e);

                return result;
            }

            return result;
        }

        private void Reset()
        {
            kcmbFilePath.Text = string.Empty;

            bsReset.Visible = false;

            pbxProcessIcon.Image = null;
        }

        #endregion
    }
}
