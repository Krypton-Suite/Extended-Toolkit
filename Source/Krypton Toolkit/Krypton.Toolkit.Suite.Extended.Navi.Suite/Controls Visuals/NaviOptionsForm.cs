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

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    public partial class NaviOptionsForm : KryptonForm
    {
        private NaviBar _bar;
        private NaviSuiteLanguageManager? _languageManager;

        public NaviSuiteLanguageManager? LanguageManager { get => _languageManager; set => _languageManager = value ?? new(); }

        public NaviOptionsForm()
        {
            InitializeComponent();

            _languageManager = null;
        }

        public void Initialize(NaviBar bar)
        {
            _bar = bar;
            checkedListBoxBands.Items.Clear();
            foreach (NaviBand band in _bar.Bands)
            {
                checkedListBoxBands.Items.Add(band.Text, band.Visible);
            }
            Translate();
        }

        private void Translate()
        {
            buttonCancel.Text = KryptonManager.Strings.GeneralStrings.Cancel;
            buttonOk.Text = KryptonManager.Strings.GeneralStrings.OK;
            labelDesc.Text = NaviSuiteLanguageManager.SuiteStrings.Description;
            buttonMoveDown.Text = NaviSuiteLanguageManager.SuiteStrings.MoveDown;
            buttonMoveUp.Text = NaviSuiteLanguageManager.SuiteStrings.MoveUp;
            buttonReset.Text = NaviSuiteLanguageManager.SuiteStrings.ResetText;
            Text = NaviSuiteLanguageManager.SuiteStrings.OptionsTitle;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            // Set the new order
            for (int i = 0; i < _bar.Bands.Count; i++)
            {
                int loc = kclbBands.Items.IndexOf(_bar.Bands[i].Text);
                _bar.Bands[i].Visible = kclbBands.CheckedItems.Contains(_bar.Bands[i].Text);
                _bar.Bands[i].Order = loc;
            }

            // And sort the list based on the new order
            _bar.Bands.Sort(new NaviBandOrderComparer());
        }

        private void buttonMoveUp_Click(object sender, EventArgs e)
        {
            if (kclbBands.SelectedIndex > 0)
            {
                bool oldChecked = kclbBands.CheckedIndices.Contains(kclbBands.SelectedIndex - 1);
                bool oldChecked2 = kclbBands.CheckedIndices.Contains(kclbBands.SelectedIndex);

                object oldItem = kclbBands.Items[kclbBands.SelectedIndex - 1];
                kclbBands.Items[kclbBands.SelectedIndex - 1] = kclbBands.SelectedItem;

                kclbBands.SetItemChecked(kclbBands.SelectedIndex, oldChecked);
                kclbBands.SetItemChecked(kclbBands.SelectedIndex - 1, oldChecked2);

                kclbBands.Items[kclbBands.SelectedIndex] = oldItem;
                kclbBands.SelectedIndex -= 1;
            }
        }

        private void buttonMoveDown_Click(object sender, EventArgs e)
        {
            if ((kclbBands.SelectedIndex > 0)
            && (kclbBands.SelectedIndex < kclbBands.Items.Count - 1))
            {
                bool oldChecked = kclbBands.CheckedIndices.Contains(
                   kclbBands.SelectedIndex + 1);
                bool oldChecked2 = kclbBands.CheckedIndices.Contains(
                   kclbBands.SelectedIndex);

                object oldItem = kclbBands.Items[kclbBands.SelectedIndex + 1];
                kclbBands.Items[kclbBands.SelectedIndex + 1] =
                   kclbBands.SelectedItem;

                kclbBands.SetItemChecked(kclbBands.SelectedIndex,
                   oldChecked);
                kclbBands.SetItemChecked(kclbBands.SelectedIndex + 1,
                   oldChecked2);

                kclbBands.Items[kclbBands.SelectedIndex] = oldItem;
                kclbBands.SelectedIndex += 1;
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            // Sort list based on original order
            _bar.Bands.Sort(new NaviBandOrgOrderComparer());
            Initialize(_bar);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            // Reset ordering posibly caused by reset button
            _bar.Bands.Sort(new NaviBandOrderComparer());
        }
    }
}