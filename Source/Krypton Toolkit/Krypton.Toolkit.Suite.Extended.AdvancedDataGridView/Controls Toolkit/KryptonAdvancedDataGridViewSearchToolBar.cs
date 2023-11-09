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

//#pragma warning disable 
namespace Krypton.Toolkit.Suite.Extended.AdvancedDataGridView
{
    [DesignerCategory("code")]
    public partial class KryptonAdvancedDataGridViewSearchToolBar : ToolStrip
    {
        #region Design Code

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
            // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
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
            this._buttonClose = new System.Windows.Forms.ToolStripButton();
            this._labelSearch = new System.Windows.Forms.ToolStripLabel();
            this._comboBoxColumns = new System.Windows.Forms.ToolStripComboBox();
            this._textBoxSearch = new System.Windows.Forms.ToolStripTextBox();
            this._buttonFrombegin = new System.Windows.Forms.ToolStripButton();
            this._buttonCasesensitive = new System.Windows.Forms.ToolStripButton();
            this._buttonSearch = new System.Windows.Forms.ToolStripButton();
            this._buttonWholeword = new System.Windows.Forms.ToolStripButton();
            this._separatorSearch = new System.Windows.Forms.ToolStripSeparator();
            this.SuspendLayout();
            // 
            // button_close
            // 
            this._buttonClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._buttonClose.Image = global::Krypton.Toolkit.Suite.Extended.AdvancedDataGridView.Properties.Resources.SearchToolBar_ButtonCaseSensitive;
            this._buttonClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this._buttonClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._buttonClose.Name = "_buttonClose";
            this._buttonClose.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this._buttonClose.Size = new System.Drawing.Size(23, 24);
            this._buttonClose.Click += new System.EventHandler(this.button_close_Click);
            // 
            // label_search
            // 
            this._labelSearch.Name = "_labelSearch";
            this._labelSearch.Size = new System.Drawing.Size(45, 15);

