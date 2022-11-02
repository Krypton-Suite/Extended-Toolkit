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
        public KryptonRunDialog()
        {
            InitializeComponent();
        }

        private void KryptonRunDialog_Load(object sender, EventArgs e)
        {
            //kcmdOpenInExplorer.ImageLarge =
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
            if (kcmbRunPath.Text == string.Empty)
            {
                bsReset.Enabled = ButtonEnabled.False;
            }
            else
            {
                bsReset.Enabled = ButtonEnabled.True;
            }
        }
    }
}
