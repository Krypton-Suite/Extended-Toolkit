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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.GrammarBuilding
{
    internal sealed class GrammarBuilderDictation : GrammarBuilderBase
    {
        private readonly string _category;

        internal override string DebugSummary
        {
            get
            {
                string str = _category != null ? ":" + _category : string.Empty;
                return $"dictation{str}";
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
            Uri srgsUri = string.IsNullOrEmpty(_category) || !(_category == "spelling") ? new Uri("grammar:dictation", UriKind.RelativeOrAbsolute) : new Uri("grammar:dictation#spelling", UriKind.RelativeOrAbsolute);
            return elementFactory.CreateRuleRef(parent, srgsUri, null, null);
        }
    }
}