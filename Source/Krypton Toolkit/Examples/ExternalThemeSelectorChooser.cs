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
    public partial class ExternalThemeSelectorChooser : KryptonForm
    {
        public ExternalThemeSelectorChooser()
        {
            InitializeComponent();
        }

        private void kbtnBinaryThemes_Click(object sender, EventArgs e)
        {
            KryptonExternalThemeSelectorForm themeSelector =
                new KryptonExternalThemeSelectorForm(ExternalThemeType.Binary, null);

            themeSelector.ShowDialog();
        }

        private void kbtnXMLThemes_Click(object sender, EventArgs e)
        {
            KryptonExternalThemeSelectorForm themeSelector =
                new KryptonExternalThemeSelectorForm(ExternalThemeType.ExtensibleMarkupLanguage, null);

            themeSelector.ShowDialog();
        }
    }
}
