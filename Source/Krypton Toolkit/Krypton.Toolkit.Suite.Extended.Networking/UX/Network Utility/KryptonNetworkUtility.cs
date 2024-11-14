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

namespace Krypton.Toolkit.Suite.Extended.Networking
{
    public partial class KryptonNetworkUtility : KryptonForm
    {
        #region Variables
        private KryptonPanel _infoPanel;

        private KryptonPanel _netStatPanel;

        private KryptonPanel _pingPanel;

        private KryptonPanel _portScanPanel;
        #endregion

        #region Constructor
        public KryptonNetworkUtility()
        {
            InitializeComponent();
        }
        #endregion

        private void KryptonNetworkUtility_Load(object sender, EventArgs e)
        {
            _infoPanel = new KryptonPanel();

            _netStatPanel = new KryptonPanel();

            _pingPanel = new KryptonPanel();

            _portScanPanel = new KryptonPanel();

            Info info = new Info(_infoPanel);

            ksc.Panel2.Controls.Add(_infoPanel);
        }

        private void klblNetStat_LinkClicked(object sender, EventArgs e)
        {
            SelectMenu(klblNetStat);

            NetStat netStat = new NetStat(_netStatPanel, true);

            netStat.Execute();
        }

        private void klblNetStatWithoutDNS_LinkClicked(object sender, EventArgs e)
        {
            SelectMenu(klblNetStatWithoutDNS);

            NetStat netStat = new NetStat(_netStatPanel, false);

            netStat.Execute();

            ksc.Panel2.Controls.RemoveAt(0);

            ksc.Panel2.Controls.Add(_netStatPanel);
        }

        private void klblPing_LinkClicked(object sender, EventArgs e)
        {
            SelectMenu(klblPing);

            Pinger ping = new Pinger(_pingPanel);

            ksc.Panel2.Controls.RemoveAt(0);

            ksc.Panel2.Controls.Add(_pingPanel);
        }

        private void klblPortScan_LinkClicked(object sender, EventArgs e)
        {
            SelectMenu(klblPortScan);

            PortScan scan = new PortScan(_portScanPanel);

            ksc.Panel2.Controls.RemoveAt(0);

            ksc.Panel2.Controls.Add(_portScanPanel);
        }

        private void SelectMenu(KryptonLinkLabel control)
        {
            Control.ControlCollection collecion = ksc.Panel1.Controls;

            foreach (Control ctr in collecion)
            {
                try
                {
                    KryptonLinkLabel linkControl = (KryptonLinkLabel)ctr;
                    //linkControl.BackColor = Color.Transparent;
                    //linkControl.LinkColor = Color.White;
                }
                catch { }
            }
        }
    }
}