using System.Windows.Interop;

using IWin32Window = System.Windows.Forms.IWin32Window;

namespace Krypton.Toolkit.Suite.Extended.Software.Updater
{
    internal class Wpf32Window : IWin32Window
    {
        public Wpf32Window(Window wpfWindow)
        {
            Handle = new WindowInteropHelper(wpfWindow).EnsureHandle();
        }

        public IntPtr Handle { get; }
    }
}