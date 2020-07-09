namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition
{
	public class AudioStateChangedEventArgs : EventArgs
	{
		private AudioState _audioState;

		public AudioState AudioState => _audioState;

		internal AudioStateChangedEventArgs(AudioState audioState)
		{
			_audioState = audioState;
		}
	}
}
