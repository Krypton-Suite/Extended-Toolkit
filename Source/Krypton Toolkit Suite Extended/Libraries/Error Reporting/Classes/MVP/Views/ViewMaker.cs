using Krypton.Toolkit.Suite.Extended.Base;
using System.Windows.Forms;

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

        public ViewMaker(ExceptionReportInfo reportInfo)
        {
            _reportInfo = reportInfo;
        }

        public IExceptionReportView Create()
        {
            return new KryptonFullReportView(_reportInfo);
        }

        public void ShowError(string message, string description)
        {
            KryptonMessageBoxExtended.Show(message, description, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}