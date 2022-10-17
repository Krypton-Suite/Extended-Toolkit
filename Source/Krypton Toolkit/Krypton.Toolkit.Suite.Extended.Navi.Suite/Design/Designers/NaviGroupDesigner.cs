#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Navi.Suite
{
    public class NaviGroupDesigner : ParentControlDesigner
    {
        #region Fields

        private IComponentChangeService changeService = null;
        private ISelectionService selectionService = null;
        private NaviGroup m_designingControl;

        #endregion

        #region Static

        public static int LoWord(int dwValue)
        {
            return dwValue & 0xFFFF;
        }

        public static int HiWord(int dwValue)
        {
            return (dwValue >> 16) & 0xFFFF;
        }

        #endregion

        #region Constructor
        #endregion

        #region Properties
        #endregion

        #region Methods

        private void CheckHeaderClick(Point location)
        {
            if (m_designingControl != null)
            {
                if (m_designingControl.HeaderRegion.IsVisible(location))
                {
                    if (selectionService.PrimarySelection == m_designingControl)
                        SetControlProperty("Expanded", !m_designingControl.Expanded);
                }
            }
        }

        private void InitializeServices()
        {
            if (changeService == null)
            {
                this.changeService =
                   GetService(typeof(IComponentChangeService)) as IComponentChangeService;
            }
            if (selectionService == null)
            {
                this.selectionService =
                   GetService(typeof(ISelectionService)) as ISelectionService;
            }
        }

        private void SetControlProperty(string propName, object value)
        {
            PropertyDescriptor propDesc =
               TypeDescriptor.GetProperties(m_designingControl)[propName];

            if (changeService != null)
            {
                // Raise event that we are about to change
                this.changeService.OnComponentChanging(m_designingControl, propDesc);
            }

            // Change to desired value
            object oldValue = propDesc.GetValue(m_designingControl);
            propDesc.SetValue(m_designingControl, value);

            if (changeService != null)
            {
                // Raise event that the component has been changed
                this.changeService.OnComponentChanged(m_designingControl, propDesc, oldValue, value);
            }
        }
        #endregion

        #region Overrides

        protected override void WndProc(ref Message m)
        {
            if (m.HWnd == Control.Handle)
            {
                switch (m.Msg)
                {
                    case 0x202: //WM_LBUTTONUP
                        CheckHeaderClick(new Point(LoWord((int)m.LParam), HiWord((int)m.LParam)));
                        break;
                    default:
                        break;
                }
            }
            base.WndProc(ref m);
        }

        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            if (component is NaviGroup)
            {
                m_designingControl = (NaviGroup)component;
            }
            InitializeServices();
        }
        #endregion

        #region Event Handling

        #endregion
    }
}