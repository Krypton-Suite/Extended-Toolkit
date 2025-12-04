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
using System.ComponentModel;
using System.Data;

using Krypton.Toolkit.Suite.Extended.AdvancedDataGridView;

using Timer = System.Windows.Forms.Timer;

namespace Examples
{
    public partial class AdvancedDataGridView : KryptonForm
    {
        #region Instance Fields

        private DataTable _dataTable = null;
        private DataSet _dataSet = null;

        private SortedDictionary<int, string?> _filtersaved = new SortedDictionary<int, string?>();
        private SortedDictionary<int, string?> _sortsaved = new SortedDictionary<int, string?>();

        private bool _testtranslations = false;
        private bool _testtranslationsFromFile = false;

        private static int DisplayItemsCounter = 100;

        private static bool MemoryTestEnabled = true;
        private const int MEMORY_TEST_NUM = 100;
        private bool _memorytest = false;
        private object[][] _inrows = new object[][] { };

        private Timer _memorytestclosetimer = null;
        private Timer _timermemoryusage = null;

        private static bool CollectGarbageOnTimerMemoryUsageUpdate = true;

        #endregion

        public AdvancedDataGridView()
        {
            InitializeComponent();

            //set timers
            _memorytestclosetimer = new Timer(components)
            {
                Interval = 10
            };
            _timermemoryusage = new Timer(components)
            {
                Interval = 2000
            };

            //trigger the memory usage show
            _timermemoryusage_Tick(null, null);

            //set localization strings
            Dictionary<string, string> translations = new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> translation in KryptonAdvancedDataGridView.Translations)
            {
                if (!translations.ContainsKey(translation.Key))
                {
                    translations.Add(translation.Key, $".{translation.Value}");
                }
            }
            foreach (KeyValuePair<string, string> translation in KryptonAdvancedDataGridViewSearchToolBar.Translations)
            {
                if (!translations.ContainsKey(translation.Key))
                {
                    translations.Add(translation.Key, $".{translation.Value}");
                }
            }
            if (_testtranslations)
            {
                KryptonAdvancedDataGridView.SetTranslations(translations);
                KryptonAdvancedDataGridViewSearchToolBar.SetTranslations(translations);
            }
            if (_testtranslationsFromFile)
            {
                KryptonAdvancedDataGridView.SetTranslations(KryptonAdvancedDataGridView.LoadTranslationsFromFile("lang.json"));
                KryptonAdvancedDataGridViewSearchToolBar.SetTranslations(KryptonAdvancedDataGridViewSearchToolBar.LoadTranslationsFromFile("lang.json"));
            }

            //set filter and sort saved
            _filtersaved.Add(0, "");
            _sortsaved.Add(0, "");
            kcmbSavedFilters.DataSource = new BindingSource(_filtersaved, null);
            kcmbSavedFilters.DisplayMember = "Key";
            kcmbSavedFilters.ValueMember = "Value";
            kcmbSavedFilters.SelectedIndex = -1;
            kcmbSortSaved.DataSource = new BindingSource(_sortsaved, null);
            kcmbSortSaved.DisplayMember = "Key";
            kcmbSortSaved.ValueMember = "Value";
            kcmbSortSaved.SelectedIndex = -1;

            //set memory test button
            kbtnMemoryTest.Enabled = MemoryTestEnabled;

            //initialize dataset
            _dataTable = new DataTable();
            _dataSet = new DataSet();

            //initialize bindingsource
            bsData.DataSource = _dataSet;

            //initialize datagridview
            kadgvMain.SetDoubleBuffered();
            kadgvMain.DataSource = bsData;

            //set bindingsource
            SetTestData();
        }

        public AdvancedDataGridView(bool memoryTest, object[][] inRows) : this()
        {
            _memorytest = memoryTest;

            _inrows = inRows;
        }

        private void kbtnLoadRandomData_Click(object sender, EventArgs e)
        {
            //add test data to bindsource
            AddTestData();
        }

        private void SetTestData()
        {
            _dataTable = _dataSet.Tables.Add("TableTest");
            _dataTable.Columns.Add("int", typeof(int));
            _dataTable.Columns.Add("decimal", typeof(decimal));
            _dataTable.Columns.Add("double", typeof(double));
            _dataTable.Columns.Add("date", typeof(DateTime));
            _dataTable.Columns.Add("datetime", typeof(DateTime));
            _dataTable.Columns.Add("string", typeof(string));
            _dataTable.Columns.Add("boolean", typeof(bool));
            _dataTable.Columns.Add("guid", typeof(Guid));
            _dataTable.Columns.Add("image", typeof(Bitmap));
            _dataTable.Columns.Add("timespan", typeof(TimeSpan));

            bsData.DataMember = _dataTable.TableName;

            kryptonAdvancedDataGridViewSearchToolBar1.SetColumns(kadgvMain.Columns);
        }

