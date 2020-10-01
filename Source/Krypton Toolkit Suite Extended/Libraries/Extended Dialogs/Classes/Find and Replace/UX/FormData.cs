using Krypton.Toolkit.Suite.Extended.Dialogs.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    public class FormData
    {
        public bool IsFindOnly { get; set; }
        public string Dir { get; set; }
        public bool IncludeSubDirectories { get; set; }
        public string FileMask { get; set; }
        public string ExcludeFileMask { get; set; }
        public string ExcludeDir { get; set; }
        public string FindText { get; set; }
        public bool IsCaseSensitive { get; set; }
        public bool IsRegEx { get; set; }
        public bool SkipBinaryFileDetection { get; set; }
        public bool ShowEncoding { get; set; }
        public bool IncludeFilesWithoutMatches { get; set; }
        public string ReplaceText { get; set; }
        public bool UseEscapeChars { get; set; }
        public string Encoding { get; set; }
        public bool IsKeepModifiedDate { get; set; }
        public bool IsFirstTime { get; set; }

        public void SaveSetting()
        {
            Properties.Settings.Default.Dir = Dir;
            Properties.Settings.Default.IncludeSubDirectories = IncludeSubDirectories;
            Properties.Settings.Default.FileMask = FileMask;
            Properties.Settings.Default.ExcludeFileMask = ExcludeFileMask;
            Properties.Settings.Default.ExcludeDir = ExcludeDir;
            Properties.Settings.Default.FindText = FindText;
            Properties.Settings.Default.IsCaseSensitive = IsCaseSensitive;
            Properties.Settings.Default.IsRegEx = IsRegEx;
            Properties.Settings.Default.SkipBinaryFileDetection = SkipBinaryFileDetection;
            Properties.Settings.Default.IncludeFilesWithoutMatches = IncludeFilesWithoutMatches;
            Properties.Settings.Default.ShowEncoding = ShowEncoding;
            Properties.Settings.Default.ReplaceText = ReplaceText;
            Properties.Settings.Default.UseEscapeChars = UseEscapeChars;
            Properties.Settings.Default.Encoding = Encoding;
            Properties.Settings.Default.IsKeepModifiedDate = IsKeepModifiedDate;
            Properties.Settings.Default.IsFirstTime = IsFirstTime;

            Properties.Settings.Default.Save();
        }

        public void LoadSetting()
        {
            if (Properties.Settings.Default.UpgradeRequired)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpgradeRequired = false;
                Properties.Settings.Default.Save();
            }

            Dir = Properties.Settings.Default.Dir;
            IncludeSubDirectories = Properties.Settings.Default.IncludeSubDirectories;
            FileMask = Properties.Settings.Default.FileMask;
            ExcludeFileMask = Properties.Settings.Default.ExcludeFileMask;
            ExcludeDir = Properties.Settings.Default.ExcludeDir;
            FindText = Properties.Settings.Default.FindText;
            IsCaseSensitive = Properties.Settings.Default.IsCaseSensitive;
            IsRegEx = Properties.Settings.Default.IsRegEx;
            SkipBinaryFileDetection = Properties.Settings.Default.SkipBinaryFileDetection;
            IncludeFilesWithoutMatches = Properties.Settings.Default.IncludeFilesWithoutMatches;
            ShowEncoding = Properties.Settings.Default.ShowEncoding;
            ReplaceText = Properties.Settings.Default.ReplaceText;
            UseEscapeChars = Properties.Settings.Default.UseEscapeChars;
            Encoding = Properties.Settings.Default.Encoding;
            IsKeepModifiedDate = Properties.Settings.Default.IsKeepModifiedDate;
            IsFirstTime = Properties.Settings.Default.IsFirstTime;
        }
    }
}