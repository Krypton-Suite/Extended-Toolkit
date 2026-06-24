#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Card;

/// <summary>
/// Combines a title, subtitle, and image into a single card section.
/// </summary>
[ToolboxItem(false)]
[DefaultProperty(nameof(Title))]
public class KryptonCardTitleGroup : KryptonCardSection
{
    private readonly PictureBox _image;
    private readonly KryptonLabel _titleLabel;
    private readonly KryptonLabel _subtitleLabel;
    private readonly TableLayoutPanel _layout;

    public KryptonCardTitleGroup()
        : base(new Padding(CardMetrics.StandardPadding))
    {
        AutoSize = true;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        Dock = DockStyle.Top;

        _image = new PictureBox
        {
            Size = new Size(CardMetrics.TitleGroupImageWidth, CardMetrics.TitleGroupImageWidth),
            SizeMode = PictureBoxSizeMode.Zoom,
            Margin = new Padding(0, 0, CardMetrics.StandardPadding, 0),
            Visible = false,
        };

        _titleLabel = new KryptonLabel
        {
            AutoSize = true,
            LabelStyle = LabelStyle.TitlePanel,
            Margin = Padding.Empty,
            Visible = false,
        };
        _titleLabel.TextChanged += (_, _) => OnTextChanged();

        _subtitleLabel = new KryptonLabel
        {
            AutoSize = true,
            LabelStyle = LabelStyle.NormalPanel,
            Margin = new Padding(0, CardMetrics.HeaderTextGap, 0, 0),
            Visible = false,
        };
        _subtitleLabel.TextChanged += (_, _) => OnTextChanged();

        var textStack = new TableLayoutPanel
        {
            AutoSize = true,
            AutoSizeMode = AutoSizeMode.GrowAndShrink,
            ColumnCount = 1,
            RowCount = 2,
            Dock = DockStyle.Fill,
            Margin = Padding.Empty,
        };
        textStack.Controls.Add(_titleLabel, 0, 0);
        textStack.Controls.Add(_subtitleLabel, 0, 1);

        _layout = new TableLayoutPanel
        {
            AutoSize = true,
            AutoSizeMode = AutoSizeMode.GrowAndShrink,
            ColumnCount = 2,
            RowCount = 1,
            Dock = DockStyle.Top,
            Margin = Padding.Empty,
        };
        _layout.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
        _layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        _layout.Controls.Add(_image, 0, 0);
        _layout.Controls.Add(textStack, 1, 0);

        Controls.Add(_layout);
    }

    [Category(@"Appearance")]
    [DefaultValue("")]
    [Localizable(true)]
    public string Title
    {
        get => _titleLabel.Text;
        set => _titleLabel.Text = value ?? string.Empty;
    }

    [Category(@"Appearance")]
    [DefaultValue("")]
    [Localizable(true)]
    public string Subtitle
    {
        get => _subtitleLabel.Text;
        set => _subtitleLabel.Text = value ?? string.Empty;
    }

    [Category(@"Appearance")]
    [DefaultValue(null)]
    public Image? Image
    {
        get => _image.Image;
        set
        {
            _image.Image = value;
            _image.Visible = value != null;
            NotifyOwnerContentChanged();
        }
    }

    internal override bool IsSectionEmpty() =>
        string.IsNullOrWhiteSpace(Title)
        && string.IsNullOrWhiteSpace(Subtitle)
        && Image == null
        && Controls.Count == 1;

    private void OnTextChanged()
    {
        _titleLabel.Visible = !string.IsNullOrWhiteSpace(Title);
        _subtitleLabel.Visible = !string.IsNullOrWhiteSpace(Subtitle);
        NotifyOwnerContentChanged();
    }
}
