#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
    internal abstract class MailSender
    {
        protected readonly ExceptionReportInfo _config;
        protected readonly IReportSendEvent _sendEvent;
        protected readonly Attacher _attacher;

        protected MailSender(ExceptionReportInfo reportInfo, IReportSendEvent sendEvent, IScreenShooter screenShooter)
        {
            _config = reportInfo;
            _sendEvent = sendEvent;
            _attacher = new Attacher(reportInfo, screenShooter);
        }

        public abstract string Description { get; }

        public virtual string ConnectingMessage => $"Connecting {Description}...";

        public string EmailSubject =>
            _config.EmailReportSubject.Length > 0 ? _config.EmailReportSubject :
                _config.MainException.Message
                    .Replace('\r', ' ')
                    .Replace('\n', ' ')
                    .Truncate(255) ?? "Exception Report";
    }
}