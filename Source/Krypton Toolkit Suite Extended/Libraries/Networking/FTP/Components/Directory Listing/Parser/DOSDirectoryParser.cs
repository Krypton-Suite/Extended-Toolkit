using System.Globalization;
using System.Text.RegularExpressions;

namespace Krypton.Toolkit.Suite.Extended.Networking
{
    public class DOSDirectoryParser : IListDirectoryParser
    {
        private readonly Regex dosDirectoryRegex = new Regex(@"(?<modify>\d+-\d+-\d+\s+\d+:\d+\w+)\s+<DIR>\s+(?<name>.*)$", RegexOptions.Compiled);
        private readonly Regex dosFileRegex = new Regex(@"(?<modify>\d+-\d+-\d+\s+\d+:\d+\w+)\s+(?<size>\d+)\s+(?<name>.*)$", RegexOptions.Compiled);
        private ILogger logger;

        public DOSDirectoryParser(ILogger logger)
        {
            this.logger = logger;
        }

        public bool Test(string testString)
        {
            return dosDirectoryRegex.Match(testString).Success ||
                   dosFileRegex.Match(testString).Success;
        }

        public FTPNodeInformation Parse(string line)
        {
            var directoryMatch = dosDirectoryRegex.Match(line);
            if (directoryMatch.Success)
            {
                return ParseDirectory(directoryMatch);
            }


            var fileMatch = dosFileRegex.Match(line);
            if (fileMatch.Success)
            {
                return ParseFile(fileMatch);
            }

            return null;
        }

        public FTPNodeInformation ParseDirectory(Match match)
        {
            return new FTPNodeInformation
            {
                NodeType = FTPNodeType.DIRECTORY,
                Name = match.Groups["name"].Value,
                DateModified = match.Groups["modify"].Value.ExtractFTPDate(DateTimeStyles.AssumeLocal),
                Size = 0
            };
        }

        public FTPNodeInformation ParseFile(Match match)
        {
            return new FTPNodeInformation
            {
                NodeType = FTPNodeType.FILE,
                Name = match.Groups["name"].Value,
                DateModified = match.Groups["modify"].Value.ExtractFTPDate(DateTimeStyles.AssumeLocal),
                Size = match.Groups["size"].Value.ParseOrDefault()
            };
        }
    }
}