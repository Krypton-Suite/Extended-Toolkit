using Krypton.Toolkit.Suite.Extended.Base;
using Krypton.Toolkit.Suite.Extended.IO;
using Krypton.Toolkit.Suite.Extended.Settings;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    /// <summary>Allows you to find &amp; highlight selected text within a specified <seealso cref="KryptonRichTextBox" />.</summary>
    public class KryptonTextFinderDialog : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private System.Windows.Forms.Panel panel1;
        private KryptonButton kryptonButton1;
        private KryptonPanel kryptonPanel2;
        private KryptonButton kbtnCountOccurrences;
        private KryptonColorButton kryptonColorButton1;
        private KryptonLabel kryptonLabel1;
        private KryptonTextBox ktxtSearchTerm;
        private Base.KryptonSplitButton ksbFindOptions;
        private KryptonButton kbtnCancel;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kryptonButton1 = new Krypton.Toolkit.KryptonButton();
            this.kbtnCancel = new Krypton.Toolkit.KryptonButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.ksbFindOptions = new Krypton.Toolkit.Suite.Extended.Base.KryptonSplitButton();
            this.kbtnCountOccurrences = new Krypton.Toolkit.KryptonButton();
            this.kryptonColorButton1 = new Krypton.Toolkit.KryptonColorButton();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.ktxtSearchTerm = new Krypton.Toolkit.KryptonTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonButton1);
            this.kryptonPanel1.Controls.Add(this.kbtnCancel);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 146);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(504, 45);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kryptonButton1.Location = new System.Drawing.Point(207, 10);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(90, 25);
            this.kryptonButton1.TabIndex = 1;
            this.kryptonButton1.Values.Text = "C&ancel";
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Location = new System.Drawing.Point(544, 8);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.TabIndex = 0;
            this.kbtnCancel.Values.Text = "C&ancel";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 143);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(504, 3);
            this.panel1.TabIndex = 2;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.ksbFindOptions);
            this.kryptonPanel2.Controls.Add(this.kbtnCountOccurrences);
            this.kryptonPanel2.Controls.Add(this.kryptonColorButton1);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Controls.Add(this.ktxtSearchTerm);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(504, 143);
            this.kryptonPanel2.TabIndex = 3;
            // 
            // ksbFindOptions
            // 
            this.ksbFindOptions.AutoSize = true;
            this.ksbFindOptions.CornerRadius = -1;
            this.ksbFindOptions.Image = null;
            this.ksbFindOptions.Location = new System.Drawing.Point(360, 105);
            this.ksbFindOptions.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ksbFindOptions.Name = "ksbFindOptions";
            this.ksbFindOptions.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ksbFindOptions.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ksbFindOptions.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.ksbFindOptions.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.ksbFindOptions.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.ksbFindOptions.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.ksbFindOptions.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.ksbFindOptions.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.ksbFindOptions.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.ksbFindOptions.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.ksbFindOptions.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ksbFindOptions.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ksbFindOptions.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.ksbFindOptions.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.ksbFindOptions.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.ksbFindOptions.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.ksbFindOptions.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.ksbFindOptions.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.ksbFindOptions.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.ksbFindOptions.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.ksbFindOptions.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ksbFindOptions.ShowSplitOption = true;
            this.ksbFindOptions.Size = new System.Drawing.Size(131, 25);
            this.ksbFindOptions.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ksbFindOptions.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ksbFindOptions.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.ksbFindOptions.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.ksbFindOptions.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.ksbFindOptions.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.ksbFindOptions.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.ksbFindOptions.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.ksbFindOptions.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.ksbFindOptions.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.ksbFindOptions.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ksbFindOptions.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ksbFindOptions.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.ksbFindOptions.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.ksbFindOptions.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.ksbFindOptions.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.ksbFindOptions.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.ksbFindOptions.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.ksbFindOptions.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.ksbFindOptions.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.ksbFindOptions.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ksbFindOptions.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ksbFindOptions.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.ksbFindOptions.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.ksbFindOptions.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.ksbFindOptions.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.ksbFindOptions.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.ksbFindOptions.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.ksbFindOptions.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.ksbFindOptions.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.ksbFindOptions.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ksbFindOptions.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ksbFindOptions.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.ksbFindOptions.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.ksbFindOptions.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.ksbFindOptions.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.ksbFindOptions.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.ksbFindOptions.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.ksbFindOptions.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.ksbFindOptions.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.ksbFindOptions.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ksbFindOptions.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ksbFindOptions.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.ksbFindOptions.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.ksbFindOptions.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.ksbFindOptions.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.ksbFindOptions.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.ksbFindOptions.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.ksbFindOptions.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.ksbFindOptions.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.ksbFindOptions.TabIndex = 4;
            this.ksbFindOptions.Values.Text = "&Find....";
            this.ksbFindOptions.Click += new System.EventHandler(this.ksbFindOptions_Click);
            // 
            // kbtnCountOccurrences
            // 
            this.kbtnCountOccurrences.Location = new System.Drawing.Point(215, 105);
            this.kbtnCountOccurrences.Name = "kbtnCountOccurrences";
            this.kbtnCountOccurrences.Size = new System.Drawing.Size(138, 25);
            this.kbtnCountOccurrences.TabIndex = 3;
            this.kbtnCountOccurrences.Values.Text = "Count &Occurrences";
            this.kbtnCountOccurrences.Click += new System.EventHandler(this.kbtnCountOccurrences_Click);
            // 
            // kryptonColorButton1
            // 
            this.kryptonColorButton1.Location = new System.Drawing.Point(13, 105);
            this.kryptonColorButton1.Name = "kryptonColorButton1";
            this.kryptonColorButton1.Size = new System.Drawing.Size(196, 25);
            this.kryptonColorButton1.TabIndex = 2;
            this.kryptonColorButton1.Values.Text = "Select a &Highlight Colour";
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(13, 24);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(36, 20);
            this.kryptonLabel1.TabIndex = 1;
            this.kryptonLabel1.Values.Text = "Find:";
            // 
            // ktxtSearchTerm
            // 
            this.ktxtSearchTerm.Location = new System.Drawing.Point(55, 24);
            this.ktxtSearchTerm.Name = "ktxtSearchTerm";
            this.ktxtSearchTerm.Size = new System.Drawing.Size(437, 23);
            this.ktxtSearchTerm.TabIndex = 0;
            this.ktxtSearchTerm.Text = "kryptonTextBox1";
            // 
            // KryptonTextFinderDialog
            // 
            this.ClientSize = new System.Drawing.Size(504, 191);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonTextFinderDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private Color _highlighterColour = Color.Empty;

        private TextFinderDialogSettingsManager _textFinderDialogSettingsManager = new TextFinderDialogSettingsManager();

        private string _defaultWatermark;

        private KryptonRichTextBox _target;
        #endregion

        #region Properties
        [DefaultValue("Color.Yellow")]
        public Color HighlighterColour { get => _highlighterColour; set => _highlighterColour = value; }

        /// <summary>Gets or sets the default watermark text.</summary>
        /// <value>The default watermark text.</value>
        [DefaultValue("Enter a search term here...")]
        public string DefaultWatermark { get => _defaultWatermark; set { _defaultWatermark = value; Invalidate(); } }

        /// <summary>Gets or sets the target <see cref="KryptonRichTextBox" />.</summary>
        /// <value>The target <see cref="KryptonRichTextBox" />.</value>
        public KryptonRichTextBox Target { get => _target; set => _target = value; }
        #endregion

        #region Constructor
        public KryptonTextFinderDialog(KryptonRichTextBox target, string defaultWatermark = "")
        {
            InitializeComponent();

            Target = target;

            if (defaultWatermark == null || defaultWatermark == "" || defaultWatermark == string.Empty)
            {
                DefaultWatermark = "Enter a search term here...";
            }
            else
            {
                DefaultWatermark = defaultWatermark;
            }

            SetUp(Target, DefaultWatermark);
        }
        #endregion

        #region Methods
        /// <summary>Sets up the UI.</summary>
        /// <param name="target">The target <see cref="KryptonRichTextBox" />.</param>
        /// <param name="defaultWatermark">The default watermark.</param>
        private void SetUp(KryptonRichTextBox target, string defaultWatermark = "")
        {
            _textFinderDialogSettingsManager.SetDefaultTextMask(defaultWatermark);

            _textFinderDialogSettingsManager.SaveTextFinderDialogSettings();
        }

        /// <summary>Changes the text highlighter colour.</summary>
        /// <param name="highlighterColour">The highlighter colour.</param>
        public void ChangeTextHighlighterColour(Color highlighterColour)
        {
            if (highlighterColour == Color.Empty || highlighterColour == Color.Transparent || highlighterColour == null)
            {
                KryptonMessageBoxExtended.Show("Sorry, the colour you have chosen is not supported. Please try again.", "Unsupported Colour", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Default to yellow
                _textFinderDialogSettingsManager.SetTextHighlighterColour(Color.Yellow);
            }
            else
            {
                _textFinderDialogSettingsManager.SetTextHighlighterColour(highlighterColour);
            }

            _textFinderDialogSettingsManager.SaveTextFinderDialogSettings();
        }
        #endregion

        #region Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            if (!string.IsNullOrEmpty(_textFinderDialogSettingsManager.GetDefaultTextMask()))
            {
                ktxtSearchTerm.Hint = _textFinderDialogSettingsManager.GetDefaultTextMask();
            }
            else if (!string.IsNullOrEmpty(_defaultWatermark))
            {
                ktxtSearchTerm.Hint = _defaultWatermark;
            }
            else
            {
                ktxtSearchTerm.Hint = "Enter a search term here...";
            }

            base.OnPaint(e);
        }
        #endregion

        private void ksbFindOptions_Click(object sender, EventArgs e)
        {
            TextUtilities.SearchForWord(ktxtSearchTerm.Text, Target, HighlighterColour);
        }

        private void kbtnCountOccurrences_Click(object sender, EventArgs e)
        {
            KryptonMessageBoxExtended.Show($"The number of the word: '{ ktxtSearchTerm.Text }' is: { TextUtilities.CountOccurrencesOfWord(Target.Text, ktxtSearchTerm.Text) }.", "Count Word Occurrences", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}