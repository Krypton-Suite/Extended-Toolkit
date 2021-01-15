#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Core;

namespace Krypton.Toolkit.Suite.Extended.IO
{
    [Author("Gustavo Franco")]
    public class MixerDetail
    {
        #region Variables Declaration
        private string mName;
        private int mDeviceId;
        private bool mSupportWaveIn;
        private bool mSupportWaveOut;
        #endregion

        #region Constructors
        public MixerDetail()
        {
            mName = "";
            mDeviceId = -1;
            mSupportWaveIn = false;
            mSupportWaveOut = false;
        }
        #endregion

        #region Properties
        public string MixerName
        {
            get { return mName; }
            set { mName = value; }
        }

        public int DeviceId
        {
            get { return mDeviceId; }
            set { mDeviceId = value; }
        }

        public bool SupportWaveIn
        {
            get { return mSupportWaveIn; }
            set { mSupportWaveIn = value; }
        }

        public bool SupportWaveOut
        {
            get { return mSupportWaveOut; }
            set { mSupportWaveOut = value; }
        }
        #endregion

        #region Overrides
        public override string ToString()
        {
            //return mName + ":" + mDeviceId;
            return mName;
        }
        #endregion
    }
}