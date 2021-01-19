using System;

namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
{
    /// <summary>
    /// Class for events of the group image of a group row.
    /// </summary>
    public class OutlookGridGroupImageEventArgs : EventArgs
    {
        private OutlookGridRow row;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="row">The OutlookGridRow.</param>
        public OutlookGridGroupImageEventArgs(OutlookGridRow row)
        {
            this.row = row;
        }

        /// <summary>
        /// Gets or sets the row.
        /// </summary>
        public OutlookGridRow Row
        {
            get
            {
                return this.row;
            }
            set
            {
                this.row = value;
            }
        }
    }
}