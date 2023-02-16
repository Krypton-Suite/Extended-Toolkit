﻿#region MIT License
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

namespace Krypton.Toolkit.Suite.Extended.Networking
{
    internal class Info
    {
        public Info(KryptonPanel updatePanel)
        {
            updatePanel.Dock = DockStyle.Fill;
            updatePanel.Controls.Clear();

            FlowLayoutPanel flp1 = new FlowLayoutPanel();
            flp1.Dock = DockStyle.Fill;
            flp1.FlowDirection = FlowDirection.LeftToRight;
            flp1.Padding = new Padding(20);

            KryptonLabel lblNetworks = new KryptonLabel();
            lblNetworks.StateCommon.ShortText.TextV = PaletteRelativeAlign.Near;
            lblNetworks.Text = "Networks";

            KryptonComboBox cboNetworks = new KryptonComboBox();
            List<NetworkInterface> interfaces = new();

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    cboNetworks.Items.Add(nic.Name);
                    interfaces.Add(nic);
                }
            }

            cboNetworks.SelectedIndex = 0;
            NetworkInterface selectedNic = interfaces[0];

            KryptonLabel lblMACAddress = new KryptonLabel();
            lblMACAddress.StateCommon.ShortText.TextV = PaletteRelativeAlign.Near;
            lblMACAddress.Text = "Network Address";

            KryptonLabel lblMACAddressValue = new KryptonLabel();
            lblMACAddressValue.StateCommon.ShortText.TextV = PaletteRelativeAlign.Near;
            lblMACAddressValue.Text = selectedNic.GetPhysicalAddress().ToString();

            KryptonLabel lblIP = new KryptonLabel();
            lblIP.StateCommon.ShortText.TextV = PaletteRelativeAlign.Near;
            lblIP.Text = "IP Address";

            KryptonLabel lblIPValue = new KryptonLabel();
            lblIPValue.StateCommon.ShortText.TextV = PaletteRelativeAlign.Near;

            foreach (UnicastIPAddressInformation ip in selectedNic.GetIPProperties().UnicastAddresses)
            {
                if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    lblIPValue.Text = ip.Address.ToString();
                    break;
                }
            }

            KryptonLabel lblSpeed = new KryptonLabel();
            lblSpeed.StateCommon.ShortText.TextV = PaletteRelativeAlign.Near;
            lblSpeed.Text = "Speed";

            KryptonLabel lblSpeedValue = new KryptonLabel();
            lblSpeedValue.StateCommon.ShortText.TextV = PaletteRelativeAlign.Near;
            lblSpeedValue.Text = selectedNic.Speed.ToString() + " bits";

            KryptonLabel lblMachineName = new KryptonLabel();
            lblMachineName.StateCommon.ShortText.TextV = PaletteRelativeAlign.Near;
            lblMachineName.Text = "Machine Name";

            KryptonLabel lblMachineNameValue = new KryptonLabel();
            lblMachineNameValue.StateCommon.ShortText.TextV = PaletteRelativeAlign.Near;
            lblMachineNameValue.Text = System.Windows.Forms.SystemInformation.ComputerName;

            KryptonLabel lblUserName = new KryptonLabel();
            lblUserName.StateCommon.ShortText.TextV = PaletteRelativeAlign.Near;
            lblUserName.Text = "Username";

            KryptonLabel lblUserNameValue = new KryptonLabel();
            lblUserNameValue.StateCommon.ShortText.TextV = PaletteRelativeAlign.Near;
            lblUserNameValue.Text = System.Windows.Forms.SystemInformation.UserName;

            flp1.Controls.Add(lblNetworks);
            flp1.Controls.Add(cboNetworks);
            flp1.SetFlowBreak(cboNetworks, true);
            flp1.Controls.Add(lblMACAddress);
            flp1.Controls.Add(lblMACAddressValue);
            flp1.SetFlowBreak(lblMACAddressValue, true);
            flp1.Controls.Add(lblIP);
            flp1.Controls.Add(lblIPValue);
            flp1.SetFlowBreak(lblIPValue, true);
            flp1.Controls.Add(lblSpeed);
            flp1.Controls.Add(lblSpeedValue);
            flp1.SetFlowBreak(lblSpeedValue, true);
            flp1.Controls.Add(lblMachineName);
            flp1.Controls.Add(lblMachineNameValue);
            flp1.SetFlowBreak(lblMachineNameValue, true);
            flp1.Controls.Add(lblUserName);
            flp1.Controls.Add(lblUserNameValue);

            updatePanel.Controls.Add(flp1);
        }
    }
}