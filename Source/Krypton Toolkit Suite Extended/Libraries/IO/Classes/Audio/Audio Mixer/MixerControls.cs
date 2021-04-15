#region BSD License
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
    public class MixerControls : CollectionBase
    {
        #region Constructors
        public MixerControls()
        {
        }
        #endregion

        #region Properties
        #endregion

        #region Methods
        public MixerControl GetControlByType(MIXERCONTROL_CONTROLTYPE type)
        {
            foreach (MixerControl mixerControl in this.InnerList)
                if (mixerControl.Type == type)
                    return mixerControl;

            return null;
        }

        public MixerControl GetControlByIndex(int index)
        {
            return this[index];
        }

        public void Add(MixerControl mixerControl)
        {
            this.InnerList.Add(mixerControl);
        }

        public void Remove(MixerControl mixerControl)
        {
            if (this.InnerList.Contains(mixerControl))
            {
                this.InnerList.Remove(mixerControl);
                return;
            }

            MixerControl mixerControlToRemove = null;
            foreach (MixerControl mixerControlLoop in this.InnerList)
            {
                if (mixerControlLoop.Id == mixerControl.Id &&
                    mixerControlLoop.Name == mixerControl.Name &&
                    mixerControlLoop.Line == mixerControl.Line)
                {
                    mixerControlToRemove = mixerControlLoop;
                    break;
                }
            }

            if (mixerControlToRemove != null)
                this.InnerList.Remove(mixerControlToRemove);
        }
        #endregion

        #region Indexers
        public MixerControl this[int index]
        {
            get
            {
                if (index >= this.InnerList.Count || index < 0)
                    return null;

                return (MixerControl)this.InnerList[index];
            }
        }
        #endregion
    }
}