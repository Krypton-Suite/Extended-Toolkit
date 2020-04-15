using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krypton.Toolkit.Extended.Base
{
    public class RendererChangedEventArgs : EventArgs
    {
        #region Properties
        public ToggleSwitchRendererBase Render { get; set; } 
        #endregion

        #region Constructor
        public RendererChangedEventArgs(ToggleSwitchRendererBase render) => Render = render;
        #endregion
    }
}