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
/// Full-width card image section.
/// </summary>
[ToolboxItem(false)]
[DefaultProperty(nameof(Image))]
public class KryptonCardImage : KryptonCardSection
{
    private readonly PictureBox _pictureBox;
    private int _imageHeight = 180;
    private CardImageSizeMode _sizeMode = CardImageSizeMode.Zoom;

    public KryptonCardImage()
        : base(Padding.Empty)
    {
        Dock = DockStyle.Top;
        AutoSize = false;
        Height = _imageHeight;

        _pictureBox = new PictureBox
        {
            Dock = DockStyle.Fill,
            SizeMode = PictureBoxSizeMode.Zoom,
            Margin = Padding.Empty,
        };

        Controls.Add(_pictureBox);
    }

    [Category(@"Appearance")]
    [DefaultValue(null)]
    public Image? Image
    {
        get => _pictureBox.Image;
        set
        {
            _pictureBox.Image = value;
            UpdateHeightFromImage();
            NotifyOwnerContentChanged();
            Invalidate();
        }
    }

    [Category(@"Layout")]
    [DefaultValue(CardImageSizeMode.Zoom)]
    public CardImageSizeMode SizeMode
    {
        get => _sizeMode;
        set
        {
            _sizeMode = value;
            _pictureBox.Visible = _sizeMode != CardImageSizeMode.Crop;
            Invalidate();
        }
    }

    [Category(@"Layout")]
    [DefaultValue(180)]
    public int ImageHeight
    {
        get => _imageHeight;
        set
        {
            _imageHeight = Math.Max(1, value);
            UpdateHeightFromImage();
        }
    }

    internal override bool IsSectionEmpty() => Image == null && Controls.Count == 1;

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        if (_sizeMode != CardImageSizeMode.Crop || Image == null)
        {
            return;
        }

        Rectangle target = ClientRectangle;
        Rectangle source = CardRendering.GetCroppedImageBounds(Image, target);
        e.Graphics.DrawImage(Image, target, source, GraphicsUnit.Pixel);
    }

    protected override void OnSizeChanged(EventArgs e)
    {
        base.OnSizeChanged(e);
        UpdateHeightFromImage();
    }

    private void UpdateHeightFromImage()
    {
        if (Image == null || _sizeMode == CardImageSizeMode.Stretch)
        {
            Height = _imageHeight;
            _pictureBox.SizeMode = _sizeMode == CardImageSizeMode.Stretch
                ? PictureBoxSizeMode.StretchImage
                : PictureBoxSizeMode.Zoom;
            return;
        }

        _pictureBox.SizeMode = PictureBoxSizeMode.Zoom;

        if (Width > 0)
        {
            double aspect = (double)Image.Height / Image.Width;
            Height = Math.Max(1, (int)Math.Round(Width * aspect));
        }
        else
        {
            Height = _imageHeight;
        }
    }
}
