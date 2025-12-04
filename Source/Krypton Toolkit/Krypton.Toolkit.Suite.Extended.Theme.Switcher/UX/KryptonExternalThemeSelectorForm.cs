#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Theme.Switcher;

public partial class KryptonExternalThemeSelectorForm : KryptonForm
{
    #region Instance Fields

    private ExternalThemeType _externalThemeType;

    private ExternalThemeViewerType _externalThemeViewerType;

    private FileDialogType _fileDialogType;

    #endregion

    #region Identity

    /// <summary>Initializes a new instance of the <see cref="KryptonExternalThemeSelectorForm" /> class.</summary>
    /// <param name="externalThemeType">Type of the external theme.</param>
    /// <param name="externalThemeViewerType">Type of the external theme viewer.</param>
    public KryptonExternalThemeSelectorForm(ExternalThemeType? externalThemeType, ExternalThemeViewerType? externalThemeViewerType)
    {
        InitializeComponent();

        _externalThemeType = externalThemeType ?? ExternalThemeType.ExtensibleMarkupLanguage;

        _externalThemeViewerType = externalThemeViewerType ?? ExternalThemeViewerType.ListBox;

        kbtnApply.Text = KryptonManager.Strings.CustomStrings.Apply;

        kbtnCancel.Text = KryptonManager.Strings.GeneralStrings.Cancel;

        kbtnOk.Text = KryptonManager.Strings.GeneralStrings.OK;

        UpdateUI(externalThemeType, externalThemeViewerType);
    }

    #endregion

    #region Implementation

    /// <summary>Updates the UI.</summary>
    /// <param name="externalThemeType">Type of the external theme.</param>
    /// <param name="externalThemeViewerType">Type of the external theme viewer.</param>
    /// <exception cref="ArgumentOutOfRangeException">externalThemeType - null or externalThemeViewerType - null</exception>
    private void UpdateUI(ExternalThemeType? externalThemeType, ExternalThemeViewerType? externalThemeViewerType)
    {
        switch (externalThemeType)
        {
            case ExternalThemeType.Binary:
                klblPath.Text = @"File Path:";

                ktxtThemeLocation.CueHint.CueHintText = @"Enter a file path...";
                break;
            case ExternalThemeType.ExtensibleMarkupLanguage:
                klblPath.Text = @"Directory Path:";

                ktxtThemeLocation.CueHint.CueHintText = @"Enter a directory path...";
                break;
            case null:
                klblPath.Text = @"File Path:";

                ktxtThemeLocation.CueHint.CueHintText = @"Enter a file path...";
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(externalThemeType), externalThemeType, null);
        }

        switch (externalThemeViewerType)
        {
            case ExternalThemeViewerType.ListBox:
                klbThemesList.Visible = true;

                klvThemesList.Visible = false;
                break;
            case ExternalThemeViewerType.ListView:
                klbThemesList.Visible = false;

                klvThemesList.Visible = true;
                break;
            case null:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(externalThemeViewerType), externalThemeViewerType, null);
        }
    }

    private void KryptonExternalThemeSelectorForm_Load(object sender, EventArgs e)
    {

    }

    private void bsaReset_Click(object sender, EventArgs e)
    {
        ktxtThemeLocation.Text = string.Empty;

        bsaReset.Enabled = ButtonEnabled.False;
    }

    private void bsaBrowse_Click(object sender, EventArgs e)
    {
        switch (_fileDialogType)
        {
            case FileDialogType.Krypton:
                KryptonFolderBrowserDialog kfbd = new();

                if (_externalThemeType == ExternalThemeType.Binary)
                {

                }
                else
                {
                    kfbd.Title = @"Open themes directory:";

                    if (kfbd.ShowDialog() == DialogResult.OK)
                    {
                        ktxtThemeLocation.Text = Path.GetFullPath(kfbd.SelectedPath);

                        LoadThemesFromDirectory(Path.GetFullPath(kfbd.SelectedPath));
                    }
                }
                break;
            case FileDialogType.Standard:
                FolderBrowserDialog fbd = new();

                if (_externalThemeType == ExternalThemeType.Binary)
                {

                }
                else
                {
                    fbd.Description = @"Open themes directory:";

                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        ktxtThemeLocation.Text = Path.GetFullPath(fbd.SelectedPath);

                        LoadThemesFromDirectory(Path.GetFullPath(fbd.SelectedPath));
                    }
                }
                break;
            case FileDialogType.WindowsAPICodePack:
                CommonOpenFileDialog commonOpenFileDialog;

                if (_externalThemeType == ExternalThemeType.Binary)
                {

                }
                else
                {
                    commonOpenFileDialog = new()
                    {
                        Title = @"Open themes directory:",
                        IsFolderPicker = true
                    };

                    if (commonOpenFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
                    {
                        ktxtThemeLocation.Text = Path.GetFullPath(commonOpenFileDialog.FileName);

                        LoadThemesFromDirectory(Path.GetFullPath(commonOpenFileDialog.FileName));
                    }
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    /// <summary>Loads the themes from directory.</summary>
    /// <param name="themeLocation">The theme location.</param>
    private void LoadThemesFromDirectory(string themeLocation)
    {
        try
        {
            if (!string.IsNullOrEmpty(themeLocation))
            {
                // Get the information of the directory
                DirectoryInfo di = new(themeLocation);

                // Create an array of files listed in the selected directory
                FileInfo[] files = di.GetFiles();

                if (klbThemesList.Visible)
                {
                    foreach (FileInfo file in files)
                    {
                        klbThemesList.Items.Add(Path.GetFullPath(file.Name));
                    }
                }
                else if (klvThemesList.Visible)
                {
                    foreach (FileInfo file in files)
                    {
                        klvThemesList.Items.Add(Path.GetFullPath(file.Name));
                    }
                }
            }
        }
        catch (Exception e)
        {
            DebugUtilities.NotImplemented(e.ToString());
        }
    }

    private void klbThemesList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void klvThemesList_SelectedIndexChanged(object sender, EventArgs e)
    {
        kcpbCustom.Import(klvThemesList.SelectedItems.ToString(), kchkSilent.Checked);

        kmanCustom.GlobalPaletteMode = PaletteMode.Custom;

        kmanCustom.GlobalCustomPalette = kcpbCustom;

        kbtnApply.Enabled = true;
    }

    #endregion
}