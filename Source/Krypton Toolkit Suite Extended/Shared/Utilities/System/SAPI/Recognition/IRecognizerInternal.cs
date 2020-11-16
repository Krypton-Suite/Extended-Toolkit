namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition
{
	internal interface IRecognizerInternal
	{
		void SetGrammarState(Grammar grammar, bool enabled);

		void SetGrammarWeight(Grammar grammar, float weight);

		void SetGrammarPriority(Grammar grammar, int priority);

		Grammar GetGrammarFromId(ulong id);

		void SetDictationContext(Grammar grammar, string precedingText, string subsequentText);
	}
}
