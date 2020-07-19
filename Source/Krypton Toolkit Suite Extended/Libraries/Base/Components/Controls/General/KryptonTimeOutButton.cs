using System;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    [ToolboxBitmap(typeof(KryptonButton))]
    public class KryptonTimeOutButton : KryptonButton
    {
        #region Variables
        private int _seconds;
        #endregion

        #region Properties
        public int Seconds { get => _seconds; set { _seconds = value; Invalidate(); } }
        #endregion

        #region Custom Event
        public delegate void CountdownEventHandler(object sender, CountDownEventArgs e);

        public event CountdownEventHandler Countdown;

        protected virtual void OnCountdown(object sender, CountDownEventArgs e) => Countdown?.Invoke(sender, e);
        #endregion

        #region Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
        }
        #endregion
    }
}