using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Specialised.Dialogs
{
    public partial class KryptonRunDialog : KryptonForm
    {
        #region Instance Fields

        private bool _runTaskAsAdministrator;

        private readonly RunDialogIconVisibility _iconVisibility;

        private readonly RunDialogType _runDialogType;

        #endregion

        #region Public

        [DefaultValue(typeof(RunDialogIconVisibility), "RunDialogIconVisibility.VISIBLE"), Description("Shows the icon representation of the file, application etc in the text field.")]
        public RunDialogIconVisibility IconVisibility => _iconVisibility;

        #endregion

        public KryptonRunDialog(bool? runTaskAsAdministrator, RunDialogIconVisibility? iconVisibility, RunDialogType? runDialogType)
        {
            InitializeComponent();

            _runTaskAsAdministrator = runTaskAsAdministrator ?? false;

            _iconVisibility = iconVisibility ?? RunDialogIconVisibility.Visible;

            _runDialogType = runDialogType ?? RunDialogType.Textbox;

            UpdateControls(iconVisibility, runDialogType);

            Image shield = SystemIcons.Shield.ToBitmap();

            kcmdRunTaskAsAdministrator.ImageSmall = GraphicsExtensions.ScaleImage(shield, 16, 16);
        }

        private void UpdateControls(RunDialogIconVisibility? iconVisibility, RunDialogType? runDialogType)
        {
            switch (iconVisibility)
            {
                case RunDialogIconVisibility.Hidden:
                    pbxResourceIcon.Visible = false;
                    break;
                case RunDialogIconVisibility.Visible:
                    pbxResourceIcon.Visible = true;
                    break;
                case null:
                    pbxResourceIcon.Visible = false;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(iconVisibility), iconVisibility, null);
            }

            switch (runDialogType)
            {
                case RunDialogType.Combobox:
                    kbtnBrowse.Visible = true;

                    kcmbResourcePath.Visible = true;

                    ktxtResourcePath.Visible = false;
                    break;
                case RunDialogType.Textbox:
                    kbtnBrowse.Visible = false;

                    kcmbResourcePath.Visible = false;

                    ktxtResourcePath.Visible = true;
                    break;
                case null:
                    kbtnBrowse.Visible = false;

                    kcmbResourcePath.Visible = false;

                    ktxtResourcePath.Visible = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(runDialogType), runDialogType, null);
            }
        }

        private void ToggleLocateButtonVisibility(bool visible) => kbtnLocate.Visible = visible;

        private void LocateResource(string resourcePath)
        {
            try
            {
                if (!string.IsNullOrEmpty(resourcePath))
                {
                    Process.Start(@"explorer.exe", resourcePath);
                }
            }
            catch (Exception e)
            {
                DebugUtilities.NotImplemented(e.ToString());
            }
        }

        private void BrowseForFile()
        {
            try
            {
                KryptonOpenFileDialog openFileDialog = new() { Title = @"Select a resource:" };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    kcmbResourcePath.Text = Path.GetFullPath(openFileDialog.FileName);
                }
            }
            catch (Exception e)
            {
                DebugUtilities.NotImplemented(e.ToString());
            }
        }

        /// <summary>Determines whether [has file extension] [the specified path].</summary>
        /// <param name="path">The file path.</param>
        /// <returns><c>true</c> if [has file extension] [the specified path]; otherwise, <c>false</c>.</returns>
        private bool HasFileExtension(string path) => Path.HasExtension(path);

        /// <summary>Determines whether [is ComboBox string empty].</summary>
        /// <returns><c>true</c> if [is ComboBox string empty]; otherwise, <c>false</c>.</returns>
        private bool IsComboBoxStringEmpty() => string.IsNullOrEmpty(kcmbResourcePath.Text);

        /// <summary>Determines whether [is input a directory] [the specified input].</summary>
        /// <param name="input">The input.</param>
        /// <returns>
        ///   <c>true</c> if [is input a directory] [the specified input]; otherwise, <c>false</c>.</returns>
        private bool IsInputADirectory(Control input) => input.Text.EndsWith("\\");

        /// <summary>Runs the process.</summary>
        /// <param name="path">The file path.</param>
        private void RunProcess(string path)
        {
            try
            {
                ProcessStartInfo psi = new ProcessStartInfo(path);

                Process.Start(psi);

                Close();
            }
            catch (Exception exc)
            {
                DebugUtilities.NotImplemented(exc.ToString());
            }
        }

        /// <summary>Gets the application icon.</summary>
        /// <param name="path">The file path.</param>
        /// <returns>The application icon.</returns>
        private Image GetApplicationIcon(string path) => Icon.ExtractAssociatedIcon(path).ToBitmap();

        /// <summary>Enables the run button.</summary>
        /// <param name="value">if set to <c>true</c> [value].</param>
        private void EnableRunButton(bool value) => kbtnRun.Enabled = value;

        private void kcmdRunTaskAsAdministrator_Execute(object? sender, EventArgs e)
        {
            kbtnRun.Values.UseAsUACElevationButton = true;

            try
            {
                if (_runDialogType == RunDialogType.Combobox)
                {

                }
                else if (_runDialogType == RunDialogType.Textbox)
                {

                }
            }
            catch (Exception exception)
            {
                DebugUtilities.NotImplemented(exception.ToString());
            }
        }

        private void kcmdRunTaskAsNormalUser_Execute(object? sender, EventArgs e)
        {
            kbtnRun.Values.UseAsUACElevationButton = false;

            try
            {
                if (_runDialogType == RunDialogType.Combobox)
                {
                    Process.Start(kcmbResourcePath.Text);
                }
                else if (_runDialogType == RunDialogType.Textbox)
                {
                    Process.Start(ktxtResourcePath.Text);
                }
            }
            catch (Exception exception)
            {
                DebugUtilities.NotImplemented(exception.ToString());
            }
        }

        private void kbtnRun_Click(object? sender, EventArgs e)
        {
            if (kbtnRun.Values.UseAsUACElevationButton)
            {
                kcmdRunTaskAsAdministrator.PerformExecute();
            }
            else
            {
                kcmdRunTaskAsNormalUser.PerformExecute();
            }
        }
    }
}
