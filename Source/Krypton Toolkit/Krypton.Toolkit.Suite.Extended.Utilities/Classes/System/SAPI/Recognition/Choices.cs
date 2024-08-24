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
    [DebuggerDisplay("{_oneOf.DebugSummary}")]
    public class Choices
    {
        private OneOfElement _oneOf = new();

        internal OneOfElement OneOf => _oneOf;

        public Choices()
        {
        }

        public Choices(params string[] phrases)
        {
            Helpers.ThrowIfNull(phrases, "phrases");
            Add(phrases);
        }

        public Choices(params GrammarBuilder[] alternateChoices)
        {
            Helpers.ThrowIfNull(alternateChoices, "alternateChoices");
            Add(alternateChoices);
        }

        public void Add(params string[] phrases)
        {
            Helpers.ThrowIfNull(phrases, "phrases");
            foreach (string text in phrases)
            {
                Helpers.ThrowIfEmptyOrNull(text, "phrase");
                _oneOf.Add(text);
            }
        }

        public void Add(params GrammarBuilder[] alternateChoices)
        {
            Helpers.ThrowIfNull(alternateChoices, "alternateChoices");
            foreach (GrammarBuilder grammarBuilder in alternateChoices)
            {
                Helpers.ThrowIfNull(grammarBuilder, "alternateChoice");
                _oneOf.Items.Add(new ItemElement(grammarBuilder));
            }
        }

        public GrammarBuilder ToGrammarBuilder()
        {
            return new GrammarBuilder(this);
        }
    }
}
