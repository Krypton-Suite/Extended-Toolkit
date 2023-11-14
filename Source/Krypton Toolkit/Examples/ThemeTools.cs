using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Krypton.Toolkit.Suite.Extended.Theme.Switcher;

namespace Examples
{
    public partial class ThemeTools : KryptonForm
    {
        public ThemeTools()
        {
            InitializeComponent();
        }

        private void kbtnExternalThemeSelector_Click(object sender, EventArgs e)
        {
            ExternalThemeSelectorChooser chooser = new();

            chooser.Show();
        }

        private void kbtnThemeSelector_Click(object sender, EventArgs e)
        {
            ThemeSelector themeSelector = new(new KryptonManager());

            themeSelector.Show();
        }

        private void ThemeTools_Load(object sender, EventArgs e)
        {

        }
    }
}
