namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
	/// <summary>
    /// Default/WinForms implementation of IViewmaker 
    /// </summary>
    internal class DefaultWinFormsViewmaker : IViewMaker
    {
        private readonly ExceptionReportInfo _reportInfo;

        public DefaultWinFormsViewmaker(ExceptionReportInfo reportInfo)
        {
            _reportInfo = reportInfo;
        }

        public IExceptionReportView Create()
        {
            return new ExceptionReportView(_reportInfo);
        }

        public void ShowError(string message)
        {
            KryptonMessageBox.Show(message, Properties.Resources.Failed_trying_to_report_an_Error, MessageBoxButtons.OK, KryptonMessageBoxIcon.ERROR);
        }
    }
}