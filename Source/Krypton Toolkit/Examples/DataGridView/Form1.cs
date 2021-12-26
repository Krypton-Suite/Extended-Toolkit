using System.Data;
using System.Data.SQLite;
using System.Diagnostics;
using System.Windows.Forms;

using Krypton.Toolkit;

namespace DataGridViewExt
{
    public partial class Form1 : KryptonForm
    {
        public Form1()
        {
            InitializeComponent();
            // DB obtained from https://github.com/jpwhite3/northwind-SQLite3/blob/master/Northwind_small.sqlite
            string cs = @"URI=file:Northwind_small.sqlite";
            using var con = new SQLiteConnection(cs);
            con.Open();
            DataSet customerOrders = new();
            using (var custAdapter = new SQLiteDataAdapter(@"SELECT * FROM 'Employee'", con))
            {
                custAdapter.Fill(customerOrders, @"Employees");
            }

            using (var ordAdapter = new SQLiteDataAdapter(@"SELECT * FROM 'Order'", con))
            {
                ordAdapter.Fill(customerOrders, @"Orders");
            }

            // The data relationship below is not possible because the orders have more ids than the customers table contains
            //DataRelation relation = customerOrders.Relations.Add("CustOrders",
            //    customerOrders.Tables["Customers"].Columns["Id"],
            //    customerOrders.Tables["Orders"].Columns["CustomerId"]);

            kryptonDataGridView1.DataSet = customerOrders;
            kryptonDataGridView1.SetMasterSource(@"Employees", @"Id");  // Notice that the Source key column name
            kryptonDataGridView1.AddSingleDetail(@"Orders", @"EmployeeId"); // does not need to be the the same as the Detail target key column name
            kryptonDataGridView1.DetailsCellMouseClick += KryptonDataGridView1OnDetailsCellMouseClick;

            using (var empTerAdapter = new SQLiteDataAdapter(@"SELECT * FROM 'EmployeeTerritory'", con))
            {
                empTerAdapter.Fill(customerOrders, @"Territories");
            }

            kryptonDataGridView2.DataSet = customerOrders;
            kryptonDataGridView2.SetMasterSource(@"Employees", @"Id");
            kryptonDataGridView2.AddMultiDetail(@"Orders", @"EmployeeId", @"Orders");
            kryptonDataGridView2.AddMultiDetail(@"Territories", @"EmployeeId", @"Employee Territories");
            kryptonDataGridView2.DetailsCellMouseClick += KryptonDataGridView2OnDetailsCellMouseClick;
        }

        private void KryptonDataGridView2OnDetailsCellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Debug.WriteLine(kryptonDataGridView2.DetailsCurrentCell.Value);
        }

        private void KryptonDataGridView1OnDetailsCellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Debug.WriteLine(kryptonDataGridView1.DetailsCurrentCell.Value);
        }

        private void ButtonSpecAny1_Click(object sender, System.EventArgs e)
        {
            new ListExample().Show(this);
        }
    }
}
