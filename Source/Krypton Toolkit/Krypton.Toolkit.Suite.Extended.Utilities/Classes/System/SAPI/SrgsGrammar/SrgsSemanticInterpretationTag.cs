#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsGrammar;

[Serializable]
[DebuggerDisplay("{DebuggerDisplayString ()}")]
public class SrgsSemanticInterpretationTag : SrgsElement, ISemanticTag, IElement
{
    private string _script = string.Empty;

    public string Script
    {
        get => _script;
        set
        {
            Helpers.ThrowIfNull(value, "value");
            _script = value;
        }
    }

    public SrgsSemanticInterpretationTag()
    {
    }

    public SrgsSemanticInterpretationTag(string script)
    {
        Helpers.ThrowIfNull(script, "script");
        _script = script;
    }

    internal override void Validate(SrgsGrammar grammar)
    {
        if (grammar.TagFormat == SrgsTagFormat.Default)
        {
            grammar.TagFormat |= SrgsTagFormat.W3cV1;
        }
        else if (grammar.TagFormat == SrgsTagFormat.KeyValuePairs)
        {
            XmlParser.ThrowSrgsException(SRID.SapiPropertiesAndSemantics);
        }
    }

    internal override void WriteSrgs(XmlWriter writer)
    {
        string text = Script.Trim(Helpers._achTrimChars);
        writer.WriteStartElement("tag");
        if (!string.IsNullOrEmpty(text))
        {
            writer.WriteString(text);
        }
        writer.WriteEndElement();
    }

    internal override string DebuggerDisplayString()
    {
        StringBuilder stringBuilder = new StringBuilder("SrgsSemanticInterpretationTag '");
        stringBuilder.Append(_script);
        stringBuilder.Append("'");
        return stringBuilder.ToString();
    }

    void ISemanticTag.Content(IElement parent, string value, int line)
    {
        Script = value;
    }
}