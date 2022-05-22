namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
    /// <summary>
    /// An interface/contract to replace the default view (currently only applicable to WinForms)
    /// </summary>
    public interface IViewMaker
    {
        /// <summary>
        /// create the main view/dialog
        /// </summary>
        /// <returns><see cref="IExceptionReportView"/></returns>
        IExceptionReportView Create();

        /// <summary>
        /// show an error 
        /// </summary>
        /// <param name="message"></param>
        void ShowError(string message);
    }
}