namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis
{
	/// <filterpriority>2</filterpriority>
	public class PhonemeReachedEventArgs : PromptEventArgs
	{
		private string _currentPhoneme;

		private TimeSpan _audioPosition;

		private TimeSpan _duration;

		private SynthesizerEmphasis _emphasis;

		private string _nextPhoneme;

		public string Phoneme => _currentPhoneme;

		public TimeSpan AudioPosition => _audioPosition;

		public TimeSpan Duration => _duration;

		public SynthesizerEmphasis Emphasis => _emphasis;

		public string NextPhoneme => _nextPhoneme;

		internal PhonemeReachedEventArgs(Prompt prompt, string currentPhoneme, TimeSpan audioPosition, TimeSpan duration, SynthesizerEmphasis emphasis, string nextPhoneme)
			: base(prompt)
		{
			_currentPhoneme = currentPhoneme;
			_audioPosition = audioPosition;
			_duration = duration;
			_emphasis = emphasis;
			_nextPhoneme = nextPhoneme;
		}
	}
}
