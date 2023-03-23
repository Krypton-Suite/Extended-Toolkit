﻿#region MIT License
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

#if NET462_OR_GREATER
using System.Deployment.Application;
#endif

#pragma warning disable 1591
namespace Krypton.Toolkit.Suite.Extended.Error.Reporting
{
    /// <summary>
    /// ReportGenerator is the entry point to use 'ExceptionReporter.NET' to retrieve the report/data only.
    /// ie if the user only requires the report info but has no need to use the show or send functionality available
    /// </summary>
    public class ReportGenerator
    {
        private readonly ExceptionReportInfo _info;
        private readonly List<SysInfoResult> _sysInfoResults = new List<SysInfoResult>();

        /// <summary>
        /// Initialises some ExceptionReportInfo properties related to the application/system
        /// </summary>
        /// <param name="reportInfo">an ExceptionReportInfo, can be pre-populated with config
        /// however 'base' properties such as MachineName</param>
        public ReportGenerator(ExceptionReportInfo reportInfo)
        {
            // this is going to be a dev/learning mistake - fail fast and hard
            _info = reportInfo ?? throw new ArgumentNullException(nameof(reportInfo));
            if (_info.AppAssembly == null)
            {
                _info.AppAssembly = Assembly.GetEntryAssembly() ?? Assembly.GetCallingAssembly();
            }

            _info.AppName = _info.AppName.IsEmpty() ? _info.AppAssembly.GetName().Name : _info.AppName;
            _info.AppVersion = _info.AppVersion.IsEmpty() ? GetAppVersion() : _info.AppVersion;
            _info.ExceptionDate = _info.ExceptionDateKind != DateTimeKind.Local ? DateTime.UtcNow : DateTime.Now;
        }

        private string GetAppVersion()
        {
#if NET462_OR_GREATER
            return ApplicationDeployment.IsNetworkDeployed ?
                ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString() : _info.AppAssembly.GetName().Version.ToString();
#else
			return Assembly.GetExecutingAssembly().ImageRuntimeVersion.ToString();
#endif
        }

        /// <summary>
        /// Generate the exception report
        /// </summary>
        /// <remarks>
        /// Generate doesn't do a lot beside feed the builder - this is just to keep the builder free of
        /// too many concrete (system-reliant) dependencies
        /// </remarks>
        /// <returns><see cref="ReportModel"/>object</returns>
        public string Generate()
        {
            var sysInfoResults = GetOrFetchSysInfoResults();

            var build = new ReportBuilder(_info,
                new AssemblyDigger(_info.AppAssembly),
                new StackTraceMaker(_info.Exceptions),
                new SysInfoResultMapper(sysInfoResults));

            return build.Report();
        }

        /// <summary>
        /// get system information and memoize
        /// </summary>
        internal IEnumerable<SysInfoResult> GetOrFetchSysInfoResults()
        {
            if (_sysInfoResults.Count == 0)
            {
                _sysInfoResults.AddRange(CreateSysInfoResults());
            }

            return _sysInfoResults.AsReadOnly();
        }

        private static IEnumerable<SysInfoResult> CreateSysInfoResults()
        {
            var retriever = new SysInfoRetriever();
            var results = new List<SysInfoResult>
            {
                retriever.Retrieve(SysInfoQueries.OperatingSystem).Filter(
                    new[]
                    {
                        "CodeSet",
                        "CurrentTimeZone",
                        "FreePhysicalMemory",
                        "OSArchitecture",
                        "OSLanguage",
                        "Version"
                    }),
                retriever.Retrieve(SysInfoQueries.Machine).Filter(
                    new[]
                    {
                        "TotalPhysicalMemory",
                        "Manufacturer",
                        "Model"
                    })
            };
            return results;
        }
    }
}