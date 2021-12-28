#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
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
        private void MarqueeTimer_Tick(object sender, EventArgs e)
        {
            offset = (offset - Speed);

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