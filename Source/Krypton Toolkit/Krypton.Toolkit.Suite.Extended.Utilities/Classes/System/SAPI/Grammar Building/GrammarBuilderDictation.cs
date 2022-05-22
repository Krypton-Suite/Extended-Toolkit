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
    internal sealed class GrammarBuilderDictation : GrammarBuilderBase
    {
        private readonly string _category;

        internal override string DebugSummary
        {
            get
            {
                string str = (_category != null) ? (":" + _category) : string.Empty;
                return "dictation" + str;
            }
        }

        internal GrammarBuilderDictation()
            : this(null)
        {
        }

        internal GrammarBuilderDictation(string category)
        {
            _category = category;
        }

        public override bool Equals(object obj)
        {
            GrammarBuilderDictation grammarBuilderDictation = obj as GrammarBuilderDictation;
            if (grammarBuilderDictation == null)
            {
                return false;
            }
            return _category == grammarBuilderDictation._category;
        }

        public override int GetHashCode()
        {
            if (_category != null)
            {
                return _category.GetHashCode();
            }
            return 0;
        }

        internal override GrammarBuilderBase Clone()
        {
            return new GrammarBuilderDictation(_category);
        }

        internal override IElement CreateElement(IElementFactory elementFactory, IElement parent, IRule rule, IdentifierCollection ruleIds)
        {
            return CreateRuleRefToDictation(elementFactory, parent);
        }

        private IRuleRef CreateRuleRefToDictation(IElementFactory elementFactory, IElement parent)
        {
            Uri srgsUri = (string.IsNullOrEmpty(_category) || !(_category == "spelling")) ? new Uri("grammar:dictation", UriKind.RelativeOrAbsolute) : new Uri("grammar:dictation#spelling", UriKind.RelativeOrAbsolute);
            return elementFactory.CreateRuleRef(parent, srgsUri, null, null);
        }
    }
}