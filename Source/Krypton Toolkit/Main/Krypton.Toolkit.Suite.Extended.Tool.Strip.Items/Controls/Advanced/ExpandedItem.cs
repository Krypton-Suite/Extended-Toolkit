#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Tool.Strip.Items
{
    internal class ExpandedItem : ExpandingMenuItem
    {
        public ExpandedItem() : base()
        {
            Name = "ExpandableMenuItem";

            var bitmap = ProjectResources.Expand_large;

            bitmap.MakeTransparent(Color.Magenta);

            BackgroundImageLayout = ImageLayout.Center;

            BackgroundImage = bitmap;
        }
    }
}