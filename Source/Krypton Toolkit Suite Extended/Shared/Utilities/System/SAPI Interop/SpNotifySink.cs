namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    internal class SpNotifySink : ISpNotifySink
    {
        private EventNotify eventNotify;

        public SpNotifySink(EventNotify eventNotify)
        {
            this.eventNotify = eventNotify;
        }
    }
}