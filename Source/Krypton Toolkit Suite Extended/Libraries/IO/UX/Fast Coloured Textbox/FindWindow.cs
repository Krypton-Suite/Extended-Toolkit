using Krypton.Toolkit.Suite.Extended.Base;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.IO
{
    public class FindWindow : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnFindNext;
        private KryptonCheckBox kcbRegex;
        private KryptonCheckBox kcbMatchWholeWord;
        private KryptonCheckBox kcbMatchCase;
        private KryptonTextBox ktxtFind;
        private KryptonLabel kryptonLabel1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnFindNext = new Krypton.Toolkit.KryptonButton();
            this.kcbRegex = new Krypton.Toolkit.KryptonCheckBox();
            this.kcbMatchWholeWord = new Krypton.Toolkit.KryptonCheckBox();
            this.kcbMatchCase = new Krypton.Toolkit.KryptonCheckBox();
            this.ktxtFind = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnFindNext);
            this.kryptonPanel1.Controls.Add(this.kcbRegex);
            this.kryptonPanel1.Controls.Add(this.kcbMatchWholeWord);
            this.kryptonPanel1.Controls.Add(this.kcbMatchCase);
            this.kryptonPanel1.Controls.Add(this.ktxtFind);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(356, 98);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnFindNext
            // 
            this.kbtnFindNext.Location = new System.Drawing.Point(158, 64);
            this.kbtnFindNext.Name = "kbtnFindNext";
            this.kbtnFindNext.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnFindNext.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnFindNext.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnFindNext.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnFindNext.Size = new System.Drawing.Size(90, 25);
            this.kbtnFindNext.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnFindNext.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnFindNext.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnFindNext.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnFindNext.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnFindNext.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnFindNext.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnFindNext.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnFindNext.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnFindNext.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnFindNext.TabIndex = 1;
            this.kbtnFindNext.Values.Text = "&Find Next";
            this.kbtnFindNext.Click += new System.EventHandler(this.kbtnFindNext_Click);
            // 
            // kcbRegex
            // 
            this.kcbRegex.Location = new System.Drawing.Point(283, 38);
            this.kcbRegex.Name = "kcbRegex";
            this.kcbRegex.Size = new System.Drawing.Size(57, 20);
            this.kcbRegex.TabIndex = 4;
            this.kcbRegex.Values.Text = "&Regex";
            // 
            // kcbMatchWholeWord
            // 
            this.kcbMatchWholeWord.Location = new System.Drawing.Point(147, 38);
            this.kcbMatchWholeWord.Name = "kcbMatchWholeWord";
            this.kcbMatchWholeWord.Size = new System.Drawing.Size(130, 20);
            this.kcbMatchWholeWord.TabIndex = 3;
            this.kcbMatchWholeWord.Values.Text = "Match &Whole Word";
            // 
            // kcbMatchCase
            // 
            this.kcbMatchCase.Location = new System.Drawing.Point(54, 38);
            this.kcbMatchCase.Name = "kcbMatchCase";
            this.kcbMatchCase.Size = new System.Drawing.Size(87, 20);
            this.kcbMatchCase.TabIndex = 2;
            this.kcbMatchCase.Values.Text = "Match &Case";
            this.kcbMatchCase.CheckedChanged += new System.EventHandler(this.kcbMatchCase_CheckedChanged);
            // 
            // ktxtFind
            // 
            this.ktxtFind.Hint = "Find...";
            this.ktxtFind.Location = new System.Drawing.Point(54, 9);
            this.ktxtFind.Name = "ktxtFind";
            this.ktxtFind.Size = new System.Drawing.Size(290, 23);
            this.ktxtFind.TabIndex = 1;
            this.ktxtFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ktxtFind_KeyPress);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(36, 20);
            this.kryptonLabel1.TabIndex = 1;
            this.kryptonLabel1.Values.Text = "Find:";
            // 
            // FindWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 98);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FindWindow_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private bool _firstSearch = true;

        private Place _startPlace;

        private FastColouredTextBox _textBox;
        #endregion

        #region Constructor
        public FindWindow(FastColouredTextBox textBox)
        {
            InitializeComponent();

            _textBox = textBox;
        }
        #endregion

        #region Methods
        public virtual void FindNext(string pattern)
        {
            try
            {
                RegexOptions opt = kcbMatchCase.Checked ? RegexOptions.None : RegexOptions.IgnoreCase;
                if (!kcbRegex.Checked)
                    pattern = Regex.Escape(pattern);
                if (kcbMatchWholeWord.Checked)
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
                KryptonMessageBoxExtended.Show("Not found");
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        [Browsable(false)]
        public KryptonTextBox FindBox { get => ktxtFind; }

        private void kbtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void kbtnFindNext_Click(object sender, EventArgs e)
        {
            FindNext(ktxtFind.Text);
        }

        private void ktxtFind_KeyPress(object sender, KeyPressEventArgs e)
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

        private void FindWindow_FormClosing(object sender, FormClosingEventArgs e)
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
            ktxtFind.Focus();
            ResetSerach();
        }

        private void ResetSerach() => _firstSearch = true;

        private void kcbMatchCase_CheckedChanged(object sender, EventArgs e) => ResetSerach();
    }
}