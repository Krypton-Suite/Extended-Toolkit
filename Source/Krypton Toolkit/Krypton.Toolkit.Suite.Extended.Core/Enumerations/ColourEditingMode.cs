namespace Krypton.Toolkit.Suite.Extended.Core;

/// <summary>
/// Specifies the edit mode of a <see cref="ColourGridControl" />.
/// </summary>
public enum ColourEditingMode
{
    /// <summary>
    /// None. No editing is allowed.
    /// </summary>
    None = 0,

    /// <summary>
    /// Only custom colours can be edited.
    /// </summary>
    CustomOnly = 1,

    /// <summary>
    /// Custom or standard colours can be edited.
    /// </summary>
    Both = 2
}