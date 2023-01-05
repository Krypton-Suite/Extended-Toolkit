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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Internal
{
    internal static class SapiAttributeParser
    {
        internal static CultureInfo GetCultureInfoFromLanguageString(string valueString)
        {
            string[] array = valueString.Split(';');
            string text = array[0].Trim();
            if (!string.IsNullOrEmpty(text))
            {
                try
                {
                    return new CultureInfo(int.Parse(text, NumberStyles.HexNumber, CultureInfo.InvariantCulture), false);
                }
                catch (ArgumentException)
                {
                    return null;
                }
            }
            return null;
        }

        internal static List<SpeechAudioFormatInfo> GetAudioFormatsFromString(string valueString)
        {
            List<SpeechAudioFormatInfo> list = new List<SpeechAudioFormatInfo>();
            string[] array = valueString.Split(';');
            for (int i = 0; i < array.Length; i++)
            {
                string text = array[i].Trim();
                if (!string.IsNullOrEmpty(text))
                {
                    SpeechAudioFormatInfo speechAudioFormatInfo = AudioFormatConverter.ToSpeechAudioFormatInfo(text);
                    if (speechAudioFormatInfo != null)
                    {
                        list.Add(speechAudioFormatInfo);
                    }
                }
            }
            return list;
        }
    }
}