namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    internal struct SPTEXTSELECTIONINFO
    {
        internal uint ulStartActiveOffset;

        internal uint cchActiveChars;

        internal uint ulStartSelection;

        internal uint cchSelection;

        internal SPTEXTSELECTIONINFO(uint ulStartActiveOffset, uint cchActiveChars, uint ulStartSelection, uint cchSelection)
        {
            this.ulStartActiveOffset = ulStartActiveOffset;
            this.cchActiveChars = cchActiveChars;
            this.ulStartSelection = ulStartSelection;
            this.cchSelection = cchSelection;
        }
    }
}