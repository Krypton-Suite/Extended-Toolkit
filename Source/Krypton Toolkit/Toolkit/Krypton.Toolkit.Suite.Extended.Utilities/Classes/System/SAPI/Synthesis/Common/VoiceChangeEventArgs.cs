#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

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