            // 
            // comboBox_columns
            // 
            this._comboBoxColumns.AutoSize = false;
            this._comboBoxColumns.AutoToolTip = true;
            this._comboBoxColumns.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._comboBoxColumns.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this._comboBoxColumns.IntegralHeight = false;
            this._comboBoxColumns.Margin = new System.Windows.Forms.Padding(0, 2, 8, 2);
            this._comboBoxColumns.MaxDropDownItems = 12;
            this._comboBoxColumns.Name = "_comboBoxColumns";
            this._comboBoxColumns.Size = new System.Drawing.Size(150, 23);
            // 
            // textBox_search
            // 
            this._textBoxSearch.AutoSize = false;
            this._textBoxSearch.ForeColor = System.Drawing.Color.LightGray;
            this._textBoxSearch.Margin = new System.Windows.Forms.Padding(0, 2, 8, 2);
            this._textBoxSearch.Name = "_textBoxSearch";
            this._textBoxSearch.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this._textBoxSearch.Size = new System.Drawing.Size(100, 23);
            this._textBoxSearch.Enter += new System.EventHandler(this.textBox_search_Enter);
            this._textBoxSearch.Leave += new System.EventHandler(this.textBox_search_Leave);
            this._textBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_search_KeyDown);
            this._textBoxSearch.TextChanged += new System.EventHandler(this.textBox_search_TextChanged);
            // 
            // button_frombegin
            // 
            this._buttonFrombegin.CheckOnClick = true;
            this._buttonFrombegin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._buttonFrombegin.Image = global::Krypton.Toolkit.Suite.Extended.AdvancedDataGridView.Properties.Resources.SearchToolBar_ButtonFromBegin;
            this._buttonFrombegin.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this._buttonFrombegin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._buttonFrombegin.Name = "_buttonFrombegin";
            this._buttonFrombegin.Size = new System.Drawing.Size(23, 20);
            // 
            // button_casesensitive
            // 
            this._buttonCasesensitive.CheckOnClick = true;
            this._buttonCasesensitive.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._buttonCasesensitive.Image = global::Krypton.Toolkit.Suite.Extended.AdvancedDataGridView.Properties.Resources.SearchToolBar_ButtonCaseSensitive;
            this._buttonCasesensitive.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this._buttonCasesensitive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._buttonCasesensitive.Name = "_buttonCasesensitive";
            this._buttonCasesensitive.Size = new System.Drawing.Size(23, 20);
            // 
            // button_search
            // 
            this._buttonSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._buttonSearch.Image = global::Krypton.Toolkit.Suite.Extended.AdvancedDataGridView.Properties.Resources.SearchToolBar_ButtonSearch;
            this._buttonSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this._buttonSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._buttonSearch.Name = "_buttonSearch";
            this._buttonSearch.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this._buttonSearch.Size = new System.Drawing.Size(23, 24);
            this._buttonSearch.Click += new System.EventHandler(this.button_search_Click);
            // 
            // button_wholeword
            // 
            this._buttonWholeword.CheckOnClick = true;
            this._buttonWholeword.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._buttonWholeword.Image = global::Krypton.Toolkit.Suite.Extended.AdvancedDataGridView.Properties.Resources.SearchToolBar_ButtonWholeWord;
            this._buttonWholeword.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this._buttonWholeword.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._buttonWholeword.Margin = new System.Windows.Forms.Padding(1, 1, 1, 2);
            this._buttonWholeword.Name = "_buttonWholeword";
            this._buttonWholeword.Size = new System.Drawing.Size(23, 20);
            // 
            // separator_search
            // 
            this._separatorSearch.AutoSize = false;
            this._separatorSearch.Name = "_separatorSearch";
            this._separatorSearch.Size = new System.Drawing.Size(10, 25);
            // 
            // AdvancedDataGridViewSearchToolBar
            // 
            this.AllowMerge = false;
            this.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._buttonClose,
            this._labelSearch,
            this._comboBoxColumns,
            this._textBoxSearch,
            this._buttonFrombegin,
            this._buttonWholeword,
            this._buttonCasesensitive,
            this._separatorSearch,
            this._buttonSearch});
            this.MaximumSize = new System.Drawing.Size(0, 27);
            this.MinimumSize = new System.Drawing.Size(0, 27);
            this.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.Size = new System.Drawing.Size(0, 27);
            this.Resize += new System.EventHandler(this.ResizeMe);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolStripButton _buttonClose;
        private ToolStripLabel _labelSearch;
        private ToolStripComboBox _comboBoxColumns;
        private ToolStripTextBox _textBoxSearch;
        private ToolStripButton _buttonFrombegin;
        private ToolStripButton _buttonCasesensitive;
        private ToolStripButton _buttonSearch;
        private ToolStripButton _buttonWholeword;
        private ToolStripSeparator _separatorSearch;

        #endregion

        #region public events

        public event AdvancedDataGridViewSearchToolBarSearchEventHandler Search;

        #endregion


        #region class properties

        private DataGridViewColumnCollection? _columnsList;

        private const bool BUTTON_CLOSE_ENABLED = false;

        #endregion


        #region translations

        /// <summary>
        /// Available translation keys
        /// </summary>
        public enum TranslationKey
        {
            AdgvstbLabelSearch,
            AdgvstbButtonFromBegin,
            AdgvstbButtonCaseSensitiveToolTip,
            AdgvstbButtonSearchToolTip,
            AdgvstbButtonCloseToolTip,
            AdgvstbButtonWholeWordToolTip,
            AdgvstbComboBoxColumnsAll,
            AdgvstbTextBoxSearchToolTip
        }

        /// <summary>
        /// Internationalization strings
        /// </summary>
        public static Dictionary<string, string> Translations = new Dictionary<string, string>()
        {
            { TranslationKey.AdgvstbLabelSearch.ToString(), "Search:" },
            { TranslationKey.AdgvstbButtonFromBegin.ToString(), "From Begin" },
            { TranslationKey.AdgvstbButtonCaseSensitiveToolTip.ToString(), "Case Sensitivity" },
            { TranslationKey.AdgvstbButtonSearchToolTip.ToString(), "Find Next" },
            { TranslationKey.AdgvstbButtonCloseToolTip.ToString(), "Hide" },
            { TranslationKey.AdgvstbButtonWholeWordToolTip.ToString(), "Search only Whole Word" },
            { TranslationKey.AdgvstbComboBoxColumnsAll.ToString(), "(All Columns)" },
            { TranslationKey.AdgvstbTextBoxSearchToolTip.ToString(), "Value for Search" }
        };

        /// <summary>
        /// Used to check if components translations has to be updated
        /// </summary>
        private Dictionary<string, string> _translationsRefreshComponentTranslationsCheck = new Dictionary<string, string>() { };

        #endregion


        #region constructor

        /// <summary>Initializes a new instance of the <see cref="KryptonAdvancedDataGridViewSearchToolBar" /> class.</summary>
        public KryptonAdvancedDataGridViewSearchToolBar()
        {
            //initialize components
            InitializeComponent();

            RefreshComponentTranslations();

            //set default values
            if (!BUTTON_CLOSE_ENABLED)
            {
                Items.RemoveAt(0);
            }

            _comboBoxColumns!.SelectedIndex = 0;

            // Use Krypton
            RenderMode = ToolStripRenderMode.ManagerRenderMode;
        }

        #endregion


        #region translations methods

        /// <summary>
        /// Set translation dictionary
        /// </summary>
        /// <param name="translations"></param>
        public static void SetTranslations(IDictionary<string, string>? translations)
        {
            //set localization strings
            if (translations != null)
            {
                foreach (KeyValuePair<string, string> translation in translations)
                {
                    if (Translations.ContainsKey(translation.Key))
                    {
                        Translations[translation.Key] = translation.Value;
                    }
                }
            }
        }

        /// <summary>
        /// Get translation dictionary
        /// </summary>
        /// <returns></returns>
        public static IDictionary<string, string> GetTranslations()
        {
            return Translations;
        }

        /// <summary>
        /// Load translations from file
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static IDictionary<string, string> LoadTranslationsFromFile(string filename)
        {
            IDictionary<string, string> ret = new Dictionary<string, string>();

            if (!String.IsNullOrEmpty(filename))
            {
                //deserialize the file
                try
                {
                    string jsontext = File.ReadAllText(filename);
#if NETFRAMEWORK
                    Dictionary<string, string> translations = new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(jsontext);
#else
                    Dictionary<string, string> translations = JsonSerializer.Deserialize<Dictionary<string, string>>(jsontext);
#endif
                    foreach (KeyValuePair<string, string> translation in translations)
                    {
                        if (!ret.ContainsKey(translation.Key) && Translations.ContainsKey(translation.Key))
                        {
                            ret.Add(translation.Key, translation.Value);
                        }
                    }
                }
                catch (Exception e)
                { }
            }

            //add default translations if not in files
            foreach (KeyValuePair<string, string> translation in GetTranslations())
            {
                if (!ret.ContainsKey(translation.Key))
                {
                    ret.Add(translation.Key, translation.Value);
                }
            }

            return ret;
        }

        /// <summary>
        /// Update components translations
        /// </summary>
        private void RefreshComponentTranslations()
        {
            _comboBoxColumns.BeginUpdate();
            _comboBoxColumns.Items.Clear();
            _comboBoxColumns.Items.AddRange(new object[] { Translations[TranslationKey.AdgvstbComboBoxColumnsAll.ToString()] });
            if (_columnsList != null)
            {
                foreach (DataGridViewColumn c in _columnsList)
                    if (c.Visible)
                    {
                        _comboBoxColumns.Items.Add(c.HeaderText);
                    }
            }

            _comboBoxColumns.SelectedIndex = 0;
            _comboBoxColumns.EndUpdate();
            _buttonClose.ToolTipText = Translations[TranslationKey.AdgvstbButtonCloseToolTip.ToString()];
            _labelSearch.Text = Translations[TranslationKey.AdgvstbLabelSearch.ToString()];
            _textBoxSearch.ToolTipText = Translations[TranslationKey.AdgvstbTextBoxSearchToolTip.ToString()];
            _buttonFrombegin.ToolTipText = Translations[TranslationKey.AdgvstbButtonFromBegin.ToString()];
            _buttonCasesensitive.ToolTipText = Translations[TranslationKey.AdgvstbButtonCaseSensitiveToolTip.ToString()];
            _buttonSearch.ToolTipText = Translations[TranslationKey.AdgvstbButtonSearchToolTip.ToString()];
            _buttonWholeword.ToolTipText = Translations[TranslationKey.AdgvstbButtonWholeWordToolTip.ToString()];
            _textBoxSearch.Text = _textBoxSearch.ToolTipText;
        }

        #endregion


        #region button events

        /// <summary>
        /// button Search Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void button_search_Click(object sender, EventArgs e)
        {
            if (_textBoxSearch.TextLength > 0 && _textBoxSearch.Text != _textBoxSearch.ToolTipText && Search != null)
            {
                DataGridViewColumn? c = null;
                if (_comboBoxColumns.SelectedIndex > 0 && _columnsList != null && _columnsList.GetColumnCount(DataGridViewElementStates.Visible) > 0)
                {
                    DataGridViewColumn[] cols = _columnsList.Cast<DataGridViewColumn>().Where(col => col.Visible).ToArray<DataGridViewColumn>();

                    if (cols.Length == _comboBoxColumns.Items.Count - 1)
                    {
                        if (cols[_comboBoxColumns.SelectedIndex - 1].HeaderText == _comboBoxColumns.SelectedItem.ToString())
                        {
                            c = cols[_comboBoxColumns.SelectedIndex - 1];
                        }
                    }
                }

                AdvancedDataGridViewSearchToolBarSearchEventArgs args = new AdvancedDataGridViewSearchToolBarSearchEventArgs(
                    _textBoxSearch.Text,
                    c,
                    _buttonCasesensitive.Checked,
                    _buttonWholeword.Checked,
                    _buttonFrombegin.Checked
                );
                Search(this, args);
            }
        }

        /// <summary>
        /// button Close Click event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void button_close_Click(object sender, EventArgs e)
        {
            Hide();
        }

        #endregion


        #region textbox search events

        /// <summary>
        /// textBox Search TextChanged event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void textBox_search_TextChanged(object sender, EventArgs e)
        {
            _buttonSearch.Enabled = _textBoxSearch.TextLength > 0 && _textBoxSearch.Text != _textBoxSearch.ToolTipText;
        }


        /// <summary>
        /// textBox Search Enter event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void textBox_search_Enter(object sender, EventArgs e)
        {
            if (_textBoxSearch.Text == _textBoxSearch.ToolTipText && _textBoxSearch.ForeColor == Color.LightGray)
            {
                _textBoxSearch.Text = "";
            }
            else
            {
                _textBoxSearch.SelectAll();
            }

            _textBoxSearch.ForeColor = SystemColors.WindowText;
        }

        /// <summary>
        /// textBox Search Leave event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void textBox_search_Leave(object sender, EventArgs e)
        {
            if (_textBoxSearch.Text.Trim() == "")
            {
                _textBoxSearch.Text = _textBoxSearch.ToolTipText;
                _textBoxSearch.ForeColor = Color.LightGray;
            }
        }


        /// <summary>
        /// textBox Search KeyDown event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void textBox_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (_textBoxSearch.TextLength > 0 && _textBoxSearch.Text != _textBoxSearch.ToolTipText && e.KeyData == Keys.Enter)
            {
                button_search_Click(_buttonSearch, new EventArgs());
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
        }

        #endregion


        #region public methods

        /// <summary>
        /// Set Columns to search in
        /// </summary>
        /// <param name="columns"></param>
        public void SetColumns(DataGridViewColumnCollection columns)
        {
            _columnsList = columns;
            _comboBoxColumns.BeginUpdate();
            _comboBoxColumns.Items.Clear();
            _comboBoxColumns.Items.AddRange(new object[] { Translations[TranslationKey.AdgvstbComboBoxColumnsAll.ToString()] });
            if (_columnsList != null)
            {
                foreach (DataGridViewColumn c in _columnsList)
                    if (c.Visible)
                    {
                        _comboBoxColumns.Items.Add(c.HeaderText);
                    }
            }

            _comboBoxColumns.SelectedIndex = 0;
            _comboBoxColumns.EndUpdate();
        }

        #endregion


        #region resize events

        /// <summary>
        /// Resize event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResizeMe(object sender, EventArgs e)
        {
            SuspendLayout();
            int w1 = 150;
            int w2 = 150;
            int oldW = _comboBoxColumns.Width + _textBoxSearch.Width;
            foreach (ToolStripItem c in Items)
            {
                c.Overflow = ToolStripItemOverflow.Never;
                c.Visible = true;
            }

            int width = PreferredSize.Width - oldW + w1 + w2;
            if (Width < width)
            {
                _labelSearch.Visible = false;
                GetResizeBoxSize(PreferredSize.Width - oldW + w1 + w2, ref w1, ref w2);
                width = PreferredSize.Width - oldW + w1 + w2;

                if (Width < width)
                {
                    _buttonCasesensitive.Overflow = ToolStripItemOverflow.Always;
                    GetResizeBoxSize(PreferredSize.Width - oldW + w1 + w2, ref w1, ref w2);
                    width = PreferredSize.Width - oldW + w1 + w2;
                }

                if (Width < width)
                {
                    _buttonWholeword.Overflow = ToolStripItemOverflow.Always;
                    GetResizeBoxSize(PreferredSize.Width - oldW + w1 + w2, ref w1, ref w2);
                    width = PreferredSize.Width - oldW + w1 + w2;
                }

                if (Width < width)
                {
                    _buttonFrombegin.Overflow = ToolStripItemOverflow.Always;
                    _separatorSearch.Visible = false;
                    GetResizeBoxSize(PreferredSize.Width - oldW + w1 + w2, ref w1, ref w2);
                    width = PreferredSize.Width - oldW + w1 + w2;
                }

                if (Width < width)
                {
                    _comboBoxColumns.Overflow = ToolStripItemOverflow.Always;
                    _textBoxSearch.Overflow = ToolStripItemOverflow.Always;
                    w1 = 150;
                    w2 = Math.Max(Width - PreferredSize.Width - _textBoxSearch.Margin.Left - _textBoxSearch.Margin.Right, 75);
                    _textBoxSearch.Overflow = ToolStripItemOverflow.Never;
                    width = PreferredSize.Width - _textBoxSearch.Width + w2;
                }
                if (Width < width)
                {
                    _buttonSearch.Overflow = ToolStripItemOverflow.Always;
                    w2 = Math.Max(Width - PreferredSize.Width + _textBoxSearch.Width, 75);
                    width = PreferredSize.Width - _textBoxSearch.Width + w2;
                }
                if (Width < width)
                {
                    _buttonClose.Overflow = ToolStripItemOverflow.Always;
                    _textBoxSearch.Margin = new Padding(8, 2, 8, 2);
                    w2 = Math.Max(Width - PreferredSize.Width + _textBoxSearch.Width, 75);
                    width = PreferredSize.Width - _textBoxSearch.Width + w2;
                }

                if (Width < width)
                {
                    w2 = Math.Max(Width - PreferredSize.Width + _textBoxSearch.Width, 20);
                    width = PreferredSize.Width - _textBoxSearch.Width + w2;
                }
                if (width > Width)
                {
                    _textBoxSearch.Overflow = ToolStripItemOverflow.Always;
                    _textBoxSearch.Margin = new Padding(0, 2, 8, 2);
                    w2 = 150;
                }
            }
            else
            {
                GetResizeBoxSize(width, ref w1, ref w2);
            }

            if (_comboBoxColumns.Width != w1)
            {
                _comboBoxColumns.Width = w1;
            }

            if (_textBoxSearch.Width != w2)
            {
                _textBoxSearch.Width = w2;
            }

            ResumeLayout();
        }

        /// <summary>
        /// Get a Resize Size for a box
        /// </summary>
        /// <param name="width"></param>
        /// <param name="w1"></param>
        /// <param name="w2"></param>
        private void GetResizeBoxSize(int width, ref int w1, ref int w2)
        {
            int dif = (int)Math.Round((width - Width) / 2.0, 0, MidpointRounding.AwayFromZero);

            int oldW1 = w1;
            int oldW2 = w2;
            if (Width < width)
            {
                w1 = Math.Max(w1 - dif, 75);
                w2 = Math.Max(w2 - dif, 75);
            }
            else
            {
                w1 = Math.Min(w1 - dif, 150);
                w2 += Width - width + oldW1 - w1;
            }
        }

        #endregion


        #region paint events

        /// <summary>
        /// On Paint event
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            //check if translations are changed and update components
            if (!((_translationsRefreshComponentTranslationsCheck == Translations) || (_translationsRefreshComponentTranslationsCheck.Count == Translations.Count && !_translationsRefreshComponentTranslationsCheck.Except(Translations).Any())))
            {
                _translationsRefreshComponentTranslationsCheck = Translations;
                RefreshComponentTranslations();
            }

            base.OnPaint(e);
        }

        #endregion

    }
}