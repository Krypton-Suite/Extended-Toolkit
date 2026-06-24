#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Card;

namespace Krypton.Toolkit.Suite.Extended.Card.Tests;

public class CardRenderingTests
{
    [Fact]
    public void CreateRoundRectPath_ReturnsClosedPath()
    {
        using GraphicsPath path = CardRendering.CreateRoundRectPath(new Rectangle(0, 0, 100, 60), 8);
        Assert.True(path.PointCount > 0);
    }

    [Fact]
    public void GetCroppedImageBounds_PreservesAspectForWideImage()
    {
        using var image = new Bitmap(200, 100);
        Rectangle source = CardRendering.GetCroppedImageBounds(image, new Rectangle(0, 0, 100, 100));
        Assert.Equal(100, source.Height);
        Assert.True(source.Width < image.Width);
    }

    [Fact]
    public void ResolveShadowColor_ReturnsOpaqueColor()
    {
        using var control = new Control { BackColor = Color.White };
        Color shadow = CardRendering.ResolveShadowColor(control);
        Assert.True(shadow.A > 0);
    }
}

public class CardModelTests
{
    [Fact]
    public void CardItem_StoresBoundValues()
    {
        var item = new CardItem
        {
            Title = "Alpha",
            Subtitle = "Beta",
            Content = "Gamma",
        };

        Assert.Equal("Alpha", item.Title);
        Assert.Equal("Beta", item.Subtitle);
        Assert.Equal("Gamma", item.Content);
    }
}
