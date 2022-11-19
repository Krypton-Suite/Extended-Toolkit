namespace Krypton.Toolkit.Suite.Extended.Core;

/// <summary>
/// Determines how the selected cell in a <see cref="ColourGridControl" /> control is rendered.
/// </summary>
public enum ColourGridSelectedCellStyle
{
    /// <summary>
    /// The selected cell is drawn no differently to any other cell.
    /// </summary>
    None = 0,

    /// <summary>
    /// The selected cell displays a basic outline and focus rectangle.
    /// </summary>
    Standard = 1,

    /// <summary>
    /// The selected cell is displayed larger than other cells
    /// </summary>
    Zoomed = 2
}