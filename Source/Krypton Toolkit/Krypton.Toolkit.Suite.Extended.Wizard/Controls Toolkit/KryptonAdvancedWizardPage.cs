#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 * Base code by Steve Bate 2003 - 2017 (https://github.com/SteveBate/AdvancedWizard), modifications by Peter Wagner (aka Wagnerp) 2021 - 2025.
 *
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Wizard;

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
    public Color HeaderColourOne { get => HeaderPanel.StateCommon.Color1; set => HeaderPanel.StateCommon.Color1 = value; }

    public Color HeaderColourTwo { get => HeaderPanel.StateCommon.Color2; set => HeaderPanel.StateCommon.Color2 = value; }

    /// <summary>
    /// Allow an Image to be assigned to the wizard header
    /// </summary>
    [Category("WizardPage")]
    [DefaultValue("Resouces.Installer48.png")]
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
    internal KryptonLabel WizardSubText, WizardText;

    private void SetupHeader()
    {
        HeaderPanel = new KryptonPanel();

        HeaderPanel.Parent = this;

        HeaderPanel.Dock = DockStyle.Top;

        HeaderPanel.Height = 70;

        HeaderPanel.StateCommon.Color1 = _headerColourOne;

        HeaderPanel.StateCommon.Color2 = _headerColourTwo;

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
        //Stream stream = GetType().Assembly.GetManifestResourceStream("Resources.Installer48.png");
        try
        {
            //if (stream != null) _wizardImage.Image = Image.FromStream(stream);
            WizardImage.Image = Properties.Resources.Installer48;
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
    }

    private void SetupWizardText()
    {
        WizardText = new KryptonLabel();

        WizardText.StateCommon.ShortText.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);

        WizardText.Left = HeaderPanel.Left + 20;

        WizardText.Top = 20;

        WizardText.AutoSize = true;

        WizardText.Parent = HeaderPanel;

        WizardText.Text = "Welcome to the Krypton Wizard";

        WizardSubText = new KryptonLabel();

        WizardSubText.StateCommon.ShortText.Font = new Font("Microsoft Sans Serif", 8.25f);

        WizardSubText.Left = HeaderPanel.Left + 40;

        WizardSubText.Top = 40;

        WizardSubText.AutoSize = true;

        WizardSubText.Parent = HeaderPanel;

        WizardSubText.Text = "Your page description goes here";
    }

    private Color _headerColourOne, _headerColourTwo;
    private bool _headerVisible;
    private bool _imageVisible;
}