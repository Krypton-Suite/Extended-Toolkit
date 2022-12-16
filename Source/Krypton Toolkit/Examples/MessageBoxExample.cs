using Krypton.Toolkit.Suite.Extended.Messagebox;

namespace Examples
{
    public partial class MessageBoxExample : KryptonForm
    {
        public MessageBoxExample()
        {
            InitializeComponent();
        }

        private void MessageBoxExample_Load(object sender, EventArgs e)
        {
            foreach (string value in Enum.GetNames(typeof(ExtendedKryptonMessageBoxIcon)))
            {
                kcmbMessageBoxIcon.Items.Add(value);
            }

            kcmbMessageBoxIcon.SelectedIndex = 1;

            foreach (string name in Enum.GetNames(typeof(ExtendedMessageBoxButtons)))
            {
                kcmbMessageBoxButtons.Items.Add(name);
            }

            kcmbMessageBoxButtons.SelectedIndex = 1;
        }
    }
}
