using System.Text.RegularExpressions;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    public class RuleDesc
    {
        Regex regex;
        public string pattern;
        public RegexOptions options = RegexOptions.None;
        public Style style;

        public Regex Regex
        {
            get
            {
                if (regex == null)
                {
                    regex = new Regex(pattern, SyntaxHighlighter.RegexCompiledOption | options);
                }
                return regex;
            }
        }
    }
}