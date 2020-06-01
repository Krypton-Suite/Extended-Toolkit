using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    public class ListViewItemComparerReverser : IComparer
    {
        #region Variable
        private int _column;
        #endregion

        #region Constructors
        public ListViewItemComparerReverser() => _column = 0;

        public ListViewItemComparerReverser(int column) => _column = column;
        #endregion

        public int Compare(object x, object y) => new CaseInsensitiveComparer().Compare(((ListViewItem)y).SubItems[_column].Text, ((ListViewItem)x).SubItems[_column].Text);
    }
}