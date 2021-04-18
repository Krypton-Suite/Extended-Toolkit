using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Notifications
{
    /// <summary>Provides useful methods for specified tasks.</summary>
    internal class NotificationUtilityMethods
    {
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="NotificationUtilityMethods" /> class.</summary>
        public NotificationUtilityMethods() { }
        #endregion

        #region Methods
        /// <summary>Changes the control location.</summary>
        /// <param name="control">The control.</param>
        /// <param name="location">The location.</param>
        public static void ChangeControlLocation(Control control, Point location) => control.Location = location;

        /// <summary>
        /// Converts a bitmaps to an image.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <returns></returns>
        public static Image BitmapToImage(Bitmap bitmap)
        {
            Image tmp = new Bitmap(bitmap);

            return tmp;
        }
        #endregion
    }
}