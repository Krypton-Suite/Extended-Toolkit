#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Card;

/// <summary>
/// Card header section with optional avatar, title, and subtitle.
/// </summary>
[ToolboxItem(false)]
[DefaultProperty(nameof(Title))]
public class KryptonCardHeader : KryptonCardSection
{
    private readonly PictureBox _avatar;
    private readonly KryptonLabel _titleLabel;
    private readonly KryptonLabel _subtitleLabel;
    private readonly TableLayoutPanel _layout;

    /// <summary>
    /// Initializes a new instance of the <see cref="KryptonCardHeader"/> class.
    /// </summary>
    public KryptonCardHeader()
        : base(new Padding(CardMetrics.StandardPadding))
    {
        AutoSize = true;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        Dock = DockStyle.Top;

        _avatar = new PictureBox
        {
            Size = new Size(CardMetrics.AvatarSize, CardMetrics.AvatarSize),
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
        _titleLabel.TextChanged += (_, _) => OnHeaderTextChanged();

        _subtitleLabel = new KryptonLabel
        {
            AutoSize = true,
            LabelStyle = LabelStyle.NormalPanel,
            Margin = new Padding(0, CardMetrics.HeaderTextGap, 0, 0),
            Visible = false,
        };
        _subtitleLabel.TextChanged += (_, _) => OnHeaderTextChanged();

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
        _layout.Controls.Add(_avatar, 0, 0);
        _layout.Controls.Add(textStack, 1, 0);

        Controls.Add(_layout);
    }

    /// <summary>
    /// Gets or sets the card title text.
    /// </summary>
    [Category(@"Appearance")]
    [DefaultValue("")]
    [Localizable(true)]
    public string Title
    {
        get => _titleLabel.Text;
        set => _titleLabel.Text = value ?? string.Empty;
    }

    /// <summary>
    /// Gets or sets the card subtitle text.
    /// </summary>
    [Category(@"Appearance")]
    [DefaultValue("")]
    [Localizable(true)]
    public string Subtitle
    {
        get => _subtitleLabel.Text;
        set => _subtitleLabel.Text = value ?? string.Empty;
    }

    /// <summary>
    /// Gets or sets the avatar image displayed in the header.
    /// </summary>
    [Category(@"Appearance")]
    [DefaultValue(null)]
    public Image? Avatar
    {
        get => _avatar.Image;
        set
        {
            _avatar.Image = value;
            _avatar.Visible = value != null;
            UpdateAvatarRegion();
            NotifyOwnerContentChanged();
        }
    }

    /// <inheritdoc />
    internal override bool IsSectionEmpty() =>
        string.IsNullOrWhiteSpace(Title)
        && string.IsNullOrWhiteSpace(Subtitle)
        && Avatar == null
        && Controls.Count == 1;

    private void OnHeaderTextChanged()
    {
        _titleLabel.Visible = !string.IsNullOrWhiteSpace(Title);
        _subtitleLabel.Visible = !string.IsNullOrWhiteSpace(Subtitle);
        NotifyOwnerContentChanged();
    }

    private void UpdateAvatarRegion()
    {
        if (_avatar.Image == null || _avatar.Width <= 0 || _avatar.Height <= 0)
        {
            _avatar.Region = null;
            return;
        }

        using GraphicsPath path = new();
        path.AddEllipse(0, 0, _avatar.Width - 1, _avatar.Height - 1);
        _avatar.Region = new Region(path);
    }
}
