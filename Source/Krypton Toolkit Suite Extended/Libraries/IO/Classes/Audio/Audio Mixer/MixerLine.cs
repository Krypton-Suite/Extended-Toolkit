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
using System;
using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.IO
{
    #region Aliases
    #endregion

    [Author("Gustavo Franco")]
    public class MixerLine
    {
        #region Variables Declaration
        private string mName;
        private Channel mChannel;
        private uint mChannels;
        private uint mConnections;
        private uint mCControls;
        private MIXERLINE_COMPONENTTYPE mComponentType;
        private uint mFlag;
        private uint mId;
        private uint mSource;
        private uint mDestination;
        private MixerType mDirection;
        private IntPtr mHMixer;
        private MixerControls mControls = new MixerControls();
        private Mixer mMixer;
        #endregion

        #region Constructors
        public MixerLine()
        {
            mName = "";
            mComponentType = (MIXERLINE_COMPONENTTYPE)(-1);
            mChannel = Channel.Uniform;
            unchecked
            {
                mId = (uint)-1;
            }
        }
        #endregion

        #region Properties
        #region Mixer
        public Mixer Mixer
        {
            get { return mMixer; }
            set { mMixer = value; }
        }
        #endregion

        #region HMixer
        internal unsafe IntPtr HMixer
        {
            get { return mHMixer; }
            set
            {
                MMErrors errorCode = 0;
                MIXERLINECONTROLS mlc = new MIXERLINECONTROLS();
                IntPtr pmc = IntPtr.Zero;

                try
                {
                    mHMixer = value;
                    mControls.Clear();

                    if (mCControls == 0)
                        return;

                    pmc = Marshal.AllocHGlobal((int)(Marshal.SizeOf(typeof(MIXERCONTROL)) * mCControls));
                    mlc.cbStruct = (uint)sizeof(MIXERLINECONTROLS);
                    mlc.dwLineID = mId;
                    mlc.cControls = mCControls;
                    mlc.pamxctrl = pmc;
                    mlc.cbmxctrl = (uint)(Marshal.SizeOf(typeof(MIXERCONTROL)));

                    errorCode = (MMErrors)MixerNative.mixerGetLineControls(mHMixer, ref mlc, MIXER_GETLINECONTROLSFLAG.ALL);
                    if (errorCode != MMErrors.MMSYSERR_NOERROR)
                        throw new MixerException(errorCode, Mixers.GetErrorDescription(FuncName.fnMixerGetLineControls, errorCode));

                    for (int i = 0; i < mlc.cControls; i++)
                    {
                        MIXERCONTROL mc = (MIXERCONTROL)Marshal.PtrToStructure((IntPtr)(((byte*)pmc) + (Marshal.SizeOf(typeof(MIXERCONTROL)) * i)), typeof(MIXERCONTROL));

                        MixerControl mixerControl = new MixerControl();
                        mixerControl.Id = mc.dwControlID;
                        mixerControl.Type = (MIXERCONTROL_CONTROLTYPE)mc.dwControlType;
                        mixerControl.ControlFlag = (MIXERCONTROL_CONTROLFLAG)mc.fdwControl;
                        mixerControl.MultipleItems = mc.cMultipleItems;
                        mixerControl.Name = mc.szName;
                        mixerControl.Minimum = mc.Bounds.dwMinimum;
                        mixerControl.Maximum = mc.Bounds.dwMaximum;
                        mixerControl.Steps = mc.Metrics.cSteps;
                        mixerControl.Line = this;
                        mixerControl.HMixer = mHMixer;

                        mControls.Add(mixerControl);
                    }
                }
                finally
                {
                    if (pmc != IntPtr.Zero)
                        Marshal.FreeHGlobal(pmc);
                }
            }
        }
        #endregion

        #region MixerControls
        public MixerControls Controls
        {
            get { return mControls; }
            set { mControls = value; }
        }
        #endregion

        #region Flag
        internal uint Flag
        {
            get { return mFlag; }
            set { mFlag = value; }
        }
        #endregion

        #region Active
        public bool Active
        {
            get { return ((mFlag & (uint)MIXERLINE_LINEFLAG.ACTIVE) > 0); }
        }
        #endregion

        #region Connected
        public bool Connected
        {
            get { return ((mFlag & (uint)MIXERLINE_LINEFLAG.DISCONNECTED) == 0); }
        }
        #endregion

        #region IsSource
        public bool IsSource
        {
            get { return ((mFlag & (uint)MIXERLINE_LINEFLAG.SOURCE) > 0); }
        }
        #endregion

        #region Channels
        public uint Channels
        {
            get { return mChannels; }
            set { mChannels = value; }
        }
        #endregion

        #region CControls
        internal uint CControls
        {
            get { return mCControls; }
            set { mCControls = value; }
        }
        #endregion

        #region Connections
        public uint Connections
        {
            get { return mConnections; }
            set { mConnections = value; }
        }
        #endregion

        #region Direction
        public MixerType Direction
        {
            get { return mDirection; }
            set { mDirection = value; }
        }
        #endregion

        #region Name
        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }
        #endregion

        #region Soruce
        public uint Source
        {
            get { return mSource; }
            set { mSource = value; }
        }
        #endregion

        #region Destination
        public uint Destination
        {
            get { return mDestination; }
            set { mDestination = value; }
        }
        #endregion

        #region ComponentType
        public MIXERLINE_COMPONENTTYPE ComponentType
        {
            get { return mComponentType; }
            set { mComponentType = value; }
        }
        #endregion

        #region Id
        public uint Id
        {
            get { return mId; }
            set { mId = value; }
        }
        #endregion

        #region Children Properties
        #region Channel
        public Channel Channel
        {
            get { return mChannel; }
            set { mChannel = value; }
        }
        #endregion

        #region Volume
        public int Volume
        {
            get
            {
                MixerControl mixerControl = Controls.GetControlByType(MIXERCONTROL_CONTROLTYPE.VOLUME);
                if (mixerControl == null)
                    return -1;
                else
                    return (int)mixerControl.Volume;
            }
            set
            {
                MixerControl mixerControl = Controls.GetControlByType(MIXERCONTROL_CONTROLTYPE.VOLUME);
                if (mixerControl != null)
                    mixerControl.Volume = value;
            }
        }

        public int VolumeMax
        {
            get
            {
                MixerControl mixerControl = Controls.GetControlByType(MIXERCONTROL_CONTROLTYPE.VOLUME);
                if (mixerControl == null)
                    return -1;
                else
                    return (int)mixerControl.Maximum;
            }
        }

        public int VolumeMin
        {
            get
            {
                MixerControl mixerControl = Controls.GetControlByType(MIXERCONTROL_CONTROLTYPE.VOLUME);
                if (mixerControl == null)
                    return -1;
                else
                    return (int)mixerControl.Minimum;
            }
        }

        public bool ContainsVolume
        {
            get
            {
                MixerControl mixerControl = Controls.GetControlByType(MIXERCONTROL_CONTROLTYPE.VOLUME);
                if (mixerControl == null)
                    return false;
                return true;
            }
        }
        #endregion

        #region Mute
        public bool Mute
        {
            get
            {
                MixerControl mixerControl = Controls.GetControlByType(MIXERCONTROL_CONTROLTYPE.MUTE);
                if (mixerControl == null)
                    return false;
                else
                    return mixerControl.Mute;
            }
            set
            {
                MixerControl mixerControl = Controls.GetControlByType(MIXERCONTROL_CONTROLTYPE.MUTE);
                if (mixerControl != null)
                    mixerControl.Mute = value;
            }
        }

        public bool ContainsMute
        {
            get
            {
                MixerControl mixerControl = Controls.GetControlByType(MIXERCONTROL_CONTROLTYPE.MUTE);
                if (mixerControl == null)
                    return false;
                return true;
            }
        }
        #endregion

        #region Selected
        public bool Selected
        {
            get
            {
                if (this.Direction == MixerType.Playback)
                    return false;

                MixerLine lineMux = this.Mixer.Lines.GetMixerFirstLineByComponentType(MIXERLINE_COMPONENTTYPE.DST_WAVEIN);
                if (lineMux == null || lineMux.IsSource)
                    return false;

                MixerControls controls = lineMux.Controls;
                MixerControl muxControl = controls.GetControlByType(MIXERCONTROL_CONTROLTYPE.MUX);
                if (muxControl == null)
                    return false;

                if (muxControl.Selected == Id)
                    return true;

                return false;
            }
            set
            {
                if (this.Direction == MixerType.Playback)
                    return;

                MixerLine lineMux = this.Mixer.Lines.GetMixerFirstLineByComponentType(MIXERLINE_COMPONENTTYPE.DST_WAVEIN);
                if (lineMux == null || lineMux.IsSource)
                    return;

                MixerControls controls = lineMux.Controls;
                MixerControl muxControl = controls.GetControlByType(MIXERCONTROL_CONTROLTYPE.MUX);
                if (muxControl == null)
                    return;

                if (value)
                    muxControl.Selected = Id;
                else
                    unchecked { muxControl.Selected = (uint)-1; }
            }
        }

        public bool ContainsSelected
        {
            get
            {
                if (this.Direction == MixerType.Playback)
                    return false;

                MixerLine lineMux = this.Mixer.Lines.GetMixerFirstLineByComponentType(MIXERLINE_COMPONENTTYPE.DST_WAVEIN);
                if (lineMux == null || lineMux.IsSource)
                    return false;

                MixerControls controls = lineMux.Controls;
                if (controls.GetControlByType(MIXERCONTROL_CONTROLTYPE.MUX) != null)
                    return true;
                return false;
            }
        }
        #endregion

        #endregion
        #endregion

        #region Overrides
        public override string ToString()
        {
            return mName;
        }
        #endregion
    }
}