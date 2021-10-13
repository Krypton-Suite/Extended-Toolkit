namespace Krypton.Toolkit.Suite.Extended.Outlook.Grid
{
    internal class OutlookGridGroupCountComparer : IComparer<IOutlookGridGroup>
    {
        public OutlookGridGroupCountComparer()
        {
        }

        #region IComparer Members

        public int Compare(IOutlookGridGroup x, IOutlookGridGroup y)
        {
            int compareResult = 0;
            try
            {
                int orderModifier = (x.Column.SortDirection == SortOrder.Ascending ? 1 : -1);

                int c1 = x.ItemCount;
                int c2 = y.ItemCount;
                compareResult = c1.CompareTo(c2) * orderModifier;

                if (compareResult == 0)
                {
                    compareResult = x.CompareTo(y);
                }
                return compareResult;
            }
            catch (Exception ex)
            {
                throw new Exception("OutlookGridGroupCountComparer: " + this.ToString(), ex);
            }
        }
        #endregion
    }
}