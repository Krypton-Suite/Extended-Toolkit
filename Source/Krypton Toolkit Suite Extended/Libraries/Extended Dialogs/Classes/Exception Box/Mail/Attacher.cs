using System.Collections.Generic;
using System.Linq;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    internal class Attacher
    {
        private const string ZIP = ".zip";

        private readonly ExceptionReportInfo _config;

        public IFileService File { private get; set; } = new FileService();
        public IZipper Zipper { private get; set; } = new Zipper();
        public IScreenshotTaker ScreenshotTaker { private get; set; } = new ScreenshotTaker();

        public Attacher(ExceptionReportInfo config)
        {
            _config = config;
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
                if (_config.TakeScreenshot) files.Add(ScreenshotTaker.TakeScreenShot());
            }
            catch { /* ignored */ }

            var filesThatExist = files.Where(f => File.Exists(f)).ToList();

            // attach external zip files separately - admittedly weak detection using just file extension
            filesThatExist.Where(f => f.EndsWith(ZIP)).ToList().ForEach(attacher.Attach);

            // now zip & attach all specified files (ie config FilesToAttach) plus screenshot, if taken
            var filesToZip = filesThatExist.Where(f => !f.EndsWith(ZIP)).ToList();
            if (filesToZip.Any())
            {
                var zipFile = File.TempFile(_config.AttachmentFilename);
                Zipper.Zip(zipFile, filesToZip);
                attacher.Attach(zipFile);
            }
        }
    }
}