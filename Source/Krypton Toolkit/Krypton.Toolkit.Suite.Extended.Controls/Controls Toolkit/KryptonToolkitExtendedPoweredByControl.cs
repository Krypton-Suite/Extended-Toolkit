namespace Krypton.Toolkit.Suite.Extended.Controls;

public partial class KryptonToolkitExtendedPoweredByControl : UserControl
{
    #region Instance Fields

    private bool _showThemeOption;

    private ToolkitSupportType _toolkitType;

    #endregion

    #region Public

    /// <summary>Gets or sets a value indicating whether [show theme option].</summary>
    /// <value><c>true</c> if [show theme option]; otherwise, <c>false</c>.</value>
    [DefaultValue(false), Description(@"Allows the user to change the theme.")]
    public bool ShowThemeOption { get => _showThemeOption; set { _showThemeOption = value; Invalidate(); SetLogoSpan(value); } }

    /// <summary>Gets or sets the type of the toolkit.</summary>
    /// <value>The type of the toolkit.</value>
    [DefaultValue(typeof(ToolkitSupportType), @"ToolkitSupportType.Stable"), Description(@"Changes the icon based on the type of toolkit you are using.")]
    public ToolkitSupportType ToolkitType { get => _toolkitType; set { _toolkitType = value; SetLogo(value); } }

    #endregion

    #region Identity

    /// <summary>Initializes a new instance of the <see cref="KryptonToolkitExtendedPoweredByControl" /> class.</summary>
    public KryptonToolkitExtendedPoweredByControl()
    {
        InitializeComponent();

        _showThemeOption = false;

        _toolkitType = ToolkitSupportType.Stable;

        Size = new Size(659, 122);
    }

    #endregion

    #region Implementation

    private void SetLogo(ToolkitSupportType toolkitType)
    {
        switch (toolkitType)
        {
            case ToolkitSupportType.Canary:
                kpbxLogo.Image = Resources.Krypton_Canary;
                break;
            case ToolkitSupportType.Nightly:
                kpbxLogo.Image = Resources.Krypton_Nightly;
                break;
            case ToolkitSupportType.Stable:
                kpbxLogo.Image = Resources.Krypton_Stable;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(toolkitType), toolkitType, null);
        }
    }

    private void SetLogoSpan(bool showThemeOption)
    {
        if (showThemeOption)
        {
            tlpContent.SetRowSpan(kpbxLogo, 3);

            TableLayoutPanelCellPosition currentThemeLabelCellPosition =
                tlpContent.GetCellPosition(kwlblCurrentTheme);

            TableLayoutPanelCellPosition currentThemeCellPosition = tlpContent.GetCellPosition(ktcmbTheme);

            int labelRowHeight = tlpContent.GetRowHeights()[currentThemeLabelCellPosition.Row];

            int comboBoxRowHeight = tlpContent.GetRowHeights()[currentThemeCellPosition.Row];

            int addedHeight = labelRowHeight + comboBoxRowHeight;

            Size = new Size(659, addedHeight);
        }
        else
        {
            tlpContent.SetRowSpan(kpbxLogo, 1);

            Size = new Size(659, 122);
        }
    }

    private void klwlblDescription_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        try
        {
            Process.Start(@"https://github.com/Krypton-Suite/Extended-Toolkit");
        }
        catch (Exception exception)
        {
            DebugUtilities.NotImplemented(exception.ToString());
        }
    }

    #endregion

    #region Removed Designer Visibility

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public override Color BackColor { get; set; }

    #endregion
}