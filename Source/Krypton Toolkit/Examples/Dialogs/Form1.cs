using System;
using System.Reflection;

using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Dialogs;

namespace Dialogs
{
    public partial class Form1 : KryptonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void kbtnAboutBox_Click(object sender, EventArgs e)
        {
            kabm.DisplayAboutBox();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            kabm.Assembly = Assembly.GetExecutingAssembly();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            KryptonTextToSpeechDialog textToSpeechDialog = new KryptonTextToSpeechDialog();

            textToSpeechDialog.ShowDialog();
        }

        private void kbtnException_Click(object sender, EventArgs e)
        {
            KryptonExceptionCaptureDialog kryptonException = new KryptonExceptionCaptureDialog(new ArgumentOutOfRangeException());

            kryptonException.Show();
        }
    }
}
