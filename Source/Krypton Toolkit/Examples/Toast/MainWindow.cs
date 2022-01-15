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
    }
}
