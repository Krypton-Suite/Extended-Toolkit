using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// ReSharper disable VirtualMemberCallInConstructor

namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    public partial class NetSparkleMessageNotificationWindow : KryptonForm
    {
        public NetSparkleMessageNotificationWindow()
        {
            InitializeComponent();
        }

        public NetSparkleMessageNotificationWindow(string title, string message, Icon? applicationIcon = null)
        {
            InitializeComponent();

            Text = title;

            if (applicationIcon != null)
            {
                Icon = applicationIcon;

                pbxApplicationIcon.Image = new Icon(applicationIcon, new Size(48, 48)).ToBitmap();
            }

            kwlMessage.Text = message;
        }

        private void kbtnOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
