#region License

/*
 * The MIT License
 *
 * Copyright (c) 2022 Deadpikle
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

#endregion

using Application = System.Windows.Forms.Application;
using Size = System.Drawing.Size;

namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    public partial class NetSparkleDownloadProgressWindow : KryptonForm, IDownloadProgress
    {
        #region Instance Fields

        private bool _shouldLaunchInstallFileOnClose = false;
        private bool _didCallDownloadProcessCompletedHandler = false;

        #endregion

        #region Public

        /// <summary>
        /// Whether or not the software will relaunch after the update has been installed
        /// </summary>
        public bool SoftwareWillRelaunchAfterUpdateInstalled
        {
            set => kbtnInstallAndRelaunch.Text = value ? "&Install && Relaunch" : "&Install";
        }

        #endregion

        #region Identity

        public NetSparkleDownloadProgressWindow(AppCastItem? item, Icon applicationIcon)
        {
            InitializeComponent();

            pbxApplicationIcon.Image = new Icon(applicationIcon, new Size(48, 48)).ToBitmap();

            Icon = applicationIcon;

            kbtnInstallAndRelaunch.Visible = false;

            kbtnInstallAndRelaunch.Text = @"&Install && Relaunch";

            kwlHeader.Text = $@"{item.AppName} {item.Version}";

            kwlDownloadProgress.Text = string.Empty;

            kpbDownloadProgress.Maximum = 100;

            kpbDownloadProgress.Minimum = 0;

            kpbDownloadProgress.Step = 1;
        }

        #endregion

        #region IDownloadProgress Implementation

        public event DownloadInstallEventHandler? DownloadProcessCompleted;

        public void SetDownloadAndInstallButtonEnabled(bool shouldBeEnabled)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate () { SetDownloadAndInstallButtonEnabled(shouldBeEnabled); });
            }
            else
            {
                kbtnInstallAndRelaunch.Enabled = shouldBeEnabled;
            }
        }

        public void Show(bool isOnMainThread)
        {
            Show();

            if (!isOnMainThread)
            {
                Application.Run(this);
            }
        }

        public void OnDownloadProgressChanged(object sender, ItemDownloadProgressEventArgs args) => OnDownloadProgressChanged(sender, args.BytesReceived, args.TotalBytesToReceive, args.ProgressPercentage);

        public void FinishedDownloadingFile(bool isDownloadedFileValid)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate () { FinishedDownloadingFile(isDownloadedFileValid); });
            }
            else
            {
                kpbDownloadProgress.Visible = false;

                kbtnCancel.Visible = false;

                kwlDownloadProgress.Visible = false;

                if (isDownloadedFileValid)
                {
                    kbtnInstallAndRelaunch.Visible = true;
                }
                else
                {
                    kbtnInstallAndRelaunch.Visible = false;
                }
            }
        }

        public bool DisplayErrorMessage(string errorMessage)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate () { DisplayErrorMessage(errorMessage); });
            }
            else
            {
                kwlDownloadProgress.Visible = true;

                kpbDownloadProgress.Visible = false;

                kbtnInstallAndRelaunch.Visible = false;

                kbtnCancel.Text = @"Close";

                kpbDownloadProgress.Text = errorMessage;
            }

            return true;
        }

        void IDownloadProgress.Close()
        {
            DialogResult = DialogResult.Abort;

            CloseForm();
        }

        #endregion

        #region Implementation

        private void CloseForm()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate ()
                {
                    Close();
                });
            }
            else
            {
                Close();
            }
        }

        /// <summary>
        /// Event called when the client download progress changes
        /// </summary>
        private void OnDownloadProgressChanged(object sender, long bytesReceived, long totalBytesToReceive, int percentage)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate () { OnDownloadProgressChanged(sender, bytesReceived, totalBytesToReceive, percentage); });
            }
            else
            {
                kpbDownloadProgress.Value = percentage;

                kwlDownloadProgress.Text = $@"({Utilities.ConvertNumBytesToUserReadableString(bytesReceived)} / 
                                           {Utilities.ConvertNumBytesToUserReadableString(totalBytesToReceive)})";
            }
        }

        #endregion

        private void NetSparkleDownloadProgressWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_didCallDownloadProcessCompletedHandler)
            {
                _didCallDownloadProcessCompletedHandler = true;
                DownloadProcessCompleted?.Invoke(this, new DownloadInstallEventArgs(_shouldLaunchInstallFileOnClose));
            }
        }

        private void kbtnInstallAndRelaunch_Click(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)delegate () { kbtnInstallAndRelaunch_Click(sender, e); });
            }
            else
            {
                DialogResult = DialogResult.OK;
                _shouldLaunchInstallFileOnClose = true;
                _didCallDownloadProcessCompletedHandler = true;
                DownloadProcessCompleted?.Invoke(this, new DownloadInstallEventArgs(true));
            }
        }

        private void kbtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            _didCallDownloadProcessCompletedHandler = true;
            DownloadProcessCompleted?.Invoke(this, new DownloadInstallEventArgs(false));
        }
    }
}
