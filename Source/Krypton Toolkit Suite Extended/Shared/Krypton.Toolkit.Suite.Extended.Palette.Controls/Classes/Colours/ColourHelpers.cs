using System.Collections;

namespace Krypton.Toolkit.Extended.Palette.Controls
{
    public class ColourHelpers
    {
        #region Variables
        private string[] _paletteColours = new string[] {
        "Border Colour One",
        "Border Colour Two",
        "Alternative Normal Text Colour",
        "Disabled Text Colour",
        "Focused Text Colour",
        "Normal Text Colour",
        "Pressed Text Colour",
        "Disabled Control Colour",
        "Link Focused Text Colour",
        "Link Hover Text Colour",
        "Link Normal Text Colour",
        "Link Visited Text Colour",
        "Custom Colour One",
        "Custom Colour Two",
        "Custom Colour Three",
        "Custom Colour Four",
        "Custom Colour Five",
        "Custom Text Colour One",
        "Custom Text Colour Teo",
        "Custom Text Colour Three",
        "Custom Text Colour Four",
        "Custom Text Colour Five",
        "Menu Text Colour",
        "Status Strip Text Colour",
        "Ribbon Tab Text Colour"
        };
        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="ColourHelpers" /> class.</summary>
        public ColourHelpers()
        {

        }
        #endregion

        #region Methods
        /// <summary>Gets the palette colours.</summary>
        /// <returns></returns>
        public static string[] GetPaletteColours()
        {
            ColourHelpers colourHelpers = new ColourHelpers();

            return colourHelpers._paletteColours;
        }

        /// <summary>Propagates the colours.</summary>
        /// <param name="comboBox">The combo box.</param>
        public static void PropagateColours(KryptonComboBox comboBox)
        {
            foreach (string item in GetPaletteColours())
            {
                comboBox.Items.Add(item);
            }
        }

        /// <summary>Propagates the colours.</summary>
        /// <param name="comboBox">The combo box.</param>
        /// <param name="sort">if set to <c>true</c> [sort].</param>
        public static void PropagateColours(KryptonComboBox comboBox, bool sort)
        {
            ArrayList internalArray = new ArrayList();

            foreach (string item in GetPaletteColours())
            {
                internalArray.Add(item);
            }

            if (sort)
            {
                internalArray.Sort();

                foreach (string item in internalArray)
                {
                    comboBox.Items.Add(item);
                }
            }
        }
        #endregion
    }
}