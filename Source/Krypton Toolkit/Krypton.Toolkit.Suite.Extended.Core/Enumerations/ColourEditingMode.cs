namespace Krypton.Toolkit.Suite.Extended.Core;

/// <summary>
/// Specifies the edit mode of a <see cref="ColourGridControl" />.
/// </summary>
public enum ColourEditingMode
{
    /// <summary>
    /// None. No editing is allowed.
    /// </summary>
    NONE,

    /// <summary>
    /// Only custom colours can be edited.
    /// </summary>
    CUSTOMONLY,

    /// <summary>
    /// Custom or standard colours can be edited.
    /// </summary>
    BOTH
}