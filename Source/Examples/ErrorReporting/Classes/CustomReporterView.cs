using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Error.Reporting;

namespace ErrorReporting
{
	public class CustomReporterView : IExceptionReportView
	{
		public string ProgressMessage { get; set; }
		public bool EnableEmailButton { get; set; }
		public bool ShowProgressBar { get; set; }
		public bool ShowFullDetail { get; set; }
		public string UserExplanation { get; }

		public void Completed(bool success) { }
		public void ShowError(string message, Exception exception) { }
		public void MapiSendCompleted() { }
		public void SetInProgressState() { }
		public void PopulateExceptionTab(IEnumerable<Exception> exceptions) { }
		public void PopulateAssembliesTab() { }
		public void PopulateSysInfoTab() { }
		public void SetProgressCompleteState() { }
		public void ToggleShowFullDetail() { }
		public void ShowWindow()
		{
			KryptonMessageBox.Show("Demo custom report form");
		}
	}
}