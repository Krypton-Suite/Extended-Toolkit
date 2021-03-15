namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
    internal class MapiMailSender : MailSender, IReportSender
    {
        public MapiMailSender(ExceptionReportInfo reportInfo, IReportSendEvent sendEvent) :
            base(reportInfo, sendEvent)
        { }

        public override string Description
        {
            get { return "Email Client"; }
        }

        public override string ConnectingMessage
        {
            get { return $"Launching { Description }..."; }
        }

        /// <summary>
        /// Try send via installed Email client
        /// Uses Simple-MAPI.NET library - https://github.com/PandaWood/Simple-MAPI.NET
        /// </summary>
        public void Send(string report)
        {
            if (_config.EmailReportAddress.IsEmpty())
            {
                _sendEvent.ShowError("EmailReportAddress not set", new ConfigurationErrorsException("EmailReportAddress"));
                return;
            }

            var mapi = new SimpleMapi();
            mapi.AddRecipient(_config.EmailReportAddress, null, false);
            _attacher.AttachFiles(new AttachAdapter(mapi));

            mapi.Send(EmailSubject, report);
        }
    }
}