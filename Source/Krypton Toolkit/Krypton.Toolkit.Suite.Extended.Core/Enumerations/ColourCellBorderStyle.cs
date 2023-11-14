namespace Krypton.Toolkit.Suite.Extended.Core;

/// <summary>
/// Specifies the style of a colour cell border.
/// </summary>
public enum ColourCellBorderStyle
{
    /// <summary>
    /// No border.
    /// </summary>
    None = 0,

    /// <summary>
    /// A single line border.
    /// </summary>
    FixedSingle = 1,

    /// <summary>
    /// A contrasting double border with a soft inner outline using the colour of the cell.
    /// </summary>
    DoubleSoft = 2
}