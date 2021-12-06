#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition
{
    internal class InternalGrammarData
    {
        internal ulong _grammarId;

        internal SapiGrammar _sapiGrammar;

        internal bool _grammarEnabled;

        internal float _grammarWeight;

        internal int _grammarPriority;

        internal InternalGrammarData(ulong grammarId, SapiGrammar sapiGrammar, bool enabled, float weight, int priority)
        {
            _grammarId = grammarId;
            _sapiGrammar = sapiGrammar;
            _grammarEnabled = enabled;
            _grammarWeight = weight;
            _grammarPriority = priority;
        }
    }
}
