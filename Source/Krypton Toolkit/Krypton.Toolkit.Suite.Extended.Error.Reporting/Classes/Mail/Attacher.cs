namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
    internal class Attacher
    {
        private const string ZIP = ".zip";

        private readonly ExceptionReportInfo _config;

        public IFileService FileService { private get; set; } = new FileService();
        public IZipper Zipper { private get; set; } = new Zipper();

        public IScreenShooter ScreenShooter { get; set; }

        public Attacher(ExceptionReportInfo config, IScreenShooter screenShooter)
        {
            _config = config;
            ScreenShooter = screenShooter;
        }

        public void AttachFiles(IAttach attacher)
        {
            var files = new List<string>();
            if (_config.FilesToAttach.Length > 0)
            {
                files.AddRange(_config.FilesToAttach);
            }

            try
            {
                if (_config.TakeScreenshot) files.Add(ScreenShooter.TakeScreenShot());
            }
            catch { /* ignored */ }

            var filesThatExist = files.Where(f => FileService.Exists(f)).ToList();

            // attach external zip files separately - admittedly weak detection using just file extension
            filesThatExist.Where(f => f.EndsWith(ZIP)).ToList().ForEach(attacher.Attach);

            // now zip & attach all specified files (ie config FilesToAttach) plus screenshot, if taken
            var filesToZip = filesThatExist.Where(f => !f.EndsWith(ZIP)).ToList();
            if (filesToZip.Any())
            {
                var zipFile = FileService.TempFile(_config.AttachmentFilename);
                Zipper.Zip(zipFile, filesToZip);
                attacher.Attach(zipFile);
            }
        }
    }
}