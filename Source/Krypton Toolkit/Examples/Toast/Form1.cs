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
            KryptonToastWindowVersion1 toastNotification = new KryptonToastWindowVersion1(true, null, "Hello World!",
                "This is a basic notification that launches notepad.exe.",
                ActionButtonLocation.LEFT, true, ActionType.LAUCHPROCESS, @"C:\Windows\notepad.exe",
                false, false, "&Launch Notepad", String.Empty, -1, PaletteDrawBorders.All,
                IconType.INFORMATION, 60, InputBoxSystemSounds.BEEP);

            toastNotification.Show();
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
