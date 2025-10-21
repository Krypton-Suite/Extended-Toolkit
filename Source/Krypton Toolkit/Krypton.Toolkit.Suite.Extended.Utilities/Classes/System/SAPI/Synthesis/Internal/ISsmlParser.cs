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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis;

internal interface ISsmlParser
{
    string Ssml
    {
        get;
    }

    object ProcessSpeak(string sVersion, string sBaseUri, CultureInfo culture, List<SsmlXmlAttribute> extraNamespace);

    void ProcessText(string text, object voice, ref FragmentState fragmentState, int position, bool fIgnore);

    void ProcessAudio(object voice, string sUri, string baseUri, bool fIgnore);

    void ProcessBreak(object voice, ref FragmentState fragmentState, EmphasisBreak eBreak, int time, bool fIgnore);

    void ProcessDesc(CultureInfo culture);

    void ProcessEmphasis(bool noLevel, EmphasisWord word);

    void ProcessMark(object voice, ref FragmentState fragmentState, string name, bool fIgnore);

    object ProcessTextBlock(bool isParagraph, object voice, ref FragmentState fragmentState, CultureInfo culture, bool newCulture, VoiceGender gender, VoiceAge age);

    void EndProcessTextBlock(bool isParagraph);

    void ProcessPhoneme(ref FragmentState fragmentState, AlphabetType alphabet, string ph, char[] phoneIds);

    void ProcessProsody(string pitch, string range, string rate, string volume, string duration, string points);

    void ProcessSayAs(string interpretAs, string format, string detail);

    void ProcessSub(string alias, object voice, ref FragmentState fragmentState, int position, bool fIgnore);

    object ProcessVoice(string name, CultureInfo culture, VoiceGender gender, VoiceAge age, int variant, bool fNewCulture, List<SsmlXmlAttribute> extraNamespace);

    void ProcessLexicon(Uri uri, string type);

    void EndElement();

    void EndSpeakElement();

    void ProcessUnknownElement(object voice, ref FragmentState fragmentState, XmlReader reader);

    void StartProcessUnknownAttributes(object voice, ref FragmentState fragmentState, string element, List<SsmlXmlAttribute> extraAttributes);

    void EndProcessUnknownAttributes(object voice, ref FragmentState fragmentState, string element, List<SsmlXmlAttribute> extraAttributes);

    void ContainsPexml(string pexmlPrefix);

    bool BeginPromptEngineOutput(object voice);

    void EndPromptEngineOutput(object voice);

    bool ProcessPromptEngineDatabase(object voice, string fname, string delta, string idset);

    bool ProcessPromptEngineDiv(object voice);

    bool ProcessPromptEngineId(object voice, string id);

    bool BeginPromptEngineTts(object voice);

    void EndPromptEngineTts(object voice);

    bool BeginPromptEngineWithTag(object voice, string tag);

    void EndPromptEngineWithTag(object voice, string tag);

    bool BeginPromptEngineRule(object voice, string name);

    void EndPromptEngineRule(object voice, string name);
}