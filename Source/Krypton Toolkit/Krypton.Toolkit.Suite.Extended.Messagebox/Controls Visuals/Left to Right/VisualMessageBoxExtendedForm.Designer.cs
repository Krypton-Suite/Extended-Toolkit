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
            this._panelExpandButton = new Krypton.Toolkit.KryptonPanel();
            this._footerPanel = new Krypton.Toolkit.KryptonPanel();
            this._footerLabel = new Krypton.Toolkit.KryptonTextBox();
            this._messageIcon = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.kcbOptionalCheckBox = new Krypton.Toolkit.KryptonCheckBox();
            this.kpnlContent = new Krypton.Toolkit.KryptonPanel();
            this.kwlblMessageText = new Krypton.Toolkit.KryptonTextBox();
            this.klwlblMessageText = new Krypton.Toolkit.KryptonLinkWrapLabel();
            this.krtbMessageText = new Krypton.Toolkit.KryptonRichTextBox();
            this._button4 = new Krypton.Toolkit.Suite.Extended.Messagebox.MessageButton();
            this._button3 = new Krypton.Toolkit.Suite.Extended.Messagebox.MessageButton();
            this._button1 = new Krypton.Toolkit.Suite.Extended.Messagebox.MessageButton();
            this._button2 = new Krypton.Toolkit.Suite.Extended.Messagebox.MessageButton();
            this._expandButton = new Krypton.Toolkit.Suite.Extended.Messagebox.MessageButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._panelButtons)).BeginInit();
            this._panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._panelExpandButton)).BeginInit();
            this._panelExpandButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._footerPanel)).BeginInit();
            this._footerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._messageIcon)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlContent)).BeginInit();
            this.kpnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.tlpMain);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(292, 155);
            this.kryptonPanel1.TabIndex = 2;
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.Color.Transparent;
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this._panelButtons, 0, 1);
            this.tlpMain.Controls.Add(this._panelExpandButton, 0, 2);
            this.tlpMain.Controls.Add(this._footerPanel, 0, 3);
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
            this.tlpMain.Size = new System.Drawing.Size(292, 155);
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
            this._panelButtons.Location = new System.Drawing.Point(0, 92);
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
            // _panelExpandButton
            // 
            this.tlpMain.SetColumnSpan(this._panelExpandButton, 2);
            this._panelExpandButton.Controls.Add(this._expandButton);
            this._panelExpandButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panelExpandButton.Location = new System.Drawing.Point(3, 116);
            this._panelExpandButton.Name = "_panelExpandButton";
            this._panelExpandButton.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this._panelExpandButton.Size = new System.Drawing.Size(286, 30);
            this._panelExpandButton.TabIndex = 1;
            // 
            // _footerPanel
            // 
            this.tlpMain.SetColumnSpan(this._footerPanel, 2);
            this._footerPanel.Controls.Add(this._footerLabel);
            this._footerPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._footerPanel.Location = new System.Drawing.Point(3, 153);
            this._footerPanel.Name = "_footerPanel";
            this._footerPanel.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this._footerPanel.Size = new System.Drawing.Size(286, 0);
            this._footerPanel.TabIndex = 2;
            // 
            // _footerLabel
            // 
            this._footerLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._footerLabel.InputControlStyle = Krypton.Toolkit.InputControlStyle.PanelAlternate;
            this._footerLabel.Location = new System.Drawing.Point(0, 0);
            this._footerLabel.Multiline = true;
            this._footerLabel.Name = "_footerLabel";
            this._footerLabel.ReadOnly = true;
            this._footerLabel.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._footerLabel.Size = new System.Drawing.Size(286, 0);
            this._footerLabel.TabIndex = 0;
            // 
            // _messageIcon
            // 
            this._messageIcon.BackColor = System.Drawing.Color.Transparent;
            this._messageIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this._messageIcon.Location = new System.Drawing.Point(8, 4);
            this._messageIcon.Margin = new System.Windows.Forms.Padding(8, 4, 4, 4);
            this._messageIcon.Name = "_messageIcon";
            this._messageIcon.Size = new System.Drawing.Size(33, 84);
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(241, 86);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // kcbOptionalCheckBox
            // 
            this.kcbOptionalCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kcbOptionalCheckBox.Location = new System.Drawing.Point(3, 63);
            this.kcbOptionalCheckBox.Name = "kcbOptionalCheckBox";
            this.kcbOptionalCheckBox.Size = new System.Drawing.Size(235, 20);
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
            this.kpnlContent.Size = new System.Drawing.Size(235, 54);
            this.kpnlContent.TabIndex = 1;
            // 
            // kwlblMessageText
            // 
            this.kwlblMessageText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kwlblMessageText.InputControlStyle = Krypton.Toolkit.InputControlStyle.PanelClient;
            this.kwlblMessageText.Location = new System.Drawing.Point(0, 0);
            this.kwlblMessageText.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.kwlblMessageText.Multiline = true;
            this.kwlblMessageText.Name = "kwlblMessageText";
            this.kwlblMessageText.ReadOnly = true;
            this.kwlblMessageText.Size = new System.Drawing.Size(235, 54);
            this.kwlblMessageText.StateCommon.Border.DrawBorders = Krypton.Toolkit.PaletteDrawBorders.None;
            this.kwlblMessageText.TabIndex = 2;
            this.kwlblMessageText.Text = "Message Text\r\n.\ttabbed";
            // 
            // klwlblMessageText
            // 
            this.klwlblMessageText.AutoSize = false;
            this.klwlblMessageText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klwlblMessageText.LabelStyle = Krypton.Toolkit.LabelStyle.AlternateControl;
            this.klwlblMessageText.Location = new System.Drawing.Point(0, 0);
            this.klwlblMessageText.Name = "klwlblMessageText";
            this.klwlblMessageText.Size = new System.Drawing.Size(235, 54);
            this.klwlblMessageText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // krtbMessageText
            // 
            this.krtbMessageText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.krtbMessageText.Location = new System.Drawing.Point(0, 0);
            this.krtbMessageText.Name = "krtbMessageText";
            this.krtbMessageText.ReadOnly = true;
            this.krtbMessageText.Size = new System.Drawing.Size(235, 54);
            this.krtbMessageText.TabIndex = 0;
            this.krtbMessageText.Text = "";
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
            // _expandButton
            // 
            this._expandButton.Enabled = false;
            this._expandButton.Location = new System.Drawing.Point(3, 3);
            this._expandButton.Name = "_expandButton";
            this._expandButton.Size = new System.Drawing.Size(90, 24);
            this._expandButton.TabIndex = 1;
            this._expandButton.Values.DropDownArrowColor = System.Drawing.Color.Empty;
            this._expandButton.Values.Text = "Expand ▼";
            this._expandButton.Visible = false;
            this._expandButton.Click += new System.EventHandler(this.expandButton_Click);
            // 
            // VisualMessageBoxExtendedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 155);
            this.Controls.Add(this.kryptonPanel1);
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
            ((System.ComponentModel.ISupportInitialize)(this._panelExpandButton)).EndInit();
            this._panelExpandButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._footerPanel)).EndInit();
            this._footerPanel.ResumeLayout(false);
            this._footerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._messageIcon)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlContent)).EndInit();
            this.kpnlContent.ResumeLayout(false);
            this.kpnlContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonPanel kryptonPanel1;
        private TableLayoutPanel tlpMain;
        private KryptonPanel _panelButtons;
        private KryptonPanel _panelExpandButton;
        private KryptonBorderEdge _borderEdge;
        private MessageButton _button4;
        private MessageButton _button3;
        private MessageButton _button1;
        private MessageButton _button2;
        private PictureBox _messageIcon;
        private TableLayoutPanel tableLayoutPanel2;
        private KryptonCheckBox kcbOptionalCheckBox;
        private KryptonPanel kpnlContent;
        private KryptonTextBox kwlblMessageText;
        private KryptonLinkWrapLabel klwlblMessageText;
        private KryptonRichTextBox krtbMessageText;
        private KryptonPanel _footerPanel;
        private MessageButton _expandButton;
        private KryptonTextBox _footerLabel;
    }
}