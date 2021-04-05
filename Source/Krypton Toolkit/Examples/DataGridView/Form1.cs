using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Diagnostics;
using System.Windows.Forms;
using Krypton.Toolkit;

namespace DataGridView
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
            DataSet customerOrders = new DataSet();
            using (var custAdapter = new SQLiteDataAdapter(@"SELECT * FROM 'Employee'", con))
            {
                custAdapter.Fill(customerOrders, @"Employees");
            }

            using (var ordAdapter = new SQLiteDataAdapter(@"SELECT * FROM 'Order'", con))
            {
                ordAdapter.Fill(customerOrders, @"Orders");
            }

            //DataRelation relation = customerOrders.Relations.Add("CustOrders",
            //    customerOrders.Tables["Customers"].Columns["Id"],
            //    customerOrders.Tables["Orders"].Columns["CustomerId"]);

            kryptonDataGridView1.DataSet = customerOrders;
            kryptonDataGridView1.SetMasterSource(@"Employees", @"Id");
            kryptonDataGridView1.AddSingleDetail(@"Orders", @"EmployeeId");
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
    }
}
