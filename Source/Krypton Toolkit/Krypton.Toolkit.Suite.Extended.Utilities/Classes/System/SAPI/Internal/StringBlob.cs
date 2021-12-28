#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.Speech;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Internal
{
    internal class StringBlob
    {
        private Dictionary<string, int> _strings = new Dictionary<string, int>();

        private List<string> _refStrings = new List<string>();

        private List<int> _offsetStrings = new List<int>();

        private int _cWords;

        private int _totalStringSizes = 1;

        private const int _sizeOfChar = 2;

        internal string this[int index]
        {
            get
            {
                if (index < 1 || index > _cWords)
                {
                    throw new InvalidOperationException();
                }
                return _refStrings[index - 1];
            }
        }

        internal int Count => _cWords;

        internal StringBlob()
        {
        }

        internal StringBlob(char[] pszStringArray)
        {
            int num = pszStringArray.Length;
            if (num <= 0)
            {
                return;
            }
            if (pszStringArray[0] != 0)
            {
                throw new FormatException(SR.Get(SRID.RecognizerInvalidBinaryGrammar));
            }
            int i = 1;
            int num2 = num;
            int num3 = 1;
            for (; i < num2; i++)
            {
                if (pszStringArray[i] == '\0')
                {
                    string text = new string(pszStringArray, num3, i - num3);
                    _refStrings.Add(text);
                    _offsetStrings.Add(_totalStringSizes);
                    _strings.Add(text, ++_cWords);
                    _totalStringSizes += text.Length + 1;
                    num3 = i + 1;
                }
            }
        }

        internal int Add(string psz, out int idWord)
        {
            int num = 0;
            idWord = 0;
            if (!string.IsNullOrEmpty(psz))
            {
                if (!_strings.TryGetValue(psz, out idWord))
                {
                    idWord = ++_cWords;
                    num = _totalStringSizes;
                    _refStrings.Add(psz);
                    _offsetStrings.Add(num);
                    _strings.Add(psz, _cWords);
                    _totalStringSizes += psz.Length + 1;
                }
                else
                {
                    num = OffsetFromId(idWord);
                }
            }
            return num;
        }

        internal int Find(string psz)
        {
            if (string.IsNullOrEmpty(psz) || _cWords == 0)
            {
                return 0;
            }
            int value;
            if (!_strings.TryGetValue(psz, out value))
            {
                return -1;
            }
            return value;
        }

        internal string FromOffset(int offset)
        {
            int num = 1;
            int num2 = 1;
            if (offset == 1 && _cWords >= 1)
            {
                return this[num2];
            }
            foreach (string refString in _refStrings)
            {
                num2++;
                num += refString.Length + 1;
                if (offset == num)
                {
                    return this[num2];
                }
            }
            return null;
        }

        internal int StringSize()
        {
            if (_cWords <= 0)
            {
                return 0;
            }
            return _totalStringSizes;
        }

        internal int SerializeSize()
        {
            return ((StringSize() * 2 + 3) & -4) / 2;
        }

        internal char[] SerializeData()
        {
            int num = SerializeSize();
            char[] array = new char[num];
            int num2 = 1;
            foreach (string refString in _refStrings)
            {
                for (int i = 0; i < refString.Length; i++)
                {
                    array[num2++] = refString[i];
                }
                array[num2++] = '\0';
            }
            if (StringSize() % 2 == 1)
            {
                array[num2++] = '쳌';
            }
            return array;
        }

        internal int OffsetFromId(int index)
        {
            if (index > 0)
            {
                return _offsetStrings[index - 1];
            }
            return 0;
        }
    }
}