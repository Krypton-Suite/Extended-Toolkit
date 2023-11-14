#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
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

using OpenFileDialog = System.Windows.Forms.OpenFileDialog;
using SaveFileDialog = System.Windows.Forms.SaveFileDialog;

namespace Krypton.Toolkit.Suite.Extended.Buttons
{
    public class KryptonBrowseButton : KryptonButton
    {
        #region Variables
        private bool _openFile, _saveFile, _useSystemFolderBrowser, _showNewFolderButtonOnDialog, _allowMultiSelect;

        private string _filePath, _dialogTitle, _folderBrowserDialogDescription, _rawDisplayName, _extensionList;

        private string[]? _dialogFilter;

        private BrowseButtonAction _browseButtonAction;

        private IEnumerable<string> _fileNames;

        private FileDialogType _fileDialogType;

        //private CommonFileDialogStandardFilters _commonFileDialogFilter;
        #endregion

        #region Properties
        public bool UseAsOpenFileBrowseButton { get => _openFile; set => _openFile = value; }

        public bool UseAsSaveFileBrowseButton { get => _saveFile; set => _saveFile = value; }

        /// <summary>Gets or sets a value indicating whether [use system folder browser].</summary>
        /// <value><c>true</c> if [use system folder browser]; otherwise, <c>false</c>.</value>
        [DefaultValue(true), Description("Use the standard WinForms folder browser dialog.")]
        public bool UseSystemFolderBrowser { get => _useSystemFolderBrowser; set => _useSystemFolderBrowser = value; }

        /// <summary>Gets or sets a value indicating whether [show new folder button on dialog].</summary>
        /// <value><c>true</c> if [show new folder button on dialog]; otherwise, <c>false</c>.</value>
        [DefaultValue(false), Description("Shows the new folder button on the standard WinForms folder browser dialog.")]
        public bool ShowNewFolderButtonOnDialog { get => _showNewFolderButtonOnDialog; set => _showNewFolderButtonOnDialog = value; }


        [DefaultValue(false), Description("Allows the user to select multiple files in a open file dialog. To be used in conjunction with the Windows API Code Pack version.")]
        public bool AllowMultiSelect { get => _allowMultiSelect; set => _allowMultiSelect = value; }

        /// <summary>Gets or sets the dialog title.</summary>
        /// <value>The dialog title.</value>
        [DefaultValue(""), Description("The title of the dialog.")]
        public string DialogTitle { get => _dialogTitle; set => _dialogTitle = value; }

        /// <summary>Gets the file path.</summary>
        /// <value>The file path.</value>
        [DefaultValue(""), Description("Displays the complete file path of the object.")]
        public string FilePath { get => _filePath; private set => _filePath = value; }

        /// <summary>Gets or sets the folder browser dialog description.</summary>
        /// <value>The folder browser dialog description.</value>
        public string FolderBrowserDialogDescription { get => _folderBrowserDialogDescription; set => _folderBrowserDialogDescription = value; }

        /// <summary>Gets or sets the display name of the raw.</summary>
        /// <value>The display name of the raw.</value>
        public string RawDisplayName { get => _rawDisplayName; set => _rawDisplayName = value; }

        /// <summary>Gets or sets the extension list.</summary>
        /// <value>The extension list.</value>
        public string ExtensionList { get => _extensionList; set => _extensionList = value; }

        /// <summary>Gets or sets the dialog filter.</summary>
        /// <value>The dialog filter.</value>
        public string[] DialogFilter { get => _dialogFilter; set => _dialogFilter = value; }

        /// <summary>Gets or sets the browse button action.</summary>
        /// <value>The browse button action.</value>
        public BrowseButtonAction BrowseButtonAction { get => _browseButtonAction; set => _browseButtonAction = value; }

        /// <summary>Gets or sets the file names.</summary>
        /// <value>The file names.</value>
        public IEnumerable<string> FileNames { get => _fileNames; set => _fileNames = value; }

        public FileDialogType FileDialogType { get => _fileDialogType; set => _fileDialogType = value; }

        #endregion

        #region Identity
        public KryptonBrowseButton()
        {
            _filePath = string.Empty;

            Text = @".&..";

            Size = new(34, 25);

            _browseButtonAction = BrowseButtonAction.SaveFile;

            _fileDialogType = FileDialogType.Standard;
        }
        #endregion

