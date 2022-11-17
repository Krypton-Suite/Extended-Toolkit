namespace Krypton.Toolkit.Suite.Extended.Shared
{
    /// <summary>
    /// Resource identifiers for default animations from shell32.dll.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue")]
    public enum ShellAnimation
    {
        /// <summary>
        /// An animation representing a file move.
        /// </summary>
        FileMove = 160,
        /// <summary>
        /// An animation representing a file copy.
        /// </summary>
        FileCopy = 161,
        /// <summary>
        /// An animation showing flying papers.
        /// </summary>
        FlyingPapers = 165,
        /// <summary>
        /// An animation showing a magnifying glass over a globe.
        /// </summary>
        SearchGlobe = 166,
        /// <summary>
        /// An animation representing a permanent delete.
        /// </summary>
        PermanentDelete = 164,
        /// <summary>
        /// An animation representing deleting an item from the recycle bin.
        /// </summary>
        FromRecycleBinDelete = 163,
        /// <summary>
        /// An animation representing a file move to the recycle bin.
        /// </summary>
        ToRecycleBinDelete = 162,
        /// <summary>
        /// An animation representing a search spanning the local computer.
        /// </summary>
        SearchComputer = 152,
        /// <summary>
        /// An animation representing a search in a document..
        /// </summary>
        SearchDocument = 151,
        /// <summary>
        /// An animation representing a search using a flashlight animation.
        /// </summary>
        SearchFlashlight = 150,
    }

    /// <summary>Positions the title on a <see cref="KryptonFormExtended"/>.</summary>
    public enum KryptonFormTitleStyle
    {
        /// <summary>Positions the title to the left (Windows 95 - 7/10/11 style).</summary>
        Classic = 0,
        /// <summary>Positions the title to the center (Windows 8/8.1 style).</summary>
        Modern = 1,
        /// <summary>Positions the title, based on OS settings.</summary>
        Inherit = 2
    }
}