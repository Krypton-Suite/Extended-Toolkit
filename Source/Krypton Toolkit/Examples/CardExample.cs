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

using System.Drawing.Drawing2D;

namespace Examples;

public partial class CardExample : KryptonForm
{
    public CardExample()
    {
        InitializeComponent();
        BuildCards();
    }

    private void BuildCards()
    {
        var featuredCard = CreateFeaturedCard();
        featuredCard.Margin = new Padding(12);
        _flowPanel.Controls.Add(featuredCard);

        var simpleCard = CreateSimpleCard();
        simpleCard.Margin = new Padding(12);
        _flowPanel.Controls.Add(simpleCard);

        var outlinedCard = CreateOutlinedCard();
        outlinedCard.Margin = new Padding(12);
        _flowPanel.Controls.Add(outlinedCard);

        var cardList = CreateCardList();
        cardList.Margin = new Padding(12);
        cardList.Width = 640;
        cardList.Height = 260;
        _flowPanel.Controls.Add(cardList);

        var expandableCard = CreateExpandableCard();
        expandableCard.Margin = new Padding(12);
        _flowPanel.Controls.Add(expandableCard);
    }

    private static KryptonCard CreateFeaturedCard()
    {
        var card = new KryptonCard
        {
            Width = 340,
            Elevation = 6,
            CornerRadius = 6,
        };

        card.Header.Title = "Shiba Inu";
        card.Header.Subtitle = "Dog Breed";
        card.Header.Avatar = CreateAvatarBitmap("SI", Color.SteelBlue);

        card.CardImage.Image = CreateBannerBitmap(Color.FromArgb(63, 81, 181), "Shiba Inu");

        card.Content.Controls.Add(new KryptonWrapLabel
        {
            Dock = DockStyle.Top,
            AutoSize = false,
            Size = new Size(300, 72),
            Text = "The Shiba Inu is the smallest of the six original and distinct spitz breeds of dog from Japan.",
        });

        var likeButton = new KryptonButton { Text = "LIKE", AutoSize = true, Margin = new Padding(4) };
        var shareButton = new KryptonButton { Text = "SHARE", AutoSize = true, Margin = new Padding(4) };
        likeButton.Click += (_, _) => KryptonMessageBox.Show("Liked!", "Card Actions");
        shareButton.Click += (_, _) => KryptonMessageBox.Show("Shared!", "Card Actions");

        card.Actions.ActionControls.Add(likeButton);
        card.Actions.ActionControls.Add(shareButton);
        card.Actions.Alignment = CardActionsAlignment.End;

        card.Footer.Controls.Add(new KryptonLabel
        {
            AutoSize = true,
            LabelStyle = LabelStyle.NormalPanel,
            Text = "Last updated today",
        });

        return card;
    }

    private static KryptonCard CreateSimpleCard()
    {
        var card = new KryptonCard
        {
            Width = 280,
            Elevation = 2,
            CornerRadius = 4,
            Clickable = true,
        };

        card.CardClick += (_, _) => KryptonMessageBox.Show("Card clicked.", "KryptonCard");

        card.Header.Title = "Quick Settings";
        card.Header.Subtitle = "Tap the card surface";

        card.Content.Controls.Add(new KryptonWrapLabel
        {
            Dock = DockStyle.Top,
            AutoSize = false,
            Size = new Size(240, 48),
            Text = "A minimal card with header and content only. Empty sections are hidden automatically.",
        });

        return card;
    }

    private static KryptonCard CreateOutlinedCard()
    {
        var card = new KryptonCard
        {
            Width = 300,
            Appearance = CardAppearance.Outlined,
            CornerRadius = 6,
            Title = "Outlined Card",
        };

        card.TitleGroup.Title = "Material Outlined";
        card.TitleGroup.Subtitle = "No shadow, bordered surface";
        card.TitleGroup.Image = CreateAvatarBitmap("MO", Color.DarkSlateBlue);

        card.Content.Controls.Add(new KryptonWrapLabel
        {
            Dock = DockStyle.Top,
            AutoSize = false,
            Size = new Size(260, 48),
            Text = "Use CardAppearance.Outlined for flat bordered cards.",
        });

        return card;
    }

    private KryptonCardList CreateCardList()
    {
        var list = new KryptonCardList
        {
            CardWidth = 220,
            DataSource = new[]
            {
                new CardItem { Title = "Alpha", Subtitle = "First item", Content = "Generated from CardItem data." },
                new CardItem { Title = "Beta", Subtitle = "Second item", Content = "KryptonCardList binds collections to cards." },
                new CardItem { Title = "Gamma", Subtitle = "Third item", Content = "Click a card to handle CardItemClick." },
            },
        };

        list.CardItemClick += (_, args) =>
            KryptonMessageBox.Show($"Clicked {args.Item}", "Card List");

        return list;
    }

    private static KryptonCard CreateExpandableCard()
    {
        var card = new KryptonCard
        {
            Width = 320,
            Title = "Expandable Card",
            Expandable = true,
            Expanded = false,
            ExpandOnHeaderClick = true,
            AnimateExpandCollapse = true,
            ExpandDirection = CardExpandDirection.SlideDown,
            CornerRadius = 6,
            Elevation = 4,
        };

        card.Header.Title = "Click header to expand";
        card.Header.Subtitle = "Animated slide open/close";

        card.Content.Controls.Add(new KryptonWrapLabel
        {
            Dock = DockStyle.Top,
            AutoSize = false,
            Size = new Size(280, 64),
            Text = "This body slides down when expanded and slides up when collapsed. Set Expandable, Expanded, and ExpandDirection on KryptonCard.",
        });

        card.Actions.ActionControls.Add(new KryptonButton
        {
            Text = "ACTION",
            AutoSize = true,
            Margin = new Padding(4),
        });

        return card;
    }

    private static Bitmap CreateAvatarBitmap(string initials, Color color)
    {
        var bitmap = new Bitmap(40, 40);
        using Graphics graphics = Graphics.FromImage(bitmap);
        graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        using SolidBrush brush = new(color);
        graphics.FillEllipse(brush, 0, 0, 39, 39);

        using Font font = new("Segoe UI", 12F, FontStyle.Bold);
        using SolidBrush textBrush = new(Color.White);
        SizeF size = graphics.MeasureString(initials, font);
        graphics.DrawString(initials, font, textBrush, (40F - size.Width) / 2F, (40F - size.Height) / 2F);
        return bitmap;
    }

    private static Bitmap CreateBannerBitmap(Color color, string caption)
    {
        var bitmap = new Bitmap(340, 160);
        using Graphics graphics = Graphics.FromImage(bitmap);
        using LinearGradientBrush brush = new(new Rectangle(0, 0, bitmap.Width, bitmap.Height), color, ControlPaint.Light(color), 90f);
        graphics.FillRectangle(brush, 0, 0, bitmap.Width, bitmap.Height);

        using Font font = new("Segoe UI", 18F, FontStyle.Bold);
        using SolidBrush textBrush = new(Color.White);
        graphics.DrawString(caption, font, textBrush, new PointF(16, 16));
        return bitmap;
    }
}
