#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Toast
{
    /// <summary>Provides useful methods for specified tasks.</summary>
    internal class UtilityMethods
    {
        #region Constructor
        /// <summary>
        /// Initialises a new instance of <see cref="UtilityMethods"/>.
        /// </summary>
        public UtilityMethods()
        {

        }
        #endregion

        #region Methods
        /// <summary>Changes the control location.</summary>
        /// <param name="control">The control.</param>
        /// <param name="location">The location.</param>
        public static void ChangeControlLocation(Control control, Point location) => control.Location = location;

        /// <summary>
        /// Bitmaps to image.
        /// </summary>
        /// <param name="bitmap">The bitmap.</param>
        /// <returns></returns>
        public static Image BitmapToImage(Bitmap bitmap)
        {
            Image tmp = new Bitmap(bitmap);

            return tmp;
        }
        
        public static void SetIconType(IconType iconType, Image customImage, PictureBox target)
        {
            switch (iconType)
            {
                case IconType.CUSTOM:
                    SetIconImage(target, customImage);
                    break;
                case IconType.OK:
                    SetIconImage(target, Properties.Resources.Input_Box_Ok_128_x_128);
                    break;
                case IconType.ERROR:
                    SetIconImage(target, Properties.Resources.Input_Box_Critical_128_x_128);
                    break;
                case IconType.EXCLAMATION:
                    SetIconImage(target, Properties.Resources.Input_Box_Warning_128_x_115);
                    break;
                case IconType.INFORMATION:
                    SetIconImage(target, Properties.Resources.Input_Box_Information_128_x_128);
                    break;
                case IconType.QUESTION:
                    SetIconImage(target, Properties.Resources.Input_Box_Question_128_x_128);
                    break;
                case IconType.NOTHING:
                    SetIconImage(target, null);
                    break;
                case IconType.NONE:
                    SetIconImage(target, null);
                    break;
                case IconType.STOP:
                    SetIconImage(target, Properties.Resources.Input_Box_Stop_128_x_128);
                    break;
                case IconType.HAND:
                    SetIconImage(target, Properties.Resources.Input_Box_Hand_128_x_128);
                    break;
                case IconType.WARNING:
                    SetIconImage(target, Properties.Resources.Input_Box_Warning_128_x_115);
                    break;
            }
        }

        private static void SetIconImage(PictureBox pictureBox, Image image) => pictureBox.Image = image;

        public static void FadeIn(KryptonForm activeWindow)
        {
            Timer timer = new Timer();

            timer.Interval = 10;
            
            timer.Tick += (sender, args) =>
            {
                if (activeWindow.Opacity == 1d)
                {
                    timer.Stop();
                }

                activeWindow.Opacity += 0.02d;
            };

            timer.Start();
        }

        public static void FadeOutAndClose(KryptonForm activeWindow)
        {
            Timer timer = new Timer();

            timer.Interval = 10;
            
            timer.Tick += (sender, args) =>
            {
                if (activeWindow.Opacity == 0d)
                {
                    timer.Stop();
                  
                    activeWindow.Close();
                }

                activeWindow.Opacity -= 0.02d;
            };

            timer.Start();
        }
        #endregion
    }
}