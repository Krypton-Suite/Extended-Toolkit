using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
