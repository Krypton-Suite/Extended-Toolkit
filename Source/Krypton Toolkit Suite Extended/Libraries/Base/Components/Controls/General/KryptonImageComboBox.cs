#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.ComponentModel;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    public class KryptonImageComboBox : KryptonComboBox
    {
        private ImageComboCollection<ImageComboBoxItem> _items;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new ImageComboCollection<ImageComboBoxItem> Items { get => _items; set => _items = value; }

        public KryptonImageComboBox()
        {
            DropDownStyle = ComboBoxStyle.DropDownList;

            //DrawMode = DrawMode.OwnerDrawVariable;

            DrawItem += KryptonImageComboBox_DrawItem;

            ComboBox.MeasureItem += ComboBox_MeasureItem;
        }

        protected override ControlCollection CreateControlsInstance()
        {
            _items = new ImageComboCollection<ImageComboBoxItem> { };

            return base.CreateControlsInstance();
        }

        private void ComboBox_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void KryptonImageComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}