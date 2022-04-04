#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
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