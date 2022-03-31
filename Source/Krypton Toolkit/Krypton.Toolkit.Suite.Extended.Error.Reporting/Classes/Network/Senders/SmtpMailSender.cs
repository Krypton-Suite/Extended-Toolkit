namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
	internal class SmtpMailSender : MailSender, IReportSender
	{
		public SmtpMailSender(ExceptionReportInfo reportInfo, IReportSendEvent sendEvent, IScreenShooter screenShooter) :
			base(reportInfo, sendEvent, screenShooter)
		{ }

		public override string Description => "SMTP";

		/// <summary>
		/// Send SMTP email, uses native .NET SmtpClient library
		/// Requires following ExceptionReportInfo properties to be set:
		/// SmtpPort, SmtpUseSsl, SmtpUsername, SmtpPassword, SmtpFromAddress, EmailReportAddress
		/// </summary>
		public void Send(string report)
		{
			var smtp = new SmtpClient(_config.SmtpServer)
			{
				DeliveryMethod = SmtpDeliveryMethod.Network,
				EnableSsl = _config.SmtpUseSsl,
				UseDefaultCredentials = _config.SmtpUseDefaultCredentials
			};

			if (_config.SmtpPort != 0)      // the default port is used if not set in config
				smtp.Port = _config.SmtpPort;
			if (!_config.SmtpUseDefaultCredentials)
				smtp.Credentials = new NetworkCredential(_config.SmtpUsername, _config.SmtpPassword);

			var message = new MailMessage(_config.SmtpFromAddress, _config.EmailReportAddress)
			{
				BodyEncoding = Encoding.UTF8,
				SubjectEncoding = Encoding.UTF8,
				Priority = _config.SmtpMailPriority,
				Body = report,
				Subject = EmailSubject
			};

			_attacher.AttachFiles(new AttachAdapter(message));

			smtp.SendCompleted += SmtpOnSendCompleted(message, smtp);

			smtp.SendAsync(message, "Exception Report");
		}

		private SendCompletedEventHandler SmtpOnSendCompleted(IDisposable message, IDisposable smtp)
		{
			return (sender, e) =>
			{
				try
				{
					if (e.Error == null)
					{
						_sendEvent.Completed(success: true);
					}
					else
					{
						_sendEvent.Completed(success: false);
						_sendEvent.ShowError($"{Description}: " + (e.Error.InnerException != null ? e.Error.InnerException.Message : e.Error.Message), e.Error);
					}
				}
				finally
				{
					message.Dispose();
					smtp.Dispose();
				}
			};
		}
	}
}