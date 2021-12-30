#pragma warning disable 1591
namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
    public partial class ExceptionReportView : KryptonForm, IExceptionReportView
    {
        #region Design Code
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ExceptionReportView
            // 
            this.ClientSize = new System.Drawing.Size(551, 416);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExceptionReportView";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);

        }
        #endregion

        #region IExceptionReportView Implementation
        public string ProgressMessage { set => throw new NotImplementedException(); }
        public bool EnableEmailButton { set => throw new NotImplementedException(); }
        public bool ShowProgressBar { set => throw new NotImplementedException(); }
        public bool ShowFullDetail { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string UserExplanation => throw new NotImplementedException();

        public void MapiSendCompleted()
        {
            throw new NotImplementedException();
        }

        public void SetInProgressState()
        {
            throw new NotImplementedException();
        }

        public void PopulateExceptionTab(IEnumerable<Exception> exceptions)
        {
            throw new NotImplementedException();
        }

        public void PopulateAssembliesTab()
        {
            throw new NotImplementedException();
        }

        public void PopulateSysInfoTab()
        {
            throw new NotImplementedException();
        }

        public void SetProgressCompleteState()
        {
            throw new NotImplementedException();
        }

        public void ToggleShowFullDetail()
        {
            throw new NotImplementedException();
        }

        public void ShowWindow()
        {
            throw new NotImplementedException();
        }

        public void Completed(bool success)
        {
            throw new NotImplementedException();
        }

        public void ShowError(string message, Exception exception)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Constructor
        public ExceptionReportView(ExceptionReportInfo reportInfo)
        {
            
        }
        #endregion
    }
}