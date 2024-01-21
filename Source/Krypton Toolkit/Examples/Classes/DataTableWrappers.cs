using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Krypton.Toolkit.Suite.Extended.Controls;

namespace Examples
{
    public class DataTableWrapper : ListSelectionWrapper<DataRow>
    {
        public DataTableWrapper(DataTable dataTable, string usePropertyAsDisplayName) : base(dataTable.Rows, false, usePropertyAsDisplayName) { }
    }
}