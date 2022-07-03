namespace Krypton.Toolkit.Suite.Extended.Tool.Strip.Items
{
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.MenuStrip)]
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

        private GlobalMethods _globalMethods = new GlobalMethods();

        private UtilityMethods _utilityMethods = new UtilityMethods();

        #endregion

        #region Public
        [DefaultValue(false), Description("")]
        public bool UseSystemDialogs { get => _useSystemDialogs; set => _useSystemDialogs = value; }

        [DefaultValue(null), Description("")]
        public Control OutputControl { get => _outputControl; set => _outputControl = value; }

        [DefaultValue("O&pen"), Description("")]
        public string DefaultText { get => _defaultText; set => _defaultText = value; }

        [DefaultValue(null), Description("")]
        public string ApplicationName { get => _applicationName; set => _applicationName = value; }

        [DefaultValue("Open:"), Description("")]
        public string OpenFileDialogTitle { get => _openFileDialogTitle; set => _openFileDialogTitle = value; }

        [DefaultValue(null), Description("")]
        public string RawFilterDisplayName { get => _rawFilterDisplayName; set => _rawFilterDisplayName = value; }

        [DefaultValue(null), Description("")]
        public string RawExtensionList { get => _rawExtensionList; set => _rawExtensionList = value; }

        [DefaultValue(null), Description("")]
        public string StandardDialogFilter { get => _standardDialogFilter; set => _standardDialogFilter = value; }

        [DefaultValue(Environment.SpecialFolder.MyDocuments), Description("")]
        public string StartingDirectory { get => _startingDirectory; set => _startingDirectory = value; }

        [DefaultValue(null), Description("")]
        public MRUMenuItem ParentMruMenuItem { get => _parentMruMenuItem; set => _parentMruMenuItem = value; }

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
