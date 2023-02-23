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
    internal class ReportFileZipper
    {
        private readonly IFileService _fileService;
        private readonly ReportGenerator _reportGenerator;
        private readonly ExceptionReportInfo _info;

        public ReportFileZipper(IFileService fileService, ReportGenerator reportGenerator, ExceptionReportInfo info)
        {
            _fileService = fileService;
            _reportGenerator = reportGenerator;
            _info = info;
        }

        public FileSaveResult Save(string zipFilePath)
        {
            var fileExtension = _info.ReportTemplateFormat.ToString().ToLower().Replace("text", "txt");
            var reportPath = Path.Combine(Path.GetTempPath(), $"ExceptionReporter{Path.DirectorySeparatorChar}report.{fileExtension}");
            if (!Directory.Exists(reportPath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(reportPath)!);
            }

            var report = _reportGenerator.Generate();
            var saveResult = _fileService.Write(reportPath, report);
            if (saveResult.Saved)
            {
                var zipReport = new ZipAttachmentService(new Zipper(), new NoScreenShot(), _fileService);
                var savedPath = zipReport.CreateZipReport(_info, zipFilePath, new List<string> { reportPath });
                if (!File.Exists(savedPath))
                {   // we might be guilty of using exceptions to control flow here, but it's complying with existing design, so maybe we can let it slide
                    return new FileSaveResult { Exception = new IOException(savedPath) };
                }
            }
            return saveResult;
        }
    }
}