#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.TTSEngine
{
	[StructLayout(LayoutKind.Sequential)]
	public class TextFragment
	{
		private FragmentState _state;

		[MarshalAs(UnmanagedType.LPWStr)]
		private string _textToSpeak = string.Empty;

		private int _textOffset;

		private int _textLength;

		public FragmentState State
		{
			get => _state;
            set => _state = value;
        }

		public string TextToSpeak
		{
			get => _textToSpeak;
            set
			{
				Helpers.ThrowIfEmptyOrNull(value, "value");
				_textToSpeak = value;
			}
		}

		public int TextOffset
		{
			get => _textOffset;
            set => _textOffset = value;
        }

		public int TextLength
		{
			get => _textLength;
            set => _textLength = value;
        }

		public TextFragment()
		{
		}

		internal TextFragment(FragmentState fragState)
			: this(fragState, null, null, 0, 0)
		{
		}

		internal TextFragment(FragmentState fragState, string textToSpeak)
			: this(fragState, textToSpeak, textToSpeak, 0, textToSpeak.Length)
		{
		}

		internal TextFragment(FragmentState fragState, string textToSpeak, string textFrag, int offset, int length)
		{
			if (fragState.Action == TtsEngineAction.Speak || fragState.Action == TtsEngineAction.Pronounce)
			{
				textFrag = textToSpeak;
			}
			if (!string.IsNullOrEmpty(textFrag))
			{
				TextToSpeak = textFrag;
			}
			State = fragState;
			TextOffset = offset;
			TextLength = length;
		}
	}
}
