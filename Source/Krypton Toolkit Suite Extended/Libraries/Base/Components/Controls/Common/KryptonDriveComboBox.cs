using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    public class KryptonDriveComboBox : KryptonImageCombo
    {
        #region Properties
        public string SelectedDrive
        {
            get
            {
                if (base.SelectedIndex != -1)
                {
                    return (base.SelectedIndex as ImageComboItem).ItemValue;
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion

        #region Constructors
        public KryptonDriveComboBox() : base()
        {
            ImageList.ColorDepth = ColorDepth.Depth32Bit;
        }
        #endregion
    }
}