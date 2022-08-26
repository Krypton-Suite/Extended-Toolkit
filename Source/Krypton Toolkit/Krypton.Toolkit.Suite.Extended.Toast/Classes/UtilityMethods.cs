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
                case IconType.Custom:
                    SetIconImage(target, customImage);
                    break;
                case IconType.Ok:
                    SetIconImage(target, Properties.Resources.Input_Box_Ok_128_x_128);
                    break;
                case IconType.Error:
                    SetIconImage(target, Properties.Resources.Input_Box_Critical_128_x_128);
                    break;
                case IconType.Exclamation:
                    SetIconImage(target, Properties.Resources.Input_Box_Warning_128_x_115);
                    break;
                case IconType.Information:
                    SetIconImage(target, Properties.Resources.Input_Box_Information_128_x_128);
                    break;
                case IconType.Question:
                    SetIconImage(target, Properties.Resources.Input_Box_Question_128_x_128);
                    break;
                case IconType.None:
                    SetIconImage(target, null);
                    break;
                case IconType.Stop:
                    SetIconImage(target, Properties.Resources.Input_Box_Stop_128_x_128);
                    break;
                case IconType.Hand:
                    SetIconImage(target, Properties.Resources.Input_Box_Hand_128_x_128);
                    break;
                case IconType.Warning:
                    SetIconImage(target, Properties.Resources.Input_Box_Warning_128_x_115);
                    break;
                case IconType.Asterisk:
                    SetIconImage(target, Properties.Resources.Input_Box_Asterisk_128_x_128);
                    break;
                case IconType.Shield:
                    if (Environment.OSVersion.Version.Major >= 10 && Environment.OSVersion.Version.Build >= 22000)
                    {
                        SetIconImage(target, Properties.Resources.Input_Box_UAC_Shield_Windows_11_128_x_128);
                    }
                    // Windows 10
                    else if (Environment.OSVersion.Version.Major == 10 && Environment.OSVersion.Version.Build <= 19044 /* RTM - 21H2 */)
                    {
                        SetIconImage(target, Properties.Resources.Input_Box_UAC_Shield_Windows_10_128_x_128);
                    }
                    else
                    {
                        SetIconImage(target, Properties.Resources.Input_Box_UAC_Shield_Windows_7_and_8_128_x_128);
                    }
                    break;
                case IconType.WindowsLogo:
                    // Because Windows 11 displays a generic application icon,
                    // we need to rely on a image instead
                    if (Environment.OSVersion.Version.Major >= 10 && Environment.OSVersion.Version.Build >= 22000)
                    {
                        SetIconImage(target, Properties.Resources.Input_Box_Windows_11_128_x_128);
                    }
                    // Windows 10
                    else if (Environment.OSVersion.Version.Major == 10 && Environment.OSVersion.Version.Build <= 19044 /* RTM - 21H2 */)
                    {
                        SetIconImage(target, Properties.Resources.Input_Box_Windows_10_128_x_121);
                    }
                    else
                    {
                        SetIconImage(target, SystemIcons.WinLogo.ToBitmap());
                    }
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