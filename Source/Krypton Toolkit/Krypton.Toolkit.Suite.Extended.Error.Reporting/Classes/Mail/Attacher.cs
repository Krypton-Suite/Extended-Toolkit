#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

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