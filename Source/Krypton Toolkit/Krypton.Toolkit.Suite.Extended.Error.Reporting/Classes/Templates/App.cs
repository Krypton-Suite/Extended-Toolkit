namespace Krypton.Toolkit.Suite.Extended.Error.Reporting;

public class App
{
    public string Name { get; set; }
    public string Version { get; set; }
    public string Region { get; set; } = CultureInfo.CurrentCulture.DisplayName;

    /// <summary> eg used in HTML lang attribute </summary>
    public string Language { get; set; } = "en";

    /// <summary> Title of the report </summary>
    public string Title { get; set; } = "Exception Report";

    /// <summary> optional - will not show field at all if empty </summary>
    public string User { get; set; }

    public IEnumerable<AssemblyRef> AssemblyRefs { get; set; }
}