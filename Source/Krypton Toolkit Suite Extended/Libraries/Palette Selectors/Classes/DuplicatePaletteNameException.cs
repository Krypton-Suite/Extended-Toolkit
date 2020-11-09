using System;

namespace Krypton.Toolkit.Suite.Extended.Palette.Selectors
{
    [Serializable]
    public class DuplicatePaletteNameException : Exception
    {
        public DuplicatePaletteNameException() { }
        public DuplicatePaletteNameException(string s) : base(s) { }
    }
}