using System;
using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Toast;

namespace Toast
{
    public partial class Form1 : KryptonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void kbtnVersion1_Click(object sender, EventArgs e)
        {
            KryptonToastNotificationVersion1Manager toastNotification = new KryptonToastNotificationVersion1Manager()
            {
                ShowActionButton = true,
                Action = ActionType.LAUCHPROCESS,
                ButtonLocation = ActionButtonLocation.LEFT,
                Fade = true,
                ShowProgressBar = true,
                ShowControlBox = true,
                SoundPath = null,
                SoundStream = null,
                HeaderText = "Hello World!",
                ContentText = "This is a test",
                ProcessName = @"C:\Windows\notepad.exe",
                IconImage = null,
                Seconds = 60,
                CornerRadius = -1,
                PaletteDrawBorders = PaletteDrawBorders.All,
                Type = IconType.INFORMATION
            };

            toastNotification.DisplayToastNotification();
        }

        private void kbtnVersion2_Click(object sender, EventArgs e)
        {
            KryptonToastNotificationVersion2Manager toastNotification = new KryptonToastNotificationVersion2Manager()
            {
                Fade = true,
                SoundPath = null,
                SoundStream = null,
                HeaderText = "Hello World!",
                ContentText = "This is a test",
                IconImage = null,
                Seconds = 60,
                CornerRadius = -1,
                PaletteDrawBorders = PaletteDrawBorders.All,
                Type = IconType.INFORMATION
            };

            toastNotification.DisplayNotification();
        }
    }
}
