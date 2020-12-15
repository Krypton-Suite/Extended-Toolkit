#region License
/*
  THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
  PURPOSE. IT CAN BE DISTRIBUTED FREE OF CHARGE AS LONG AS THIS HEADER 
  REMAINS UNCHANGED.

  Email:  gustavo_franco @hotmail.com

  Copyright (C) 2005 Franco, Gustavo
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