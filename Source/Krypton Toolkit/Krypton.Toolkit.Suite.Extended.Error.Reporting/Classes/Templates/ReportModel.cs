#pragma warning disable 1591
namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
	/// <summary>
    /// The top-level model/object passed to report templates
    /// </summary>
    public class ReportModel
    {
        public App App { get; set; }
        public Error Error { get; set; }
        public string SystemInfo { get; set; }
    }
}