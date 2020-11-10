namespace Krypton.Toolkit.Suite.Extended.Fast.Coloured.Text.Box
{
    public struct RangeRect
    {
        public RangeRect(int iStartLine, int iStartChar, int iEndLine, int iEndChar)
        {
            this.iStartLine = iStartLine;
            this.iStartChar = iStartChar;
            this.iEndLine = iEndLine;
            this.iEndChar = iEndChar;
        }

        public int iStartLine;
        public int iStartChar;
        public int iEndLine;
        public int iEndChar;
    }
}