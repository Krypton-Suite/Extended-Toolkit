#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    /// <summary>
    /// Represents a series of data values with a common name. Values from several DataSets can be grouped (by value index).
    /// </summary>
    public class DataSet
    {
        public string label;
        public double[] values;
        public double[] errors;

        public DataSet(string label, double[] values, double[] errors = null)
        {
            this.values = values;
            this.label = label;
            this.errors = errors;

            if (errors != null && errors.Length != values.Length)
                throw new ArgumentException("values and errors must have identical length");
        }
    }
}
