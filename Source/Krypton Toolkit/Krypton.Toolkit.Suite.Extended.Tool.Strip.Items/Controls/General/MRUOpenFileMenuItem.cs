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

namespace Krypton.Toolkit.Suite.Extended.Tool.Strip.Items
{
    [ToolboxItem(false), ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.MenuStrip)]
    public class MRUOpenFileMenuItem : ToolStripMenuItem
    {
        #region Instance Fields

        private bool _useSystemDialogs;

        private Control _outputControl = null;

        private string _defaultText = "O&pen";

        private string _applicationName;

        private string _openFileDialogTitle = "Open:";

        private string _rawFilterDisplayName;

        private string _rawExtensionList;

        private string _standardDialogFilter;

        private string _startingDirectory;

        private MRUMenuItem _parentMruMenuItem;
        
        private MostRecentlyUsedFileManager _recentlyUsedFileManager = null;

        #endregion

        #region Public
        /// <summary>Gets or sets a value indicating whether to use the native system dialogs over the Windows API CodePack types.</summary>
        /// <value> <c>true</c> if [use system dialogs]; otherwise, <c>false</c>.</value>
        [DefaultValue(false), Description("Use the native system dialogs over the Windows API CodePack types.")]
        public bool UseSystemDialogs { get => _useSystemDialogs; set => _useSystemDialogs = value; }

        /// <summary>Gets or sets the control to load the file content text into.</summary>
        /// <value>The control to load the file content text into.</value>
        [DefaultValue(null), Description("The control to load the file content text into.")]
        public Control OutputControl { get => _outputControl; set => _outputControl = value; }

        /// <summary>Gets or sets the text displayed on the tool strip menu item.</summary>
        /// <value>The text displayed on the tool strip menu item.</value>
        [DefaultValue("O&pen"), Description("The text displayed on the tool strip menu item.")]
        public string DefaultText { get => _defaultText; set => _defaultText = value; }

        /// <summary>Gets or sets the name of the name of your application. This is used to store the MRU list in the Windows registry.</summary>
        /// <value>The name of the application.</value>
        [DefaultValue(null), Description("The name of your application. This is used to store the MRU list in the Windows registry.")]
        public string ApplicationName { get => _applicationName; set => _applicationName = value; }

        /// <summary>Gets or sets the open file dialog title.</summary>
        /// <value>The open file dialog title.</value>
        [DefaultValue("Open:"), Description("The title of the open file dialog.")]
        public string OpenFileDialogTitle { get => _openFileDialogTitle; set => _openFileDialogTitle = value; }

        /// <summary>Gets or sets the display name of the raw filter. Please refer to <see cref="CommonFileDialogFilter"/> documentation for more information.</summary>
        /// <value>The display name of the raw filter.</value>
        [DefaultValue(null), Description("The display name of the raw filter.")]
        public string RawFilterDisplayName { get => _rawFilterDisplayName; set => _rawFilterDisplayName = value; }

        /// <summary>Gets or sets the raw extension list. Please refer to <see cref="CommonFileDialogFilter"/> documentation for more information.</summary>
        /// <value>The raw extension list.</value>
        [DefaultValue(null), Description("The raw extension list.")]
        public string RawExtensionList { get => _rawExtensionList; set => _rawExtensionList = value; }

        [DefaultValue(null), Description("")]
        public string StandardDialogFilter { get => _standardDialogFilter; set => _standardDialogFilter = value; }

        /// <summary>Gets or sets the starting directory of the open file dialog.</summary>
        /// <value>The starting directory of the open file dialog.</value>
        [DefaultValue(Environment.SpecialFolder.MyDocuments), Description("The starting directory of the open file dialog.")]
        public string StartingDirectory { get => _startingDirectory; set => _startingDirectory = value; }

        /// <summary>Gets or sets the parent MRU menu item.</summary>
        /// <value>The parent MRU menu item.</value>
        [DefaultValue(null), Description("The parent MRU menu item.")]
        public MRUMenuItem ParentMRUMenuItem { get => _parentMruMenuItem; set => _parentMruMenuItem = value; }

        #endregion

        #region Identity

        public MRUOpenFileMenuItem()
        {
            Text = _defaultText;

            Image = ProjectResources.Open;

            _useSystemDialogs = true;

            _outputControl = null;

            _defaultText = "O&pen";

            _applicationName = null;

            _openFileDialogTitle = "Open:";

            _rawFilterDisplayName = "";

            _rawExtensionList = "";

            _standardDialogFilter = "";

            _startingDirectory = Environment.SpecialFolder.MyDocuments.ToString();

            _parentMruMenuItem = null;

            _recentlyUsedFileManager = new MostRecentlyUsedFileManager(_parentMruMenuItem, _applicationName, null, null);

            ShortcutKeys = Keys.Control | Keys.O;

            ShortcutKeyDisplayString = "Ctrl + O";
        }

        public MRUOpenFileMenuItem(string defaultText)
        {
            
        }

        #endregion

        #region Implementation

        private void OpenFile(string filePath, Control outputControl)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    if (outputControl != null)
                    {
                        StreamReader sr = new StreamReader(filePath);

                        outputControl.Text = sr.ReadToEnd();

                        sr.Close();

                        sr.Dispose();
                    }

                    _recentlyUsedFileManager.AddRecentFile(filePath);
                }
                else
                {
                    KryptonMessageBox.Show($"Error: file '{filePath}' could not be found!");
                }
            }
            catch (IOException e)
            {
                ExceptionCapture.CaptureException(e);
            }
        }

        #endregion

        #region Protected

        protected override void OnClick(EventArgs e)
        {
            try
            {
                if (!_useSystemDialogs)
                {
                    CommonOpenFileDialog ofd = new CommonOpenFileDialog();

                    ofd.Title = _openFileDialogTitle;

                    ofd.Filters.Add(new CommonFileDialogFilter(_rawFilterDisplayName, _rawExtensionList));

                    if (MissingFrameWorkAPIs.IsNullOrWhiteSpace(_startingDirectory))
                    {
                        ofd.InitialDirectory = Environment.CurrentDirectory;
                    }
                    else
                    {
                        ofd.InitialDirectory = _startingDirectory;
                    }

                    if (ofd.ShowDialog() == CommonFileDialogResult.Ok)
                    {
                        return;
                    }

                    string openedFile = ofd.FileName;

                    OpenFile(openedFile, _outputControl);
                }
                else
                {
                    OpenFileDialog ofd = new OpenFileDialog();

                    ofd.Title = _openFileDialogTitle;

                    ofd.Filter = _standardDialogFilter;

                    if (MissingFrameWorkAPIs.IsNullOrWhiteSpace(_startingDirectory))
                    {
                        ofd.InitialDirectory = Environment.CurrentDirectory;
                    }
                    else
                    {
                        ofd.InitialDirectory = _startingDirectory;
                    }

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        return;
                    }

                    string openedFile = ofd.FileName;

                    OpenFile(openedFile, _outputControl);
                }
            }
            catch (Exception ex)
            {
                ExceptionCapture.CaptureException(ex);
            }

            base.OnClick(e);
        }

        #endregion
    }
}
