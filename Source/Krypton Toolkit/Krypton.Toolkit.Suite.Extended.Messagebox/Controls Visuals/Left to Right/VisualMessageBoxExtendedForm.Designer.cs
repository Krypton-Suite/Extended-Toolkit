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

namespace Krypton.Toolkit.Suite.Extended.Messagebox
{
    partial class VisualMessageBoxExtendedForm
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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this._panelButtons = new Krypton.Toolkit.KryptonPanel();
            this._borderEdge = new Krypton.Toolkit.KryptonBorderEdge();
            this._button4 = new Krypton.Toolkit.Suite.Extended.Messagebox.MessageButton();
            this._button3 = new Krypton.Toolkit.Suite.Extended.Messagebox.MessageButton();
            this._button1 = new Krypton.Toolkit.Suite.Extended.Messagebox.MessageButton();
            this._button2 = new Krypton.Toolkit.Suite.Extended.Messagebox.MessageButton();
            this._messageIcon = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.kcbOptionalCheckBox = new Krypton.Toolkit.KryptonCheckBox();
            this._panelFooter = new Krypton.Toolkit.KryptonPanel();
            this.tlpFooter = new System.Windows.Forms.TableLayoutPanel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this._expandButton = new Krypton.Toolkit.Suite.Extended.Messagebox.MessageButton();
            this.kryptonPanel3 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonRichTextBox1 = new Krypton.Toolkit.KryptonRichTextBox();
            this.krtbMessageText = new Krypton.Toolkit.KryptonRichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._panelButtons)).BeginInit();
            this._panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._messageIcon)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._panelFooter)).BeginInit();
            this._panelFooter.SuspendLayout();
            this.tlpFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).BeginInit();
            this.kryptonPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.tlpMain);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(292, 134);
            this.kryptonPanel1.TabIndex = 2;
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.Color.Transparent;
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this._panelButtons, 0, 1);
            this.tlpMain.Controls.Add(this._messageIcon, 0, 0);
            this.tlpMain.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(2);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.Size = new System.Drawing.Size(292, 134);
            this.tlpMain.TabIndex = 0;
            // 
            // _panelButtons
            // 
            this.tlpMain.SetColumnSpan(this._panelButtons, 2);
            this._panelButtons.Controls.Add(this._borderEdge);
            this._panelButtons.Controls.Add(this._button4);
            this._panelButtons.Controls.Add(this._button3);
            this._panelButtons.Controls.Add(this._button1);
            this._panelButtons.Controls.Add(this._button2);
            this._panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panelButtons.Location = new System.Drawing.Point(0, 113);
            this._panelButtons.Margin = new System.Windows.Forms.Padding(0);
            this._panelButtons.Name = "_panelButtons";
            this._panelButtons.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this._panelButtons.Size = new System.Drawing.Size(292, 21);
            this._panelButtons.TabIndex = 0;
            // 
            // _borderEdge
            // 
            this._borderEdge.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderPrimary;
            this._borderEdge.Dock = System.Windows.Forms.DockStyle.Top;
            this._borderEdge.Location = new System.Drawing.Point(0, 0);
            this._borderEdge.Margin = new System.Windows.Forms.Padding(2);
            this._borderEdge.Name = "_borderEdge";
            this._borderEdge.Size = new System.Drawing.Size(292, 1);
            this._borderEdge.Text = "kryptonBorderEdge1";
            // 
            // _button4
            // 
            this._button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._button4.AutoSize = true;
            this._button4.Enabled = false;
            this._button4.Location = new System.Drawing.Point(292, 0);
            this._button4.Margin = new System.Windows.Forms.Padding(0);
            this._button4.MinimumSize = new System.Drawing.Size(38, 21);
            this._button4.Name = "_button4";
            this._button4.Size = new System.Drawing.Size(38, 24);
            this._button4.TabIndex = 2;
            this._button4.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this._button4.Values.Text = "B4";
            this._button4.Visible = false;
            // 
            // _button3
            // 
            this._button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._button3.AutoSize = true;
            this._button3.Enabled = false;
            this._button3.Location = new System.Drawing.Point(255, 0);
            this._button3.Margin = new System.Windows.Forms.Padding(0);
            this._button3.MinimumSize = new System.Drawing.Size(38, 21);
            this._button3.Name = "_button3";
            this._button3.Size = new System.Drawing.Size(38, 24);
            this._button3.TabIndex = 2;
            this._button3.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this._button3.Values.Text = "B3";
            this._button3.Visible = false;
            // 
            // _button1
            // 
            this._button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._button1.AutoSize = true;
            this._button1.Enabled = false;
            this._button1.Location = new System.Drawing.Point(179, 0);
            this._button1.Margin = new System.Windows.Forms.Padding(0);
            this._button1.MinimumSize = new System.Drawing.Size(38, 21);
            this._button1.Name = "_button1";
            this._button1.Size = new System.Drawing.Size(38, 24);
            this._button1.TabIndex = 0;
            this._button1.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this._button1.Values.Text = "B1";
            this._button1.Visible = false;
            // 
            // _button2
            // 
            this._button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._button2.AutoSize = true;
            this._button2.Enabled = false;
            this._button2.Location = new System.Drawing.Point(217, 0);
            this._button2.Margin = new System.Windows.Forms.Padding(0);
            this._button2.MinimumSize = new System.Drawing.Size(38, 21);
            this._button2.Name = "_button2";
            this._button2.Size = new System.Drawing.Size(38, 24);
            this._button2.TabIndex = 1;
            this._button2.Values.DropDownArrowColor = System.Drawing.Color.Empty;
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
            this._messageIcon.Size = new System.Drawing.Size(33, 105);
            this._messageIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this._messageIcon.TabIndex = 0;
            this._messageIcon.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.krtbMessageText, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.kcbOptionalCheckBox, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(48, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(241, 107);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // kcbOptionalCheckBox
            // 
            this.kcbOptionalCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kcbOptionalCheckBox.Location = new System.Drawing.Point(3, 84);
            this.kcbOptionalCheckBox.Name = "kcbOptionalCheckBox";
            this.kcbOptionalCheckBox.Size = new System.Drawing.Size(235, 20);
            this.kcbOptionalCheckBox.TabIndex = 0;
            this.kcbOptionalCheckBox.Values.Text = "CB1";
            this.kcbOptionalCheckBox.CheckedChanged += new System.EventHandler(this.OptionalCheckBox_CheckedChanged);
            // 
            // _panelFooter
            // 
            this._panelFooter.Controls.Add(this.tlpFooter);
            this._panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._panelFooter.Location = new System.Drawing.Point(0, 134);
            this._panelFooter.Name = "_panelFooter";
            this._panelFooter.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this._panelFooter.Size = new System.Drawing.Size(292, 100);
            this._panelFooter.TabIndex = 3;
            this._panelFooter.Visible = false;
            // 
            // tlpFooter
            // 
            this.tlpFooter.BackColor = System.Drawing.Color.Transparent;
            this.tlpFooter.ColumnCount = 1;
            this.tlpFooter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFooter.Controls.Add(this.kryptonPanel2, 0, 0);
            this.tlpFooter.Controls.Add(this.kryptonPanel3, 0, 1);
            this.tlpFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpFooter.Location = new System.Drawing.Point(0, 0);
            this.tlpFooter.Name = "tlpFooter";
            this.tlpFooter.RowCount = 2;
            this.tlpFooter.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpFooter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpFooter.Size = new System.Drawing.Size(292, 100);
            this.tlpFooter.TabIndex = 0;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this._expandButton);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(3, 3);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel2.Size = new System.Drawing.Size(286, 25);
            this.kryptonPanel2.TabIndex = 0;
            // 
            // _expandButton
            // 
            this._expandButton.Enabled = false;
            this._expandButton.Location = new System.Drawing.Point(0, 0);
            this._expandButton.Name = "_expandButton";
            this._expandButton.Size = new System.Drawing.Size(90, 24);
            this._expandButton.TabIndex = 2;
            this._expandButton.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this._expandButton.Values.Text = "Expand ▼";
            this._expandButton.Visible = false;
            this._expandButton.Click += new System.EventHandler(this.expandButton_Click);
            // 
            // kryptonPanel3
            // 
            this.kryptonPanel3.Controls.Add(this.kryptonRichTextBox1);
            this.kryptonPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel3.Location = new System.Drawing.Point(3, 34);
            this.kryptonPanel3.Name = "kryptonPanel3";
            this.kryptonPanel3.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel3.Size = new System.Drawing.Size(286, 63);
            this.kryptonPanel3.TabIndex = 1;
            // 
            // kryptonRichTextBox1
            // 
            this.kryptonRichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonRichTextBox1.InputControlStyle = Krypton.Toolkit.InputControlStyle.PanelAlternate;
            this.kryptonRichTextBox1.Location = new System.Drawing.Point(0, 0);
            this.kryptonRichTextBox1.Name = "kryptonRichTextBox1";
            this.kryptonRichTextBox1.ReadOnly = true;
            this.kryptonRichTextBox1.Size = new System.Drawing.Size(286, 63);
            this.kryptonRichTextBox1.TabIndex = 0;
            this.kryptonRichTextBox1.Text = "kryptonRichTextBox1";
            // 
            // krtbMessageText
            // 
            this.krtbMessageText.DetectUrls = false;
            this.krtbMessageText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.krtbMessageText.InputControlStyle = Krypton.Toolkit.InputControlStyle.PanelClient;
            this.krtbMessageText.Location = new System.Drawing.Point(0, 0);
            this.krtbMessageText.Margin = new System.Windows.Forms.Padding(0);
            this.krtbMessageText.Name = "krtbMessageText";
            this.krtbMessageText.ReadOnly = true;
            this.krtbMessageText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.krtbMessageText.Size = new System.Drawing.Size(241, 81);
            this.krtbMessageText.StateCommon.Border.DrawBorders = Krypton.Toolkit.PaletteDrawBorders.None;
            this.krtbMessageText.TabIndex = 1;
            this.krtbMessageText.Text = "Message Text\n.\ttabbed";
            this.krtbMessageText.WordWrap = false;
            // 
            // VisualMessageBoxExtendedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 234);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this._panelFooter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VisualMessageBoxExtendedForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._panelButtons)).EndInit();
            this._panelButtons.ResumeLayout(false);
            this._panelButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._messageIcon)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._panelFooter)).EndInit();
            this._panelFooter.ResumeLayout(false);
            this.tlpFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel3)).EndInit();
            this.kryptonPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonPanel kryptonPanel1;
        private TableLayoutPanel tlpMain;
        private KryptonPanel _panelButtons;
        private KryptonBorderEdge _borderEdge;
        private MessageButton _button4;
        private MessageButton _button3;
        private MessageButton _button1;
        private MessageButton _button2;
        private PictureBox _messageIcon;
        private TableLayoutPanel tableLayoutPanel2;
        private KryptonCheckBox kcbOptionalCheckBox;
        private KryptonPanel _panelFooter;
        private TableLayoutPanel tlpFooter;
        private KryptonPanel kryptonPanel2;
        private MessageButton _expandButton;
        private KryptonPanel kryptonPanel3;
        private KryptonRichTextBox kryptonRichTextBox1;
        private KryptonRichTextBox krtbMessageText;
    }
}