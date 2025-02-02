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
    internal class NetStat
    {
        #region Variables
        private bool _dnsLookup = true;

        private BackgroundWorker _worker;

        private ListView _statView;

        private KryptonPanel _updatePanel;
        #endregion

        #region Constructor
        public NetStat(KryptonPanel updatePanel, bool dnsLookup)
        {
            _dnsLookup = dnsLookup;

            _updatePanel = updatePanel;

            _updatePanel.Dock = DockStyle.Fill;

            _updatePanel.Controls.Clear();

            _worker = new BackgroundWorker();

            _worker.WorkerReportsProgress = true;

            _worker.DoWork += Worker_DoWork;

            _worker.RunWorkerCompleted += Worker_RunWorkerCompleted;

            _statView = new ListView();
            _statView.View = View.Details;
            _statView.Dock = DockStyle.Fill; _statView.BorderStyle = BorderStyle.None;
            _statView.Columns.Add("Local Address", 150);
            _statView.Columns.Add("Local Port", 100);
            _statView.Columns.Add("Remote Address", 300);
            _statView.Columns.Add("Remote Port", 100);
            _statView.Columns.Add("Type", 100);
            _statView.Columns.Add("Protocol", 100);

            _updatePanel.Controls.Add(_statView);
        }
        #endregion

        #region Event Handlers
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ListView statView = (ListView)_updatePanel.Controls[0];

            List<ConnectionDetails> details = (List<ConnectionDetails>)e.Result;

            foreach (ConnectionDetails info in details)
            {
                ListViewItem list = new ListViewItem(info.LocalAddress);

                list.SubItems.Add(info.LocalPort);

                list.SubItems.Add(info.RemoteAddress);

                list.SubItems.Add(info.RemotePort);

                list.SubItems.Add(info.ApplicationProtocol);

                list.SubItems.Add(info.Protocol);

                statView.Items.Add(list);
            }
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            TcpConnectionInformation[] connections = properties.GetActiveTcpConnections();

            List<ConnectionDetails> list = [];

            foreach (TcpConnectionInformation info in connections)
            {
                string host;

                if (_dnsLookup)
                {
                    try
                    {
                        IPHostEntry entry = Dns.GetHostEntry(info.RemoteEndPoint.Address);
                        host = entry.HostName;
                    }
                    catch (Exception ex)
                    {
                        host = info.RemoteEndPoint.Address.ToString();
                    }
                }
                else
                {
                    host = info.RemoteEndPoint.Address.ToString();
                }

                ConnectionDetails details = new ConnectionDetails();

                details.LocalAddress = info.LocalEndPoint.Address.ToString();

                details.LocalPort = info.LocalEndPoint.Port.ToString();

                details.RemoteAddress = host;

                details.RemotePort = info.RemoteEndPoint.Port.ToString();

                details.Protocol = "TCP";

                list.Add(details);
            }

            e.Result = list;
            _worker.ReportProgress(100);
        }
        #endregion

        #region Methods
        public void Execute() => _worker.RunWorkerAsync();
        #endregion
    }
}