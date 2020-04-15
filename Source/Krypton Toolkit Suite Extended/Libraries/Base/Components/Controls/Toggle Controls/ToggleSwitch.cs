using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Krypton.Toolkit.Extended.Base
{
    [DefaultValue("Checked"), DefaultEvent("CheckedChanged"), ToolboxBitmap(typeof(CheckBox))]
    public class ToggleSwitch : Control
    {
        #region Event
        public delegate void CheckedChangedEventHandler(object sender, EventArgs e);

        [Description("Raised when the ToggleSwitch has changed state")]
        public event CheckedChangedEventHandler CheckedChanged;

        protected override void OnCheckChanged(object sender, EventArgs e) => CheckedChanged?.Invoke(sender, e);

        public delegate void RendererChangedEventHandler(object sender, RendererChangedEventArgs e);

        [Description("Raised when the ToggleSwitch renderer is changed")]
        public event RendererChangedEventHandler RendererChanged;

        protected override void OnRendererChanged(object sender, RendererChangedEventArgs e) => RendererChanged?.Invoke(sender, e);
        #endregion

        #region Enumerations
        public enum ToggleSwitchStyle
        {
            ANDROID,
            BRUSHEDMETAL,
            CARBON,
            FANCY,
            IOS,
            IPHONE,
            OSX,
            METRO,
            MODERN,
            PLAINANDSIMPLE,
            KRYPTONBRUSHMETAL,
            KRYPTONSTANDARD
        }            

        public enum ToggleSwitchAlignment
        {
            NEAR,
            CENTRE,
            FAR
        }

        public enum ToggleSwitchButtonAlignment
        {
            LEFT,
            CENTRE,
            RIGHT
        }
        #endregion
    }
}