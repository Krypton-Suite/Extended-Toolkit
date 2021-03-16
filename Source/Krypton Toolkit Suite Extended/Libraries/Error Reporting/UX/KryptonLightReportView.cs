using System;
using System.Collections.Generic;

namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
    public class KryptonLightReportView : KryptonForm, IExceptionReportView
    {
        #region Design Code
        private System.Windows.Forms.Panel panel1;
        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnSend;
        private KryptonButton kbtnCopyDetails;
        private KryptonButton kbtnMoreDetails;
        private KryptonLabel klblContactCompany;
        private KryptonWrapLabel kwlExceptionMessageLarge;
        private KryptonWrapLabel kwlHeader;
        private System.Windows.Forms.PictureBox lessDetail_alertIcon;
        private KryptonPanel kryptonPanel2;

        private void InitializeComponent()
        {
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnSend = new Krypton.Toolkit.KryptonButton();
            this.kbtnCopyDetails = new Krypton.Toolkit.KryptonButton();
            this.kbtnMoreDetails = new Krypton.Toolkit.KryptonButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.klblContactCompany = new Krypton.Toolkit.KryptonLabel();
            this.kwlExceptionMessageLarge = new Krypton.Toolkit.KryptonWrapLabel();
            this.kwlHeader = new Krypton.Toolkit.KryptonWrapLabel();
            this.lessDetail_alertIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lessDetail_alertIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kbtnSend);
            this.kryptonPanel2.Controls.Add(this.kbtnCopyDetails);
            this.kryptonPanel2.Controls.Add(this.kbtnMoreDetails);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 277);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(542, 41);
            this.kryptonPanel2.TabIndex = 4;
            // 
            // kbtnSend
            // 
            this.kbtnSend.Location = new System.Drawing.Point(316, 8);
            this.kbtnSend.Name = "kbtnSend";
            this.kbtnSend.Size = new System.Drawing.Size(90, 25);
            this.kbtnSend.TabIndex = 2;
            this.kbtnSend.Values.Text = "&Send";
            // 
            // kbtnCopyDetails
            // 
            this.kbtnCopyDetails.Location = new System.Drawing.Point(220, 8);
            this.kbtnCopyDetails.Name = "kbtnCopyDetails";
            this.kbtnCopyDetails.Size = new System.Drawing.Size(90, 25);
            this.kbtnCopyDetails.TabIndex = 1;
            this.kbtnCopyDetails.Values.Text = "&Copy Details";
            // 
            // kbtnMoreDetails
            // 
            this.kbtnMoreDetails.Location = new System.Drawing.Point(124, 8);
            this.kbtnMoreDetails.Name = "kbtnMoreDetails";
            this.kbtnMoreDetails.Size = new System.Drawing.Size(90, 25);
            this.kbtnMoreDetails.TabIndex = 0;
            this.kbtnMoreDetails.Values.Text = "More &Details";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 274);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(542, 3);
            this.panel1.TabIndex = 5;
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.klblContactCompany);
            this.kryptonPanel1.Controls.Add(this.kwlExceptionMessageLarge);
            this.kryptonPanel1.Controls.Add(this.kwlHeader);
            this.kryptonPanel1.Controls.Add(this.lessDetail_alertIcon);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(542, 274);
            this.kryptonPanel1.TabIndex = 6;
            // 
            // klblContactCompany
            // 
            this.klblContactCompany.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.klblContactCompany.Location = new System.Drawing.Point(12, 236);
            this.klblContactCompany.Name = "klblContactCompany";
            this.klblContactCompany.Size = new System.Drawing.Size(6, 2);
            this.klblContactCompany.TabIndex = 29;
            this.klblContactCompany.Values.Text = "";
            // 
            // kwlExceptionMessageLarge
            // 
            this.kwlExceptionMessageLarge.AutoSize = false;
            this.kwlExceptionMessageLarge.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kwlExceptionMessageLarge.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlExceptionMessageLarge.Location = new System.Drawing.Point(12, 83);
            this.kwlExceptionMessageLarge.Name = "kwlExceptionMessageLarge";
            this.kwlExceptionMessageLarge.Size = new System.Drawing.Size(518, 141);
            this.kwlExceptionMessageLarge.Text = "No message";
            // 
            // kwlHeader
            // 
            this.kwlHeader.AutoSize = false;
            this.kwlHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlHeader.Location = new System.Drawing.Point(83, 12);
            this.kwlHeader.Name = "kwlHeader";
            this.kwlHeader.Size = new System.Drawing.Size(447, 64);
            this.kwlHeader.StateCommon.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kwlHeader.Text = "Operation Failed!";
            this.kwlHeader.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lessDetail_alertIcon
            // 
            this.lessDetail_alertIcon.BackColor = System.Drawing.Color.Transparent;
            this.lessDetail_alertIcon.Image = global::Krypton.Toolkit.Suite.Extended.Error.Reporting.Properties.Resources.Warning_64_x_58;
            this.lessDetail_alertIcon.Location = new System.Drawing.Point(12, 12);
            this.lessDetail_alertIcon.Name = "lessDetail_alertIcon";
            this.lessDetail_alertIcon.Size = new System.Drawing.Size(64, 64);
            this.lessDetail_alertIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.lessDetail_alertIcon.TabIndex = 26;
            this.lessDetail_alertIcon.TabStop = false;
            // 
            // KryptonLightReportView
            // 
            this.ClientSize = new System.Drawing.Size(542, 318);
            this.Controls.Add(this.kryptonPanel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.kryptonPanel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonLightReportView";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Load += new System.EventHandler(this.KryptonLightReportView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lessDetail_alertIcon)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Constructor
        public KryptonLightReportView(ExceptionReportInfo reportInfo)
        {
            InitializeComponent();
        }
        #endregion

        private void KryptonLightReportView_Load(object sender, EventArgs e)
        {

        }

        #region IExceptionReportView Implementation
        public string ProgressMessage { set => throw new NotImplementedException(); }
        public bool EnableEmailButton { set => throw new NotImplementedException(); }
        public bool ShowProgressBar { set => throw new NotImplementedException(); }
        public bool ShowFullDetail { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string UserExplanation => throw new NotImplementedException();

        public void Completed(bool success)
        {
            throw new NotImplementedException();
        }

        public void MapiSendCompleted()
        {
            throw new NotImplementedException();
        }

        public void PopulateAssembliesTab()
        {
            throw new NotImplementedException();
        }

        public void PopulateExceptionTab(IEnumerable<Exception> exceptions)
        {
            throw new NotImplementedException();
        }

        public void PopulateSysInfoTab()
        {
            throw new NotImplementedException();
        }

        public void SetInProgressState()
        {
            throw new NotImplementedException();
        }

        public void SetProgressCompleteState()
        {
            throw new NotImplementedException();
        }

        public void ShowError(string message, Exception exception)
        {
            throw new NotImplementedException();
        }

        public void ShowWindow()
        {
            throw new NotImplementedException();
        }

        public void ToggleShowFullDetail()
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}