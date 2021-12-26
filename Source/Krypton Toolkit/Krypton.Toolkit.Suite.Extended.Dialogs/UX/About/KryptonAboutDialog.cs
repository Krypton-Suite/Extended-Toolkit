#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Effects;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    public class KryptonAboutDialog : CommonExtendedKryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private KryptonLabel klblApplicationVersion;
        private KryptonLabel klblApplicationName;
        private System.Windows.Forms.PictureBox pbxApplicationIcon;
        private KryptonButton kbtnOk;
        private KryptonRichTextBox krtbMoreDetails;
        private KryptonLabel klblCopyright;
        private KryptonButton kbtnSystemInformation;
        private KryptonLabel klblFrameworkVersion;
        private KryptonBorderEdge kryptonBorderEdge1;
        private KryptonPanel kryptonPanel2;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnSystemInformation = new Krypton.Toolkit.KryptonButton();
            this.kbtnOk = new Krypton.Toolkit.KryptonButton();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.klblFrameworkVersion = new Krypton.Toolkit.KryptonLabel();
            this.krtbMoreDetails = new Krypton.Toolkit.KryptonRichTextBox();
            this.klblCopyright = new Krypton.Toolkit.KryptonLabel();
            this.klblApplicationVersion = new Krypton.Toolkit.KryptonLabel();
            this.klblApplicationName = new Krypton.Toolkit.KryptonLabel();
            this.pbxApplicationIcon = new System.Windows.Forms.PictureBox();
            this.kryptonBorderEdge1 = new Krypton.Toolkit.KryptonBorderEdge();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxApplicationIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kryptonBorderEdge1);
            this.kryptonPanel1.Controls.Add(this.kbtnSystemInformation);
            this.kryptonPanel1.Controls.Add(this.kbtnOk);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 339);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(622, 46);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnSystemInformation
            // 
            this.kbtnSystemInformation.Location = new System.Drawing.Point(12, 9);
            this.kbtnSystemInformation.Name = "kbtnSystemInformation";
            this.kbtnSystemInformation.Size = new System.Drawing.Size(128, 25);
            this.kbtnSystemInformation.TabIndex = 1;
            this.kbtnSystemInformation.Values.Text = "System &Information";
            this.kbtnSystemInformation.Visible = false;
            this.kbtnSystemInformation.Click += new System.EventHandler(this.kbtnSystemInformation_Click);
            // 
            // kbtnOk
            // 
            this.kbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnOk.Location = new System.Drawing.Point(520, 9);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new System.Drawing.Size(90, 25);
            this.kbtnOk.TabIndex = 0;
            this.kbtnOk.Values.Text = "&Ok";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.klblFrameworkVersion);
            this.kryptonPanel2.Controls.Add(this.krtbMoreDetails);
            this.kryptonPanel2.Controls.Add(this.klblCopyright);
            this.kryptonPanel2.Controls.Add(this.klblApplicationVersion);
            this.kryptonPanel2.Controls.Add(this.klblApplicationName);
            this.kryptonPanel2.Controls.Add(this.pbxApplicationIcon);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(622, 339);
            this.kryptonPanel2.TabIndex = 2;
            // 
            // klblFrameworkVersion
            // 
            this.klblFrameworkVersion.Location = new System.Drawing.Point(146, 98);
            this.klblFrameworkVersion.Name = "klblFrameworkVersion";
            this.klblFrameworkVersion.Size = new System.Drawing.Size(156, 19);
            this.klblFrameworkVersion.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblFrameworkVersion.TabIndex = 5;
            this.klblFrameworkVersion.Values.Text = "Framework Version: {0}";
            // 
            // krtbMoreDetails
            // 
            this.krtbMoreDetails.Location = new System.Drawing.Point(146, 141);
            this.krtbMoreDetails.Name = "krtbMoreDetails";
            this.krtbMoreDetails.ReadOnly = true;
            this.krtbMoreDetails.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedHorizontal;
            this.krtbMoreDetails.Size = new System.Drawing.Size(464, 183);
            this.krtbMoreDetails.TabIndex = 4;
            this.krtbMoreDetails.Text = "";
            // 
            // klblCopyright
            // 
            this.klblCopyright.Location = new System.Drawing.Point(146, 70);
            this.klblCopyright.Name = "klblCopyright";
            this.klblCopyright.Size = new System.Drawing.Size(95, 19);
            this.klblCopyright.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblCopyright.TabIndex = 3;
            this.klblCopyright.Values.Text = "Copyright: {0}";
            // 
            // klblApplicationVersion
            // 
            this.klblApplicationVersion.Location = new System.Drawing.Point(146, 42);
            this.klblApplicationVersion.Name = "klblApplicationVersion";
            this.klblApplicationVersion.Size = new System.Drawing.Size(83, 19);
            this.klblApplicationVersion.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblApplicationVersion.TabIndex = 2;
            this.klblApplicationVersion.Values.Text = "Version: {0}";
            // 
            // klblApplicationName
            // 
            this.klblApplicationName.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.klblApplicationName.Location = new System.Drawing.Point(146, 12);
            this.klblApplicationName.Name = "klblApplicationName";
            this.klblApplicationName.Size = new System.Drawing.Size(119, 21);
            this.klblApplicationName.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblApplicationName.TabIndex = 1;
            this.klblApplicationName.Values.Text = "Application: {0}";
            // 
            // pbxApplicationIcon
            // 
            this.pbxApplicationIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbxApplicationIcon.Location = new System.Drawing.Point(12, 12);
            this.pbxApplicationIcon.Name = "pbxApplicationIcon";
            this.pbxApplicationIcon.Size = new System.Drawing.Size(128, 128);
            this.pbxApplicationIcon.TabIndex = 0;
            this.pbxApplicationIcon.TabStop = false;
            // 
            // kryptonBorderEdge1
            // 
            this.kryptonBorderEdge1.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderSecondary;
            this.kryptonBorderEdge1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonBorderEdge1.Location = new System.Drawing.Point(0, 0);
            this.kryptonBorderEdge1.Name = "kryptonBorderEdge1";
            this.kryptonBorderEdge1.Size = new System.Drawing.Size(622, 1);
            this.kryptonBorderEdge1.Text = "kryptonBorderEdge1";
            // 
            // KryptonAboutDialog
            // 
            this.AcceptButton = this.kbtnOk;
            this.ClientSize = new System.Drawing.Size(622, 385);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonAboutDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.KryptonAboutDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxApplicationIcon)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Constructors
        public KryptonAboutDialog(Image applicationIcon, Assembly assembly, FadeSpeedChoice speedChoice = FadeSpeedChoice.Normal, float fadeDelay = 50, int fadeSpeed = 50)
        {
            InitializeComponent();

            FadeSpeed = fadeDelay;

            FadeSpeedChoice = speedChoice;

            SleepInterval = fadeSpeed;

            try
            {
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);

                Text = $"About { assembly.FullName }";

                pbxApplicationIcon.Image = applicationIcon;

                klblApplicationName.Text = $"Application: { fvi.ProductName }";

                klblApplicationVersion.Text = $"Version: { fvi.FileVersion }";

                klblCopyright.Text = $"Copyright: { fvi.LegalCopyright }";

                klblFrameworkVersion.Text = $"Framework Version: { FileUtilityMethodsExtended.GetFrameworkVersion(assembly) }";

                krtbMoreDetails.Text = fvi.FileDescription;
            }
            catch (Exception e)
            {
                ExceptionCapture.CaptureException(e);
            }
        }

        public KryptonAboutDialog(Image applicationIcon, Assembly assembly, bool showDescription, bool showFrameworkVersion, bool showSystemInformation, string applicationText, 
                                 string aboutText, string copyrightText, string frameworkVersionText, string showSystemInformationText, string versionText)
        {
            InitializeComponent();

            try
            {
                Text = $"{aboutText}: {assembly.FullName}";

                pbxApplicationIcon.Image = applicationIcon;

                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);

                klblApplicationName.Text = $"{applicationText}: {fvi.ProductName}";

                klblApplicationVersion.Text = $"{versionText}: {fvi.FileVersion}";

                klblCopyright.Text = $"{copyrightText}: {fvi.LegalCopyright}";

                klblFrameworkVersion.Text = $"{frameworkVersionText}: {FileUtilityMethodsExtended.GetFrameworkVersion(assembly)}";

                klblFrameworkVersion.Visible = showFrameworkVersion;

                krtbMoreDetails.Text = fvi.FileDescription;

                krtbMoreDetails.Visible = showDescription;

                ModifyLayout(showDescription);

                kbtnSystemInformation.Text = showSystemInformationText;

                kbtnSystemInformation.Visible = showSystemInformation;
            }
            catch (Exception e)
            {
                ExceptionCapture.CaptureException(e);
            }
        }
        #endregion

        private void KryptonAboutDialog_Load(object sender, EventArgs e)
        {

        }

        private void kbtnSystemInformation_Click(object sender, EventArgs e)
        {
            // TODO: Eventually, replace this with a custom solution
            try
            {
                Process.Start("msinfo32.exe");
            }
            catch (Exception exc)
            {
                ExceptionCapture.CaptureException(exc);
            }
        }

        private void ModifyLayout(bool showDescription)
        {
            if (showDescription)
            {
                Size = new Size(642, 428);
            }
            else
            {
                Size = new Size(642, 243);
            }
        }
    }
}