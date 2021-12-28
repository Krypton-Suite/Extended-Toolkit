#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop;
using Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsCompiler;
using Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsParser;
using Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.Speech;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition
{
    [Serializable]
    [DebuggerDisplay("{Text}")]
    public class RecognizedPhrase
    {
        private class RuleNode
        {
            internal Grammar _grammar;

            internal string _rule;

            internal string _name;

            internal uint _firstElement;

            internal uint _count;

            internal float _confidence;

            internal bool _hasName;

            internal RuleNode _next;

            internal RuleNode _child;

            internal RuleNode(Grammar grammar, string rule, float confidence, uint first, uint count)
            {
                _rule = (_name = rule);
                _firstElement = first;
                _count = count;
                _confidence = confidence;
                _grammar = grammar;
            }

            internal RuleNode Find(uint firstElement, uint count)
            {
                float num;
                if (count == 0)
                {
                    num = (float)firstElement - 0.5f;
                }
                else
                {
                    float num2 = firstElement;
                    num = num2 + (float)(count - 1);
                }
                for (RuleNode ruleNode = _child; ruleNode != null; ruleNode = ruleNode._next)
                {
                    float num4;
                    float num3;
                    if (ruleNode._count == 0)
                    {
                        num4 = (num3 = (float)ruleNode._firstElement - 0.5f);
                    }
                    else
                    {
                        num4 = ruleNode._firstElement;
                        num3 = num4 + (float)(ruleNode._count - 1);
                    }
                    if (num4 <= (float)firstElement && num3 >= num)
                    {
                        return ruleNode.Find(firstElement, count);
                    }
                }
                return this;
            }
        }

        private struct ResultPropertiesRef
        {
            internal string _name;

            internal SemanticValue _value;

            internal RuleNode _ruleNode;

            internal ResultPropertiesRef(string name, SemanticValue value, RuleNode ruleNode)
            {
                _name = name;
                _value = value;
                _ruleNode = ruleNode;
            }
        }

        internal SPSERIALIZEDPHRASE _serializedPhrase;

        internal byte[] _phraseBuffer;

        internal bool _isSapi53Header;

        internal bool _hasIPAPronunciation;

        private RecognitionResult _recoResult;

        private GrammarOptions _grammarOptions;

        private string _text;

        private float _confidence;

        private SemanticValue _semantics;

        private ReadOnlyCollection<RecognizedWordUnit> _words;

        private Collection<ReplacementText> _replacementText;

        [NonSerialized]
        private ulong _grammarId = ulong.MaxValue;

        [NonSerialized]
        private Grammar _grammar;

        private int _homophoneGroupId;

        private ReadOnlyCollection<RecognizedPhrase> _homophones;

        private Collection<SemanticValue> _dupItems;

        private string _smlContent;

        private const int SpVariantSubsetOffset = 16;

        public string Text
        {
            get
            {
                if (_text == null)
                {
                    Collection<ReplacementText> replacementWordUnits = ReplacementWordUnits;
                    int posInCollection = 0;
                    ReplacementText replacement;
                    int num = NextReplacementWord(replacementWordUnits, out replacement, ref posInCollection);
                    StringBuilder stringBuilder = new StringBuilder();
                    for (int i = 0; i < Words.Count; i++)
                    {
                        DisplayAttributes displayAttributes;
                        string text;
                        if (i == num)
                        {
                            displayAttributes = replacement.DisplayAttributes;
                            text = replacement.Text;
                            i += replacement.CountOfWords - 1;
                            num = NextReplacementWord(replacementWordUnits, out replacement, ref posInCollection);
                        }
                        else
                        {
                            displayAttributes = Words[i].DisplayAttributes;
                            text = Words[i].Text;
                        }
                        if ((displayAttributes & DisplayAttributes.ConsumeLeadingSpaces) != 0)
                        {
                            while (stringBuilder.Length > 0 && stringBuilder[stringBuilder.Length - 1] == ' ')
                            {
                                stringBuilder.Remove(stringBuilder.Length - 1, 1);
                            }
                        }
                        stringBuilder.Append(text);
                        if ((displayAttributes & DisplayAttributes.ZeroTrailingSpaces) == 0)
                        {
                            if ((displayAttributes & DisplayAttributes.OneTrailingSpace) != 0)
                            {
                                stringBuilder.Append(" ");
                            }
                            else if ((displayAttributes & DisplayAttributes.TwoTrailingSpaces) != 0)
                            {
                                stringBuilder.Append("  ");
                            }
                        }
                    }
                    _text = stringBuilder.ToString().Trim(' ');
                }
                return _text;
            }
        }

        public float Confidence => _confidence;

        public ReadOnlyCollection<RecognizedWordUnit> Words
        {
            get
            {
                if (_words == null)
                {
                    int ulCountOfElements = (int)_serializedPhrase.Rule.ulCountOfElements;
                    int elementsOffset = (int)_serializedPhrase.ElementsOffset;
                    List<RecognizedWordUnit> list = new List<RecognizedWordUnit>(ulCountOfElements);
                    int num = Marshal.SizeOf(typeof(SPSERIALIZEDPHRASEELEMENT));
                    GCHandle gCHandle = GCHandle.Alloc(_phraseBuffer, GCHandleType.Pinned);
                    try
                    {
                        IntPtr value = gCHandle.AddrOfPinnedObject();
                        for (int i = 0; i < ulCountOfElements; i++)
                        {
                            IntPtr ptr = new IntPtr((long)value + elementsOffset + i * num);
                            SPSERIALIZEDPHRASEELEMENT sPSERIALIZEDPHRASEELEMENT = (SPSERIALIZEDPHRASEELEMENT)Marshal.PtrToStructure(ptr, typeof(SPSERIALIZEDPHRASEELEMENT));
                            string text = null;
                            string lexicalForm = null;
                            string pronunciation = null;
                            if (sPSERIALIZEDPHRASEELEMENT.pszDisplayTextOffset != 0)
                            {
                                IntPtr ptr2 = new IntPtr((long)value + (int)sPSERIALIZEDPHRASEELEMENT.pszDisplayTextOffset);
                                text = Marshal.PtrToStringUni(ptr2);
                            }
                            if (sPSERIALIZEDPHRASEELEMENT.pszLexicalFormOffset != 0)
                            {
                                IntPtr ptr3 = new IntPtr((long)value + (int)sPSERIALIZEDPHRASEELEMENT.pszLexicalFormOffset);
                                lexicalForm = Marshal.PtrToStringUni(ptr3);
                            }
                            if (sPSERIALIZEDPHRASEELEMENT.pszPronunciationOffset != 0)
                            {
                                IntPtr ptr4 = new IntPtr((long)value + (int)sPSERIALIZEDPHRASEELEMENT.pszPronunciationOffset);
                                pronunciation = Marshal.PtrToStringUni(ptr4);
                                if (!_hasIPAPronunciation)
                                {
                                    pronunciation = _recoResult.ConvertPronunciation(pronunciation, _serializedPhrase.LangID);
                                }
                            }
                            DisplayAttributes displayAttributes = RecognizedWordUnit.SapiAttributesToDisplayAttributes(sPSERIALIZEDPHRASEELEMENT.bDisplayAttributes);
                            if (!_isSapi53Header)
                            {
                                sPSERIALIZEDPHRASEELEMENT.SREngineConfidence = 1f;
                            }
                            list.Add(new RecognizedWordUnit(text, sPSERIALIZEDPHRASEELEMENT.SREngineConfidence, pronunciation, lexicalForm, displayAttributes, new TimeSpan((long)sPSERIALIZEDPHRASEELEMENT.ulAudioTimeOffset * 10000L / 10000), new TimeSpan((long)sPSERIALIZEDPHRASEELEMENT.ulAudioSizeTime * 10000L / 10000)));
                        }
                        _words = new ReadOnlyCollection<RecognizedWordUnit>(list);
                    }
                    finally
                    {
                        gCHandle.Free();
                    }
                }
                return _words;
            }
        }

        public SemanticValue Semantics
        {
            get
            {
                if (_serializedPhrase.SemanticErrorInfoOffset != 0)
                {
                    ThrowInvalidSemanticInterpretationError();
                }
                if (_phraseBuffer == null)
                {
                    throw new NotSupportedException();
                }
                if (_semantics == null)
                {
                    CalcSemantics(Grammar);
                }
                return _semantics;
            }
        }

        public ReadOnlyCollection<RecognizedPhrase> Homophones
        {
            get
            {
                if (_phraseBuffer == null)
                {
                    throw new NotSupportedException();
                }
                if (_homophones == null)
                {
                    List<RecognizedPhrase> list = new List<RecognizedPhrase>(_recoResult.Alternates.Count);
                    for (int i = 0; i < _recoResult.Alternates.Count; i++)
                    {
                        if (_recoResult.Alternates[i]._homophoneGroupId == _homophoneGroupId && _recoResult.Alternates[i].Text != Text)
                        {
                            list.Add(_recoResult.Alternates[i]);
                        }
                    }
                    _homophones = new ReadOnlyCollection<RecognizedPhrase>(list);
                }
                return _homophones;
            }
        }

        public Grammar Grammar
        {
            get
            {
                if (_grammarId == ulong.MaxValue)
                {
                    throw new NotSupportedException(SR.Get(SRID.CantGetPropertyFromSerializedInfo, "Grammar"));
                }
                if (_grammar == null && _recoResult.Recognizer != null)
                {
                    _grammar = _recoResult.Recognizer.GetGrammarFromId(_grammarId);
                }
                return _grammar;
            }
        }

        public Collection<ReplacementText> ReplacementWordUnits
        {
            get
            {
                if (_replacementText == null)
                {
                    _replacementText = new Collection<ReplacementText>();
                    GCHandle gCHandle = GCHandle.Alloc(_phraseBuffer, GCHandleType.Pinned);
                    try
                    {
                        IntPtr value = gCHandle.AddrOfPinnedObject();
                        IntPtr intPtr = new IntPtr((long)value + _serializedPhrase.ReplacementsOffset);
                        int num = 0;
                        while (num < _serializedPhrase.cReplacements)
                        {
                            SPPHRASEREPLACEMENT sPPHRASEREPLACEMENT = (SPPHRASEREPLACEMENT)Marshal.PtrToStructure(intPtr, typeof(SPPHRASEREPLACEMENT));
                            string text = Marshal.PtrToStringUni(new IntPtr((long)value + sPPHRASEREPLACEMENT.pszReplacementText));
                            DisplayAttributes displayAttributes = RecognizedWordUnit.SapiAttributesToDisplayAttributes(sPPHRASEREPLACEMENT.bDisplayAttributes);
                            _replacementText.Add(new ReplacementText(displayAttributes, text, (int)sPPHRASEREPLACEMENT.ulFirstElement, (int)sPPHRASEREPLACEMENT.ulCountOfElements));
                            num++;
                            intPtr = (IntPtr)((long)intPtr + Marshal.SizeOf(typeof(SPPHRASEREPLACEMENT)));
                        }
                    }
                    finally
                    {
                        gCHandle.Free();
                    }
                }
                return _replacementText;
            }
        }

        public int HomophoneGroupId => _homophoneGroupId;

        internal ulong GrammarId => _grammarId;

        internal string SmlContent
        {
            get
            {
                if (_smlContent == null)
                {
                    ConstructSmlFromSemantics();
                }
                return _smlContent;
            }
        }

        internal RecognizedPhrase()
        {
        }

        public IXPathNavigable ConstructSmlFromSemantics()
        {
            if (!string.IsNullOrEmpty(_smlContent))
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(_smlContent);
                return xmlDocument;
            }
            if (_serializedPhrase.SemanticErrorInfoOffset != 0)
            {
                ThrowInvalidSemanticInterpretationError();
            }
            XmlDocument xmlDocument2 = new XmlDocument();
            XmlElement xmlElement = xmlDocument2.CreateElement("SML");
            NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
            numberFormatInfo.NumberDecimalDigits = 3;
            xmlDocument2.AppendChild(xmlElement);
            xmlElement.SetAttribute("text", Text);
            xmlElement.SetAttribute("utteranceConfidence", Confidence.ToString("f", numberFormatInfo));
            xmlElement.SetAttribute("confidence", Confidence.ToString("f", numberFormatInfo));
            if (Semantics.Count > 0)
            {
                AppendPropertiesSML(xmlDocument2, xmlElement, Semantics, numberFormatInfo);
            }
            else if (Semantics.Value != null)
            {
                XmlText newChild = xmlDocument2.CreateTextNode(Semantics.Value.ToString());
                xmlElement.AppendChild(newChild);
            }
            for (int i = 0; i < _recoResult.Alternates.Count; i++)
            {
                RecognizedPhrase recognizedPhrase = _recoResult.Alternates[i];
                recognizedPhrase.AppendSml(xmlDocument2, i + 1, numberFormatInfo);
            }
            _smlContent = xmlDocument2.OuterXml;
            return xmlDocument2;
        }

        internal static SPSERIALIZEDPHRASE GetPhraseHeader(IntPtr phraseBuffer, uint expectedPhraseSize, bool isSapi53Header)
        {
            SPSERIALIZEDPHRASE sPSERIALIZEDPHRASE;
            if (isSapi53Header)
            {
                sPSERIALIZEDPHRASE = (SPSERIALIZEDPHRASE)Marshal.PtrToStructure(phraseBuffer, typeof(SPSERIALIZEDPHRASE));
            }
            else
            {
                SPSERIALIZEDPHRASE_Sapi51 source = (SPSERIALIZEDPHRASE_Sapi51)Marshal.PtrToStructure(phraseBuffer, typeof(SPSERIALIZEDPHRASE_Sapi51));
                sPSERIALIZEDPHRASE = new SPSERIALIZEDPHRASE(source);
            }
            if (sPSERIALIZEDPHRASE.ulSerializedSize > expectedPhraseSize)
            {
                throw new FormatException(SR.Get(SRID.ResultInvalidFormat));
            }
            return sPSERIALIZEDPHRASE;
        }

        internal void InitializeFromSerializedBuffer(RecognitionResult recoResult, SPSERIALIZEDPHRASE serializedPhrase, IntPtr phraseBuffer, int phraseLength, bool isSapi53Header, bool hasIPAPronunciation)
        {
            _recoResult = recoResult;
            _isSapi53Header = isSapi53Header;
            _serializedPhrase = serializedPhrase;
            _confidence = _serializedPhrase.Rule.SREngineConfidence;
            _grammarId = _serializedPhrase.ullGrammarID;
            _homophoneGroupId = _serializedPhrase.wHomophoneGroupId;
            _hasIPAPronunciation = hasIPAPronunciation;
            _phraseBuffer = new byte[phraseLength];
            Marshal.Copy(phraseBuffer, _phraseBuffer, 0, phraseLength);
            _grammarOptions = ((recoResult.Grammar != null) ? recoResult.Grammar._semanticTag : GrammarOptions.KeyValuePairSrgs);
            CalcSemantics(recoResult.Grammar);
        }

        private void CalcSemantics(Grammar grammar)
        {
            if (_semantics == null && _serializedPhrase.SemanticErrorInfoOffset == 0)
            {
                GCHandle gCHandle = GCHandle.Alloc(_phraseBuffer, GCHandleType.Pinned);
                try
                {
                    IntPtr phraseBuffer = gCHandle.AddrOfPinnedObject();
                    if (!CalcILSemantics(phraseBuffer))
                    {
                        IList<RecognizedWordUnit> words = Words;
                        RuleNode ruleNode = ExtractRules(grammar, _serializedPhrase.Rule, phraseBuffer);
                        List<ResultPropertiesRef> properties = BuildRecoPropertyTree(_serializedPhrase, phraseBuffer, ruleNode, words, _isSapi53Header);
                        _semantics = RecursiveBuildSemanticProperties(words, properties, ruleNode, _grammarOptions & GrammarOptions.TagFormat, ref _dupItems);
                        _semantics.Value = TryExecuteOnRecognition(grammar, _recoResult, ruleNode._rule);
                    }
                }
                finally
                {
                    gCHandle.Free();
                }
            }
        }

        private bool CalcILSemantics(IntPtr phraseBuffer)
        {
            if ((_grammarOptions & GrammarOptions.SemanticInterpretation) != 0 || _grammarOptions == GrammarOptions.KeyValuePairs)
            {
                IList<RecognizedWordUnit> words = Words;
                _semantics = new SemanticValue("<ROOT>", null, _confidence);
                if (_serializedPhrase.PropertiesOffset != 0)
                {
                    RecursivelyExtractSemanticValue(phraseBuffer, (int)_serializedPhrase.PropertiesOffset, _semantics, words, _isSapi53Header, _grammarOptions & GrammarOptions.TagFormat);
                }
                return true;
            }
            return false;
        }

        private static List<ResultPropertiesRef> BuildRecoPropertyTree(SPSERIALIZEDPHRASE serializedPhrase, IntPtr phraseBuffer, RuleNode ruleTree, IList<RecognizedWordUnit> words, bool isSapi53Header)
        {
            List<ResultPropertiesRef> list = new List<ResultPropertiesRef>();
            if ((int)serializedPhrase.PropertiesOffset > 0)
            {
                RecursivelyExtractSemanticProperties(list, (int)serializedPhrase.PropertiesOffset, phraseBuffer, ruleTree, words, isSapi53Header);
            }
            return list;
        }

        private static SemanticValue RecursiveBuildSemanticProperties(IList<RecognizedWordUnit> words, List<ResultPropertiesRef> properties, RuleNode ruleTree, GrammarOptions semanticTag, ref Collection<SemanticValue> dupItems)
        {
            SemanticValue semanticValue = new SemanticValue(ruleTree._name, null, ruleTree._confidence);
            for (RuleNode ruleNode = ruleTree._child; ruleNode != null; ruleNode = ruleNode._next)
            {
                SemanticValue semanticValue2 = RecursiveBuildSemanticProperties(words, properties, ruleNode, semanticTag, ref dupItems);
                if (!ruleNode._hasName)
                {
                    foreach (KeyValuePair<string, SemanticValue> item in semanticValue2._dictionary)
                    {
                        InsertSemanticValueToDictionary(semanticValue, item.Key, item.Value, semanticTag, ref dupItems);
                    }
                    if (semanticValue2.Value != null)
                    {
                        if ((semanticTag & GrammarOptions.SemanticInterpretation) == 0 && semanticValue._valueFieldSet && !semanticValue.Value.Equals(semanticValue2.Value))
                        {
                            throw new InvalidOperationException(SR.Get(SRID.DupSemanticValue, ruleTree._name));
                        }
                        semanticValue.Value = semanticValue2.Value;
                        semanticValue._valueFieldSet = true;
                    }
                }
                else
                {
                    if (!semanticValue2._valueFieldSet && semanticValue2.Count == 0)
                    {
                        StringBuilder stringBuilder = new StringBuilder();
                        for (int i = 0; i < ruleNode._count; i++)
                        {
                            if (stringBuilder.Length > 0)
                            {
                                stringBuilder.Append(" ");
                            }
                            stringBuilder.Append(words[(int)ruleNode._firstElement + i].Text);
                        }
                        semanticValue2._valueFieldSet = true;
                        semanticValue2.Value = stringBuilder.ToString();
                    }
                    semanticValue._dictionary.Add(ruleNode._name, semanticValue2);
                }
            }
            foreach (ResultPropertiesRef property in properties)
            {
                if (property._ruleNode == ruleTree)
                {
                    InsertSemanticValueToDictionary(semanticValue, property._name, property._value, semanticTag, ref dupItems);
                }
            }
            Exception exceptionThrown = null;
            object newValue;
            bool flag = TryExecuteOnParse(ruleTree, semanticValue, words, out newValue, ref exceptionThrown);
            if (exceptionThrown != null)
            {
                throw exceptionThrown;
            }
            if (flag)
            {
                semanticValue._dictionary.Clear();
                semanticValue.Value = newValue;
                semanticValue._valueFieldSet = true;
            }
            return semanticValue;
        }

        private static void RecursivelyExtractSemanticProperties(List<ResultPropertiesRef> propertyList, int semanticsOffset, IntPtr phraseBuffer, RuleNode ruleTree, IList<RecognizedWordUnit> words, bool isSapi53Header)
        {
            IntPtr ptr = new IntPtr((long)phraseBuffer + semanticsOffset);
            SPSERIALIZEDPHRASEPROPERTY sPSERIALIZEDPHRASEPROPERTY = (SPSERIALIZEDPHRASEPROPERTY)Marshal.PtrToStructure(ptr, typeof(SPSERIALIZEDPHRASEPROPERTY));
            string propertyName;
            SemanticValue semanticValue = ExtractSemanticValueInformation(semanticsOffset, sPSERIALIZEDPHRASEPROPERTY, phraseBuffer, isSapi53Header, out propertyName);
            RuleNode ruleNode = ruleTree.Find(sPSERIALIZEDPHRASEPROPERTY.ulFirstElement, sPSERIALIZEDPHRASEPROPERTY.ulCountOfElements);
            if (propertyName == "SemanticKey")
            {
                ruleNode._name = (string)semanticValue.Value;
                ruleNode._hasName = true;
            }
            else
            {
                propertyList.Add(new ResultPropertiesRef(propertyName, semanticValue, ruleNode));
            }
            if (sPSERIALIZEDPHRASEPROPERTY.pFirstChildOffset != 0)
            {
                RecursivelyExtractSemanticProperties(propertyList, (int)sPSERIALIZEDPHRASEPROPERTY.pFirstChildOffset, phraseBuffer, ruleTree, words, isSapi53Header);
            }
            if (sPSERIALIZEDPHRASEPROPERTY.pNextSiblingOffset != 0)
            {
                RecursivelyExtractSemanticProperties(propertyList, (int)sPSERIALIZEDPHRASEPROPERTY.pNextSiblingOffset, phraseBuffer, ruleTree, words, isSapi53Header);
            }
        }

        private void RecursivelyExtractSemanticValue(IntPtr phraseBuffer, int semanticsOffset, SemanticValue semanticValue, IList<RecognizedWordUnit> words, bool isSapi53Header, GrammarOptions semanticTag)
        {
            IntPtr ptr = new IntPtr((long)phraseBuffer + semanticsOffset);
            SPSERIALIZEDPHRASEPROPERTY sPSERIALIZEDPHRASEPROPERTY = (SPSERIALIZEDPHRASEPROPERTY)Marshal.PtrToStructure(ptr, typeof(SPSERIALIZEDPHRASEPROPERTY));
            string propertyName;
            SemanticValue semanticValue2 = ExtractSemanticValueInformation(semanticsOffset, sPSERIALIZEDPHRASEPROPERTY, phraseBuffer, isSapi53Header, out propertyName);
            if (propertyName == "_value" && semanticValue != null)
            {
                semanticValue.Value = semanticValue2.Value;
                if (sPSERIALIZEDPHRASEPROPERTY.pFirstChildOffset != 0)
                {
                    semanticValue2 = semanticValue;
                }
            }
            else
            {
                InsertSemanticValueToDictionary(semanticValue, propertyName, semanticValue2, semanticTag, ref _dupItems);
            }
            if (sPSERIALIZEDPHRASEPROPERTY.pFirstChildOffset != 0)
            {
                RecursivelyExtractSemanticValue(phraseBuffer, (int)sPSERIALIZEDPHRASEPROPERTY.pFirstChildOffset, semanticValue2, words, isSapi53Header, semanticTag);
            }
            if (sPSERIALIZEDPHRASEPROPERTY.pNextSiblingOffset != 0)
            {
                RecursivelyExtractSemanticValue(phraseBuffer, (int)sPSERIALIZEDPHRASEPROPERTY.pNextSiblingOffset, semanticValue, words, isSapi53Header, semanticTag);
            }
        }

        private static void InsertSemanticValueToDictionary(SemanticValue semanticValue, string propertyName, SemanticValue thisSemanticValue, GrammarOptions semanticTag, ref Collection<SemanticValue> dupItems)
        {
            string text = propertyName;
            if ((text == "$" && semanticTag == GrammarOptions.MssV1) || (text == "=" && (semanticTag == GrammarOptions.KeyValuePairSrgs || semanticTag == GrammarOptions.KeyValuePairs)) || (thisSemanticValue.Count == -1 && semanticTag == GrammarOptions.W3cV1))
            {
                if ((semanticTag & GrammarOptions.SemanticInterpretation) == 0 && semanticValue._valueFieldSet && !semanticValue.Value.Equals(thisSemanticValue.Value))
                {
                    throw new InvalidOperationException(SR.Get(SRID.DupSemanticValue, semanticValue.KeyName));
                }
                semanticValue.Value = thisSemanticValue.Value;
                semanticValue._valueFieldSet = true;
            }
            else if (!semanticValue._dictionary.ContainsKey(text))
            {
                semanticValue._dictionary.Add(text, thisSemanticValue);
            }
            else if (!semanticValue._dictionary[text].Equals(thisSemanticValue))
            {
                if (semanticTag == GrammarOptions.KeyValuePairSrgs)
                {
                    throw new InvalidOperationException(SR.Get(SRID.DupSemanticKey, propertyName, semanticValue.KeyName));
                }
                int num = 0;
                do
                {
                    text = propertyName + string.Format(CultureInfo.InvariantCulture, "_{0}", new object[1]
                    {
                        num++
                    });
                }
                while (semanticValue._dictionary.ContainsKey(text));
                semanticValue._dictionary.Add(text, thisSemanticValue);
                if (dupItems == null)
                {
                    dupItems = new Collection<SemanticValue>();
                }
                SemanticValue item = semanticValue._dictionary[text];
                dupItems.Add(item);
            }
        }

        private static SemanticValue ExtractSemanticValueInformation(int semanticsOffset, SPSERIALIZEDPHRASEPROPERTY property, IntPtr phraseBuffer, bool isSapi53Header, out string propertyName)
        {
            bool flag = false;
            if (property.pszNameOffset != 0)
            {
                IntPtr ptr = new IntPtr((long)phraseBuffer + (int)property.pszNameOffset);
                propertyName = Marshal.PtrToStringUni(ptr);
            }
            else
            {
                propertyName = property.ulId.ToString(CultureInfo.InvariantCulture);
                flag = true;
            }
            object obj;
            if (property.pszValueOffset != 0)
            {
                IntPtr ptr2 = new IntPtr((long)phraseBuffer + (int)property.pszValueOffset);
                obj = Marshal.PtrToStringUni(ptr2);
                if (!isSapi53Header && flag && ((string)obj).Contains("$"))
                {
                    throw new NotSupportedException(SR.Get(SRID.NotSupportedWithThisVersionOfSAPI));
                }
            }
            else if (property.SpVariantSubset >= 0)
            {
                IntPtr ptr3 = new IntPtr((long)phraseBuffer + semanticsOffset + 16);
                switch (property.vValue)
                {
                    case 3:
                        obj = Marshal.ReadInt32(ptr3);
                        break;
                    case 19:
                        obj = Marshal.PtrToStructure(ptr3, typeof(uint));
                        break;
                    case 20:
                        obj = Marshal.ReadInt64(ptr3);
                        break;
                    case 21:
                        obj = Marshal.PtrToStructure(ptr3, typeof(ulong));
                        break;
                    case 4:
                        obj = Marshal.PtrToStructure(ptr3, typeof(float));
                        break;
                    case 5:
                        obj = Marshal.PtrToStructure(ptr3, typeof(double));
                        break;
                    case 11:
                        obj = (Marshal.ReadByte(ptr3) != 0);
                        break;
                    case 0:
                        obj = null;
                        break;
                    default:
                        throw new NotSupportedException(SR.Get(SRID.UnhandledVariant));
                }
            }
            else
            {
                obj = string.Empty;
            }
            return new SemanticValue(propertyName, obj, property.SREngineConfidence);
        }

        private static RuleNode ExtractRules(Grammar grammar, SPSERIALIZEDPHRASERULE rule, IntPtr phraseBuffer)
        {
            IntPtr ptr = new IntPtr((long)phraseBuffer + (int)rule.pszNameOffset);
            string text = Marshal.PtrToStringUni(ptr);
            Grammar grammar2 = grammar?.Find(text);
            if (grammar2 != null)
            {
                grammar = grammar2;
            }
            RuleNode ruleNode = new RuleNode(grammar, text, rule.SREngineConfidence, rule.ulFirstElement, rule.ulCountOfElements);
            if (rule.NextSiblingOffset != 0)
            {
                IntPtr ptr2 = new IntPtr((long)phraseBuffer + rule.NextSiblingOffset);
                SPSERIALIZEDPHRASERULE rule2 = (SPSERIALIZEDPHRASERULE)Marshal.PtrToStructure(ptr2, typeof(SPSERIALIZEDPHRASERULE));
                ruleNode._next = ExtractRules(grammar, rule2, phraseBuffer);
            }
            if (rule.FirstChildOffset != 0)
            {
                IntPtr ptr3 = new IntPtr((long)phraseBuffer + rule.FirstChildOffset);
                SPSERIALIZEDPHRASERULE rule3 = (SPSERIALIZEDPHRASERULE)Marshal.PtrToStructure(ptr3, typeof(SPSERIALIZEDPHRASERULE));
                ruleNode._child = ExtractRules(grammar, rule3, phraseBuffer);
            }
            return ruleNode;
        }

        private void ThrowInvalidSemanticInterpretationError()
        {
            if (!_isSapi53Header)
            {
                throw new NotSupportedException(SR.Get(SRID.NotSupportedWithThisVersionOfSAPI));
            }
            GCHandle gCHandle = GCHandle.Alloc(_phraseBuffer, GCHandleType.Pinned);
            try
            {
                IntPtr value = gCHandle.AddrOfPinnedObject();
                SPSEMANTICERRORINFO sPSEMANTICERRORINFO = (SPSEMANTICERRORINFO)Marshal.PtrToStructure((IntPtr)((long)value + (int)_serializedPhrase.SemanticErrorInfoOffset), typeof(SPSEMANTICERRORINFO));
                string text = Marshal.PtrToStringUni(new IntPtr((long)value + sPSEMANTICERRORINFO.pszSourceOffset));
                string text2 = Marshal.PtrToStringUni(new IntPtr((long)value + sPSEMANTICERRORINFO.pszDescriptionOffset));
                string text3 = Marshal.PtrToStringUni(new IntPtr((long)value + sPSEMANTICERRORINFO.pszScriptLineOffset));
                string message = string.Format(CultureInfo.InvariantCulture, "Error while evaluating semantic interpretation:\n  HRESULT:     {0:x}\n  Line:        {1}\n  Source:      {2}\n  Description: {3}\n  Script:      {4}\n", sPSEMANTICERRORINFO.hrResultCode, sPSEMANTICERRORINFO.ulLineNumber, text, text2, text3);
                throw new InvalidOperationException(message);
            }
            finally
            {
                gCHandle.Free();
            }
        }

        private static bool TryExecuteOnParse(RuleNode ruleRef, SemanticValue value, IList<RecognizedWordUnit> words, out object newValue, ref Exception exceptionThrown)
        {
            newValue = null;
            bool result = false;
            Grammar grammar = ruleRef._grammar;
            if (grammar != null && grammar._scripts != null)
            {
                try
                {
                    if (exceptionThrown != null)
                    {
                        if (!ExecuteOnError(grammar, ruleRef, exceptionThrown))
                        {
                            return result;
                        }
                        exceptionThrown = null;
                        return result;
                    }
                    result = ExecuteOnParse(grammar, ruleRef, value, words, out newValue);
                    return result;
                }
                catch (Exception ex)
                {
                    if (exceptionThrown == null)
                    {
                        exceptionThrown = ex;
                        try
                        {
                            if (!ExecuteOnError(grammar, ruleRef, exceptionThrown))
                            {
                                return result;
                            }
                            exceptionThrown = null;
                            return result;
                        }
                        catch (Exception ex2)
                        {
                            Exception ex3 = exceptionThrown = ex2;
                            return result;
                        }
                    }
                    return result;
                }
            }
            return result;
        }

        private static bool ExecuteOnParse(Grammar grammar, RuleNode ruleRef, SemanticValue value, IList<RecognizedWordUnit> words, out object newValue)
        {
            ScriptRef[] scripts = grammar._scripts;
            bool result = false;
            newValue = null;
            foreach (ScriptRef scriptRef in scripts)
            {
                if (!(ruleRef._rule == scriptRef._rule) || scriptRef._method != RuleMethodScript.onParse)
                {
                    continue;
                }
                RecognizedWordUnit[] array = new RecognizedWordUnit[ruleRef._count];
                for (int j = 0; j < ruleRef._count; j++)
                {
                    array[j] = words[j];
                }
                object[] parameters = new object[2]
                {
                    value,
                    array
                };
                if (grammar._proxy != null)
                {
                    Exception exceptionThrown;
                    newValue = grammar._proxy.OnParse(scriptRef._rule, scriptRef._sMethod, parameters, out exceptionThrown);
                    if (exceptionThrown != null)
                    {
                        throw exceptionThrown;
                    }
                }
                else
                {
                    MethodInfo onParse;
                    Grammar ruleInstance;
                    GetRuleInstance(grammar, scriptRef._rule, scriptRef._sMethod, out onParse, out ruleInstance);
                    newValue = onParse.Invoke(ruleInstance, parameters);
                }
                result = true;
            }
            return result;
        }

        private static bool ExecuteOnError(Grammar grammar, RuleNode ruleRef, Exception e)
        {
            ScriptRef[] scripts = grammar._scripts;
            bool result = false;
            foreach (ScriptRef scriptRef in scripts)
            {
                if (!(ruleRef._rule == scriptRef._rule) || scriptRef._method != RuleMethodScript.onError)
                {
                    continue;
                }
                object[] parameters = new object[1]
                {
                    e
                };
                if (grammar._proxy != null)
                {
                    Exception exceptionThrown;
                    grammar._proxy.OnError(scriptRef._rule, scriptRef._sMethod, parameters, out exceptionThrown);
                    if (exceptionThrown != null)
                    {
                        throw exceptionThrown;
                    }
                }
                else
                {
                    MethodInfo onParse;
                    Grammar ruleInstance;
                    GetRuleInstance(grammar, scriptRef._rule, scriptRef._sMethod, out onParse, out ruleInstance);
                    onParse.Invoke(ruleInstance, parameters);
                }
                result = true;
            }
            return result;
        }

        private static object TryExecuteOnRecognition(Grammar grammar, RecognitionResult result, string rootRule)
        {
            object result2 = result.Semantics.Value;
            if (grammar != null && grammar._scripts != null)
            {
                ScriptRef[] scripts = grammar._scripts;
                foreach (ScriptRef scriptRef in scripts)
                {
                    if (!(rootRule == scriptRef._rule) || scriptRef._method != RuleMethodScript.onRecognition)
                    {
                        continue;
                    }
                    object[] parameters = new object[1]
                    {
                        result
                    };
                    if (grammar._proxy != null)
                    {
                        Exception exceptionThrown;
                        result2 = grammar._proxy.OnRecognition(scriptRef._sMethod, parameters, out exceptionThrown);
                        if (exceptionThrown != null)
                        {
                            throw exceptionThrown;
                        }
                    }
                    else
                    {
                        Type type = grammar.GetType();
                        MethodInfo method = type.GetMethod(scriptRef._sMethod, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                        result2 = method.Invoke(grammar, parameters);
                    }
                }
            }
            return result2;
        }

        private static void GetRuleInstance(Grammar grammar, string rule, string method, out MethodInfo onParse, out Grammar ruleInstance)
        {
            Type type = grammar.GetType();
            Assembly assembly = type.Assembly;
            Type type2 = (rule == type.Name) ? type : GetTypeForRule(assembly, rule);
            if (type2 == null || !type2.IsSubclassOf(typeof(Grammar)))
            {
                throw new FormatException(SR.Get(SRID.RecognizerInvalidBinaryGrammar));
            }
            ruleInstance = ((type2 == type) ? grammar : ((Grammar)assembly.CreateInstance(type2.FullName)));
            onParse = ruleInstance.MethodInfo(method);
        }

        private static Type GetTypeForRule(Assembly assembly, string rule)
        {
            Type[] types = assembly.GetTypes();
            foreach (Type type in types)
            {
                if (type.Name == rule && type.IsPublic && type.IsSubclassOf(typeof(Grammar)))
                {
                    return type;
                }
            }
            return null;
        }

        private static int NextReplacementWord(Collection<ReplacementText> replacements, out ReplacementText replacement, ref int posInCollection)
        {
            if (posInCollection < replacements.Count)
            {
                replacement = replacements[posInCollection++];
                return replacement.FirstWordIndex;
            }
            replacement = null;
            return -1;
        }

        private void AppendSml(XmlDocument document, int i, NumberFormatInfo nfo)
        {
            XmlNode documentElement = document.DocumentElement;
            XmlElement xmlElement = document.CreateElement("alternate");
            documentElement.AppendChild(xmlElement);
            xmlElement.SetAttribute("Rank", i.ToString(CultureInfo.CurrentCulture));
            xmlElement.SetAttribute("text", Text);
            xmlElement.SetAttribute("utteranceConfidence", Confidence.ToString("f", nfo));
            xmlElement.SetAttribute("confidence", Confidence.ToString("f", nfo));
            if (_semantics.Value != null)
            {
                XmlText newChild = document.CreateTextNode(_semantics.Value.ToString());
                xmlElement.AppendChild(newChild);
            }
            AppendPropertiesSML(document, xmlElement, _semantics, nfo);
        }

        private void AppendPropertiesSML(XmlDocument document, XmlElement alternateNode, SemanticValue semanticsNode, NumberFormatInfo nfo)
        {
            if (semanticsNode != null)
            {
                foreach (KeyValuePair<string, SemanticValue> item in (IEnumerable<KeyValuePair<string, SemanticValue>>)semanticsNode)
                {
                    if (item.Key == "_attributes")
                    {
                        AppendAttributes(alternateNode, item.Value);
                        if (string.IsNullOrEmpty(alternateNode.InnerText) && semanticsNode.Value != null)
                        {
                            XmlText newChild = document.CreateTextNode(semanticsNode.Value.ToString());
                            alternateNode.AppendChild(newChild);
                        }
                    }
                    else
                    {
                        string name = item.Key;
                        if (_dupItems != null && _dupItems.Contains(item.Value))
                        {
                            name = RemoveTrailingNumber(item.Key);
                        }
                        XmlElement xmlElement = document.CreateElement(name);
                        xmlElement.SetAttribute("confidence", semanticsNode[item.Key].Confidence.ToString("f", nfo));
                        alternateNode.AppendChild(xmlElement);
                        if (item.Value.Count > 0)
                        {
                            if (item.Value.Value != null)
                            {
                                XmlText newChild2 = document.CreateTextNode(item.Value.Value.ToString());
                                xmlElement.AppendChild(newChild2);
                            }
                            AppendPropertiesSML(document, xmlElement, item.Value, nfo);
                        }
                        else if (item.Value.Value != null)
                        {
                            XmlText newChild3 = document.CreateTextNode(item.Value.Value.ToString());
                            xmlElement.AppendChild(newChild3);
                        }
                    }
                }
            }
        }

        private string RemoveTrailingNumber(string name)
        {
            return name.Substring(0, name.LastIndexOf('_'));
        }

        private void AppendAttributes(XmlElement propertyNode, SemanticValue semanticValue)
        {
            foreach (KeyValuePair<string, SemanticValue> item in (IEnumerable<KeyValuePair<string, SemanticValue>>)semanticValue)
            {
                if (propertyNode.Attributes[item.Key] == null)
                {
                    propertyNode.SetAttribute(item.Key, item.Value.Value.ToString());
                }
            }
        }
    }
}
