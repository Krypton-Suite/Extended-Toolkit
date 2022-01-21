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
using Krypton.Toolkit.Suite.Extended.Toast;

namespace Toast.LTR
{
    public partial class BasicNotificationConfiguration : KryptonForm
    {
        private string _soundPath;
        private Image _image;

        public BasicNotificationConfiguration()
        {
            InitializeComponent();

            kcmbNotificationIconType.DataSource = Enum.GetValues(typeof(IconType));
        }

        private void kbtnNotificationCustomImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _image = Image.FromFile(ofd.FileName);

                    kcmbNotificationIconType.SelectedIndex = 0;
                }
            }
        }

        private void kbtnPickSound_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    _soundPath = ofd.FileName;
                }
            }
        }

        private void kbtnShowNotification_Click(object sender, EventArgs e)
        {
            BasicNotificationLTR notification = new BasicNotificationLTR((IconType)Enum.Parse(typeof(IconType), kcmbNotificationIconType.Text),
                                                                                    ktxtNotificationTitle.Text, krtbNotificationContentText.Text,
                                                                                    _image, ktxtNotificationDismissButtonText.Text);

            if (_soundPath != null)
            {
                notification.SoundPath = _soundPath;
            }

            if (knudNotificationTimeOut.Value > 0)
            {
                notification.Seconds = (int)knudNotificationTimeOut.Value;
            }

            notification.Show();
        }

        private void BasicNotificationConfiguration_Load(object sender, EventArgs e)
        {

        }
    }
}
