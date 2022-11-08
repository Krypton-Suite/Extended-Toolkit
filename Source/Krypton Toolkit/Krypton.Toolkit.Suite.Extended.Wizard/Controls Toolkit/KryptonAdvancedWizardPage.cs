#region BSD License
/*
 *
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 *
 * Base code by Steve Bate 2003 - 2017 (https://github.com/SteveBate/AdvancedWizard), modifications by Peter Wagner (aka Wagnerp) 2021.
 *
 */
#endregion

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
            _headerColourOne = Color.White;

            _headerColourTwo = Color.White;

            SetupHeader();
            SetupHeaderImage();
            SetupWizardText();
        }

        [Category("WizardPage")]
        [DefaultValue(typeof(Color), "Color.White")]
        [Description("A 48x48 image for the wizard header")]
        public Color HeaderColourOne { get => _headerPanel.StateCommon.Color1; set => _headerPanel.StateCommon.Color1 = value; }

        public Color HeaderColourTwo { get => _headerPanel.StateCommon.Color2; set => _headerPanel.StateCommon.Color2 = value; }

        /// <summary>
        /// Allow an Image to be assigned to the wizard header
        /// </summary>
        [Category("WizardPage")]
        [DefaultValue("Resouces.Installer48.png")]
        [Description("A 48x48 image for the wizard header")]
        public Image HeaderImage
        {
            get => _wizardImage.Image;
            set => _wizardImage.Image = value;
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
                _wizardImage.Visible = _imageVisible;
            }
        }

        // Specify background colour of header
        [Category("WizardPage")]
        [Description("The background color for the header")]
        public Color HeaderBackgroundColor
        {
            get => _headerPanel.BackColor;
            set => _headerPanel.BackColor = value;
        }

        // Specify the main text for the page
        [Category("WizardPage")]
        [Description("Allows a title for the current page")]
        [Localizable(true)]
        public string HeaderTitle
        {
            get => _wizardText.Text;
            set => _wizardText.Text = value;
        }

        // Specify the font used for text on the Header
        [Category("WizardPage")]
        [Description("The font for the header title")]
        public Font HeaderFont
        {
            get => _wizardText.Font;
            set => _wizardText.Font = value;
        }

        // Specify the subtext for the page
        [Category("WizardPage")]
        [Description("Allows a subheading for the current page.")]
        [Localizable(true)]
        public string SubTitle
        {
            get => _wizardSubText.Text;
            set => _wizardSubText.Text = value;
        }

        // Specify the font used for text on the subtitle
        [Category("WizardPage")]
        [Description("The font for the subtitle")]
        public Font SubTitleFont
        {
            get => _wizardSubText.Font;
            set => _wizardSubText.Font = value;
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
                _headerPanel.Visible = _headerVisible;
            }
        }

        [Category("Wizard")]
        [Description("Fires when the page is shown")]
        public event EventHandler<WizardPageEventArgs> PageShow = delegate { };

        // get the index of the page before the current page
        [Browsable(false)]
        public int PreviousPage { get; set; }

        internal void FirePageShowEvent() => PageShow(this, new WizardPageEventArgs(this));

        internal KryptonPanel _headerPanel;
        internal PictureBox _wizardImage;
        internal KryptonLabel _wizardSubText, _wizardText;

        private void SetupHeader()
        {
            _headerPanel = new KryptonPanel();

            _headerPanel.Parent = this;

            _headerPanel.Dock = DockStyle.Top;

            _headerPanel.Height = 70;

            _headerPanel.StateCommon.Color1 = _headerColourOne;

            _headerPanel.StateCommon.Color2 = _headerColourTwo;

            _headerVisible = true;
            _imageVisible = true;
        }

        private void SetupHeaderImage()
        {
            _wizardImage = new PictureBox { Parent = _headerPanel, Size = new Size(48, 48) };
            _wizardImage.Left = Width - _wizardImage.Width - 10;
            _wizardImage.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            _wizardImage.Top = _headerPanel.Height - _wizardImage.Height - 10;
            _wizardImage.BackColor = Color.Transparent;

            // load the wizImage bitmap that we have embedded in the control
            //Stream stream = GetType().Assembly.GetManifestResourceStream("Resources.Installer48.png");
            try
            {
                //if (stream != null) _wizardImage.Image = Image.FromStream(stream);
                _wizardImage.Image = Properties.Resources.Installer48;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void SetupWizardText()
        {
            _wizardText = new KryptonLabel();

            _wizardText.StateCommon.ShortText.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);

            _wizardText.Left = _headerPanel.Left + 20;

            _wizardText.Top = 20;

            _wizardText.AutoSize = true;

            _wizardText.Parent = _headerPanel;

            _wizardText.Text = "Welcome to the Krypton Wizard";

            _wizardSubText = new KryptonLabel();

            _wizardSubText.StateCommon.ShortText.Font = new Font("Microsoft Sans Serif", 8.25f); ;

            _wizardSubText.Left = _headerPanel.Left + 40;

            _wizardSubText.Top = 40;

            _wizardSubText.AutoSize = true;

            _wizardSubText.Parent = _headerPanel;

            _wizardSubText.Text = "Your page description goes here";
        }

        private Color _headerColourOne, _headerColourTwo;
        private bool _headerVisible;
        private bool _imageVisible;
    }
}