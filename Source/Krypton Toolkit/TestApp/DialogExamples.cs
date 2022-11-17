using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Krypton.Toolkit.Suite.Extended.Dialogs;

using TestApp.Properties;

namespace TestApp
{
    public partial class DialogExamples : KryptonForm
    {
        public DialogExamples()
        {
            InitializeComponent();
        }

        private void kbtnAbout_Click(object sender, EventArgs e)
        {
            Assembly asm = Assembly.GetExecutingAssembly();

            KryptonAboutDialog aboutDialog = new KryptonAboutDialog(Resources.Stable, asm);

            aboutDialog.ShowDialog();
        }

        private void kbtnException_Click(object sender, EventArgs e)
        {
            //KryptonExceptionCaptureDialog exceptionCaptureDialog = new KryptonExceptionCaptureDialog();

            //exceptionCaptureDialog.ShowDialog();
        }

        private void kbtnCheckSum_Click(object sender, EventArgs e)
        {
            KryptonPropertiesForm propertiesForm = new KryptonPropertiesForm();

            propertiesForm.ShowDialog();
        }

        private void kbtnRun_Click(object sender, EventArgs e)
        {
            KryptonRunDialog runDialog = new KryptonRunDialog(RunDialogStartPosition.BottomLeft);

            runDialog.ShowDialog();
        }

        private void kbtnSplash_Click(object sender, EventArgs e)
        {
            KryptonSplashDialog splashDialog = new KryptonSplashDialog(true, @"Extended Toolkit Test App", Resources.Stable);

            splashDialog.ShowDialog();
        }

        private void kbtnTextToSpeech_Click(object sender, EventArgs e)
        {
            KryptonTextToSpeechDialog textToSpeechDialog = new KryptonTextToSpeechDialog();

            textToSpeechDialog.ShowDialog();
        }
    }
}
