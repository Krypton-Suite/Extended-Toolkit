using System.Drawing;
using System.Drawing.Drawing2D;

namespace Krypton.Toolkit.Suite.Extended.Dialogs
{
    /// <summary>
    /// Contains methods to paint the glass effect.
    /// </summary>
    internal class PaintingEngine
    {
        /// <summary>
        /// Private constructor
        /// </summary>
        private PaintingEngine()
        {
        }

        /// <summary>
        /// Paints a glass effect on graphics using the width width, the height height and the pColor color
        /// </summary>
        /// <param name="graphics">Graphics to paint into</param>
        /// <param name="color">Base color of the glass effect</param>
        /// <param name="width">Width of the effect</param>
        /// <param name="height">Height of the effect</param>
        internal static void PaintGlassEffect(Graphics graphics, Color color, int width, int height)
        {
            // Fill the background
            SolidBrush backBrush = new SolidBrush(Color.Gainsboro);
            graphics.FillRectangle(backBrush, new Rectangle(0, 0, width, height));

            int topZoneHeight = (height - 3) / 2;

            // Create brushes
            LinearGradientBrush brushTop = new LinearGradientBrush(
                new RectangleF(0, 0, width, topZoneHeight),
                Color.FromArgb(50, color),
                Color.FromArgb(160, color),
                LinearGradientMode.Vertical);

            LinearGradientBrush brushMiddle = new LinearGradientBrush(
                new RectangleF(0, 0, width, height - 3 - topZoneHeight),
                Color.FromArgb(190, color),
                Color.FromArgb(210, color),
                LinearGradientMode.Vertical);

            LinearGradientBrush brushBottom = new LinearGradientBrush(
                new RectangleF(0, 0, width, 3),
                Color.FromArgb(210, color),
                Color.FromArgb(50, color),
                LinearGradientMode.Vertical);

            // Fill zones
            graphics.FillRectangle(brushTop, new Rectangle(0, 0, width, topZoneHeight));
            graphics.FillRectangle(brushMiddle, new Rectangle(0, topZoneHeight, width, height - 3 - topZoneHeight));
            graphics.FillRectangle(brushBottom, new Rectangle(0, height - 3, width, 3));

            graphics.DrawLine(new Pen(Color.DimGray), new Point(0, height - 1), new Point(width, height - 1));
        }

        /// <summary>
        /// Paints borders on sides on selected sides of the zone delimited by width and height
        /// </summary>
        /// <param name="graphics">Graphics to paint into</param>
        /// <param name="topColor">Top color of the border</param>
        /// <param name="bottomColor">Bottom color of the border</param>
        /// <param name="width">Width of the control</param>
        /// <param name="height">Height of the control</param>
        /// <param name="borderWidth">Width of the border</param>
        /// <param name="sides">Represents on which sides are the borders</param>
        internal static void PaintGradientBorders(Graphics graphics, Color topColor, Color bottomColor, int width, int height, int borderWidth, SideBorder sides)
        {
            if (sides != SideBorder.None)
            {
                LinearGradientBrush brushSide = new LinearGradientBrush(new Rectangle(0, 0, borderWidth, height), topColor, bottomColor, LinearGradientMode.Vertical);

                if (sides != SideBorder.Right)
                {
                    graphics.FillRectangle(brushSide, new Rectangle(0, 0, borderWidth, height));
                }

                if (sides != SideBorder.Left)
                {
                    graphics.FillRectangle(brushSide, new Rectangle(width - borderWidth, 0, borderWidth, height));
                }
            }
        }

