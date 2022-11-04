using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Krypton.Toolkit.Suite.Extended.Forms;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    public partial class KryptonRunDialog : KryptonFormExtended
    {
        public KryptonRunDialog(RunDialogStartPosition startPosition)
        {
            InitializeComponent();

            SetupStartPosition(startPosition);
        }

        #region Implementation

        private void SetupStartPosition(RunDialogStartPosition startPosition)
        {
            switch (startPosition)
            {
                case RunDialogStartPosition.BottomLeft:
                    Location = new Point(0, Screen.PrimaryScreen.WorkingArea.Bottom - Height);
                    break;
                case RunDialogStartPosition.BottomRight:
                    break;
                case RunDialogStartPosition.CentreScreen:
                    StartPosition = FormStartPosition.CenterScreen;
                    break;
            }
        }

        private void KryptonRunDialog_Load(object sender, EventArgs e)
        {
            //kcmdOpenInExplorer.ImageLarge = Icon
        }

        private void bsReset_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(kcmbRunPath.Text))
            {
                kcmbRunPath.Text = null;
            }
        }

        private void kcmbRunPath_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void kcmbRunPath_TextChanged(object sender, EventArgs e)
        {
          
        }
        
        private void kcmdOpenInExplorer_Execute(object sender, EventArgs e)
        {
            try
            {
                Process.Start("explorer.exe", kcmbRunPath.Text);

                Hide();
            }
            catch (Exception exception)
            {
                ExceptionCapture.CaptureException(exception);
            }
        }

        #endregion

       
    }
}
