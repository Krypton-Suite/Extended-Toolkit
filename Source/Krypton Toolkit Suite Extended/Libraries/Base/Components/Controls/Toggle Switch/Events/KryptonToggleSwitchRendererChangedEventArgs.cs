namespace Krypton.Toolkit.Suite.Extended.Base
{
    public class KryptonToggleSwitchRendererChangedEventArgs
    {
        public KryptonToggleSwitchRendererBase Renderer { get; set; }

        public KryptonToggleSwitchRendererChangedEventArgs(KryptonToggleSwitchRendererBase renderer)
        {
            Renderer = renderer;
        }
    }
}