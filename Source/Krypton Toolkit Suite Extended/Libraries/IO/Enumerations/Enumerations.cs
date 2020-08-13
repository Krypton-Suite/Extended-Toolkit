namespace Krypton.Toolkit.Suite.Extended.IO
{
    public enum FileExplorerActionType
    {
        OPENFILE = 0,
        SAVEASFILE = 1,
        SAVEFILE = 2
    }

    /// <summary>
    /// The Various levels of Status for the xDirectory 'StartCopy' method.
    /// </summary>
    public enum xDirectoryStatus
    {
        /// <summary>
        /// The xDirectory Copy Thread is Stopped.
        /// </summary>
        STOPPED,

        /// <summary>
        /// The xDirectory Copy Thread is Starting.
        /// </summary>
        STARTED,

        /// <summary>
        /// The xDirectory Copy Thread is Indexing.
        /// </summary>
        INDEXING,

        /// <summary>
        /// The xDirectory Copy Thread is Copying Folders.
        /// </summary>
        COPYINGDIRECTORIES,

        /// <summary>
        /// The xDirectory Copy Thread is Copying Files.
        /// </summary>
        COPYINGFILES
    }
}