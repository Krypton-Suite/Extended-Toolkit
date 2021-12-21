#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.Speech;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition
{
    public class DictationGrammar : Grammar
    {
        private static Uri _defaultDictationUri = new Uri("grammar:dictation");

        public DictationGrammar()
            : base(_defaultDictationUri, null, null)
        {
        }

        public DictationGrammar(string topic)
            : base(new Uri(topic, UriKind.RelativeOrAbsolute), null, null)
        {
        }

        public void SetDictationContext(string precedingText, string subsequentText)
        {
            if (base.State != GrammarState.Loaded)
            {
                throw new InvalidOperationException(SR.Get(SRID.GrammarNotLoaded));
            }
            base.Recognizer.SetDictationContext(this, precedingText, subsequentText);
        }
    }
}
