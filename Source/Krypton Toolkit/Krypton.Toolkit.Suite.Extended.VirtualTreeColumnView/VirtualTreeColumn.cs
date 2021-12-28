#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.ComponentModel;

namespace Krypton.Toolkit.Suite.Extended.VirtualTreeColumnView
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class VirtualTreeColumn
    {
        [Category("Behavior")]
        [DefaultValue(@"Name")]
        [RefreshProperties(RefreshProperties.Repaint)]
        public string Name { get; set; } = @"Name";

        [Category("Behavior")]
        [DefaultValue(100)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public int Width { get; set; } = 100;

        [Category("Behavior")]
        [Description(@"Use remaining space to proportionally fill")]
        [DefaultValue(false)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public bool Fill { get; set; }

        // used so that we do not have to keep calculating where the col starts
        internal int StartPos;

    }
}
