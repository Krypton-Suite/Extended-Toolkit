namespace Krypton.Toolkit.Suite.Extended.Networking
{
    public class KryptonNetworkScanner : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnScan;
        private KryptonTextBox ktxtWorkGroupName;
        private KryptonLabel kryptonLabel1;
        private KryptonPanel kryptonPanel2;
        private KryptonDataGridView kdgvNodes;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnScan = new Krypton.Toolkit.KryptonButton();
            this.ktxtWorkGroupName = new Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kdgvNodes = new Krypton.Toolkit.KryptonDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kdgvNodes)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbtnScan);
            this.kryptonPanel1.Controls.Add(this.ktxtWorkGroupName);
            this.kryptonPanel1.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.Size = new System.Drawing.Size(589, 44);
            this.kryptonPanel1.TabIndex = 1;
            // 
            // kbtnScan
            // 
            this.kbtnScan.Enabled = false;
            this.kbtnScan.Location = new System.Drawing.Point(472, 12);
            this.kbtnScan.Name = "kbtnScan";
            this.kbtnScan.Size = new System.Drawing.Size(101, 25);
            this.kbtnScan.TabIndex = 2;
            this.kbtnScan.Values.Text = "St&art Scan";
            this.kbtnScan.Click += new System.EventHandler(this.kbtnScan_Click);
            // 
            // ktxtWorkGroupName
            // 
            this.ktxtWorkGroupName.CueHint.CueHintText = "Type a domain or workgroup name here...";
            this.ktxtWorkGroupName.CueHint.Padding = new System.Windows.Forms.Padding(0);
            this.ktxtWorkGroupName.Location = new System.Drawing.Point(178, 12);
            this.ktxtWorkGroupName.Name = "ktxtWorkGroupName";
            this.ktxtWorkGroupName.Size = new System.Drawing.Size(287, 23);
            this.ktxtWorkGroupName.TabIndex = 1;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(159, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Domain/Workgroup Name:";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kdgvNodes);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 44);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(589, 398);
            this.kryptonPanel2.TabIndex = 2;
            // 
            // kdgvNodes
            // 
            this.kdgvNodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kdgvNodes.Location = new System.Drawing.Point(0, 0);
            this.kdgvNodes.Name = "kdgvNodes";
            this.kdgvNodes.Size = new System.Drawing.Size(589, 398);
            this.kdgvNodes.TabIndex = 1;
            // 
            // KryptonNetworkScanner
            // 
            this.ClientSize = new System.Drawing.Size(589, 442);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonNetworkScanner";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Scan Network";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kdgvNodes)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        #region APIs
        [DllImport("iphlpapi.dll", ExactSpelling = true)]
        public static extern int SendARP(int DestIP, int SrcIP, [Out] byte[] pMacAddr, ref int PhyAddrLen);
        #endregion

        #region Constructor
        public KryptonNetworkScanner()
        {
            InitializeComponent();
        }
        #endregion

        private void kbtnScan_Click(object sender, EventArgs e)
        {
            if (ktxtWorkGroupName.Text == "") return;

            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("ComputerName", typeof(String)));          //0
            dt.Columns.Add(new DataColumn("ComputerIP", typeof(String)));            //1
            dt.Columns.Add(new DataColumn("ComputerMAC", typeof(String)));       //2

            try
            {
                // Use Your work Group WinNT://&&&&(Work Group Name)
                DirectoryEntry DomainEntry = new DirectoryEntry("WinNT://" + ktxtWorkGroupName.Text + "");
                DomainEntry.Children.SchemaFilter.Add("Computer");

                ///*************************************************
                /// ITERATING THROUGH ALL MACHINES IN DOMAIN ENTRY
                ///*************************************************
                foreach (DirectoryEntry machine in DomainEntry.Children)
                {
                    string strMachineName = machine.Name;
                    string strMACAddress;
                    IPAddress ipAddress;


                    try
                    {
                        ipAddress = GetIPByName(machine.Name);
                    }
                    catch
                    {
                        continue;
                    }//try/catch

                    ///*************************************************
                    /// GETTING MAC ADDRESS
                    ///*************************************************
                    strMACAddress = GetMACAddress(ipAddress);

                    ///*************************************************
                    /// ADD ROWS TO OUR DATA TABLE
                    ///*************************************************

                    DataRow dr = dt.NewRow();

                    dr[0] = machine.Name;
                    dr[1] = ipAddress.ToString();
                    dr[2] = strMACAddress;

                    dt.Rows.Add(dr);

                }//foreach loop

                ///*************************************************
                /// SETTING DATASOURCE
                ///*************************************************
                kdgvNodes.DataSource = dt;

            }//try/catch
            catch (Exception ex)
            {
                ExceptionCapture.CaptureException(ex);
            }
        }

        #region Methods
        private string GetMACAddress(IPAddress ipAddress)
        {
            byte[] ab = new byte[6];
            int len = ab.Length;

            // This Function Used to Get The Physical Address
            int r = SendARP(ipAddress.GetHashCode(), 0, ab, ref len);
            string mac = BitConverter.ToString(ab, 0, 6);
            return mac;
        }//getMACAddress()

        private IPAddress GetIPByName(string strMachineName)
        {
            try
            {
                IPHostEntry hostInfo = Dns.GetHostEntry(strMachineName);
                return hostInfo.AddressList[0];
            }
            catch (Exception ex)
            {
                InternalKryptonMessageBoxExtended.Show("Unable to connect with the system: " + strMachineName);
                throw ex;
            }
        }//getIPByName()
        #endregion
    }
}