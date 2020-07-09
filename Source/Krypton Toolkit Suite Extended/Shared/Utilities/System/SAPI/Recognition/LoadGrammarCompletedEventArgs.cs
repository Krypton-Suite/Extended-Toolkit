using System.ComponentModel;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition
{
	public class LoadGrammarCompletedEventArgs : AsyncCompletedEventArgs
	{
		private Grammar _grammar;

		public Grammar Grammar => _grammar;

		internal LoadGrammarCompletedEventArgs(Grammar grammar, Exception error, bool cancelled, object userState)
			: base(error, cancelled, userState)
		{
			_grammar = grammar;
		}
	}
}
