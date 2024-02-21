namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public static class Platform
    {
        private enum Os
        {
            Windows,
            Linux,
            MacOs,
            Other,
        };

        private static Os _thisOs = GetOs();

        private static Os GetOs()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return Os.Windows;
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return Os.Linux;
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return Os.MacOs;
            }

            return Os.Other;
        }

        /// <summary>
        /// Launch a web browser to a URL using a command appropriate for the operating system
        /// </summary>
        public static void LaunchWebBrowser(string url)
        {
            switch (_thisOs)
            {
                case Os.Windows:
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                    break;
                case Os.Linux:
                    Process.Start("xdg-open", url);
                    break;
                case Os.MacOs:
                    Process.Start("open", url);
                    break;
                default:
                    throw new InvalidOperationException("Cannot launch a web browser on this OS");
            }
        }
    }
}