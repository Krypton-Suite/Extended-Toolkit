#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    /// <summary>
    /// Enables design time mode for the ClientArea of the Band
    /// </summary>
    public class NaviBandDesigner : ParentControlDesigner
    {
        private NaviBand designingComponent;

        public override void Initialize(System.ComponentModel.IComponent component)
        {
            base.Initialize(component);
            if (component is NaviBand)
            {
                designingComponent = (NaviBand)component;

                EnableDesignMode(designingComponent.ClientArea, "ClientArea");
            }
        }
    }
}