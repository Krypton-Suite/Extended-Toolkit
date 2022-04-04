namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
    internal interface IZipAttachmentService
    {
        /// <summary>
        /// Create Zip file
        /// filepath = %TEMP% + ExceptionReportInfo.AttachmentFilename
        /// </summary>
        /// <returns>
        /// Path to zip file.
        /// Empty if not saved.
        /// </returns>
        string CreateZipReport(ExceptionReportInfo reportInfo, IList<string> additionalFilesToAttach);

        /// <summary>
        /// Create Zip file
        /// </summary>
        /// <returns>
        /// Path to zip file.
        /// Empty if not saved.
        /// </returns>
        string CreateZipReport(ExceptionReportInfo reportInfo, string filepath, IList<string> additionalFilesToAttach);
    }
}