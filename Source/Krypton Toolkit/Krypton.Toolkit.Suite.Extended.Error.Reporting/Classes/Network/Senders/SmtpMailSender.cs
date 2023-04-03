#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

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
            {
                smtp.Port = _config.SmtpPort;
            }

            if (!_config.SmtpUseDefaultCredentials)
            {
                smtp.Credentials = new NetworkCredential(_config.SmtpUsername, _config.SmtpPassword);
            }

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
						_sendEvent.ShowError(
                            $"{Description}: {(e.Error.InnerException != null ? e.Error.InnerException.Message : e.Error.Message)}", e.Error);
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