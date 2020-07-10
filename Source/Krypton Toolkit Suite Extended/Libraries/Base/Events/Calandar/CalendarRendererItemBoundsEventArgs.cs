using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    public class CalendarRendererItemBoundsEventArgs : CalendarRendererItemEventArgs
    {
        #region Fields
        private Rectangle _bounds;
        private bool _isFirst;
        private bool _isLast;
        #endregion

        #region Ctor

        /// <summary>
        /// Creates a new Event
        /// </summary>
        /// <param name="original"></param>
        /// <param name="bounds"></param>
        /// <param name="isFirst"></param>
        /// <param name="isLast"></param>
        internal CalendarRendererItemBoundsEventArgs(CalendarRendererItemEventArgs original, Rectangle bounds, bool isFirst, bool isLast) : base(original, original.Item)
        {
            _isFirst = isFirst;
            _isLast = isLast;
            _bounds = bounds;
        }

        #endregion

        #region Props

        /// <summary>
        /// Gets the bounds of the item to be rendered.
        /// </summary>
        /// <remarks>
        /// Items may have more than one bounds due to week segmentation.
        /// </remarks>
        public Rectangle Bounds
        {
            get { return _bounds; }
        }

        /// <summary>
        /// Gets a value indicating if the bounds are the first of the item.
        /// </summary>
        /// <remarks>
        /// Items may have more than one bounds due to week segmentation.
        /// </remarks>
        public bool IsFirst
        {
            get { return _isFirst; }
        }

        /// <summary>
        /// Gets a value indicating if the bounds are the last of the item.
        /// </summary>
        /// <remarks>
        /// Items may have more than one bounds due to week segmentation.
        /// </remarks>
        public bool IsLast
        {
            get { return _isLast; }
            set { _isLast = value; }
        }


        #endregion
    }
}