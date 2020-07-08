using System;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.GrammarBuilding
{
    internal sealed class GrammarBuilderRuleRef : GrammarBuilderBase
    {
        private readonly string _uri;

        internal override string DebugSummary => "#" + _uri;

        internal GrammarBuilderRuleRef(Uri uri, string rule)
        {
            _uri = uri.OriginalString + ((rule != null) ? ("#" + rule) : "");
        }

        private GrammarBuilderRuleRef(string sgrsUri)
        {
            _uri = sgrsUri;
        }

        public override bool Equals(object obj)
        {
            GrammarBuilderRuleRef grammarBuilderRuleRef = obj as GrammarBuilderRuleRef;
            if (grammarBuilderRuleRef == null)
            {
                return false;
            }
            return _uri == grammarBuilderRuleRef._uri;
        }

        public override int GetHashCode()
        {
            return _uri.GetHashCode();
        }

        internal override GrammarBuilderBase Clone()
        {
            return new GrammarBuilderRuleRef(_uri);
        }

        internal override IElement CreateElement(IElementFactory elementFactory, IElement parent, IRule rule, IdentifierCollection ruleIds)
        {
            Uri srgsUri = new Uri(_uri, UriKind.RelativeOrAbsolute);
            return elementFactory.CreateRuleRef(parent, srgsUri, null, null);
        }
    }
}