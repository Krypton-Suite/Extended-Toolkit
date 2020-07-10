using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Core
{
    public class ColourManager
    {
        #region Constructors
        public ColourManager()
        {

        }
        #endregion

        #region Methods
        /// <summary>Changes the colour.</summary>
        /// <param name="alphaValue">The alpha value.</param>
        /// <param name="redValue">The red value.</param>
        /// <param name="greenValue">The green value.</param>
        /// <param name="blueValue">The blue value.</param>
        /// <returns></returns>
        public static Color ChangeColour(decimal alphaValue, decimal redValue, decimal greenValue, decimal blueValue)
        {
            Color outputColour = Color.FromArgb((int)alphaValue, (int)redValue, (int)greenValue, (int)blueValue);

            return outputColour;
        }
        #endregion
    }
}