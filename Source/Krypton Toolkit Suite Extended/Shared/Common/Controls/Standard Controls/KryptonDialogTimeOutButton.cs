
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Common
{
    [ToolboxItem(false)]
    public class KryptonDialogTimeOutButton : KryptonButton
    {
        #region Variables
        private bool _enableOnTimeOut, _startCountDown, _performClickOnTimeOut;

        private int _seconds, _time;

        private Timer _timer = new Timer() { Enabled = true, Interval = 1000 };
        #endregion

        #region Properties
        [DefaultValue(false)]
        public bool EnableOnTimeOut { get => _enableOnTimeOut; set => _enableOnTimeOut = value; }

        [DefaultValue(false)]
        public bool StartCountDown { get => _startCountDown; set => _startCountDown = value; }

        [DefaultValue(false)]
        public bool PerformClickOnTimeOut { get => _performClickOnTimeOut; set => _performClickOnTimeOut = value; }

        [DefaultValue(60)]
        public int Seconds { get => _seconds; set { _seconds = value; Invalidate(); } }
        #endregion

        #region Constructor
        public KryptonDialogTimeOutButton()
        {
            _enableOnTimeOut = false;

            _startCountDown = false;

            _performClickOnTimeOut = false;

            _seconds = 60;
        }
        #endregion

        #region Methods
        public void StartCountdown()
        {
            //_timer = new Timer() { Enabled = true, Interval = 1000 };

            if (_seconds != 0)
            {
                Text = Text + $" ({ _seconds - _time}s)";

                _timer.Tick += timer_Tick;

                _timer.Start();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            _time++;

            Text = $"{ Text } ({ _seconds - _time }s)";

            if (_time == _seconds)
            {
                if (_enableOnTimeOut)
                {
                    Enabled = true;
                }
            }
        }
        #endregion

        #region Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
        #endregion
    }
}
