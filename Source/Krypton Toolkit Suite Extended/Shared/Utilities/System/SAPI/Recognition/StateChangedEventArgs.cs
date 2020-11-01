using System;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Recognition
{
    public class StateChangedEventArgs : EventArgs
    {
        private RecognizerState _recognizerState;

        public RecognizerState RecognizerState => _recognizerState;

        internal StateChangedEventArgs(RecognizerState recognizerState)
        {
            _recognizerState = recognizerState;
        }
    }
}
