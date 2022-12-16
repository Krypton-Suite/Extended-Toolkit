using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examples
{
    public partial class TreeGridViewExample : KryptonForm
    {
        public TreeGridViewExample()
        {
            InitializeComponent();

            // DB obtained from https://github.com/jpwhite3/northwind-SQLite3/blob/master/Northwind_small.sqlite
            string cs = @"URI=file:Northwind_small.sqlite";
            using var con = new SQLiteConnection(cs);
            con.Open();
            DataSet customerOrders = new DataSet();
            using (var custAdapter = new SQLiteDataAdapter(@"SELECT * FROM 'Employee'", con))
            {
                // Note: Why doesn't this work?
                custAdapter.Fill(customerOrders, @"Employees");
            }

            using (var ordAdapter = new SQLiteDataAdapter(@"SELECT * FROM 'Order'", con))
            {
                ordAdapter.Fill(customerOrders, @"Orders");
            }
        }
    }
}
