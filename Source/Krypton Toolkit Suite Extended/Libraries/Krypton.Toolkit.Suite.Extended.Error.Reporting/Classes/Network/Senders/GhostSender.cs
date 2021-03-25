namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
    internal class GhostSender : IReportSender
    {
        public void Send(string report)
        {
            // do nothing
        }

        public string Description { get; } = "";
        public string ConnectingMessage { get; } = "";
    }
}