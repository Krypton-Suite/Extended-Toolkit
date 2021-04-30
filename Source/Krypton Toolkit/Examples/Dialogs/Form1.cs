using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Krypton.Toolkit;

namespace Dialogs
{
    public partial class Form1 : KryptonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void kbtnAboutBox_Click(object sender, EventArgs e)
        {
            kabm.DisplayAboutBox();
        }

        private void kbtnShowInputBox_Click(object sender, EventArgs e)
        {
            kibm.DisplayInputBox();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            kabm.Assembly = Assembly.GetExecutingAssembly();
        }
    }
}
