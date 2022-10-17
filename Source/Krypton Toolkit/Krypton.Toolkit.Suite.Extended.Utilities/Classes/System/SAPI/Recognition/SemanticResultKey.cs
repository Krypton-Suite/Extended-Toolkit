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
