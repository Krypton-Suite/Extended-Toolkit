using Krypton.Toolkit.Suite.Extended.Utilities.SystemInternal.Speech;
using System;

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
