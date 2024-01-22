namespace Krypton.Toolkit.Suite.Extended.Core
{
    public partial class ColourConverter : KryptonForm
    {
        public ColourConverter(Color colour)
        {
            InitializeComponent();

            UpdateUI(colour);
        }

        private void kbtnConvertToRGB_Click(object sender, EventArgs e)
        {
            try
            {
                int[] rgb = ConversionMethods.ConvertHexadecimalToRGBTest(ktxtHexValue.Text);

                knudRedValue.Value = rgb[0];

                knudGreenValue.Value = rgb[1];

                knudBlueValue.Value = rgb[2];

                ccpbxPreview.BackColor = Color.FromArgb((int)knudRedValue.Value, (int)knudGreenValue.Value, (int)knudBlueValue.Value);
            }
            catch (Exception exception)
            {
                DebugUtilities.NotImplemented(exception.ToString());
            }
        }

        private void kbtnConvertToHexadecimal_Click(object sender, EventArgs e)
        {
            try
            {
                ktxtHexValue.Text = ConversionMethods.FormatColourToHexadecimal(Color.FromArgb((int)knudRedValue.Value,
                    (int)knudGreenValue.Value, (int)knudBlueValue.Value));
            }
            catch (Exception exception)
            {
                DebugUtilities.NotImplemented(exception.ToString());
            }
        }

        private void UpdateUI(Color colour, bool previewColour = false)
        {
            if (previewColour)
            {
                ccpbxPreview.BackColor = colour;

                knudRedValue.Value = colour.R;

                knudGreenValue.Value = colour.G;

                knudBlueValue.Value = colour.B;
            }
            else
            {
                knudRedValue.Value = colour.R;

                knudGreenValue.Value = colour.G;

                knudBlueValue.Value = colour.B;
            }
        }

        private void kcbtnSelectBaseColour_SelectedColorChanged(object sender, ColorEventArgs e) => UpdateUI(kcbtnSelectBaseColour.SelectedColor);

        private void kchkUpdateColourValues_CheckedChanged(object sender, EventArgs e) => tmrUpdateColourValues.Enabled = kchkUpdateColourValues.Checked;

        private void tmrUpdateColourValues_Tick(object sender, EventArgs e)
        {
            ccpbxPreview.BackColor =
                Color.FromArgb((int)knudRedValue.Value, (int)knudGreenValue.Value, (int)knudBlueValue.Value);
        }
    }
}
