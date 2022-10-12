namespace Krypton.Toolkit.Suite.Extended.Forms
{
    /// <summary>
    /// Exposes interface for visual form to cooperate with a view for composition.
    /// </summary>
    public interface IKryptonComposition
    {
        /// <summary>
        /// Gets the pixel height of the composition extension into the client area.
        /// </summary>
        int CompHeight { get; }

        /// <summary>
        /// Should painting be performed for the selection glyph.
        /// </summary>
        bool CompVisible { get; set; }

        /// <summary>
        /// Gets and sets the form that owns the composition.
        /// </summary>
        VirtualForm CompOwnerForm { get; set; }

        /// <summary>
        /// Request a repaint and optional layout.
        /// </summary>
        /// <param name="needLayout">Is a layout required.</param>
        void CompNeedPaint(bool needLayout);

        /// <summary>
        /// Gets the handle of the composition element control.
        /// </summary>
        IntPtr CompHandle { get; }
    }
}