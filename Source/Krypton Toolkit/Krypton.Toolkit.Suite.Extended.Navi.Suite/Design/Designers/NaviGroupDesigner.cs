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
    [SuppressMessage("ReSharper", "RedundantEmptySwitchSection")]
    public class NaviGroupDesigner : ParentControlDesigner
    {
        #region Fields

        private IComponentChangeService? _changeService;
        private ISelectionService? _selectionService;
        private NaviGroup? _mDesigningControl;

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
            if (_mDesigningControl != null)
            {
                if (_mDesigningControl.HeaderRegion.IsVisible(location))
                {
                    if (_selectionService?.PrimarySelection == _mDesigningControl)
                    {
                        SetControlProperty("Expanded", !_mDesigningControl.Expanded);
                    }
                }
            }
        }

        private void InitializeServices()
        {
            if (_changeService == null)
            {
                _changeService =
                   GetService(typeof(IComponentChangeService)) as IComponentChangeService;
            }
            if (_selectionService == null)
            {
                _selectionService =
                   GetService(typeof(ISelectionService)) as ISelectionService;
            }
        }

        private void SetControlProperty(string propName, object value)
        {
            PropertyDescriptor? propDesc =
               TypeDescriptor.GetProperties(_mDesigningControl!)[propName];

            if (_changeService != null)
            {
                // Raise event that we are about to change
                _changeService.OnComponentChanging(_mDesigningControl!, propDesc);
            }

            // Change to desired value
            object? oldValue = propDesc?.GetValue(_mDesigningControl);
            propDesc?.SetValue(_mDesigningControl, value);

            if (_changeService != null)
            {
                // Raise event that the component has been changed
                _changeService.OnComponentChanged(_mDesigningControl!, propDesc, oldValue, value);
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
                _mDesigningControl = (NaviGroup)component;
            }
            InitializeServices();
        }
        #endregion

        #region Event Handling

        #endregion
    }
}