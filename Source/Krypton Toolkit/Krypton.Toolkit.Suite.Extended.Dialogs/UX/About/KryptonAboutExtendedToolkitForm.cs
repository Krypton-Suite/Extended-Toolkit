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
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    internal partial class KryptonAboutExtendedToolkitForm : KryptonForm
    {
        #region Instance Fields

        private readonly KryptonAboutExtendedToolkitData _aboutExtendedToolkitData;

        #endregion

        public KryptonAboutExtendedToolkitForm(KryptonAboutExtendedToolkitData aboutExtendedToolkitData)
        {
            _aboutExtendedToolkitData = aboutExtendedToolkitData;

            Startup();

            InitializeComponent();
        }

        #region Implementation

        private void klwlblDemos_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e) => GlobalToolkitUtilities.LaunchProcess(@"https://github.com/Krypton-Suite/Extended-Toolkit-Demos/releases");

        private void klwlblDocumentation_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e) => GlobalToolkitUtilities.LaunchProcess(@"https://github.com/Krypton-Suite/Help-Files/releases");

        private void klwlblRepositories_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e) => GlobalToolkitUtilities.LaunchProcess(@"https://github.com/orgs/Krypton-Suite/repositories");

        private void klwlblDiscord_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e) => GlobalToolkitUtilities.LaunchProcess(@"https://discord.gg/CRjF6fY");

        private void klwlblGeneralInformation_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e) => GlobalToolkitUtilities.LaunchProcess(@"https://github.com/Krypton-Suite/Extended-Toolkit");

        private void tsbtnToolkitGeneralInformation_Click(object? sender, EventArgs e) => SwitchToolkitInformationPage(AboutToolkitPage.GeneralInformation);

        private void tsbtnDiscord_Click(object? sender, EventArgs e) => SwitchToolkitInformationPage(AboutToolkitPage.Discord);

        private void tsbtnDeveloperInformation_Click(object? sender, EventArgs e) => SwitchToolkitInformationPage(AboutToolkitPage.DeveloperInformation);

        private void tsbtnVersions_Click(object? sender, EventArgs e) => SwitchToolkitInformationPage(AboutToolkitPage.Versions);

        private void kbtnSystemInformation_Click(object? sender, EventArgs e) => LaunchSystemInformation();

        private void kbtnOk_Click(object? sender, EventArgs e) => Hide();

        private void Startup()
        {
            // Adjust UI elements
            ShowDeveloperControls(_aboutExtendedToolkitData.ShowDeveloperInformationButton);

            ShowDiscordControls(_aboutExtendedToolkitData.ShowDiscordButton);

            ShowVersionControls(_aboutExtendedToolkitData.ShowVersionInformationButton);

            ShowThemeControls(_aboutExtendedToolkitData.ShowThemeOptions);

            ShowBuildDateLabel(_aboutExtendedToolkitData.ShowBuildDate);

            UpdateBuiltOnText(string.Empty);

            // ToDo: Figure out why this does not work
            // UpdateBuiltOnText($@"{_aboutExtendedToolkitData.BuildOnText}: {KryptonAboutBoxUtilities.AssemblyBuildDate(Assembly.LoadFile($@"{Application.ExecutablePath}\Krypton.Toolkit.dll"), false)}");

            UpdateCurrentThemeText($@"{_aboutExtendedToolkitData.CurrentThemeText}:");

            ShowSystemInformationButton(_aboutExtendedToolkitData.ShowSystemInformationButton);

            SwitchIcon(_aboutExtendedToolkitData.ToolkitType);

            ConcatanateGeneralInformationText(_aboutExtendedToolkitData.GeneralInformationWelcomeText, _aboutExtendedToolkitData.GeneralInformationLicenseText, _aboutExtendedToolkitData.GeneralInformationLearnMoreText);

            UpdateDiscordText(_aboutExtendedToolkitData.DiscordText);

            UpdateRepositoriesText(_aboutExtendedToolkitData.RepositoryInformationText);

            UpdateDemosText(_aboutExtendedToolkitData.DownloadDemosText);

            UpdateDocumentationText(_aboutExtendedToolkitData.DownloadDocumentationText);

            UpdateColumnHeadings(_aboutExtendedToolkitData.FileNameColumnHeaderText, _aboutExtendedToolkitData.VersionColumnHeaderText);

            UpdateToolBarText(_aboutExtendedToolkitData.ToolBarGeneralInformationText, _aboutExtendedToolkitData.ToolBarDiscordText, _aboutExtendedToolkitData.ToolBarDeveloperInformationText, _aboutExtendedToolkitData.ToolBarVersionInformationText);

            UpdateGeneralInformationLinkArea(_aboutExtendedToolkitData.LearnMoreLinkArea);

            UpdateDocumentationLinkArea(_aboutExtendedToolkitData.DocumentationLinkArea);

            UpdateDiscordLinkArea(_aboutExtendedToolkitData.DiscordLinkArea);

            UpdateDemosLinkArea(_aboutExtendedToolkitData.DownloadDemosLinkArea);

            UpdateRepositoriesLinkArea(_aboutExtendedToolkitData.RepositoryInformationLinkArea);

            GetReferenceAssemblyInformation();

            klblCurrentTheme.Text = $@"{KryptonManager.Strings.CustomStrings.CurrentTheme}:";
        }

        private void UpdateCurrentThemeText(string value) => klblCurrentTheme.Text = value;

        private void LaunchSystemInformation() => GlobalToolkitUtilities.LaunchProcess(@"MSInfo32.exe");

        private void UpdateToolBarText(string toolBarGeneralInformationText, string toolBarDiscordText, string toolBarDeveloperInformationText, string toolBarVersionInformationText)
        {
            tsbtnToolkitGeneralInformation.Text = toolBarGeneralInformationText;

            tsbtnDiscord.Text = toolBarDiscordText;

            tsbtnDeveloperInformation.Text = toolBarDeveloperInformationText;

            tsbtnVersions.Text = toolBarVersionInformationText;
        }

        private void ShowBuildDateLabel(bool value)
        {
            klblBuiltOn.Visible = value;

            if (!value)
            {
                klblBuiltOn.Text = null;
            }
        }

        private void ShowDeveloperControls(bool value)
        {
            tssDeveloperInformation.Visible = value;

            tsbtnDeveloperInformation.Visible = value;
        }

        private void ShowDiscordControls(bool value)
        {
            tssDiscord.Visible = value;

            tsbtnDiscord.Visible = value;
        }

        private void ShowVersionControls(bool value)
        {
            tsbtnVersions.Visible = value;

            tssVersions.Visible = value;
        }

        private void ShowThemeControls(bool value)
        {
            klblCurrentTheme.Visible = value;

            ktcmbCurrentTheme.Visible = value;

            SetLogoSpan(value);
        }

        private void SwitchIcon(ToolkitType value)
        {
            switch (value)
            {
                case ToolkitType.Canary:
                    khgMain.ValuesPrimary.Image = Resources.Canary;

                    pbxLogo.Image = Resources.Krypton_Canary;
                    break;
                case ToolkitType.Nightly:
                    khgMain.ValuesPrimary.Image = Resources.Nightly;

                    pbxLogo.Image = Resources.Krypton_Nightly;
                    break;
                case ToolkitType.Stable:
                    khgMain.ValuesPrimary.Image = Resources.Stable;

                    pbxLogo.Image = Resources.Krypton_Stable;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
        }

        private void UpdateBuiltOnText(string value) => klblBuiltOn.Text = value;

        private void ConcatanateGeneralInformationText(string welcomeText, string licenseText, string learnMoreText)
        {
            // Note: Do not use verbatim string!
            string output = $"{welcomeText}\r\n\r\n{licenseText}: MIT\r\n\r\n{learnMoreText}";

            klwlblGeneralInformation.Text = output;
        }

        private void UpdateDiscordText(string value) => klwlblDiscord.Text = value;

        private void UpdateRepositoriesText(string value) => klwlblRepositories.Text = value;

        private void UpdateDocumentationText(string value) => klwlblDocumentation.Text = value;

        private void UpdateDemosText(string value) => klwlblDemos.Text = value;

        private void UpdateColumnHeadings(string fileName, string version)
        {
            kdgvVersions.Columns[0].HeaderText = fileName;

            kdgvVersions.Columns[1].HeaderText = version;
        }

        private void UpdateGeneralInformationLinkArea(LinkArea linkArea) => klwlblGeneralInformation.LinkArea = linkArea;

        private void UpdateDiscordLinkArea(LinkArea linkArea) => klwlblDiscord.LinkArea = linkArea;

        private void UpdateRepositoriesLinkArea(LinkArea linkArea) => klwlblRepositories.LinkArea = linkArea;

        private void UpdateDemosLinkArea(LinkArea linkArea) => klwlblDemos.LinkArea = linkArea;

        private void UpdateDocumentationLinkArea(LinkArea linkArea) => klwlblDocumentation.LinkArea = linkArea;

        private void SetLogoSpan(bool value)
        {
            if (value)
            {
                tlpGeneralInformation.SetRowSpan(pbxLogo, 3);
            }
            else
            {
                klblCurrentTheme.Text = null;

                ktcmbCurrentTheme.Visible = false;

                tlpGeneralInformation.SetRowSpan(pbxLogo, 1);
            }
        }

        private void SwitchToolkitInformationPage(AboutToolkitPage page)
        {
            switch (page)
            {
                case AboutToolkitPage.GeneralInformation:
                    kpnlToolkitGeneralInformation.Visible = true;

                    kpnlDiscord.Visible = false;

                    kpnlDeveloperInformation.Visible = false;

                    kpnlVersions.Visible = false;

                    tsbtnToolkitGeneralInformation.Checked = true;

                    tsbtnDiscord.Checked = false;

                    tsbtnDeveloperInformation.Checked = false;

                    tsbtnVersions.Checked = false;
                    break;
                case AboutToolkitPage.Discord:
                    kpnlToolkitGeneralInformation.Visible = false;

                    kpnlDiscord.Visible = true;

                    kpnlDeveloperInformation.Visible = false;

                    kpnlVersions.Visible = false;

                    tsbtnToolkitGeneralInformation.Checked = false;

                    tsbtnDiscord.Checked = true;

                    tsbtnDeveloperInformation.Checked = false;

                    tsbtnVersions.Checked = false;
                    break;
                case AboutToolkitPage.DeveloperInformation:
                    kpnlToolkitGeneralInformation.Visible = false;

                    kpnlDiscord.Visible = false;

                    kpnlDeveloperInformation.Visible = true;

                    kpnlVersions.Visible = false;

                    tsbtnToolkitGeneralInformation.Checked = false;

                    tsbtnDiscord.Checked = false;

                    tsbtnDeveloperInformation.Checked = true;

                    tsbtnVersions.Checked = false;
                    break;
                case AboutToolkitPage.Versions:
                    kpnlToolkitGeneralInformation.Visible = false;

                    kpnlDiscord.Visible = false;

                    kpnlDeveloperInformation.Visible = false;

                    kpnlVersions.Visible = true;

                    tsbtnToolkitGeneralInformation.Checked = false;

                    tsbtnDiscord.Checked = false;

                    tsbtnDeveloperInformation.Checked = false;

                    tsbtnVersions.Checked = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(page), page, null);
            }
        }

        private void GetReferenceAssemblyInformation()
        {
            // Get the current assembly
            Assembly currentAssembly = Assembly.GetExecutingAssembly();

            // Place reference assemblies into an array
            // Note: Can we use `FileVersionInfo`?
            AssemblyName[] satelliteAssemblies = currentAssembly.GetReferencedAssemblies();

            foreach (AssemblyName assembly in satelliteAssemblies)
            {
                //FileVersionInfo fileInfo = FileVersionInfo.GetVersionInfo(file);

                // Fill data grid view
                kdgvVersions.Rows.Add(assembly.Name, assembly.Version.ToString());
            }
        }

        private void ShowSystemInformationButton(bool? value) => kbtnSystemInformation.Visible = value ?? true;

        #endregion
    }
}
