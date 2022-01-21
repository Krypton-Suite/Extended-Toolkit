using System.Data;
using System.Data.SQLite;

using Krypton.Toolkit;

namespace TreeGridView
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
        }

    }
}
