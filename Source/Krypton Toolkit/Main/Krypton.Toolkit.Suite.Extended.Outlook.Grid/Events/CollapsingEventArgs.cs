namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
{
    /// <summary>
    /// Class for Node collapsing events
    /// </summary>
    /// <seealso cref="JDHSoftware.Krypton.Toolkit.KryptonOutlookGrid.OutlookGridRowNodeCancelEventBase" />
    public class CollapsingEventArgs : OutlookGridRowNodeCancelEventBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CollapsingEventArgs"/> class.
        /// </summary>
        /// <param name="node">The node.</param>
        public CollapsingEventArgs(OutlookGridRow node)
            : base(node)
        {
        }
    }
}