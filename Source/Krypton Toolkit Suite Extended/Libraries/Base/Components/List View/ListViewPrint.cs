#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
#if !NETCOREAPP31 && !NET5
    [ToolboxBitmap(typeof(ListView)), ToolboxItem(false)]
    public class ListViewPrint : PrintDocument
    {

    }
#endif
}