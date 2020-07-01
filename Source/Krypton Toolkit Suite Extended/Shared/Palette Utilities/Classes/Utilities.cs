using System;
using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Palette.Utilities
{
    public class Utilities
    {
        #region Constructor
        public Utilities()
        {

        }
        #endregion

        #region Methods
        public Color GenerateRandomColour()
        {
            Random rnd = new Random();

            KnownColor[] name = (KnownColor[])Enum.GetValues(typeof(KnownColor));

            KnownColor randomColourName = name[rnd.Next(name.Length)];

            Color randomColour = Color.FromKnownColor(randomColourName);

            return randomColour;
        }
        #endregion
    }
}
