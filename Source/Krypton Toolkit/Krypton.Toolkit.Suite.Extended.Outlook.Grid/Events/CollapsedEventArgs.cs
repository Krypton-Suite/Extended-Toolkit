namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
{
    /// <summary>
    /// Class for Node collapsed events 
    /// </summary>
    /// <seealso cref="JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid.OutlookGridRowNodeEventBase" />
    public class CollapsedEventArgs : OutlookGridRowNodeEventBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CollapsedEventArgs"/> class.
        /// </summary>
        /// <param name="node">The node.</param>
        public CollapsedEventArgs(OutlookGridRow node)
            : base(node)
        {
        }
    }
}