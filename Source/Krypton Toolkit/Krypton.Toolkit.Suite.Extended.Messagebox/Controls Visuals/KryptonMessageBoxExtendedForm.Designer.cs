﻿#region MIT License
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

namespace Krypton.Toolkit.Suite.Extended.Messagebox
{
    partial class KryptonMessageBoxExtendedForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this._panelButtons = new Krypton.Toolkit.KryptonPanel();
            this._borderEdge = new Krypton.Toolkit.KryptonBorderEdge();
            this._button4 = new Krypton.Toolkit.Suite.Extended.Messagebox.MessageButton();
            this._button3 = new Krypton.Toolkit.Suite.Extended.Messagebox.MessageButton();
            this._button1 = new Krypton.Toolkit.Suite.Extended.Messagebox.MessageButton();
            this._button2 = new Krypton.Toolkit.Suite.Extended.Messagebox.MessageButton();
            this._messageIcon = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.kcbOptionalCheckBox = new Krypton.Toolkit.KryptonCheckBox();
            this.kpnlContent = new Krypton.Toolkit.KryptonPanel();
            this.kwlblMessageText = new Krypton.Toolkit.KryptonWrapLabel();
            this.klwlblMessageText = new Krypton.Toolkit.KryptonLinkWrapLabel();
            this.krtbMessageText = new Krypton.Toolkit.KryptonRichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._panelButtons)).BeginInit();
            this._panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._messageIcon)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlContent)).BeginInit();
            this.kpnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.tableLayoutPanel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(188, 88);
            this.kryptonPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this._panelButtons, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this._messageIcon, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(188, 88);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // _panelButtons
            // 
            this.tableLayoutPanel1.SetColumnSpan(this._panelButtons, 2);
            this._panelButtons.Controls.Add(this._borderEdge);
            this._panelButtons.Controls.Add(this._button4);
            this._panelButtons.Controls.Add(this._button3);
            this._panelButtons.Controls.Add(this._button1);
            this._panelButtons.Controls.Add(this._button2);
            this._panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panelButtons.Location = new System.Drawing.Point(0, 67);
            this._panelButtons.Margin = new System.Windows.Forms.Padding(0);
            this._panelButtons.Name = "_panelButtons";
            this._panelButtons.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this._panelButtons.Size = new System.Drawing.Size(188, 21);
            this._panelButtons.TabIndex = 0;
            // 
            // _borderEdge
            // 
            this._borderEdge.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderPrimary;
            this._borderEdge.Dock = System.Windows.Forms.DockStyle.Top;
            this._borderEdge.Location = new System.Drawing.Point(0, 0);
            this._borderEdge.Margin = new System.Windows.Forms.Padding(2);
            this._borderEdge.Name = "_borderEdge";
            this._borderEdge.Size = new System.Drawing.Size(188, 1);
            this._borderEdge.Text = "kryptonBorderEdge1";
            // 
            // _button4
            // 
            this._button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._button4.AutoSize = true;
            this._button4.CornerRoundingRadius = -1F;
            this._button4.Enabled = false;
            this._button4.IgnoreAltF4 = false;
            this._button4.Location = new System.Drawing.Point(188, 0);
            this._button4.Margin = new System.Windows.Forms.Padding(0);
            this._button4.MinimumSize = new System.Drawing.Size(38, 21);
            this._button4.Name = "_button4";
            this._button4.Size = new System.Drawing.Size(38, 24);
            this._button4.TabIndex = 2;
            this._button4.Values.Text = "B4";
            this._button4.Visible = false;
            // 
            // _button3
            // 
            this._button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._button3.AutoSize = true;
            this._button3.CornerRoundingRadius = -1F;
            this._button3.Enabled = false;
            this._button3.IgnoreAltF4 = false;
            this._button3.Location = new System.Drawing.Point(151, 0);
            this._button3.Margin = new System.Windows.Forms.Padding(0);
            this._button3.MinimumSize = new System.Drawing.Size(38, 21);
            this._button3.Name = "_button3";
            this._button3.Size = new System.Drawing.Size(38, 24);
            this._button3.TabIndex = 2;
            this._button3.Values.Text = "B3";
            this._button3.Visible = false;
            // 
            // _button1
            // 
            this._button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._button1.AutoSize = true;
            this._button1.CornerRoundingRadius = -1F;
            this._button1.Enabled = false;
            this._button1.IgnoreAltF4 = false;
            this._button1.Location = new System.Drawing.Point(75, 0);
            this._button1.Margin = new System.Windows.Forms.Padding(0);
            this._button1.MinimumSize = new System.Drawing.Size(38, 21);
            this._button1.Name = "_button1";
            this._button1.Size = new System.Drawing.Size(38, 24);
            this._button1.TabIndex = 0;
            this._button1.Values.Text = "B1";
            this._button1.Visible = false;
            // 
            // _button2
            // 
            this._button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._button2.AutoSize = true;
            this._button2.CornerRoundingRadius = -1F;
            this._button2.Enabled = false;
            this._button2.IgnoreAltF4 = false;
            this._button2.Location = new System.Drawing.Point(113, 0);
            this._button2.Margin = new System.Windows.Forms.Padding(0);
            this._button2.MinimumSize = new System.Drawing.Size(38, 21);
            this._button2.Name = "_button2";
            this._button2.Size = new System.Drawing.Size(38, 24);
            this._button2.TabIndex = 1;
            this._button2.Values.Text = "B2";
            this._button2.Visible = false;
            // 
            // _messageIcon
            // 
            this._messageIcon.BackColor = System.Drawing.Color.Transparent;
            this._messageIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this._messageIcon.Location = new System.Drawing.Point(8, 4);
            this._messageIcon.Margin = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this._messageIcon.Name = "_messageIcon";
            this._messageIcon.Size = new System.Drawing.Size(33, 59);
            this._messageIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this._messageIcon.TabIndex = 0;
            this._messageIcon.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.kcbOptionalCheckBox, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.kpnlContent, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(48, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(137, 61);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // kcbOptionalCheckBox
            // 
            this.kcbOptionalCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kcbOptionalCheckBox.Location = new System.Drawing.Point(3, 38);
            this.kcbOptionalCheckBox.Name = "kcbOptionalCheckBox";
            this.kcbOptionalCheckBox.Size = new System.Drawing.Size(131, 20);
            this.kcbOptionalCheckBox.TabIndex = 0;
            this.kcbOptionalCheckBox.Values.Text = "CB1";
            this.kcbOptionalCheckBox.CheckedChanged += new System.EventHandler(this.OptionalCheckBox_CheckedChanged);
            // 
            // kpnlContent
            // 
            this.kpnlContent.Controls.Add(this.kwlblMessageText);
            this.kpnlContent.Controls.Add(this.klwlblMessageText);
            this.kpnlContent.Controls.Add(this.krtbMessageText);
            this.kpnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpnlContent.Location = new System.Drawing.Point(3, 3);
            this.kpnlContent.Name = "kpnlContent";
            this.kpnlContent.Size = new System.Drawing.Size(131, 29);
            this.kpnlContent.TabIndex = 1;
            // 
            // kwlblMessageText
            // 
            this.kwlblMessageText.AutoSize = false;
            this.kwlblMessageText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kwlblMessageText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kwlblMessageText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlblMessageText.LabelStyle = Krypton.Toolkit.LabelStyle.AlternateControl;
            this.kwlblMessageText.Location = new System.Drawing.Point(0, 0);
            this.kwlblMessageText.Name = "kwlblMessageText";
            this.kwlblMessageText.Size = new System.Drawing.Size(131, 29);
            this.kwlblMessageText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // klwlblMessageText
            // 
            this.klwlblMessageText.AutoSize = false;
            this.klwlblMessageText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klwlblMessageText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.klwlblMessageText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.klwlblMessageText.LabelStyle = Krypton.Toolkit.LabelStyle.AlternateControl;
            this.klwlblMessageText.Location = new System.Drawing.Point(0, 0);
            this.klwlblMessageText.Name = "klwlblMessageText";
            this.klwlblMessageText.Size = new System.Drawing.Size(131, 29);
            this.klwlblMessageText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // krtbMessageText
            // 
            this.krtbMessageText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.krtbMessageText.Location = new System.Drawing.Point(0, 0);
            this.krtbMessageText.Name = "krtbMessageText";
            this.krtbMessageText.ReadOnly = true;
            this.krtbMessageText.Size = new System.Drawing.Size(131, 29);
            this.krtbMessageText.TabIndex = 0;
            this.krtbMessageText.Text = "";
            // 
            // KryptonMessageBoxExtendedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(188, 88);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonMessageBoxExtendedForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._panelButtons)).EndInit();
            this._panelButtons.ResumeLayout(false);
            this._panelButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._messageIcon)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlContent)).EndInit();
            this.kpnlContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonPanel kryptonPanel1;
        private TableLayoutPanel tableLayoutPanel1;
        private KryptonPanel _panelButtons;
        private KryptonBorderEdge _borderEdge;
        private MessageButton _button4;
        private MessageButton _button3;
        private MessageButton _button1;
        private MessageButton _button2;
        private PictureBox _messageIcon;
        private TableLayoutPanel tableLayoutPanel2;
        private KryptonCheckBox kcbOptionalCheckBox;
        private KryptonPanel kpnlContent;
        private KryptonRichTextBox krtbMessageText;
        private KryptonLinkWrapLabel klwlblMessageText;
        private KryptonWrapLabel kwlblMessageText;
    }
}