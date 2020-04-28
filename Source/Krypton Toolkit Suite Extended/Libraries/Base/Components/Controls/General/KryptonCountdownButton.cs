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

        private Timer _countdownTimer; //= new Timer();
        #endregion

        #region Properties
        public bool TimerEnabled { get => _timerEnabled; set => _timerEnabled = value; }

        public int Seconds { get; set; }
        #endregion

        #region Constructor
        public KryptonCountdownButton()
        {
            _countdownTimer = new Timer();

            _countdownTimer.Enabled = TimerEnabled;

            _countdownTimer.Interval = 1000;

            _countdownTimer.Tick += CountdownTimer_Tick;
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            _time++;

            if (Seconds != 0)
            {
                Text = $"{ Text } ({ Seconds - _time })";

                Enabled = false;
            }
            else
            {
                _countdownTimer.Stop();

                Enabled = true;
            }
        }
        #endregion

        #region Overrides

        #endregion
    }
}