#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Common;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    public class KryptonAboutDialog : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private System.Windows.Forms.PictureBox pbxApplicationIcon;
        private KryptonPanel kryptonPanel2;
        private KryptonButton kbtnTechnicalDetails;
        private KryptonOKDialogButton kdbOk;
        private KryptonLabel klblApplicationName;
        private KryptonRichTextBox krtbApplicationDescription;
        private KryptonLabel klblCompanyName;
        private KryptonLabel klblCopyright;
        private KryptonLabel klblApplicationBuildDate;
        private KryptonLabel klblApplicationVersion;
        private KryptonButton kbtnCheckForUpdates;
        private System.Windows.Forms.Panel panel1;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.krtbApplicationDescription = new Krypton.Toolkit.KryptonRichTextBox();
            this.klblCompanyName = new Krypton.Toolkit.KryptonLabel();
            this.klblCopyright = new Krypton.Toolkit.KryptonLabel();
            this.klblApplicationBuildDate = new Krypton.Toolkit.KryptonLabel();
            this.klblApplicationVersion = new Krypton.Toolkit.KryptonLabel();
            this.klblApplicationName = new Krypton.Toolkit.KryptonLabel();
            this.pbxApplicationIcon = new System.Windows.Forms.PictureBox();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnTechnicalDetails = new Krypton.Toolkit.KryptonButton();
            this.kdbOk = new Krypton.Toolkit.Suite.Extended.Dialogs.KryptonOKDialogButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kbtnCheckForUpdates = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxApplicationIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.krtbApplicationDescription);
            this.kryptonPanel1.Controls.Add(this.klblCompanyName);
            this.kryptonPanel1.Controls.Add(this.klblCopyright);
            this.kryptonPanel1.Controls.Add(this.klblApplicationBuildDate);
            this.kryptonPanel1.Controls.Add(this.klblApplicationVersion);
            this.kryptonPanel1.Controls.Add(this.klblApplicationName);
            this.kryptonPanel1.Controls.Add(this.pbxApplicationIcon);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(557, 313);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // krtbApplicationDescription
            // 
            this.krtbApplicationDescription.Location = new System.Drawing.Point(83, 143);
            this.krtbApplicationDescription.Name = "krtbApplicationDescription";
            this.krtbApplicationDescription.ReadOnly = true;
            this.krtbApplicationDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedHorizontal;
            this.krtbApplicationDescription.Size = new System.Drawing.Size(462, 117);
            this.krtbApplicationDescription.TabIndex = 6;
            this.krtbApplicationDescription.Text = "kryptonRichTextBox1";
            // 
            // klblCompanyName
            // 
            this.klblCompanyName.Location = new System.Drawing.Point(83, 117);
            this.klblCompanyName.Name = "klblCompanyName";
            this.klblCompanyName.Size = new System.Drawing.Size(146, 20);
            this.klblCompanyName.TabIndex = 5;
            this.klblCompanyName.Values.Text = "<##Company-Name##>";
            // 
            // klblCopyright
            // 
            this.klblCopyright.Location = new System.Drawing.Point(83, 91);
            this.klblCopyright.Name = "klblCopyright";
            this.klblCopyright.Size = new System.Drawing.Size(111, 20);
            this.klblCopyright.TabIndex = 4;
            this.klblCopyright.Values.Text = "<##Copyright##>";
            // 
            // klblApplicationBuildDate
            // 
            this.klblApplicationBuildDate.Location = new System.Drawing.Point(83, 65);
            this.klblApplicationBuildDate.Name = "klblApplicationBuildDate";
            this.klblApplicationBuildDate.Size = new System.Drawing.Size(102, 20);
            this.klblApplicationBuildDate.TabIndex = 3;
            this.klblApplicationBuildDate.Values.Text = "<##Built-On##>";
            // 
            // klblApplicationVersion
            // 
            this.klblApplicationVersion.Location = new System.Drawing.Point(83, 39);
            this.klblApplicationVersion.Name = "klblApplicationVersion";
            this.klblApplicationVersion.Size = new System.Drawing.Size(98, 20);
            this.klblApplicationVersion.TabIndex = 2;
            this.klblApplicationVersion.Values.Text = "<##Version##>";
            // 
            // klblApplicationName
            // 
            this.klblApplicationName.Location = new System.Drawing.Point(83, 13);
            this.klblApplicationName.Name = "klblApplicationName";
            this.klblApplicationName.Size = new System.Drawing.Size(156, 20);
            this.klblApplicationName.TabIndex = 1;
            this.klblApplicationName.Values.Text = "<##Application-Name##>";
            // 
            // pbxApplicationIcon
            // 
            this.pbxApplicationIcon.BackColor = System.Drawing.Color.Transparent;
            this.pbxApplicationIcon.Location = new System.Drawing.Point(12, 12);
            this.pbxApplicationIcon.Name = "pbxApplicationIcon";
            this.pbxApplicationIcon.Size = new System.Drawing.Size(64, 64);
            this.pbxApplicationIcon.TabIndex = 0;
            this.pbxApplicationIcon.TabStop = false;
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kbtnCheckForUpdates);
            this.kryptonPanel2.Controls.Add(this.kbtnTechnicalDetails);
            this.kryptonPanel2.Controls.Add(this.kdbOk);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 269);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(557, 44);
            this.kryptonPanel2.TabIndex = 0;
            // 
            // kbtnTechnicalDetails
            // 
            this.kbtnTechnicalDetails.Location = new System.Drawing.Point(319, 7);
            this.kbtnTechnicalDetails.Name = "kbtnTechnicalDetails";
            this.kbtnTechnicalDetails.Size = new System.Drawing.Size(130, 25);
            this.kbtnTechnicalDetails.TabIndex = 3;
            this.kbtnTechnicalDetails.Values.Text = "&Technical Details...";
            this.kbtnTechnicalDetails.Click += new System.EventHandler(this.kbtnTechnicalDetails_Click);
            // 
            // kdbOk
            // 
            this.kdbOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kdbOk.Location = new System.Drawing.Point(455, 7);
            this.kdbOk.Name = "kdbOk";
            this.kdbOk.ParentWindow = this;
            this.kdbOk.Size = new System.Drawing.Size(90, 25);
            this.kdbOk.TabIndex = 2;
            this.kdbOk.Values.Text = "&OK";
            this.kdbOk.Click += new System.EventHandler(this.kdbOk_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 266);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(557, 3);
            this.panel1.TabIndex = 1;
            // 
            // kbtnCheckForUpdates
            // 
            this.kbtnCheckForUpdates.Location = new System.Drawing.Point(12, 7);
            this.kbtnCheckForUpdates.Name = "kbtnCheckForUpdates";
            this.kbtnCheckForUpdates.Size = new System.Drawing.Size(130, 25);
            this.kbtnCheckForUpdates.TabIndex = 4;
            this.kbtnCheckForUpdates.Values.Text = "Check for &Updates";
            this.kbtnCheckForUpdates.Click += new System.EventHandler(this.kbtnCheckForUpdates_Click);
            // 
            // KryptonAboutDialog
            // 
            this.AcceptButton = this.kdbOk;
            this.ClientSize = new System.Drawing.Size(557, 313);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonAboutDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.KryptonAboutDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxApplicationIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private Assembly _assembly;

        private Image _applicationIcon;

        private KryptonForm _updateWindow;
        #endregion

        #region Properties
        [DefaultValue(null)]
        public Assembly Application { get => _assembly; private set => _assembly = value; }

        [DefaultValue(null)]
        public Image ApplicationIcon { get => _applicationIcon; private set => _applicationIcon = value; }

        [DefaultValue(null)]
        public KryptonForm UpdateWindow { get => _updateWindow; set => _updateWindow = value; }
        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="KryptonAboutDialog" /> class.</summary>
        /// <param name="application">The application.</param>
        /// <param name="applicationIcon">The application icon.</param>
        /// <param name="showTechnicalDetailsButton">if set to <c>true</c> [show technical details button].</param>
        /// <param name="showCheckForUpdatesButton">if set to <c>true</c> [show check for updates button].</param>
        /// <param name="updateWindow">The update window.</param>
        public KryptonAboutDialog(Assembly application, Image applicationIcon, bool showTechnicalDetailsButton = false, bool showCheckForUpdatesButton = false, KryptonForm updateWindow = null)
        {
            InitializeComponent();

            Application = application;

            ApplicationIcon = applicationIcon;

            kbtnTechnicalDetails.Visible = showTechnicalDetailsButton;

            kbtnCheckForUpdates.Visible = showCheckForUpdatesButton;

            UpdateWindow = updateWindow;
        }
        #endregion

        #region Event Handlers
        private void KryptonAboutDialog_Load(object sender, EventArgs e)
        {
            try
            {
                BuildDetails(Application);
            }
            catch (Exception exc)
            {
                ExceptionHandler.CaptureException(exc);
            }
        }

        private void kdbOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void kbtnTechnicalDetails_Click(object sender, EventArgs e)
        {
            Process.Start("msinfo32.exe");
        }

        private void kbtnCheckForUpdates_Click(object sender, EventArgs e)
        {
            try
            {
                CheckForUpdates(UpdateWindow);
            }
            catch (Exception exc)
            {
                ExceptionHandler.CaptureException(exc);
            }
        }
        #endregion

        #region Methods
        private void BuildDetails(Assembly application, bool forceFileDate = false)
        {
            Text = $"About { application.GetName().Name }";

            klblApplicationVersion.Text = $"Version: { application.GetName().Version }";

            klblApplicationBuildDate.Text = $"Build Date: { AssemblyBuildDate(application, forceFileDate) }";

            AssemblyCopyrightAttribute assemblyCopyright = AssemblyDetails.GetAssemblyAttribute<AssemblyCopyrightAttribute>(application);

            klblCopyright.Text = $"Copyright: { assemblyCopyright.Copyright }";

            AssemblyCompanyAttribute assemblyCompany = AssemblyDetails.GetAssemblyAttribute<AssemblyCompanyAttribute>(application);

            klblCompanyName.Text = $"Company Name: { assemblyCompany.Company }";

            AssemblyDescriptionAttribute assemblyDescription = AssemblyDetails.GetAssemblyAttribute<AssemblyDescriptionAttribute>(application);

            krtbApplicationDescription.Text = assemblyDescription.Description;
        }

        /// <summary>
        /// Returns DateTime this Assembly was last built. Will attempt to calculate from build number, if possible. 
        /// If not, the actual LastWriteTime on the assembly file will be returned.
        /// </summary>
        /// <param name="application">Assembly to get build date for</param>
        /// <param name="forceFileDate">Don't attempt to use the build number to calculate the date</param>
        /// <returns>DateTime this assembly was last built</returns>
        private DateTime AssemblyBuildDate(Assembly application, bool forceFileDate)
        {
            Version applicationVersion = application.GetName().Version;

            DateTime dateTime;

            if (forceFileDate)
            {
                dateTime = AssemblyLastWriteTime(application);
            }
            else
            {
                dateTime = DateTime.Parse("01/01/1979").AddDays(applicationVersion.Build).AddSeconds(applicationVersion.Revision * 2);

                if (TimeZone.IsDaylightSavingTime(dateTime, TimeZone.CurrentTimeZone.GetDaylightChanges(dateTime.Year)))
                {
                    dateTime = dateTime.AddHours(1);
                }

                if (dateTime > DateTime.Now || applicationVersion.Build < 730 || applicationVersion.Revision == 0)
                {
                    dateTime = AssemblyLastWriteTime(application);
                }
            }

            return dateTime;
        }

        private DateTime AssemblyLastWriteTime(Assembly application)
        {
            if (application.Location == null || application.Location == "")
            {
                return DateTime.MaxValue;
            }

            try
            {
                return File.GetLastWriteTime(application.Location);
            }
            catch (Exception)
            {
                return DateTime.MaxValue;
            }
        }

        private void CheckForUpdates(KryptonForm updateWindow) => updateWindow.Show();
        #endregion
    }
}