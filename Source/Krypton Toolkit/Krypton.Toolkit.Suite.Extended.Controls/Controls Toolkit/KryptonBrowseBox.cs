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

        private string _resetTextToolTipHeading;

        private string _resetTextToolTipDescription;

        private Image _smallResetImage;

        private Image _largeResetImage;

        private KryptonCommand _kcBrowse;

        private KryptonCommand _kcReset;

        #endregion

        #region Public

        /// <summary>Gets or sets a value indicating whether [use save dialog].</summary>
        /// <value><c>true</c> if [use save dialog]; otherwise, <c>false</c>.</value>
        [DefaultValue(false), Description(@"Gets or sets a value indicating whether to use the 'CommonSaveFileDialog'.")]
        public bool UseSaveDialog { get => _useSaveDialog; set => _useSaveDialog = value; }

        /// <summary>Gets or sets a value indicating whether to show the reset button.</summary>
        /// <value><c>true</c> if [show reset button]; otherwise, <c>false</c>.</value>
        [DefaultValue(false), Description(@"Gets or sets a value indicating whether to show the reset button.")]
        public bool ShowResetButton { get => _showResetButton; set { _showResetButton = value; Invalidate(); } }

        /// <summary>Gets or sets a value indicating whether the open file dialog is a folder picker.</summary>
        /// <value><c>true</c> if the open file dialog is a folder picker; otherwise, <c>false</c>.</value>
        [DefaultValue(false), Description(@"Gets or sets a value indicating whether the open file dialog is a folder picker.")]
        public bool IsFolderPicker { get => _isFolderPicker; set => _isFolderPicker = value; }

        /// <summary>Gets or sets a value indicating whether the save file dialog is in expanded mode.</summary>
        /// <value><c>true</c> if the save file dialog is in expanded mode; otherwise, <c>false</c>.</value>
        [DefaultValue(false), Description(@"Gets or sets a value indicating whether the save file dialog is in expanded mode.")]
        public bool IsExpandedMode { get => _isExpandedMode; set => _isExpandedMode = value; }

        /// <summary>Gets or sets the file dialog filter. Please see <see cref="CommonFileDialogFilter"/> for more information.</summary>
        /// <value> The file dialog filter.</value>
        [DefaultValue(null), Description(@"Gets or sets the file dialog filter. Please see 'Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialogFilter' for more information.")]
        public CommonFileDialogFilter FileDialogFilter { get => _filter; set => _filter = value; }

        /// <summary>Gets or sets the file dialog filter collection. Please see <see cref="CommonFileDialogFilterCollection"/> for more information.</summary>
        /// <value>The file dialog filter collection.</value>
        [DefaultValue(null), Description(@"Gets or sets the file dialog filter collection. Please see 'Microsoft.WindowsAPICodePack.Dialogs.CommonFileDialogFilterCollection' for more information.")]
        public CommonFileDialogFilterCollection FileDialogFilterCollection { get => _filterCollection; set => _filterCollection = value; }

        /// <summary>Gets or sets the initial directory.</summary>
        /// <value>The initial directory.</value>
        [DefaultValue(null), Description(@"Gets or sets the initial directory.")]
        public string InitialDirectory { get => _initialDirectory; set => _initialDirectory = value; }

        /// <summary>Gets or sets the reset text.</summary>
        /// <value>The reset text.</value>
        [DefaultValue(@"&Reset"), Description(@"Gets or sets the reset text.")]
        public string ResetText { get => _resetText; set { _resetText = value; Invalidate(); } }

        /// <summary>Gets or sets the reset text tool tip heading.</summary>
        /// <value>The reset text tool tip heading.</value>
        [DefaultValue(@"Reset"), Description(@"Gets or sets the reset text tool tip heading.")]
        public string ResetTextToolTipHeading { get => _resetTextToolTipHeading; set => _resetTextToolTipHeading = value; }

        /// <summary>Gets or sets the reset text tool tip description.</summary>
        /// <value>The reset text tool tip description.</value>
        [DefaultValue(@"Resets the text of the text box."), Description(@">Gets or sets the reset text tool tip description.")]
        public string ResetTextToolTipDescription { get => _resetTextToolTipDescription; set => _resetTextToolTipDescription = value; }

        /// <summary>Gets or sets the small reset image.</summary>
        /// <value>The small reset image.</value>
        [DefaultValue(typeof(Image), @"Properties.Resources.Reset_16_x_16"), Description(@"Gets or sets the small reset image.")]
        public Image SmallResetImage { get => _smallResetImage; set => _smallResetImage = value; }

        /// <summary>Gets or sets the large reset image.</summary>
        /// <value>The large reset image.</value>
        [DefaultValue(typeof(Image), @"Properties.Resources.Reset_32_x_32"), Description(@"Gets or sets the large reset image.")]
        public Image LargeResetImage { get => _largeResetImage; set => _largeResetImage = value; }

        #endregion

        #region Identity

        /// <summary>Initializes a new instance of the <see cref="KryptonBrowseBox" /> class.</summary>
        public KryptonBrowseBox()
        {
            _bsaBrowse = new ButtonSpecAny();

            _bsaReset = new ButtonSpecAny();

            _kcBrowse = new KryptonCommand();

            _kcReset = new KryptonCommand();

            _smallResetImage = Properties.Resources.Reset_16_x_16;

            _largeResetImage = Properties.Resources.Reset_32_x_32;

            _bsaBrowse.Text = "...";

            _bsaBrowse.KryptonCommand = _kcBrowse;

            _kcBrowse.Text = "...";

            _bsaReset.ToolTipImage = _smallResetImage;

            _bsaReset.ToolTipBody = _resetTextToolTipDescription;

            _bsaReset.ToolTipTitle = _resetTextToolTipHeading;

            _bsaReset.Text = _resetText;

            _bsaReset.Image = _smallResetImage;

            _bsaReset.KryptonCommand = _kcReset;

            _kcReset.Text = _resetText;

            _bsaReset.Enabled = ButtonEnabled.False;
            
            _kcBrowse.Execute += Browse_Execute;

            _kcReset.ImageLarge = _largeResetImage;

            _kcReset.ImageSmall = _smallResetImage;

            _kcReset.Execute += Reset_Execute;

            ButtonSpecs.AddRange(new [] { _bsaBrowse, _bsaReset });
        }

        #endregion

        #region Implementation

        /// <summary>Handles the Execute event of the Browse control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
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

        /// <summary>Handles the Execute event of the Reset control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
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

        /// <summary>Raises the Paint event.</summary>
        /// <param name="e">A PaintEventArgs containing the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            _bsaReset.Visible = _showResetButton;

            base.OnPaint(e);
        }

        /// <summary>Raises the <see cref="E:System.Windows.Forms.Control.TextChanged">TextChanged</see> event.</summary>
        /// <param name="e">An <see cref="T:System.EventArgs">EventArgs</see> that contains the event data.</param>
        protected override void OnTextChanged(EventArgs e)
        {
            if (!string.IsNullOrEmpty(Text))
            {
                _bsaReset.Enabled = ButtonEnabled.True;
            }
            else
            {
                _bsaReset.Enabled =ButtonEnabled.False;
            }

            base.OnTextChanged(e);
        }

        #endregion
    }
}
