#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    /// <summary>
    /// The interface used to merge krypton ribbons.
    /// </summary>
    public interface IRibbonMerger
    {
        /// <summary>
        /// Function to merge a ribbon with the target ribbon
        /// </summary>
        /// <param name="ribbon">The ribbon to merge.</param>
        /// <exception cref="ArgumentNullException">Thrown when the <paramref name="ribbon"/> parameter is <b>null</b>.</exception>
        void Merge(KryptonRibbon ribbon);

        /// <summary>
        /// Function to unmerge the specified ribbon from the target ribbon.
        /// </summary>
        /// <param name="ribbon">The ribbon to unmerge.</param>
        void Unmerge(KryptonRibbon ribbon);
    }
}