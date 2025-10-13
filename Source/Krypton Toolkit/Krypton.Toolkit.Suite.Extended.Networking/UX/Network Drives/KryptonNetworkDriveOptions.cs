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

namespace Krypton.Toolkit.Suite.Extended.Networking;

public partial class KryptonNetworkDriveOptions : KryptonForm
{
    #region Variables
    private char[] _validDriveLetters;

    private NetworkDrives? _networkDrives = new();

    private NetworkUtilities _utilities = new();
    #endregion

    #region Constructors
    public KryptonNetworkDriveOptions()
    {
        InitializeComponent();
    }

    #endregion

    private void KryptonNetworkDriveOptions_Load(object sender, EventArgs e)
    {
        _utilities.GetAvailableDriveLetters(_validDriveLetters);

        foreach (char item in _validDriveLetters)
        {
            kcmbDriveLetter.Items.Add(item.ToString());
        }

        // set the address field to a share name for the current computer

        ktxtShareAddress.Text = $@"\\\\{SystemInformation.ComputerName}\\C$";
    }

    private void kbtnMapDrive_Click(object sender, EventArgs e)
    {
        UpdateStatus($"Mapping '{ktxtShareAddress.Text}' to drive '{kcmbDriveLetter.Text}'");

        try
        {
            if (_networkDrives != null)
            {
                _networkDrives.Force = kcbForceDisConnection.Checked;

                _networkDrives.Persistent = kcbPersistantConnection.Checked;

                _networkDrives.LocalDrive = kcmbDriveLetter.Text;

                _networkDrives.PromptForCredentials = kcbPromptForCredentials.Checked;

                _networkDrives.ShareName = ktxtShareAddress.Text;

                _networkDrives.SaveCredentials = kcbSaveCredentials.Checked;

                if (ktxtUsername.Text == "" && ktxtPassword.Text == "")
                {
                    _networkDrives.MapDrive();
                }
                else if (ktxtUsername.Text == "")
                {
                    _networkDrives.MapDrive(ktxtPassword.Text);
                }
                else
                {
                    _networkDrives.MapDrive(ktxtUsername.Text, ktxtPassword.Text);
                }
            }

            UpdateStatus("Drive mapping was successful!");
        }
        catch (Exception exc)
        {
            UpdateStatus($"Cannot map drive! - {exc.Message}");

            InternalKryptonMessageBoxExtended.Show(this, $"Cannot map drive!\nError: {exc.Message}");
        }

        _networkDrives = null;
    }

    private void kbtnDisconnect_Click(object sender, EventArgs e)
    {
        UpdateStatus("Disconnecting drive...");

        try
        {
            //unmap the drive
            if (_networkDrives != null)
            {
                _networkDrives.Force = kcbForceDisConnection.Checked;

                _networkDrives.LocalDrive = kcmbDriveLetter.Text;

                _networkDrives.UnMapDrive();
            }

            //update status
            UpdateStatus("Drive disconnection successful");
        }
        catch (Exception err)
        {
            //report error
            UpdateStatus($"Cannot disconnect drive! - {err.Message}");

            InternalKryptonMessageBoxExtended.Show(this, $"Cannot disconnect drive!\nError: {err.Message}");
        }

        _networkDrives = null;
    }

    private void UpdateStatus(string text) => tslStatus.Text = text;
}