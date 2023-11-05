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
        #region Identity

        public KryptonAboutExtendedToolkitForm(KryptonAboutExtendedToolkitData aboutToolkitData)
        {
            InitializeComponent();

            InitialiseDialog(aboutToolkitData);

            kbtnOk.Text = KryptonManager.Strings.GeneralStrings.OK;

            kbtnSystemInformation.Text = KryptonManager.Strings.CustomStrings.SystemInformation;
        }

        #endregion

        #region Implementation

        private void kbtnOk_Click(object sender, EventArgs e) => Close();

        private void kbtnSystemInformation_Click(object sender, EventArgs e) => GlobalToolkitUtilities.LaunchProcess(@"MSInfo32.exe");

        private void tsbtnGeneralInformation_Click(object sender, EventArgs e) => SwitchPages(AboutToolkitPage.GeneralInformation);

        private void tsbtnDiscord_Click(object sender, EventArgs e) => SwitchPages(AboutToolkitPage.Discord);

        private void tsbtnDeveloperInformation_Click(object sender, EventArgs e) => SwitchPages(AboutToolkitPage.DeveloperInformation);

        private void tsbtnVersionInformation_Click(object sender, EventArgs e) => SwitchPages(AboutToolkitPage.Versions);

        private void klwlblGeneralInformation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => GlobalToolkitUtilities.LaunchProcess(@"https://github.com/Krypton-Suite/Extended-Toolkit");

        private void klwlblJoinDiscordServer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => GlobalToolkitUtilities.LaunchProcess(@"https://discord.gg/CRjF6fY");

        private void klwlblViewRepositories_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => GlobalToolkitUtilities.LaunchProcess(@"https://github.com/orgs/Krypton-Suite/repositories");

        private void klwlblDownloadDemos_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => GlobalToolkitUtilities.LaunchProcess(@"https://github.com/Krypton-Suite/Help-Files/releases");

        private void klwlblDownloadDocumentation_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => GlobalToolkitUtilities.LaunchProcess(@"https://github.com/Krypton-Suite/Standard-Toolkit-Demos/releases");

        private void UpdateCurrentThemeText(string value) => klblCurrentTheme.Text = value;

        private void UpdateToolBarText(string toolBarGeneralInformationText, string toolBarDiscordText, string toolBarDeveloperInformationText, string toolBarVersionInformationText)
        {
            tsbtnGeneralInformation.Text = toolBarGeneralInformationText;

            tsbtnDiscord.Text = toolBarDiscordText;

            tsbtnDeveloperInformation.Text = toolBarDeveloperInformationText;

            tsbtnVersionInformation.Text = toolBarVersionInformationText;
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
            tsbtnVersionInformation.Visible = value;

            tssVersionInformation.Visible = value;
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
                    pbxToolkitImage.Image = Resources.Canary;
                    break;
                case ToolkitType.Nightly:
                    pbxToolkitImage.Image = Resources.Nightly;
                    break;
                case ToolkitType.Stable:
                    pbxToolkitImage.Image = Resources.Stable;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
        }

        private void UpdateHeaderText(string value) => kryptonHeaderGroup1.ValuesPrimary.Heading = value;

        private void ConcatanateGeneralInformationText(string welcomeText, string licenseText, string learnMoreText)
        {
            // Note: Do not use verbatim string!
            string output = $"{welcomeText}\r\n\r\n{licenseText}: BSD-3-Clause\r\n\r\n{learnMoreText}";

            klwlblGeneralInformation.Text = output;
        }

        private void UpdateDiscordText(string value) => klwlblJoinDiscordServer.Text = value;

        private void UpdateRepositoriesText(string value) => klwlblViewRepositories.Text = value;

        private void UpdateDocumentationText(string value) => klwlblDownloadDocumentation.Text = value;

        private void UpdateDemosText(string value) => klwlblDownloadDemos.Text = value;

        private void UpdateColumnHeadings(string fileName, string version)
        {
            kdgvVersionInformation.Columns[0].HeaderText = fileName;

            kdgvVersionInformation.Columns[1].HeaderText = version;
        }

        private void UpdateGeneralInformationLinkArea(LinkArea linkArea) => klwlblGeneralInformation.LinkArea = linkArea;

        private void UpdateDiscordLinkArea(LinkArea linkArea) => klwlblJoinDiscordServer.LinkArea = linkArea;

        private void UpdateRepositoriesLinkArea(LinkArea linkArea) => klwlblViewRepositories.LinkArea = linkArea;

        private void UpdateDemosLinkArea(LinkArea linkArea) => klwlblDownloadDemos.LinkArea = linkArea;

        private void UpdateDocumentationLinkArea(LinkArea linkArea) => klwlblDownloadDocumentation.LinkArea = linkArea;

        private void SetLogoSpan(bool value)
        {
            if (value)
            {
                tlpnlGeneralInformation.SetRowSpan(pbxToolkitImage, 3);
            }
            else
            {
                klblCurrentTheme.Text = null;

                ktcmbCurrentTheme.Visible = false;

                tlpnlGeneralInformation.SetRowSpan(pbxToolkitImage, 1);
            }
        }

        private void SwitchPages(AboutToolkitPage page)
        {
            switch (page)
            {
                case AboutToolkitPage.GeneralInformation:
                    kpnlGeneralInformation.Visible = true;

                    kpnlDiscord.Visible = false;

                    kpnlDeveloperInformation.Visible = false;

                    kpnlVersionInformation.Visible = false;

                    tsbtnGeneralInformation.Checked = true;

                    tsbtnDiscord.Checked = false;

                    tsbtnDeveloperInformation.Checked = false;

                    tsbtnVersionInformation.Checked = false;
                    break;
                case AboutToolkitPage.Discord:
                    kpnlGeneralInformation.Visible = false;

                    kpnlDiscord.Visible = true;

                    kpnlDeveloperInformation.Visible = false;

                    kpnlVersionInformation.Visible = false;

                    tsbtnGeneralInformation.Checked = false;

                    tsbtnDiscord.Checked = true;

                    tsbtnDeveloperInformation.Checked = false;

                    tsbtnVersionInformation.Checked = false;
                    break;
                case AboutToolkitPage.DeveloperInformation:
                    kpnlGeneralInformation.Visible = false;

                    kpnlDiscord.Visible = false;

                    kpnlDeveloperInformation.Visible = true;

                    kpnlVersionInformation.Visible = false;

                    tsbtnGeneralInformation.Checked = false;

                    tsbtnDiscord.Checked = false;

                    tsbtnDeveloperInformation.Checked = true;

                    tsbtnVersionInformation.Checked = false;
                    break;
                case AboutToolkitPage.Versions:
                    kpnlGeneralInformation.Visible = false;

                    kpnlDiscord.Visible = false;

                    kpnlDeveloperInformation.Visible = false;

                    kpnlVersionInformation.Visible = true;

                    tsbtnGeneralInformation.Checked = false;

                    tsbtnDiscord.Checked = false;

                    tsbtnDeveloperInformation.Checked = false;

                    tsbtnVersionInformation.Checked = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(page), page, null);
            }
        }

        private void UpdateHeaderFont(Font value) => kryptonHeaderGroup1.StateCommon.HeaderPrimary.Content.ShortText.Font = value;

        private void UpdateCommonFonts(Font value)
        {
            klwlblViewRepositories.StateCommon.Font = value;

            klwlblDownloadDemos.StateCommon.Font = value;

            klwlblJoinDiscordServer.StateCommon.Font = value;

            klwlblDownloadDocumentation.StateCommon.Font = value;

            klwlblGeneralInformation.StateCommon.Font = value;

            ktcmbCurrentTheme.StateCommon.ComboBox.Content.Font = value;
        }

        private void UpdateCurrentThemeFont(Font value) => klblCurrentTheme.StateCommon.ShortText.Font = value;

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

                // Fill datagrid view
                kdgvVersionInformation.Rows.Add(assembly.Name, assembly.Version.ToString());
            }
        }

        private void ShowSystemInformationButton(bool? value) => kbtnSystemInformation.Visible = value ?? true;

        private void InitialiseDialog(KryptonAboutExtendedToolkitData aboutToolkitData)
        {
            // Adjust UI elements
            ShowDeveloperControls(aboutToolkitData.ShowDeveloperInformationButton);

            ShowDiscordControls(aboutToolkitData.ShowDiscordButton);

            ShowVersionControls(aboutToolkitData.ShowVersionInformationButton);

            ShowThemeControls(aboutToolkitData.ShowThemeOptions);

            UpdateCurrentThemeText($@"{aboutToolkitData.CurrentThemeText}:");

            ShowSystemInformationButton(aboutToolkitData.ShowSystemInformationButton);

            SwitchIcon(aboutToolkitData.ToolkitType);

            UpdateHeaderText($@"{aboutToolkitData.HeaderText} Krypton Extended Toolkit");

            ConcatanateGeneralInformationText(aboutToolkitData.GeneralInformationWelcomeText, aboutToolkitData.GeneralInformationLicenseText, aboutToolkitData.GeneralInformationLearnMoreText);

            UpdateDiscordText(aboutToolkitData.DiscordText);

            UpdateRepositoriesText(aboutToolkitData.RepositoryInformationText);

            UpdateDemosText(aboutToolkitData.DownloadDemosText);

            UpdateDocumentationText(aboutToolkitData.DownloadDocumentationText);

            UpdateColumnHeadings(aboutToolkitData.FileNameColumnHeaderText, aboutToolkitData.VersionColumnHeaderText);

            UpdateToolBarText(aboutToolkitData.ToolBarGeneralInformationText, aboutToolkitData.ToolBarDiscordText, aboutToolkitData.ToolBarDeveloperInformationText, aboutToolkitData.ToolBarVersionInformationText);

            UpdateGeneralInformationLinkArea(aboutToolkitData.LearnMoreLinkArea);

            UpdateDocumentationLinkArea(aboutToolkitData.DocumentationLinkArea);

            UpdateDiscordLinkArea(aboutToolkitData.DiscordLinkArea);

            UpdateDemosLinkArea(aboutToolkitData.DownloadDemosLinkArea);

            UpdateRepositoriesLinkArea(aboutToolkitData.RepositoryInformationLinkArea);

            GetReferenceAssemblyInformation();
        }

        #endregion
    }
}