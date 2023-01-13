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
    public partial class ExtendedControlExamples : KryptonForm
    {
        public ExtendedControlExamples()
        {
            InitializeComponent();
        }

        private void kkcv1Test_ValueChanged(object sender, Krypton.Toolkit.Suite.Extended.Controls.KnobValueChangedEventArgs e)
        {
            kryptonProgressBarExtendedVersion11.Value = kkcv1Test.Value;
        }

        private void kkcv2Test_ValueChanged(object sender, Krypton.Toolkit.Suite.Extended.Controls.KnobValueChangedEventArgs e)
        {
            kryptonProgressBarExtendedVersion21.Value = kkcv2Test.Value;
        }
    }
}
