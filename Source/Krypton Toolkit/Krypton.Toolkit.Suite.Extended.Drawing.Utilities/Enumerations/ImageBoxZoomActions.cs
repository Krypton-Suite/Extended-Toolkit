namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities;

/// <summary>
/// Describes the zoom action occuring
/// </summary>
[Flags]
public enum ImageBoxZoomActions
{
    /// <summary>
    /// No action.
    /// </summary>
    None = 0,

    /// <summary>
    /// The control is increasing the zoom.
    /// </summary>
    ZoomIn = 1,

    /// <summary>
    /// The control is decreasing the zoom.
    /// </summary>
    ZoomOut = 2,

    /// <summary>
    /// The control zoom was reset.
    /// </summary>
    ActualSize = 4
}