        private void AddTestData()
        {
            Random r = new Random();
            Image[] sampleimages = new Image[2];
            sampleimages[0] = Image.FromFile(Path.Combine(Application.StartupPath, "flag-green_24.png"));
            sampleimages[1] = Image.FromFile(Path.Combine(Application.StartupPath, "flag-red_24.png"));

            int maxMinutes = (int)((TimeSpan.FromHours(20) - TimeSpan.FromHours(10)).TotalMinutes);

            if (_inrows.Length == 0)
            {
                for (int i = 0; i < DisplayItemsCounter; i++)
                {
                    object[] newrow = new object[] {
                        i,
                        Math.Round((decimal)i*2/3, 6),
                        Math.Round(i % 2 == 0 ? (double)i*2/3 : (double)i/2, 6),
                        DateTime.Today.AddHours(i*2).AddHours(i%2 == 0 ?i*10+1:0).AddMinutes(i%2 == 0 ?i*10+1:0).AddSeconds(i%2 == 0 ?i*10+1:0).AddMilliseconds(i%2 == 0 ?i*10+1:0).Date,
                        DateTime.Today.AddHours(i*2).AddHours(i%2 == 0 ?i*10+1:0).AddMinutes(i%2 == 0 ?i*10+1:0).AddSeconds(i%2 == 0 ?i*10+1:0).AddMilliseconds(i%2 == 0 ?i*10+1:0),
                        i*2 % 3 == 0 ? null : $"{i} str",
                        i % 2 == 0 ? true:false,
                        Guid.NewGuid(),
                        sampleimages[r.Next(0, 2)],
                        TimeSpan.FromHours(10).Add(TimeSpan.FromMinutes(r.Next(maxMinutes)))
                    };

                    _dataTable.Rows.Add(newrow);
                }
            }
            else
            {
                for (int i = 0; i < _inrows.Length; i++)
                {
                    _dataTable.Rows.Add(_inrows[i]);
                }
            }

        }

        private void AdvancedDataGridView_Load(object sender, EventArgs e)
        {
            //add test data to bindsource
            AddTestData();

            //setup datagridview
            kadgvMain.SetFilterDateAndTimeEnabled(kadgvMain.Columns["datetime"], true);
            kadgvMain.SetSortEnabled(kadgvMain.Columns["guid"], false);
            kadgvMain.SetFilterChecklistEnabled(kadgvMain.Columns["guid"], false);
            kadgvMain.SortAscending(kadgvMain.Columns["datetime"]);
            kadgvMain.SortDescending(kadgvMain.Columns["double"]);
            kadgvMain.SetTextFilterRemoveNodesOnSearch(kadgvMain.Columns["double"], false);
            kadgvMain.SetChecklistTextFilterRemoveNodesOnSearchMode(kadgvMain.Columns["decimal"], false);
            kadgvMain.SetFilterChecklistEnabled(kadgvMain.Columns["double"], false);
            kadgvMain.SetFilterCustomEnabled(kadgvMain.Columns["timespan"], false);
            kadgvMain.CleanSort(kadgvMain.Columns["datetime"]);
            kadgvMain.SetFilterChecklistTextFilterTextChangedDelayNodes(kadgvMain.Columns["string"], 10);
            kadgvMain.SetFilterChecklistTextFilterTextChangedDelayMs(kadgvMain.Columns["string"], 500);

            //memory test
            if (!_memorytest)
            {
                //set timer memory usage
                _timermemoryusage.Enabled = true;
                _timermemoryusage.Tick += _timermemoryusage_Tick;
            }
            else
            {
                kryptonPanel1.Visible = false;

                _memorytestclosetimer.Enabled = true;
                _memorytestclosetimer.Tick += _memorytestclosetimer_Tick;

                foreach (DataGridViewColumn column in kadgvMain.Columns)
                    kadgvMain.ShowMenuStrip(column);
            }
        }

