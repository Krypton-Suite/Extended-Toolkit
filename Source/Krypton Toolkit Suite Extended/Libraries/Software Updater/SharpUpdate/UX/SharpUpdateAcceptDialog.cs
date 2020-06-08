using Krypton.Toolkit.Extended.Common;
using Krypton.Toolkit.Extended.Software.Updater.SharpUpdate.Language;
using System;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Software.Updater.SharpUpdate
{
    public class SharpUpdateAcceptDialog : KryptonForm
    {
        #region Designer Code
        private KryptonPanel kryptonPanel1;
        private KryptonLabel klblpdateAvail;
        private KryptonLabel klblNewVersion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Base.KryptonYesDialogButton kbtnYes;
        private Base.KryptonNODialogButton kbtnNo;
        private KryptonButton kbtnDetails;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.klblpdateAvail = new Krypton.Toolkit.KryptonLabel();
            this.klblNewVersion = new Krypton.Toolkit.KryptonLabel();
            this.kbtnDetails = new Krypton.Toolkit.KryptonButton();
            this.kbtnNo = new Krypton.Toolkit.Extended.Base.KryptonNODialogButton();
            this.kbtnYes = new Krypton.Toolkit.Extended.Base.KryptonYesDialogButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnYes);
            this.kryptonPanel1.Controls.Add(this.kbtnNo);
            this.kryptonPanel1.Controls.Add(this.pictureBox1);
            this.kryptonPanel1.Controls.Add(this.klblpdateAvail);
            this.kryptonPanel1.Controls.Add(this.klblNewVersion);
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
            // kbtnNo
            // 
            this.kbtnNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.kbtnNo.Location = new System.Drawing.Point(206, 106);
            this.kbtnNo.Name = "kbtnNo";
            this.kbtnNo.ParentWindow = this;
            this.kbtnNo.Size = new System.Drawing.Size(90, 25);
            this.kbtnNo.TabIndex = 5;
            this.kbtnNo.Values.Text = "&No";
            // 
            // kbtnYes
            // 
            this.kbtnYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.kbtnYes.Location = new System.Drawing.Point(110, 106);
            this.kbtnYes.Name = "kbtnYes";
            this.kbtnYes.ParentWindow = this;
            this.kbtnYes.Size = new System.Drawing.Size(90, 25);
            this.kbtnYes.TabIndex = 1;
            this.kbtnYes.Values.Text = "&Yes";
            // 
            // SharpUpdateAcceptDialog
            // 
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