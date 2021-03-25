#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */

// Original license

/**
* THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
* KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
* IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
* PURPOSE.
*
* License: GNU Lesser General Public License (LGPLv3)
*
* Email: pavel_torgashov@ukr.net.
*
* Copyright (C) Pavel Torgashov, 2011-2016.
*/
#endregion

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    public class ReplaceWindow : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private System.Windows.Forms.Panel panel1;
        private KryptonPanel kryptonPanel2;
        private KryptonTextBox ktxtReplacementTerm;
        private KryptonLabel kryptonLabel2;
        private KryptonCheckBox kchkMatchCase;
        private KryptonCheckBox kchkMatchWholeWord;
        private KryptonCheckBox kchkUseRegex;
        private KryptonTextBox ktxtSearchTerm;
        private KryptonLabel kryptonLabel1;
        private KryptonButton kbtnReplace;
        private KryptonButton kbtnReplaceAll;
        private KryptonButton kbtnFindNext;
        private KryptonButton kbtnClose;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnClose = new Krypton.Toolkit.KryptonButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kchkMatchCase = new Krypton.Toolkit.KryptonCheckBox();
            this.kchkMatchWholeWord = new Krypton.Toolkit.KryptonCheckBox();
            this.kchkUseRegex = new Krypton.Toolkit.KryptonCheckBox();
            this.ktxtSearchTerm = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.ktxtReplacementTerm = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kbtnFindNext = new Krypton.Toolkit.KryptonButton();
            this.kbtnReplaceAll = new Krypton.Toolkit.KryptonButton();
            this.kbtnReplace = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnClose);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 137);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(445, 47);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kbtnClose
            // 
            this.kbtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnClose.Location = new System.Drawing.Point(343, 10);
            this.kbtnClose.Name = "kbtnClose";
            this.kbtnClose.Size = new System.Drawing.Size(90, 25);
            this.kbtnClose.TabIndex = 0;
            this.kbtnClose.Values.Text = "C&lose";
            this.kbtnClose.Click += new System.EventHandler(this.kbtnClose_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 134);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(445, 3);
            this.panel1.TabIndex = 2;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kbtnReplace);
            this.kryptonPanel2.Controls.Add(this.kbtnReplaceAll);
            this.kryptonPanel2.Controls.Add(this.kbtnFindNext);
            this.kryptonPanel2.Controls.Add(this.ktxtReplacementTerm);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel2.Controls.Add(this.kchkMatchCase);
            this.kryptonPanel2.Controls.Add(this.kchkMatchWholeWord);
            this.kryptonPanel2.Controls.Add(this.kchkUseRegex);
            this.kryptonPanel2.Controls.Add(this.ktxtSearchTerm);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(445, 134);
            this.kryptonPanel2.TabIndex = 3;
            // 
            // kchkMatchCase
            // 
            this.kchkMatchCase.Location = new System.Drawing.Point(103, 41);
            this.kchkMatchCase.Name = "kchkMatchCase";
            this.kchkMatchCase.Size = new System.Drawing.Size(87, 20);
            this.kchkMatchCase.TabIndex = 9;
            this.kchkMatchCase.Values.Text = "Match &Case";
            this.kchkMatchCase.CheckedChanged += new System.EventHandler(this.kchkMatchCase_CheckedChanged);
            // 
            // kchkMatchWholeWord
            // 
            this.kchkMatchWholeWord.Location = new System.Drawing.Point(196, 41);
            this.kchkMatchWholeWord.Name = "kchkMatchWholeWord";
            this.kchkMatchWholeWord.Size = new System.Drawing.Size(130, 20);
            this.kchkMatchWholeWord.TabIndex = 8;
            this.kchkMatchWholeWord.Values.Text = "&Match Whole Word";
            // 
            // kchkUseRegex
            // 
            this.kchkUseRegex.Location = new System.Drawing.Point(332, 41);
            this.kchkUseRegex.Name = "kchkUseRegex";
            this.kchkUseRegex.Size = new System.Drawing.Size(80, 20);
            this.kchkUseRegex.TabIndex = 7;
            this.kchkUseRegex.Values.Text = "Use &Regex";
            // 
            // ktxtSearchTerm
            // 
            this.ktxtSearchTerm.Hint = "Enter a search term...";
            this.ktxtSearchTerm.Location = new System.Drawing.Point(103, 12);
            this.ktxtSearchTerm.Name = "ktxtSearchTerm";
            this.ktxtSearchTerm.Size = new System.Drawing.Size(334, 23);
            this.ktxtSearchTerm.TabIndex = 6;
            this.ktxtSearchTerm.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ktxtSearchTerm_KeyPress);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(36, 20);
            this.kryptonLabel1.TabIndex = 5;
            this.kryptonLabel1.Values.Text = "Find:";
            // 
            // ktxtReplacementTerm
            // 
            this.ktxtReplacementTerm.Hint = "Enter a replacment term...";
            this.ktxtReplacementTerm.Location = new System.Drawing.Point(103, 64);
            this.ktxtReplacementTerm.Name = "ktxtReplacementTerm";
            this.ktxtReplacementTerm.Size = new System.Drawing.Size(334, 23);
            this.ktxtReplacementTerm.TabIndex = 11;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(12, 67);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(85, 20);
            this.kryptonLabel2.TabIndex = 10;
            this.kryptonLabel2.Values.Text = "Replace With:";
            // 
            // kbtnFindNext
            // 
            this.kbtnFindNext.Enabled = false;
            this.kbtnFindNext.Location = new System.Drawing.Point(151, 93);
            this.kbtnFindNext.Name = "kbtnFindNext";
            this.kbtnFindNext.Size = new System.Drawing.Size(90, 25);
            this.kbtnFindNext.TabIndex = 12;
            this.kbtnFindNext.Values.Text = "Find &Next";
            this.kbtnFindNext.Click += new System.EventHandler(this.kbtnFindNext_Click);
            // 
            // kbtnReplaceAll
            // 
            this.kbtnReplaceAll.Enabled = false;
            this.kbtnReplaceAll.Location = new System.Drawing.Point(343, 93);
            this.kbtnReplaceAll.Name = "kbtnReplaceAll";
            this.kbtnReplaceAll.Size = new System.Drawing.Size(90, 25);
            this.kbtnReplaceAll.TabIndex = 13;
            this.kbtnReplaceAll.Values.Text = "Replace &All";
            this.kbtnReplaceAll.Click += new System.EventHandler(this.kbtnReplaceAll_Click);
            // 
            // kbtnReplace
            // 
            this.kbtnReplace.Enabled = false;
            this.kbtnReplace.Location = new System.Drawing.Point(247, 93);
            this.kbtnReplace.Name = "kbtnReplace";
            this.kbtnReplace.Size = new System.Drawing.Size(90, 25);
            this.kbtnReplace.TabIndex = 14;
            this.kbtnReplace.Values.Text = "&Replace";
            this.kbtnReplace.Click += new System.EventHandler(this.kbtnReplace_Click);
            // 
            // ReplaceWindow
            // 
            this.AcceptButton = this.kbtnFindNext;
            this.CancelButton = this.kbtnClose;
            this.ClientSize = new System.Drawing.Size(445, 184);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReplaceWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find and Replace";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ReplaceWindow_FormClosing);
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

        private FastColouredTextBox _textBox;

        private Place _startPlace;
        #endregion

        #region Properties
        public KryptonTextBox FindBox => ktxtSearchTerm;
        #endregion

        #region Constructor
        public ReplaceWindow(FastColouredTextBox textBox)
        {
            InitializeComponent();

            _textBox = textBox;
        }
        #endregion

        #region Event Handlers
        private void kbtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void kbtnFindNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Find(ktxtSearchTerm.Text))
                {
                    KryptonMessageBox.Show("Not found!");
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
        }

        private void kbtnReplace_Click(object sender, EventArgs e)
        {
            try
            {
                if (_textBox.SelectionLength != 0)
                {
                    if (!_textBox.Selection.ReadOnly)
                    {
                        _textBox.InsertText(ktxtReplacementTerm.Text);
                    }
                }

                kbtnFindNext_Click(sender, null);
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
        }

        private void kbtnReplaceAll_Click(object sender, EventArgs e)
        {
            try
            {
                _textBox.Selection.BeginUpdate();

                //search
                var ranges = FindAll(ktxtSearchTerm.Text);
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
                        _textBox.TextSource.Manager.ExecuteCommand(new ReplaceTextCommand(_textBox.TextSource, ranges, ktxtReplacementTerm.Text));
                        _textBox.Selection.Start = new Place(0, 0);
                    }
                //
                _textBox.Invalidate();
                KryptonMessageBox.Show($"{ ranges.Count } occurrence(s) replaced");
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
            _textBox.Selection.EndUpdate();
        }

        private void ReplaceWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;

                Hide();
            }

            _textBox.Focus();
        }

        private void kchkMatchCase_CheckedChanged(object sender, EventArgs e)
        {
            ResetSearch();
        }

        private void ktxtSearchTerm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                kbtnFindNext_Click(sender, null);
            }

            if (e.KeyChar == '\x1b')
            {
                Hide();
            }
        }
        #endregion

        #region Methods
        public List<Range> FindAll(string pattern)
        {
            var opt = kchkMatchCase.Checked ? RegexOptions.None : RegexOptions.IgnoreCase;

            if (!kchkUseRegex.Checked)
            {
                pattern = Regex.Escape(pattern);
            }

            if (kchkMatchWholeWord.Checked)
            {
                pattern = $"\\b { pattern } \\b";
            }

            var range = _textBox.Selection.IsEmpty ? _textBox.Range.Clone() : _textBox.Range.Clone();

            var list = new List<Range>();

            foreach (var r in range.GetRangesByLines(pattern, opt))
            {
                list.Add(r);
            }

            return list;
        }

        public bool Find(string pattern)
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
                _textBox.Selection.Start = r.Start;
                _textBox.Selection.End = r.End;
                _textBox.DoSelectionVisible();
                _textBox.Invalidate();
                return true;
            }
            if (range.Start >= _startPlace && _startPlace > Place.Empty)
            {
                _textBox.Selection.Start = new Place(0, 0);
                return Find(pattern);
            }
            return false;
        }

        private void ResetSearch() => _firstSearch = true;
        #endregion

        #region Overrides
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                Close();

                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void OnActivated(EventArgs e)
        {
            ktxtSearchTerm.Focus();

            ResetSearch();
        }
        #endregion
    }
}