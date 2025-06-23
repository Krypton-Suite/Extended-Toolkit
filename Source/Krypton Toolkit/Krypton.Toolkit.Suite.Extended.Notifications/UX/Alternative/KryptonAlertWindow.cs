#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Notifications;

public partial class KryptonAlertWindow : KryptonForm
{
    #region Variables
    private AlertAction _action;

    private int _interval, _positionX, _positionY;

    private Timer? _tmrAlert = null;
    #endregion

    #region Constructor
    /// <summary>Initializes a new instance of the <see cref="KryptonAlertWindow" /> class.</summary>
    public KryptonAlertWindow()
    {
        InitializeComponent();

        _tmrAlert = new() { Enabled = true, Interval = 10 };

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

            var window = Application.OpenForms[windowName] as KryptonAlertWindow;

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