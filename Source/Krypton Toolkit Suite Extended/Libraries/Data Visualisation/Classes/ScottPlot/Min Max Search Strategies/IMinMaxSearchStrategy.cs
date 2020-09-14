using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    public interface IMinMaxSearchStrategy<T>
    {
        T[] SourceArray { get; set; }
        void MinMaxRangeQuery(int l, int r, out double lowestValue, out double highestValue);
        void updateElement(int index, T newValue);
        void updateRange(int from, int to, T[] newData, int fromData = 0);
        double SourceElement(int index);
    }
}