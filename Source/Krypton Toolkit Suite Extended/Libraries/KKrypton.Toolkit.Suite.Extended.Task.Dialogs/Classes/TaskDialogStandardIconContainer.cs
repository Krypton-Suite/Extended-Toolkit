namespace Krypton.Toolkit.Suite.Extended.Task.Dialogs
{
    internal class TaskDialogStandardIconContainer : TaskDialogIcon
    {
        public TaskDialogStandardIconContainer(TaskDialogStandardIcon icon) : base() => Icon = icon;

        public TaskDialogStandardIcon Icon { get; }
    }
}