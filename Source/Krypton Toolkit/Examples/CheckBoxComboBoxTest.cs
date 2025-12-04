#region MIT License

/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
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
using System.Data;

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
