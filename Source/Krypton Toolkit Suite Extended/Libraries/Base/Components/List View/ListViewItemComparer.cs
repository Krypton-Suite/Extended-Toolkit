using System.Collections;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Base
{
    public class ListViewItemComparer : IComparer
    {
        #region Variable
        private int _column;
        #endregion

        #region Constructors
        public ListViewItemComparer() => _column = 0;

        public ListViewItemComparer(int column) => _column = column;
        #endregion

        public int Compare(object x, object y) => string.Compare(((ListViewItem)x).SubItems[_column].Text, ((ListViewItem)y).SubItems[_column].Text);
    }
}