#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.AudioFormat;
using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;
using Krypton.Toolkit.Suite.Extended.Utilities.System.ObjectTokens;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition
{
    /// <filterpriority>2</filterpriority>
    public class RecognizerInfo : IDisposable
    {
        private ReadOnlyDictionary<string, string> _attributes;

        private string _id;

        private string _name;

        private string _description;

        private string _sapiObjectTokenId;

        private CultureInfo _culture;

        private ReadOnlyCollection<SpeechAudioFormatInfo> _supportedAudioFormats;

        private ObjectToken _objectToken;

        public string Id => _id;

        public string Name => _name;

        public string Description => _description;

        public CultureInfo Culture => _culture;

        public ReadOnlyCollection<SpeechAudioFormatInfo> SupportedAudioFormats => _supportedAudioFormats;

        public IDictionary<string, string> AdditionalInfo => _attributes;

        private RecognizerInfo(ObjectToken token, CultureInfo culture)
        {
            _id = token.Name;
            _description = token.Description;
            _sapiObjectTokenId = token.Id;
            _name = token.TokenName();
            _culture = culture;
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            string[] valueNames = token.Attributes.GetValueNames();
            foreach (string text in valueNames)
            {
                string value;
                if (token.Attributes.TryGetString(text, out value))
                {
                    dictionary[text] = value;
                }
            }
            _attributes = new ReadOnlyDictionary<string, string>(dictionary);
            string value2;
            if (token.Attributes.TryGetString("AudioFormats", out value2))
            {
                _supportedAudioFormats = new ReadOnlyCollection<SpeechAudioFormatInfo>(SapiAttributeParser.GetAudioFormatsFromString(value2));
            }
            else
            {
                _supportedAudioFormats = new ReadOnlyCollection<SpeechAudioFormatInfo>(new List<SpeechAudioFormatInfo>());
            }
            _objectToken = token;
        }

        internal static RecognizerInfo Create(ObjectToken token)
        {
            if (token.Attributes == null)
            {
                return null;
            }
            string value;
            if (!token.Attributes.TryGetString("Language", out value))
            {
                return null;
            }
            CultureInfo cultureInfoFromLanguageString = SapiAttributeParser.GetCultureInfoFromLanguageString(value);
            if (cultureInfoFromLanguageString != null)
            {
                return new RecognizerInfo(token, cultureInfoFromLanguageString);
            }
            return null;
        }

        internal ObjectToken GetObjectToken()
        {
            return _objectToken;
        }

        public void Dispose()
        {
            _objectToken.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
