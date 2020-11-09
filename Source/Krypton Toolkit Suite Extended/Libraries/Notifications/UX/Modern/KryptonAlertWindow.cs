using Krypton.Toolkit.Suite.Extended.Notifications.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Notifications
{
    public class KryptonAlertWindow : KryptonForm
    {
        #region Design Code
        private KryptonPanel kpnlBackPane;
        private System.Windows.Forms.PictureBox ptbClose;
        private KryptonLabel klblMessage;
        private System.Windows.Forms.Timer timer;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.PictureBox ptbLogo;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.kpnlBackPane = new Krypton.Toolkit.KryptonPanel();
            this.ptbClose = new System.Windows.Forms.PictureBox();
            this.klblMessage = new Krypton.Toolkit.KryptonLabel();
            this.ptbLogo = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kpnlBackPane)).BeginInit();
            this.kpnlBackPane.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // kpnlBackPane
            // 
            this.kpnlBackPane.Controls.Add(this.ptbClose);
            this.kpnlBackPane.Controls.Add(this.klblMessage);
            this.kpnlBackPane.Controls.Add(this.ptbLogo);
            this.kpnlBackPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpnlBackPane.Location = new System.Drawing.Point(0, 0);
            this.kpnlBackPane.Name = "kpnlBackPane";
            this.kpnlBackPane.Size = new System.Drawing.Size(433, 80);
            this.kpnlBackPane.TabIndex = 0;
            // 
            // ptbClose
            // 
            this.ptbClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ptbClose.BackColor = System.Drawing.Color.Transparent;
            this.ptbClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptbClose.Image = global::Krypton.Toolkit.Suite.Extended.Notifications.Properties.Resources.close48px;
            this.ptbClose.Location = new System.Drawing.Point(395, 24);
            this.ptbClose.Name = "ptbClose";
            this.ptbClose.Size = new System.Drawing.Size(26, 33);
            this.ptbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbClose.TabIndex = 3;
            this.ptbClose.TabStop = false;
            this.ptbClose.Click += new System.EventHandler(this.ptbClose_Click);
            // 
            // klblMessage
            // 
            this.klblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.klblMessage.AutoSize = false;
            this.klblMessage.Location = new System.Drawing.Point(81, 12);
            this.klblMessage.Name = "klblMessage";
            this.klblMessage.Size = new System.Drawing.Size(307, 57);
            this.klblMessage.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblMessage.StateCommon.ShortText.TextV = Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.klblMessage.TabIndex = 2;
            this.klblMessage.Values.Text = "kryptonLabel1";
            // 
            // ptbLogo
            // 
            this.ptbLogo.BackColor = System.Drawing.Color.Transparent;
            this.ptbLogo.Image = global::Krypton.Toolkit.Suite.Extended.Notifications.Properties.Resources.sucess48px;
            this.ptbLogo.Location = new System.Drawing.Point(12, 12);
            this.ptbLogo.Name = "ptbLogo";
            this.ptbLogo.Size = new System.Drawing.Size(63, 57);
            this.ptbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbLogo.TabIndex = 1;
            this.ptbLogo.TabStop = false;
            // 
            // timer
            // 
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // KryptonAlertWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(433, 80);
            this.Controls.Add(this.kpnlBackPane);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "KryptonAlertWindow";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.kpnlBackPane)).EndInit();
            this.kpnlBackPane.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbLogo)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Properties

        private AlertAction _action;
        private int _interval, _positionX, _positionY;
        protected override bool ShowWithoutActivation => true;

        #endregion

        #region Constructor
        public KryptonAlertWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void ptbClose_Click(object sender, EventArgs e)
        {
            timer.Interval = 1;

            _action = AlertAction.CLOSE;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            switch (_action)
            {
                case AlertAction.START:
                    timer.Interval = 1;

                    Opacity += 1;

                    if (_positionX < Location.X)
                    {
                        Left--;
                    }
                    else if (Opacity == 1.0)
                    {
                        _action = AlertAction.WAIT;
                    }
                    break;
                case AlertAction.WAIT:
                    timer.Interval = _interval;

                    _action = AlertAction.CLOSE;
                    break;
                case AlertAction.CLOSE:
                    timer.Interval = 1;

                    Opacity -= 1;

                    Left -= 3;

                    if (Opacity == 0.0)
                    {
                        Close();
                    }
                    break;
            }
        }
        #endregion

        #region Methods
        /// <summary>Displays the alert.</summary>
        /// <param name="message">The message.</param>
        /// <param name="alertType">Type of the alert.</param>
        /// <param name="interval">The interval.</param>
        /// <param name="image">The image.</param>
        /// <param name="backColour">The back colour.</param>
        /// <param name="textColour">The text colour.</param>
        internal void DisplayAlert(string message, AlertType alertType, int interval, Image image = null, Color backColour = default, Color textColour = default)
        {
            Opacity = 0.0;

            StartPosition = FormStartPosition.Manual;

            for (int i = 1; i < 10; i++)
            {
                var windowName = $"Alert { i }";

                var window = (KryptonAlertWindow)Application.OpenForms[windowName];

                if (window == null)
                {
                    Name = windowName;

                    _positionX = Screen.PrimaryScreen.WorkingArea.Width - Width - 5;

                    _positionY = Screen.PrimaryScreen.WorkingArea.Height - Height * i - 5 * i;

                    Location = new Point(_positionX, _positionY);

                    break;
                }
            }

            _positionX = Screen.PrimaryScreen.WorkingArea.Width - Width - 5;

            switch (alertType)
            {
                case AlertType.SUCESS:
                    ptbLogo.Image = Resources.sucess48px;

                    ChangeColour(Color.SeaGreen, Color.White);
                    break;
                case AlertType.INFORMATION:
                    ptbLogo.Image = Resources.information48px;

                    ChangeColour(Color.RoyalBlue, Color.White);
                    break;
                case AlertType.WARNING:
                    ptbLogo.Image = Resources.warning48px;

                    ChangeColour(Color.FromArgb(230, 126, 34), Color.White);
                    break;
                case AlertType.ERROR:
                    ptbLogo.Image = Resources.error48px;

                    ChangeColour(Color.FromArgb(231, 76, 60), Color.White);
                    break;
                case AlertType.CUSTOM:
                    ptbLogo.Image = image ?? Resources.information48px;

                    ChangeColour(backColour, textColour);
                    break;
            }

            klblMessage.Text = message;

            _interval = interval;

            _action = AlertAction.START;

            timer.Interval = 1;

            timer.Start();

            Show();
        }

        private void ChangeColour(Color backColour, Color textColour)
        {
            // Form Colour
            StateCommon.Border.Color1 = backColour;

            StateCommon.Border.Color2 = backColour;

            StateCommon.Back.Color1 = backColour;

            StateCommon.Back.Color2 = backColour;

            // Panel colour
            kpnlBackPane.StateCommon.Color1 = backColour;

            kpnlBackPane.StateCommon.Color2 = backColour;

            // Label colour
            klblMessage.StateCommon.ShortText.Color1 = textColour;

            klblMessage.StateCommon.ShortText.Color2 = textColour;
        }
        #endregion
    }
}