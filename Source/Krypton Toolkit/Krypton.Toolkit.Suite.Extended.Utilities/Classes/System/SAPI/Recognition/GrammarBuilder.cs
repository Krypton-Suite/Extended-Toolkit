#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.GrammarBuilding;
using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;
using Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsCompiler;
using Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsGrammar;
using Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsParser;
using Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.Speech;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition
{
    [DebuggerDisplay("{DebugSummary}")]
    public class GrammarBuilder
    {
        private class InternalGrammarBuilder : BuilderElements
        {
            internal override GrammarBuilderBase Clone()
            {
                InternalGrammarBuilder internalGrammarBuilder = new InternalGrammarBuilder();
                foreach (GrammarBuilderBase item in base.Items)
                {
                    internalGrammarBuilder.Items.Add(item.Clone());
                }
                return internalGrammarBuilder;
            }

            internal override IElement CreateElement(IElementFactory elementFactory, IElement parent, IRule rule, IdentifierCollection ruleIds)
            {
                Collection<RuleElement> collection = new Collection<RuleElement>();
                CalcCount(null);
                Optimize(collection);
                foreach (RuleElement item in collection)
                {
                    base.Items.Add(item);
                }
                string text = ruleIds.CreateNewIdentifier("root");
                elementFactory.Grammar.Root = text;
                elementFactory.Grammar.TagFormat = SrgsTagFormat.KeyValuePairs;
                IRule rule2 = elementFactory.Grammar.CreateRule(text, RulePublic.False, RuleDynamic.NotSet, false);
                foreach (GrammarBuilderBase item2 in base.Items)
                {
                    if (item2 is RuleElement)
                    {
                        item2.CreateElement(elementFactory, rule2, rule2, ruleIds);
                    }
                }
                foreach (GrammarBuilderBase item3 in base.Items)
                {
                    if (!(item3 is RuleElement))
                    {
                        IElement element = item3.CreateElement(elementFactory, rule2, rule2, ruleIds);
                        if (element != null)
                        {
                            element.PostParse(rule2);
                            elementFactory.AddElement(rule2, element);
                        }
                    }
                }
                rule2.PostParse(elementFactory.Grammar);
                elementFactory.Grammar.PostParse(null);
                return null;
            }
        }

        private InternalGrammarBuilder _grammarBuilder;

        private CultureInfo _culture = CultureInfo.CurrentUICulture;

        /// <filterpriority>3</filterpriority>
        public string DebugShowPhrases => DebugSummary;

        public CultureInfo Culture
        {
            get
            {
                return _culture;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                _culture = value;
            }
        }

        internal virtual string DebugSummary
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (GrammarBuilderBase item in InternalBuilder.Items)
                {
                    if (stringBuilder.Length > 0)
                    {
                        stringBuilder.Append(' ');
                    }
                    stringBuilder.Append(item.DebugSummary);
                }
                return stringBuilder.ToString();
            }
        }

        internal BuilderElements InternalBuilder => _grammarBuilder;

        public GrammarBuilder()
        {
            _grammarBuilder = new InternalGrammarBuilder();
        }

        public GrammarBuilder(string phrase)
            : this()
        {
            Append(phrase);
        }

        public GrammarBuilder(string phrase, SubsetMatchingMode subsetMatchingCriteria)
            : this()
        {
            Append(phrase, subsetMatchingCriteria);
        }

        public GrammarBuilder(string phrase, int minRepeat, int maxRepeat)
            : this()
        {
            Append(phrase, minRepeat, maxRepeat);
        }

        public GrammarBuilder(GrammarBuilder builder, int minRepeat, int maxRepeat)
            : this()
        {
            Append(builder, minRepeat, maxRepeat);
        }

        public GrammarBuilder(Choices alternateChoices)
            : this()
        {
            Append(alternateChoices);
        }

        public GrammarBuilder(SemanticResultKey key)
            : this()
        {
            Append(key);
        }

        public GrammarBuilder(SemanticResultValue value)
            : this()
        {
            Append(value);
        }

        public void Append(string phrase)
        {
            Helpers.ThrowIfEmptyOrNull(phrase, "phrase");
            AddItem(new GrammarBuilderPhrase(phrase));
        }

        public void Append(string phrase, SubsetMatchingMode subsetMatchingCriteria)
        {
            Helpers.ThrowIfEmptyOrNull(phrase, "phrase");
            ValidateSubsetMatchingCriteriaArgument(subsetMatchingCriteria, "subsetMatchingCriteria");
            AddItem(new GrammarBuilderPhrase(phrase, subsetMatchingCriteria));
        }

        public void Append(string phrase, int minRepeat, int maxRepeat)
        {
            Helpers.ThrowIfEmptyOrNull(phrase, "phrase");
            ValidateRepeatArguments(minRepeat, maxRepeat, "minRepeat", "maxRepeat");
            GrammarBuilderPhrase grammarBuilderPhrase = new GrammarBuilderPhrase(phrase);
            if (minRepeat != 1 || maxRepeat != 1)
            {
                AddItem(new ItemElement(grammarBuilderPhrase, minRepeat, maxRepeat));
            }
            else
            {
                AddItem(grammarBuilderPhrase);
            }
        }

        public void Append(GrammarBuilder builder)
        {
            Helpers.ThrowIfNull(builder, "builder");
            Helpers.ThrowIfNull(builder.InternalBuilder, "builder.InternalBuilder");
            Helpers.ThrowIfNull(builder.InternalBuilder.Items, "builder.InternalBuilder.Items");
            foreach (GrammarBuilderBase item in builder.InternalBuilder.Items)
            {
                if (item == null)
                {
                    throw new ArgumentException(SR.Get(SRID.ArrayOfNullIllegal), "builder");
                }
            }
            List<GrammarBuilderBase> list = (builder == this) ? builder.Clone().InternalBuilder.Items : builder.InternalBuilder.Items;
            foreach (GrammarBuilderBase item2 in list)
            {
                AddItem(item2);
            }
        }

        public void Append(Choices alternateChoices)
        {
            Helpers.ThrowIfNull(alternateChoices, "alternateChoices");
            AddItem(alternateChoices.OneOf);
        }

        public void Append(SemanticResultKey key)
        {
            Helpers.ThrowIfNull(key, "builder");
            AddItem(key.SemanticKeyElement);
        }

        public void Append(SemanticResultValue value)
        {
            Helpers.ThrowIfNull(value, "builder");
            AddItem(value.Tag);
        }

        public void Append(GrammarBuilder builder, int minRepeat, int maxRepeat)
        {
            Helpers.ThrowIfNull(builder, "builder");
            ValidateRepeatArguments(minRepeat, maxRepeat, "minRepeat", "maxRepeat");
            Helpers.ThrowIfNull(builder.InternalBuilder, "builder.InternalBuilder");
            if (minRepeat != 1 || maxRepeat != 1)
            {
                AddItem(new ItemElement(builder.InternalBuilder.Items, minRepeat, maxRepeat));
            }
            else
            {
                Append(builder);
            }
        }

        public void AppendDictation()
        {
            AddItem(new GrammarBuilderDictation());
        }

        public void AppendDictation(string category)
        {
            Helpers.ThrowIfEmptyOrNull(category, "category");
            AddItem(new GrammarBuilderDictation(category));
        }

        public void AppendWildcard()
        {
            AddItem(new GrammarBuilderWildcard());
        }

        public void AppendRuleReference(string path)
        {
            Helpers.ThrowIfEmptyOrNull(path, "path");
            Uri uri;
            try
            {
                uri = new Uri(path, UriKind.RelativeOrAbsolute);
            }
            catch (UriFormatException ex)
            {
                throw new ArgumentException(ex.Message, path, ex);
            }
            AddItem(new GrammarBuilderRuleRef(uri, null));
        }

        public void AppendRuleReference(string path, string rule)
        {
            Helpers.ThrowIfEmptyOrNull(path, "path");
            Helpers.ThrowIfEmptyOrNull(rule, "rule");
            Uri uri;
            try
            {
                uri = new Uri(path, UriKind.RelativeOrAbsolute);
            }
            catch (UriFormatException ex)
            {
                throw new ArgumentException(ex.Message, path, ex);
            }
            AddItem(new GrammarBuilderRuleRef(uri, rule));
        }

        /// <filterpriority>2</filterpriority>
        public static GrammarBuilder operator +(string phrase, GrammarBuilder builder)
        {
            return Add(phrase, builder);
        }

        public static GrammarBuilder Add(string phrase, GrammarBuilder builder)
        {
            Helpers.ThrowIfNull(builder, "builder");
            GrammarBuilder grammarBuilder = new GrammarBuilder(phrase);
            grammarBuilder.Append(builder);
            return grammarBuilder;
        }

        /// <filterpriority>2</filterpriority>
        public static GrammarBuilder operator +(GrammarBuilder builder, string phrase)
        {
            return Add(builder, phrase);
        }

        public static GrammarBuilder Add(GrammarBuilder builder, string phrase)
        {
            Helpers.ThrowIfNull(builder, "builder");
            GrammarBuilder grammarBuilder = builder.Clone();
            grammarBuilder.Append(phrase);
            return grammarBuilder;
        }

        /// <filterpriority>2</filterpriority>
        public static GrammarBuilder operator +(Choices choices, GrammarBuilder builder)
        {
            return Add(choices, builder);
        }

        public static GrammarBuilder Add(Choices choices, GrammarBuilder builder)
        {
            Helpers.ThrowIfNull(choices, "choices");
            Helpers.ThrowIfNull(builder, "builder");
            GrammarBuilder grammarBuilder = new GrammarBuilder(choices);
            grammarBuilder.Append(builder);
            return grammarBuilder;
        }

        /// <filterpriority>2</filterpriority>
        public static GrammarBuilder operator +(GrammarBuilder builder, Choices choices)
        {
            return Add(builder, choices);
        }

        public static GrammarBuilder Add(GrammarBuilder builder, Choices choices)
        {
            Helpers.ThrowIfNull(builder, "builder");
            Helpers.ThrowIfNull(choices, "choices");
            GrammarBuilder grammarBuilder = builder.Clone();
            grammarBuilder.Append(choices);
            return grammarBuilder;
        }

        /// <filterpriority>2</filterpriority>
        public static GrammarBuilder operator +(GrammarBuilder builder1, GrammarBuilder builder2)
        {
            return Add(builder1, builder2);
        }

        public static GrammarBuilder Add(GrammarBuilder builder1, GrammarBuilder builder2)
        {
            Helpers.ThrowIfNull(builder1, "builder1");
            Helpers.ThrowIfNull(builder2, "builder2");
            GrammarBuilder grammarBuilder = builder1.Clone();
            grammarBuilder.Append(builder2);
            return grammarBuilder;
        }

        /// <filterpriority>2</filterpriority>
        public static implicit operator GrammarBuilder(string phrase)
        {
            return new GrammarBuilder(phrase);
        }

        /// <filterpriority>2</filterpriority>
        public static implicit operator GrammarBuilder(Choices choices)
        {
            return new GrammarBuilder(choices);
        }

        /// <filterpriority>2</filterpriority>
        public static implicit operator GrammarBuilder(SemanticResultKey semanticKey)
        {
            return new GrammarBuilder(semanticKey);
        }

        /// <filterpriority>2</filterpriority>
        public static implicit operator GrammarBuilder(SemanticResultValue semanticValue)
        {
            return new GrammarBuilder(semanticValue);
        }

        internal static void ValidateRepeatArguments(int minRepeat, int maxRepeat, string minParamName, string maxParamName)
        {
            if (minRepeat < 0)
            {
                throw new ArgumentOutOfRangeException(minParamName, SR.Get(SRID.InvalidMinRepeat, minRepeat));
            }
            if (minRepeat > maxRepeat)
            {
                throw new ArgumentException(SR.Get(SRID.MinGreaterThanMax), maxParamName);
            }
        }

        internal static void ValidateSubsetMatchingCriteriaArgument(SubsetMatchingMode subsetMatchingCriteria, string paramName)
        {
            if ((uint)subsetMatchingCriteria > 3u)
            {
                throw new ArgumentException(SR.Get(SRID.EnumInvalid, paramName), paramName);
            }
        }

        internal void CreateGrammar(IElementFactory elementFactory)
        {
            IdentifierCollection ruleIds = new IdentifierCollection();
            elementFactory.Grammar.Culture = Culture;
            _grammarBuilder.CreateElement(elementFactory, null, null, ruleIds);
        }

        internal void Compile(Stream stream)
        {
            Backend backend = new Backend();
            CustomGrammar cg = new CustomGrammar();
            SrgsElementCompilerFactory elementFactory = new SrgsElementCompilerFactory(backend, cg);
            CreateGrammar(elementFactory);
            backend.Optimize();
            using (StreamMarshaler streamBuffer = new StreamMarshaler(stream))
            {
                backend.Commit(streamBuffer);
            }
            stream.Position = 0L;
        }

        internal GrammarBuilder Clone()
        {
            GrammarBuilder grammarBuilder = new GrammarBuilder();
            grammarBuilder._grammarBuilder = (InternalGrammarBuilder)_grammarBuilder.Clone();
            return grammarBuilder;
        }

        private void AddItem(GrammarBuilderBase item)
        {
            InternalBuilder.Items.Add(item.Clone());
        }
    }
}
