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
    public partial class KryptonProgressBarExtendedExamples : KryptonForm
    {
        public KryptonProgressBarExtendedExamples()
        {
            InitializeComponent();
        }

        private void ktbValue_ValueChanged(object sender, EventArgs e)
        {
            kryptonProgressBar1.Value = (int)ktbValue.Value;

            kryptonProgressBarExtended1.Value = (int)ktbValue.Value;

            kryptonProgressBarExtendedVersion11.Value = (int)ktbValue.Value;
        }
    }
}
