#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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
    internal class ReportBuilder
    {
        private readonly ExceptionReportInfo _info;
        private readonly IAssemblyDigger _assemblyDigger;
        private readonly IStackTraceMaker _stackTraceMaker;
        private readonly ISysInfoResultMapper _sysInfoMapper;

        public ReportBuilder(ExceptionReportInfo info,
            IAssemblyDigger assemblyDigger,
            IStackTraceMaker stackTraceMaker,
            ISysInfoResultMapper sysInfoMapper)
        {
            _info = info;
            _assemblyDigger = assemblyDigger;
            _stackTraceMaker = stackTraceMaker;
            _sysInfoMapper = sysInfoMapper;
        }

        public string Report()
        {
            var renderer = new TemplateRenderer(this.ReportModel());
            return _info.ReportCustomTemplate.IsEmpty()
                ? renderer.RenderPreset(_info.ReportTemplateFormat)
                : renderer.RenderCustom(_info.ReportCustomTemplate);
        }

        public ReportModel ReportModel()
        {
            return new ReportModel
            {
                App = new App
                {
                    Title = _info.TitleText,
                    Name = _info.AppName,
                    Version = _info.AppVersion,
                    Region = _info.RegionInfo,
                    User = _info.UserName,
                    AssemblyRefs = _assemblyDigger.GetAssemblyRefs()
                },
                SystemInfo = _sysInfoMapper.SysInfoString(),
                Error = new Error
                {
                    Exception = _info.MainException,
                    Explanation = _info.UserExplanation,
                    When = _info.ExceptionDate,
                    FullStackTrace = _stackTraceMaker.FullStackTrace()
                }
            };
        }
    }
}