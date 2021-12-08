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
