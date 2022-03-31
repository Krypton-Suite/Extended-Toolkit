#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.AudioFormat;

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