        /// <summary>
        /// Paints an hover effect according the provided position ans style
        /// </summary>
        /// <param name="graphics">The graphics.</param>
        /// <param name="outerColor">Outer color of the effect</param>
        /// <param name="middleColor">Middle color of the effect</param>
        /// <param name="innerColor">Inner color of the effect</param>
        /// <param name="lightColor">Color of the light effect</param>
        /// <param name="width">Width of the control (for centering purpose)</param>
        /// <param name="height">Height of the control (for centering purpose)</param>
        internal static void PaintHoverEffect(Graphics graphics, Color outerColor, Color middleColor, Color innerColor, Color lightColor, int width, int height)
        {
            // Light effect
            int topZoneHeight = (height - 3) / 2;
            Rectangle lightEffectRectangle;

            Pen outerBorderPen = new Pen(new SolidBrush(outerColor));
            Pen middleBorderPen = new Pen(new SolidBrush(middleColor));
            Pen innerBorderPen = new Pen(new SolidBrush(innerColor));

            GraphicsPath outerBorderPath = new GraphicsPath();
            GraphicsPath middleBorderPath = new GraphicsPath();
            GraphicsPath innerBorderPath = new GraphicsPath();

            outerBorderPath.AddLine(new Point(3, height), new Point(3, 5));
            outerBorderPath.AddCurve(new Point[] { new Point(3, 5), new Point(5, 3) }, 0.5f);
            outerBorderPath.AddLine(new Point(5, 3), new Point(width - 6, 3));
            outerBorderPath.AddCurve(new Point[] { new Point(width - 6, 3), new Point(width - 4, 5) }, 0.5f);
            outerBorderPath.AddLine(new Point(width - 4, 5), new Point(width - 4, height));

            middleBorderPath.AddLine(new Point(4, height), new Point(4, 5));
            middleBorderPath.AddLine(new Point(5, 4), new Point(width - 6, 4));
            middleBorderPath.AddLine(new Point(width - 5, 5), new Point(width - 5, height));

            innerBorderPath.AddLines(new Point[] { new Point(5, height), new Point(5, 5), new Point(width - 6, 5), new Point(width - 6, height) });

            lightEffectRectangle = new Rectangle(new Point(6, 6), new Size(width - 12, topZoneHeight - 6));

            graphics.DrawPath(outerBorderPen, outerBorderPath);
            graphics.DrawPath(middleBorderPen, middleBorderPath);
            graphics.DrawPath(innerBorderPen, innerBorderPath);

            SolidBrush hoverEffectButton = new SolidBrush(lightColor);
            graphics.FillRectangle(hoverEffectButton, lightEffectRectangle);
        }

        /// <summary>
        /// Paints an pushed effect according the provided position ans style
        /// </summary>
        /// <param name="graphics">Graphics to paint into</param>
        /// <param name="width">Width of the control (for centering purposes)</param>
        /// <param name="height">Height of the control (for centering purposes)</param>
        internal static void PaintPushedEffect(Graphics graphics, int width, int height)
        {
            Pen outerBorderPen = new Pen(new SolidBrush(Color.FromArgb(120, Color.Gainsboro)));
            GraphicsPath outerBorderPath = new GraphicsPath();
            outerBorderPath.AddLine(new Point(3, height), new Point(3, 5));
            outerBorderPath.AddCurve(new Point[] { new Point(3, 5), new Point(5, 3) }, 0.5f);
            outerBorderPath.AddLine(new Point(5, 3), new Point(width - 6, 3));
            outerBorderPath.AddCurve(new Point[] { new Point(width - 6, 3), new Point(width - 4, 5) }, 0.5f);
            outerBorderPath.AddLine(new Point(width - 4, 5), new Point(width - 4, height));

            Pen innerBorderPen = new Pen(new SolidBrush(Color.FromArgb(120, Color.Black)));
            GraphicsPath innerBorderPath = new GraphicsPath();
            innerBorderPath.AddLine(new Point(4, height), new Point(4, 5));
            innerBorderPath.AddLine(new Point(5, 4), new Point(width - 6, 4));
            innerBorderPath.AddLine(new Point(width - 5, 5), new Point(width - 5, height));

            Pen outerBorderButtonPen = new Pen(new SolidBrush(Color.FromArgb(70, Color.Black)));
            GraphicsPath outerButtonBorderPath = new GraphicsPath();
            outerButtonBorderPath.AddLines(new Point[]
            {
                new Point(5, height),
                new Point(5, 5),
                new Point(width - 6, 5),
                new Point(width - 6, height)
            });

            graphics.DrawPath(outerBorderPen, outerBorderPath);
            graphics.DrawPath(innerBorderPen, innerBorderPath);
            graphics.DrawPath(outerBorderButtonPen, outerButtonBorderPath);
        }
    }
}