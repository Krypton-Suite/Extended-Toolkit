using System.ComponentModel;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition
{
	public class EmulateRecognizeCompletedEventArgs : AsyncCompletedEventArgs
	{
		private RecognitionResult _result;

		public RecognitionResult Result => _result;

		internal EmulateRecognizeCompletedEventArgs(RecognitionResult result, Exception error, bool cancelled, object userState)
			: base(error, cancelled, userState)
		{
			_result = result;
		}
	}
}
