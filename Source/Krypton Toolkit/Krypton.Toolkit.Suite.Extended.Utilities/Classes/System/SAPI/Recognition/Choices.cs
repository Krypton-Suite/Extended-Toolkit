#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.GrammarBuilding;
using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition
{
    [DebuggerDisplay("{_oneOf.DebugSummary}")]
    public class Choices
    {
        private OneOfElement _oneOf = new OneOfElement();

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
