using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    public class FindWindown : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnFindNext;
        private KryptonButton kbtnClose;
        private System.Windows.Forms.Panel panel1;
        private KryptonCheckBox kchkMatchCase;
        private KryptonCheckBox kchkMatchWholeWord;
        private KryptonCheckBox kchkUseRegex;
        private KryptonTextBox ktxtSearchTerm;
        private KryptonLabel kryptonLabel1;
        private KryptonPanel kryptonPanel2;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnClose = new Krypton.Toolkit.KryptonButton();
            this.kbtnFindNext = new Krypton.Toolkit.KryptonButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.ktxtSearchTerm = new Krypton.Toolkit.KryptonTextBox();
            this.kchkUseRegex = new Krypton.Toolkit.KryptonCheckBox();
            this.kchkMatchWholeWord = new Krypton.Toolkit.KryptonCheckBox();
            this.kchkMatchCase = new Krypton.Toolkit.KryptonCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnFindNext);
            this.kryptonPanel1.Controls.Add(this.kbtnClose);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 76);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(400, 47);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnClose
            // 
            this.kbtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnClose.Location = new System.Drawing.Point(298, 10);
            this.kbtnClose.Name = "kbtnClose";
            this.kbtnClose.Size = new System.Drawing.Size(90, 25);
            this.kbtnClose.TabIndex = 0;
            this.kbtnClose.Values.Text = "C&lose";
            this.kbtnClose.Click += new System.EventHandler(this.kbtnClose_Click);
            // 
            // kbtnFindNext
            // 
            this.kbtnFindNext.Enabled = false;
            this.kbtnFindNext.Location = new System.Drawing.Point(202, 10);
            this.kbtnFindNext.Name = "kbtnFindNext";
            this.kbtnFindNext.Size = new System.Drawing.Size(90, 25);
            this.kbtnFindNext.TabIndex = 1;
            this.kbtnFindNext.Values.Text = "Find &Next";
            this.kbtnFindNext.Click += new System.EventHandler(this.kbtnFindNext_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 3);
            this.panel1.TabIndex = 1;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kchkMatchCase);
            this.kryptonPanel2.Controls.Add(this.kchkMatchWholeWord);
            this.kryptonPanel2.Controls.Add(this.kchkUseRegex);
            this.kryptonPanel2.Controls.Add(this.ktxtSearchTerm);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(400, 73);
            this.kryptonPanel2.TabIndex = 2;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(36, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Find:";
            // 
            // ktxtSearchTerm
            // 
            this.ktxtSearchTerm.Hint = "Enter a search term...";
            this.ktxtSearchTerm.Location = new System.Drawing.Point(54, 9);
            this.ktxtSearchTerm.Name = "ktxtSearchTerm";
            this.ktxtSearchTerm.Size = new System.Drawing.Size(334, 23);
            this.ktxtSearchTerm.TabIndex = 1;
            this.ktxtSearchTerm.TextChanged += new System.EventHandler(this.ktxtSearchTerm_TextChanged);
            this.ktxtSearchTerm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ktxtSearchTerm_KeyPress);
            // 
            // kchkUseRegex
            // 
            this.kchkUseRegex.Location = new System.Drawing.Point(283, 38);
            this.kchkUseRegex.Name = "kchkUseRegex";
            this.kchkUseRegex.Size = new System.Drawing.Size(80, 20);
            this.kchkUseRegex.TabIndex = 2;
            this.kchkUseRegex.Values.Text = "Use &Regex";
            // 
            // kchkMatchWholeWord
            // 
            this.kchkMatchWholeWord.Location = new System.Drawing.Point(147, 38);
            this.kchkMatchWholeWord.Name = "kchkMatchWholeWord";
            this.kchkMatchWholeWord.Size = new System.Drawing.Size(130, 20);
            this.kchkMatchWholeWord.TabIndex = 3;
            this.kchkMatchWholeWord.Values.Text = "&Match Whole Word";
            // 
            // kchkMatchCase
            // 
            this.kchkMatchCase.Location = new System.Drawing.Point(54, 38);
            this.kchkMatchCase.Name = "kchkMatchCase";
            this.kchkMatchCase.Size = new System.Drawing.Size(87, 20);
            this.kchkMatchCase.TabIndex = 4;
            this.kchkMatchCase.Values.Text = "Match &Case";
            this.kchkMatchCase.CheckedChanged += new System.EventHandler(this.kchkMatchCase_CheckedChanged);
            // 
            // FindWindown
            // 
            this.AcceptButton = this.kbtnFindNext;
            this.BlurValues.BlurWhenFocusLost = true;
            this.BlurValues.EnableBlur = true;
            this.CancelButton = this.kbtnClose;
            this.ClientSize = new System.Drawing.Size(400, 123);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindWindown";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FindWindown_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private bool _firstSearch = true;

        private Place _startPlace;

        private FastColouredTextBox _textBox;
        #endregion

        #region Constructor
        public FindWindown(FastColouredTextBox textBox)
        {
            InitializeComponent();

            _textBox = textBox;
        }
        #endregion

        private void kbtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void kbtnFindNext_Click(object sender, EventArgs e)
        {
            FindNext(kbtnFindNext.Text);
        }

        public virtual void FindNext(string pattern)
        {
            try
            {
                RegexOptions opt = kchkMatchCase.Checked ? RegexOptions.None : RegexOptions.IgnoreCase;
                if (!kchkUseRegex.Checked)
                    pattern = Regex.Escape(pattern);
                if (kchkMatchWholeWord.Checked)
                    pattern = "\\b" + pattern + "\\b";
                //
                Range range = _textBox.Selection.Clone();
                range.Normalize();
                //
                if (_firstSearch)
                {
                    _startPlace = range.Start;
                    _firstSearch = false;
                }
                //
                range.Start = range.End;
                if (range.Start >= _startPlace)
                    range.End = new Place(_textBox.GetLineLength(_textBox.LinesCount - 1), _textBox.LinesCount - 1);
                else
                    range.End = _startPlace;
                //
                foreach (var r in range.GetRangesByLines(pattern, opt))
                {
                    _textBox.Selection = r;
                    _textBox.DoSelectionVisible();
                    _textBox.Invalidate();
                    return;
                }
                //
                if (range.Start >= _startPlace && _startPlace > Place.Empty)
                {
                    _textBox.Selection.Start = new Place(0, 0);
                    FindNext(pattern);
                    return;
                }
                KryptonMessageBox.Show("Not found");
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
        }

        private void ktxtSearchTerm_TextChanged(object sender, EventArgs e)
        {
            kbtnFindNext.Enabled = string.IsNullOrWhiteSpace(kbtnFindNext.Text);
        }

        private void ktxtSearchTerm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                kbtnFindNext.PerformClick();
                e.Handled = true;
                return;
            }
            if (e.KeyChar == '\x1b')
            {
                Hide();
                e.Handled = true;
                return;
            }
        }

        private void FindWindown_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
            _textBox.Focus();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void OnActivated(EventArgs e)
        {
            kbtnFindNext.Focus();
            ResetSerach();
        }

        private void ResetSerach() => _firstSearch = true;

        private void kchkMatchCase_CheckedChanged(object sender, EventArgs e)
        {
            ResetSerach();
        }
    }
}