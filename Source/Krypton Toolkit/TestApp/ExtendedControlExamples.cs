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

namespace TestApp
{
    public partial class ExtendedControlExamples : KryptonForm
    {
        public ExtendedControlExamples()
        {
            InitializeComponent();
        }

        private void kkTest1_ValueChanged(object sender, Krypton.Toolkit.Suite.Extended.Controls.KnobValueChangedEventArgs e)
        {
            kryptonProgressBarExtendedVersion11.Value = e.Value;

            kryptonProgressBarExtendedVersion11.DisplayText = $"{e.Value}%";
        }

        private void kkTest2_ValueChanged(object sender, Krypton.Toolkit.Suite.Extended.Controls.KnobValueChangedEventArgs e)
        {
            kryptonProgressBarExtendedVersion21.Value = e.Value;
        }
    }
}
