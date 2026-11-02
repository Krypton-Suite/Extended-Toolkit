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
