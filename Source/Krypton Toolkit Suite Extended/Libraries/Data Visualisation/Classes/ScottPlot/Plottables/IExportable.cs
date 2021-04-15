#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Collections.Generic;
using System.Text;

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    /// <summary>
    /// describes Plottable objects whose data can be exported as a text file
    /// </summary>
    public interface IExportable
    {
        void SaveCSV(string filePath, string delimiter = ", ", string separator = "\n");
        string GetCSV(string delimiter = ", ", string separator = "\n");
    }
}
