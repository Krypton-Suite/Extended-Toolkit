using Krypton.Toolkit.Extended.Colour.Controls;
using System.ComponentModel;
using System.Drawing;

namespace Krypton.Toolkit.Extended.Dialogs
{
    [DefaultEvent("ColourChanged"), DefaultProperty("Colour")]
    public class KryptonPaletteColourMixerBasic : KryptonForm
    {
        #region Design Code
        private KryptonPanel kpnlButtons;
        private KryptonOKDialogButton kbtnOk;
        private System.Windows.Forms.Panel panel1;
        private KryptonPanel kryptonPanel1;
        private Base.CircularPictureBox cpbColourPreview;
        private Colour.Controls.KryptonRGBColourSliderHorizontal krgbcsColour;
        private KryptonCancelDialogButton kbtnCancel;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KryptonPaletteColourMixerBasic));
            this.kpnlButtons = new Krypton.Toolkit.KryptonPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.cpbColourPreview = new Krypton.Toolkit.Extended.Base.CircularPictureBox();
            this.krgbcsColour = new Krypton.Toolkit.Extended.Colour.Controls.KryptonRGBColourSliderHorizontal();
            this.kbtnOk = new Krypton.Toolkit.Extended.Dialogs.KryptonOKDialogButton();
            this.kbtnCancel = new Krypton.Toolkit.Extended.Dialogs.KryptonCancelDialogButton();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlButtons)).BeginInit();
            this.kpnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpbColourPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // kpnlButtons
            // 
            this.kpnlButtons.Controls.Add(this.kbtnOk);
            this.kpnlButtons.Controls.Add(this.kbtnCancel);
            this.kpnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kpnlButtons.Location = new System.Drawing.Point(0, 217);
            this.kpnlButtons.Name = "kpnlButtons";
            this.kpnlButtons.Size = new System.Drawing.Size(629, 44);
            this.kpnlButtons.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 214);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 3);
            this.panel1.TabIndex = 6;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.krgbcsColour);
            this.kryptonPanel1.Controls.Add(this.cpbColourPreview);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(629, 214);
            this.kryptonPanel1.TabIndex = 7;
            // 
            // cpbColourPreview
            // 
            this.cpbColourPreview.BackColor = System.Drawing.SystemColors.Control;
            this.cpbColourPreview.Location = new System.Drawing.Point(12, 12);
            this.cpbColourPreview.Name = "cpbColourPreview";
            this.cpbColourPreview.Size = new System.Drawing.Size(196, 196);
            this.cpbColourPreview.TabIndex = 8;
            this.cpbColourPreview.TabStop = false;
            this.cpbColourPreview.ToolTipValues = null;
            // 
            // krgbcsColour
            // 
            this.krgbcsColour.BackColor = System.Drawing.Color.Transparent;
            this.krgbcsColour.Colour = System.Drawing.Color.Empty;
            this.krgbcsColour.Location = new System.Drawing.Point(214, 12);
            this.krgbcsColour.Name = "krgbcsColour";
            this.krgbcsColour.Size = new System.Drawing.Size(403, 189);
            this.krgbcsColour.TabIndex = 9;
            this.krgbcsColour.ColourChanged += new Krypton.Toolkit.Extended.Colour.Controls.KryptonRGBColourSliderHorizontal.ColourChangedEventHandler(this.krgbcsColour_ColourChanged);
            // 
            // kbtnOk
            // 
            this.kbtnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnOk.Image = null;
            this.kbtnOk.Location = new System.Drawing.Point(431, 7);
            this.kbtnOk.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.Size = new System.Drawing.Size(90, 25);
            this.kbtnOk.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnOk.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnOk.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnOk.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnOk.TabIndex = 2;
            this.kbtnOk.Values.Text = "&OK";
            // 
            // kbtnCancel
            // 
            this.kbtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.kbtnCancel.Image = null;
            this.kbtnCancel.Location = new System.Drawing.Point(527, 7);
            this.kbtnCancel.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.Name = "kbtnCancel";
            this.kbtnCancel.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.Size = new System.Drawing.Size(90, 25);
            this.kbtnCancel.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnCancel.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kbtnCancel.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnCancel.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnCancel.TabIndex = 2;
            this.kbtnCancel.Values.Text = "C&ancel";
            // 
            // KryptonPaletteColourMixerBasic
            // 
            this.ClientSize = new System.Drawing.Size(629, 261);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kpnlButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonPaletteColourMixerBasic";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Basic Colour Mixer";
            ((System.ComponentModel.ISupportInitialize)(this.kpnlButtons)).EndInit();
            this.kpnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cpbColourPreview)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variable
        private Color _colour;
        #endregion

        #region Properties
        public Color Colour
        {
            get => _colour;

            set
            {
                _colour = value;

                ColourChangedEventArgs e = new ColourChangedEventArgs(value);

                OnColourChanged(this, e);
            }
        }
        #endregion

        #region Event
        public delegate void ColourChangedEventHandler(object sender, ColourChangedEventArgs e);

        public event ColourChangedEventHandler ColourChanged;

        protected virtual void OnColourChanged(object sender, ColourChangedEventArgs e) => ColourChanged?.Invoke(sender, e);
        #endregion

        #region Constructor
        public KryptonPaletteColourMixerBasic()
        {
            InitializeComponent();
        }
        #endregion

        private void krgbcsColour_ColourChanged(object sender, ColourChangedEventArgs e)
        {
            UpdateColour(e.Colour);
        }

        private void UpdateColour(Color colour) => cpbColourPreview.BackColor = colour;
    }
}