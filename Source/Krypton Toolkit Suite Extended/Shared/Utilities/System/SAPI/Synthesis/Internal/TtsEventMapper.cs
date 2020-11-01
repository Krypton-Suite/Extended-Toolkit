namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis
{
    internal abstract class TtsEventMapper : ITtsEventSink
    {
        private ITtsEventSink _sink;

        internal TtsEventMapper(ITtsEventSink sink)
        {
            _sink = sink;
        }

        protected virtual void SendToOutput(TTSEvent evt)
        {
            if (_sink != null)
            {
                _sink.AddEvent(evt);
            }
        }

        public virtual void AddEvent(TTSEvent evt)
        {
            SendToOutput(evt);
        }

        public virtual void FlushEvent()
        {
            if (_sink != null)
            {
                _sink.FlushEvent();
            }
        }
    }
}