using System;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    public class KryptonMarqueeLabel : KryptonLabel
    {
        int offset;

        public Timer MarqueeTimer { get; set; }

        public int Speed { get; set; }

        public int YOffset { get; set; }

        public KryptonMarqueeLabel()
        {
            YOffset = 0;

            Speed = 1;

            MarqueeTimer = new Timer();

            MarqueeTimer.Interval = 25;

            MarqueeTimer.Enabled = true;

            MarqueeTimer.Tick += MarqueeTimer_Tick;
        }

        private void MarqueeTimer_Tick(object sender, EventArgs e)
        {
            offset = (offset - Speed);

            if (offset < -ClientSize.Width)
            {
                offset = 0;
            }

            Invalidate();
        }

        public void Start() => MarqueeTimer.Start();

        public void Stop() => MarqueeTimer.Stop();


    }
}