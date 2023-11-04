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

namespace Krypton.Toolkit.Suite.Extended.Networking
{
    public partial class KryptonNetworkScanner : KryptonForm
    {
        #region APIs
        [DllImport("iphlpapi.dll", ExactSpelling = true)]
        public static extern int SendARP(int destIp, int srcIp, [Out] byte[] pMacAddr, ref int phyAddrLen);
        #endregion

        #region Constructor
        public KryptonNetworkScanner()
        {
            InitializeComponent();
        }
        #endregion

        private void kbtnScan_Click(object sender, EventArgs e)
        {
            if (ktxtWorkGroupName.Text == "")
            {
                return;
            }

            DataTable dt = new DataTable();

            dt.Columns.Add(new DataColumn("ComputerName", typeof(string)));          //0
            dt.Columns.Add(new DataColumn("ComputerIP", typeof(string)));            //1
            dt.Columns.Add(new DataColumn("ComputerMAC", typeof(string)));       //2

            try
            {
                // Use Your work Group WinNT://&&&&(Work Group Name)
                DirectoryEntry domainEntry = new DirectoryEntry($"WinNT://{ktxtWorkGroupName.Text}");
                domainEntry.Children.SchemaFilter.Add("Computer");

                //*************************************************
                // ITERATING THROUGH ALL MACHINES IN DOMAIN ENTRY
                //*************************************************
                foreach (DirectoryEntry machine in domainEntry.Children)
                {
                    string strMachineName = machine.Name;
                    string strMacAddress;
                    IPAddress ipAddress;


                    try
                    {
                        ipAddress = GetIpByName(machine.Name);
                    }
                    catch
                    {
                        continue;
                    }//try/catch

                    //*************************************************
                    // GETTING MAC ADDRESS
                    //*************************************************
                    strMacAddress = GetMacAddress(ipAddress);

                    //*************************************************
                    // ADD ROWS TO OUR DATA TABLE
                    //*************************************************

                    DataRow dr = dt.NewRow();

                    dr[0] = machine.Name;
                    dr[1] = ipAddress.ToString();
                    dr[2] = strMacAddress;

                    dt.Rows.Add(dr);

                }//foreach loop

                //*************************************************
                // SETTING DATASOURCE
                //*************************************************
                kdgvNodes.DataSource = dt;

            }//try/catch
            catch (Exception ex)
            {
                ExceptionCapture.CaptureException(ex);
            }
        }

        #region Methods
        private string GetMacAddress(IPAddress ipAddress)
        {
            byte[] ab = new byte[6];
            int len = ab.Length;

            // This Function Used to Get The Physical Address
            int r = SendARP(ipAddress.GetHashCode(), 0, ab, ref len);
            string mac = BitConverter.ToString(ab, 0, 6);
            return mac;
        }//getMACAddress()

        private IPAddress GetIpByName(string strMachineName)
        {
            try
            {
                IPHostEntry hostInfo = Dns.GetHostEntry(strMachineName);
                return hostInfo.AddressList[0];
            }
            catch (Exception ex)
            {
                InternalKryptonMessageBoxExtended.Show($"Unable to connect with the system: {strMachineName}");
                throw ex;
            }
        }//getIPByName()
        #endregion
    }
}