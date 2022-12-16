using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examples
{
    public partial class KryptonFormExtended1 : KryptonFormExtended
    {
        public KryptonFormExtended1()
        {
            InitializeComponent();
        }

        private void KryptonFormExtended1_Load(object sender, EventArgs e)
        {
            //FadeValues.NextWindow = KryptonFormExtended2;
        }

        private void kbtnCloseButton_CheckedChanged(object sender, EventArgs e)
        {
            CloseBox = kbtnCloseButton.Checked;

            if (kbtnCloseButton.Checked)
            {
                kbtnCloseButton.Text = @"Enable Close Button";
            }
            else
            {
                kbtnCloseButton.Text = @"Disable Close Button";
            }
        }
    }
}
