using System;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition
{
    [Serializable]
    public class SpeechRecognitionRejectedEventArgs : RecognitionEventArgs
    {
        internal SpeechRecognitionRejectedEventArgs(RecognitionResult result)
            : base(result)
        {
        }
    }
}
