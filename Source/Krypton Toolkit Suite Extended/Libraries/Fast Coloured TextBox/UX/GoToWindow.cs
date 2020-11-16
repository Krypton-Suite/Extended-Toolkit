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
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    public class GoToWindow : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnOk;
        private System.Windows.Forms.Panel panel1;
        private KryptonPanel kryptonPanel2;
        private KryptonTextBox ktxtLineNumber;
        private KryptonLabel klblLineNumber;
        private KryptonNumericUpDown knudLineNumber;
        private KryptonButton kbtnCancel;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnOk = new Krypton.Toolkit.KryptonButton();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.klblLineNumber = new Krypton.Toolkit.KryptonLabel();
            this.ktxtLineNumber = new Krypton.Toolkit.KryptonTextBox();
            this.knudLineNumber = new Krypton.Toolkit.KryptonNumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnOk);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 76);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(400, 47);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kbtnOk
            // 
            this.kbtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnOk.Location = new System.Drawing.Point(202, 10);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new System.Drawing.Size(90, 25);
            this.kbtnOk.TabIndex = 1;
            this.kbtnOk.Values.Text = "&OK";
            this.kbtnOk.Click += new System.EventHandler(this.kbtnOk_Click);
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(298, 10);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 0;
            this.kbtnCancel.Values.Text = "C&ancel";
            this.kbtnCancel.Click += new System.EventHandler(this.kbtnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 3);
            this.panel1.TabIndex = 2;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.knudLineNumber);
            this.kryptonPanel2.Controls.Add(this.ktxtLineNumber);
            this.kryptonPanel2.Controls.Add(this.klblLineNumber);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(400, 73);
            this.kryptonPanel2.TabIndex = 3;
            // 
            // klblLineNumber
            // 
            this.klblLineNumber.Location = new System.Drawing.Point(12, 12);
            this.klblLineNumber.Name = "klblLineNumber";
            this.klblLineNumber.Size = new System.Drawing.Size(128, 20);
            this.klblLineNumber.TabIndex = 4;
            this.klblLineNumber.Values.Text = "Line Number ({0}/{1}):";
            // 
            // ktxtLineNumber
            // 
            this.ktxtLineNumber.Hint = "Enter a line number...";
            this.ktxtLineNumber.Location = new System.Drawing.Point(12, 38);
            this.ktxtLineNumber.MaxLength = 10;
            this.ktxtLineNumber.Name = "ktxtLineNumber";
            this.ktxtLineNumber.Size = new System.Drawing.Size(376, 23);
            this.ktxtLineNumber.TabIndex = 5;
            this.ktxtLineNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // knudLineNumber
            // 
            this.knudLineNumber.Location = new System.Drawing.Point(12, 38);
            this.knudLineNumber.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.knudLineNumber.Name = "knudLineNumber";
            this.knudLineNumber.Size = new System.Drawing.Size(376, 22);
            this.knudLineNumber.TabIndex = 4;
            // 
            // GoToWindow
            // 
            this.AcceptButton = this.kbtnOk;
            this.BlurValues.BlurWhenFocusLost = true;
            this.BlurValues.EnableBlur = true;
            this.CancelButton = this.kbtnCancel;
            this.ClientSize = new System.Drawing.Size(400, 123);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GoToWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Go To Line";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region Properties
        public int SelectedLineNumber { get; set; }

        public int TotalLineCount { get; set; }
        #endregion

        #region Constructor
        public GoToWindow(bool useNumericBox = false)
        {
            InitializeComponent();

            knudLineNumber.Visible = useNumericBox;
        }
        #endregion

        #region Overrides
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (knudLineNumber.Visible)
            {
                knudLineNumber.Value = SelectedLineNumber;
            }
            else
            {
                ktxtLineNumber.Text = SelectedLineNumber.ToString();
            }

            klblLineNumber.Text = $"Line Number (1 - { TotalLineCount }:";
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (knudLineNumber.Visible)
            {
                knudLineNumber.Focus();
            }
            else
            {
                ktxtLineNumber.Focus();
            }
        }
        #endregion

        private void kbtnOk_Click(object sender, EventArgs e)
        {
            int enteredLine;

            if (knudLineNumber.Visible)
            {
                string value = knudLineNumber.Value.ToString();

                if (int.TryParse(value, out enteredLine))
                {
                    enteredLine = Math.Min(enteredLine, TotalLineCount);

                    enteredLine = Math.Max(1, enteredLine);

                    SelectedLineNumber = enteredLine;
                }
            }
            else
            {
                if (int.TryParse(ktxtLineNumber.Text, out enteredLine))
                {
                    enteredLine = Math.Min(enteredLine, TotalLineCount);

                    enteredLine = Math.Max(1, enteredLine);

                    SelectedLineNumber = enteredLine;
                }
            }

            DialogResult = DialogResult.OK;

            Close();
        }

        private void kbtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }
    }
}