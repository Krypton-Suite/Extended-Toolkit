#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.IO
{
    /*
    /// <summary>
    /// Represents a ListBox control with file names as items.
    /// </summary>
    [Description("Display a list of files that the user can select from"),
     DefaultProperty("DirectoryName"),
     DefaultEvent("FileSelected")]
    public class KryptonFileListBox : KryptonListBox
    {
        #region Events

        /// <summary>
        /// Occures whenever a file is selected by a double click on the control.
        /// </summary>
        [Description("Occures whenever a file is selected by a double click on the control"),
        Category("Action")]
        public event FileSelectedEventHandler FileSelected;

        #endregion

        #region Properties

        string _selectedPath = "C:\\";
        /// <summary>
        /// Gets or sets the directory name that the files should relate to
        /// </summary>        
        [Description("Gets or sets the directory name that the files should relate to"),
        DefaultValue("C:\\"), Category("Data")]
        public string SelectedPath
        {
            get { return _selectedPath; }
            set
            {
                if (_selectedPath != string.Empty)
                {
                    _selectedPath = value;
                    PopulatingItems();
                }
            }
        }

        bool _showDirectories = true;
        /// <summary>
        /// Gets or sets a value indicating wheater to show directories on the control
        /// </summary>        
        [Description("Gets or sets a value indicating wheater to show directories on the control"),
        DefaultValue(true), Category("Behavior")]
        public bool ShowDirectories
        {
            get { return _showDirectories; }
            set
            {
                _showDirectories = value;
                PopulatingItems();
            }
        }

        bool _showBackIcon = true;
        /// <summary>
        /// Gets or sets a value indicating wheater to show the back directory icon
        /// on the control (when the IsToShowDirectories property is true)
        /// </summary>        
        [Description("Gets or sets a value indicating wheater to show the back directory icon on the control (when the IsToShowDirectories property is true)"),
       DefaultValue(true), Category("Behavior")]
        public bool ShowBackIcon
        {
            get { return _showBackIcon; }
            set
            {
                _showBackIcon = value;
                PopulatingItems();
            }
        }

        /// <summary>
        /// Gets an array containting the currently selected files (without directories) 
        /// in the KryptonFileListBox.
        /// </summary>
        [Browsable(false)]
        public string[] SelectedFiles
        {
            get
            {
                ArrayList selectedFiles = new ArrayList();
                foreach (object file in SelectedItems)
                {
                    string selectedFile = GetFullName(file.ToString());
                    // .. ---> go back one level
                    if (selectedFile.EndsWith(".."))
                    {
                        continue;
                    }
                    // only files should be selected
                    else if (File.Exists(selectedFile))
                    {
                        selectedFiles.Add(selectedFile);
                    }
                }
                return selectedFiles.ToArray(typeof(string)) as string[];
            }
        }
        /// <summary>
        /// Gets the currently selected file in the KryptonFileListBox
        /// </summary>
        [Browsable(false)]
        public string SelectedFile
        {
            get
            {
                string[] selectedFiles = SelectedFiles;
                if (selectedFiles.Length > 0)
                    return selectedFiles[0];
                else
                    return null;
            }
        }

        private IconSize _fileIconSize = IconSize.Small;
        /// <summary>
        /// Gets or sets the icon size, this value also sets the item heigth
        /// </summary>
        [Description("Specifies the size of the icon of each file - small or large"),
         DefaultValue(typeof(IconSize), "IconSize.Small"), Category("Appearance")]
        public IconSize FileIconSize
        {
            get { return _fileIconSize; }
            set
            {
                _fileIconSize = value;
                switch (_fileIconSize)
                {
                    case IconSize.Small:
                        base.ItemHeight = 16;
                        break;
                    case IconSize.Large:
                        base.ItemHeight = 32;
                        break;
                }
                Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the item height. can only be 32 or 16.
        /// </summary>
        [Browsable(false)]
        public override int ItemHeight
        {
            get
            {
                return base.ItemHeight;
            }
            set
            {
                if (value == 32)
                {
                    FileIconSize = IconSize.Large;
                    base.ItemHeight = 32;
                }
                else
                {
                    FileIconSize = IconSize.Small;
                    base.ItemHeight = 16;
                }

            }
        }

        #endregion

        #region Ctor(s)

        /// <summary>
        /// Intializes a new instance of the KryptonFileListBox class, to view a list of
        /// files inside a ListBox control.
        /// </summary>
        public KryptonFileListBox()
        {
            SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            DrawMode = DrawMode.OwnerDrawFixed;
        }
        /// <summary>
        /// Intializes a new instance of the KryptonFileListBox class, to view a list of
        /// files inside a ListBox control.
        /// </summary>
        /// <param name="directoryName">The directory to start from</param>
        public KryptonFileListBox(string directoryName)
            : this()
        {
            _selectedPath = SelectedPath;
            PopulatingItems();
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Adds the specified directory to the list.
        /// </summary>
        /// <param name="directoryName"></param>
        private void AddDirectory(string directoryName)
        {
            Items.Add(directoryName);
        }

        /// <summary>
        /// Adds the specified file to the list.
        /// </summary>
        /// <param name="fileName"></param>
        private void AddFile(string fileName)
        {
            Items.Add(fileName);
        }

        /// <summary>
        /// Gets the full file name, by adding the directory name to the file specified.
        /// </summary>
        /// <param name="fileNameOnly"></param>
        /// <returns></returns>
        private string GetFullName(string fileNameOnly)
        {
            return Path.Combine(_selectedPath, fileNameOnly);
        }

        /// <summary>
        /// Populate the list box with files and directories according to the 
        /// directoryName property
        /// </summary>
        private void PopulatingItems()
        {
            // Ignore when in desing mode
            if (DesignMode)
                return;

            this.Items.Clear();
            // Shows the back directory item (            
            if (_showBackIcon && _selectedPath.Length > 3)
            {
                Items.Add("..");
            }
            try
            {
                // Fills all directory items
                if (_showDirectories)
                {
                    string[] dirNames = Directory.GetDirectories(_selectedPath);
                    foreach (string dir in dirNames)
                    {
                        string realDir = Path.GetFileName(dir);
                        Items.Add(realDir);
                    }
                }
                // Fills all list items
                string[] fileNames = Directory.GetFiles(_selectedPath);
                foreach (string file in fileNames)
                {
                    string fileName = Path.GetFileName(file);
                    Items.Add(fileName);
                }
            }
            catch
            {
                // eat this - back is still optional even when no other items exists
            }
            Invalidate();
        }

        #endregion

        #region Event Handlers
        /// <summary>
        /// Overrides, when double click on the list - fires the FileSelected event,
        /// or, for directory, move into it.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            if (SelectedItem == null) return;
            string selectedFile = GetFullName(SelectedItem.ToString());
            // .. ---> go back one level
            if (selectedFile.EndsWith(".."))
            {
                // Removes the \ in the end, so that the parent will return the real parent.
                if (_selectedPath.EndsWith("\\"))
                    _selectedPath = _selectedPath.Remove(_selectedPath.Length - 1, 1);
                _selectedPath = Directory.GetParent(_selectedPath).FullName;
                PopulatingItems();
            }
            // go inside the directory
            else if (Directory.Exists(selectedFile))
            {
                _selectedPath = selectedFile + "\\";
                PopulatingItems();
            }
            else
            {
                OnFileSelected(new FileSelectEventArgs(selectedFile));
            }
            base.OnMouseDoubleClick(e);
        }
        /// <summary>
        /// Fires the FileSelected event.
        /// </summary>
        /// <param name="fse"></param>
        protected void OnFileSelected(FileSelectEventArgs fse)
        {
            if (FileSelected != null)
                FileSelected(this, fse);
        }

        #endregion
    }
    */
}