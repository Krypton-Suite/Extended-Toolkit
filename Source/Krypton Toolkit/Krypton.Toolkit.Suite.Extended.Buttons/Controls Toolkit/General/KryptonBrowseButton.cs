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
        private bool _openFile, _saveFile;

        private string _filePath, _dialogTitle;

        private string[] _dialogFilter;
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

        public string DialogTitle { get => _dialogTitle; set => _dialogTitle = value; }

        public string FilePath { get => _filePath; private set => _filePath = value; }

        public string[] DialogFilter { get => _dialogFilter; set => _dialogFilter = value; }
        #endregion

        #region Constructor
        public KryptonBrowseButton()
        {
            FilePath = string.Empty;

            Text = @".&..";

            Size = new Size(34, 25);
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
            if (_openFile)
            {
                if (_dialogFilter != null)
                {
                    OpenFileDialog openFile = new OpenFileDialog();

                    openFile.Filter = _dialogFilter.ToString();

                    openFile.Title = _dialogTitle;

                    if (openFile.ShowDialog() == DialogResult.OK)
                    {
                        FilePath = Path.GetFullPath(openFile.FileName);
                    }
                }
                else
                {
                    OpenFileDialog openFile = new OpenFileDialog();

                    openFile.Title = _dialogTitle;

                    if (openFile.ShowDialog() == DialogResult.OK)
                    {
                        FilePath = Path.GetFullPath(openFile.FileName);
                    }
                }
            }
            else if (_saveFile)
            {
                if (_dialogFilter != null)
                {
                    SaveFileDialog saveFile = new SaveFileDialog();

                    saveFile.Filter = _dialogFilter.ToString();

                    saveFile.Title = _dialogTitle;

                    if (saveFile.ShowDialog() == DialogResult.OK)
                    {
                        FilePath = Path.GetFullPath(saveFile.FileName);
                    }
                }
                else
                {
                    SaveFileDialog saveFile = new SaveFileDialog();

                    saveFile.Title = _dialogTitle;

                    if (saveFile.ShowDialog() == DialogResult.OK)
                    {
                        FilePath = Path.GetFullPath(saveFile.FileName);
                    }
                }
            }

            base.OnClick(e);
        }
        #endregion
    }
}