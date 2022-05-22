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
    [ImmutableObject(true)]
    [DebuggerDisplay("{DebuggerDisplayString()}")]
    public class SrgsRuleRef : SrgsElement, IRuleRef, IElement
    {
        private enum SpecialRuleRefType
        {
            Null,
            Void,
            Garbage
        }

        public static readonly SrgsRuleRef Null = new SrgsRuleRef(SpecialRuleRefType.Null);

        public static readonly SrgsRuleRef Void = new SrgsRuleRef(SpecialRuleRefType.Void);

        public static readonly SrgsRuleRef Garbage = new SrgsRuleRef(SpecialRuleRefType.Garbage);

        public static readonly SrgsRuleRef Dictation = new SrgsRuleRef(new Uri("grammar:dictation"));

        public static readonly SrgsRuleRef MnemonicSpelling = new SrgsRuleRef(new Uri("grammar:dictation#spelling"));

        private Uri _uri;

        private SpecialRuleRefType _type;

        private string _semanticKey;

        private string _params;

        public Uri Uri => _uri;

        public string SemanticKey => _semanticKey;

        public string Params => _params;

        public SrgsRuleRef(Uri uri)
        {
            UriInit(uri, null, null, null);
        }

        public SrgsRuleRef(Uri uri, string rule)
        {
            Helpers.ThrowIfEmptyOrNull(rule, "rule");
            UriInit(uri, rule, null, null);
        }

        public SrgsRuleRef(Uri uri, string rule, string semanticKey)
        {
            Helpers.ThrowIfEmptyOrNull(semanticKey, "semanticKey");
            UriInit(uri, rule, semanticKey, null);
        }

        public SrgsRuleRef(Uri uri, string rule, string semanticKey, string parameters)
        {
            Helpers.ThrowIfEmptyOrNull(parameters, "parameters");
            UriInit(uri, rule, semanticKey, parameters);
        }

        public SrgsRuleRef(SrgsRule rule)
        {
            Helpers.ThrowIfNull(rule, "rule");
            _uri = new Uri("#" + rule.Id, UriKind.Relative);
        }

        public SrgsRuleRef(SrgsRule rule, string semanticKey)
            : this(rule)
        {
            Helpers.ThrowIfEmptyOrNull(semanticKey, "semanticKey");
            _semanticKey = semanticKey;
        }

        public SrgsRuleRef(SrgsRule rule, string semanticKey, string parameters)
            : this(rule)
        {
            Helpers.ThrowIfEmptyOrNull(parameters, "parameters");
            _semanticKey = semanticKey;
            _params = parameters;
        }

        private SrgsRuleRef(SpecialRuleRefType type)
        {
            _type = type;
        }

        internal SrgsRuleRef(string semanticKey, string parameters, Uri uri)
        {
            _uri = uri;
            _semanticKey = semanticKey;
            _params = parameters;
        }

        internal override void WriteSrgs(XmlWriter writer)
        {
            writer.WriteStartElement("ruleref");
            if (_uri != null)
            {
                writer.WriteAttributeString("uri", _uri.ToString());
            }
            else
            {
                string value;
                switch (_type)
                {
                    case SpecialRuleRefType.Null:
                        value = "NULL";
                        break;
                    case SpecialRuleRefType.Void:
                        value = "VOID";
                        break;
                    case SpecialRuleRefType.Garbage:
                        value = "GARBAGE";
                        break;
                    default:
                        XmlParser.ThrowSrgsException(SRID.InvalidSpecialRuleRef);
                        value = null;
                        break;
                }
                writer.WriteAttributeString("special", value);
            }
            if (_semanticKey != null)
            {
                writer.WriteAttributeString("sapi", "semantic-key", "http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions", _semanticKey);
            }
            if (_params != null)
            {
                writer.WriteAttributeString("sapi", "params", "http://schemas.microsoft.com/Speech/2002/06/SRGSExtensions", _params);
            }
            writer.WriteEndElement();
        }

        internal override void Validate(SrgsGrammar grammar)
        {
            bool flag = _params != null || _semanticKey != null;
            grammar._fContainsCode |= flag;
            grammar.HasSapiExtension |= flag;
            if (_uri != null)
            {
                string text = _uri.ToString();
                if (text[0] == '#')
                {
                    bool flag2 = false;
                    if (text.IndexOf("#grammar:dictation", StringComparison.Ordinal) == 0 || text.IndexOf("#grammar:dictation#spelling", StringComparison.Ordinal) == 0)
                    {
                        flag2 = true;
                    }
                    else
                    {
                        text = text.Substring(1);
                        foreach (SrgsRule rule in grammar.Rules)
                        {
                            if (rule.Id == text)
                            {
                                flag2 = true;
                                break;
                            }
                        }
                    }
                    if (!flag2)
                    {
                        XmlParser.ThrowSrgsException(SRID.UndefRuleRef, text);
                    }
                }
            }
            base.Validate(grammar);
        }

        internal override string DebuggerDisplayString()
        {
            StringBuilder stringBuilder = new StringBuilder("SrgsRuleRef");
            if (_uri != null)
            {
                stringBuilder.Append(" uri='");
                stringBuilder.Append(_uri.ToString());
                stringBuilder.Append("'");
            }
            else
            {
                stringBuilder.Append(" special='");
                stringBuilder.Append(_type.ToString());
                stringBuilder.Append("'");
            }
            return stringBuilder.ToString();
        }

        private void UriInit(Uri uri, string rule, string semanticKey, string initParameters)
        {
            Helpers.ThrowIfNull(uri, "uri");
            if (string.IsNullOrEmpty(rule))
            {
                _uri = uri;
            }
            else
            {
                _uri = new Uri(uri.ToString() + "#" + rule, UriKind.RelativeOrAbsolute);
            }
            _semanticKey = semanticKey;
            _params = initParameters;
        }
    }
}
