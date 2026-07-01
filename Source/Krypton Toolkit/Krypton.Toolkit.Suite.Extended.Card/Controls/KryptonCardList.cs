#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2026 - 2026 Krypton Suite
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
 *
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Card;

/// <summary>
/// Data-bound list that materializes <see cref="KryptonCard"/> items from a data source.
/// </summary>
[ToolboxItem(true)]
[ToolboxBitmap(typeof(KryptonCard))]
[DefaultProperty(nameof(DataSource))]
[Description(@"Displays a collection of KryptonCard controls from a data source.")]
public class KryptonCardList : UserControl
{
    private readonly KryptonCardFlowPanel _flowPanel;
    private object? _dataSource;
    private string _titleMember = nameof(CardItem.Title);
    private string _subtitleMember = nameof(CardItem.Subtitle);
    private string _imageMember = nameof(CardItem.Image);
    private string _contentMember = nameof(CardItem.Content);
    private int _cardWidth = 300;

    public KryptonCardList()
    {
        Dock = DockStyle.Fill;
        _flowPanel = new KryptonCardFlowPanel { Dock = DockStyle.Fill };
        Controls.Add(_flowPanel);
    }

    /// <summary>
    /// Occurs after cards are generated from the data source.
    /// </summary>
    [Category(@"Action")]
    public event EventHandler? CardsGenerated;

    /// <summary>
    /// Occurs when a generated card is clicked.
    /// </summary>
    [Category(@"Action")]
    public event EventHandler<CardItemEventArgs>? CardItemClick;

    [Category(@"Data")]
    [DefaultValue(null)]
    public object? DataSource
    {
        get => _dataSource;
        set
        {
            _dataSource = value;
            RebuildCards();
        }
    }

    [Category(@"Data")]
    [DefaultValue(nameof(CardItem.Title))]
    public string TitleMember
    {
        get => _titleMember;
        set => _titleMember = value ?? string.Empty;
    }

    [Category(@"Data")]
    [DefaultValue(nameof(CardItem.Subtitle))]
    public string SubtitleMember
    {
        get => _subtitleMember;
        set => _subtitleMember = value ?? string.Empty;
    }

    [Category(@"Data")]
    [DefaultValue(nameof(CardItem.Image))]
    public string ImageMember
    {
        get => _imageMember;
        set => _imageMember = value ?? string.Empty;
    }

    [Category(@"Data")]
    [DefaultValue(nameof(CardItem.Content))]
    public string ContentMember
    {
        get => _contentMember;
        set => _contentMember = value ?? string.Empty;
    }

    [Category(@"Layout")]
    [DefaultValue(300)]
    public int CardWidth
    {
        get => _cardWidth;
        set => _cardWidth = Math.Max(120, value);
    }

    /// <summary>
    /// Rebuilds cards from <see cref="DataSource"/>.
    /// </summary>
    public void RebuildCards()
    {
        foreach (Control control in _flowPanel.Cards.Cast<Control>().ToArray())
        {
            control.Dispose();
        }

        _flowPanel.Cards.Clear();

        if (_dataSource == null)
        {
            return;
        }

        if (_dataSource is IEnumerable enumerable)
        {
            foreach (object? item in enumerable)
            {
                if (item != null)
                {
                    AddCardFromItem(item);
                }
            }
        }

        CardsGenerated?.Invoke(this, EventArgs.Empty);
    }

    private void AddCardFromItem(object item)
    {
        var card = new KryptonCard
        {
            Width = _cardWidth,
            Title = Convert.ToString(GetPropertyValue(item, _titleMember)) ?? string.Empty,
        };

        card.Header.Title = card.Title;
        card.Header.Subtitle = Convert.ToString(GetPropertyValue(item, _subtitleMember)) ?? string.Empty;

        if (GetPropertyValue(item, _imageMember) is Image image)
        {
            card.CardImage.Image = image;
        }

        string content = Convert.ToString(GetPropertyValue(item, _contentMember)) ?? string.Empty;
        if (!string.IsNullOrWhiteSpace(content))
        {
            card.Content.Controls.Add(new KryptonWrapLabel
            {
                Dock = DockStyle.Top,
                AutoSize = false,
                Size = new Size(_cardWidth - 40, 60),
                Text = content,
            });
        }

        card.Tag = item;
        card.Clickable = true;
        card.CardClick += (_, _) => CardItemClick?.Invoke(this, new CardItemEventArgs(item, card));
        _flowPanel.Cards.Add(card);
    }

    private static object? GetPropertyValue(object item, string memberName)
    {
        if (string.IsNullOrWhiteSpace(memberName))
        {
            return null;
        }

        PropertyDescriptor? descriptor = TypeDescriptor.GetProperties(item)[memberName];
        return descriptor?.GetValue(item);
    }
}

/// <summary>
/// Provides data for <see cref="KryptonCardList.CardItemClick"/>.
/// </summary>
public sealed class CardItemEventArgs : EventArgs
{
    public CardItemEventArgs(object item, KryptonCard card)
    {
        Item = item;
        Card = card;
    }

    public object Item { get; }

    public KryptonCard Card { get; }
}
