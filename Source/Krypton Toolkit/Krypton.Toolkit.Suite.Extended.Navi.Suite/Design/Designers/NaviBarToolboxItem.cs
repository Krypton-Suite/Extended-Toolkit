#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
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