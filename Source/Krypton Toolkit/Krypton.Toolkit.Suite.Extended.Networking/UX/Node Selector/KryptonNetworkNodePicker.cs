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
    public partial class KryptonNetworkNodePicker : KryptonForm
    {
        #region Variables
        private ComputerEnum _computerEnum;

        private string? _selectedComputerName = null;

        private string[] _sqlServerList = [];
        #endregion

        #region Properties
        /// <summary>Gets the name of the selected computer.</summary>
        /// <value>The name of the selected computer.</value>
        public string SelectedComputerName => _selectedComputerName ?? string.Empty;

        #endregion

        #region Constructor
        public KryptonNetworkNodePicker()
        {
            InitializeComponent();

            PopulateDomainList();
        }
        #endregion

        #region Methods
        internal void PopulateDomainList()
        {
            string domainName = "";
            string currentDomain = Environment.UserDomainName;
            int index = 0;

            // browse for domains
            _computerEnum = new ComputerEnum(0x80000000, null);
            {
                for (int i = 0; i < _computerEnum.Length; i++)
                {
                    domainName = _computerEnum[i].Name;
                    kcmbDomainList.Items.Add(domainName);
                    if (domainName.CompareTo(currentDomain) == 0)
                    {
                        index = i;
                    }
                }
            }
            kcmbDomainList.SelectedIndex = index;
        }

        /// <summary>
        /// Populates listbox with filtered computer types
        /// </summary>
        /// <param name="serverType">Bit-mapped value to use when filtering
        /// computer types.</param>
        internal void DisplayComputerTypes(uint serverType)
        {
            Cursor.Current = Cursors.WaitCursor;
            klstServers.Items.Clear();
            _computerEnum = new ComputerEnum(serverType, kcmbDomainList.SelectedItem.ToString());
            int numServer = _computerEnum.Length;
            klstServers.Sorted = true;

            if (_computerEnum.LastError.Length == 0)
            {
                IEnumerator enumerator = _computerEnum.GetEnumerator();

                int i = 0;
                while (enumerator.MoveNext())
                {
                    klstServers.Items.Add(_computerEnum[i].Name);
                    i++;
                }

                // add SQL Servers if SQLDMO used
                for (int j = 0; j < _sqlServerList.Length; j++)
                {
                    if (!klstServers.Items.Contains(_sqlServerList[j]))
                    {
                        klstServers.Items.Add(_sqlServerList[j]);
                    }
                }
            }
            else
            {
                InternalKryptonMessageBoxExtended.Show(this, $"Error \"{_computerEnum.LastError}\"was returned", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor.Current = Cursors.Default;
        }

        private void GetServerTypeValues(object sender, EventArgs e)
        {
            int filterVal = 0x00;
            bool itemsChecked = false;
            int numItemsChecked = 0;
            _sqlServerList = []; // clear list, if any

            foreach (KryptonCheckBox cb in kgbServerTypes.Controls)
            {
                if (cb.Checked)
                {
                    // use SQLDMO to list Sql Servers, if available
                    if (cb.Text == @"SQL Servers" && TestForSQLDMOAbility())
                    {
                        GetSqlServersUsingSQLDMO(sender, e);
                    }
                    else
                    {
                        filterVal += int.Parse((string)cb.Tag, NumberStyles.HexNumber);
                        itemsChecked = true;
                    }
                    numItemsChecked++;
                }
            }

            kchkAllServers.Enabled = !itemsChecked;

            DisplayComputerTypes((uint)filterVal);
        }

        /// <summary>
        /// Checks if SQLDMO can be used.
        /// </summary>
        /// <returns>TRUE if SQLDMO can be used to enumerate
        /// available SQL Servers, otherwise FALSE.</returns>
        private bool TestForSQLDMOAbility()
        {
            try
            {
                //SQLDMO.Application app = new SQLDMO.ApplicationClass();
                return true;
            }
            // if the SQLDMO object doesn't exist, we can use SQLDMO
            catch (COMException comException)
            {
                return false;
            }
        }

        /// <summary>
        /// Provides an alternative (and more reliable)
        /// way to get available SQL Servers on your network.
        /// </summary>
        private void GetSqlServersUsingSQLDMO(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //SQLDMO.Application app = new SQLDMO.ApplicationClass();
            //SQLDMO.NameList nameList = app.ListAvailableSQLServers();
            string srvName = "";
            //_sqlServerList = new string[nameList.Count];

            //for (int i = 0; i < nameList.Count; i++)
            //{
            //    srvName = nameList.Item(i + 1);
            //    _sqlServerList[i] = srvName;
            //}
        }
        #endregion

        private void klstServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (klstServers.SelectedItem != null)
                {
                    _selectedComputerName = klstServers.SelectedItem.ToString();
                }

                kbtnOk.Enabled = true;
            }
            catch (NullReferenceException nre)
            {
                if (klstServers.Items.Count > 0)
                {
                    klstServers.SelectedIndex = 0;
                }

                DebugUtilities.NotImplemented(nre.ToString());
            }
        }

        private void kchkAllServers_CheckedChanged(object sender, EventArgs e)
        {
            foreach (KryptonCheckBox cb in kgbServerTypes.Controls)
            {
                cb.Enabled = !kchkAllServers.Checked;
            }

            if (kchkAllServers.Checked)
            {
                kchkAllServers.Enabled = true;
                kchkAllServers.Checked = true;

                if (!TestForSQLDMOAbility())
                {
                    DisplayComputerTypes(0xFFFFFFFF);  // show me everything (eww baby!)
                }
                else
                {
                    GetSqlServersUsingSQLDMO(sender, e);
                    DisplayComputerTypes(33556009);
                }
            }
            else
            {
                GetServerTypeValues(sender, e);
            }
        }
    }
}