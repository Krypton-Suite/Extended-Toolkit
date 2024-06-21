using System.Drawing.Text;

namespace Krypton.Toolkit.Suite.Extended.Controls
{
    /// <summary>
    /// An abstraction of <see cref="System.Drawing.Graphics"/>.
    /// </summary>
    /// <remarks>Exists in order to make test assertions on usage of
    /// <see cref="System.Drawing.Graphics"/>.</remarks>
    public interface IGraphics : IDisposable
    {
        /// <summary>
        /// Gets or sets the rendering mode for text associated with the
        /// <see cref="IGraphics"/> object.
        /// </summary>
        TextRenderingHint TextRenderingHint { get; set; }

        /// <summary>
        /// Draws the specified <paramref name="string"/> at the specified
        /// <paramref name="point"/> with the specified
        /// <paramref name="solidBrush"/> and <paramref name="font"/>.
        /// </summary>
        /// <param name="string">The <see cref="string"/> to draw.</param>
        /// <param name="font">A <see cref="Font"/> that determines the
        /// appearance of the <paramref name="string"/>.</param>
        /// <param name="solidBrush">An <see cref="ISolidBrush"/> that
        /// determines the appearance of the <paramref name="string"/>.</param>
        /// <param name="point">A <see cref="PointF"/> that defines the top-left
        /// position of the <paramref name="string"/>.</param>
        void DrawString(string @string,
                        Font font,
                        ISolidBrush solidBrush,
                        PointF point);

        /// <summary>
        /// Fills the interior of the specified <paramref name="rectangle"/>
        /// using the specified <paramref name="solidBrush"/>.
        /// </summary>
        /// <param name="solidBrush">An <see cref="ISolidBrush"/> that
        /// determines the appearance of the
        /// <paramref name="rectangle"/>.</param>
        /// <param name="rectangle">A <see cref="RectangleF"/> describing the
        /// area to be filled.</param>
        void FillRectangle(ISolidBrush solidBrush, RectangleF rectangle);

        /// <summary>
        /// Measures the specified <paramref name="string"/> when drawn with the
        /// specified <paramref name="font"/>.
        /// </summary>
        /// <param name="string">The <see cref="string"/> to measure.</param>
        /// <param name="font">A <see cref="Font"/> that determines the
        /// appearance of the <paramref name="string"/>.</param>
        /// <returns>The measured <see cref="SizeF"/>.</returns>
        /// <exception cref="ArgumentNullException">An argument is
        /// <c>null</c>.</exception>
        SizeF MeasureString(string @string, Font font);
    }
}