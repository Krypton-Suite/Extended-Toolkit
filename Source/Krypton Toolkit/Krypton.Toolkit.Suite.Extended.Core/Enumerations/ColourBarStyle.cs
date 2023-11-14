namespace Krypton.Toolkit.Suite.Extended.Core;

/// <summary>
/// Specifies the style of a colour bar
/// </summary>
public enum ColourBarStyle
{
    /// <summary>
    /// A gradient from one colour to another.
    /// </summary>
    TwoColour = 0,

    /// <summary>
    /// A gradient between three colours.
    /// </summary>
    ThreeColour = 1,

    /// <summary>
    /// A gradient between a user defined number of colours.
    /// </summary>
    Custom = 2,
}