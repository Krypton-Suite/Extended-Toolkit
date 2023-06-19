using Size = System.Drawing.Size;
using Timer = System.Windows.Forms.Timer;

namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    public partial class NetSparkleToastNotifierWindow : KryptonForm
    {
        #region Instance Fields

        private Timer _goUpTimer;
        private Timer _goDownTimer;
        private Timer _pauseTimer;
        private int _startPosX;
        private int _startPosY;

        #endregion

        #region Public

        public Action<List<AppCastItem>> ClickAction { get; set; }

        public List<AppCastItem> Updates { get; set; }

        #endregion

        #region Identity

        public NetSparkleToastNotifierWindow(Icon? applicationIcon = null)
        {
            InitializeComponent();

            TopMost = true;

            _goUpTimer = new Timer();

            _goDownTimer = new Timer();

            _pauseTimer = new Timer();

            _goUpTimer.Interval = 25;

            _goDownTimer.Interval = 25;

            _pauseTimer.Interval = 15000;

            _goUpTimer.Tick += GoUpTimer_Tick;

            _goDownTimer.Tick += GoDownTimer_Tick;

            _pauseTimer.Tick += PauseTimer_Tick;

            if (applicationIcon != null)
            {
                Icon = applicationIcon;

                pbxApplicationIcon.Image = new Icon(applicationIcon, new Size(64, 64)).ToBitmap();
            }
            else
            {
                pbxApplicationIcon.Visible = false;
            }
        }

        #endregion

        #region Implementation

        private void PauseTimer_Tick(object sender, EventArgs e)
        {
            _pauseTimer.Stop();

            _goDownTimer.Start();
        }

        private void GoDownTimer_Tick(object sender, EventArgs e)
        {
            //Lower window by 5 pixels
            _startPosY += 5;
            //If window is fully visible stop the timer
            if (_startPosY > Screen.PrimaryScreen.WorkingArea.Height)
            {
                _goDownTimer.Stop();
                Close();
            }
            else
            {
                SetDesktopLocation(_startPosX, _startPosY);
            }
        }

        private void GoUpTimer_Tick(object sender, EventArgs e)
        {
            //Lift window by 5 pixels
            _startPosY -= 5;
            //If window is fully visible stop the timer
            if (_startPosY < Screen.PrimaryScreen.WorkingArea.Height - Height)
            {
                _goUpTimer.Stop();
                _pauseTimer.Start();
            }
            else
            {
                SetDesktopLocation(_startPosX, _startPosY);
            }
        }

        private void kllCallToAction_LinkClicked(object sender, EventArgs e) => NetSparkleToastNotifierWindow_Click(null, null);

        private void NetSparkleToastNotifierWindow_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            ClickAction.Invoke(Updates);
            Close();
        }

        /// <summary>
        /// Show the toast
        /// </summary>
        /// <param name="message">Main message of the toast</param>
        /// <param name="callToAction">Text of the hyperlink</param>
        /// <param name="seconds">How long to show before it goes back down</param>
        public void Show(string message, string callToAction, int seconds)
        {
            kwlMessage.Text = message;
            kllCallToAction.Text = callToAction;
            _pauseTimer.Interval = 1000 * seconds;
            Show();
        }

        #endregion

        #region Protected

        protected override void OnLoad(EventArgs e)
        {
            _startPosX = Screen.PrimaryScreen.WorkingArea.Width - Width;

            _startPosY = Screen.PrimaryScreen.WorkingArea.Height;

            SetDesktopLocation(_startPosX, _startPosY);

            base.OnLoad(e);

            _goUpTimer.Start();
        }

        #endregion
    }
}
