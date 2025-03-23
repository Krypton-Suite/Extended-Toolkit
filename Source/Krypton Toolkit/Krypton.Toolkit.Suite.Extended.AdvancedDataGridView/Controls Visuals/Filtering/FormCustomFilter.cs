#region Original License
/*
 *
 * Microsoft Public License (Ms-PL)
 *
 * This license governs use of the accompanying software. If you use the software, you accept this license. If you do not accept the license, do not use the software.
 *
 * 1. Definitions 
 *
 * The terms "reproduce," "reproduction," "derivative works," and "distribution" have the same meaning here as under U.S. copyright law.
 *
 * A "contribution" is the original software, or any additions or changes to the software.
 *
 * A "contributor" is any person that distributes its contribution under this license.
 *
 * "Licensed patents" are a contributor's patent claims that read directly on its contribution.
 *
 * 2. Grant of Rights
 *
 * (A) Copyright Grant- Subject to the terms of this license, including the license conditions and limitations in section 3, each contributor grants you a non-exclusive, worldwide, royalty-free copyright license to reproduce its contribution, prepare derivative works of its contribution, and distribute its contribution or any derivative works that you create.
 *
 * (B) Patent Grant- Subject to the terms of this license, including the license conditions and limitations in section 3, each contributor grants you a non-exclusive, worldwide, royalty-free license under its licensed patents to make, have made, use, sell, offer for sale, import, and/or otherwise dispose of its contribution in the software or derivative works of the contribution in the software.
 *
 * 3. Conditions and Limitations
 *
 * (A) No Trademark License- This license does not grant you rights to use any contributors' name, logo, or trademarks.
 *
 * (B) If you bring a patent claim against any contributor over patents that you claim are infringed by the software, your patent license from such contributor to the software ends automatically.
 *
 * (C) If you distribute any portion of the software, you must retain all copyright, patent, trademark, and attribution notices that are present in the software.
 *
 * (D) If you distribute any portion of the software in source code form, you may do so only under this license by including a complete copy of this license with your distribution. If you distribute any portion of the software in compiled or object code form, you may only do so under a license that complies with this license.
 *
 * (E) The software is licensed "as-is." You bear the risk of using it. The contributors give no express warranties, guarantees or conditions. You may have additional consumer rights under your local laws which this license cannot change. To the extent permitted under your local laws, the contributors exclude the implied warranties of merchantability, fitness for a particular purpose and non-infringement.
 *
 */
#endregion

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

namespace Krypton.Toolkit.Suite.Extended.AdvancedDataGridView
{
    public partial class FormCustomFilter : KryptonForm
    {
        #region Instance Fields

        private readonly FilterType _filterType;
        private Control? _valControl1;
        private Control? _valControl2;

        private readonly bool _filterDateAndTimeEnabled;

        private string? _filterString;

        private string? _filterStringDescription;

        #endregion

        #region Public

        /// <summary>
        /// Get the Filter string
        /// </summary>
        public string? FilterString => _filterString;

        /// <summary>
        /// Get the Filter string description
        /// </summary>
        public string? FilterStringDescription => _filterStringDescription;

        #endregion

        #region Identity

