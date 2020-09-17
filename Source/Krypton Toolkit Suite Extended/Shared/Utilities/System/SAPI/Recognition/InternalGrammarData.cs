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
