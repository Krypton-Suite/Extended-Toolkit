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

#pragma warning disable CS8602
namespace Krypton.Toolkit.Suite.Extended.Controls
{
    internal class KryptonProgressBarExtendedVersion2Designer : ControlDesigner
    {
        public KryptonProgressBarExtendedVersion2Designer()
        {
        }

        /* Gets a list of System.Windows.Forms.Design.Behavior.SnapLine 
        objects, representing alignment points for the edited control. */
        public override IList? SnapLines
        {
            get
            {
                // Get the SnapLines collection from the base class
                ArrayList? snapList = base.SnapLines as ArrayList;

                // Calculate the Baseline for the Font used by the Control and add it to the SnapLines
                int textBaseline = GetBaseline(base.Control, ContentAlignment.MiddleCenter);
                if (textBaseline > 0) snapList.Add(new SnapLine(SnapLineType.Baseline, textBaseline, SnapLinePriority.Medium));

                return snapList;
            }
        }

        private static int GetBaseline(Control ctrl, ContentAlignment alignment)
        {
            int textAscent = 0;
            int textHeight = 0;

            // Retrieve the ClientRect of the Control
            Rectangle clientRect = ctrl.ClientRectangle;

            // Create a Graphics object for the Control
            using (Graphics graphics = ctrl.CreateGraphics())
            {
                // Retrieve the device context Handle
                IntPtr hDC = graphics.GetHdc();

                // Create a wrapper for the Font of the Control
                Font controlFont = ctrl.Font;
                HandleRef tempFontHandle = new HandleRef(controlFont, controlFont.ToHfont());

                try
                {
                    // Create a wrapper for the device context
                    HandleRef deviceContextHandle = new HandleRef(ctrl, hDC);

                    // Select the Font into the device context
                    IntPtr originalFont = SafeNativeMethods.SelectObject(deviceContextHandle, tempFontHandle);

                    // Create a TEXTMETRIC and calculate metrics for the selected Font
                    NativeMethods.TEXTMETRIC tEXTMETRIC = new NativeMethods.TEXTMETRIC();
                    if (SafeNativeMethods.GetTextMetrics(deviceContextHandle, ref tEXTMETRIC) != 0)
                    {
                        textAscent = (tEXTMETRIC.tmAscent + 1);
                        textHeight = tEXTMETRIC.tmHeight;
                    }

                    // Restore original Font
                    HandleRef originalFontHandle = new HandleRef(ctrl, originalFont);
                    SafeNativeMethods.SelectObject(deviceContextHandle, originalFontHandle);
                }
                finally
                {
                    // Cleanup tempFont
                    SafeNativeMethods.DeleteObject(tempFontHandle);

                    // Release device context
                    graphics.ReleaseHdc(hDC);
                }
            }

            // Calculate return value based on the specified alignment; first check top alignment
            if ((alignment & (ContentAlignment.TopLeft | ContentAlignment.TopCenter | ContentAlignment.TopRight)) != 0)
            {
                return (clientRect.Top + textAscent);
            }

            // Check middle alignment
            if ((alignment & (ContentAlignment.MiddleLeft | ContentAlignment.MiddleCenter | ContentAlignment.MiddleRight)) == 0)
            {
                return ((clientRect.Bottom - textHeight) + textAscent);
            }

            // Assume bottom alignment
            return ((int)Math.Round((double)clientRect.Top + (double)clientRect.Height / 2 - (double)textHeight / 2 + (double)textAscent));
        }
    }
}