        private void kadgvMain_FilterStringChanged(object sender, KryptonAdvancedDataGridView.FilterEventArgs e)
        {
            //eventually set the FilterString here
            //if e.Cancel is set to true one have to update the datasource here using
            //bindingSource_main.Filter = kadgvMain.FilterString;
            //otherwise it will be updated by the component

            //sample use of the override string filter
            string stringcolumnfilter = ktxtStringFilter.Text;
            if (!String.IsNullOrEmpty(stringcolumnfilter))
            {
                e.FilterString += (!String.IsNullOrEmpty(e.FilterString) ? " AND " : "") + String.Format("string LIKE '%{0}%'", stringcolumnfilter.Replace("'", "''"));
            }

            ktxtFilterString.Text = e.FilterString;
        }

        private void kadgvMain_SortStringChanged(object sender, KryptonAdvancedDataGridView.SortEventArgs e)
        {
            //eventually set the SortString here
            //if e.Cancel is set to true one have to update the datasource here
            //bindingSource_main.Sort = kadgvMain.SortString;
            //otherwise it will be updated by the component

            ktxtSortString.Text = e.SortString;
        }

        private void ktxtStringFilter_TextChanged(object sender, EventArgs e)
        {
            //trigger the filter string changed function when text is changed
            kadgvMain.TriggerFilterStringChanged();
        }

        private void bsData_ListChanged(object sender, ListChangedEventArgs e)
        {
            ktxtTotalRows.Text = bsData.List.Count.ToString();
        }

        private void kbtnSaveFilters_Click(object sender, EventArgs e)
        {
            _filtersaved.Add((kcmbSavedFilters.Items.Count - 1) + 1, kadgvMain.FilterString);
            kcmbSavedFilters.DataSource = new BindingSource(_filtersaved, null);
            kcmbSavedFilters.SelectedIndex = kcmbSavedFilters.Items.Count - 1;
            _sortsaved.Add((kcmbSortSaved.Items.Count - 1) + 1, kadgvMain.SortString);
            kcmbSortSaved.DataSource = new BindingSource(_sortsaved, null);
            kcmbSortSaved.SelectedIndex = kcmbSortSaved.Items.Count - 1;
        }

        private void kbtnApplySavedFilters_Click(object sender, EventArgs e)
        {
            if (kcmbSavedFilters.SelectedIndex != -1 && kcmbSortSaved.SelectedIndex != -1)
            {
                kadgvMain.LoadFilterAndSort(kcmbSavedFilters.SelectedValue.ToString(), kcmbSortSaved.SelectedValue.ToString());
            }
        }

        private void kbtnClearFilters_Click(object sender, EventArgs e)
        {
            kadgvMain.CleanFilterAndSort();
            kcmbSavedFilters.SelectedIndex = -1;
            kcmbSortSaved.SelectedIndex = -1;
        }

        private void kryptonAdvancedDataGridViewSearchToolBar1_Search(object sender, AdvancedDataGridViewSearchToolBarSearchEventArgs e)
        {
            bool restartsearch = true;
            int startColumn = 0;
            int startRow = 0;
            if (!e.FromBegin)
            {
                bool endcol = kadgvMain.CurrentCell.ColumnIndex + 1 >= kadgvMain.ColumnCount;
                bool endrow = kadgvMain.CurrentCell.RowIndex + 1 >= kadgvMain.RowCount;

                if (endcol && endrow)
                {
                    startColumn = kadgvMain.CurrentCell.ColumnIndex;
                    startRow = kadgvMain.CurrentCell.RowIndex;
                }
                else
                {
                    startColumn = endcol ? 0 : kadgvMain.CurrentCell.ColumnIndex + 1;
                    startRow = kadgvMain.CurrentCell.RowIndex + (endcol ? 1 : 0);
                }
            }
            DataGridViewCell? c = kadgvMain.FindCell(
                e.ValueToSearch,
                e.ColumnToSearch != null ? e.ColumnToSearch.Name : null,
                startRow,
                startColumn,
                e.WholeWord,
                e.CaseSensitive);
            if (c == null && restartsearch)
            {
                c = kadgvMain.FindCell(
                    e.ValueToSearch,
                    e.ColumnToSearch != null ? e.ColumnToSearch.Name : null,
                    0,
                    0,
                    e.WholeWord,
                    e.CaseSensitive);
            }

            if (c != null)
            {
                kadgvMain.CurrentCell = c;
            }
        }

        private void _timermemoryusage_Tick(object sender, EventArgs e)
        {
            if (CollectGarbageOnTimerMemoryUsageUpdate)
            {
                GC.Collect();
            }

            tsslMemoryUsage.Text = String.Format("Memory Usage: {0}Mb", GC.GetTotalMemory(false) / (1024 * 1024));
        }

