namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis
{
    internal interface ITtsEventSink
    {
        void AddEvent(TTSEvent evt);

        void FlushEvent();
    }
}