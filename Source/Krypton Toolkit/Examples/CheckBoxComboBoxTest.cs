using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Krypton.Toolkit.Suite.Extended.Controls;

namespace Examples
{
    public partial class CheckBoxComboBoxTest : KryptonForm
    {
        private StatusList _statusList;

        private ListSelectionWrapper<Status> _statusSelections;

        public CheckBoxComboBoxTest()
        {
            InitializeComponent();
        }

        private void CheckBoxComboBoxTest_Load(object sender, EventArgs e)
        {
            PopulateManualCombo();

            #region POPULATED USING A CUSTOM "IList" DATASOURCE

            _statusList = new StatusList();

            _statusList.Add(new Status(1, "New"));
            _statusList.Add(new Status(2, "Loaded"));
            _statusList.Add(new Status(3, "Inserted"));
            Status UpdatedStatus = new Status(4, "Updated");
            _statusList.Add(UpdatedStatus);
            _statusList.Add(new Status(5, "Deleted"));

            _statusSelections = new ListSelectionWrapper<Status>(_statusList, "Name");

            //kcbcmbIListDataSource.DataSource = _statusSelections;
            //kcbcmbIListDataSource.DisplayMemberSingleItem = "Name";
            //kcbcmbIListDataSource.DisplayMember = "NameConcatenated";
            //kcbcmbIListDataSource.ValueMember = "Selected";

            //kcbcmbIListDataSource.CheckBoxItems[3].DataBindings.DefaultDataSourceUpdateMode
            //    = DataSourceUpdateMode.OnPropertyChanged;
            //kcbcmbIListDataSource.DataBindings.DefaultDataSourceUpdateMode
            //    = DataSourceUpdateMode.OnPropertyChanged;

            _statusSelections.FindObjectWithItem(UpdatedStatus).Selected = true;

            #endregion

            #region POPULATED USING A DATATABLE

            DataTable DT = new DataTable("TEST TABLE FOR DEMO PURPOSES");
            DT.Columns.AddRange(
                new DataColumn[]
                {
                    new DataColumn("Id", typeof(int)),
                    new DataColumn("SomePropertyOrColumnName", typeof(string)),
                    new DataColumn("Description", typeof(string)),
                });
            DT.Rows.Add(1, "AAAA", "AAAAA");
            DT.Rows.Add(2, "BBBB", "BBBBB");
            DT.Rows.Add(3, "CCCC", "CCCCC");
            DT.Rows.Add(3, "DDDD", "DDDDD");

            //kcbcmbDataTableDataSource.DataSource =
            //    new ListSelectionWrapper<DataRow>(
            //        DT.Rows,
            //        "SomePropertyOrColumnName" // "SomePropertyOrColumnName" will populate the Name on ObjectSelectionWrapper.
            //        );
            //kcbcmbDataTableDataSource.DisplayMemberSingleItem = "Name";
            //kcbcmbDataTableDataSource.DisplayMember = "NameConcatenated";
            //kcbcmbDataTableDataSource.ValueMember = "Selected";

            #endregion
        }

        private void PopulateManualCombo()
        {
            kccmbManual.Items.Add("Item 1");
            kccmbManual.Items.Add("Item 2");
            kccmbManual.Items.Add("Item 3");
            kccmbManual.Items.Add("Item 4");
            kccmbManual.Items.Add("Item 5");
            kccmbManual.Items.Add("Item 6");
            kccmbManual.Items.Add("Item 7");
            kccmbManual.Items.Add("Item 8");

            kccmbManual.CheckBoxItems[1].Checked = true;
        }

        private void kbtnCheckItem1_Click(object sender, EventArgs e)
        {
            kccmbManual.CheckBoxItems["Item 1"].Checked = !kccmbManual.CheckBoxItems["Item 1"].Checked;
        }

        private void kbtnCheckItem5_Click(object sender, EventArgs e)
        {
            //kcbcmbStyle.CheckBoxItems["Item 5"].Checked = !kcbcmbStyle.CheckBoxItems["Item 5"].Checked;
        }

        private void kbtnCheckDDDD_Click(object sender, EventArgs e)
        {
            //kcbcmbDataTableDataSource.CheckBoxItems["DDDD"].Checked = !kcbcmbDataTableDataSource.CheckBoxItems["DDDD"].Checked;
        }

        private void kbtnCheckInserted_Click(object sender, EventArgs e)
        {
            //kcbcmbIListDataSource.CheckBoxItems["Inserted"].Checked = !kcbcmbIListDataSource.CheckBoxItems["Inserted"].Checked;
        }

        private void kbtnClear_Click(object sender, EventArgs e)
        {
            kccmbManual.Clear();

            PopulateManualCombo();
        }
    }
}
