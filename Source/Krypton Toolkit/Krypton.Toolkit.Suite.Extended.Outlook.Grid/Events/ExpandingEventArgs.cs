namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
{
    /// <summary>
    /// Class for Node expanding events
    /// </summary>
    /// <seealso cref="JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid.OutlookGridRowNodeCancelEventBase" />
    public class ExpandingEventArgs : OutlookGridRowNodeCancelEventBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExpandingEventArgs"/> class.
        /// </summary>
        /// <param name="node">The node.</param>
        public ExpandingEventArgs(OutlookGridRow node) : base(node)
        {
        }
    }
}