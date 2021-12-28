#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;
using Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsParser;
using Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.Speech;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsGrammar
{
    [Serializable]
    [DebuggerDisplay("{DebuggerDisplayString ()}")]
    public class SrgsSemanticInterpretationTag : SrgsElement, ISemanticTag, IElement
    {
        private string _script = string.Empty;

        public string Script
        {
            get
            {
                return _script;
            }
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
}
