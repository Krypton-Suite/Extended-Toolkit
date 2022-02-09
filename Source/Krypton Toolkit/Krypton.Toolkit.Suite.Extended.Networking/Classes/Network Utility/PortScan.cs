#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Networking
{
    internal class PortScan
    {
        #region Variables
        private KryptonPanel _updatePanel;

        private KryptonTextBox _txtHost;

        private KryptonTextBox _txtStartPort;

        private KryptonTextBox _txtStopPort;

        private KryptonTextBox _txtScanOutput;

        private BackgroundWorker _worker;
        #endregion

        #region Constructor
        public PortScan(KryptonPanel updatePanel)
        {
            _updatePanel = updatePanel;
            _updatePanel.Dock = DockStyle.Fill;
            _updatePanel.Controls.Clear();

            FlowLayoutPanel flp1 = new FlowLayoutPanel();
            flp1.Dock = DockStyle.Top;
            flp1.Padding = new Padding(20, 20, 0, 0);
            flp1.FlowDirection = FlowDirection.LeftToRight;
            flp1.Height = 50;

            KryptonLabel lblHost = new KryptonLabel();
            lblHost.AutoSize = false;
            lblHost.Width = 50;
            lblHost.StateCommon.ShortText.TextV = PaletteRelativeAlign.Far;
            lblHost.Text = "Host";

            _txtHost = new KryptonTextBox();
            _txtHost.Width = 344;
            //_txtHost.BorderStyle = BorderStyle.FixedSingle;
            _txtHost.BackColor = Color.FromArgb(230, 230, 230);

            flp1.Controls.Add(lblHost);
            flp1.Controls.Add(_txtHost);

            FlowLayoutPanel flp2 = new FlowLayoutPanel();
            flp2.Dock = DockStyle.Top;
            flp2.Padding = new Padding(20, 0, 0, 0);
            flp2.FlowDirection = FlowDirection.LeftToRight;
            flp2.Height = 40;

            Label lblStartPort = new Label();
            lblStartPort.AutoSize = false;
            lblStartPort.Width = 50;
            lblStartPort.TextAlign = ContentAlignment.MiddleRight;
            lblStartPort.Text = "Start";

            _txtStartPort = new KryptonTextBox();
            _txtStartPort.Width = 100;
            //_txtStartPort.BorderStyle = BorderStyle.FixedSingle;
            _txtStartPort.BackColor = Color.FromArgb(230, 230, 230);

            Label lblStopPort = new Label();
            lblStopPort.Text = "Stop";
            lblStopPort.AutoSize = false;
            lblStopPort.Width = 50;
            lblStopPort.TextAlign = ContentAlignment.MiddleRight;

            _txtStopPort = new KryptonTextBox();
            _txtStopPort.Width = 100;
            //_txtStopPort.BorderStyle = BorderStyle.FixedSingle;
            _txtStopPort.BackColor = Color.FromArgb(230, 230, 230);

            KryptonButton btnScan = new KryptonButton();
            btnScan.Text = "Scan";
            /*btnScan.FlatAppearance.BorderSize = 0;
            btnScan.FlatStyle = FlatStyle.Flat;
            btnScan.BackColor = Color.FromArgb(230, 230, 230);*/
            btnScan.Click += btnScan_Click;

            flp2.Controls.Add(lblStartPort);
            flp2.Controls.Add(_txtStartPort);
            flp2.Controls.Add(lblStopPort);
            flp2.Controls.Add(_txtStopPort);
            flp2.Controls.Add(btnScan);

            KryptonPanel panel3 = new KryptonPanel();
            panel3.Dock = DockStyle.Fill;
            panel3.Padding = new Padding(20, 0, 20, 20);

            _txtScanOutput = new KryptonTextBox();
            _txtScanOutput.Dock = DockStyle.Fill;
            _txtScanOutput.Multiline = true;
            //_txtScanOutput.BorderStyle = BorderStyle.None;
            _txtScanOutput.ScrollBars = ScrollBars.Vertical;

            panel3.Controls.Add(_txtScanOutput);

            _updatePanel.Controls.Add(panel3);
            _updatePanel.Controls.Add(flp2);
            _updatePanel.Controls.Add(flp1);

        }
        #endregion

        #region Event Handlers
        void btnScan_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (_txtStartPort.Text == string.Empty || _txtStopPort.Text == string.Empty)
            {
                MessageBox.Show("Please enter a start port and a stop port");
            }
            else
            {
                if (btn.Text == "Scan")
                {
                    _worker = new BackgroundWorker();
                    _worker.WorkerReportsProgress = true;
                    _worker.WorkerSupportsCancellation = true;
                    _worker.DoWork += new DoWorkEventHandler(_worker_DoWork);
                    _worker.ProgressChanged += new ProgressChangedEventHandler(_worker_ProgressChanged);
                    _worker.RunWorkerCompleted += _worker_RunWorkerCompleted;
                    _worker.RunWorkerAsync();

                    _txtScanOutput.Text = "";
                    _txtScanOutput.AppendText("Starting port scan..." + Environment.NewLine);
                    _txtScanOutput.AppendText("Port scanning host: " + _txtHost.Text + Environment.NewLine);
                    _txtScanOutput.AppendText(Environment.NewLine);

                    btn.Text = "Stop";
                }
                else
                {
                    _worker.CancelAsync();
                    btn.Text = "Scan";
                }
            }
        }

        void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Port scan has completed");
        }

        void _worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            PortState state = (PortState)e.UserState;

            if (state.IsOpen)
            {
                _txtScanOutput.AppendText("Port: " + state.Port.ToString() + ", open" + Environment.NewLine);
            }
            else
            {
                _txtScanOutput.AppendText("Port: " + state.Port.ToString() + ", closed" + Environment.NewLine);
            }
        }

        void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                int start = Convert.ToInt32(_txtStartPort.Text);
                int stop = Convert.ToInt32(_txtStopPort.Text);
                int x = 0;

                for (int i = start; i <= stop; i++)
                {
                    if (!_worker.CancellationPending)
                    {
                        PortState state = new PortState();
                        int diff = stop - start;
                        decimal progress = ((decimal)x / (decimal)diff) * (decimal)100;
                        try
                        {
                            TcpClient client = new TcpClient(_txtHost.Text, i);
                            state.IsOpen = true;
                        }
                        catch (Exception ex)
                        {
                            ExceptionCapture.CaptureException(ex);
                        }
                        state.Port = i;
                        _worker.ReportProgress((int)progress, state);
                        ++x;
                    }
                }
            }
            catch (Exception ee)
            {
                ExceptionCapture.CaptureException(ee);
            }
        }
        #endregion
    }
}