        /// <summary>Initializes a new instance of the <see cref="FormCustomFilter" /> class.</summary>
        /// <param name="dataType">Type of the data.</param>
        /// <param name="filterDateAndTimeEnabled">if set to <c>true</c> [filter date and time enabled].</param>
        public FormCustomFilter(Type dataType, bool filterDateAndTimeEnabled)
        {
            InitializeComponent();

            //set component translations
            Text = KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewFormTitle.ToString()];
            label_columnName.Text = KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewLabelColumnNameText.ToString()];
            label_and.Text = KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewLabelAnd.ToString()];
            button_ok.Text = KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewButtonOk.ToString()];
            button_cancel.Text = KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewButtonCancel.ToString()];

            // TODO: Turn this into a `switch`
            if (dataType == typeof(DateTime))
            {
                _filterType = FilterType.DateTime;
            }
            else if (dataType == typeof(TimeSpan))
            {
                _filterType = FilterType.TimeSpan;
            }
            else if (dataType == typeof(int) || dataType == typeof(long) || dataType == typeof(short) ||
                     dataType == typeof(uint) || dataType == typeof(ulong) || dataType == typeof(ushort) ||
                     dataType == typeof(byte) || dataType == typeof(sbyte))
            {
                _filterType = FilterType.Integer;
            }
            else if (dataType == typeof(float) || dataType == typeof(double) || dataType == typeof(decimal))
            {
                _filterType = FilterType.Float;
            }
            else if (dataType == typeof(string))
            {
                _filterType = FilterType.String;
            }
            else
            {
                _filterType = FilterType.Unknown;
            }

            _filterDateAndTimeEnabled = filterDateAndTimeEnabled;

            switch (_filterType)
            {
                case FilterType.DateTime:
                    _valControl1 = new DateTimePicker();
                    _valControl2 = new DateTimePicker();
                    if (_filterDateAndTimeEnabled)
                    {
                        DateTimeFormatInfo dt = Thread.CurrentThread.CurrentCulture.DateTimeFormat;

                        (_valControl1 as DateTimePicker)!.CustomFormat = $@"{dt.ShortDatePattern} HH:mm";
                        (_valControl2 as DateTimePicker)!.CustomFormat = $@"{dt.ShortDatePattern} HH:mm";
                        (_valControl1 as DateTimePicker)!.Format = DateTimePickerFormat.Custom;
                        (_valControl2 as DateTimePicker)!.Format = DateTimePickerFormat.Custom;
                    }
                    else
                    {
                        (_valControl1 as DateTimePicker)!.Format = DateTimePickerFormat.Short;
                        (_valControl2 as DateTimePicker)!.Format = DateTimePickerFormat.Short;
                    }

                    comboBox_filterType.Items.AddRange([
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewEquals.ToString()],
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewDoesNotEqual.ToString()],
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewEarlierThan.ToString()],
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewEarlierThanOrEqualTo.ToString()],
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewLaterThan.ToString()],
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewLaterThanOrEqualTo.ToString()],
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewBetween.ToString()]
                    ]);
                    break;

                case FilterType.TimeSpan:
                    _valControl1 = new TextBox();
                    _valControl2 = new TextBox();
                    comboBox_filterType.Items.AddRange([
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewContains.ToString()],
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewDoesNotContain.ToString()]
                    ]);
                    break;

                case FilterType.Integer:
                case FilterType.Float:
                    _valControl1 = new TextBox();
                    _valControl2 = new TextBox();
                    _valControl1.TextChanged += valControl_TextChanged;
                    _valControl2.TextChanged += valControl_TextChanged;
                    comboBox_filterType.Items.AddRange([
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewEquals.ToString()],
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewDoesNotEqual.ToString()],
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewGreaterThan.ToString()],
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewGreaterThanOrEqualTo.ToString()],
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewLessThan.ToString()],
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewLessThanOrEqualTo.ToString()],
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewBetween.ToString()]
                    ]);
                    _valControl1.Tag = true;
                    _valControl2.Tag = true;
                    button_ok.Enabled = false;
                    break;

                default:
                    _valControl1 = new TextBox();
                    _valControl2 = new TextBox();
                    comboBox_filterType.Items.AddRange([
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewEquals.ToString()],
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewDoesNotEqual.ToString()],
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewBeginsWith.ToString()],
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewDoesNotBeginWith.ToString()],
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewEndsWith.ToString()],
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewDoesNotEndWith.ToString()],
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewContains.ToString()],
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewDoesNotContain.ToString()]
                    ]);
                    break;
            }
            comboBox_filterType.SelectedIndex = 0;

            _valControl1.Name = "valControl1";
            _valControl1.Location = new(20, 66);
            _valControl1.Size = new(166, 20);
            _valControl1.Width = comboBox_filterType.Width - 20;
            _valControl1.TabIndex = 4;
            _valControl1.Visible = true;
            _valControl1.KeyDown += valControl_KeyDown;

            _valControl2.Name = "valControl2";
            _valControl2.Location = new(20, 108);
            _valControl2.Size = new(166, 20);
            _valControl2.Width = comboBox_filterType.Width - 20;
            _valControl2.TabIndex = 5;
            _valControl2.Visible = false;
            _valControl2.VisibleChanged += valControl2_VisibleChanged;
            _valControl2.KeyDown += valControl_KeyDown;

            Controls.Add(_valControl1);
            Controls.Add(_valControl2);

            ep.SetIconAlignment(_valControl1, ErrorIconAlignment.MiddleRight);
            ep.SetIconPadding(_valControl1, -18);
            ep.SetIconAlignment(_valControl2, ErrorIconAlignment.MiddleRight);
            ep.SetIconPadding(_valControl2, -18);
        }

        #endregion

        #region Implementation

        private void FormCustomFilter_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Build a Filter string
        /// </summary>
        /// <param name="filterType"></param>
        /// <param name="filterDateAndTimeEnabled"></param>
        /// <param name="filterTypeConditionText"></param>
        /// <param name="control1"></param>
        /// <param name="control2"></param>
        /// <returns></returns>
        private string? BuildCustomFilter(FilterType filterType, bool filterDateAndTimeEnabled, string filterTypeConditionText, Control control1, Control control2)
        {
            string? filterString = "";

            string? column = @"[{0}] ";

            if (filterType == FilterType.Unknown)
            {
                column = $"Convert([{{0}}], 'System.String') ";
            }

            filterString = column;

            switch (filterType)
            {
                case FilterType.DateTime:
                    DateTime dt = ((DateTimePicker)control1).Value;
                    dt = new(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0);

                    if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewEquals.ToString()])
                    {
                        filterString =
                            $"Convert([{{0}}], 'System.String') LIKE '%{Convert.ToString(filterDateAndTimeEnabled ? dt : dt.Date, CultureInfo.CurrentCulture)}%'";
                    }
                    else if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewEarlierThan.ToString()])
                    {
                        filterString +=
                            $"< '{Convert.ToString(filterDateAndTimeEnabled ? dt : dt.Date, CultureInfo.CurrentCulture)}'";
                    }
                    else if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewEarlierThanOrEqualTo.ToString()])
                    {
                        filterString +=
                            $"<= '{Convert.ToString(filterDateAndTimeEnabled ? dt : dt.Date, CultureInfo.CurrentCulture)}'";
                    }
                    else if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewLaterThan.ToString()])
                    {
                        filterString +=
                            $"> '{Convert.ToString(filterDateAndTimeEnabled ? dt : dt.Date, CultureInfo.CurrentCulture)}'";
                    }
                    else if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewLaterThanOrEqualTo.ToString()])
                    {
                        filterString +=
                            $">= '{Convert.ToString(filterDateAndTimeEnabled ? dt : dt.Date, CultureInfo.CurrentCulture)}'";
                    }
                    else if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewBetween.ToString()])
                    {
                        DateTime dt1 = ((DateTimePicker)control2).Value;
                        dt1 = new(dt1.Year, dt1.Month, dt1.Day, dt1.Hour, dt1.Minute, 0);
                        filterString +=
                            $">= '{Convert.ToString(filterDateAndTimeEnabled ? dt : dt.Date, CultureInfo.CurrentCulture)}'";
                        filterString +=
                            $" AND {column}<= '{Convert.ToString(filterDateAndTimeEnabled ? dt1 : dt1.Date, CultureInfo.CurrentCulture)}'";
                    }
                    else if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewDoesNotEqual.ToString()])
                    {
                        filterString =
                            $"Convert([{{0}}], 'System.String') NOT LIKE '%{Convert.ToString(filterDateAndTimeEnabled ? dt : dt.Date, CultureInfo.CurrentCulture)}%'";
                    }

                    break;

                case FilterType.TimeSpan:
                    try
                    {
                        TimeSpan ts = TimeSpan.Parse(control1.Text);

                        if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewContains.ToString()])
                        {
                            filterString =
                                $"(Convert([{{0}}], 'System.String') LIKE '%P{(ts.Days > 0 ? $"{ts.Days}D" : "")}{(ts.TotalHours > 0 ? "T" : "")}{(ts.Hours > 0 ? $"{ts.Hours}H" : "")}{(ts.Minutes > 0 ? $"{ts.Minutes}M" : "")}{(ts.Seconds > 0 ? $"{ts.Seconds}S" : "")}%')";
                        }
                        else if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewDoesNotContain.ToString()])
                        {
                            filterString =
                                $"(Convert([{{0}}], 'System.String') NOT LIKE '%P{(ts.Days > 0 ? $"{ts.Days}D" : "")}{(ts.TotalHours > 0 ? "T" : "")}{(ts.Hours > 0 ? $"{ts.Hours}H" : "")}{(ts.Minutes > 0 ? $"{ts.Minutes}M" : "")}{(ts.Seconds > 0 ? $"{ts.Seconds}S" : "")}%')";
                        }
                    }
                    catch (FormatException)
                    {
                        filterString = null;
                    }
                    break;

                case FilterType.Integer:
                case FilterType.Float:

                    string num = control1.Text;

                    if (filterType == FilterType.Float)
                    {
                        num = num.Replace(",", ".");
                    }

                    if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewEquals.ToString()])
                    {
                        filterString += $"= {num}";
                    }
                    else if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewBetween.ToString()])
                    {
                        filterString +=
                            $">= {num} AND {column}<= {(filterType == FilterType.Float ? control2.Text.Replace(",", ".") : control2.Text)}";
                    }
                    else if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewDoesNotEqual.ToString()])
                    {
                        filterString += $"<> {num}";
                    }
                    else if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewGreaterThan.ToString()])
                    {
                        filterString += $"> {num}";
                    }
                    else if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewGreaterThanOrEqualTo.ToString()])
                    {
                        filterString += $">= {num}";
                    }
                    else if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewLessThan.ToString()])
                    {
                        filterString += $"< {num}";
                    }
                    else if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewLessThanOrEqualTo.ToString()])
                    {
                        filterString += $"<= {num}";
                    }

                    break;

                default:
                    string txt = FormatFilterString(control1.Text);
                    if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewEquals.ToString()])
                    {
                        filterString += $"LIKE '{txt}'";
                    }
                    else if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewDoesNotEqual.ToString()])
                    {
                        filterString += $"NOT LIKE '{txt}'";
                    }
                    else if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewBeginsWith.ToString()])
                    {
                        filterString += $"LIKE '{txt}%'";
                    }
                    else if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewEndsWith.ToString()])
                    {
                        filterString += $"LIKE '%{txt}'";
                    }
                    else if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewDoesNotBeginWith.ToString()])
                    {
                        filterString += $"NOT LIKE '{txt}%'";
                    }
                    else if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewDoesNotEndWith.ToString()])
                    {
                        filterString += $"NOT LIKE '%{txt}'";
                    }
                    else if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewContains.ToString()])
                    {
                        filterString += $"LIKE '%{txt}%'";
                    }
                    else if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewDoesNotContain.ToString()])
                    {
                        filterString += $"NOT LIKE '%{txt}%'";
                    }

                    break;
            }

            return filterString;
        }

        /// <summary>
        /// Format a text Filter string
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        private string FormatFilterString(string text)
        {
            string result = "";
            string s;
            string[] replace = ["%", "[", "]", "*", "\"", "\\"];

            for (int i = 0; i < text.Length; i++)
            {
                s = text[i].ToString();
                if (replace.Contains(s))
                {
                    result += $"[{s}]";
                }
                else
                {
                    result += s;
                }
            }

            return result.Replace("'", "''");
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            _filterStringDescription = null;
            _filterString = null;
            DialogResult = DialogResult.Cancel;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            if (_valControl1 != null && _valControl2 != null && ((_valControl1.Visible && _valControl1.Tag != null && (bool)_valControl1.Tag) ||
                                                                 (_valControl2.Visible && _valControl2.Tag != null && (bool)_valControl2.Tag)))
            {
                button_ok.Enabled = false;
                return;
            }

            if (_valControl1 != null)
            {
                if (_valControl2 != null)
                {
                    string? filterString = BuildCustomFilter(_filterType, _filterDateAndTimeEnabled, comboBox_filterType.Text, _valControl1, _valControl2);

                    if (!String.IsNullOrEmpty(filterString))
                    {
                        _filterString = filterString;
                        _filterStringDescription = string.Format(KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewFilterStringDescription.ToString()], comboBox_filterType.Text, _valControl1.Text);
                        if (_valControl2.Visible)
                        {
                            _filterStringDescription += $" {label_and.Text} \"{_valControl2.Text}\"";
                        }

                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        _filterString = null;
                        _filterStringDescription = null;
                        DialogResult = DialogResult.Cancel;
                    }
                }
            }

            Close();
        }

        private void comboBox_filterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_valControl2 != null)
            {
                _valControl2.Visible = comboBox_filterType.Text ==
                                       KryptonAdvancedDataGridView.Translations[
                                           TranslationKey.KryptonAdvancedDataGridViewBetween.ToString()];
                if (_valControl1 != null)
                {
                    button_ok.Enabled =
                        !(_valControl1.Visible && _valControl1.Tag != null && (bool)_valControl1.Tag) ||
                        (_valControl2.Visible && _valControl2.Tag != null && (bool)_valControl2.Tag);
                }
            }
        }

        /// <summary>
        /// Changed control2 visibility
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void valControl2_VisibleChanged(object? sender, EventArgs e)
        {
            if (_valControl2 != null)
            {
                label_and.Visible = _valControl2.Visible;
            }
        }

        /// <summary>
        /// Changed a control Text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void valControl_TextChanged(object? sender, EventArgs e)
        {
            bool hasErrors = false;
            switch (_filterType)
            {
                case FilterType.Integer:
                    long val;
                    hasErrors = !long.TryParse((sender as TextBox)!.Text, out val);
                    break;

                case FilterType.Float:
                    double val1;
                    hasErrors = !double.TryParse((sender as TextBox)!.Text, out val1);
                    break;
            }

            (sender as Control)!.Tag = hasErrors || (sender as TextBox)!.Text.Length == 0;

            if (hasErrors && (sender as TextBox)!.Text.Length > 0)
            {
                ep.SetError((sender as Control)!, KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewInvalidValue.ToString()]);
            }
            else
            {
                ep.SetError((sender as Control)!, "");
            }

            if (_valControl1 != null && _valControl2 != null)
            {
                button_ok.Enabled = !(_valControl1.Visible && _valControl1.Tag != null && (bool)_valControl1.Tag) ||
                                 (_valControl2.Visible && _valControl2.Tag != null && (bool)_valControl2.Tag);
            }
        }

        /// <summary>
        /// KeyDown on a control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void valControl_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (sender == _valControl1)
                {
                    if (_valControl2 != null && _valControl2.Visible)
                    {
                        _valControl2.Focus();
                    }
                    else
                    {
                        button_ok_Click(button_ok, EventArgs.Empty);
                    }
                }
                else
                {
                    button_ok_Click(button_ok, EventArgs.Empty);
                }

                e.SuppressKeyPress = false;
                e.Handled = true;
            }
        }

        #endregion
    }
}