using Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CircularProgressBar
{
    public partial class Form1 : KryptonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void kcbColourTrio_CheckedChanged(object sender, EventArgs e)
        {
            ccbTest.UseColourTrio = kcbColourTrio.Checked;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tmrIncrement.Enabled = false;

            ccbTest.Text = "0%";
        }

        private void tmrIncrement_Tick(object sender, EventArgs e)
        {
            ccbTest.Increment(1);

            ccbTest.Text = $"{ ccbTest.Value }%";

            if (ccbTest.Value >= 100)
            {
                tmrIncrement.Stop();
            }
        }

        private void kbtnStart_Click(object sender, EventArgs e)
        {
            tmrIncrement.Start();
        }

        private void kbtnStop_Click(object sender, EventArgs e)
        {
            tmrIncrement.Stop();
        }

        private void kbtnReset_Click(object sender, EventArgs e)
        {
            ccbTest.Value = 0;

            ccbTest.Text = "0%";
        }
    }
}
