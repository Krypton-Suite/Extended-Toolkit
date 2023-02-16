#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
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

        /// <summary>Calibrates the UI layout.</summary>
        /// <param name="owner">The owner.</param>
        /// <param name="controls">The controls.</param>
        /// <param name="rightToLeft">The right to left.</param>
        public static void CalibrateUILayout(KryptonForm owner, Control[] controls, RightToLeft rightToLeft)
        {
            owner.RightToLeft = rightToLeft;

            if (controls.Length > 0)
            {
                foreach (Control control in controls)
                {
                    control.RightToLeft = rightToLeft;
                }
            }
        }

        /// <summary>Configures the toast notification button.</summary>
        /// <param name="toastButton">The toast button.</param>
        /// <param name="actionType">Type of the action.</param>
        /// <param name="isAcceptButton">The is accept button.</param>
        /// <param name="isDenyButton">The is deny button.</param>
        /// <param name="openInExplorer">The open in explorer.</param>
        /// <param name="optionalParameters">The optional parameters.</param>
        /// <param name="processName">Name of the process.</param>
        /// <param name="text">The text.</param>
        public static void ConfigureToastNotificationButton(KryptonToastButton toastButton, ActionType actionType,
            bool? isAcceptButton, bool? isDenyButton, bool? openInExplorer, object? optionalParameters = null,
            string? processName = null, string? text = null)
        {
            toastButton.ActionType = actionType;

            toastButton.IsAcceptButton = isAcceptButton ?? false;

            toastButton.IsDenyButton = isDenyButton ?? false;

            toastButton.OpenInExplorer = openInExplorer ?? false;

            toastButton.OptionalParameters = optionalParameters;

            toastButton.ProcessName = processName ?? string.Empty;

            toastButton.Text = text ?? string.Empty;
        }

        #endregion
    }
}