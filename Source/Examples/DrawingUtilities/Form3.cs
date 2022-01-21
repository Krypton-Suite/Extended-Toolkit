using System;

using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Drawing.Utilities;

namespace DrawingUtilities
{
    public partial class Form3 : KryptonForm
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            ColourGridDialog colourGridDialog = new ColourGridDialog();

            colourGridDialog.ShowDialog();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            ColourGridDialog colourGridDialog = new ColourGridDialog();

            colourGridDialog.ShowDialog();
        }

        private void kryptonButton6_Click(object sender, EventArgs e)
        {
            KryptonColourButtonCustomColourDialog colour = new KryptonColourButtonCustomColourDialog();

            colour.ShowDialog();
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {
            KryptonColourContrastDialog kryptonColourContrastDialog = new KryptonColourContrastDialog();

            kryptonColourContrastDialog.ShowDialog();
        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            KryptonColourPickerDialog kryptonColourPickerDialog = new KryptonColourPickerDialog();

            kryptonColourPickerDialog.ShowDialog();
        }

        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            ScreenColourPickerDialog screenColourPickerDialog = new ScreenColourPickerDialog();

            screenColourPickerDialog.ShowDialog();
        }
    }
}
