#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Networking
{
    internal class Pinger
    {
        #region Variables
        private KryptonPanel _updateControl;

        private KryptonTextBox _txtPingHost;

        private ListView _pingView;

        private BackgroundWorker _worker;
        #endregion

        #region Constructor
        public Pinger(KryptonPanel updatePanel)
        {
            _updateControl = updatePanel;
            _updateControl.Dock = DockStyle.Fill;
            _updateControl.Controls.Clear();

            _worker = new BackgroundWorker();
            _worker.WorkerReportsProgress = true;
            _worker.DoWork += _worker_DoWork;
            _worker.RunWorkerCompleted += _worker_RunWorkerCompleted;

            FlowLayoutPanel flp = new FlowLayoutPanel();
            flp.Dock = DockStyle.Top;
            flp.Padding = new Padding(20);

            KryptonLabel lblPingHost = new KryptonLabel();
            lblPingHost.Text = "Host";
            lblPingHost.AutoSize = false;
            lblPingHost.Width = 50;
            lblPingHost.StateCommon.ShortText.TextV = PaletteRelativeAlign.Far;

            _txtPingHost = new KryptonTextBox();
            _txtPingHost.StateCommon.BorderStyle = PaletteBorderStyle.FormCustom1;
            _txtPingHost.BackColor = Color.FromArgb(230, 230, 230);
            _txtPingHost.Width = 200;

            KryptonButton btnPing = new KryptonButton();
            /*btnPing.FlatAppearance.BorderSize = 0;
            btnPing.FlatStyle = FlatStyle.Flat;*/
            btnPing.BackColor = Color.FromArgb(230, 230, 230);
            btnPing.Text = "Ping";
            btnPing.Click += btnPing_Click;

            flp.Controls.Add(lblPingHost);
            flp.Controls.Add(_txtPingHost);
            flp.Controls.Add(btnPing);

            _pingView = new ListView();
            _pingView.View = View.Details;
            _pingView.Dock = DockStyle.Fill;
            _pingView.BorderStyle = BorderStyle.None;
            _pingView.Columns.Add("Address", 150);
            _pingView.Columns.Add("Bytes", 100);
            _pingView.Columns.Add("Time", 300);
            _pingView.Columns.Add("TTL", 100);

            _updateControl.Controls.Add(_pingView);
            _updateControl.Controls.Add(flp);
        }
        #endregion

        #region Event Handlers
        void btnPing_Click(object sender, EventArgs e)
        {
            _pingView.Controls.Clear();
            string host = _txtPingHost.Text;

            if (!_worker.IsBusy)
            {
                _pingView.Items.Clear();
                _worker.RunWorkerAsync(host);
            }
        }

        void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ListView statView = (ListView)_updateControl.Controls[0];
            List<PingDetails> details = (List<PingDetails>)e.Result;

            foreach (PingDetails detail in details)
            {
                ListViewItem list = new ListViewItem(detail.Address);
                list.SubItems.Add(detail.Length);
                list.SubItems.Add(detail.Time);
                list.SubItems.Add(detail.TTL);
                _pingView.Items.Add(list);
            }
        }

        void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            string host = (string)e.Argument;

            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();
            options.DontFragment = true;

            string data = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;

            List<PingDetails> list = new List<PingDetails>();



            for (int i = 0; i < 4; i++)
            {
                try
                {
                    PingReply reply = pingSender.Send(host, timeout, buffer, options);

                    if (reply.Status == IPStatus.Success)
                    {
                        PingDetails details = new PingDetails();
                        details.Address = reply.Address.ToString();
                        details.Length = reply.Buffer.Length.ToString();
                        details.Time = reply.RoundtripTime.ToString();
                        details.TTL = reply.Options.Ttl.ToString();

                        list.Add(details);
                    }
                }
                catch (Exception ex)
                {
                    ExceptionCapture.CaptureException(ex);
                    break;
                }
            }

            e.Result = list;
            _worker.ReportProgress(100);
        }
        #endregion
    }
}