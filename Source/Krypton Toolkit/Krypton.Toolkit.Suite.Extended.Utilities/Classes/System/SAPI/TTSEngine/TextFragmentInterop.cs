#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.TTSEngine
{
	internal struct TextFragmentInterop
	{
		internal FragmentStateInterop _state;

		[MarshalAs(UnmanagedType.LPWStr)]
		internal string _textToSpeak;

		internal int _textOffset;

		internal int _textLength;

		internal static IntPtr FragmentToPtr(List<TextFragment> textFragments, Collection<IntPtr> memoryBlocks)
		{
			TextFragmentInterop textFragmentInterop = default(TextFragmentInterop);
			int count = textFragments.Count;
			int num = Marshal.SizeOf((object)textFragmentInterop);
			IntPtr intPtr = Marshal.AllocCoTaskMem(num * count);
			memoryBlocks.Add(intPtr);
			for (int i = 0; i < count; i++)
			{
				textFragmentInterop._state.FragmentStateToPtr(textFragments[i].State, memoryBlocks);
				textFragmentInterop._textToSpeak = textFragments[i].TextToSpeak;
				textFragmentInterop._textOffset = textFragments[i].TextOffset;
				textFragmentInterop._textLength = textFragments[i].TextLength;
				Marshal.StructureToPtr((object)textFragmentInterop, (IntPtr)((long)intPtr + i * num), false);
			}
			return intPtr;
		}
	}
}
