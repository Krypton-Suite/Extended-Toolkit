namespace Krypton.Toolkit.Suite.Extended.Toggle.Switch
{
    public class BeforeRenderingEventArgs
    {
        public ToggleSwitchRendererBase Renderer { get; set; }

        public BeforeRenderingEventArgs(ToggleSwitchRendererBase renderer) => Renderer = renderer;
    }
}