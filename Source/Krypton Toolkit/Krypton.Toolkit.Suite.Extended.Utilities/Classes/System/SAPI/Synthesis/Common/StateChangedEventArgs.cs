#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

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
