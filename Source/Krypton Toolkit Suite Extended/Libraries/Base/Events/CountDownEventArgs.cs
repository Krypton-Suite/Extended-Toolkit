#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    public class CountDownEventArgs : EventArgs
    {
        #region Variables
        private bool _controlEnabled;

        private Control _control;

        private int _countdownTime;

        private string _text;

        private Timer tmp;
        #endregion

        #region Constructors
        public CountDownEventArgs(Control control, bool enabled, int seconds, string text)
        {
            _control = control;

            _controlEnabled = enabled;

            _countdownTime = seconds;

            _text = text;

            SetupControl(control, enabled, seconds, text);
        }

        private void SetupControl(Control control, bool enabled, int seconds, string text)
        {
            control.Enabled = enabled;

            control.Text = $"{ text } ({ seconds }s)";
        }
        #endregion

        #region Methods
        public void StartCountdown()
        {
            if (_countdownTime != 0)
            {
                _control.Text = $"{ _text } ({ _countdownTime }s)";

                tmp = new Timer();

                tmp.Interval = 1000;

                tmp.Tick += Tmp_Tick;
            }
        }

        private void Tmp_Tick(object sender, EventArgs e)
        {
            int ticker = 0;

            if (!_controlEnabled)
            {
                ticker++;

                _control.Text = $"{ _text } ({ _countdownTime }s)";

                if (ticker == _countdownTime)
                {
                    tmp.Stop();

                    _control.Enabled = true;
                }
            }
        }
        #endregion
    }
}