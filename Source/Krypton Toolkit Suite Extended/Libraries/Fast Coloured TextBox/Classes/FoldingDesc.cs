using System.Text.RegularExpressions;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    public class FoldingDesc
    {
        public string startMarkerRegex;
        public string finishMarkerRegex;
        public RegexOptions options = RegexOptions.None;
    }
}