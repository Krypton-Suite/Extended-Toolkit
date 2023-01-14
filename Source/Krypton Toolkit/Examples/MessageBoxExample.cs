using Krypton.Toolkit.Suite.Extended.Core;
using Krypton.Toolkit.Suite.Extended.Developer.Utilities;
using Krypton.Toolkit.Suite.Extended.Messagebox;

using ExtendedKryptonMessageBoxIcon = Krypton.Toolkit.Suite.Extended.Messagebox.ExtendedKryptonMessageBoxIcon;
using ExtendedMessageBoxButtons = Krypton.Toolkit.Suite.Extended.Messagebox.ExtendedMessageBoxButtons;

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

            EnableHyperlinkControls(false);

            SetupLinkAreaLengthValues();

            bsaReset.Enabled = ButtonEnabled.False;
        }

        private void ktxtMessageContent_TextChanged(object sender, EventArgs e) => SetupLinkAreaLengthValues();

        private void SetupLinkAreaLengthValues()
        {
            knudLinkAreaStart.Maximum = ktxtMessageContent.Text.Length;

            knudLinkAreaEnd.Maximum = ktxtMessageContent.Text.Length;

            knudLinkAreaEnd.Value = ktxtMessageContent.Text.Length;
        }

        private void kcmbMessageContentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (kcmbMessageContentType.SelectedIndex == 2)
            {
                EnableHyperlinkControls(true);
            }
            else
            {
                EnableHyperlinkControls(false);
            }
        }

        private void EnableHyperlinkControls(bool b)
        {
            ktxtHyperlinkDestination.Enabled = b;

            kryptonLabel3.Enabled = b;

            knudLinkAreaStart.Enabled = b;

            kryptonLabel4.Enabled = b;

            knudLinkAreaEnd.Enabled = b;
        }

        private void ktxtHyperlinkDestination_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ktxtHyperlinkDestination.Text))
            {
                bsaReset.Enabled = ButtonEnabled.False;
            }
            else
            {
                bsaReset.Enabled = ButtonEnabled.True;
            }
        }

        private void bsaReset_Click(object sender, EventArgs e)
        {
            ktxtHyperlinkDestination.Text = null;
        }

        private void bsaBrowseForResource_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new()
            {
                Title = @"Browse for a resource:"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                ktxtHyperlinkDestination.Text = Path.GetFullPath(ofd.FileName);
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            string dummyText = LoremIpsumGenerator.Paragraph(5, 6, 4, 10);

            ktxtMessageContent.Text = dummyText;
        }
    }
}
