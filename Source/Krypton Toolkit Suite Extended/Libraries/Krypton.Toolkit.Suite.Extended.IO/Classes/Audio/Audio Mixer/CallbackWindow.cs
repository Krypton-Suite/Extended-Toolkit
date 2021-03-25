#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Core;
using System;
using System.Security.Permissions;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.IO
{
    [Author("Gustavo Franco")]
    public class CallbackWindow : NativeWindow, IDisposable
    {
        #region Constants
        private const int WS_CHILD = 0x40000000, WS_VISIBLE = 0x10000000, WM_ACTIVATEAPP = 0x001C;
        #endregion

        #region Variables
        private CallbackWindowControlChangeHandler _mPtrMixerControlChange;

        private CallbackWindowLineChangeHandler _mPtrMixerLineChange;
        #endregion

        #region Constructor
        internal CallbackWindow(CallbackWindowControlChangeHandler ptrMixerControlChange, CallbackWindowLineChangeHandler ptrMixerLineChange)
        {
            CreateParams cp = new CreateParams();

            _mPtrMixerControlChange = ptrMixerControlChange;

            _mPtrMixerLineChange = ptrMixerLineChange;

            CreateHandle(cp);
        }
        #endregion

        #region Override
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case MixerNative.MM_MIXM_LINE_CHANGE:
                    _mPtrMixerLineChange(m.WParam, (uint)m.LParam);
                    break;
                case MixerNative.MM_MIXM_CONTROL_CHANGE:
                    _mPtrMixerControlChange(m.WParam, (uint)m.LParam);
                    break;
                default:
                    break;
            }

            base.WndProc(ref m);
        }
        #endregion

        #region IDisposable Members
        public void Dispose()
        {
            if (Handle != IntPtr.Zero)
            {
                DestroyHandle();
            }
        }
        #endregion
    }
}