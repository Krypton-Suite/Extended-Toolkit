#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Controls
{
    /// <summary>Allows the user to browse for files.</summary>
    [ToolboxBitmap(typeof(KryptonTextBox)), Description(@"Allows the user to browse for files.")]
    public class KryptonBrowseBox : KryptonTextBox
    {
        #region Instance Fields

        private bool _useSaveDialog;

        private bool _showResetButton;

        private bool _isFolderPicker;

        private bool _isExpandedMode;

        private ButtonSpecAny _bsaBrowse;

        private ButtonSpecAny _bsaReset;

        private CommonFileDialogFilter _filter;

        private CommonFileDialogFilterCollection _filterCollection;

        private string _initialDirectory;

        private string _resetText;

        private KryptonCommand _kcBrowse;

        private KryptonCommand _kcReset;

        #endregion

        #region Public

        /// <summary>Gets or sets a value indicating whether [use save dialog].</summary>
        /// <value><c>true</c> if [use save dialog]; otherwise, <c>false</c>.</value>
        [DefaultValue(false), Description(@"Gets or sets a value indicating whether to use the 'CommonSaveFileDialog'.")]
        public bool UseSaveDialog { get => _useSaveDialog; set => _useSaveDialog = value; }

        public bool ShowResetButton { get => _showResetButton; set { _showResetButton = value; Invalidate(); } }

        public bool IsFolderPicker { get => _isFolderPicker; set => _isFolderPicker = value; }

        public bool IsExpandedMode { get => _isExpandedMode; set => _isExpandedMode = value; }

        /// <summary>Gets or sets the file dialog filter. Please see <see cref="CommonFileDialogFilter"/> for more information.</summary>
        /// <value> The file dialog filter.</value>
        [DefaultValue(null), Description(@"Gets or sets the file dialog filter. Please see 'Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialogFilter' for more information.")]
        public CommonFileDialogFilter FileDialogFilter
        {
            get => _filter;

            set => _filter = value;
        }

        /// <summary>Gets or sets the file dialog filter collection. Please see <see cref="CommonFileDialogFilterCollection"/> for more information.</summary>
        /// <value>The file dialog filter collection.</value>
        [DefaultValue(null), Description(@"Gets or sets the file dialog filter collection. Please see 'Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialogFilterCollection' for more information.")]
        public CommonFileDialogFilterCollection FileDialogFilterCollection
        {
            get => _filterCollection;

            set => _filterCollection = value;
        }

        public string InitialDirectory { get => _initialDirectory; set => _initialDirectory = value; }

        [DefaultValue(@"&Reset")]
        public string ResetText { get => _resetText; set { _resetText = value; Invalidate(); } }

        #endregion

        #region Identity

        public KryptonBrowseBox()
        {
            _bsaBrowse = new ButtonSpecAny();

            _bsaReset = new ButtonSpecAny();

            _kcBrowse = new KryptonCommand();

            _kcReset = new KryptonCommand();

            _bsaBrowse.Text = "...";

            _bsaBrowse.KryptonCommand = _kcBrowse;

            _kcBrowse.Text = "...";

            //_bsaReset.Image 

            _bsaReset.KryptonCommand = _kcReset;
            
            _kcBrowse.Execute += Browse_Execute;

            //_kcReset.ImageLarge

            //_kcReset.ImageSmall

            _kcReset.Execute += Reset_Execute;

            ButtonSpecs.AddRange(new [] { _bsaBrowse, _bsaReset });
        }

        #endregion

        #region Implementation

        private void Browse_Execute(object sender, EventArgs e)
        {
            if (_useSaveDialog)
            {
                CommonSaveFileDialog saveFileDialog = new CommonSaveFileDialog();

                saveFileDialog.IsExpandedMode = _isExpandedMode;

                if (!string.IsNullOrEmpty(_initialDirectory))
                {
                    saveFileDialog.InitialDirectory = _initialDirectory;
                }

                if (_filter != null)
                {
                    saveFileDialog.Filters.Add(_filter);
                }

                if (saveFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    Text = Path.GetFullPath(saveFileDialog.FileName);
                }
            }
            else
            {
                CommonOpenFileDialog dialog = new CommonOpenFileDialog();

                dialog.IsFolderPicker = _isFolderPicker;

                if (!string.IsNullOrEmpty(_initialDirectory))
                {
                    dialog.InitialDirectory = _initialDirectory;
                }

                if (_filter != null)
                {
                    dialog.Filters.Add(_filter);
                }

                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    Text = Path.GetFullPath(dialog.FileName);
                }
            }
        }

        private void Reset_Execute(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Text))
            {
                Text = string.Empty;

                _bsaReset.Enabled = ButtonEnabled.False;
            }
        }

        #endregion

        #region Protected

        protected override void OnPaint(PaintEventArgs e)
        {
            _bsaReset.Visible = _showResetButton;

            base.OnPaint(e);
        }

        #endregion
    }
}