        #region Overrides
        protected override void OnClick(EventArgs e)
        {
            switch (_fileDialogType)
            {
                case FileDialogType.Krypton:
                    switch (_browseButtonAction)
                    {
                        case BrowseButtonAction.OpenFile:
                            if (_dialogFilter != null)
                            {
                                KryptonOpenFileDialog ofd = new();

                                ofd.Filter = _dialogFilter.ToString();

                                ofd.Title = _dialogTitle;

                                if (ofd.ShowDialog() == DialogResult.OK)
                                {
                                    _filePath = Path.GetFullPath(ofd.FileName);
                                }
                            }
                            else
                            {
                                KryptonOpenFileDialog ofd = new();

                                ofd.Title = _dialogTitle;

                                if (ofd.ShowDialog() == DialogResult.OK)
                                {
                                    _filePath = Path.GetFullPath(ofd.FileName);
                                }
                            }
                            break;
                        case BrowseButtonAction.OpenDirectory:
                            KryptonFolderBrowserDialog fbd = new();

                            if (fbd.ShowDialog() == DialogResult.OK)
                            {
                                _filePath = fbd.SelectedPath;
                            }
                            break;
                        case BrowseButtonAction.SaveFile:
                            if (_dialogFilter != null)
                            {
                                KryptonSaveFileDialog sfd = new();

                                sfd.Filter = _dialogFilter.ToString();

                                sfd.Title = _dialogTitle;

                                if (sfd.ShowDialog() == DialogResult.OK)
                                {
                                    _filePath = Path.GetFullPath(sfd.FileName);
                                }
                            }
                            else
                            {
                                KryptonSaveFileDialog sfd = new();

                                sfd.Title = _dialogTitle;

                                if (sfd.ShowDialog() == DialogResult.OK)
                                {
                                    FilePath = Path.GetFullPath(sfd.FileName);
                                }
                            }
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    break;
                case FileDialogType.Standard:
                    switch (_browseButtonAction)
                    {
                        case BrowseButtonAction.OpenFile:
                            if (_dialogFilter != null)
                            {
                                OpenFileDialog ofd = new();

                                ofd.Filter = _dialogFilter.ToString();

                                ofd.Title = _dialogTitle;

                                if (ofd.ShowDialog() == DialogResult.OK)
                                {
                                    _filePath = Path.GetFullPath(ofd.FileName);
                                }
                            }
                            else
                            {
                                OpenFileDialog ofd = new();

                                ofd.Title = _dialogTitle;

                                if (ofd.ShowDialog() == DialogResult.OK)
                                {
                                    _filePath = Path.GetFullPath(ofd.FileName);
                                }
                            }
                            break;
                        case BrowseButtonAction.OpenDirectory:
                            FolderBrowserDialog fbd = new();

                            fbd.Description = _folderBrowserDialogDescription;

                            fbd.ShowNewFolderButton = _showNewFolderButtonOnDialog;

                            if (fbd.ShowDialog() == DialogResult.OK)
                            {
                                _filePath = fbd.SelectedPath;
                            }
                            break;
                        case BrowseButtonAction.SaveFile:
                            if (_dialogFilter != null)
                            {
                                SaveFileDialog sfd = new();

                                sfd.Filter = _dialogFilter.ToString();

                                sfd.Title = _dialogTitle;

                                if (sfd.ShowDialog() == DialogResult.OK)
                                {
                                    _filePath = Path.GetFullPath(sfd.FileName);
                                }
                            }
                            else
                            {
                                SaveFileDialog sfd = new();

                                sfd.Title = _dialogTitle;

                                if (sfd.ShowDialog() == DialogResult.OK)
                                {
                                    FilePath = Path.GetFullPath(sfd.FileName);
                                }
                            }
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    break;
                case FileDialogType.WindowsAPICodePack:
                    switch (_browseButtonAction)
                    {
                        case BrowseButtonAction.OpenFile:
                            if (_dialogFilter != null)
                            {
                                CommonOpenFileDialog ofd = new();

                                ofd.Filters.Add(new CommonFileDialogFilter(_rawDisplayName, _extensionList));

                                ofd.Multiselect = _allowMultiSelect;

                                ofd.Title = _dialogTitle;

                                if (ofd.ShowDialog() == CommonFileDialogResult.Ok)
                                {
                                    _filePath = Path.GetFullPath(ofd.FileName);

                                    _fileNames = ofd.FileNames;
                                }
                            }
                            else
                            {
                                CommonOpenFileDialog ofd = new();

                                ofd.Title = _dialogTitle;

                                if (ofd.ShowDialog() == CommonFileDialogResult.Ok)
                                {
                                    _filePath = Path.GetFullPath(ofd.FileName);

                                    _fileNames = ofd.FileNames;
                                }
                            }
                            break;
                        case BrowseButtonAction.OpenDirectory:
                            CommonOpenFileDialog cofd = new CommonOpenFileDialog();

                            cofd.Title = _dialogTitle;

                            cofd.Multiselect = _allowMultiSelect;

                            cofd.IsFolderPicker = true;

                            if (cofd.ShowDialog() == CommonFileDialogResult.Ok)
                            {
                                _filePath = Path.GetFullPath(cofd.FileName);
                            }
                            break;
                        case BrowseButtonAction.SaveFile:
                            if (_dialogFilter != null)
                            {
                                CommonSaveFileDialog csfd = new CommonSaveFileDialog();

                                csfd.Title = _dialogTitle;

                                csfd.Filters.Add(new CommonFileDialogFilter(_rawDisplayName, _extensionList));

                                if (csfd.ShowDialog() == CommonFileDialogResult.Ok)
                                {
                                    _filePath = Path.GetFullPath(csfd.FileName);
                                }
                            }
                            else
                            {
                                CommonSaveFileDialog csfd = new CommonSaveFileDialog();

                                csfd.Title = _dialogTitle;

                                if (csfd.ShowDialog() == CommonFileDialogResult.Ok)
                                {
                                    _filePath = Path.GetFullPath(csfd.FileName);
                                }
                            }
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            base.OnClick(e);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string Text { get; set; }

        #endregion
    }
}