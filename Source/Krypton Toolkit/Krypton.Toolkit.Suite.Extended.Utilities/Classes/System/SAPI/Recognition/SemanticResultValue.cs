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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition
{
    [DebuggerDisplay("{_tag.DebugSummary}")]
    public class SemanticResultValue
    {
        private TagElement _tag;

        internal TagElement Tag => _tag;

        public SemanticResultValue(object value)
        {
            Helpers.ThrowIfNull(value, "value");
            _tag = new TagElement(value);
        }

        public SemanticResultValue(string phrase, object value)
        {
            Helpers.ThrowIfEmptyOrNull(phrase, "phrase");
            Helpers.ThrowIfNull(value, "value");
            _tag = new TagElement(new GrammarBuilderPhrase((string)phrase.Clone()), value);
        }

        public SemanticResultValue(GrammarBuilder builder, object value)
        {
            Helpers.ThrowIfNull(builder, "builder");
            Helpers.ThrowIfNull(value, "value");
            _tag = new TagElement(builder.Clone(), value);
        }

        public GrammarBuilder ToGrammarBuilder()
        {
            return new GrammarBuilder(this);
        }
    }
}
