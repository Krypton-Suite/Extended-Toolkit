using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;

namespace Krypton.Toolkit.Extended.Common
{
    public class DevelopmentInformation
    {
        #region Variables
        private Version _internalVersion = Assembly.GetExecutingAssembly().GetName().Version, _assemblyVersion;

        private FileInfo _fileInfo;
        #endregion

        #region Properties
        /// <summary>Gets or sets the file information.</summary>
        /// <value>The file information.</value>
        public FileInfo FileInformation { get => _fileInfo; set => _fileInfo = value; }

        /// <summary>Gets or sets the assembly version.</summary>
        /// <value>The assembly version.</value>
        public Version AssemblyVersion { get => _assemblyVersion; set => _assemblyVersion = value; }

        /// <summary>Gets the internal version.</summary>
        /// <value>The internal version.</value>
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
                ExceptionHandler.CaptureException(exc);
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
                ExceptionHandler.CaptureException(exc);
            }
        }

        /// <summary>Gets the file infomation.</summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        public static FileInfo GetFileInfomation(string filePath) => new FileInfo(filePath);

        /// <summary>Gets the file version information.</summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        public static FileVersionInfo GetFileVersionInformation(string filePath) => FileVersionInfo.GetVersionInfo(filePath);

        /// <summary>Gets the file version.</summary>
        /// <param name="fileVersionInfo">The file version information.</param>
        /// <returns></returns>
        public static Version GetFileVersion(FileVersionInfo fileVersionInfo) => Version.Parse(fileVersionInfo.ProductVersion);

        /// <summary>Gets the assembly version.</summary>
        /// <param name="executablePath">The executable path.</param>
        /// <returns></returns>
        public static Version GetAssemblyVersion(Assembly executablePath) => executablePath.GetName().Version;
        #endregion
    }
}