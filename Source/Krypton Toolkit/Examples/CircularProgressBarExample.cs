#region MIT License

/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */

#endregion
namespace Examples
{
    public partial class CircularProgressBarExample : KryptonForm
    {
        public CircularProgressBarExample()
        {
            InitializeComponent();
        }

        private void kryptonTrackBar1_ValueChanged(object sender, EventArgs e)
        {
            circularProgressBar1.Value = (int)kryptonTrackBar1.Value;

            circularProgressBar1.Text = $"{kryptonTrackBar1.Value}%";
        }

        private void kcbUseColourTrio_CheckedChanged(object sender, EventArgs e)
        {
            EnableColourTrioUI(kcbUseColourTrio.Checked);

            circularProgressBar1.UseColorTrio = kcbUseColourTrio.Checked;
        }

        private void EnableColourTrioUI(bool enabled)
        {
            kcbtnFirstColour.Enabled = enabled;

            kcbtnSecondColour.Enabled = enabled;

            kcbtnThirdColour.Enabled = enabled;
        }

        private void kcbtnFirstColour_SelectedColorChanged(object sender, ColorEventArgs e) => circularProgressBar1.FirstValueColor = e.Color;

        private void kcbtnSecondColour_SelectedColorChanged(object sender, ColorEventArgs e) => circularProgressBar1.SecondValueColor = e.Color;

        private void kcbtnThirdColour_SelectedColorChanged(object sender, ColorEventArgs e) => circularProgressBar1.ThirdValueColor = e.Color;

        private void kcbtnProgressColour_SelectedColorChanged(object sender, ColorEventArgs e) => circularProgressBar1.ProgressColor = e.Color;
    }
}
