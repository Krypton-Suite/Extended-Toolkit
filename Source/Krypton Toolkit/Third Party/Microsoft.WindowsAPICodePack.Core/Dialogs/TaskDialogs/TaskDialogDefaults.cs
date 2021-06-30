namespace Microsoft.WindowsAPICodePack.Core
{
    internal static class TaskDialogDefaults
    {
        public static string Caption { get { return LocalisedMessages.TaskDialogDefaultCaption; } }
        public static string MainInstruction { get { return LocalisedMessages.TaskDialogDefaultMainInstruction; } }
        public static string Content { get { return LocalisedMessages.TaskDialogDefaultContent; } }

        public const int ProgressBarMinimumValue = 0;
        public const int ProgressBarMaximumValue = 100;

        public const int IdealWidth = 0;

        // For generating control ID numbers that won't 
        // collide with the standard button return IDs.
        public const int MinimumDialogControlId =
            (int)TaskDialogNativeMethods.TaskDialogCommonButtonReturnIds.Close + 1;
    }
}