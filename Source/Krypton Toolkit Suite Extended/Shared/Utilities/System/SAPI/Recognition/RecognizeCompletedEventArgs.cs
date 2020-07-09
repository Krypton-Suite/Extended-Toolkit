using System.ComponentModel;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition
{
	public class RecognizeCompletedEventArgs : AsyncCompletedEventArgs
	{
		private RecognitionResult _result;

		private bool _initialSilenceTimeout;

		private bool _babbleTimeout;

		private bool _inputStreamEnded;

		private TimeSpan _audioPosition;

		public RecognitionResult Result => _result;

		public bool InitialSilenceTimeout => _initialSilenceTimeout;

		public bool BabbleTimeout => _babbleTimeout;

		public bool InputStreamEnded => _inputStreamEnded;

		public TimeSpan AudioPosition => _audioPosition;

		internal RecognizeCompletedEventArgs(RecognitionResult result, bool initialSilenceTimeout, bool babbleTimeout, bool inputStreamEnded, TimeSpan audioPosition, Exception error, bool cancelled, object userState)
			: base(error, cancelled, userState)
		{
			_result = result;
			_initialSilenceTimeout = initialSilenceTimeout;
			_babbleTimeout = babbleTimeout;
			_inputStreamEnded = inputStreamEnded;
			_audioPosition = audioPosition;
		}
	}
}
