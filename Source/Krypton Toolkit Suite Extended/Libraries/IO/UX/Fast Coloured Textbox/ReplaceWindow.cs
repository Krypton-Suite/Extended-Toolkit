using Krypton.Toolkit.Suite.Extended.Base;
using Krypton.Toolkit.Suite.Extended.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.IO
{
    public class ReplaceWindow : KryptonForm
    {
        #region Design Code
        private KryptonTextBox ktxtReplace;
        private KryptonLabel kryptonLabel2;
        private KryptonCheckBox kcbRegex;
        private KryptonCheckBox kcbMatchWholeWord;
        private KryptonCheckBox kcbMatchCase;
        private KryptonTextBox ktxtFind;
        private KryptonLabel kryptonLabel1;
        private KryptonButton kbtnReplaceAll;
        private KryptonButton kbtnReplace;
        private KryptonButton kbtnFindNext;
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnReplaceAll = new Krypton.Toolkit.KryptonButton();
            this.kbtnReplace = new Krypton.Toolkit.KryptonButton();
            this.kbtnFindNext = new Krypton.Toolkit.KryptonButton();
            this.ktxtReplace = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
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
            this.kryptonPanel1.Controls.Add(this.kbtnReplaceAll);
            this.kryptonPanel1.Controls.Add(this.kbtnReplace);
            this.kryptonPanel1.Controls.Add(this.kbtnFindNext);
            this.kryptonPanel1.Controls.Add(this.ktxtReplace);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel1.Controls.Add(this.kcbRegex);
            this.kryptonPanel1.Controls.Add(this.kcbMatchWholeWord);
            this.kryptonPanel1.Controls.Add(this.kcbMatchCase);
            this.kryptonPanel1.Controls.Add(this.ktxtFind);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(390, 191);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnReplaceAll
            // 
            this.kbtnReplaceAll.Location = new System.Drawing.Point(288, 124);
            this.kbtnReplaceAll.Name = "kbtnReplaceAll";
            this.kbtnReplaceAll.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReplaceAll.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReplaceAll.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReplaceAll.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReplaceAll.Size = new System.Drawing.Size(90, 25);
            this.kbtnReplaceAll.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReplaceAll.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReplaceAll.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReplaceAll.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReplaceAll.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReplaceAll.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReplaceAll.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReplaceAll.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReplaceAll.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReplaceAll.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReplaceAll.TabIndex = 15;
            this.kbtnReplaceAll.Values.Text = "Replace &All";
            this.kbtnReplaceAll.Click += new System.EventHandler(this.kbtnReplaceAll_Click);
            // 
            // kbtnReplace
            // 
            this.kbtnReplace.Location = new System.Drawing.Point(192, 124);
            this.kbtnReplace.Name = "kbtnReplace";
            this.kbtnReplace.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReplace.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReplace.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReplace.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReplace.Size = new System.Drawing.Size(90, 25);
            this.kbtnReplace.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReplace.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReplace.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReplace.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReplace.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReplace.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReplace.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReplace.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReplace.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReplace.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnReplace.TabIndex = 14;
            this.kbtnReplace.Values.Text = "R&eplace";
            this.kbtnReplace.Click += new System.EventHandler(this.kbtnReplace_Click);
            // 
            // kbtnFindNext
            // 
            this.kbtnFindNext.Location = new System.Drawing.Point(96, 124);
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
            this.kbtnFindNext.TabIndex = 12;
            this.kbtnFindNext.Values.Text = "&Find Next";
            this.kbtnFindNext.Click += new System.EventHandler(this.kbtnFindNext_Click);
            // 
            // ktxtReplace
            // 
            this.ktxtReplace.Hint = "Replace with...";
            this.ktxtReplace.Location = new System.Drawing.Point(74, 82);
            this.ktxtReplace.Name = "ktxtReplace";
            this.ktxtReplace.Size = new System.Drawing.Size(304, 23);
            this.ktxtReplace.TabIndex = 10;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(12, 85);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(56, 20);
            this.kryptonLabel2.TabIndex = 11;
            this.kryptonLabel2.Values.Text = "Replace:";
            // 
            // kcbRegex
            // 
            this.kcbRegex.Location = new System.Drawing.Point(303, 38);
            this.kcbRegex.Name = "kcbRegex";
            this.kcbRegex.Size = new System.Drawing.Size(57, 20);
            this.kcbRegex.TabIndex = 9;
            this.kcbRegex.Values.Text = "&Regex";
            // 
            // kcbMatchWholeWord
            // 
            this.kcbMatchWholeWord.Location = new System.Drawing.Point(167, 38);
            this.kcbMatchWholeWord.Name = "kcbMatchWholeWord";
            this.kcbMatchWholeWord.Size = new System.Drawing.Size(130, 20);
            this.kcbMatchWholeWord.TabIndex = 8;
            this.kcbMatchWholeWord.Values.Text = "Match &Whole Word";
            // 
            // kcbMatchCase
            // 
            this.kcbMatchCase.Location = new System.Drawing.Point(74, 38);
            this.kcbMatchCase.Name = "kcbMatchCase";
            this.kcbMatchCase.Size = new System.Drawing.Size(87, 20);
            this.kcbMatchCase.TabIndex = 7;
            this.kcbMatchCase.Values.Text = "Match &Case";
            this.kcbMatchCase.CheckedChanged += new System.EventHandler(this.kcbMatchCase_CheckedChanged);
            // 
            // ktxtFind
            // 
            this.ktxtFind.Hint = "Find...";
            this.ktxtFind.Location = new System.Drawing.Point(74, 9);
            this.ktxtFind.Name = "ktxtFind";
            this.ktxtFind.Size = new System.Drawing.Size(304, 23);
            this.ktxtFind.TabIndex = 5;
            this.ktxtFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ktxtFind_KeyPress);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(32, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(36, 20);
            this.kryptonLabel1.TabIndex = 6;
            this.kryptonLabel1.Values.Text = "Find:";
            // 
            // ReplaceWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 191);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReplaceWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find and Replace";
            this.UseDropShadow = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReplaceWindow_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private FastColouredTextBox tb;

        private bool firstSearch = true;

        private Place startPlace;
        #endregion

        #region Constructor
        public ReplaceWindow(FastColouredTextBox box)
        {
            InitializeComponent();

            tb = box;
        }
        #endregion

        [Browsable(false)]
        public KryptonTextBox FindBox { get => ktxtFind; }

        [Browsable(false)]
        public KryptonTextBox ReplaceBox { get => ktxtReplace; }

        private void kbtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void kbtnFindNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Find(ktxtFind.Text))
                {
                    KryptonMessageBoxExtended.Show($"{ ktxtFind.Text } not found!");
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.CaptureException(ex);
            }
        }

        public List<Range> FindAll(string pattern)
        {
            var opt = kcbMatchCase.Checked ? RegexOptions.None : RegexOptions.IgnoreCase;
            if (!kcbRegex.Checked)
                pattern = Regex.Escape(pattern);
            if (kcbMatchWholeWord.Checked)
                pattern = "\\b" + pattern + "\\b";
            //
            var range = tb.Selection.IsEmpty ? tb.Range.Clone() : tb.Selection.Clone();
            //
            var list = new List<Range>();
            foreach (var r in range.GetRangesByLines(pattern, opt))
                list.Add(r);

            return list;
        }

        private bool Find(string pattern)
        {
            RegexOptions opt = kcbMatchCase.Checked ? RegexOptions.None : RegexOptions.IgnoreCase;
            if (!kcbRegex.Checked)
                pattern = Regex.Escape(pattern);
            if (kcbMatchWholeWord.Checked)
                pattern = "\\b" + pattern + "\\b";
            //
            Range range = tb.Selection.Clone();
            range.Normalize();
            //
            if (firstSearch)
            {
                startPlace = range.Start;
                firstSearch = false;
            }
            //
            range.Start = range.End;
            if (range.Start >= startPlace)
                range.End = new Place(tb.GetLineLength(tb.LinesCount - 1), tb.LinesCount - 1);
            else
                range.End = startPlace;
            //
            foreach (var r in range.GetRangesByLines(pattern, opt))
            {
                tb.Selection.Start = r.Start;
                tb.Selection.End = r.End;
                tb.DoSelectionVisible();
                tb.Invalidate();
                return true;
            }
            if (range.Start >= startPlace && startPlace > Place.Empty)
            {
                tb.Selection.Start = new Place(0, 0);
                return Find(pattern);
            }
            return false;
        }

        private void ktxtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                kbtnFindNext_Click(sender, null);
            if (e.KeyChar == '\x1b')
                Hide();
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

        private void ReplaceWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
            this.tb.Focus();
        }

        private void kbtnReplace_Click(object sender, EventArgs e)
        {
            try
            {
                if (tb.SelectionLength != 0)
                    if (!tb.Selection.ReadOnly)
                        tb.InsertText(ktxtReplace.Text);
                kbtnFindNext_Click(sender, null);
            }
            catch (Exception ex)
            {
                ExceptionHandler.CaptureException(ex);
            }
        }

        private void kbtnReplaceAll_Click(object sender, EventArgs e)
        {
            try
            {
                tb.Selection.BeginUpdate();

                //search
                var ranges = FindAll(ktxtFind.Text);
                //check readonly
                var ro = false;
                foreach (var r in ranges)
                    if (r.ReadOnly)
                    {
                        ro = true;
                        break;
                    }
                //replace
                if (!ro)
                    if (ranges.Count > 0)
                    {
                        tb.TextSource.Manager.ExecuteCommand(new ReplaceTextCommand(tb.TextSource, ranges, ktxtReplace.Text));
                        tb.Selection.Start = new Place(0, 0);
                    }
                //
                tb.Invalidate();
                KryptonMessageBoxExtended.Show(ranges.Count + " occurrence(s) replaced");
            }
            catch (Exception ex)
            {
                ExceptionHandler.CaptureException(ex);
            }
            tb.Selection.EndUpdate();
        }

        protected override void OnActivated(EventArgs e)
        {
            ktxtFind.Focus();
            ResetSerach();
        }

        private void ResetSerach() => firstSearch = true;

        private void kcbMatchCase_CheckedChanged(object sender, EventArgs e)
        {
            ResetSerach();
        }
    }
}