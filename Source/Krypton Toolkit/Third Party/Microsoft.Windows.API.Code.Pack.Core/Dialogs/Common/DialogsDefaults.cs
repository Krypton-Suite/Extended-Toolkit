using Microsoft.Windows.API.Code.Pack.Core.Resources;

namespace Microsoft.Windows.API.Code.Pack.Core
{
    internal static class DialogsDefaults
    {
        internal static string Caption { get { return LocalizedMessages.DialogDefaultCaption; } }
        internal static string MainInstruction { get { return LocalizedMessages.DialogDefaultMainInstruction; } }
        internal static string Content { get { return LocalizedMessages.DialogDefaultContent; } }

        internal const int ProgressBarStartingValue = 0;
        internal const int ProgressBarMinimumValue = 0;
        internal const int ProgressBarMaximumValue = 100;

        internal const int IdealWidth = 0;

        // For generating control ID numbers that won't 
        // collide with the standard button return IDs.
        internal const int MinimumDialogControlId =
            (int)TaskDialogNativeMethods.TaskDialogCommonButtonReturnIds.Close + 1;
    }
}