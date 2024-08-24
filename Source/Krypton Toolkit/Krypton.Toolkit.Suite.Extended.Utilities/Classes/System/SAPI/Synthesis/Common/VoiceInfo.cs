#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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
    [Serializable]
    [DebuggerDisplay("{(_name != null ? \"'\" + _name + \"' \" : \"\") +  (_culture != null ? \" '\" + _culture.ToString () + \"' \" : \"\") + (_gender != VoiceGender.NotSet ? \" '\" + _gender.ToString () + \"' \" : \"\") + (_age != VoiceAge.NotSet ? \" '\" + _age.ToString () + \"' \" : \"\") + (_variant > 0 ? \" \" + _variant.ToString () : \"\")}")]
    public class VoiceInfo
    {
        private string _name;

        private CultureInfo _culture;

        private VoiceGender _gender;

        private VoiceAge _age;

        private int _variant = -1;

        [NonSerialized]
        private string _id;

        [NonSerialized]
        private string _registryKeyPath;

        [NonSerialized]
        private string _assemblyName;

        [NonSerialized]
        private string _clsid;

        [NonSerialized]
        private string _description;

        [NonSerialized]
        private ReadOnlyDictionary<string, string> _attributes;

        [NonSerialized]
        private ReadOnlyCollection<SpeechAudioFormatInfo> _audioFormats;

        public VoiceGender Gender => _gender;

        public VoiceAge Age => _age;

        public string Name => _name;

        public CultureInfo Culture => _culture;

        public string Id => _id;

        public string Description
        {
            get
            {
                if (_description == null)
                {
                    return string.Empty;
                }
                return _description;
            }
        }

        /// <filterpriority>1</filterpriority>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public ReadOnlyCollection<SpeechAudioFormatInfo> SupportedAudioFormats => _audioFormats;

        /// <filterpriority>1</filterpriority>
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public IDictionary<string, string> AdditionalInfo
        {
            get
            {
                if (_attributes == null)
                {
                    _attributes = new ReadOnlyDictionary<string, string>(new Dictionary<string, string>(0));
                }
                return _attributes;
            }
        }

        internal int Variant => _variant;

        internal string AssemblyName => _assemblyName;

        internal string Clsid => _clsid;

        internal string RegistryKeyPath => _registryKeyPath;

        internal VoiceInfo(string name)
        {
            Helpers.ThrowIfEmptyOrNull(name, "name");
            _name = name;
        }

        internal VoiceInfo(CultureInfo culture)
        {
            Helpers.ThrowIfNull(culture, "culture");
            if (culture.Equals(CultureInfo.InvariantCulture))
            {
                throw new ArgumentException(SR.Get(SRID.InvariantCultureInfo), "culture");
            }
            _culture = culture;
        }

        internal VoiceInfo(ObjectToken token)
        {
            _registryKeyPath = token._sKeyId;
            _id = token.Name;
            _description = token.Description;
            _name = token.TokenName();
            SsmlParserHelpers.TryConvertAge(token.Age.ToLowerInvariant(), out _age);
            SsmlParserHelpers.TryConvertGender(token.Gender.ToLowerInvariant(), out _gender);
            string value;
            if (token.Attributes.TryGetString("Language", out value))
            {
                _culture = SapiAttributeParser.GetCultureInfoFromLanguageString(value);
            }
            string value2;
            if (token.TryGetString("Assembly", out value2))
            {
                _assemblyName = value2;
            }
            string value3;
            if (token.TryGetString("CLSID", out value3))
            {
                _clsid = value3;
            }
            if (token.Attributes != null)
            {
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                string[] valueNames = token.Attributes.GetValueNames();
                foreach (string text in valueNames)
                {
                    string value4;
                    if (token.Attributes.TryGetString(text, out value4))
                    {
                        dictionary.Add(text, value4);
                    }
                }
                _attributes = new ReadOnlyDictionary<string, string>(dictionary);
            }
            string value5;
            if (token.Attributes != null && token.Attributes.TryGetString("AudioFormats", out value5))
            {
                _audioFormats = new ReadOnlyCollection<SpeechAudioFormatInfo>(SapiAttributeParser.GetAudioFormatsFromString(value5));
            }
            else
            {
                _audioFormats = new ReadOnlyCollection<SpeechAudioFormatInfo>(new List<SpeechAudioFormatInfo>());
            }
        }

        internal VoiceInfo(VoiceGender gender)
        {
            _gender = gender;
        }

        internal VoiceInfo(VoiceGender gender, VoiceAge age)
        {
            _gender = gender;
            _age = age;
        }

        internal VoiceInfo(VoiceGender gender, VoiceAge age, int voiceAlternate)
        {
            if (voiceAlternate < 0)
            {
                throw new ArgumentOutOfRangeException("voiceAlternate", SR.Get(SRID.PromptBuilderInvalidVariant));
            }
            _gender = gender;
            _age = age;
            _variant = voiceAlternate + 1;
        }

        public override bool Equals(object obj)
        {
            VoiceInfo voiceInfo = obj as VoiceInfo;
            if (voiceInfo != null && _name == voiceInfo._name && (_age == voiceInfo._age || _age == VoiceAge.NotSet || voiceInfo._age == VoiceAge.NotSet) && (_gender == voiceInfo._gender || _gender == VoiceGender.NotSet || voiceInfo._gender == VoiceGender.NotSet))
            {
                if (_culture != null && voiceInfo._culture != null)
                {
                    return _culture.Equals(voiceInfo._culture);
                }
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return _name.GetHashCode();
        }

        internal static bool ValidateGender(VoiceGender gender)
        {
            if (gender != VoiceGender.Female && gender != VoiceGender.Male && gender != VoiceGender.Neutral)
            {
                return gender == VoiceGender.NotSet;
            }
            return true;
        }

        internal static bool ValidateAge(VoiceAge age)
        {
            if (age != VoiceAge.Adult && age != VoiceAge.Child && age != 0 && age != VoiceAge.Senior)
            {
                return age == VoiceAge.Teen;
            }
            return true;
        }
    }
}
