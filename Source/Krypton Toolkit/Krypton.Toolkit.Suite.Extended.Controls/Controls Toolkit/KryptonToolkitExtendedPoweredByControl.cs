using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Controls
{
    public partial class KryptonToolkitExtendedPoweredByControl : UserControl
    {
        #region Instance Fields

        private bool _showThemeOption;

        private ToolkitType _toolkitType;

        #endregion

        #region Public

        /// <summary>Gets or sets a value indicating whether [show theme option].</summary>
        /// <value><c>true</c> if [show theme option]; otherwise, <c>false</c>.</value>
        [DefaultValue(false), Description(@"Allows the user to change the theme.")]
        public bool ShowThemeOption { get => _showThemeOption; set { _showThemeOption = value; Invalidate(); SetLogoSpan(value); } }

        /// <summary>Gets or sets the type of the toolkit.</summary>
        /// <value>The type of the toolkit.</value>
        [DefaultValue(typeof(ToolkitType), @"ToolkitType.Stable"), Description(@"Changes the icon based on the type of toolkit you are using.")]
        public ToolkitType ToolkitType { get => _toolkitType; set { _toolkitType = value; SetLogo(value); } }

        #endregion

        #region Identity

        /// <summary>Initializes a new instance of the <see cref="KryptonToolkitExtendedPoweredByControl" /> class.</summary>
        public KryptonToolkitExtendedPoweredByControl()
        {
            InitializeComponent();

            _showThemeOption = false;

            _toolkitType = ToolkitType.Stable;
        }

        #endregion

        #region Implementation

        private void SetLogo(ToolkitType toolkitType)
        {
            switch (toolkitType)
            {
                case ToolkitType.Canary:
                    pictureBox1.Image = Resources.Krypton_Canary;
                    break;
                case ToolkitType.Nightly:
                    pictureBox1.Image = Resources.Krypton_Nightly;
                    break;
                case ToolkitType.Stable:
                    pictureBox1.Image = Resources.Krypton_Stable;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(toolkitType), toolkitType, null);
            }
        }

        private void SetLogoSpan(bool showThemeOption)
        {
            /*if (showThemeOption)
            {
                tlpnlContent.SetRowSpan(kpbxLogo, 10);

                TableLayoutPanelCellPosition currentThemeLabelCellPosition =
                    tlpnlContent.GetCellPosition(kwlblCurrentTheme);

                TableLayoutPanelCellPosition currentThemeCellPosition = tlpnlContent.GetCellPosition(ktcmbCurrentTheme);

                int labelRowHeight = tlpnlContent.GetRowHeights()[currentThemeLabelCellPosition.Row];

                int comboBoxRowHeight = tlpnlContent.GetRowHeights()[currentThemeCellPosition.Row];

                int addedHeight = labelRowHeight + comboBoxRowHeight;

                Size = new Size(659, addedHeight);
            }
            else
            {
                tlpnlContent.SetRowSpan(kpbxLogo, 1);

                Size = new Size(659, 122);
            }
            */
        }

        #endregion
    }
}
