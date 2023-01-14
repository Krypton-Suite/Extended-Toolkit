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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition
{
    [DebuggerDisplay("{_semanticKey.DebugSummary}")]
    public class SemanticResultKey
    {
        private readonly SemanticKeyElement _semanticKey;

        internal SemanticKeyElement SemanticKeyElement => _semanticKey;

        private SemanticResultKey(string semanticResultKey)
        {
            Helpers.ThrowIfEmptyOrNull(semanticResultKey, "semanticResultKey");
            _semanticKey = new SemanticKeyElement(semanticResultKey);
        }

        public SemanticResultKey(string semanticResultKey, params string[] phrases)
            : this(semanticResultKey)
        {
            Helpers.ThrowIfEmptyOrNull(semanticResultKey, "semanticResultKey");
            Helpers.ThrowIfNull(phrases, "phrases");
            foreach (string text in phrases)
            {
                _semanticKey.Add((string)text.Clone());
            }
        }

        public SemanticResultKey(string semanticResultKey, params GrammarBuilder[] builders)
            : this(semanticResultKey)
        {
            Helpers.ThrowIfEmptyOrNull(semanticResultKey, "semanticResultKey");
            Helpers.ThrowIfNull(builders, "phrases");
            foreach (GrammarBuilder grammarBuilder in builders)
            {
                _semanticKey.Add(grammarBuilder.Clone());
            }
        }

        public GrammarBuilder ToGrammarBuilder()
        {
            return new GrammarBuilder(this);
        }
    }
}
