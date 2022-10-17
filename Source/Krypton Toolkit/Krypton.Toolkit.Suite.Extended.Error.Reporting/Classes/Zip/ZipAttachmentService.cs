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