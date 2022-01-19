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
    public partial class BasicNotificationWithUserResponseAndProgressBarConfiguration : KryptonForm
    {
        private string _soundPath;
        private Image _image;
        private Font _cueFont;

        public BasicNotificationWithUserResponseAndProgressBarConfiguration()
        {
            InitializeComponent();

            kcmbNotificationIconType.DataSource = Enum.GetValues(typeof(IconType));

            kcmbPromptAlignHorizontal.DataSource = Enum.GetValues(typeof(PaletteRelativeAlign));

            kcmbPromptAlignVertical.DataSource = Enum.GetValues(typeof(PaletteRelativeAlign));
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

        private void kbtnPromptFont_Click(object sender, EventArgs e)
        {
            using (KryptonFontDialog kfd = new KryptonFontDialog())
            {
                if (kfd.ShowDialog() == DialogResult.OK)
                {
                    _cueFont = kfd.Font;
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
            BasicNotificationWithUserResponseAndProgressBarLTR notification = new BasicNotificationWithUserResponseAndProgressBarLTR((IconType)Enum.Parse(typeof(IconType), kcmbNotificationIconType.Text),
                                                                                 ktxtNotificationTitle.Text, krtbNotificationContentText.Text, _image,
                                                                                 ktxtNotificationDismissButtonText.Text, ktxtCueText.Text,
                                                                                 kcbtnCueColour.SelectedColor, (PaletteRelativeAlign)Enum.Parse(typeof(PaletteRelativeAlign), kcmbPromptAlignHorizontal.Text),
                                                                                 (PaletteRelativeAlign)Enum.Parse(typeof(PaletteRelativeAlign), kcmbPromptAlignVertical.Text), _cueFont);

            if (_soundPath != null)
            {
                notification.SoundPath = _soundPath;
            }

            if (knudNotificationTimeOut.Value > 0)
            {
                notification.Seconds = (int)knudNotificationTimeOut.Value;
            }

            if (notification.ShowDialog() == DialogResult.OK)
            {
                KryptonMessageBox.Show($"User response: {notification.GetUserResponse()}", "User Response", MessageBoxButtons.OK, KryptonMessageBoxIcon.INFORMATION);
            }
        }
    }
}
