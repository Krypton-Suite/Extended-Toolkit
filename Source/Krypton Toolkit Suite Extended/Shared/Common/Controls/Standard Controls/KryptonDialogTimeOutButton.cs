using System.ComponentModel;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Common
{
    [ToolboxItem(false)]
    public class KryptonDialogTimeOutButton : KryptonButton
    {
        #region Variables
        private bool _enableOnTimeOut;

        private int _seconds, _time;

        private Timer _timer;
        #endregion

        #region Properties
        public bool EnableOnTimeOut { get => _enableOnTimeOut; set => _enableOnTimeOut = value; }

        public int Seconds { get => _seconds; set { _seconds = value; Invalidate(); } }
        #endregion

        #region Constructor
        public KryptonDialogTimeOutButton()
        {
            _enableOnTimeOut = false;

            _seconds = 60;
        }
        #endregion

        #region Methods
        public void StartCountdown()
        {
            _timer = new Timer() { Enabled = true, Interval = 1000 };

            if (_seconds != 0)
            {
                Text = Text + $" ({ _seconds - _time}s)";

                _timer.Tick += timer_Tick;

                _timer.Start();
            }
        }

        private void timer_Tick(object sender, System.EventArgs e)
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
    }
}
