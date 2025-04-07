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

namespace Krypton.Toolkit.Suite.Extended.Controls
{
    public class KryptonMarqueeLabel : KryptonLabel
    {
        int offset;

        /// <summary>Gets or sets the marquee timer.</summary>
        /// <value>The marquee timer.</value>
        public System.Windows.Forms.Timer MarqueeTimer { get; set; }

        /// <summary>Gets or sets the speed of the marquee.</summary>
        /// <value>The speed.</value>
        public int Speed { get; set; }

        /// <summary>Gets or sets the y offset.</summary>
        /// <value>The y offset.</value>
        public int YOffset { get; set; }

        /// <summary>Initializes a new instance of the <see cref="KryptonMarqueeLabel" /> class.</summary>
        public KryptonMarqueeLabel()
        {
            YOffset = 0;

            Speed = 1;

            MarqueeTimer = new System.Windows.Forms.Timer();

            MarqueeTimer.Interval = 25;

            MarqueeTimer.Enabled = true;

            MarqueeTimer.Tick += MarqueeTimer_Tick;
        }

        /// <summary>Handles the Tick event of the MarqueeTimer control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs" /> instance containing the event data.</param>
        private void MarqueeTimer_Tick(object? sender, EventArgs e)
        {
            offset = offset - Speed;

            if (offset < -ClientSize.Width)
            {
                offset = 0;
            }

            Invalidate();
        }

        /// <summary>Starts the marquee animation.</summary>
        public void Start() => MarqueeTimer.Start();

        /// <summary>Stops the marquee animation.</summary>
        public void Stop() => MarqueeTimer.Stop();


    }
}