        private void kbtnMemoryTest_Click(object sender, EventArgs e)
        {
            if (kcmbMemoryTest.SelectedItem != null && kcmbMemoryTest.SelectedItem.ToString() == "FullForm")
            {
                //build random data
                Random r = new Random();
                Image[] sampleimages = new Image[2];
                sampleimages[0] = Image.FromFile(Path.Combine(Application.StartupPath, "flag-green_24.png"));
                sampleimages[1] = Image.FromFile(Path.Combine(Application.StartupPath, "flag-red_24.png"));
                int maxMinutes = (int)((TimeSpan.FromHours(20) - TimeSpan.FromHours(10)).TotalMinutes);
                object[][] testrows = new object[100][];
                for (int i = 0; i < 100; i++)
                {
                    object[] newrow = new object[] {
                        i,
                        Math.Round((decimal)i*2/3, 6),
                        Math.Round(i % 2 == 0 ? (double)i*2/3 : (double)i/2, 6),
                        DateTime.Today.AddHours(i*2).AddHours(i%2 == 0 ?i*10+1:0).AddMinutes(i%2 == 0 ?i*10+1:0).AddSeconds(i%2 == 0 ?i*10+1:0).AddMilliseconds(i%2 == 0 ?i*10+1:0).Date,
                        DateTime.Today.AddHours(i*2).AddHours(i%2 == 0 ?i*10+1:0).AddMinutes(i%2 == 0 ?i*10+1:0).AddSeconds(i%2 == 0 ?i*10+1:0).AddMilliseconds(i%2 == 0 ?i*10+1:0),
                        i*2 % 3 == 0 ? null : $"{i} str",
                        i % 2 == 0 ? true:false,
                        Guid.NewGuid(),
                        sampleimages[r.Next(0, 2)],
                        TimeSpan.FromHours(10).Add(TimeSpan.FromMinutes(r.Next(maxMinutes)))
                    };

                    testrows.SetValue(newrow, i);
                }

                //show the forms
                for (int i = 0; i < MEMORY_TEST_NUM; i++)
                {
                    AdvancedDataGridView formtest = new AdvancedDataGridView(true, testrows);
                    formtest.Show();
                    //wait for the form to be disposed
                    while (!formtest.IsDisposed)
                    {
                        Application.DoEvents();
                        System.Threading.Thread.Sleep(100);
                    }
                }
            }
            else if (kcmbMemoryTest.SelectedItem != null && kcmbMemoryTest.SelectedItem.ToString() == "DataSource")
            {
                object datasourcePrev = kadgvMain.DataSource;

                //initialize dataset
                DataTable dataTableTest = new DataTable();
                DataSet dataSetTest = new DataSet();
                dataTableTest = dataSetTest.Tables.Add("TableTest");
                dataTableTest.Columns.Add("int", typeof(int));
                dataTableTest.Columns.Add("decimal", typeof(decimal));
                dataTableTest.Columns.Add("double", typeof(double));
                //add data
                for (int i = 0; i < 100; i++)
                {
                    object[] newrow = new object[] {
                            i,
                            Math.Round((decimal)i*2/3, 6),
                            Math.Round(i % 2 == 0 ? (double)i*2/3 : (double)i/2, 6)
                        };
                    dataTableTest.Rows.Add(newrow);
                }

                //update the DataSource
                for (int i = 0; i < MEMORY_TEST_NUM; i++)
                {
                    using (BindingSource bindingSourceTest = new BindingSource())
                    {
                        bindingSourceTest.DataSource = dataSetTest;
                        bindingSourceTest.DataMember = dataTableTest.TableName;
                        kadgvMain.DataSource = null;
                        kadgvMain.ColumnHeadersVisible = false;
                        kadgvMain.DataSource = bindingSourceTest;
                        kadgvMain.Refresh();
                        kadgvMain.ColumnHeadersVisible = true;
                        Application.DoEvents();
                    }
                }

                //restore original datasource
                kadgvMain.DataSource = datasourcePrev;
            }
            else
            {
                KryptonMessageBox.Show("Select a Memory Test", "Warning", KryptonMessageBoxButtons.OK, KryptonMessageBoxIcon.Warning);
            }
        }

        private void _memorytestclosetimer_Tick(object sender, EventArgs e)
        {
            _dataTable.Rows.Clear();
            this.Close();
        }
    }
}
