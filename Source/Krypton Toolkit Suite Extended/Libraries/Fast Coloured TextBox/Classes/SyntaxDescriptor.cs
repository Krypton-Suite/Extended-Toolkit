using System;
using System.Collections.Generic;

namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    public class SyntaxDescriptor : IDisposable
    {
        public char leftBracket = '(';
        public char rightBracket = ')';
        public char leftBracket2 = '{';
        public char rightBracket2 = '}';
        public BracketsHighlightStrategy bracketsHighlightStrategy = BracketsHighlightStrategy.STRATEGY2;
        public readonly List<Style> styles = new List<Style>();
        public readonly List<RuleDesc> rules = new List<RuleDesc>();
        public readonly List<FoldingDesc> foldings = new List<FoldingDesc>();

        public void Dispose()
        {
            foreach (var style in styles)
                style.Dispose();
        }
    }
}