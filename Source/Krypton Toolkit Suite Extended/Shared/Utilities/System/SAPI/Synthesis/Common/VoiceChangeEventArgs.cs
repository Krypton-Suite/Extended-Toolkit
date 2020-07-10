namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis
{
	/// <filterpriority>2</filterpriority>
	public class VoiceChangeEventArgs : PromptEventArgs
	{
		private VoiceInfo _voice;

		public VoiceInfo Voice => _voice;

		internal VoiceChangeEventArgs(Prompt prompt, VoiceInfo voice)
			: base(prompt)
		{
			_voice = voice;
		}
	}
}
