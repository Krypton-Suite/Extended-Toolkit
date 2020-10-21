namespace Krypton.Toolkit.Suite.Extended.Notifications
{
    public enum ActionType
    {
        DEFAULT,
        LAUCHPROCESS,
        OPEN
    }

    public enum ActionButtonLocation
    {
        LEFT,
        RIGHT
    }

    public enum DefaultNotificationButton
    {
        ACTIONBUTTON,
        DISMISSBUTTON,
        NONE
    }

    public enum IconType
    {
        CUSTOM,
        OK,
        ERROR,
        EXCLAMATION,
        INFORMATION,
        QUESTION,
        NOTHING,
        NONE,
        STOP,
        HAND,
        WARNING
    }

    public enum RightToLeftSupport
    {
        LEFTTORIGHT,
        RIGHTTOLEFT
    }

    public enum AlertAction
    {
        START,
        WAIT,
        CLOSE
    }

    public enum AlertType
    {
        SUCESS,
        INFORMATION,
        WARNING,
        ERROR,
        CUSTOM
    }
}
