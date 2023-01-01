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

            foreach (string value in Enum.GetNames(typeof(ExtendedKryptonMessageBoxMessageContainerType)))
            {
                kcmbMessageContentType.Items.Add(value);
            }

            kcmbMessageContentType.SelectedIndex = 1;
        }

        private void ktxtMessageContent_TextChanged(object sender, EventArgs e)
        {
            knudLinkAreaStart.Maximum = ktxtMessageContent.Text.Length;

            knudLinkAreaEnd.Maximum = ktxtMessageContent.Text.Length;

            knudLinkAreaEnd.Value = ktxtMessageContent.Text.Length;
        }
    }
}
