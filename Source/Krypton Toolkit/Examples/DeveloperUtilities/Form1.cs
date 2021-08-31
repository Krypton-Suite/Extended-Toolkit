using System;

using Krypton.Toolkit;

using Krypton.Toolkit.Suite.Extended.Developer.Utilities;

namespace DeveloperUtilities
{
    public partial class Form1 : KryptonForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void kbtnNotImplementedYet_Click(object sender, EventArgs e)
        {
            ApplicationUtilities.UnderConstruction();
        }
    }
}
