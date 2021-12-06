#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis
{
	public class SpeakCompletedEventArgs : PromptEventArgs
	{
		internal SpeakCompletedEventArgs(Prompt prompt)
			: base(prompt)
		{
		}
	}
}