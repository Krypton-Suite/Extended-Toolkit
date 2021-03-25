﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Core;
using System.Collections;

namespace Krypton.Toolkit.Suite.Extended.IO
{
    [Author("Gustavo Franco")]
    public class MixerDetails : CollectionBase
    {
        #region Constructors & Destructor
        public MixerDetails()
        {
        }

        ~MixerDetails()
        {
            this.InnerList.Clear();
        }
        #endregion

        #region Methods
        public bool Contains(MixerDetail detail)
        {
            foreach (MixerDetail mixerDetail in this.InnerList)
                if (mixerDetail == detail)
                    return true;

            return false;
        }

        public MixerDetail GetMixerByDeviceId(int deviceId)
        {
            foreach (MixerDetail mixerDetail in this.InnerList)
                if (mixerDetail.DeviceId == deviceId)
                    return mixerDetail;

            return null;
        }

        public MixerDetail GetMixerByIndex(int index)
        {
            return this[index];
        }

        public MixerDetail GetMixerByName(string name)
        {
            foreach (MixerDetail mixerDetail in this.InnerList)
                if (mixerDetail.MixerName == name)
                    return mixerDetail;

            return null;
        }

        public void Add(MixerDetail mixer)
        {
            this.InnerList.Add(mixer);
        }

        public void Remove(MixerDetail mixer)
        {
            if (this.InnerList.Contains(mixer))
            {
                this.InnerList.Remove(mixer);
                return;
            }

            MixerDetail mixerDetailToRemove = null;
            foreach (MixerDetail mixerDetail in this.InnerList)
            {
                if (mixerDetail.DeviceId == mixer.DeviceId &&
                    mixerDetail.MixerName == mixer.MixerName)
                {
                    mixerDetailToRemove = mixerDetail;
                    break;
                }
            }

            if (mixerDetailToRemove != null)
                this.InnerList.Remove(mixerDetailToRemove);
        }
        #endregion

        #region Indexers
        public MixerDetail this[int index]
        {
            get
            {
                if (index >= this.InnerList.Count || index < 0)
                    return null;

                return (MixerDetail)this.InnerList[index];
            }
        }
        #endregion
    }
}