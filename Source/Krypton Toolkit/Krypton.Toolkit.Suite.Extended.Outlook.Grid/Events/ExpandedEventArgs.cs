namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
{
    /// <summary>
    /// Class for Node expanding events
    /// </summary>
    /// <seealso cref="JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid.OutlookGridRowNodeEventBase" />
    public class ExpandedEventArgs : OutlookGridRowNodeEventBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExpandedEventArgs"/> class.
        /// </summary>
        /// <param name="node">The node.</param>
        public ExpandedEventArgs(OutlookGridRow node) : base(node)
        {
        }
    }
}