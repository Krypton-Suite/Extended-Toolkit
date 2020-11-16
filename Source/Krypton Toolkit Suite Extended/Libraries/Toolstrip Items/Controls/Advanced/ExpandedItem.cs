using Krypton.Toolkit.Suite.Extended.Tool.Strip.Items.Properties;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Tool.Strip.Items.Controls
{
    internal class ExpandedItem : ExpandingMenuItem
    {
        public ExpandedItem() : base()
        {
            Name = "ExpandableMenuItem";

            var bitmap = Resources.Expand_large;

            bitmap.MakeTransparent(Color.Magenta);

            BackgroundImageLayout = ImageLayout.Center;

            BackgroundImage = bitmap;
        }
    }
}