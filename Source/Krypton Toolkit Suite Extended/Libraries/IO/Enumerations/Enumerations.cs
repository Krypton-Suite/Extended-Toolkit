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

    /// <summary>
    /// Actions for shortcuts
    /// </summary>
    public enum FCTBAction
    {
        None,
        AutoCompleteMenu,
        AutoIndentChars,
        BookmarkLine,
        ClearHints,
        ClearWordLeft,
        ClearWordRight,
        CloneLine,
        CommentSelected,
        Copy,
        Cut,
        DeleteCharRight,
        FindChar,
        FindDialog,
        FindNext,
        GoDown,
        GoDownWithSelection,
        GoDown_ColumnSelectionMode,
        GoEnd,
        GoEndWithSelection,
        GoFirstLine,
        GoFirstLineWithSelection,
        GoHome,
        GoHomeWithSelection,
        GoLastLine,
        GoLastLineWithSelection,
        GoLeft,
        GoLeftWithSelection,
        GoLeft_ColumnSelectionMode,
        GoPageDown,
        GoPageDownWithSelection,
        GoPageUp,
        GoPageUpWithSelection,
        GoRight,
        GoRightWithSelection,
        GoRight_ColumnSelectionMode,
        GoToDialog,
        GoNextBookmark,
        GoPrevBookmark,
        GoUp,
        GoUpWithSelection,
        GoUp_ColumnSelectionMode,
        GoWordLeft,
        GoWordLeftWithSelection,
        GoWordRight,
        GoWordRightWithSelection,
        IndentIncrease,
        IndentDecrease,
        LowerCase,
        MacroExecute,
        MacroRecord,
        MoveSelectedLinesDown,
        MoveSelectedLinesUp,
        NavigateBackward,
        NavigateForward,
        Paste,
        Redo,
        ReplaceDialog,
        ReplaceMode,
        ScrollDown,
        ScrollUp,
        SelectAll,
        UnbookmarkLine,
        Undo,
        UpperCase,
        ZoomIn,
        ZoomNormal,
        ZoomOut,
        CustomAction1,
        CustomAction2,
        CustomAction3,
        CustomAction4,
        CustomAction5,
        CustomAction6,
        CustomAction7,
        CustomAction8,
        CustomAction9,
        CustomAction10,
        CustomAction11,
        CustomAction12,
        CustomAction13,
        CustomAction14,
        CustomAction15,
        CustomAction16,
        CustomAction17,
        CustomAction18,
        CustomAction19,
        CustomAction20
    }
}