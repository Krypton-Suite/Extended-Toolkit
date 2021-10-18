using System;
using System.Drawing;
using System.Windows.Forms;

using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Messagebox;

namespace MessageBox
{
    public partial class Form1 : KryptonForm
    {
        private ExtendedMessageBoxCustomButtonVisibility _buttonVisibility;
        private ExtendedKryptonMessageBoxIcon _icon;
        private ExtendedMessageBoxButtons _buttons;
        private MessageBoxOptions _options = 0;
        private Font _buttonTypeface, _textTypeface;

        private Color contentMessageColour, buttonOneBackColourOne, buttonOneBackColourTwo, buttonOneTextColourOne,
                      buttonOneTextColourTwo, buttonTwoTextColourOne, buttonTwoTextColourTwo, buttonTwoBackColourOne,
                      buttonTwoBackColourTwo, buttonThreeTextColourOne, buttonThreeTextColourTwo, buttonThreeBackColourOne,
                      buttonThreeBackColourTwo, yesButtonBackColourOne, yesButtonBackColourTwo, yesButtonTextColourOne,
                      yesButtonTextColourTwo, noButtonBackColourOne, noButtonBackColourTwo, noButtonTextColourOne,
                      noButtonTextColourTwo;

        public Form1()
        {
            InitializeComponent();
        }

        private void kbtnTest_Click(object sender, EventArgs e)
        {
            //kmbc.DisplayKryptonMessageBox();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ThemeManager.PropagateThemeSelector(kcmbSelectedTheme);
        }

        private void kcmbSelectedTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            ThemeManager.ApplyTheme(kcmbSelectedTheme.Text, kryptonManager1);
        }
    }
}
