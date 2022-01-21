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
            KryptonInputBoxExtendedManager manager = new KryptonInputBoxExtendedManager()
            {
                IconLocation = new Point(),
                Message = "Hello world!",
                Title = "Test",
                IconType = InputBoxIconType.OK,
                Image = null,
                InputBoxLanguage = InputBoxLanguage.ENGLISH,
                InputBoxButtons = InputBoxButtons.YESNO,
                IconInputType = InputBoxInputType.TEXTBOX,
                ListItems = null,
                ShowInTaskBar = false,
                ControlTypeface = new Font("Microsoft Sans Serif", 8.25f),
                MessageTypeface = new Font("Microsoft Sans Serif", 11.25f, FontStyle.Bold),
                OkText = "&Ok",
                YesText = "Y&es",
                NoText = "&No",
                CancelText = "C&ancel",
                HintText = "Hint",
                StartPosition = FormStartPosition.CenterScreen,
                ButtonFocus = InputBoxButtonFocus.BUTTONONE,
                MessageDisplayType = InputBoxMessageDisplayType.LABEL,
                NormalMessageTextAlignment = InputBoxNormalMessageTextAlignment.CENTRENEAR,
                WrappedMessageTextAlignment = InputBoxWrappedMessageTextAlignment.MIDDLELEFT,
                TextAlignment = InputBoxTextAlignment.LEFT,
                ButtonOneResult = DialogResult.No,
                ButtonTwoResult = DialogResult.Yes,
                ButtonThreeResult = DialogResult.None,
                ButtonFourResult = DialogResult.None
            };

            manager.DisplayInputBox();
        }
    }
}
