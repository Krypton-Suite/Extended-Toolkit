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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis
{
    internal static class SsmlParserHelpers
    {
        private static readonly string[] _genderNames = new string[3]
        {
            "female",
            "male",
            "neutral"
        };

        private static readonly VoiceGender[] _genders = new VoiceGender[3]
        {
            VoiceGender.Female,
            VoiceGender.Male,
            VoiceGender.Neutral
        };

        internal static bool TryConvertAge(string sAge, out VoiceAge age)
        {
            bool result = false;
            age = VoiceAge.NotSet;
            switch (sAge)
            {
                case "child":
                    age = VoiceAge.Child;
                    break;
                case "teenager":
                case "teen":
                    age = VoiceAge.Teen;
                    break;
                case "adult":
                    age = VoiceAge.Adult;
                    break;
                case "elder":
                case "senior":
                    age = VoiceAge.Senior;
                    break;
            }
            int result2;
            if (age != 0)
            {
                result = true;
            }
            else if (int.TryParse(sAge, out result2))
            {
                if (result2 <= 12)
                {
                    age = VoiceAge.Child;
                }
                else if (result2 <= 22)
                {
                    age = VoiceAge.Teen;
                }
                else if (result2 <= 47)
                {
                    age = VoiceAge.Adult;
                }
                else
                {
                    age = VoiceAge.Senior;
                }
                result = true;
            }
            return result;
        }

        internal static bool TryConvertGender(string sGender, out VoiceGender gender)
        {
            bool result = false;
            gender = VoiceGender.NotSet;
            int num = Array.BinarySearch(_genderNames, sGender);
            if (num >= 0)
            {
                gender = _genders[num];
                result = true;
            }
            return result;
        }
    }
}