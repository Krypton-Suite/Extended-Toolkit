using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;

namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
    internal class WebServiceSender : IReportSender
    {
        private const string APPLICATION_JSON = "application/json";
        private readonly ExceptionReportInfo _info;
        private readonly IReportSendEvent _sendEvent;

        internal WebServiceSender(ExceptionReportInfo info, IReportSendEvent sendEvent)
        {
            _info = info;
            _sendEvent = sendEvent;
        }

        public string Description
        {
            get { return "WebService"; }
        }

        public string ConnectingMessage
        {
            get { return string.Format("Connecting to {0}", Description); }
        }

        public void Send(string report)
        {
            var webClient = new ExceptionReporterWebClient(_info.WebServiceTimeout)
            {
                Encoding = Encoding.UTF8
            };

            webClient.Headers.Add(HttpRequestHeader.ContentType, APPLICATION_JSON);
            webClient.Headers.Add(HttpRequestHeader.Accept, APPLICATION_JSON);

            webClient.UploadStringCompleted += OnUploadCompleted(webClient);

            using (var jsonStream = new MemoryStream())
            {
                var sz = new DataContractJsonSerializer(typeof(ReportPacket));
                sz.WriteObject(jsonStream, new ReportPacket
                {
                    AppName = _info.AppName,
                    AppVersion = _info.AppVersion,
                    ExceptionMessage = _info.MainException.Message,
                    ExceptionReport = report
                });
                var jsonString = Encoding.UTF8.GetString(jsonStream.ToArray());
                webClient.UploadStringAsync(new Uri(_info.WebServiceUrl), jsonString);
            }
        }

        private UploadStringCompletedEventHandler OnUploadCompleted(IDisposable webClient)
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
                        _sendEvent.ShowError(string.Format("{0}: ", Description) +
                            (e.Error.InnerException != null ? e.Error.InnerException.Message : e.Error.Message), e.Error);
                    }
                }
                finally
                {
                    webClient.Dispose();
                }
            };
        }
    }

    /// <summary>
    /// override of WebClient - this is the only way to set a timeout
    /// </summary>
    internal class ExceptionReporterWebClient : WebClient
    {
        private readonly int _timeout;

        public ExceptionReporterWebClient(int timeout)
        {
            _timeout = timeout;
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            var wr = base.GetWebRequest(address);
            wr.Timeout = _timeout * 1000;
            return wr;
        }
    }
}