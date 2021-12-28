#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SrgsParser
{
    internal interface IElementFactory
    {
        IGrammar Grammar
        {
            get;
        }

        IRuleRef Null
        {
            get;
        }

        IRuleRef Void
        {
            get;
        }

        IRuleRef Garbage
        {
            get;
        }

        void RemoveAllRules();

        IElementText CreateText(IElement parent, string value);

        IToken CreateToken(IElement parent, string content, string pronumciation, string display, float reqConfidence);

        IPropertyTag CreatePropertyTag(IElement parent);

        ISemanticTag CreateSemanticTag(IElement parent);

        IItem CreateItem(IElement parent, IRule rule, int minRepeat, int maxRepeat, float repeatProbability, float weight);

        IRuleRef CreateRuleRef(IElement parent, Uri srgsUri);

        IRuleRef CreateRuleRef(IElement parent, Uri srgsUri, string semanticKey, string parameters);

        void InitSpecialRuleRef(IElement parent, IRuleRef special);

        IOneOf CreateOneOf(IElement parent, IRule rule);

        ISubset CreateSubset(IElement parent, string text, MatchMode matchMode);

        string AddScript(IGrammar grammar, string rule, string code, string filename, int line);

        void AddScript(IGrammar grammar, string script, string filename, int line);

        void AddScript(IGrammar grammar, string rule, string code);

        void AddItem(IOneOf oneOf, IItem value);

        void AddElement(IRule rule, IElement value);

        void AddElement(IItem item, IElement value);
    }
}