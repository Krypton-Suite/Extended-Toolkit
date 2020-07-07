namespace Krypton.Toolkit.Suite.Extended.Utilities.System.GrammarBuilding
{
    internal sealed class GrammarBuilderWildcard : GrammarBuilderBase
    {
        internal override string DebugSummary => "*";

        internal GrammarBuilderWildcard()
        {
        }

        public override bool Equals(object obj)
        {
            GrammarBuilderWildcard grammarBuilderWildcard = obj as GrammarBuilderWildcard;
            return grammarBuilderWildcard != null;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        internal override GrammarBuilderBase Clone()
        {
            return new GrammarBuilderWildcard();
        }

        internal override IElement CreateElement(IElementFactory elementFactory, IElement parent, IRule rule, IdentifierCollection ruleIds)
        {
            IRuleRef garbage = elementFactory.Garbage;
            elementFactory.InitSpecialRuleRef(parent, garbage);
            return garbage;
        }
    }
}