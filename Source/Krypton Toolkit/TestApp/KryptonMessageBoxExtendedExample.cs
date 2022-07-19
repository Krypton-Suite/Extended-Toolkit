using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Krypton.Toolkit;
using Krypton.Toolkit.Suite.Extended.Messagebox;

namespace TestApp
{
    public partial class KryptonMessageBoxExtendedExample : KryptonForm
    {
        #region Instance Fields

        private ExtendedMessageBoxDefaultButton _defaultButton = ExtendedMessageBoxDefaultButton.Button4;

        private MessageBoxButtons _messageBoxButtons = MessageBoxButtons.OK;

        private MessageBoxOptions _options = 0;

        private HelpNavigator _helpNavigator = 0;

        private ExtendedKryptonMessageBoxIcon _icon = ExtendedKryptonMessageBoxIcon.NONE;

        private Image _customImage = null;

        private Font _customFont = new Font("Segoe UI", 8.25F);

        #endregion

        public KryptonMessageBoxExtendedExample()
        {
            InitializeComponent();
        }

        private void kbtnDefineFont_Click(object sender, EventArgs e)
        {
            KryptonFontDialog dlg = new KryptonFontDialog()
            {
                Font = new Font("Segoe UI", 8.25F)
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _customFont = dlg.Font;
            }
        }

        private void KryptonMessageBoxExtendedExample_Load(object sender, EventArgs e)
        {
            if (_customFont != null)
            {
                kwlDefinedFont.Text = $"Selected font: {_customFont}";
            }
        }
    }
}
