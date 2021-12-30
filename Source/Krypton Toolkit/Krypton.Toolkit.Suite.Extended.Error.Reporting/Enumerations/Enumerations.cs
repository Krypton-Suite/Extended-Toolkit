namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
    /// <summary>
    /// Output format of the report 
    /// </summary>
    /// <remarks>
    /// This needs to be in the 1st-level namespace to avoid forcing users to include 2 namespaces
    /// </remarks>
    public enum TemplateFormat
    {
        /// <summary> Plain text </summary>
        Text,
        /// <summary> HTML (5) </summary>
        Html,
        /// <summary> Standard markdown </summary>
        Markdown
    }

    /// <summary>
    /// The communication method used to send a report 
    /// </summary>
    public enum ReportSendMethod
    {
        ///<summary>
        /// No sending (default)
        /// </summary>
        None,

        ///<summary>
        /// Tries to use the Windows default Email client eg Outlook via SMTP
        /// If a compatible client isn't installed, it will not work, so there is some risk - but in that case, an
        /// error message will prompt the user to use the "Copy" feature and manually send the result
        /// <remarks>
        /// requires <see cref="ExceptionReportInfo.EmailReportAddress"/> to be set to a valid email</remarks>
        /// </summary>
        SimpleMAPI,

        ///<summary>
        /// Sends an Email via an SMTP server - requires other config (host/port etc) properties starting with 'Smtp'
        /// </summary>
        SMTP,

        /// <summary>
        /// WebService - requires a REST API server accepting content-type 'application/json' of type POST and a
        /// JSON packet containing the properties represented in the DataContract class 'ExceptionReportPacket'
        /// An example project demonstrating requirements is included in the fExceptionReporter.NET solution
        /// </summary>
        WebService
    }
}