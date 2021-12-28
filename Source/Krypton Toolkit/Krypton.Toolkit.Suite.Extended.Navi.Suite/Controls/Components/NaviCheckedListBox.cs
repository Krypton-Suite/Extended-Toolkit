#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    [ToolboxItem(false)]
    public class NaviCheckedListBox : CheckedListBox
    {
        private int checkBoxWidth = 18;
        private bool checkHandled = false;
        private bool itemChecked;

        protected override void OnItemCheck(ItemCheckEventArgs ice)
        {
            base.OnItemCheck(ice);
            if (checkHandled)
            {
                if (itemChecked)
                    ice.NewValue = CheckState.Checked;
                else
                    ice.NewValue = CheckState.Unchecked;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            checkHandled = false;
            if (e.Button == MouseButtons.Left)
            {
                int index = -1;
                for (int i = 0; i < Items.Count; i++)
                {
                    if (GetItemRectangle(i).Contains(e.X, e.Y))
                    {
                        index = i;
                        break;
                    }
                }
                if (index != -1 && e.X <= checkBoxWidth)
                {
                    itemChecked = !GetItemChecked(index);
                    checkHandled = true;
                    SetItemChecked(index, itemChecked);
                }
            }
        }
    }
}