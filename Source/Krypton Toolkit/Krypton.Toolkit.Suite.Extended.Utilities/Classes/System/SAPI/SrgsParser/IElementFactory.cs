#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
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