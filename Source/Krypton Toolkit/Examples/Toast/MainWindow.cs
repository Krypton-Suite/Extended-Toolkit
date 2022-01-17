using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Krypton.Toolkit;

using Toast.LTR;

namespace Toast
{
    public partial class MainWindow : KryptonForm
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void kbtnLTRBasicNotificationConfiguration_Click(object sender, EventArgs e)
        {
            BasicNotificationConfiguration notificationConfiguration = new BasicNotificationConfiguration();

            notificationConfiguration.Show();
        }

        private void kbtnBasicNotificationWithProgressBarConfiguration_Click(object sender, EventArgs e)
        {
            BasicNotificationWithProgressBarConfiguration configuration = new BasicNotificationWithProgressBarConfiguration();

            configuration.Show();
        }

        private void kbtnBasicNotificationWithUserResponseConfiguration_Click(object sender, EventArgs e)
        {
            BasicNotificationWithUserResponseConfiguration configuration = new BasicNotificationWithUserResponseConfiguration();

            configuration.Show();
        }

        private void kbtnBasicNotificationWithUserResponseAndProgressBar_Click(object sender, EventArgs e)
        {
            BasicNotificationWithUserResponseAndProgressBarConfiguration configuration = new BasicNotificationWithUserResponseAndProgressBarConfiguration();

            configuration.Show();
        }
    }
}
