#region MIT License
/*
 *
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

using System.Globalization;
using System.IO;

namespace Krypton.Toolkit.Suite.Extended.Common
{
    public class DevelopmentInformation
    {
        #region Variables
        private Version _internalVersion = Assembly.GetExecutingAssembly().GetName().Version, _assemblyVersion;
        private FileInfo _fileInfo;
        #endregion

        #region Properties
        public Version AssemblyVersion { get => _assemblyVersion; set => _assemblyVersion = value; }

        public Version InternalVersion => _internalVersion;

        #endregion

        #region Constructors
        /// <summary>Initializes a new instance of the <see cref="DevelopmentInformation"/> class.</summary>
        public DevelopmentInformation()
        {

        }
        #endregion

        #region Methods                
        /// <summary>
        /// Sets the build information.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="state">The state.</param>
        public static void SetBuildInformation(KryptonForm target, DevelopmentState state = DevelopmentState.BETA)
        {
            DevelopmentInformation developmentInformation = new DevelopmentInformation();

            try
            {
                switch (state)
                {
                    case DevelopmentState.PREALPHA:
                        target.TextExtra = $"({CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month + 1)} {DateTime.Now.Year.ToString()} Update - Build: {developmentInformation.InternalVersion.Build.ToString()} - Pre-Alpha)";
                        break;
                    case DevelopmentState.ALPHA:
                        target.TextExtra = $"({CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month + 1)} {DateTime.Now.Year.ToString()} Update - Build: {developmentInformation.InternalVersion.Build.ToString()} - Alpha)";
                        break;
                    case DevelopmentState.BETA:
                        target.TextExtra = $"({CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month + 1)} {DateTime.Now.Year.ToString()} Update - Build: {developmentInformation.InternalVersion.Build.ToString()} - Beta)";
                        break;
                    case DevelopmentState.RTM:
                        target.TextExtra = $"({CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month + 1)} {DateTime.Now.Year.ToString()} Update - Build: {developmentInformation.InternalVersion.Build.ToString()} - RTM)";
                        break;
                    case DevelopmentState.CURRENT:
                        target.TextExtra = $"({CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month + 1)} {DateTime.Now.Year.ToString()} Update - Build: {developmentInformation.InternalVersion.Build.ToString()} - Current Build)";
                        break;
                    case DevelopmentState.EOL:
                        target.TextExtra = $"({CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month + 1)} {DateTime.Now.Year.ToString()} Update - Build: {developmentInformation.InternalVersion.Build.ToString()} - End of Life)";
                        break;
                }
            }
            catch (Exception exc)
            {
                ExceptionCapture.CaptureException(exc);
            }
        }

        /// <summary>
        /// Sets the build information.
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="assembly">The assembly.</param>
        /// <param name="state">The state.</param>
        public static void SetBuildInformation(KryptonForm target, Assembly assembly, DevelopmentState state = DevelopmentState.BETA)
        {
            DevelopmentInformation developmentInformation = new DevelopmentInformation();

            try
            {
                switch (state)
                {
                    case DevelopmentState.PREALPHA:
                        target.TextExtra = $"({CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month + 1)} {DateTime.Now.Year.ToString()} Update - Build: {GetAssemblyVersion(assembly).Build.ToString()} - Pre-Alpha)";
                        break;
                    case DevelopmentState.ALPHA:
                        target.TextExtra = $"({CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month + 1)} {DateTime.Now.Year.ToString()} Update - Build: {GetAssemblyVersion(assembly).Build.ToString()} - Alpha)";
                        break;
                    case DevelopmentState.BETA:
                        target.TextExtra = $"({CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month + 1)} {DateTime.Now.Year.ToString()} Update - Build: {GetAssemblyVersion(assembly).Build.ToString()} - Beta)";
                        break;
                    case DevelopmentState.RTM:
                        target.TextExtra = $"({CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month + 1)} {DateTime.Now.Year.ToString()} Update - Build: {GetAssemblyVersion(assembly).Build.ToString()} - RTM)";
                        break;
                    case DevelopmentState.CURRENT:
                        target.TextExtra = $"({CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month + 1)} {DateTime.Now.Year.ToString()} Update - Build: {GetAssemblyVersion(assembly).Build.ToString()} - Current Build)";
                        break;
                    case DevelopmentState.EOL:
                        target.TextExtra = $"({CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month + 1)} {DateTime.Now.Year.ToString()} Update - Build: {GetAssemblyVersion(assembly).Build.ToString()} - End of Life)";
                        break;
                }
            }
            catch (Exception exc)
            {
                ExceptionCapture.CaptureException(exc);
            }
        }

        public static FileInfo GetFileInfomation(string filePath) => new FileInfo(filePath);

        public static FileVersionInfo GetFileVersionInformation(string filePath) => FileVersionInfo.GetVersionInfo(filePath);

        public static Version GetFileVersion(FileVersionInfo fileVersionInfo) => Version.Parse(fileVersionInfo.ProductVersion);

        public static Version GetAssemblyVersion(Assembly executablePath) => executablePath.GetName().Version;

        #endregion
    }
}