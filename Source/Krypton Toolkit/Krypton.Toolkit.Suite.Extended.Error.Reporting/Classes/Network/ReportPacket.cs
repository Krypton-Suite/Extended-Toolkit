#pragma warning disable 1591
namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
	/// <summary>
    /// A class representing the JSON packet that is sent to the configured WebService
    /// We use DataContract serialization technique here for 2 reasons:
    /// 1 - To avoid going higher than .NET 4 Framework (most better options require >= 4.5)
    /// 2 - It would seem overkill to include another library like JSON.NET, just for this tiny requirement
    /// </summary>
    [DataContract]
    public class ReportPacket
    {
        [DataMember]
        public string AppName { get; set; }
        [DataMember]
        public string AppVersion { get; set; }
        [DataMember]
        public string ExceptionMessage { get; set; }
        [DataMember]
        public string ExceptionReport { get; set; }
    }
}
#pragma warning restore 1591