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
    public class MixerLines : CollectionBase
    {
        #region Constructors
        public MixerLines()
        {
        }
        #endregion

        #region Methods
        public bool Contains(MixerLine line)
        {
            foreach (MixerLine mixerLine in this.InnerList)
                if (mixerLine == line)
                    return true;

            return false;
        }

        public MixerLine GetMixerLineByIndex(int index)
        {
            return this[index];
        }

        public MixerLine GetMixerFirstLineByComponentType(MIXERLINE_COMPONENTTYPE componentType)
        {
            foreach (MixerLine mixerLine in this.InnerList)
                if (mixerLine.ComponentType == componentType)
                    return mixerLine;

            return null;
        }

        public MixerLine GetMixerLineByControlId(uint controlId)
        {
            foreach (MixerLine mixerLine in this.InnerList)
                foreach (MixerControl mixerControl in mixerLine.Controls)
                    if (mixerControl.Id == controlId)
                        return mixerLine;

            return null;
        }

        public MixerLine GetMixerLineByLineId(uint lineId)
        {
            foreach (MixerLine mixerLine in this.InnerList)
                if (mixerLine.Id == lineId)
                    return mixerLine;

            return null;
        }

        public MixerLine GetMixerLineByLineSource(uint lineSource)
        {
            foreach (MixerLine mixerLine in this.InnerList)
                if (mixerLine.Source == lineSource)
                    return mixerLine;

            return null;
        }

        public MixerLine GetMixerFirstLineByLineDestination(uint lineDestination)
        {
            foreach (MixerLine mixerLine in this.InnerList)
                if (mixerLine.Destination == lineDestination)
                    return mixerLine;

            return null;
        }

        public void Add(MixerLine line)
        {
            this.InnerList.Add(line);
        }

        public void Remove(MixerLine mixerLine)
        {
            if (this.InnerList.Contains(mixerLine))
            {
                this.InnerList.Remove(mixerLine);
                return;
            }

            MixerLine mixerLineToRemove = null;
            foreach (MixerLine mixerLineLoop in this.InnerList)
            {
                if (mixerLineLoop.ComponentType == mixerLine.ComponentType &&
                    mixerLineLoop.Destination == mixerLine.Destination &&
                    mixerLineLoop.Id == mixerLine.Id &&
                    mixerLineLoop.Source == mixerLine.Source &&
                    mixerLineLoop.Name == mixerLine.Name)
                {
                    mixerLineToRemove = mixerLineLoop;
                    break;
                }
            }

            if (mixerLineToRemove != null)
                this.InnerList.Remove(mixerLineToRemove);
        }
        #endregion

        #region Indexers
        public MixerLine this[int index]
        {
            get
            {
                if (index >= this.InnerList.Count || index < 0)
                    return null;

                return (MixerLine)this.InnerList[index];
            }
        }
        #endregion
    }
}