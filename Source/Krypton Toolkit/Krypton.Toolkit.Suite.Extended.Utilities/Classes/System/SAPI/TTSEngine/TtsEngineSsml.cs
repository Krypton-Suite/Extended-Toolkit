#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

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
