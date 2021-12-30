namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
    internal class ZipAttachmentService : IZipAttachmentService
    {
        private IZipper Zipper { get; }
        private IScreenShooter ScreenShooter { get; }
        private IFileService FileService { get; }

        public ZipAttachmentService(IZipper zipper, IScreenShooter screenShooter, IFileService fileService)
        {
            Zipper = zipper;
            ScreenShooter = screenShooter;
            FileService = fileService;
        }

        public string CreateZipReport(ExceptionReportInfo reportInfo, IList<string> additionalFiles = null)
        {
            var zipFilePath = FileService.TempFile(reportInfo.AttachmentFilename);
            return CreateZipReport(reportInfo, zipFilePath, additionalFiles);
        }

        public string CreateZipReport(ExceptionReportInfo reportInfo, string zipFilePath, IList<string> additionalFiles = null)
        {
            if (string.IsNullOrWhiteSpace(zipFilePath)) return string.Empty;

            var files = new List<string>();
            if (reportInfo.FilesToAttach.Length > 0) files.AddRange(reportInfo.FilesToAttach);
            if (additionalFiles?.Count > 0) files.AddRange(additionalFiles);
            try
            {
                if (reportInfo.TakeScreenshot) files.Add(ScreenShooter.TakeScreenShot());
            }
            catch
            {
                /* ignored */
            }

            var filesThatExist = files.Where(f => FileService.Exists(f)).ToList();

            if (filesThatExist.Any())
                Zipper.Zip(zipFilePath, filesThatExist);
            else
                return string.Empty;

            return zipFilePath;
        }
    }
}