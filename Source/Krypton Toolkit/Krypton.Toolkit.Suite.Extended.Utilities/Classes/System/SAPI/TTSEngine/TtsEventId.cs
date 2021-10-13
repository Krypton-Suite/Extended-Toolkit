#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.TTSEngine
{
	public enum TtsEventId
	{
		/// <summary />
		StartInputStream = 1,
		/// <summary />
		EndInputStream,
		/// <summary />
		VoiceChange,
		/// <summary />
		Bookmark,
		/// <summary />
		WordBoundary,
		/// <summary />
		Phoneme,
		/// <summary />
		SentenceBoundary,
		/// <summary />
		Viseme,
		/// <summary />
		AudioLevel
	}
}
