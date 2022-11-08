#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;
using Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsParser;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsCompiler
{
    internal class SrgsElementCompilerFactory : IElementFactory
    {
        private Backend _backend;

        private GrammarElement _grammar;

        private CustomGrammar _cg;

        IGrammar IElementFactory.Grammar => _grammar;

        IRuleRef IElementFactory.Null => RuleRef.Null;

        IRuleRef IElementFactory.Void => RuleRef.Void;

        IRuleRef IElementFactory.Garbage => RuleRef.Garbage;

        internal SrgsElementCompilerFactory(Backend backend, CustomGrammar cg)
        {
            _backend = backend;
            _cg = cg;
            _grammar = new GrammarElement(backend, cg);
        }

        void IElementFactory.RemoveAllRules()
        {
        }

        IPropertyTag IElementFactory.CreatePropertyTag(IElement parent)
        {
            return new PropertyTag((ParseElementCollection)parent, _backend);
        }

        ISemanticTag IElementFactory.CreateSemanticTag(IElement parent)
        {
            return new SemanticTag((ParseElementCollection)parent, _backend);
        }

        IElementText IElementFactory.CreateText(IElement parent, string value)
        {
            return null;
        }

        IToken IElementFactory.CreateToken(IElement parent, string content, string pronunciation, string display, float reqConfidence)
        {
            ParseToken((ParseElementCollection)parent, content, pronunciation, display, reqConfidence);
            return null;
        }

        IItem IElementFactory.CreateItem(IElement parent, IRule rule, int minRepeat, int maxRepeat, float repeatProbability, float weight)
        {
            return new Item(_backend, (Rule)rule, minRepeat, maxRepeat, repeatProbability, weight);
        }

        IRuleRef IElementFactory.CreateRuleRef(IElement parent, Uri srgsUri)
        {
            throw new NotImplementedException();
        }

        IRuleRef IElementFactory.CreateRuleRef(IElement parent, Uri srgsUri, string semanticKey, string parameters)
        {
            return new RuleRef((ParseElementCollection)parent, _backend, srgsUri, _grammar.UndefRules, semanticKey, parameters);
        }

        void IElementFactory.InitSpecialRuleRef(IElement parent, IRuleRef specialRule)
        {
            ((RuleRef)specialRule).InitSpecialRuleRef(_backend, (ParseElementCollection)parent);
        }

        IOneOf IElementFactory.CreateOneOf(IElement parent, IRule rule)
        {
            return new OneOf((Rule)rule, _backend);
        }

        ISubset IElementFactory.CreateSubset(IElement parent, string text, MatchMode mode)
        {
            return new Subset((ParseElementCollection)parent, _backend, text, mode);
        }

        void IElementFactory.AddScript(IGrammar grammar, string rule, string code)
        {
            ((GrammarElement)grammar).AddScript(rule, code);
        }

        string IElementFactory.AddScript(IGrammar grammar, string rule, string code, string filename, int line)
        {
            if (line >= 0)
            {
                if (_cg._language == "C#")
                {
                    return string.Format(CultureInfo.InvariantCulture, "#line {0} \"{1}\"\n{2}", new object[3]
                    {
                        line.ToString(CultureInfo.InvariantCulture),
                        filename,
                        code
                    });
                }
                return string.Format(CultureInfo.InvariantCulture, "#ExternalSource (\"{1}\",{0}) \n{2}\n#End ExternalSource\n", new object[3]
                {
                    line.ToString(CultureInfo.InvariantCulture),
                    filename,
                    code
                });
            }
            return code;
        }

        void IElementFactory.AddScript(IGrammar grammar, string script, string filename, int line)
        {
            if (line >= 0)
            {
                if (_cg._language == "C#")
                {
                    _cg._script.Append("#line ");
                    _cg._script.Append(line.ToString(CultureInfo.InvariantCulture));
                    _cg._script.Append(" \"");
                    _cg._script.Append(filename);
                    _cg._script.Append("\"\n");
                    _cg._script.Append(script);
                }
                else
                {
                    _cg._script.Append("#ExternalSource (");
                    _cg._script.Append(" \"");
                    _cg._script.Append(filename);
                    _cg._script.Append("\",");
                    _cg._script.Append(line.ToString(CultureInfo.InvariantCulture));
                    _cg._script.Append(")\n");
                    _cg._script.Append(script);
                    _cg._script.Append("#End #ExternalSource\n");
                }
            }
            else
            {
                _cg._script.Append(script);
            }
        }

        void IElementFactory.AddItem(IOneOf oneOf, IItem item)
        {
        }

        void IElementFactory.AddElement(IRule rule, IElement value)
        {
        }

        void IElementFactory.AddElement(IItem item, IElement value)
        {
        }

        private void ParseToken(ParseElementCollection parent, string sToken, string pronunciation, string display, float reqConfidence)
        {
            int requiredConfidence = parent?._confidence ?? 0;
            sToken = Backend.NormalizeTokenWhiteSpace(sToken);
            if (string.IsNullOrEmpty(sToken))
            {
                return;
            }
            parent._confidence = 0;
            if (reqConfidence < 0f || reqConfidence.Equals(0.5f))
            {
                parent._confidence = 0;
            }
            else if ((double)reqConfidence < 0.5)
            {
                parent._confidence = -1;
            }
            else
            {
                parent._confidence = 1;
            }
            if (pronunciation != null || display != null)
            {
                string text = EscapeToken(sToken);
                string text2 = (display == null) ? text : EscapeToken(display);
                if (pronunciation != null)
                {
                    OneOf oneOf = (pronunciation.IndexOf(';') >= 0) ? new OneOf(parent._rule, _backend) : null;
                    int num = 0;
                    int num2 = 0;
                    while (num < pronunciation.Length)
                    {
                        num2 = pronunciation.IndexOf(';', num);
                        if (num2 == -1)
                        {
                            num2 = pronunciation.Length;
                        }
                        string text3 = pronunciation.Substring(num, num2 - num);
                        string text4 = null;
                        switch (_backend.Alphabet)
                        {
                            case AlphabetType.Sapi:
                                text4 = PhonemeConverter.ConvertPronToId(text3, _grammar.Backend.LangId);
                                break;
                            case AlphabetType.Ipa:
                                text4 = text3;
                                PhonemeConverter.ValidateUpsIds(text4);
                                break;
                            case AlphabetType.Ups:
                                text4 = PhonemeConverter.UpsConverter.ConvertPronToId(text3);
                                break;
                        }
                        string sWord = string.Format(CultureInfo.InvariantCulture, "/{0}/{1}/{2};", new object[3]
                        {
                            text2,
                            text,
                            text4
                        });
                        if (oneOf != null)
                        {
                            oneOf.AddArc(_backend.WordTransition(sWord, 1f, requiredConfidence));
                        }
                        else
                        {
                            parent.AddArc(_backend.WordTransition(sWord, 1f, requiredConfidence));
                        }
                        num = num2 + 1;
                    }
                    ((IElement)oneOf)?.PostParse((IElement)parent);
                }
                else
                {
                    string sWord2 = string.Format(CultureInfo.InvariantCulture, "/{0}/{1};", new object[2]
                    {
                        text2,
                        text
                    });
                    parent.AddArc(_backend.WordTransition(sWord2, 1f, requiredConfidence));
                }
            }
            else
            {
                parent.AddArc(_backend.WordTransition(sToken, 1f, requiredConfidence));
            }
        }

        private static string EscapeToken(string sToken)
        {
            if (sToken.IndexOf("\\/", StringComparison.Ordinal) == -1)
            {
                return sToken;
            }
            char[] array = sToken.ToCharArray();
            char[] array2 = new char[array.Length * 2];
            int length = 0;
            int num = 0;
            while (num < array.Length)
            {
                if (array[num] == '\\' || array[num] == '/')
                {
                    array2[length++] = '\\';
                }
                array2[length++] = array[num++];
            }
            return new string(array2, 0, length);
        }
    }
}