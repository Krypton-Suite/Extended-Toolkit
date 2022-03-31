namespace Krypton.Toolkit.Suite.Extended.Error.Reporting;

public class Error
{
    //===== required variables =====

    /// <summary> DateTime of exception - defaults is 'Now' but would normally be set via config </summary>
    public DateTime When { get; set; } = DateTime.Now;

    /// <summary> Full stack trace string, including any and all inner exceptions and/or multiple exceptions </summary>
    public string FullStackTrace { get; set; }

    /// <summary> Optional - user input </summary>
    public string Explanation { get; set; }

    /// <summary> an ID to uniquely identify this particular report (defaults to a generated GUID) </summary>
    public string ID { get; set; } = Guid.NewGuid().ToString();

    //===== calculated variables
    public Exception Exception { get; set; }

    public string Message { get { return Exception.Message; } }

    public string Date { get { return When.ToShortDateString(); } }

    public string Time { get { return When.ToShortTimeString(); } }
    //=====
}