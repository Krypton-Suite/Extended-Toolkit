namespace Krypton.Toolkit.Suite.Extended.Wizard
{
    /// <summary>
    /// Add AllowPageChange property to allow user to determine whether or not 
    /// the application user can proceed
    /// </summary>
    public class WizardEventArgs : EventArgs
    {
        public WizardEventArgs(int currentPageIndex, Direction direction = Direction.FORWARD)
        {
            CurrentPageIndex = currentPageIndex;
            NextPageIndex = direction == Direction.FORWARD ? currentPageIndex + 1 : currentPageIndex - 1;
            AllowPageChange = true;
        }

        public bool AllowPageChange { get; set; }

        public int CurrentPageIndex { get; }

        public int NextPageIndex { get; set; }
    }
}