using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Theme.Switcher;

namespace ThemeSwitcher
{
    public partial class Form1 : KryptonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void kbtnChangeTheme_Click(object sender, System.EventArgs e)
        {
            ThemeSelector selector = new ThemeSelector(new KryptonManager());

            selector.Show();
        }
    }
}
