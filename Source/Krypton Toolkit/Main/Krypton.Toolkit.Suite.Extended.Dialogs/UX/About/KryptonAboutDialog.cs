#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Developer.Utilities;
using Krypton.Toolkit.Suite.Extended.Global.Utilities;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    public class KryptonAboutDialog : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private System.Windows.Forms.Panel panel1;
        private KryptonLabel klblApplicationVersion;
        private KryptonLabel klblApplicationName;
        private System.Windows.Forms.PictureBox pbxApplicationIcon;
        private KryptonButton kbtnOk;
        private KryptonRichTextBox krtbMoreDetails;
        private KryptonLabel klblCopyright;
        private KryptonButton kbtnSystemInformation;
        private KryptonLabel klblFrameworkVersion;
        private KryptonPanel kryptonPanel2;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.klblApplicationVersion = new Krypton.Toolkit.KryptonLabel();
            this.klblApplicationName = new Krypton.Toolkit.KryptonLabel();
            this.pbxApplicationIcon = new System.Windows.Forms.PictureBox();
            this.klblCopyright = new Krypton.Toolkit.KryptonLabel();
            this.krtbMoreDetails = new Krypton.Toolkit.KryptonRichTextBox();
            this.kbtnOk = new Krypton.Toolkit.KryptonButton();
            this.klblFrameworkVersion = new Krypton.Toolkit.KryptonLabel();
            this.kbtnSystemInformation = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxApplicationIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnSystemInformation);
            this.kryptonPanel1.Controls.Add(this.kbtnOk);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 339);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(622, 46);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 336);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(622, 3);
            this.panel1.TabIndex = 1;
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
            this.kryptonPanel2.Size = new System.Drawing.Size(622, 336);
            this.kryptonPanel2.TabIndex = 2;
            // 
            // klblApplicationVersion
            // 
            this.klblApplicationVersion.Location = new System.Drawing.Point(146, 42);
            this.klblApplicationVersion.Name = "klblApplicationVersion";
            this.klblApplicationVersion.Size = new System.Drawing.Size(83, 19);
            this.klblApplicationVersion.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblApplicationVersion.StateCommon.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.klblApplicationVersion.StateCommon.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
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
            this.klblApplicationName.StateCommon.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.klblApplicationName.StateCommon.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
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
            // klblCopyright
            // 
            this.klblCopyright.Location = new System.Drawing.Point(146, 70);
            this.klblCopyright.Name = "klblCopyright";
            this.klblCopyright.Size = new System.Drawing.Size(95, 19);
            this.klblCopyright.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblCopyright.StateCommon.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.klblCopyright.StateCommon.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.klblCopyright.TabIndex = 3;
            this.klblCopyright.Values.Text = "Copyright: {0}";
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
            // kbtnOk
            // 
            this.kbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnOk.Location = new System.Drawing.Point(520, 9);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new System.Drawing.Size(90, 25);
            this.kbtnOk.TabIndex = 0;
            this.kbtnOk.Values.Text = "&Ok";
            // 
            // klblFrameworkVersion
            // 
            this.klblFrameworkVersion.Location = new System.Drawing.Point(146, 98);
            this.klblFrameworkVersion.Name = "klblFrameworkVersion";
            this.klblFrameworkVersion.Size = new System.Drawing.Size(156, 19);
            this.klblFrameworkVersion.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblFrameworkVersion.StateCommon.ShortText.ImageStyle = Krypton.Toolkit.PaletteImageStyle.Inherit;
            this.klblFrameworkVersion.StateCommon.ShortText.Trim = Krypton.Toolkit.PaletteTextTrim.Inherit;
            this.klblFrameworkVersion.TabIndex = 5;
            this.klblFrameworkVersion.Values.Text = "Framework Version: {0}";
            // 
            // kbtnSystemInformation
            // 
            this.kbtnSystemInformation.Location = new System.Drawing.Point(12, 9);
            this.kbtnSystemInformation.Name = "kbtnSystemInformation";
            this.kbtnSystemInformation.Size = new System.Drawing.Size(128, 25);
            this.kbtnSystemInformation.TabIndex = 1;
            this.kbtnSystemInformation.Values.Text = "System &Information";
            this.kbtnSystemInformation.Visible = false;
            // 
            // KryptonAboutDialog
            // 
            this.AcceptButton = this.kbtnOk;
            this.ClientSize = new System.Drawing.Size(622, 385);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.panel1);
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
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxApplicationIcon)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Constructors
        public KryptonAboutDialog(Image applicationIcon, Assembly assembly)
        {
            InitializeComponent();

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
        #endregion

        private void KryptonAboutDialog_Load(object sender, EventArgs e)
        {

        }
    }
}