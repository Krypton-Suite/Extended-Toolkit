namespace Krypton.Toolkit.Suite.Extended.Base
{
    public class ListViewColumn
    {
        #region Variables
        private int _columnNumber;
        #endregion

        #region Properties
        public int ColumnNumber { get => _columnNumber; set => _columnNumber = value; }

        public int DefaultColumnNumber => -1;
        #endregion

        #region Constructor
        public ListViewColumn()
        {
            ColumnNumber = DefaultColumnNumber;
        }
        #endregion
    }
}