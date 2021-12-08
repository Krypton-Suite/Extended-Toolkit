#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
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

        public Version InternalVersion { get => _internalVersion; }
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
                        target.TextExtra = $"({ CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month + 1) } { DateTime.Now.Year.ToString() } Update - Build: { developmentInformation.InternalVersion.Build.ToString() } - Pre-Alpha)";
                        break;
                    case DevelopmentState.ALPHA:
                        target.TextExtra = $"({ CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month + 1) } { DateTime.Now.Year.ToString() } Update - Build: { developmentInformation.InternalVersion.Build.ToString() } - Alpha)";
                        break;
                    case DevelopmentState.BETA:
                        target.TextExtra = $"({ CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month + 1) } { DateTime.Now.Year.ToString() } Update - Build: { developmentInformation.InternalVersion.Build.ToString() } - Beta)";
                        break;
                    case DevelopmentState.RTM:
                        target.TextExtra = $"({ CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month + 1) } { DateTime.Now.Year.ToString() } Update - Build: { developmentInformation.InternalVersion.Build.ToString() } - RTM)";
                        break;
                    case DevelopmentState.CURRENT:
                        target.TextExtra = $"({ CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month + 1) } { DateTime.Now.Year.ToString() } Update - Build: { developmentInformation.InternalVersion.Build.ToString() } - Current Build)";
                        break;
                    case DevelopmentState.EOL:
                        target.TextExtra = $"({ CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month + 1) } { DateTime.Now.Year.ToString() } Update - Build: { developmentInformation.InternalVersion.Build.ToString() } - End of Life)";
                        break;
                }
            }
            catch (Exception exc)
            {
                KryptonMessageBox.Show(exc.Message, "Exception Caught", MessageBoxButtons.OK, KryptonMessageBoxIcon.ERROR);
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
                        target.TextExtra = $"({ CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month + 1) } { DateTime.Now.Year.ToString() } Update - Build: { GetAssemblyVersion(assembly).Build.ToString() } - Pre-Alpha)";
                        break;
                    case DevelopmentState.ALPHA:
                        target.TextExtra = $"({ CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month + 1) } { DateTime.Now.Year.ToString() } Update - Build: { GetAssemblyVersion(assembly).Build.ToString() } - Alpha)";
                        break;
                    case DevelopmentState.BETA:
                        target.TextExtra = $"({ CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month + 1) } { DateTime.Now.Year.ToString() } Update - Build: { GetAssemblyVersion(assembly).Build.ToString() } - Beta)";
                        break;
                    case DevelopmentState.RTM:
                        target.TextExtra = $"({ CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month + 1) } { DateTime.Now.Year.ToString() } Update - Build: { GetAssemblyVersion(assembly).Build.ToString() } - RTM)";
                        break;
                    case DevelopmentState.CURRENT:
                        target.TextExtra = $"({ CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month + 1) } { DateTime.Now.Year.ToString() } Update - Build: { GetAssemblyVersion(assembly).Build.ToString() } - Current Build)";
                        break;
                    case DevelopmentState.EOL:
                        target.TextExtra = $"({ CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Now.Month + 1) } { DateTime.Now.Year.ToString() } Update - Build: { GetAssemblyVersion(assembly).Build.ToString() } - End of Life)";
                        break;
                }
            }
            catch (Exception exc)
            {
                KryptonMessageBox.Show(exc.Message, "Exception Caught", MessageBoxButtons.OK, KryptonMessageBoxIcon.ERROR);
            }
        }

        public static FileInfo GetFileInfomation(string filePath) => new FileInfo(filePath);

        public static FileVersionInfo GetFileVersionInformation(string filePath) => FileVersionInfo.GetVersionInfo(filePath);

        public static Version GetFileVersion(FileVersionInfo fileVersionInfo) => Version.Parse(fileVersionInfo.ProductVersion);

        public static Version GetAssemblyVersion(Assembly executablePath) => executablePath.GetName().Version;

        #endregion
    }
}