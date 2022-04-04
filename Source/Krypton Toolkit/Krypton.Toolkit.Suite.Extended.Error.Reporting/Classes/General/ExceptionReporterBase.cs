namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
    /// <summary>
    /// A class at a lower-level than ExceptionReporter due to the need to abstract out the option for the
    /// implementation of IScreenshooter
    /// Call Send() method here directly with any IScreenshooter implementation (including the dummy provided <see cref="NoScreenShot"/> - which will be
    /// effectively the same as setting <see cref="ExceptionReportInfo.TakeScreenshot"/>to false)
    /// </summary>
    public class ExceptionReporterBase
    {
        /// <summary>
        /// 
        /// </summary>
        protected readonly ExceptionReportInfo _info;

        /// <summary>
        /// Initialise the ExceptionReporter
        /// </summary>
        protected ExceptionReporterBase()
        {
            _info = new ExceptionReportInfo();
        }

        /// <summary>
        /// Public access to configuration/settings
        /// </summary>
        public ExceptionReportInfo Config => _info;

        /// <summary>
        /// Send the report, asynchronously, without showing a dialog (silent send)
        /// <see cref="ExceptionReportInfo.SendMethod"/>must be SMTP or WebService, else this is ignored (silently)
        /// </summary>
        /// <param name="screenShooter">The screen-shotting code might be specific to WinForms, so this is an option to send anything that implements IScreenshooter</param>
        /// <param name="sendEvent">Provide implementation of IReportSendEvent to receive error/updates on calling thread</param>
        /// <param name="exceptions">The exception/s to include in the report</param>
        protected void Send(IScreenShooter screenShooter, IReportSendEvent sendEvent = null, params Exception[] exceptions)
        {
            _info.SetExceptions(exceptions);

            var sender = new SenderFactory(_info, sendEvent ?? new SilentSendEvent(), screenShooter).Get();
            var report = new ReportGenerator(_info);
            sender.Send(report.Generate());
        }
    }
}