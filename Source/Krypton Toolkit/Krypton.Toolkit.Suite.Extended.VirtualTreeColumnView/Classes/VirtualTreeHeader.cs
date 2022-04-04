#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Collections.Generic;
using System.ComponentModel;

namespace Krypton.Toolkit.Suite.Extended.VirtualTreeColumnView
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class VirtualTreeHeader
    {
        [Category("Behavior")]
        [DefaultValue(true)]
        public bool Visible { get; set; } = true;

        [Category("Behavior")]
        [DefaultValue(20)]
        [Description(@"Will be equivalent to the RowHeight")]
        public int MinHeight { get; set; } = 20;

        [Category("Behavior")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<VirtualTreeColumn> Columns { get; set; } = new();
    }
}
