using System;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Base
{
    [ToolboxBitmap(typeof(KryptonButton))]
    public class KryptonCountdownButton : KryptonButton
    {
        #region Variables
        private bool _timerEnabled;

        private int _time;

        private Timer _countdownTimer = new Timer();
        #endregion

        #region Properties
        public bool TimerEnabled { get => _timerEnabled; set => _timerEnabled = value; }

        public int CountdownTime { get => _time; set { _time = value; Invalidate(); } }
        #endregion

        #region Constructor
        public KryptonCountdownButton()
        {
            _countdownTimer = new Timer();

            _countdownTimer.Interval = 1000;

            _countdownTimer.Tick += CountdownTimer_Tick;
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            int tmp = CountdownTime;

            do
            {
                tmp--;

                Text = $"{ Text } ({ tmp })";

                Enabled = false;
            } while (tmp > 0);
        }
        #endregion
    }
}