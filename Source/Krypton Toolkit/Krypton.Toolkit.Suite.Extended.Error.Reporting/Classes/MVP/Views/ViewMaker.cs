namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
    /// <summary>
    /// contract to show view-related things
    /// </summary>
    public interface IViewMaker
    {
        /// <summary>
        /// create the main view/dialog
        /// </summary>
        /// <returns><see cref="IExceptionReportView"/></returns>
        IExceptionReportView Create();

        /// <summary>
        /// show error 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="description"></param>
        void ShowError(string message, string description);
    }

    internal class ViewMaker : IViewMaker
    {
        private readonly ExceptionReportInfo _reportInfo;

        public ViewMaker(ExceptionReportInfo reportInfo) => _reportInfo = reportInfo;

        public IExceptionReportView Create() => new ExceptionReportView(_reportInfo);

        public void ShowError(string message, string description) => KryptonMessageBox.Show(message, description, MessageBoxButtons.OK, KryptonMessageBoxIcon.ERROR);
    }
}