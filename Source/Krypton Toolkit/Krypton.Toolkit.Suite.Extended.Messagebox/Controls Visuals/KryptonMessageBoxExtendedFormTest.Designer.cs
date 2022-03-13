﻿namespace Krypton.Toolkit.Suite.Extended.Messagebox
{
    partial class KryptonMessageBoxExtendedFormTest
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
            this._messageText = new Krypton.Toolkit.KryptonWrapLabel();
            this._panelButtons = new Krypton.Toolkit.KryptonPanel();
            this._borderEdge = new Krypton.Toolkit.KryptonBorderEdge();
            this._button4 = new Krypton.Toolkit.Suite.Extended.Messagebox.MessageButton();
            this._button3 = new Krypton.Toolkit.Suite.Extended.Messagebox.MessageButton();
            this._button1 = new Krypton.Toolkit.Suite.Extended.Messagebox.MessageButton();
            this._button2 = new Krypton.Toolkit.Suite.Extended.Messagebox.MessageButton();
            this._messageIcon = new System.Windows.Forms.PictureBox();
            this._panelCheckBox = new Krypton.Toolkit.KryptonPanel();
            this._optionalCheckBox = new Krypton.Toolkit.KryptonCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._panelButtons)).BeginInit();
            this._panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._messageIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._panelCheckBox)).BeginInit();
            this._panelCheckBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.tableLayoutPanel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(228, 84);
            this.kryptonPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this._messageText, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this._panelButtons, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this._panelCheckBox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this._messageIcon, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(228, 84);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // _messageText
            // 
            this._messageText.AutoSize = false;
            this._messageText.Dock = System.Windows.Forms.DockStyle.Fill;
            this._messageText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this._messageText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this._messageText.LabelStyle = Krypton.Toolkit.LabelStyle.NormalControl;
            this._messageText.Location = new System.Drawing.Point(49, 0);
            this._messageText.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this._messageText.Name = "_messageText";
            this._messageText.Size = new System.Drawing.Size(179, 43);
            this._messageText.Text = "Message Text";
            this._messageText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this._panelButtons.Location = new System.Drawing.Point(0, 43);
            this._panelButtons.Margin = new System.Windows.Forms.Padding(0);
            this._panelButtons.Name = "_panelButtons";
            this._panelButtons.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this._panelButtons.Size = new System.Drawing.Size(228, 21);
            this._panelButtons.TabIndex = 0;
            // 
            // _borderEdge
            // 
            this._borderEdge.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderPrimary;
            this._borderEdge.Dock = System.Windows.Forms.DockStyle.Top;
            this._borderEdge.Location = new System.Drawing.Point(0, 0);
            this._borderEdge.Margin = new System.Windows.Forms.Padding(2);
            this._borderEdge.Name = "_borderEdge";
            this._borderEdge.Size = new System.Drawing.Size(228, 1);
            this._borderEdge.Text = "kryptonBorderEdge1";
            // 
            // _button4
            // 
            this._button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._button4.AutoSize = true;
            this._button4.Enabled = false;
            this._button4.IgnoreAltF4 = false;
            this._button4.Location = new System.Drawing.Point(228, 0);
            this._button4.Margin = new System.Windows.Forms.Padding(0);
            this._button4.MinimumSize = new System.Drawing.Size(38, 21);
            this._button4.Name = "_button4";
            this._button4.Size = new System.Drawing.Size(38, 23);
            this._button4.TabIndex = 2;
            this._button4.Values.Text = "B4";
            this._button4.Visible = false;
            // 
            // _button3
            // 
            this._button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._button3.AutoSize = true;
            this._button3.Enabled = false;
            this._button3.IgnoreAltF4 = false;
            this._button3.Location = new System.Drawing.Point(191, 0);
            this._button3.Margin = new System.Windows.Forms.Padding(0);
            this._button3.MinimumSize = new System.Drawing.Size(38, 21);
            this._button3.Name = "_button3";
            this._button3.Size = new System.Drawing.Size(38, 23);
            this._button3.TabIndex = 2;
            this._button3.Values.Text = "B3";
            this._button3.Visible = false;
            // 
            // _button1
            // 
            this._button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._button1.AutoSize = true;
            this._button1.Enabled = false;
            this._button1.IgnoreAltF4 = false;
            this._button1.Location = new System.Drawing.Point(115, 0);
            this._button1.Margin = new System.Windows.Forms.Padding(0);
            this._button1.MinimumSize = new System.Drawing.Size(38, 21);
            this._button1.Name = "_button1";
            this._button1.Size = new System.Drawing.Size(38, 23);
            this._button1.TabIndex = 0;
            this._button1.Values.Text = "B1";
            this._button1.Visible = false;
            // 
            // _button2
            // 
            this._button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._button2.AutoSize = true;
            this._button2.Enabled = false;
            this._button2.IgnoreAltF4 = false;
            this._button2.Location = new System.Drawing.Point(153, 0);
            this._button2.Margin = new System.Windows.Forms.Padding(0);
            this._button2.MinimumSize = new System.Drawing.Size(38, 21);
            this._button2.Name = "_button2";
            this._button2.Size = new System.Drawing.Size(38, 23);
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
            this._messageIcon.Size = new System.Drawing.Size(33, 35);
            this._messageIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this._messageIcon.TabIndex = 0;
            this._messageIcon.TabStop = false;
            // 
            // _panelCheckBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this._panelCheckBox, 2);
            this._panelCheckBox.Controls.Add(this._optionalCheckBox);
            this._panelCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._panelCheckBox.Location = new System.Drawing.Point(0, 64);
            this._panelCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this._panelCheckBox.Name = "_panelCheckBox";
            this._panelCheckBox.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this._panelCheckBox.Size = new System.Drawing.Size(228, 20);
            this._panelCheckBox.TabIndex = 1;
            // 
            // _optionalCheckBox
            // 
            this._optionalCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this._optionalCheckBox.Location = new System.Drawing.Point(0, 0);
            this._optionalCheckBox.Name = "_optionalCheckBox";
            this._optionalCheckBox.Size = new System.Drawing.Size(228, 20);
            this._optionalCheckBox.TabIndex = 0;
            this._optionalCheckBox.Values.Text = "CB1";
            // 
            // KryptonMessageBoxExtendedFormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 84);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonMessageBoxExtendedFormTest";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._panelButtons)).EndInit();
            this._panelButtons.ResumeLayout(false);
            this._panelButtons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._messageIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._panelCheckBox)).EndInit();
            this._panelCheckBox.ResumeLayout(false);
            this._panelCheckBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonPanel kryptonPanel1;
        private TableLayoutPanel tableLayoutPanel1;
        private KryptonWrapLabel _messageText;
        private KryptonPanel _panelButtons;
        private KryptonBorderEdge _borderEdge;
        private MessageButton _button4;
        private MessageButton _button3;
        private MessageButton _button1;
        private MessageButton _button2;
        private KryptonPanel _panelCheckBox;
        private KryptonCheckBox _optionalCheckBox;
        private PictureBox _messageIcon;
    }
}