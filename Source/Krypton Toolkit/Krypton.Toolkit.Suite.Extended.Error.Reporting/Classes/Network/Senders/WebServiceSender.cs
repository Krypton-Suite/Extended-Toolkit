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

        public string Description => "WebService";

        public string ConnectingMessage => $"Connecting to {Description}";

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
                        _sendEvent.ShowError(
                            $"{Description}: {(e.Error.InnerException != null ? e.Error.InnerException.Message : e.Error.Message)}", e.Error);
                    }
                }
                finally
                {
                    webClient.Dispose();
                }
            };
        }
    }
}