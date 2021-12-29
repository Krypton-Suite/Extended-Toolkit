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
						_sendEvent.ShowError($"{Description}: " +
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
}