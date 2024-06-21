namespace Krypton.Toolkit.Suite.Extended.Controls
{
    /// <summary>
    /// An abstraction of <see cref="System.Drawing.Graphics"/>.
    /// </summary>
    /// <remarks>Exists in order to make test assertions on usage of
    /// <see cref="System.Drawing.Graphics"/>.</remarks>
    public class GraphicsExtended : IGraphics
    {
        /// <summary>
        /// Converts the specified <paramref name="graphics"/> object to a
        /// <see cref="System.Drawing.Graphics"/> object.
        /// </summary>
        /// <param name="graphics">A <see cref="GraphicsExtended"/> object.</param>
        /// <returns>The <see cref="System.Drawing.Graphics"/> object of which
        /// <paramref name="graphics"/> is an abstraction.</returns>
        public static explicit operator System.Drawing.Graphics(GraphicsExtended graphics)
        {
            return graphics.native;
        }

        private readonly System.Drawing.Graphics native;

        /// <summary>
        /// Instantiates a new <see cref="GraphicsExtended"/> object with the specified
        /// <paramref name="control"/>.
        /// </summary>
        /// <param name="control">The desired value of
        /// <see cref="Control"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="control"/>
        /// is <c>null</c>.</exception>
        public GraphicsExtended(Control control)
        {
            if (ReferenceEquals(control, null))
            {
                throw new ArgumentNullException(nameof(control));
            }

            Control = control;
            native = Control.CreateGraphics();
        }

        /// <summary>
        /// Finalizes a <see cref="GraphicsExtended"/> object.
        /// </summary>
        ~GraphicsExtended()
        {
            Dispose(false);
            System.Diagnostics.Debug.Fail($"{GetType().FullName} was not disposed!");
        }

        /// <summary>
        /// The <see cref="System.Windows.Forms.Control"/> which the
        /// <see cref="GraphicsExtended"/> object used to create a
        /// <see cref="System.Drawing.Graphics"/> object.
        /// </summary>
        public Control Control { get; }

        /// <summary>
        /// Gets or sets the rendering mode for text associated with the
        /// <see cref="GraphicsExtended"/> object.
        /// </summary>
        public TextRenderingHint TextRenderingHint
        {
            get { return native.TextRenderingHint; }

            set { native.TextRenderingHint = value; }
        }

        /// <summary>
        /// Disposes resources acquired by the <see cref="GraphicsExtended"/> object.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes unmanaged resources acquired by the <see cref="GraphicsExtended"/>
        /// object, optionally disposing managed resources, as well.
        /// </summary>
        /// <param name="disposing">If <c>true</c>, managed resources are
        /// disposed along with unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                native.Dispose();
            }
        }

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
        /// <exception cref="ArgumentNullException">An argument is
        /// <c>null</c>.</exception>
        public void DrawString(string @string,
        Font font,
                               ISolidBrush solidBrush,
                               PointF point)
        {
            native.DrawString(@string, font, solidBrush.Native, point);
        }

        /// <summary>
        /// Fills the interior of the specified <paramref name="rectangle"/>
        /// using the specified <paramref name="solidBrush"/>.
        /// </summary>
        /// <param name="solidBrush">An <see cref="ISolidBrush"/> that
        /// determines the appearance of the
        /// <paramref name="rectangle"/>.</param>
        /// <param name="rectangle">A <see cref="RectangleF"/> describing the
        /// area to be filled.</param>
        /// <exception cref="ArgumentNullException">An argument is
        /// <c>null</c>.</exception>
        public void FillRectangle(ISolidBrush solidBrush, RectangleF rectangle)
        {
            native.FillRectangle(solidBrush.Native, rectangle);
        }

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
        public SizeF MeasureString(string @string, Font font)
        {
            return native.MeasureString(@string, font);
        }
    }
}