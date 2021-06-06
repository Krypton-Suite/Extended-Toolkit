using System.IO;

namespace Krypton.Toolkit.Suite.Extended.Wizard
{
    /// <summary>
    /// Gives us a header as seen in most wizards
    /// </summary>
    [Designer(typeof(KryptonAdvancedWizardPageDesigner))]
    [ToolboxItem(false)]
    public class KryptonAdvancedWizardPage : KryptonPanel
    {
        public KryptonAdvancedWizardPage()
        {
            SetupHeader();
            SetupHeaderImage();
            SetupWizardText();
        }

        /// <summary>
        /// Allow an Image to be assigned to the wizard header
        /// </summary>
        [Category("WizardPage")]
        [DefaultValue(null)]
        [Description("A 48x48 image for the wizard header")]
        public Image HeaderImage
        {
            get => WizardImage.Image;
            set => WizardImage.Image = value;
        }

        // Specify whether or not image is shown
        [Category("WizardPage")]
        [Description("Shows/Hides the image in the header")]
        public bool HeaderImageVisible
        {
            get => _imageVisible;
            set
            {
                _imageVisible = value;
                WizardImage.Visible = _imageVisible;
            }
        }

        // Specify background colour of header
        [Category("WizardPage")]
        [Description("The background color for the header")]
        public Color HeaderBackgroundColor
        {
            get => HeaderPanel.BackColor;
            set => HeaderPanel.BackColor = value;
        }

        // Specify the main text for the page
        [Category("WizardPage")]
        [Description("Allows a title for the current page")]
        [Localizable(true)]
        public string HeaderTitle
        {
            get => WizardText.Text;
            set => WizardText.Text = value;
        }

        // Specify the font used for text on the Header
        [Category("WizardPage")]
        [Description("The font for the header title")]
        public Font HeaderFont
        {
            get => WizardText.Font;
            set => WizardText.Font = value;
        }

        // Specify the subtext for the page
        [Category("WizardPage")]
        [Description("Allows a subheading for the current page.")]
        [Localizable(true)]
        public string SubTitle
        {
            get => WizardSubText.Text;
            set => WizardSubText.Text = value;
        }

        // Specify the font used for text on the subtitle
        [Category("WizardPage")]
        [Description("The font for the subtitle")]
        public Font SubTitleFont
        {
            get => WizardSubText.Font;
            set => WizardSubText.Font = value;
        }

        // Specify whether or not the header is shown
        [Category("WizardPage")]
        [Description(
            "The header gives you a head start in designing your pages. Turn it off for complete freedom of design.")]
        public bool Header
        {
            get => _headerVisible;
            set
            {
                _headerVisible = value;
                HeaderPanel.Visible = _headerVisible;
            }
        }

        [Category("Wizard")]
        [Description("Fires when the page is shown")]
        public event EventHandler<WizardPageEventArgs> PageShow = delegate { };

        // get the index of the page before the current page
        [Browsable(false)]
        public int PreviousPage { get; set; }

        internal void FirePageShowEvent() => PageShow(this, new WizardPageEventArgs(this));

        internal KryptonPanel HeaderPanel;
        internal PictureBox WizardImage;
        internal KryptonLabel WizardSubText;
        internal KryptonLabel WizardText;

        private void SetupHeader()
        {
            HeaderPanel = new KryptonPanel { Parent = this, Dock = DockStyle.Top, Height = 70, BackColor = Color.White };
            _headerVisible = true;
            _imageVisible = true;
        }

        private void SetupHeaderImage()
        {
            WizardImage = new PictureBox { Parent = HeaderPanel, Size = new Size(48, 48) };
            WizardImage.Left = Width - WizardImage.Width - 10;
            WizardImage.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            WizardImage.Top = HeaderPanel.Height - WizardImage.Height - 10;
            WizardImage.BackColor = Color.Transparent;

            // load the wizImage bitmap that we have embedded in the control
            Stream stream = GetType().Assembly.GetManifestResourceStream("AdvancedWizardControl.Resources.wiz.gif");
            try
            {
                if (stream != null) WizardImage.Image = Image.FromStream(stream);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void SetupWizardText()
        {
            WizardText = new KryptonLabel
            {
                Font = new Font("tahoma", 10, FontStyle.Bold),
                Left = HeaderPanel.Left + 20,
                Top = 20,
                AutoSize = true,
                Parent = HeaderPanel,
                Text = "Welcome to Advanced Wizard"
            };

            WizardSubText = new KryptonLabel
            {
                Font = new Font("tahoma", 8),
                Left = HeaderPanel.Left + 40,
                Top = 38,
                AutoSize = true,
                Parent = HeaderPanel,
                Text = "Your page description goes here"
            };
        }

        private bool _headerVisible;
        private bool _imageVisible;
    }
}