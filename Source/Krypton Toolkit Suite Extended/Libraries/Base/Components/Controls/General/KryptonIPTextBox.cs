using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Base
{
    public class KryptonIPTextBox : UserControl
    {
        #region Designer Code
        private KryptonTextBox ktxtChamberFour;
        private KryptonLabel kryptonLabel3;
        private KryptonTextBox ktxtChamberThree;
        private KryptonLabel kryptonLabel2;
        private KryptonTextBox ktxtChamberTwo;
        private KryptonLabel kryptonLabel1;
        private KryptonTextBox ktxtChamberOne;
        private KryptonPanel kryptonPanel1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.ktxtChamberOne = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.ktxtChamberTwo = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.ktxtChamberThree = new Krypton.Toolkit.KryptonTextBox();
            this.ktxtChamberFour = new Krypton.Toolkit.KryptonTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.ktxtChamberFour);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel3);
            this.kryptonPanel1.Controls.Add(this.ktxtChamberThree);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel2);
            this.kryptonPanel1.Controls.Add(this.ktxtChamberTwo);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Controls.Add(this.ktxtChamberOne);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(219, 23);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // ktxtChamberOne
            // 
            this.ktxtChamberOne.Dock = System.Windows.Forms.DockStyle.Left;
            this.ktxtChamberOne.Hint = "0";
            this.ktxtChamberOne.Location = new System.Drawing.Point(0, 0);
            this.ktxtChamberOne.MaxLength = 3;
            this.ktxtChamberOne.Name = "ktxtChamberOne";
            this.ktxtChamberOne.Size = new System.Drawing.Size(45, 23);
            this.ktxtChamberOne.TabIndex = 0;
            this.ktxtChamberOne.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.kryptonLabel1.Location = new System.Drawing.Point(45, 0);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(13, 23);
            this.kryptonLabel1.TabIndex = 1;
            this.kryptonLabel1.Values.Text = ".";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.kryptonLabel2.Location = new System.Drawing.Point(103, 0);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(13, 23);
            this.kryptonLabel2.TabIndex = 3;
            this.kryptonLabel2.Values.Text = ".";
            // 
            // ktxtChamberTwo
            // 
            this.ktxtChamberTwo.Dock = System.Windows.Forms.DockStyle.Left;
            this.ktxtChamberTwo.Hint = "0";
            this.ktxtChamberTwo.Location = new System.Drawing.Point(58, 0);
            this.ktxtChamberTwo.MaxLength = 3;
            this.ktxtChamberTwo.Name = "ktxtChamberTwo";
            this.ktxtChamberTwo.Size = new System.Drawing.Size(45, 23);
            this.ktxtChamberTwo.TabIndex = 1;
            this.ktxtChamberTwo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.kryptonLabel3.Location = new System.Drawing.Point(161, 0);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(13, 23);
            this.kryptonLabel3.TabIndex = 5;
            this.kryptonLabel3.Values.Text = ".";
            // 
            // ktxtChamberThree
            // 
            this.ktxtChamberThree.Dock = System.Windows.Forms.DockStyle.Left;
            this.ktxtChamberThree.Hint = "0";
            this.ktxtChamberThree.Location = new System.Drawing.Point(116, 0);
            this.ktxtChamberThree.MaxLength = 3;
            this.ktxtChamberThree.Name = "ktxtChamberThree";
            this.ktxtChamberThree.Size = new System.Drawing.Size(45, 23);
            this.ktxtChamberThree.TabIndex = 2;
            this.ktxtChamberThree.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ktxtChamberFour
            // 
            this.ktxtChamberFour.Dock = System.Windows.Forms.DockStyle.Left;
            this.ktxtChamberFour.Hint = "0";
            this.ktxtChamberFour.Location = new System.Drawing.Point(174, 0);
            this.ktxtChamberFour.MaxLength = 3;
            this.ktxtChamberFour.Name = "ktxtChamberFour";
            this.ktxtChamberFour.Size = new System.Drawing.Size(45, 23);
            this.ktxtChamberFour.TabIndex = 3;
            this.ktxtChamberFour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // KryptonIPTextBox
            // 
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.kryptonPanel1);
            this.Name = "KryptonIPTextBox";
            this.Size = new System.Drawing.Size(219, 23);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region Overrides
        public override string Text
        {
            get => $"{ ktxtChamberOne.Text }.{ ktxtChamberTwo.Text }.{ ktxtChamberThree.Text }.{ ktxtChamberFour.Text }";

            set
            {
                if (value != "" && value != null)
                {
                    string[] pieces = new string[4];

                    pieces = value.ToString().Split(".".ToCharArray(), 4);

                    ktxtChamberOne.Text = pieces[0];

                    ktxtChamberTwo.Text = pieces[1];

                    ktxtChamberThree.Text = pieces[2];

                    ktxtChamberFour.Text = pieces[3];
                }
                else
                {
                    ktxtChamberOne.Text = "";

                    ktxtChamberTwo.Text = "";

                    ktxtChamberThree.Text = "";

                    ktxtChamberFour.Text = "";
                }
            }
        }
        #endregion
    }
}