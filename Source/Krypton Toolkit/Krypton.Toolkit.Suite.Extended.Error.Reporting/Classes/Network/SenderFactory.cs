namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
	internal class SenderFactory
    {
        private readonly ExceptionReportInfo _config;
        private readonly IReportSendEvent _sendEvent;
        private readonly IScreenShooter _screenShooter;

        public SenderFactory(ExceptionReportInfo config, IReportSendEvent sendEvent, IScreenShooter screenShooter)
        {
            _config = config;
            _sendEvent = sendEvent;
            _screenShooter = screenShooter;
        }

        public IReportSender Get()
        {
            switch (_config.SendMethod)
            {
                case ReportSendMethod.WebService:
                    return new WebServiceSender(_config, _sendEvent);
                case ReportSendMethod.SMTP:
                    return new SmtpMailSender(_config, _sendEvent, _screenShooter);
                case ReportSendMethod.SimpleMAPI:
                    return new MapiMailSender(_config, _sendEvent, _screenShooter);
                case ReportSendMethod.None:
                    return new GhostSender();
                default:
                    return new GhostSender();
            }
        }
    }
}