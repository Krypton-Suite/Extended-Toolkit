using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Mail;
using System.Reflection;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    /// <summary>
    /// A bag of configuration and data
    /// </summary>
    public class ExceptionReportInfo
    {
        private readonly List<Exception> _exceptions = new List<Exception>();

        /// <summary>
        /// The Main (usually the 'only') exception, which is the subject of this exception 'report'
        /// Setting this property will clear any previously set exceptions
        /// <remarks>
        /// If multiple top-level exceptions are required, use <see cref="SetExceptions(IEnumerable{Exception})"/> instead
        /// </remarks>
        /// </summary>
        public Exception MainException
        {
            get { return _exceptions.Count > 0 ? _exceptions[0] : new Exception("Empty Exception"); }
            set
            {
                _exceptions.Clear();
                if (value != null)
                {
                    _exceptions.Add(value);
                }
            }
        }

        public Exception[] Exceptions
        {
            get { return _exceptions.ToArray(); }
        }

        /// <summary>
        /// Add multiple exceptions
        /// <remarks>
        /// Note: Showing multiple exceptions is a special-case requirement
        /// To set only 1 top-level exception use <see cref="MainException"/> property instead
        /// </remarks>
        /// </summary>
        public void SetExceptions(IEnumerable<Exception> exceptions)
        {
            _exceptions.Clear();
            _exceptions.AddRange(exceptions);
        }

        /// <summary>
        /// Override the Exception.Message property
        /// ie a custom message to show in place of the Exception Message
        /// NB this can also be set in the 1st parameter of <see cref="ExceptionReporter.Show(string, Exception[])"/>
        /// </summary>
        public string CustomMessage { get; set; }

        #region SMTP settings

        public string SmtpUsername { get; set; }
        public string SmtpPassword { get; set; }
        public string SmtpFromAddress { get; set; } = "";
        public string SmtpServer { get; set; }

        /// <summary>
        /// Uses default port if not set (ie 25)
        /// </summary>
        public int SmtpPort { get; set; }

        /// <summary>
        /// Whether SMTP uses SSL
        /// </summary>
        public bool SmtpUseSsl { get; set; }

        /// <summary>
        /// Use default credentials of the user (alternatively set false supply SmtpUsername/SmtpPassword)
        /// </summary>
        public bool SmtpUseDefaultCredentials { get; set; }

        /// <summary>
        /// Priority of the Email message
        /// </summary>
        public MailPriority SmtpMailPriority { get; set; } = MailPriority.Normal;

        #endregion

        /// <summary>
        /// The name of the application calling the exception report
        /// </summary>
        public string AppName { get; set; }

        /// <summary>
        /// The version of the application calling the exception report
        /// set automatically by <see cref="ReportGenerator"/> from either the assembly or ApplicationDeployment
        /// if deployed using ClickOnce
        /// </summary>
        public string AppVersion { get; set; }

        /// <summary>
        /// Region information - set automatically by <see cref="ReportGenerator"/>
        /// </summary>
        public string RegionInfo { get; set; }

        /// <summary>
        /// User Name shown in a report.
        /// If this value is empty, the value and any label/field will be hidden 
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Date/time of the exception being raised - will be set automatically by <see cref="ReportGenerator"/>
        /// depending on <see cref="ExceptionDateKind"/>
        /// </summary>
        public DateTime ExceptionDate { get; set; }

        /// <summary>
        /// Whether to report the date/time of the exception in local or Coordinated Universal Time (UTC).
        /// Defaults to UTC
        /// </summary>
        public DateTimeKind ExceptionDateKind { get; set; } = DateTimeKind.Utc;

        /// <summary>
        /// The text filled in by the user of the Exception Reporter dialog, to explain the error
        /// If this value is empty, the value and any label/field will be hidden
        /// </summary>
        public string UserExplanation { get; set; }

        /// <summary>
        /// The calling assembly of the running application
        /// If not set, will default to
        /// <see cref="Assembly.GetEntryAssembly()"/> ??
        /// <see cref="Assembly.GetCallingAssembly()"/>
        /// </summary>
        public Assembly AppAssembly { get; set; }

        /// <summary>
        /// The company/owner of the running application.
        /// Used in the dialog label that reads "...please contact {0} support" and the Email button "Email {0}"
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Show/hide *General* tab in dialog
        /// </summary>
        public bool ShowGeneralTab { get; set; } = true;

        /// <summary>
        /// Show/hide *Exceptions* tab in dialog
        /// </summary>
        public bool ShowExceptionsTab { get; set; } = true;


        private bool _showSysInfoTab = true;
        /// <summary>
        /// Show/hide *System Information* (SysInfo) tab in dialog
        /// <remarks> ignored in Mono </remarks> 
        /// </summary>
        public bool ShowSysInfoTab
        {
            get { return !ExceptionReporter.IsRunningMono() && _showSysInfoTab; }
            set { _showSysInfoTab = value; }
        }

        private bool _showAssembliesTab = true;
        /// <summary>
        /// Show/hide *Assemblies* tab in dialog
        /// <remarks> ignored in Mono </remarks>
        /// </summary>
        public bool ShowAssembliesTab
        {
            get { return !ExceptionReporter.IsRunningMono() && _showAssembliesTab; }
            set { _showAssembliesTab = value; }
        }

        /// <summary>
        /// Email address used to send the report via email
        /// Appears in the 'to:' field in the default email client if
        /// <see cref="SendMethod"/> is <see cref="ReportSendMethod.SimpleMAPI"/>
        /// </summary>
        public string EmailReportAddress { get; set; } = "";

        /// <summary>
        /// Email object
        /// Appears in the 'subject:' field in the default email client if
        /// <see cref="SendMethod"/> is <see cref="ReportSendMethod.SimpleMAPI"/>
        /// </summary>
        public string EmailReportSubject { get; set; } = "";

        /// <summary>
        /// The URL to be used to submit the exception report to a RESTful WebService
        /// Requires <see cref="SendMethod"/> is set to <see cref="ReportSendMethod.WebService"/>
        /// </summary>
        public string WebServiceUrl { get; set; }

        /// <summary>
        /// Timeout (in seconds) for the WebService
        /// </summary>
        public int WebServiceTimeout { get; set; } = 15;

        private bool _showEmailButton = true;
        /// <summary>
        /// Whether or not to show/display the button labelled "Email"
        /// Will assume false if <see cref="SendMethod"/> is <see cref="ReportSendMethod.None"/>
        /// </summary>
        public bool ShowEmailButton
        {
            get { return SendMethod != ReportSendMethod.None && _showEmailButton; }
            set { _showEmailButton = value; }
        }

        /// <summary>
        /// The title of the main ExceptionReporter dialog
        /// </summary>
        public string TitleText { get; set; } = "Error Report";

        /// <summary>
        /// Background color of the dialog
        /// </summary>
        public Color BackgroundColour { get; set; } = Color.WhiteSmoke;

        /// <summary>
        /// The font size of the user input text box
        /// </summary>
        public float UserExplanationFontSize { get; set; } = 12f;

        /// <summary>
        /// Take a screenshot automatically when attaching <see cref="ExceptionReporter.Show(System.Exception[])"/>
        /// which will then be available if sending an email using the ExceptionReporter dialog functionality
        /// </summary>
        public bool TakeScreenshot { get; set; } = false;

        /// <summary>
        /// The method used to send the report
        /// </summary>
        public ReportSendMethod SendMethod { get; set; } = ReportSendMethod.None;

        /// <summary>
        /// Show the Exception Reporter as a "TopMost" window (ie TopMost property on a WinForm)
        /// This can be quite important in some environments (eg Office Addins) where it might get covered by other UI
        /// </summary>
        public bool TopMost { get; set; } = false;

        /// <summary>
        /// Any additional files to attach to the outgoing email report (SMTP or SimpleMAPI) 
        /// This is in addition to the automatically attached screenshot, if configured.
        /// All files (except those already with .zip extension) will be added into a single zip file and
        /// attached to the email
        /// </summary>
        public string[] FilesToAttach { get; set; } = { };

        private string _attachmentFilename = "ExceptionReport";
        /// <summary> Gets or sets the attachment filename </summary>
        /// <value>The attachment filename, extension .zip applied automatically if not provided</value>
        public string AttachmentFilename
        {
            get { return _attachmentFilename.ToLower().EndsWith(".zip") ? _attachmentFilename : _attachmentFilename + ".zip"; }
            set { _attachmentFilename = value; }
        }

        /// <summary>
        /// The text to show in the label that prompts the user to input any relevant message
        /// </summary>
        public string UserExplanationLabel { get; set; } = DefaultLabelMessages.DefaultExplanationLabel;

        public string ContactMessageTop { get; set; } = DefaultLabelMessages.DefaultContactMessageTop;

        /// <summary> 
        /// Show buttons in the "flat" (non 3D) style
        /// </summary>
        public bool ShowFlatButtons { get; set; } = true;

        /// <summary>
        /// Show the button that gives user the option to switch back to "Less Detail".
        /// NB This was previously fully toggle but we now always show "More Detail" and optionally show "Less Detail"
        /// </summary>
        public bool ShowLessDetailButton { get; set; }

        /// <summary>
        /// Show the tabbed ("More Detailed") view to user straight away
        /// The purpose of the non-tabbed ("Less Details") view was to avoid scaring users, so the full detaild view is
        /// best reserved for advanced or technical users
        /// </summary>
        public bool ShowFullDetail { get; set; }

        /// <summary>
        /// Whether to show relevant icons on the buttons
        /// </summary>
        public bool ShowButtonIcons { get; set; }

        /// <summary>
        /// Format of the final report - Defaults to TemplateFormat.Text
        /// </summary>
        public TemplateFormat ReportTemplateFormat { get; set; } = TemplateFormat.Text;

        /// <summary>
        /// A custom/user Handlebar template (Handlebars is almost identical to Mustache) - see https://handlebarsjs.com
        /// to use instead of the supplied presets
        /// A populated model will be passed to the template <see cref="ReportModel"/>
        /// See Templates/ReportTemplate.text for example 
        /// </summary>
        public string ReportCustomTemplate { get; set; }

        /// <summary>
        /// convenience method
        /// </summary>
        /// <returns>true if configuration is set to use SimpleMAPI</returns>
        public bool IsSimpleMAPI()
        {
            return SendMethod == ReportSendMethod.SimpleMAPI;
        }
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
        /// An example project doing exactly what is required is included in the ExceptionReporter.NET solution
        /// </summary>
        WebService
    }

    internal static class DefaultLabelMessages
    {
        public const string DefaultExplanationLabel = "Please enter a brief explanation of events leading up to this exception";
        public const string DefaultContactMessageTop = "The following details can be used to obtain support for this application";
    }
}