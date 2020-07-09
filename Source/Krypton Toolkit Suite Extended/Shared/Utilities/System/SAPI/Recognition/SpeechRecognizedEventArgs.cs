namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition
{
	[Serializable]
	public class SpeechRecognizedEventArgs : RecognitionEventArgs
	{
		internal SpeechRecognizedEventArgs(RecognitionResult result)
			: base(result)
		{
		}
	}
}
