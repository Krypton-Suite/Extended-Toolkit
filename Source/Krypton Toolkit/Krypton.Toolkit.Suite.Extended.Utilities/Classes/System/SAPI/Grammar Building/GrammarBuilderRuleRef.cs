#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
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
    internal sealed class GrammarBuilderRuleRef : GrammarBuilderBase
    {
        private readonly string _uri;

        internal override string DebugSummary => $"#{_uri}";

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