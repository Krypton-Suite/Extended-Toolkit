namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
{
    /// <summary>
    /// Base class for OutlookGridRowNode events
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class OutlookGridRowNodeEventBase : EventArgs
    {
        private OutlookGridRow _row;

        /// <summary>
        /// Initializes a new instance of the <see cref="OutlookGridRowNodeEventBase"/> class.
        /// </summary>
        /// <param name="node">The node.</param>
        public OutlookGridRowNodeEventBase(OutlookGridRow node)
        {
            _row = node;
        }

        /// <summary>
        /// Gets the node.
        /// </summary>
        /// <value>
        /// The node.
        /// </value>
        public OutlookGridRow Node
        {
            get { return _row; }
        }
    }
}