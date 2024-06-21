namespace Krypton.Toolkit.Suite.Extended.Controls
{
    /// <summary>
    /// An abstraction of <see cref="System.Drawing.SolidBrush"/>.
    /// </summary>
    /// <remarks>Exists in order to make test assertions on usage of
    /// <see cref="System.Drawing.SolidBrush"/>.</remarks>
    public sealed class SolidBrushExtended : ISolidBrush
    {
        private readonly System.Drawing.SolidBrush native;

        /// <summary>
        /// Instantiates a new <see cref="SolidBrushExtended"/> with the specified
        /// <paramref name="color"/>.
        /// </summary>
        /// <param name="color">The desired value of
        /// <see cref="Color"/>.</param>
        public SolidBrushExtended(Color color)
        {
            native = new System.Drawing.SolidBrush(color);
        }

        /// <summary>
        /// Finalizes the <see cref="SolidBrushExtended"/>.
        /// </summary>
        ~SolidBrushExtended()
        {
            Dispose(false);
            System.Diagnostics.Debug.Fail($"{GetType().FullName} was not disposed!");
        }

        /// <summary>
        /// The <see cref="System.Drawing.Color"/> of the
        /// <see cref="SolidBrushExtended"/>.
        /// </summary>
        public Color Color => native.Color;

        /// <summary>
        /// The <see cref="System.Drawing.SolidBrush"/> of which the
        /// <see cref="SolidBrushExtended"/> is an abstraction.
        /// </summary>
        System.Drawing.SolidBrush ISolidBrush.Native => native;

        /// <summary>
        /// Disposes resources acquired by the <see cref="SolidBrushExtended"/>.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                native.Dispose();
            }
        }
    }
}
