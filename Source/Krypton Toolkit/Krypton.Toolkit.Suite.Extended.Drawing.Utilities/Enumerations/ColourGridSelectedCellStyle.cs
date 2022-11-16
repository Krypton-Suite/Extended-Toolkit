namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities;

/// <summary>
/// Determines how the selected cell in a <see cref="KryptonColourGrid" /> control is rendered.
/// </summary>
public enum ColourGridSelectedCellStyle
#pragma warning restore CS1574 // XML comment has cref attribute that could not be resolved
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