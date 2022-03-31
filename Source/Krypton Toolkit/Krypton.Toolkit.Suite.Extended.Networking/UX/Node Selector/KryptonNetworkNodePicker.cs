namespace Krypton.Toolkit.Suite.Extended.Networking
{
    public class KryptonNetworkNodePicker : KryptonForm
    {
        #region Design Code
        private KryptonPanel kryptonPanel1;
        private KryptonButton kbtnOk;
        private KryptonPanel kryptonPanel2;
        private KryptonGroupBox kryptonGroupBox1;
        private KryptonComboBox kcmbDomainList;
        private KryptonLabel kryptonLabel1;
        private KryptonGroupBox kgbServerTypes;
        private KryptonCheckBox kchkSQLServers;
        private KryptonCheckBox kchkWorkstations;
        private KryptonCheckBox kchkAllServers;
        private KryptonCheckBox kchkDialInServers;
        private KryptonCheckBox kchkPrintServers;
        private KryptonCheckBox kchkTimeServers;
        private KryptonCheckBox kchkTerminalServers;
        private KryptonCheckBox kchkDomainControllers;
        private KryptonBorderEdge kbeEdge;
        private KryptonListBox klstServers;

        private void InitializeComponent()
        {
            this.kryptonPanel1 = new Krypton.Toolkit.KryptonPanel();
            this.kbtnOk = new Krypton.Toolkit.KryptonButton();
            this.kryptonPanel2 = new Krypton.Toolkit.KryptonPanel();
            this.kgbServerTypes = new Krypton.Toolkit.KryptonGroupBox();
            this.kchkAllServers = new Krypton.Toolkit.KryptonCheckBox();
            this.kchkDialInServers = new Krypton.Toolkit.KryptonCheckBox();
            this.kchkPrintServers = new Krypton.Toolkit.KryptonCheckBox();
            this.kchkTimeServers = new Krypton.Toolkit.KryptonCheckBox();
            this.kchkTerminalServers = new Krypton.Toolkit.KryptonCheckBox();
            this.kchkDomainControllers = new Krypton.Toolkit.KryptonCheckBox();
            this.kchkSQLServers = new Krypton.Toolkit.KryptonCheckBox();
            this.kchkWorkstations = new Krypton.Toolkit.KryptonCheckBox();
            this.kcmbDomainList = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.kryptonGroupBox1 = new Krypton.Toolkit.KryptonGroupBox();
            this.klstServers = new Krypton.Toolkit.KryptonListBox();
            this.kbeEdge = new Krypton.Toolkit.KryptonBorderEdge();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).BeginInit();
            this.kryptonPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).BeginInit();
            this.kryptonPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kgbServerTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kgbServerTypes.Panel)).BeginInit();
            this.kgbServerTypes.Panel.SuspendLayout();
            this.kgbServerTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kcmbDomainList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).BeginInit();
            this.kryptonGroupBox1.Panel.SuspendLayout();
            this.kryptonGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonPanel1
            // 
            this.kryptonPanel1.Controls.Add(this.kbeEdge);
            this.kryptonPanel1.Controls.Add(this.kbtnOk);
            this.kryptonPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.kryptonPanel1.Location = new System.Drawing.Point(0, 369);
            this.kryptonPanel1.Name = "kryptonPanel1";
            this.kryptonPanel1.PanelBackStyle = Krypton.Toolkit.PaletteBackStyle.PanelAlternate;
            this.kryptonPanel1.Size = new System.Drawing.Size(345, 50);
            this.kryptonPanel1.TabIndex = 0;
            // 
            // kbtnOk
            // 
            this.kbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.kbtnOk.Enabled = false;
            this.kbtnOk.Location = new System.Drawing.Point(127, 13);
            this.kbtnOk.Name = "kbtnOk";
            this.kbtnOk.Size = new System.Drawing.Size(90, 25);
            this.kbtnOk.TabIndex = 1;
            this.kbtnOk.Values.Text = "O&k";
            // 
            // kryptonPanel2
            // 
            this.kryptonPanel2.Controls.Add(this.kgbServerTypes);
            this.kryptonPanel2.Controls.Add(this.kcmbDomainList);
            this.kryptonPanel2.Controls.Add(this.kryptonLabel1);
            this.kryptonPanel2.Controls.Add(this.kryptonGroupBox1);
            this.kryptonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonPanel2.Location = new System.Drawing.Point(0, 0);
            this.kryptonPanel2.Name = "kryptonPanel2";
            this.kryptonPanel2.Size = new System.Drawing.Size(345, 369);
            this.kryptonPanel2.TabIndex = 2;
            // 
            // kgbServerTypes
            // 
            this.kgbServerTypes.Location = new System.Drawing.Point(14, 47);
            this.kgbServerTypes.Name = "kgbServerTypes";
            // 
            // kgbServerTypes.Panel
            // 
            this.kgbServerTypes.Panel.Controls.Add(this.kchkAllServers);
            this.kgbServerTypes.Panel.Controls.Add(this.kchkDialInServers);
            this.kgbServerTypes.Panel.Controls.Add(this.kchkPrintServers);
            this.kgbServerTypes.Panel.Controls.Add(this.kchkTimeServers);
            this.kgbServerTypes.Panel.Controls.Add(this.kchkTerminalServers);
            this.kgbServerTypes.Panel.Controls.Add(this.kchkDomainControllers);
            this.kgbServerTypes.Panel.Controls.Add(this.kchkSQLServers);
            this.kgbServerTypes.Panel.Controls.Add(this.kchkWorkstations);
            this.kgbServerTypes.Size = new System.Drawing.Size(317, 158);
            this.kgbServerTypes.TabIndex = 4;
            this.kgbServerTypes.Values.Heading = "Server Types";
            // 
            // kchkAllServers
            // 
            this.kchkAllServers.Location = new System.Drawing.Point(192, 99);
            this.kchkAllServers.Name = "kchkAllServers";
            this.kchkAllServers.Size = new System.Drawing.Size(71, 20);
            this.kchkAllServers.TabIndex = 7;
            this.kchkAllServers.Values.Text = "&Show All";
            this.kchkAllServers.CheckedChanged += new System.EventHandler(this.kchkAllServers_CheckedChanged);
            // 
            // kchkDialInServers
            // 
            this.kchkDialInServers.Location = new System.Drawing.Point(192, 70);
            this.kchkDialInServers.Name = "kchkDialInServers";
            this.kchkDialInServers.Size = new System.Drawing.Size(102, 20);
            this.kchkDialInServers.TabIndex = 6;
            this.kchkDialInServers.Values.Text = "&Dial-In Servers";
            // 
            // kchkPrintServers
            // 
            this.kchkPrintServers.Location = new System.Drawing.Point(192, 41);
            this.kchkPrintServers.Name = "kchkPrintServers";
            this.kchkPrintServers.Size = new System.Drawing.Size(92, 20);
            this.kchkPrintServers.TabIndex = 5;
            this.kchkPrintServers.Values.Text = "P&rint Servers";
            // 
            // kchkTimeServers
            // 
            this.kchkTimeServers.Location = new System.Drawing.Point(192, 12);
            this.kchkTimeServers.Name = "kchkTimeServers";
            this.kchkTimeServers.Size = new System.Drawing.Size(93, 20);
            this.kchkTimeServers.TabIndex = 4;
            this.kchkTimeServers.Values.Text = "&Time Servers";
            // 
            // kchkTerminalServers
            // 
            this.kchkTerminalServers.Location = new System.Drawing.Point(8, 99);
            this.kchkTerminalServers.Name = "kchkTerminalServers";
            this.kchkTerminalServers.Size = new System.Drawing.Size(113, 20);
            this.kchkTerminalServers.TabIndex = 3;
            this.kchkTerminalServers.Values.Text = "&Terminal Servers";
            // 
            // kchkDomainControllers
            // 
            this.kchkDomainControllers.Location = new System.Drawing.Point(8, 70);
            this.kchkDomainControllers.Name = "kchkDomainControllers";
            this.kchkDomainControllers.Size = new System.Drawing.Size(129, 20);
            this.kchkDomainControllers.TabIndex = 2;
            this.kchkDomainControllers.Values.Text = "Domain &Controllers";
            // 
            // kchkSQLServers
            // 
            this.kchkSQLServers.Location = new System.Drawing.Point(8, 41);
            this.kchkSQLServers.Name = "kchkSQLServers";
            this.kchkSQLServers.Size = new System.Drawing.Size(88, 20);
            this.kchkSQLServers.TabIndex = 1;
            this.kchkSQLServers.Values.Text = "&SQL Servers";
            // 
            // kchkWorkstations
            // 
            this.kchkWorkstations.Location = new System.Drawing.Point(8, 12);
            this.kchkWorkstations.Name = "kchkWorkstations";
            this.kchkWorkstations.Size = new System.Drawing.Size(95, 20);
            this.kchkWorkstations.TabIndex = 0;
            this.kchkWorkstations.Values.Text = "W&orkstations";
            // 
            // kcmbDomainList
            // 
            this.kcmbDomainList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.kcmbDomainList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kcmbDomainList.DropDownWidth = 166;
            this.kcmbDomainList.IntegralHeight = false;
            this.kcmbDomainList.Location = new System.Drawing.Point(86, 15);
            this.kcmbDomainList.Name = "kcmbDomainList";
            this.kcmbDomainList.Size = new System.Drawing.Size(235, 21);
            this.kcmbDomainList.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.kcmbDomainList.TabIndex = 3;
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(24, 16);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(56, 20);
            this.kryptonLabel1.TabIndex = 1;
            this.kryptonLabel1.Values.Text = "Domain:";
            // 
            // kryptonGroupBox1
            // 
            this.kryptonGroupBox1.Location = new System.Drawing.Point(14, 211);
            this.kryptonGroupBox1.Name = "kryptonGroupBox1";
            // 
            // kryptonGroupBox1.Panel
            // 
            this.kryptonGroupBox1.Panel.Controls.Add(this.klstServers);
            this.kryptonGroupBox1.Size = new System.Drawing.Size(319, 149);
            this.kryptonGroupBox1.TabIndex = 0;
            this.kryptonGroupBox1.Values.Heading = "Servers";
            // 
            // klstServers
            // 
            this.klstServers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.klstServers.Location = new System.Drawing.Point(0, 0);
            this.klstServers.Name = "klstServers";
            this.klstServers.Size = new System.Drawing.Size(315, 125);
            this.klstServers.TabIndex = 0;
            this.klstServers.SelectedIndexChanged += new System.EventHandler(this.klstServers_SelectedIndexChanged);
            // 
            // kbeEdge
            // 
            this.kbeEdge.BorderStyle = Krypton.Toolkit.PaletteBorderStyle.HeaderPrimary;
            this.kbeEdge.Dock = System.Windows.Forms.DockStyle.Top;
            this.kbeEdge.Location = new System.Drawing.Point(0, 0);
            this.kbeEdge.Name = "kbeEdge";
            this.kbeEdge.Size = new System.Drawing.Size(345, 1);
            this.kbeEdge.Text = "kryptonBorderEdge1";
            // 
            // KryptonNetworkNodePicker
            // 
            this.AcceptButton = this.kbtnOk;
            this.ClientSize = new System.Drawing.Size(345, 419);
            this.Controls.Add(this.kryptonPanel2);
            this.Controls.Add(this.kryptonPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KryptonNetworkNodePicker";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Select a network computer";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel1)).EndInit();
            this.kryptonPanel1.ResumeLayout(false);
            this.kryptonPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonPanel2)).EndInit();
            this.kryptonPanel2.ResumeLayout(false);
            this.kryptonPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kgbServerTypes.Panel)).EndInit();
            this.kgbServerTypes.Panel.ResumeLayout(false);
            this.kgbServerTypes.Panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kgbServerTypes)).EndInit();
            this.kgbServerTypes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kcmbDomainList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1.Panel)).EndInit();
            this.kryptonGroupBox1.Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kryptonGroupBox1)).EndInit();
            this.kryptonGroupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region Variables
        private ComputerEnum _computerEnum;

        private string _selectedComputerName = null;

        private string[] _sqlServerList = new string[0];
        #endregion

        #region Properties
        /// <summary>Gets the name of the selected computer.</summary>
        /// <value>The name of the selected computer.</value>
        public string SelectedComputerName { get => _selectedComputerName; }
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
            string currentDomain = System.Environment.UserDomainName;
            int index = 0;

            // browse for domains
            _computerEnum = new ComputerEnum(0x80000000, null);
            {
                for (int i = 0; i < _computerEnum.Length; i++)
                {
                    domainName = _computerEnum[i].Name;
                    kcmbDomainList.Items.Add(domainName);
                    if (domainName.CompareTo(currentDomain) == 0)
                        index = i;
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
                        klstServers.Items.Add(_sqlServerList[j]);
                }
            }
            else
            {
                InternalKryptonMessageBoxExtended.Show(this, "Error \"" + _computerEnum.LastError + "\"was returned", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor.Current = Cursors.Default;
        }

        private void GetServerTypeValues(object sender, EventArgs e)
        {
            int filterVal = 0x00;
            bool itemsChecked = false;
            int numItemsChecked = 0;
            _sqlServerList = new string[0]; // clear list, if any

            foreach (KryptonCheckBox cb in kgbServerTypes.Controls)
            {
                if (cb.Checked)
                {
                    // use SQLDMO to list Sql Servers, if available
                    if (cb.Text == "SQL Servers" && TestForSQLDMOAbility())
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
            catch (System.Runtime.InteropServices.COMException)
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
                _selectedComputerName = klstServers.SelectedItem.ToString();

                kbtnOk.Enabled = true;
            }
            catch (NullReferenceException nre)
            {
                if (klstServers.Items.Count > 0)
                {
                    klstServers.SelectedIndex = 0;
                }
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
                    DisplayComputerTypes(0xFFFFFFFF);  // show me everything (eww baby!)
                else
                {
                    GetSqlServersUsingSQLDMO(sender, e);
                    DisplayComputerTypes(33556009);
                }
            }
            else
                GetServerTypeValues(sender, e);
        }
    }
}