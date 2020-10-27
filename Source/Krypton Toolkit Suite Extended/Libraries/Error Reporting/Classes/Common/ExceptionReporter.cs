using System;

namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
    /// <summary>
    /// The entry-point (class) to invoking an ExceptionReporter dialog
    /// eg new ExceptionReporter().Show(exceptions)
    /// </summary>
    public class ExceptionReporter
    {
        private readonly ExceptionReportInfo _info;

        /// <summary>
        /// Contract by which to show any dialogs/view
        /// </summary>
        public IViewMaker ViewMaker { get; set; }

        /// <summary>
        /// Initialise the ExceptionReporter
        /// </summary>
        public ExceptionReporter()
        {
            _info = new ExceptionReportInfo();
            ViewMaker = new ViewMaker(_info);
        }

        /// <summary>
        /// Public access to configuration/settings
        /// </summary>
        public ExceptionReportInfo Config
        {
            get { return _info; }
        }

        /// <summary>
        /// Show the ExceptionReport dialog
        /// </summary>
        /// <remarks>The <see cref="ExceptionReporter"/> will analyze the <see cref="Exception"/>s and 
        /// create and show the report dialog.</remarks>
        /// <param name="exceptions">The <see cref="Exception"/>s to show.</param>
        public bool Show(params Exception[] exceptions)
        {
            // silently ignore the mistake of passing null
            if (exceptions == null || exceptions.Length == 0 || exceptions.Length >= 1 && exceptions[0] == null) return false;

            bool status;

            try
            {
                _info.SetExceptions(exceptions);

                var view = ViewMaker.Create();
                view.ShowWindow();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                ViewMaker.ShowError(ex.Message, "Failed trying to report an Error");
            }

            return status;
        }

        /// <summary>
        /// Show the ExceptionReport dialog with a custom message instead of the Exception's Message property
        /// </summary>
        /// <param name="customMessage">custom (exception) message</param>
        /// <param name="exceptions">The exception/s to display in the exception report</param>
        public void Show(string customMessage, params Exception[] exceptions)
        {
            _info.CustomMessage = customMessage;
            Show(exceptions);
        }

        /// <summary>
        /// Send the report, asynchronously, without showing a dialog (silent send)
        /// <see cref="ExceptionReportInfo.SendMethod"/>must be SMTP or WebService, else this is ignored (silently)
        /// </summary>
        /// <param name="sendEvent">Provide implementation of IReportSendEvent to receive error/updates on calling thread</param>
        /// <param name="exceptions">The exception/s to include in the report</param>
        public void Send(IReportSendEvent sendEvent = null, params Exception[] exceptions)
        {
            _info.SetExceptions(exceptions);

            var sender = new SenderFactory(_info, sendEvent ?? new SilentSendEvent()).Get();
            var report = new ReportGenerator(_info);
            sender.Send(report.Generate());
        }

        /// <summary>
        /// Send the report, asynchronously, without showing a dialog (silent send)
        /// <see cref="ExceptionReportInfo.SendMethod"/>must be SMTP or WebService, else this is ignored (silently)
        /// </summary>
        /// <param name="exceptions">The exception/s to include in the report</param>
        public void Send(params Exception[] exceptions)
        {
            Send(new SilentSendEvent(), exceptions);
        }

        static readonly bool _isRunningMono = Type.GetType("Mono.Runtime") != null;

        /// <returns><c>true</c>, if running mono <c>false</c> otherwise.</returns>
        public static bool IsRunningMono() { return _isRunningMono; }

        /// <returns><c>true</c>, if not running mono <c>false</c> otherwise.</returns>
        public static bool NotRunningMono() { return !_isRunningMono; }
    }
}