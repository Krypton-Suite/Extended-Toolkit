#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.ComponentModel.Design;

namespace Krypton.Toolkit.Suite.Extended.Palette.Selectors
{
    public class CustomPaletteCollectionEditor : CollectionEditor
    {
        public CustomPaletteCollectionEditor(Type type)
            : base(type)
        { }

        protected override bool CanSelectMultipleInstances()
        {
            return false;
        }

        protected override Type CreateCollectionItemType()
        {
            return typeof(CustomPalette);
        }

        protected override string GetDisplayText(object value)
        {
            CustomPalette palette = (CustomPalette)value;
            return base.GetDisplayText(palette.DisplayName);
        }
    }
}