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
    /// Represents a Context Menu in the Office 2007 colors
    /// </summary>
    [ToolboxItem(false)]
    public class NaviContextMenu : ContextMenuStrip
    {
        // Fields
        private ToolStripRenderer renderer;
        private ProfessionalColorTable colorTable;

        #region Constructor

        public NaviContextMenu()
           : base()
        {
            Initialize();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Initializes the control for the first time
        /// </summary>
        private void Initialize()
        {
            colorTable = new NaviToolstripColourTable();
            renderer = new NaviToolstripRenderer(colorTable);
            base.Renderer = renderer;
        }

        #endregion
    }
}