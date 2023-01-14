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
 * Copyright (c) 2017 - 2023 Krypton Suite
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

// ReSharper disable ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
#pragma warning disable CS8602, CS8625, CS8622
namespace Krypton.Toolkit.Suite.Extended.AdvancedDataGridView
{
    internal partial class FormCustomFilter : KryptonForm
    {
        #region Designer Code

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button_ok = new Krypton.Toolkit.KryptonButton();
            this.button_cancel = new Krypton.Toolkit.KryptonButton();
            this.label_columnName = new Krypton.Toolkit.KryptonLabel();
            this.comboBox_filterType = new Krypton.Toolkit.KryptonComboBox();
            this.label_and = new Krypton.Toolkit.KryptonLabel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            ((System.ComponentModel.ISupportInitialize)(this.comboBox_filterType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_ok
            // 
            this.button_ok.CornerRoundingRadius = -1F;
            this.button_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button_ok.Location = new System.Drawing.Point(40, 139);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 0;
            this.button_ok.Values.Text = "OK";
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.CornerRoundingRadius = -1F;
            this.button_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_cancel.Location = new System.Drawing.Point(121, 139);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 1;
            this.button_cancel.Values.Text = "Cancel";
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // label_columnName
            // 
            this.label_columnName.Location = new System.Drawing.Point(4, 9);
            this.label_columnName.Name = "label_columnName";
            this.label_columnName.Size = new System.Drawing.Size(138, 20);
            this.label_columnName.TabIndex = 2;
            this.label_columnName.Values.Text = "Show rows where value";
            // 
            // comboBox_filterType
            // 
            this.comboBox_filterType.CornerRoundingRadius = -1F;
            this.comboBox_filterType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_filterType.DropDownWidth = 189;
            this.comboBox_filterType.FormattingEnabled = true;
            this.comboBox_filterType.IntegralHeight = false;
            this.comboBox_filterType.Location = new System.Drawing.Point(7, 35);
            this.comboBox_filterType.Name = "comboBox_filterType";
            this.comboBox_filterType.Size = new System.Drawing.Size(189, 21);
            this.comboBox_filterType.TabIndex = 3;
            this.comboBox_filterType.SelectedIndexChanged += new System.EventHandler(this.comboBox_filterType_SelectedIndexChanged);
            // 
            // label_and
            // 
            this.label_and.Location = new System.Drawing.Point(7, 89);
            this.label_and.Name = "label_and";
            this.label_and.Size = new System.Drawing.Size(33, 20);
            this.label_and.TabIndex = 6;
            this.label_and.Values.Text = "And";
            this.label_and.Visible = false;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.label_columnName);
            this.kryptonPanel1.Controls.Add(this.comboBox_filterType);
            this.kryptonPanel1.Controls.Add(this.label_and);
            this.kryptonPanel1.Controls.Add(this.button_cancel);
            this.kryptonPanel1.Controls.Add(this.button_ok);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(205, 169);
            this.kryptonPanel1.TabIndex = 7;
            // 
            // FormCustomFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button_cancel;
            this.ClientSize = new System.Drawing.Size(205, 169);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCustomFilter";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Custom Filter";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormCustomFilter_Load);
            ((System.ComponentModel.ISupportInitialize)(this.comboBox_filterType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonButton button_ok;
        private KryptonButton button_cancel;
        private KryptonLabel label_columnName;
        private KryptonComboBox comboBox_filterType;
        private KryptonLabel label_and;
        private ErrorProvider errorProvider;

        #endregion

        #region class properties

        private enum FilterType
        {
            Unknown,
            DateTime,
            TimeSpan,
            String,
            Float,
            Integer
        }

        private FilterType _filterType = FilterType.Unknown;
        private Control _valControl1 = null;
        private Control _valControl2 = null;

        private bool _filterDateAndTimeEnabled = true;

        private string? _filterString = null;
        private KryptonPanel kryptonPanel1;
        private string _filterStringDescription = null;

        #endregion


        #region constructors

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="filterDateAndTimeEnabled"></param>
        public FormCustomFilter(Type dataType, bool filterDateAndTimeEnabled)
            : base()
        {
            //initialize components
            InitializeComponent();

            //set component translations
            Text = KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewFormTitle.ToString()];
            label_columnName.Text = KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewLabelColumnNameText.ToString()];
            label_and.Text = KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewLabelAnd.ToString()];
            button_ok.Text = KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewButtonOk.ToString()];
            button_cancel.Text = KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewButtonCancel.ToString()];

            if (dataType == typeof(DateTime))
                _filterType = FilterType.DateTime;
            else if (dataType == typeof(TimeSpan))
                _filterType = FilterType.TimeSpan;
            else if (dataType == typeof(Int32) || dataType == typeof(Int64) || dataType == typeof(Int16) ||
                    dataType == typeof(UInt32) || dataType == typeof(UInt64) || dataType == typeof(UInt16) ||
                    dataType == typeof(Byte) || dataType == typeof(SByte))
                _filterType = FilterType.Integer;
            else if (dataType == typeof(Single) || dataType == typeof(Double) || dataType == typeof(Decimal))
                _filterType = FilterType.Float;
            else if (dataType == typeof(String))
                _filterType = FilterType.String;
            else
                _filterType = FilterType.Unknown;

            _filterDateAndTimeEnabled = filterDateAndTimeEnabled;

            switch (_filterType)
            {
                case FilterType.DateTime:
                    _valControl1 = new DateTimePicker();
                    _valControl2 = new DateTimePicker();
                    if (_filterDateAndTimeEnabled)
                    {
                        DateTimeFormatInfo dt = Thread.CurrentThread.CurrentCulture.DateTimeFormat;

                        (_valControl1 as DateTimePicker).CustomFormat = dt.ShortDatePattern + " " + "HH:mm";
                        (_valControl2 as DateTimePicker).CustomFormat = dt.ShortDatePattern + " " + "HH:mm";
                        (_valControl1 as DateTimePicker).Format = DateTimePickerFormat.Custom;
                        (_valControl2 as DateTimePicker).Format = DateTimePickerFormat.Custom;
                    }
                    else
                    {
                        (_valControl1 as DateTimePicker).Format = DateTimePickerFormat.Short;
                        (_valControl2 as DateTimePicker).Format = DateTimePickerFormat.Short;
                    }

                    comboBox_filterType.Items.AddRange(new string[] {
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewEquals.ToString()],
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewDoesNotEqual.ToString()],
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewEarlierThan.ToString()],
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewEarlierThanOrEqualTo.ToString()],
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewLaterThan.ToString()],
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewLaterThanOrEqualTo.ToString()],
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewBetween.ToString()]
                    });
                    break;

                case FilterType.TimeSpan:
                    _valControl1 = new TextBox();
                    _valControl2 = new TextBox();
                    comboBox_filterType.Items.AddRange(new string[] {
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewContains.ToString()],
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewDoesNotContain.ToString()]
                    });
                    break;

                case FilterType.Integer:
                case FilterType.Float:
                    _valControl1 = new TextBox();
                    _valControl2 = new TextBox();
                    _valControl1.TextChanged += valControl_TextChanged;
                    _valControl2.TextChanged += valControl_TextChanged;
                    comboBox_filterType.Items.AddRange(new string[] {
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewEquals.ToString()],
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewDoesNotEqual.ToString()],
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewGreaterThan.ToString()],
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewGreaterThanOrEqualTo.ToString()],
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewLessThan.ToString()],
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewLessThanOrEqualTo.ToString()],
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewBetween.ToString()]
                    });
                    _valControl1.Tag = true;
                    _valControl2.Tag = true;
                    button_ok.Enabled = false;
                    break;

                default:
                    _valControl1 = new TextBox();
                    _valControl2 = new TextBox();
                    comboBox_filterType.Items.AddRange(new string[] {
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewEquals.ToString()],
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewDoesNotEqual.ToString()],
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewBeginsWith.ToString()],
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewDoesNotBeginWith.ToString()],
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewEndsWith.ToString()],
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewDoesNotEndWith.ToString()],
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewContains.ToString()],
                        KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewDoesNotContain.ToString()]
                    });
                    break;
            }
            comboBox_filterType.SelectedIndex = 0;

            _valControl1.Name = "valControl1";
            _valControl1.Location = new Point(20, 66);
            _valControl1.Size = new Size(166, 20);
            _valControl1.Width = comboBox_filterType.Width - 20;
            _valControl1.TabIndex = 4;
            _valControl1.Visible = true;
            _valControl1.KeyDown += valControl_KeyDown;

            _valControl2.Name = "valControl2";
            _valControl2.Location = new Point(20, 108);
            _valControl2.Size = new Size(166, 20);
            _valControl2.Width = comboBox_filterType.Width - 20;
            _valControl2.TabIndex = 5;
            _valControl2.Visible = false;
            _valControl2.VisibleChanged += new EventHandler(valControl2_VisibleChanged);
            _valControl2.KeyDown += valControl_KeyDown;

            Controls.Add(_valControl1);
            Controls.Add(_valControl2);

            errorProvider.SetIconAlignment(_valControl1, ErrorIconAlignment.MiddleRight);
            errorProvider.SetIconPadding(_valControl1, -18);
            errorProvider.SetIconAlignment(_valControl2, ErrorIconAlignment.MiddleRight);
            errorProvider.SetIconPadding(_valControl2, -18);
        }

        /// <summary>
        /// Form loaders
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCustomFilter_Load(object sender, EventArgs e)
        { }

        #endregion


        #region public filter methods

        /// <summary>
        /// Get the Filter string
        /// </summary>
        public string? FilterString
        {
            get
            {
                return _filterString;
            }
        }

        /// <summary>
        /// Get the Filter string description
        /// </summary>
        public string FilterStringDescription
        {
            get
            {
                return _filterStringDescription;
            }
        }

        #endregion


        #region filter builder

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

            string? column = "[{0}] ";

            if (filterType == FilterType.Unknown)
                column = "Convert([{0}], 'System.String') ";

            filterString = column;

            switch (filterType)
            {
                case FilterType.DateTime:
                    DateTime dt = ((DateTimePicker)control1).Value;
                    dt = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0);

                    if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewEquals.ToString()])
                        filterString = "Convert([{0}], 'System.String') LIKE '%" + Convert.ToString((filterDateAndTimeEnabled ? dt : dt.Date), CultureInfo.CurrentCulture) + "%'";
                    else if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewEarlierThan.ToString()])
                        filterString += "< '" + Convert.ToString((filterDateAndTimeEnabled ? dt : dt.Date), CultureInfo.CurrentCulture) + "'";
                    else if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewEarlierThanOrEqualTo.ToString()])
                        filterString += "<= '" + Convert.ToString((filterDateAndTimeEnabled ? dt : dt.Date), CultureInfo.CurrentCulture) + "'";
                    else if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewLaterThan.ToString()])
                        filterString += "> '" + Convert.ToString((filterDateAndTimeEnabled ? dt : dt.Date), CultureInfo.CurrentCulture) + "'";
                    else if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewLaterThanOrEqualTo.ToString()])
                        filterString += ">= '" + Convert.ToString((filterDateAndTimeEnabled ? dt : dt.Date), CultureInfo.CurrentCulture) + "'";
                    else if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewBetween.ToString()])
                    {
                        DateTime dt1 = ((DateTimePicker)control2).Value;
                        dt1 = new DateTime(dt1.Year, dt1.Month, dt1.Day, dt1.Hour, dt1.Minute, 0);
                        filterString += ">= '" + Convert.ToString((filterDateAndTimeEnabled ? dt : dt.Date), CultureInfo.CurrentCulture) + "'";
                        filterString += " AND " + column + "<= '" + Convert.ToString((filterDateAndTimeEnabled ? dt1 : dt1.Date), CultureInfo.CurrentCulture) + "'";
                    }
                    else if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewDoesNotEqual.ToString()])
                        filterString = "Convert([{0}], 'System.String') NOT LIKE '%" + Convert.ToString((filterDateAndTimeEnabled ? dt : dt.Date), CultureInfo.CurrentCulture) + "%'";
                    break;

                case FilterType.TimeSpan:
                    try
                    {
                        TimeSpan ts = TimeSpan.Parse(control1.Text);

                        if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewContains.ToString()])
                        {
                            filterString = "(Convert([{0}], 'System.String') LIKE '%P" + ((int)ts.Days > 0 ? (int)ts.Days + "D" : "") + (ts.TotalHours > 0 ? "T" : "") + ((int)ts.Hours > 0 ? (int)ts.Hours + "H" : "") + ((int)ts.Minutes > 0 ? (int)ts.Minutes + "M" : "") + ((int)ts.Seconds > 0 ? (int)ts.Seconds + "S" : "") + "%')";
                        }
                        else if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewDoesNotContain.ToString()])
                        {
                            filterString = "(Convert([{0}], 'System.String') NOT LIKE '%P" + ((int)ts.Days > 0 ? (int)ts.Days + "D" : "") + (ts.TotalHours > 0 ? "T" : "") + ((int)ts.Hours > 0 ? (int)ts.Hours + "H" : "") + ((int)ts.Minutes > 0 ? (int)ts.Minutes + "M" : "") + ((int)ts.Seconds > 0 ? (int)ts.Seconds + "S" : "") + "%')";
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
                        num = num.Replace(",", ".");

                    if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewEquals.ToString()])
                        filterString += "= " + num;
                    else if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewBetween.ToString()])
                        filterString += ">= " + num + " AND " + column + "<= " + (filterType == FilterType.Float ? control2.Text.Replace(",", ".") : control2.Text);
                    else if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewDoesNotEqual.ToString()])
                        filterString += "<> " + num;
                    else if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewGreaterThan.ToString()])
                        filterString += "> " + num;
                    else if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewGreaterThanOrEqualTo.ToString()])
                        filterString += ">= " + num;
                    else if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewLessThan.ToString()])
                        filterString += "< " + num;
                    else if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewLessThanOrEqualTo.ToString()])
                        filterString += "<= " + num;
                    break;

                default:
                    string txt = FormatFilterString(control1.Text);
                    if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewEquals.ToString()])
                        filterString += "LIKE '" + txt + "'";
                    else if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewDoesNotEqual.ToString()])
                        filterString += "NOT LIKE '" + txt + "'";
                    else if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewBeginsWith.ToString()])
                        filterString += "LIKE '" + txt + "%'";
                    else if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewEndsWith.ToString()])
                        filterString += "LIKE '%" + txt + "'";
                    else if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewDoesNotBeginWith.ToString()])
                        filterString += "NOT LIKE '" + txt + "%'";
                    else if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewDoesNotEndWith.ToString()])
                        filterString += "NOT LIKE '%" + txt + "'";
                    else if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewContains.ToString()])
                        filterString += "LIKE '%" + txt + "%'";
                    else if (filterTypeConditionText == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewDoesNotContain.ToString()])
                        filterString += "NOT LIKE '%" + txt + "%'";
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
            string[] replace = { "%", "[", "]", "*", "\"", "\\" };

            for (int i = 0; i < text.Length; i++)
            {
                s = text[i].ToString();
                if (replace.Contains(s))
                    result += "[" + s + "]";
                else
                    result += s;
            }

            return result.Replace("'", "''");
        }


        #endregion


        #region buttons events

        /// <summary>
        /// Button Cancel Clieck
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_cancel_Click(object sender, EventArgs e)
        {
            _filterStringDescription = null;
            _filterString = null;
            Close();
        }

        /// <summary>
        /// Button OK Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_ok_Click(object sender, EventArgs e)
        {
            if ((_valControl1.Visible && _valControl1.Tag != null && ((bool)_valControl1.Tag)) ||
                (_valControl2.Visible && _valControl2.Tag != null && ((bool)_valControl2.Tag)))
            {
                button_ok.Enabled = false;
                return;
            }

            string? filterString = BuildCustomFilter(_filterType, _filterDateAndTimeEnabled, comboBox_filterType.Text, _valControl1, _valControl2);

            if (!String.IsNullOrEmpty(filterString))
            {
                _filterString = filterString;
                _filterStringDescription = String.Format(KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewFilterStringDescription.ToString()], comboBox_filterType.Text, _valControl1.Text);
                if (_valControl2.Visible)
                    _filterStringDescription += " " + label_and.Text + " \"" + _valControl2.Text + "\"";
                DialogResult = DialogResult.OK;
            }
            else
            {
                _filterString = null;
                _filterStringDescription = null;
                DialogResult = DialogResult.Cancel;
            }

            Close();
        }

        #endregion


        #region changed status events

        /// <summary>
        /// Changed condition type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_filterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            _valControl2.Visible = comboBox_filterType.Text == KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewBetween.ToString()];
            button_ok.Enabled = !(_valControl1.Visible && _valControl1.Tag != null && ((bool)_valControl1.Tag)) ||
                (_valControl2.Visible && _valControl2.Tag != null && ((bool)_valControl2.Tag));
        }

        /// <summary>
        /// Changed control2 visibility
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void valControl2_VisibleChanged(object sender, EventArgs e)
        {
            label_and.Visible = _valControl2.Visible;
        }

        /// <summary>
        /// Changed a control Text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void valControl_TextChanged(object sender, EventArgs e)
        {
            bool hasErrors = false;
            switch (_filterType)
            {
                case FilterType.Integer:
                    Int64 val;
                    hasErrors = !(Int64.TryParse((sender as TextBox).Text, out val));
                    break;

                case FilterType.Float:
                    Double val1;
                    hasErrors = !(Double.TryParse((sender as TextBox).Text, out val1));
                    break;
            }

            (sender as Control).Tag = hasErrors || (sender as TextBox).Text.Length == 0;

            if (hasErrors && (sender as TextBox).Text.Length > 0)
                errorProvider.SetError((sender as Control), KryptonAdvancedDataGridView.Translations[TranslationKey.KryptonAdvancedDataGridViewInvalidValue.ToString()]);
            else
                errorProvider.SetError((sender as Control), "");

            button_ok.Enabled = !(_valControl1.Visible && _valControl1.Tag != null && ((bool)_valControl1.Tag)) ||
                (_valControl2.Visible && _valControl2.Tag != null && ((bool)_valControl2.Tag));
        }

        /// <summary>
        /// KeyDown on a control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void valControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (sender == _valControl1)
                {
                    if (_valControl2.Visible)
                        _valControl2.Focus();
                    else
                        button_ok_Click(button_ok, new EventArgs());
                }
                else
                {
                    button_ok_Click(button_ok, new EventArgs());
                }

                e.SuppressKeyPress = false;
                e.Handled = true;
            }
        }

        #endregion
    }
}