using System;

namespace Krypton.Toolkit.Suite.Extended.Task.Dialogs
{
    public partial class TaskDialog
    {
        private class WindowSubclassHandler : Classes.WindowSubclassHandler
        {
            private readonly TaskDialog _taskDialog;

            private bool _processedShowWindowMessage;

            public WindowSubclassHandler(TaskDialog taskDialog)
                : base(taskDialog?._hwndDialog ?? throw new ArgumentNullException(nameof(taskDialog)))
            {
                _taskDialog = taskDialog;
            }

            protected override unsafe IntPtr WndProc(int msg, IntPtr wParam, IntPtr lParam)
            {
                switch (msg)
                {
                    case TaskDialogNativeMethods.WM_WINDOWPOSCHANGED:
                        IntPtr result = base.WndProc(msg, wParam, lParam);

                        ref TaskDialogNativeMethods.WINDOWPOS windowPos =
                                ref *(TaskDialogNativeMethods.WINDOWPOS*)lParam;

                        if ((windowPos.flags & TaskDialogNativeMethods.WINDOWPOS_FLAGS.SWP_SHOWWINDOW) ==
                                TaskDialogNativeMethods.WINDOWPOS_FLAGS.SWP_SHOWWINDOW &&
                                !_processedShowWindowMessage)
                        {
                            _processedShowWindowMessage = true;

                            // The task dialog window has been shown for the first time.
                            _taskDialog.OnShown(EventArgs.Empty);
                        }

                        return result;

                    default:
                        return base.WndProc(msg, wParam, lParam);
                }
            }
        }
    }
}