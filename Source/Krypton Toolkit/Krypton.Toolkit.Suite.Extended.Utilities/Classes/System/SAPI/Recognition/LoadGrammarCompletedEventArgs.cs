#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

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
