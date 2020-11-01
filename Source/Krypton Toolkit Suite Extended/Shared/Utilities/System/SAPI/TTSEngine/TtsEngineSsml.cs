using System;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.TTSEngine
{
	public abstract class TtsEngineSsml
	{
		protected TtsEngineSsml(string registryKey)
		{
		}

		public abstract IntPtr GetOutputFormat(SpeakOutputFormat speakOutputFormat, IntPtr targetWaveFormat);

		public abstract void AddLexicon(Uri uri, string mediaType, ITtsEngineSite site);

		public abstract void RemoveLexicon(Uri uri, ITtsEngineSite site);

		public abstract void Speak(TextFragment[] fragment, IntPtr waveHeader, ITtsEngineSite site);
	}
}
