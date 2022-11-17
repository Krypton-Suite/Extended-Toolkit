namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities;

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