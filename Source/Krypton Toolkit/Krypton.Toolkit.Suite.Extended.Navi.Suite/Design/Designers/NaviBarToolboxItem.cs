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
    /// Represents a NaviBar toolbox item
    /// </summary>
    [
    PermissionSet(SecurityAction.Demand, Name = "FullTrust"),
    Serializable,
    ]
    public class NaviBarToolboxItem : ToolboxItem
    {
        /// <summary>
        /// Initializes a new instance of the NaviBarToolboxItem class 
        /// </summary>
        public NaviBarToolboxItem()
           : base(typeof(NaviBar))
        {
        }

        /// <summary>
        /// Initializes a new instance of the NaviBarToolboxItem class 
        /// </summary>
        public NaviBarToolboxItem(SerializationInfo info, StreamingContext context)
        {
            Deserialize(info, context);
        }

        /// <summary>
        /// Creates a new instance of the NaviBar component with design time support
        /// </summary>
        /// <param name="host">The controls host</param>
        /// <returns>The newly created component</returns>
        protected override IComponent[] CreateComponentsCore(IDesignerHost host)
        {
            // Create the control
            NaviBar naviBarCtrl = (NaviBar)host.CreateComponent(typeof(NaviBar));
            NaviBand naviBandCtrl = (NaviBand)host.CreateComponent(typeof(NaviBand));

            // Add a new button
            naviBarCtrl.Controls.Add(naviBandCtrl);

            return new IComponent[] { naviBarCtrl };
        }
    }
}