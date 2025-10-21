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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition;

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