using System;
using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public interface IAboutStripped
    {
        string ApplicationName { get; set; }

        Icon ApplicationIcon { get; set; }

        Bitmap ApplicationIconImage { get; set; }

        string AuthourName { get; set; }

        Version ApplicationVersion { get; set; }

        string InstallLocation { get; set; }
    }
}