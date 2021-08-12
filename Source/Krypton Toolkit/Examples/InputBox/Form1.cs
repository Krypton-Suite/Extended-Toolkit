using System;
using System.Drawing;
using System.Windows.Forms;

using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.InputBox;

namespace InputBox
{
    public partial class Form1 : KryptonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void kbtnTest_Click(object sender, EventArgs e)
        {
            KryptonInputBoxExtendedManager manager = new KryptonInputBoxExtendedManager(new Point(), "Hello", "Hello",
                InputBoxIconType.OK, null,
                InputBoxLanguage.ENGLISH, InputBoxButtons.YESNO, InputBoxInputType.TEXTBOX,
                null, false, new Font("Microsoft Sans Serif", 8.25f),
                new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold),
                "Ok", "Yes", "No", "Cancel", "A hint", FormStartPosition.CenterScreen,
                InputBoxTextAlignment.CENTRE);

            manager.DisplayInputBox();
        }
    }
}
