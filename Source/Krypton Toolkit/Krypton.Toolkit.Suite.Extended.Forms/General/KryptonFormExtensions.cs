#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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

using Timer = System.Windows.Forms.Timer;

namespace Krypton.Toolkit.Suite.Extended.Forms
{
    public static class KryptonFormExtensions
    {
        #region Implementation

        /// <summary>
        /// Shows a notification on the form.
        /// </summary>
        /// <param name="form">The form to display the notification.</param>
        /// <param name="message">The message (notification) that should be displayed.</param>
        /// <param name="duration">The duration of the notification (specify -1 for infinite).</param>
        /// <param name="opacity">The opacity of the background (0..1).</param>
        /// <param name="glowColor">The glow color of the message rectangle.</param>
        /// <param name="backColor">The background color of the message rectangle.</param>
        /// <param name="foreColor">The text color of the message.</param>
        public static Control Notify(this VisualKryptonFormExtended form, string message, int duration, double opacity, Color glowColor, Color backColor, Color foreColor)
        {
            var font = new Font(form.Font.FontFamily, form.Font.Size * 1.2f, form.Font.Unit);
            var proposedSize = new Size(form.Width * 6 / 10, 0);
            var size = TextRenderer.MeasureText(message, font, proposedSize, TextFormatFlags.WordBreak);
            var panel = new TransparentPanel();
            panel.Size = form.ClientRectangle.Size;
            panel.Location = new Point(0, 0);
            panel.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            panel.Paint += (sender, e) =>
            {
                var g = e.Graphics;
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb((int)Math.Ceiling(255.0 * opacity), Color.Black)), 0, 0, panel.Width, panel.Height);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                var rectangle = new Rectangle(0, 0, size.Width + 20, size.Height + 10);
                rectangle.Offset(form.Width / 2 - rectangle.Width / 2, form.Height / 2 - rectangle.Height / 2);
                g.Glow(rectangle, glowColor, 30, 10);
                g.FillRoundRectangle(new SolidBrush(backColor), rectangle, 5);
                TextRenderer.DrawText(g, message, font, rectangle, foreColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak);
            };
            form.Controls.Add(panel);
            panel.BringToFront();

            if (duration > 0)
            {
                var timer = new Timer();
                timer.Interval = duration;
                timer.Tick += (sender, e) =>
                {
                    form.Controls.Remove(panel);
                    panel = null;
                    timer.Stop();
                };
                timer.Start();
            }

            form.Refresh();
            return panel;
        }

        /// <summary>
        /// Shows a notification on the form with a black background, white text, red glowing and an opaque layer of 0.3 opacity for 5 seconds.
        /// </summary>
        /// <param name="form">The form to display the notification.</param>
        /// <param name="message">The message (notification) that should be displayed.</param>
        public static Control Notify(this VisualKryptonFormExtended form, string message) => form.Notify(message, 5000);

        /// <summary>
        /// Shows a notification on the form with a black background, white text, red glowing and an opaque layer of 0.3.
        /// </summary>
        /// <param name="form">The form to display the notification.</param>
        /// <param name="message">The message (notification) that should be displayed.</param>
        /// <param name="duration">The duration of the notification (specify -1 for infinite).</param>
        public static Control Notify(this VisualKryptonFormExtended form, string message, int duration) => form.Notify(message, duration, 0.3);

        /// <summary>
        /// Shows a notification on the form with a black background, white text and red glowing.
        /// </summary>
        /// <param name="form">The form to display the notification.</param>
        /// <param name="message">The message (notification) that should be displayed.</param>
        /// <param name="duration">The duration of the notification (specify -1 for infinite).</param>
        /// <param name="opacity">The opacity of the background (0..1).</param>
        public static Control Notify(this VisualKryptonFormExtended form, string message, int duration, double opacity) => form.Notify(message, duration, opacity, Color.Red);

        /// <summary>
        /// Shows a notification on the form with a black background, white text and an opaque layer of 0.3 opacity.
        /// </summary>
        /// <param name="form">The form to display the notification.</param>
        /// <param name="message">The message (notification) that should be displayed.</param>
        /// <param name="duration">The duration of the notification (specify -1 for infinite).</param>
        /// <param name="glowColor">The glow color of the message rectangle.</param>
        public static Control Notify(this VisualKryptonFormExtended form, string message, int duration, Color glowColor) => form.Notify(message, duration, 0.3, glowColor);

        /// <summary>
        /// Shows a notification on the form with a black background and white text.
        /// </summary>
        /// <param name="form">The form to display the notification.</param>
        /// <param name="message">The message (notification) that should be displayed.</param>
        /// <param name="duration">The duration of the notification (specify -1 for infinite).</param>
        /// <param name="opacity">The opacity of the background (0..1).</param>
        /// <param name="glowColor">The glow color of the message rectangle.</param>
        public static Control Notify(this VisualKryptonFormExtended form, string message, int duration, double opacity, Color glowColor) => form.Notify(message, duration, opacity, glowColor, Color.Black, Color.White);

        #endregion
    }
}
