#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Tool.Strip.Items
{
    [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.All)]
    [ToolboxBitmap(typeof(KryptonNumericUpDown))]
    public partial class KryptonNumericUpDownToolStripItem : ToolStripControlHost
    {
        #region Constructor
        public KryptonNumericUpDownToolStripItem() : base(new KryptonNumericUpDown())
        {

        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets KryptonNumericUpDownControl.
        /// </summary>
        /// <value>
        /// The base control.
        /// </value>
        public KryptonNumericUpDown KryptonNumericUpDownControl
        {
            get
            {
                return Control as KryptonNumericUpDown;
            }
        }

        /// <summary>
        /// Gets or sets Value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public decimal Value
        {
            get
            {
                return KryptonNumericUpDownControl.Value;
            }


            set
            {
                KryptonNumericUpDownControl.Value = value;
            }
        }
        #endregion
    }
}