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
namespace Examples
{
    partial class CheckBoxComboBoxTest
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
            Krypton.Toolkit.Suite.Extended.Controls.KryptonCheckBoxProperties kryptonCheckBoxProperties1 = new Krypton.Toolkit.Suite.Extended.Controls.KryptonCheckBoxProperties();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnCheckItem5 = new Krypton.Toolkit.KryptonButton();
            this.kbtnCheckDDDD = new Krypton.Toolkit.KryptonButton();
            this.kbtnCheckInserted = new Krypton.Toolkit.KryptonButton();
            this.kbtnClear = new Krypton.Toolkit.KryptonButton();
            this.kbtnCheckItem1 = new Krypton.Toolkit.KryptonButton();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kccmbManual = new Krypton.Toolkit.Suite.Extended.Controls.KryptonCheckBoxComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kccmbManual)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kccmbManual);
            this.kryptonPanel1.Controls.Add(this.kbtnCheckItem5);
            this.kryptonPanel1.Controls.Add(this.kbtnCheckDDDD);
            this.kryptonPanel1.Controls.Add(this.kbtnCheckInserted);
            this.kryptonPanel1.Controls.Add(this.kbtnClear);
            this.kryptonPanel1.Controls.Add(this.kbtnCheckItem1);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel4);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel3);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(475, 252);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnCheckItem5
            // 
            this.kbtnCheckItem5.Location = new System.Drawing.Point(171, 202);
            this.kbtnCheckItem5.Name = "kbtnCheckItem5";
            this.kbtnCheckItem5.Size = new System.Drawing.Size(124, 25);
            this.kbtnCheckItem5.TabIndex = 13;
            this.kbtnCheckItem5.Values.Text = "! Check \"Item 5\"";
            this.kbtnCheckItem5.Click += new System.EventHandler(this.kbtnCheckItem5_Click);
            // 
            // kbtnCheckDDDD
            // 
            this.kbtnCheckDDDD.Location = new System.Drawing.Point(171, 147);
            this.kbtnCheckDDDD.Name = "kbtnCheckDDDD";
            this.kbtnCheckDDDD.Size = new System.Drawing.Size(124, 25);
            this.kbtnCheckDDDD.TabIndex = 12;
            this.kbtnCheckDDDD.Values.Text = "! Check \"DDDD\"";
            this.kbtnCheckDDDD.Click += new System.EventHandler(this.kbtnCheckDDDD_Click);
            // 
            // kbtnCheckInserted
            // 
            this.kbtnCheckInserted.Location = new System.Drawing.Point(171, 93);
            this.kbtnCheckInserted.Name = "kbtnCheckInserted";
            this.kbtnCheckInserted.Size = new System.Drawing.Size(124, 25);
            this.kbtnCheckInserted.TabIndex = 11;
            this.kbtnCheckInserted.Values.Text = "! Check \"Inserted\"";
            this.kbtnCheckInserted.Click += new System.EventHandler(this.kbtnCheckInserted_Click);
            // 
            // kbtnClear
            // 
            this.kbtnClear.Location = new System.Drawing.Point(302, 39);
            this.kbtnClear.Name = "kbtnClear";
            this.kbtnClear.Size = new System.Drawing.Size(158, 25);
            this.kbtnClear.TabIndex = 10;
            this.kbtnClear.Values.Text = "Clear && Repopulate";
            this.kbtnClear.Click += new System.EventHandler(this.kbtnClear_Click);
            // 
            // kbtnCheckItem1
            // 
            this.kbtnCheckItem1.Location = new System.Drawing.Point(171, 39);
            this.kbtnCheckItem1.Name = "kbtnCheckItem1";
            this.kbtnCheckItem1.Size = new System.Drawing.Size(124, 25);
            this.kbtnCheckItem1.TabIndex = 9;
            this.kbtnCheckItem1.Values.Text = "! Check \"Item 1\"";
            this.kbtnCheckItem1.Click += new System.EventHandler(this.kbtnCheckItem1_Click);
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(13, 175);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(282, 20);
            this.kryptonLabel4.TabIndex = 8;
            this.kryptonLabel4.Values.Text = "A different look. Accessed via CheckBoxProperties";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(13, 121);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(233, 20);
            this.kryptonLabel3.TabIndex = 7;
            this.kryptonLabel3.Values.Text = "Populated using a DataTable DataSource";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(13, 67);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(243, 20);
            this.kryptonLabel2.TabIndex = 6;
            this.kryptonLabel2.Values.Text = "Populated using a custom IList DataSource";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(13, 13);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(248, 20);
            this.kryptonLabel1.TabIndex = 5;
            this.kryptonLabel1.Values.Text = "Populated Manually using ComboBox.Items";
            // 
            // kccmbManual
            // 
            kryptonCheckBoxProperties1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.kccmbManual.CheckBoxProperties = kryptonCheckBoxProperties1;
            this.kccmbManual.DisplayMemberSingleItem = "";
            this.kccmbManual.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kccmbManual.Location = new System.Drawing.Point(13, 40);
            this.kccmbManual.Name = "kccmbManual";
            this.kccmbManual.Size = new System.Drawing.Size(152, 21);
            this.kccmbManual.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kccmbManual.TabIndex = 1;
            // 
            // CheckBoxComboBoxTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 252);
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "CheckBoxComboBoxTest";
            this.Text = "CheckBoxComboBoxTest";
            this.Load += new System.EventHandler(this.CheckBoxComboBoxTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kccmbManual)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonPanel kryptonPanel1;
        private KryptonLabel kryptonLabel1;
        private KryptonLabel kryptonLabel2;
        private KryptonLabel kryptonLabel3;
        private KryptonLabel kryptonLabel4;
        private KryptonButton kbtnCheckItem1;
        private KryptonButton kbtnClear;
        private KryptonButton kbtnCheckInserted;
        private KryptonButton kbtnCheckDDDD;
        private KryptonButton kbtnCheckItem5;
        private Krypton.Toolkit.Suite.Extended.Controls.KryptonCheckBoxComboBox kccmbManual;
    }
}