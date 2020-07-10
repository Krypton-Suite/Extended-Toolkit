using System;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis
{
    public class StateChangedEventArgs : EventArgs
    {
        private SynthesizerState _state;

        private SynthesizerState _previousState;

        public SynthesizerState State => _state;

        public SynthesizerState PreviousState => _previousState;

        internal StateChangedEventArgs(SynthesizerState state, SynthesizerState previousState)
        {
            _state = state;
            _previousState = previousState;
        }
    }
}
