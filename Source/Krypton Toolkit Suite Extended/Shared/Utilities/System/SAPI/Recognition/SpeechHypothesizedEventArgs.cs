using System;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition
{
    [Serializable]
    public class SpeechHypothesizedEventArgs : RecognitionEventArgs
    {
        internal SpeechHypothesizedEventArgs(RecognitionResult result)
            : base(result)
        {
        }
    }
}
