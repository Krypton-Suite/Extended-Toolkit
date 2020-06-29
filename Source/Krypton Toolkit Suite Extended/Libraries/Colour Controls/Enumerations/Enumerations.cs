namespace Krypton.Toolkit.Suite.Extended.Drawing.Suite
{
    /// <summary>
    /// Specifies the style of a color cell border.
    /// </summary>
    public enum ColourCellBorderStyle
    {
        /// <summary>
        /// No border.
        /// </summary>
        None,

        /// <summary>
        /// A single line border.
        /// </summary>
        FixedSingle,

        /// <summary>
        /// A contrasting double border with a soft inner outline using the color of the cell.
        /// </summary>
        DoubleSoft
    }

    /// <summary>
    /// Specifies the sort order of colors
    /// </summary>
    public enum ColourCollectionSortOrder
    {
        /// <summary>
        /// Ordered by hue.
        /// </summary>
        Hue,

        /// <summary>
        /// Ordered by brightness.
        /// </summary>
        Brightness,

        /// <summary>
        /// Ordered by value
        /// </summary>
        Value
    }

    /// <summary>
    /// Specifies the style of a color bar
    /// </summary>
    public enum ColourBarStyle
    {
        /// <summary>
        /// A gradient from one color to another.
        /// </summary>
        TwoColour,

        /// <summary>
        /// A gradient between three colors.
        /// </summary>
        ThreeColour,

        /// <summary>
        /// A gadient between a user defined number of colors.
        /// </summary>
        Custom
    }

    /// <summary>
    /// Specifies the edit mode of a <see cref="ColourGrid" />.
    /// </summary>
    public enum ColourEditingMode
    {
        /// <summary>
        /// None. No editing is allowed.
        /// </summary>
        None,

        /// <summary>
        /// Only custom colors can be edited.
        /// </summary>
        CustomOnly,

        /// <summary>
        /// Custom or standard colors can be edited.
        /// </summary>
        Both
    }

    public enum ColourPalette
    {
        None,

        Named,

        Office2010,

        Paint,

        Standard,

        WebSafe,

        Standard256
    }

    /// <summary>
    /// Determines how the selected cell in a <see cref="KryptonColourGrid" /> control is rendered.
    /// </summary>
    public enum ColourGridSelectedCellStyle
    {
        /// <summary>
        /// The selected cell is drawn no differently to any other cell.
        /// </summary>
        None,

        /// <summary>
        /// The selected cell displays a basic outline and focus rectangle.
        /// </summary>
        Standard,

        /// <summary>
        /// The selected cell is displayed larger than other cells
        /// </summary>
        Zoomed
    }

    public enum ColourSource
    {
        None,

        Standard,

        Custom
    }

    /// <summary>
    /// Specifies the origin of a navigation operation
    /// </summary>
    public enum NavigationOrigin
    {
        /// <summary>
        /// Specifies the beginning
        /// </summary>
        Begin,

        /// <summary>
        /// Specifies the current position
        /// </summary>
        Current,

        /// <summary>
        /// Specifies the end
        /// </summary>
        End
    }

    public enum ColourSliderNubStyle
    {
        None,

        TopLeft,

        BottomRight
    }

    public enum RGBAChannel
    {
        Red,

        Green,

        Blue,

        Alpha
    }

    /// <summary>
    /// The basic palette colours.
    /// </summary>
    public enum BasicPaletteColours
    {
        /// <summary>
        /// The base colour
        /// </summary>
        BASECOLOUR = 0,
        /// <summary>
        /// The darkest colour
        /// </summary>
        DARKESTCOLOUR = 1,
        /// <summary>
        /// The middle colour
        /// </summary>
        MIDDLECOLOUR = 2,
        /// <summary>
        /// The light colour
        /// </summary>
        LIGHTCOLOUR = 3,
        /// <summary>
        /// The lightest colour
        /// </summary>
        LIGHTESTCOLOUR = 4
    }

    /// <summary>
    /// All custom palette colours.
    /// </summary>
    public enum AllCustomPaletteColours
    {
        /// <summary>
        /// The alternative normal text colour.
        /// </summary>
        ALTERNATIVENORMALTEXTCOLOUR = 0,
        /// <summary>
        /// The border colour.
        /// </summary>
        BORDERCOLOUR = 1,
        /// <summary>
        /// The custom colour one.
        /// </summary>
        CUSTOMCOLOURONE = 2,
        /// <summary>
        /// The custom colour two.
        /// </summary>
        CUSTOMCOLOURTWO = 3,
        /// <summary>
        /// The custom colour three.
        /// </summary>
        CUSTOMCOLOURTHREE = 4,
        /// <summary>
        /// The custom colour four.
        /// </summary>
        CUSTOMCOLOURFOUR = 5,
        /// <summary>
        /// The custom colour five.
        /// </summary>
        CUSTOMCOLOURFIVE = 6,
        /// <summary>
        /// The custom colour six.
        /// </summary>
        CUSTOMCOLOURSIX = 7,
        /// <summary>
        /// The custom text colour one.
        /// </summary>
        CUSTOMTEXTCOLOURONE = 8,
        /// <summary>
        /// The custom text colour two.
        /// </summary>
        CUSTOMTEXTCOLOURTWO = 9,
        /// <summary>
        /// The custom text colour three.
        /// </summary>
        CUSTOMTEXTCOLOURTHREE = 10,
        /// <summary>
        /// The custom text colour four.
        /// </summary>
        CUSTOMTEXTCOLOURFOUR = 11,
        /// <summary>
        /// The custom text colour five.
        /// </summary>
        CUSTOMTEXTCOLOURFIVE = 12,
        /// <summary>
        /// The customtext colour six.
        /// </summary>
        CUSTOMTEXTCOLOURSIX = 13,
        /// <summary>
        /// The disabled control colour.
        /// </summary>
        DISABLEDCONTROLCOLOUR = 14,
        /// <summary>
        /// The disabled text colour.
        /// </summary>
        DISABLEDTEXTCOLOUR = 15,
        /// <summary>
        /// The focused text colour.
        /// </summary>
        FOCUSEDTEXTCOLOUR = 16,
        /// <summary>
        /// The link disabled text colour.
        /// </summary>
        LINKDISABLEDTEXTCOLOUR = 17,
        /// <summary>
        /// The link focused text colour.
        /// </summary>
        LINKFOCUSEDTEXTCOLOUR = 18,
        /// <summary>
        /// The link hover text colour.
        /// </summary>
        LINKHOVERTEXTCOLOUR = 19,
        /// <summary>
        /// The link normal text colour.
        /// </summary>
        LINKNORMALTEXTCOLOUR = 20,
        /// <summary>
        /// The link visited text colour.
        /// </summary>
        LINKVISITEDTEXTCOLOUR = 21,
        /// <summary>
        /// The menu text colour.
        /// </summary>
        MENUTEXTCOLOUR = 22,
        /// <summary>
        /// The normal text colour.
        /// </summary>
        NORMALTEXTCOLOUR = 23,
        /// <summary>
        /// The pressed text colour.
        /// </summary>
        PRESSEDTEXTCOLOUR = 24,
        /// <summary>
        /// The ribbon text colour.
        /// </summary>
        RIBBONTEXTCOLOUR = 25,
        /// <summary>
        /// The status text colour.
        /// </summary>
        STATUSTEXTCOLOUR = 26
    }
}