#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsParser;

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