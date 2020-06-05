using Krypton.Toolkit.Extended.Software.Updater.SharpUpdate.Language;
using System;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Software.Updater.SharpUpdate
{
    public class SharpUpdateAcceptDialog : KryptonForm
    {
        #region Designer Code
        private KryptonPanel kryptonPanel1;
        private Dialogs.KryptonNODialogButton kbtnNo;
        private Dialogs.KryptonYesDialogButton kbtnYes;
        private KryptonLabel klblpdateAvail;
        private KryptonLabel klblNewVersion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private KryptonButton kbtnDetails;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.klblpdateAvail = new Krypton.Toolkit.KryptonLabel();
            this.klblNewVersion = new Krypton.Toolkit.KryptonLabel();
            this.kbtnNo = new Krypton.Toolkit.Extended.Dialogs.KryptonNODialogButton();
            this.kbtnYes = new Krypton.Toolkit.Extended.Dialogs.KryptonYesDialogButton();
            this.kbtnDetails = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.pictureBox1);
            this.kryptonPanel1.Controls.Add(this.klblpdateAvail);
            this.kryptonPanel1.Controls.Add(this.klblNewVersion);
            this.kryptonPanel1.Controls.Add(this.kbtnNo);
            this.kryptonPanel1.Controls.Add(this.kbtnYes);
            this.kryptonPanel1.Controls.Add(this.kbtnDetails);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(404, 143);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Krypton.Toolkit.Extended.Software.Updater.Properties.Resources.update2;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // klblpdateAvail
            // 
            this.klblpdateAvail.AutoSize = false;
            this.klblpdateAvail.Location = new System.Drawing.Point(110, 12);
            this.klblpdateAvail.Name = "klblpdateAvail";
            this.klblpdateAvail.Size = new System.Drawing.Size(282, 50);
            this.klblpdateAvail.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblpdateAvail.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblpdateAvail.TabIndex = 1;
            this.klblpdateAvail.Values.Text = "An update is available!\r\nWould you like to update?\r\n";
            // 
            // klblNewVersion
            // 
            this.klblNewVersion.AutoSize = false;
            this.klblNewVersion.Location = new System.Drawing.Point(110, 68);
            this.klblNewVersion.Name = "klblNewVersion";
            this.klblNewVersion.Size = new System.Drawing.Size(282, 25);
            this.klblNewVersion.StateCommon.ShortText.TextH = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblNewVersion.TabIndex = 2;
            this.klblNewVersion.Values.Text = "";
            // 
            // kbtnNo
            // 
            this.kbtnNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.kbtnNo.Image = null;
            this.kbtnNo.Location = new System.Drawing.Point(206, 106);
            this.kbtnNo.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnNo.Name = "kbtnNo";
            this.kbtnNo.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnNo.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnNo.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnNo.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnNo.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnNo.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnNo.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnNo.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnNo.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnNo.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnNo.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnNo.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnNo.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnNo.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnNo.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnNo.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnNo.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnNo.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnNo.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnNo.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnNo.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnNo.Size = new System.Drawing.Size(90, 25);
            this.kbtnNo.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnNo.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnNo.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnNo.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnNo.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnNo.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnNo.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnNo.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnNo.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnNo.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnNo.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnNo.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnNo.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnNo.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnNo.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnNo.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnNo.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnNo.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnNo.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnNo.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnNo.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnNo.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnNo.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnNo.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnNo.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnNo.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnNo.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnNo.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnNo.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnNo.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnNo.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnNo.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnNo.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnNo.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnNo.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnNo.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnNo.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnNo.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnNo.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnNo.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnNo.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnNo.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnNo.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnNo.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnNo.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnNo.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnNo.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnNo.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnNo.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnNo.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnNo.TabIndex = 2;
            this.kbtnNo.Values.Text = "&No";
            this.kbtnNo.Click += new System.EventHandler(this.kbtnNo_Click);
            // 
            // kbtnYes
            // 
            this.kbtnYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.kbtnYes.Image = null;
            this.kbtnYes.Location = new System.Drawing.Point(110, 106);
            this.kbtnYes.LongTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnYes.Name = "kbtnYes";
            this.kbtnYes.OverrideDefault.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnYes.OverrideDefault.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnYes.OverrideDefaultBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnYes.OverrideDefaultBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnYes.OverrideDefaultBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnYes.OverrideDefaultBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnYes.OverrideDefaultLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnYes.OverrideDefaultLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnYes.OverrideDefaultShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnYes.OverrideDefaultShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnYes.OverrideFocus.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnYes.OverrideFocus.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnYes.OverrideFocusBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnYes.OverrideFocusBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnYes.OverrideFocusBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnYes.OverrideFocusBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnYes.OverrideFocusLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnYes.OverrideFocusLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnYes.OverrideFocusShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnYes.OverrideFocusShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnYes.ShortTextTypeface = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnYes.Size = new System.Drawing.Size(90, 25);
            this.kbtnYes.StateCommon.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnYes.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnYes.StateCommonBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnYes.StateCommonBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnYes.StateCommonBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnYes.StateCommonBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnYes.StateCommonLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnYes.StateCommonLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnYes.StateCommonShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnYes.StateCommonShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnYes.StateDisabled.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnYes.StateDisabled.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnYes.StateDisabledBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnYes.StateDisabledBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnYes.StateDisabledBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnYes.StateDisabledBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnYes.StateDisabledLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnYes.StateDisabledLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnYes.StateDisabledShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnYes.StateDisabledShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnYes.StateNormal.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnYes.StateNormal.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnYes.StateNormalBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnYes.StateNormalBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnYes.StateNormalBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnYes.StateNormalBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnYes.StateNormalLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnYes.StateNormalLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnYes.StateNormalShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnYes.StateNormalShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnYes.StatePressed.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnYes.StatePressed.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnYes.StatePressedBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnYes.StatePressedBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnYes.StatePressedBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnYes.StatePressedBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnYes.StatePressedLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnYes.StatePressedLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnYes.StatePressedShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnYes.StatePressedShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnYes.StateTracking.Content.LongText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnYes.StateTracking.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.kbtnYes.StateTrackingBackGroundColourOne = System.Drawing.Color.Empty;
            this.kbtnYes.StateTrackingBackGroundColourTwo = System.Drawing.Color.Empty;
            this.kbtnYes.StateTrackingBorderColourOne = System.Drawing.Color.Empty;
            this.kbtnYes.StateTrackingBorderColourTwo = System.Drawing.Color.Empty;
            this.kbtnYes.StateTrackingLongTextColourOne = System.Drawing.Color.Empty;
            this.kbtnYes.StateTrackingLongTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnYes.StateTrackingShortTextColourOne = System.Drawing.Color.Empty;
            this.kbtnYes.StateTrackingShortTextColourTwo = System.Drawing.Color.Empty;
            this.kbtnYes.TabIndex = 3;
            this.kbtnYes.Values.Text = "&Yes";
            this.kbtnYes.Click += new System.EventHandler(this.kbtnYes_Click);
            // 
            // kbtnDetails
            // 
            this.kbtnDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kbtnDetails.Location = new System.Drawing.Point(302, 106);
            this.kbtnDetails.Name = "kbtnDetails";
            this.kbtnDetails.Size = new System.Drawing.Size(90, 25);
            this.kbtnDetails.TabIndex = 1;
            this.kbtnDetails.Values.Text = "&Details...";
            this.kbtnDetails.Click += new System.EventHandler(this.kbtnDetails_Click);
            // 
            // SharpUpdateAcceptDialog
            // 
            this.AcceptButton = this.kbtnYes;
            this.CancelButton = this.kbtnNo;
            this.ClientSize = new System.Drawing.Size(404, 143);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SharpUpdateAcceptDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.SharpUpdateAcceptDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        /// <summary>
        /// The program to update's info
        /// </summary>
        private ISharpUpdatable _applicationInfo;

        /// <summary>
        /// The update info from the update.xml
        /// </summary>
        private SharpUpdateXML _updateInfo;

        /// <summary>
        /// The update info display form
        /// </summary>
        private SharpUpdateInfoDialog _updateInfoForm;
        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="SharpUpdateAcceptDialog" /> class.</summary>
        /// <param name="applicationInfo">The application information.</param>
        /// <param name="updateInfo">The update information.</param>
        internal SharpUpdateAcceptDialog(ISharpUpdatable applicationInfo, SharpUpdateXML updateInfo)
        {
            InitializeComponent();

            try
            {
                _applicationInfo = applicationInfo;

                _updateInfo = updateInfo;

                Text = LanguageEN.SharpUpdateAcceptForm_Title;

                klblpdateAvail.Text = LanguageEN.SharpUpdateAcceptForm_lblUpdateAvail;

                klblNewVersion.Text = string.Format(LanguageEN.SharpUpdateAcceptForm_lblNewVersion, _updateInfo.Version.ToString());

                kbtnYes.Text = LanguageEN.SharpUpdateAcceptForm_btnYes;

                kbtnNo.Text = LanguageEN.SharpUpdateAcceptForm_btnNo;

                kbtnDetails.Text = LanguageEN.SharpUpdateAcceptForm_btnDetails;
            }
            catch (Exception e)
            {
                ExceptionHandler.CaptureException(e);
            }

            if (applicationInfo.ApplicationIcon != null) Icon = applicationInfo.ApplicationIcon;
        }
        #endregion

        private void SharpUpdateAcceptDialog_Load(object sender, EventArgs e)
        {

        }

        private void kbtnYes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;

            Close();
        }

        private void kbtnNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;

            Close();
        }

        private void kbtnDetails_Click(object sender, EventArgs e)
        {
            if (_updateInfoForm == null) _updateInfoForm = new SharpUpdateInfoDialog(_applicationInfo, _updateInfo);

            _updateInfoForm.Show(this);
        }
    }
}