namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
	/// <summary>
    /// One who sends reports - generally separated by communication method
    /// </summary>
    public interface IReportSender
    {
        /// <summary>
        /// Send the report using implementation destination
        /// </summary>
        void Send(string report);

        /// <summary>
        /// One-word description of the sender type
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Message to describe connection impending
        /// </summary>
        string ConnectingMessage { get; }
    }
}