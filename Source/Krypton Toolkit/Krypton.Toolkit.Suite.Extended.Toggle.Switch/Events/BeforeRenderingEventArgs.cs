#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Toggle.Switch
{
    public class BeforeRenderingEventArgs
    {
        public ToggleSwitchRendererBase Renderer { get; set; }

        public BeforeRenderingEventArgs(ToggleSwitchRendererBase renderer) => Renderer = renderer;
    }
}