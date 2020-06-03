using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Base
{
    public class KryptonIPTextBox : UserControl
    {
        #region Designer Code
        private KryptonLabel kryptonLabel1;
        private KryptonTextBox ktxtChamberOne;
        private KryptonLabel kryptonLabel2;
        private KryptonTextBox ktxtChamberTwo;
        private KryptonLabel kryptonLabel3;
        private KryptonTextBox ktxtChamberThree;
        private KryptonTextBox ktxtChamberFour;
        private IContainer components = null;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.ktxtChamberOne = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.ktxtChamberTwo = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.ktxtChamberThree = new Krypton.Toolkit.KryptonTextBox();
            this.ktxtChamberFour = new Krypton.Toolkit.KryptonTextBox();
            this._tt = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.kryptonLabel1.Location = new System.Drawing.Point(41, 0);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(13, 20);
            this.kryptonLabel1.TabIndex = 3;
            this.kryptonLabel1.Values.Text = ".";
            // 
            // ktxtChamberOne
            // 
            this.ktxtChamberOne.Dock = System.Windows.Forms.DockStyle.Left;
            this.ktxtChamberOne.Hint = "0";
            this.ktxtChamberOne.Location = new System.Drawing.Point(0, 0);
            this.ktxtChamberOne.MaxLength = 3;
            this.ktxtChamberOne.Name = "ktxtChamberOne";
            this.ktxtChamberOne.Size = new System.Drawing.Size(41, 20);
            this.ktxtChamberOne.TabIndex = 2;
            this.ktxtChamberOne.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ktxtChamberOne.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ktxtChamberOne_KeyPress);
            this.ktxtChamberOne.Enter += new System.EventHandler(this.EnterBox);
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.kryptonLabel2.Location = new System.Drawing.Point(95, 0);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(13, 20);
            this.kryptonLabel2.TabIndex = 5;
            this.kryptonLabel2.Values.Text = ".";
            // 
            // ktxtChamberTwo
            // 
            this.ktxtChamberTwo.Dock = System.Windows.Forms.DockStyle.Left;
            this.ktxtChamberTwo.Hint = "0";
            this.ktxtChamberTwo.Location = new System.Drawing.Point(54, 0);
            this.ktxtChamberTwo.MaxLength = 3;
            this.ktxtChamberTwo.Name = "ktxtChamberTwo";
            this.ktxtChamberTwo.Size = new System.Drawing.Size(41, 20);
            this.ktxtChamberTwo.TabIndex = 4;
            this.ktxtChamberTwo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ktxtChamberTwo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ktxtChamberTwo_KeyPress);
            this.ktxtChamberTwo.Enter += new System.EventHandler(this.EnterBox);
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.kryptonLabel3.Location = new System.Drawing.Point(149, 0);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(13, 20);
            this.kryptonLabel3.TabIndex = 7;
            this.kryptonLabel3.Values.Text = ".";
            // 
            // ktxtChamberThree
            // 
            this.ktxtChamberThree.Dock = System.Windows.Forms.DockStyle.Left;
            this.ktxtChamberThree.Hint = "0";
            this.ktxtChamberThree.Location = new System.Drawing.Point(108, 0);
            this.ktxtChamberThree.MaxLength = 3;
            this.ktxtChamberThree.Name = "ktxtChamberThree";
            this.ktxtChamberThree.Size = new System.Drawing.Size(41, 20);
            this.ktxtChamberThree.TabIndex = 6;
            this.ktxtChamberThree.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ktxtChamberThree.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ktxtChamberThree_KeyPress);
            this.ktxtChamberThree.Enter += new System.EventHandler(this.EnterBox);
            // 
            // ktxtChamberFour
            // 
            this.ktxtChamberFour.Dock = System.Windows.Forms.DockStyle.Left;
            this.ktxtChamberFour.Hint = "0";
            this.ktxtChamberFour.Location = new System.Drawing.Point(162, 0);
            this.ktxtChamberFour.MaxLength = 3;
            this.ktxtChamberFour.Name = "ktxtChamberFour";
            this.ktxtChamberFour.Size = new System.Drawing.Size(41, 20);
            this.ktxtChamberFour.TabIndex = 8;
            this.ktxtChamberFour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ktxtChamberFour.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ktxtChamberFour_KeyPress);
            this.ktxtChamberFour.Enter += new System.EventHandler(this.EnterBox);
            // 
            // KryptonIPTextBox
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.ktxtChamberFour);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.ktxtChamberThree);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.ktxtChamberTwo);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.ktxtChamberOne);
            this.Name = "KryptonIPTextBox";
            this.Size = new System.Drawing.Size(203, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region Variables
        private ToolTip _tt = new ToolTip();
        #endregion

        #region Event
        public delegate void IPAddressChangedEventHandler(object sender, InternetProtocolEventArgs e);

        public event IPAddressChangedEventHandler IPAddressChanged;
        #endregion

        #region Properties
        public string ToolTipText
        {
            get => _tt.GetToolTip(ktxtChamberOne);

            set
            {
                _tt.SetToolTip(ktxtChamberOne, value);

                _tt.SetToolTip(ktxtChamberTwo, value);

                _tt.SetToolTip(ktxtChamberThree, value);

                _tt.SetToolTip(ktxtChamberFour, value);

                _tt.SetToolTip(kryptonLabel1, value);

                _tt.SetToolTip(kryptonLabel2, value);

                _tt.SetToolTip(kryptonLabel3, value);
            }
        }

        public override string Text 
        {
            get => $"{ ktxtChamberOne.Text }.{ ktxtChamberTwo.Text }.{ ktxtChamberThree.Text }.{ ktxtChamberFour.Text }"; 
            
            set
            {
                if (value != "" && value != null)
                {
                    string[] ipAddressString = new string[4];

                    ipAddressString = value.ToString().Split(".".ToCharArray(), 4);

                    ktxtChamberOne.Text = ipAddressString[0];

                    ktxtChamberTwo.Text = ipAddressString[1];

                    ktxtChamberThree.Text = ipAddressString[2];

                    ktxtChamberFour.Text = ipAddressString[3];
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

        #region Constructor
        public KryptonIPTextBox()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
        public bool IsValid()
        {
            try
            {
                int checkval = int.Parse(ktxtChamberOne.Text);

                if (checkval < 0 || checkval > 255)
                {
                    return false;
                }

                checkval = int.Parse(ktxtChamberTwo.Text);

                if (checkval < 0 || checkval > 255)
                {
                    return false;
                }

                checkval = int.Parse(ktxtChamberThree.Text);

                if (checkval < 0 || checkval > 255)
                {
                    return false;
                }

                checkval = int.Parse(ktxtChamberFour.Text);

                if (checkval < 0 || checkval > 255)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private bool IsValid(string inString)
        {
            try
            {
                int theValue = int.Parse(inString);
                
                if (theValue >= 0 && theValue <= 255)
                {
                    return true;
                }
                else
                {
                    KryptonMessageBoxExtended.Show("Must Be Between 0 and 255", "Out Of Range");

                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        private void EnterBox(object sender, EventArgs e)
        {
            KryptonTextBox tbs = (KryptonTextBox)sender;

            tbs.SelectAll();
        }
        #endregion

        #region Overrides
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        #endregion

        private void ktxtChamberOne_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Only Accept a '.', a numeral, or backspace
            if (e.KeyChar.ToString() == "." || Char.IsDigit(e.KeyChar) || e.KeyChar == 8)
            {
                //If the key pressed is a '.'
                if (e.KeyChar.ToString() == ".")
                {
                    //If the Text is a valid ip octet move to the next box
                    if (ktxtChamberOne.Text != "" && ktxtChamberOne.Text.Length != ktxtChamberOne.SelectionLength)
                    {
                        if (IsValid(ktxtChamberOne.Text))
                            ktxtChamberTwo.Focus();
                        else
                            ktxtChamberOne.SelectAll();
                    }
                    e.Handled = true;
                }

                //If we are not overwriting the whole text
                else if (ktxtChamberOne.SelectionLength != ktxtChamberOne.Text.Length)
                {
                    //Check that the new Text value will be a valid
                    // ip octet then move on to next box
                    if (ktxtChamberOne.Text.Length == 2)
                    {
                        if (e.KeyChar == 8)
                            ktxtChamberOne.Text.Remove(ktxtChamberOne.Text.Length - 1, 1);
                        else if (!IsValid(ktxtChamberOne.Text + e.KeyChar.ToString()))
                        {
                            ktxtChamberOne.SelectAll();
                            e.Handled = true;
                        }
                        else
                        {
                            ktxtChamberTwo.Focus();
                        }
                    }
                }
            }
            //Do nothing if the keypress is not numeral, backspace, or '.'
            else
                e.Handled = true;
        }

        private void ktxtChamberTwo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "." || Char.IsDigit(e.KeyChar) || e.KeyChar == 8)
            {
                if (e.KeyChar.ToString() == ".")
                {
                    if (ktxtChamberTwo.Text != "" && ktxtChamberTwo.Text.Length != ktxtChamberTwo.SelectionLength)
                    {
                        if (IsValid(ktxtChamberOne.Text))
                            ktxtChamberThree.Focus();
                        else
                            ktxtChamberTwo.SelectAll();
                    }
                    e.Handled = true;
                }
                else if (ktxtChamberTwo.SelectionLength != ktxtChamberTwo.Text.Length)
                {
                    if (ktxtChamberTwo.Text.Length == 2)
                    {
                        if (e.KeyChar == 8)
                        {
                            ktxtChamberTwo.Text.Remove(ktxtChamberTwo.Text.Length - 1, 1);
                        }
                        else if (!IsValid(ktxtChamberTwo.Text + e.KeyChar.ToString()))
                        {
                            ktxtChamberTwo.SelectAll();
                            e.Handled = true;
                        }
                        else
                        {
                            ktxtChamberThree.Focus();
                        }
                    }
                }
                else if (ktxtChamberTwo.Text.Length == 0 && e.KeyChar == 8)
                {
                    ktxtChamberOne.Focus();
                    ktxtChamberOne.SelectionStart = ktxtChamberOne.Text.Length;
                }
            }
            else
                e.Handled = true;
        }

        private void ktxtChamberThree_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "." || Char.IsDigit(e.KeyChar) || e.KeyChar == 8)
            {
                if (e.KeyChar.ToString() == ".")
                {
                    if (ktxtChamberThree.Text != "" && ktxtChamberThree.SelectionLength != ktxtChamberThree.Text.Length)
                    {
                        if (IsValid(ktxtChamberOne.Text))
                            ktxtChamberFour.Focus();
                        else
                            ktxtChamberThree.SelectAll();
                    }
                    e.Handled = true;
                }
                else if (ktxtChamberThree.SelectionLength != ktxtChamberThree.Text.Length)
                {
                    if (ktxtChamberThree.Text.Length == 2)
                    {
                        if (e.KeyChar == 8)
                        {
                            ktxtChamberThree.Text.Remove(ktxtChamberThree.Text.Length - 1, 1);
                        }
                        else if (!IsValid(ktxtChamberThree.Text + e.KeyChar.ToString()))
                        {
                            ktxtChamberThree.SelectAll();
                            e.Handled = true;
                        }
                        else
                        {
                            ktxtChamberFour.Focus();
                        }
                    }
                }
                else if (ktxtChamberThree.Text.Length == 0 && e.KeyChar == 8)
                {
                    ktxtChamberTwo.Focus();
                    ktxtChamberTwo.SelectionStart = ktxtChamberTwo.Text.Length;
                }
            }
            else
                e.Handled = true;
        }

        private void ktxtChamberFour_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || e.KeyChar == 8)
            {
                if (ktxtChamberFour.SelectionLength != ktxtChamberFour.Text.Length)
                {
                    if (ktxtChamberFour.Text.Length == 2)
                    {
                        if (e.KeyChar == 8)
                        {
                            ktxtChamberFour.Text.Remove(ktxtChamberFour.Text.Length - 1, 1);
                        }
                        else if (!IsValid(ktxtChamberFour.Text + e.KeyChar.ToString()))
                        {
                            ktxtChamberFour.SelectAll();
                            e.Handled = true;
                        }
                    }
                }
                else if (ktxtChamberFour.Text.Length == 0 && e.KeyChar == 8)
                {
                    ktxtChamberThree.Focus();
                    ktxtChamberThree.SelectionStart = ktxtChamberThree.Text.Length;
                }
            }
            else
                e.Handled = true;
        }
    }
}