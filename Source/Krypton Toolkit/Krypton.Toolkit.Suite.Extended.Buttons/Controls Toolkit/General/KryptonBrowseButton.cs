#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Buttons
{
    public class KryptonBrowseButton : KryptonButton
    {
        #region Variables
        private bool _openFile, _saveFile, _useSystemFolderBrowser, _showNewFolderButtonOnDialog, _useWindowsAPICodePackDialogs, _allowMultiSelect;

        private string _filePath, _dialogTitle, _folderBrowserDialogDescription, _rawDisplayName, _extensionList;

        private string[] _dialogFilter;

        private BrowseButtonAction _browseButtonAction;

        private IEnumerable<string> _fileNames;

        //private CommonFileDialogStandardFilters _commonFileDialogFilter;
        #endregion

        #region Properties
        public bool OpenFile
        {
            get => _openFile;

            set
            {
                if (_openFile != value)
                {
                    _openFile = value;
                }

                if (_openFile)
                {
                    SetBrowseType(_openFile, false);
                }
            }
        }

        public bool SaveFile
        {
            get => _saveFile;

            set
            {
                if (_saveFile != value)
                {
                    _saveFile = value;
                }

                if (_saveFile)
                {
                    SetBrowseType(false, true);
                }
            }
        }

        public bool UseSystemFolderBrowser { get => _useSystemFolderBrowser; set => _useSystemFolderBrowser = value; }

        public bool ShowNewFolderButtonOnDialog { get => _showNewFolderButtonOnDialog; set => _showNewFolderButtonOnDialog = value; }

        public bool UseWindowsAPICodePackDialogs { get => _useSystemFolderBrowser; set => _useSystemFolderBrowser = value; }

        public bool AllowMultiSelect { get => _allowMultiSelect; set => _allowMultiSelect = value; }

        public string DialogTitle { get => _dialogTitle; set => _dialogTitle = value; }

        public string FilePath { get => _filePath; private set => _filePath = value; }

        public string FolderBrowserDialogDescription { get => _folderBrowserDialogDescription; set => _folderBrowserDialogDescription = value; }

        public string RawDisplayName { get => _rawDisplayName; set => _rawDisplayName = value; }

        public string ExtensionList { get => _extensionList; set => _extensionList = value; }

        public string[] DialogFilter { get => _dialogFilter; set => _dialogFilter = value; }

        public BrowseButtonAction BrowseButtonAction { get => _browseButtonAction; set => _browseButtonAction = value; }

        public IEnumerable<string> FileNames { get => _fileNames; set => _fileNames = value; }
        #endregion

        #region Constructor
        public KryptonBrowseButton()
        {
            FilePath = string.Empty;

            Text = @".&..";

            Size = new Size(34, 25);

            BrowseButtonAction = BrowseButtonAction.SAVEFILE;
        }
        #endregion

        #region Methods
        private void SetBrowseType(bool openFile, bool saveFile)
        {
            _openFile = openFile;

            _saveFile = saveFile;
        }
        #endregion

        #region Overrides
        // TODO: Replace with WindowsAPICodePack dialogs 
        protected override void OnClick(EventArgs e)
        {
            switch (_browseButtonAction)
            {
                case BrowseButtonAction.SAVEFILE:
                    if (!_useWindowsAPICodePackDialogs)
                    {
                        if (_dialogFilter != null)
                        {
                            SaveFileDialog sfd = new SaveFileDialog();

                            sfd.Filter = _dialogFilter.ToString();

                            sfd.Title = _dialogTitle;

                            if (sfd.ShowDialog() == DialogResult.OK)
                            {
                                _filePath = Path.GetFullPath(sfd.FileName);
                            }
                        }
                        else
                        {
                            SaveFileDialog sfd = new SaveFileDialog();

                            sfd.Title = _dialogTitle;

                            if (sfd.ShowDialog() == DialogResult.OK)
                            {
                                FilePath = Path.GetFullPath(sfd.FileName);
                            }
                        }
                    }
                    else
                    {
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
                    }
                    break;
                case BrowseButtonAction.OPENDIRECTORY:
                    if (_useSystemFolderBrowser)
                    {
                        FolderBrowserDialog fbd = new FolderBrowserDialog();

                        fbd.Description = _folderBrowserDialogDescription;

                        fbd.ShowNewFolderButton = _showNewFolderButtonOnDialog;

                        if (fbd.ShowDialog() == DialogResult.OK)
                        {
                            _filePath = fbd.SelectedPath;
                        }
                    }
                    else
                    {
                        CommonOpenFileDialog cofd = new CommonOpenFileDialog();

                        cofd.Title = _dialogTitle;

                        cofd.Multiselect = _allowMultiSelect;

                        cofd.IsFolderPicker = true;

                        if (cofd.ShowDialog() == CommonFileDialogResult.Ok)
                        {
                            _filePath = Path.GetFullPath(cofd.FileName);
                        }
                    }
                    break;
                case BrowseButtonAction.OPENFILE:
                    if (!_useWindowsAPICodePackDialogs)
                    {
                        if (_dialogFilter != null)
                        {
                            OpenFileDialog ofd = new OpenFileDialog();

                            ofd.Filter = _dialogFilter.ToString();

                            ofd.Title = _dialogTitle;

                            if (ofd.ShowDialog() == DialogResult.OK)
                            {
                                _filePath = Path.GetFullPath(ofd.FileName);
                            }
                        }
                        else
                        {
                            OpenFileDialog ofd = new OpenFileDialog();

                            ofd.Title = _dialogTitle;

                            if (ofd.ShowDialog() == DialogResult.OK)
                            {
                                _filePath = Path.GetFullPath(ofd.FileName);
                            }
                        }
                    }
                    else
                    {
                        if (_dialogFilter != null)
                        {
                            CommonOpenFileDialog cofd = new CommonOpenFileDialog();

                            cofd.Filters.Add(new CommonFileDialogFilter(_rawDisplayName, _extensionList));

                            cofd.Multiselect = _allowMultiSelect;

                            cofd.Title = _dialogTitle;

                            if (cofd.ShowDialog() == CommonFileDialogResult.Ok)
                            {
                                _filePath = Path.GetFullPath(cofd.FileName);

                                _fileNames = cofd.FileNames;
                            }
                        }
                        else
                        {
                            CommonOpenFileDialog cofd = new CommonOpenFileDialog();

                            cofd.Title = _dialogTitle;

                            if (cofd.ShowDialog() == CommonFileDialogResult.Ok)
                            {
                                _filePath = Path.GetFullPath(cofd.FileName);

                                _fileNames = cofd.FileNames;
                            }
                        }
                    }
                    break;
            }

            base.OnClick(e);
        }
        #endregion
    }
}