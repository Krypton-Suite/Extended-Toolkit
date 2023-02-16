#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Notifications
{
    public class KryptonAlertWindow : KryptonForm
    {
        #region Design Code
        private KryptonPanel kpnlBackground;
        private System.Windows.Forms.PictureBox ptbClose;
        private KryptonLabel klblContent;
        private KryptonLabel klblHeader;
        private KryptonWrapLabel kwlContent;
        private System.Windows.Forms.PictureBox pbxLogo;

        private void InitializeComponent()
        {
            this.kpnlBackground = new Krypton.Toolkit.KryptonPanel();
            this.kwlContent = new Krypton.Toolkit.KryptonWrapLabel();
            this.ptbClose = new System.Windows.Forms.PictureBox();
            this.klblContent = new Krypton.Toolkit.KryptonLabel();
            this.klblHeader = new Krypton.Toolkit.KryptonLabel();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.kpnlBackground)).BeginInit();
            this.kpnlBackground.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // kpnlBackground
            // 
            this.kpnlBackground.Controls.Add(this.kwlContent);
            this.kpnlBackground.Controls.Add(this.ptbClose);
            this.kpnlBackground.Controls.Add(this.klblContent);
            this.kpnlBackground.Controls.Add(this.klblHeader);
            this.kpnlBackground.Controls.Add(this.pbxLogo);
            this.kpnlBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kpnlBackground.Location = new System.Drawing.Point(0, 0);
            this.kpnlBackground.Name = "kpnlBackground";
            this.kpnlBackground.Size = new System.Drawing.Size(417, 83);
            this.kpnlBackground.TabIndex = 0;
            // 
            // kwlContent
            // 
            this.kwlContent.AutoSize = false;
            this.kwlContent.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kwlContent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(57)))), ((int)(((byte)(91)))));
            this.kwlContent.Location = new System.Drawing.Point(82, 12);
            this.kwlContent.Name = "kwlContent";
            this.kwlContent.Size = new System.Drawing.Size(291, 57);
            this.kwlContent.Text = "kryptonWrapLabel1";
            this.kwlContent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.kwlContent.Visible = false;
            // 
            // ptbClose
            // 
            this.ptbClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ptbClose.BackColor = System.Drawing.Color.Transparent;
            this.ptbClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptbClose.Image = global::Krypton.Toolkit.Suite.Extended.Notifications.Properties.Resources.close48px;
            this.ptbClose.Location = new System.Drawing.Point(379, 25);
            this.ptbClose.Name = "ptbClose";
            this.ptbClose.Size = new System.Drawing.Size(26, 33);
            this.ptbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbClose.TabIndex = 5;
            this.ptbClose.TabStop = false;
            this.ptbClose.Click += new System.EventHandler(this.ptbClose_Click);
            // 
            // klblContent
            // 
            this.klblContent.Location = new System.Drawing.Point(82, 38);
            this.klblContent.Name = "klblContent";
            this.klblContent.Size = new System.Drawing.Size(88, 20);
            this.klblContent.TabIndex = 4;
            this.klblContent.Values.Text = "kryptonLabel1";
            // 
            // klblHeader
            // 
            this.klblHeader.LabelStyle = Krypton.Toolkit.LabelStyle.BoldControl;
            this.klblHeader.Location = new System.Drawing.Point(82, 13);
            this.klblHeader.Name = "klblHeader";
            this.klblHeader.Size = new System.Drawing.Size(98, 19);
            this.klblHeader.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.klblHeader.TabIndex = 3;
            this.klblHeader.Values.Text = "kryptonLabel1";
            // 
            // pbxLogo
            // 
            this.pbxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbxLogo.Image = global::Krypton.Toolkit.Suite.Extended.Notifications.Properties.Resources.sucess48px;
            this.pbxLogo.Location = new System.Drawing.Point(12, 12);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(63, 57);
            this.pbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxLogo.TabIndex = 2;
            this.pbxLogo.TabStop = false;
            // 
            // KryptonAlertWindow
            // 
            this.ClientSize = new System.Drawing.Size(417, 83);
            this.Controls.Add(this.kpnlBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "KryptonAlertWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            ((System.ComponentModel.ISupportInitialize)(this.kpnlBackground)).EndInit();
            this.kpnlBackground.ResumeLayout(false);
            this.kpnlBackground.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private AlertAction _action;

        private int _interval, _positionX, _positionY;

        private System.Windows.Forms.Timer _tmrAlert = null;
        #endregion

        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="KryptonAlertWindow" /> class.</summary>
        public KryptonAlertWindow()
        {
            InitializeComponent();

            _tmrAlert = new System.Windows.Forms.Timer() { Enabled = true, Interval = 10 };

            _tmrAlert.Tick += Alert_Tick;
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
        /// <param name="headerText">Define the header text.</param>
        internal void DisplayAlert(string message, AlertType alertType, int interval, Image? image = null, Color backColour = default, Color textColour = default, string headerText = "")
        {
            Opacity = 0.0;

            StartPosition = FormStartPosition.Manual;

            for (int i = 1; i < 10; i++)
            {
                var windowName = $"Alert {i}";

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
                case AlertType.Success:
                    pbxLogo.Image = Properties.Resources.sucess48px;

                    ChangeColour(Color.SeaGreen, Color.White);
                    break;
                case AlertType.Information:
                    pbxLogo.Image = Properties.Resources.information48px;

                    ChangeColour(Color.RoyalBlue, Color.White);
                    break;
                case AlertType.Warning:
                    pbxLogo.Image = Properties.Resources.warning48px;

                    ChangeColour(Color.FromArgb(230, 126, 34), Color.White);
                    break;
                case AlertType.Error:
                    pbxLogo.Image = Properties.Resources.error48px;

                    ChangeColour(Color.FromArgb(231, 76, 60), Color.White);
                    break;
                case AlertType.Custom:
                    pbxLogo.Image = image ?? Properties.Resources.information48px;

                    ChangeColour(backColour, textColour);
                    break;
            }

            if (string.IsNullOrWhiteSpace(headerText))
            {
                kwlContent.Visible = true;

                kwlContent.Text = message;
            }
            else
            {
                kwlContent.Visible = false;

                klblHeader.Text = headerText;

                klblContent.Text = message;
            }

            _interval = interval;

            _action = AlertAction.Start;

            _tmrAlert.Interval = 1;

            _tmrAlert.Start();

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
            kpnlBackground.StateCommon.Color1 = backColour;

            kpnlBackground.StateCommon.Color2 = backColour;

            klblHeader.StateCommon.ShortText.Color1 = textColour;

            klblHeader.StateCommon.ShortText.Color2 = textColour;

            // Label colour
            klblContent.StateCommon.ShortText.Color1 = textColour;

            klblContent.StateCommon.ShortText.Color2 = textColour;
        }
        #endregion

        #region Event Handlers
        private void Alert_Tick(object sender, EventArgs e)
        {
            switch (_action)
            {
                case AlertAction.Start:
                    _tmrAlert.Interval = 1;

                    Opacity += 1;

                    if (_positionX < Location.X)
                    {
                        Left--;
                    }
                    else if (Opacity == 1.0)
                    {
                        _action = AlertAction.Wait;
                    }
                    break;
                case AlertAction.Wait:
                    _tmrAlert.Interval = _interval;

                    _action = AlertAction.Close;
                    break;
                case AlertAction.Close:
                    _tmrAlert.Interval = 1;

                    Opacity -= 1;

                    Left -= 3;

                    if (Opacity == 0.0)
                    {
                        Close();
                    }
                    break;
            }
        }

        private void ptbClose_Click(object sender, EventArgs e)
        {
            _tmrAlert.Interval = 1;

            _action = AlertAction.Close;
        }
        #endregion

        #region Overrides
        protected override bool ShowWithoutActivation => true;
        #endregion
    }
}