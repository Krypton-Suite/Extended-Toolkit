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

using Size = System.Drawing.Size;

namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    public partial class NetSparkleCheckingForUpdatesWindow : KryptonForm, ICheckingForUpdates
    {
        public NetSparkleCheckingForUpdatesWindow()
        {
            InitializeComponent();
        }

        public NetSparkleCheckingForUpdatesWindow(Icon? applicationIcon = null)
        {
            InitializeComponent();

            if (applicationIcon != null)
            {
                Icon = applicationIcon;

                pbxApplicationIcon.Image = new Icon(applicationIcon, new Size(48, 48)).ToBitmap();
            }
        }

        public event EventHandler? UpdatesUIClosing;

        private void NetSparkleCheckingForUpdatesWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdatesUIClosing?.Invoke(sender, new());
        }

        void ICheckingForUpdates.Close()
        {
            CloseForm();
        }
        void ICheckingForUpdates.Show()
        {
            Show();
        }

        private void kbtnCancel_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void CloseForm()
        {
            if (InvokeRequired && !IsDisposed && !Disposing)
            {
                Invoke((MethodInvoker)delegate ()
                {
                    if (!IsDisposed && !Disposing)
                    {
                        UpdatesUIClosing?.Invoke(this, new());
                        Close();
                    }
                });
            }
            else if (!IsDisposed && !Disposing)
            {
                UpdatesUIClosing?.Invoke(this, new());
                Close();
            }
        }
    }
}
