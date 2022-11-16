namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities;

/// <summary>
/// Specifies the edit mode of a <see cref="ColorGrid" />.
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