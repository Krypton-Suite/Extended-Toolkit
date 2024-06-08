﻿namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class Label
    {
        public bool IsVisible { get; set; } = true;
        public string Text { get; set; } = string.Empty;

        public Alignment Alignment { get; set; } = 0;

        /// <summary>
        /// Rotation in degrees clockwise from 0 (horizontal text)
        /// </summary>
        public float Rotation { get; set; } = 0;

        public Color ForeColor { get; set; } = Colors.Black;

        public Color BackColor { get; set; } = Colors.Transparent;

        public Color BorderColor { get; set; } = Colors.Transparent;

        public float BorderWidth { get; set; } = 1;

        // TODO: use a class for cached typeface management

        public bool UseCachedTypefaces = true;
        private SKTypeface? _cachedTypeface = null;

        private SKTypeface Typeface => UseCachedTypefaces && _cachedTypeface is not null
            ? _cachedTypeface
            : FontStyle.CreateTypeface(FontName, Bold, Italic);

        private string _fontName = Fonts.Default;

        public string FontName
        {
            get => _fontName;
            set
            {
                _fontName = value;
                ClearCachedTypeface();
            }
        }

        private float _fontSize = 12;

        public float FontSize
        {
            get => _fontSize;
            set
            {
                _fontSize = value;
                ClearCachedTypeface();
            }
        }

        private bool _bold = false;

        public bool Bold
        {
            get => _bold;
            set
            {
                _bold = value;
                ClearCachedTypeface();
            }
        }

        public bool Italic = false;
        public bool AntiAlias = true;
        public float Padding = 0;

        public float PointSize = 0;
        public bool PointFilled = false;
        public Color PointColor = Colors.Magenta;

        public float OffsetX = 0; // TODO: automatic padding support for arbitrary rotations
        public float OffsetY = 0; // TODO: automatic padding support for arbitrary rotations

        /// <summary>
        /// Use the characters in <see cref="Text"/> to detetermine an installed 
        /// system font most likely to support this character set.
        /// </summary>
        public void SetBestFont()
        {
            FontName = Fonts.Detect(Text);
        }

        public void ClearCachedTypeface()
        {
            _cachedTypeface = null;
        }

        private void ApplyPointPaint(SKPaint paint)
        {
            paint.IsStroke = !PointFilled;
            paint.StrokeWidth = 1;
            paint.Color = PointColor.ToSkColor();
            paint.IsAntialias = AntiAlias;
        }

        private void ApplyBorderPaint(SKPaint paint)
        {
            paint.IsStroke = true;
            paint.StrokeWidth = BorderWidth;
            paint.Color = BorderColor.ToSkColor();
            paint.IsAntialias = AntiAlias;
        }

        private void ApplyBackgroundPaint(SKPaint paint)
        {
            paint.IsStroke = false;
            paint.Color = BackColor.ToSkColor();
            paint.IsAntialias = AntiAlias;
        }

        private void ApplyTextPaint(SKPaint paint)
        {
            paint.TextAlign = SKTextAlign.Left;
            paint.IsStroke = false;
            paint.Typeface = Typeface;
            paint.TextSize = FontSize;
            paint.Color = ForeColor.ToSkColor();
            paint.IsAntialias = AntiAlias;
        }

        public void ApplyToPaint(SKPaint paint)
        {
            ApplyTextPaint(paint);
        }

        public void Render(SKCanvas canvas, Pixel pixel)
        {
            Render(canvas, pixel.X, pixel.Y);
        }

        public void Render(SKCanvas canvas, float x, float y)
        {
            using SKPaint paint = new();
            Render(canvas, x, y, paint);
        }

        public PixelSize Measure()
        {
            using SKPaint paint = new();
            return Measure(paint);
        }

        public PixelSize Measure(SKPaint paint)
        {
            ApplyTextPaint(paint);
            SKRect textBounds = new();
            ///INFO: MeasureText(string str, ref SKRect rect) works as follow:
            /// - returned value is the length of the text with leading and trailing white spaces
            /// - rect.Left contains the width of leading white spaces
            /// - rect.width contains the length of the text __without__ leading or trailing white spaces
            var fullTextWidth = paint.MeasureText(Text, ref textBounds);
            return new PixelSize(fullTextWidth, textBounds.Height);
        }

        public void Render(SKCanvas canvas, float x, float y, SKPaint paint)
        {
            PixelSize size = Measure(paint);

            float xOffset = size.Width * Alignment.HorizontalFraction();
            float yOffset = size.Height * Alignment.VerticalFraction();
            PixelRect textRect = new(0, size.Width, size.Height, 0);
            textRect = textRect.WithDelta(-xOffset, yOffset - size.Height);
            PixelRect backgroundRect = textRect.Expand(Padding);

            canvas.Save();
            canvas.Translate(x + OffsetX, y + OffsetY); // compensate for padding
            canvas.RotateDegrees(Rotation);
            ApplyBackgroundPaint(paint);
            canvas.DrawRect(backgroundRect.ToSkRect(), paint);
            ApplyTextPaint(paint);

            if (Text.Contains('\n'))
            {
                // TODO: multiline support could be significantly improved
                string[] lines = Text.Split('\n');
                for (int i = 0; i < lines.Length; i++)
                {
                    canvas.DrawText(lines[i], textRect.Left, textRect.Bottom + i * paint.FontSpacing, paint);
                }
            }
            else
            {
                canvas.DrawText(Text, textRect.Left, textRect.Bottom, paint);
            }

            ApplyBorderPaint(paint);
            canvas.DrawRect(backgroundRect.ToSkRect(), paint);
            canvas.Restore();

            canvas.Save();
            canvas.Translate(x, y); // do not compensate for padding
            canvas.RotateDegrees(Rotation);

            if (PointSize > 0)
            {
                ApplyPointPaint(paint);
                canvas.DrawCircle(0, 0, PointSize, paint);
            }

            canvas.DrawLine(-PointSize, 0, PointSize, 0, paint);
            canvas.DrawLine(0, -PointSize, 0, PointSize, paint);
            canvas.Restore();
        }
    }
}