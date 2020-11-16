#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Core;
using System;
using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.IO
{
    [Author("Gustavo Franco")]
    public class MixerControl
    {
        #region Variables Declaration
        private string mName;
        private MixerLine mLine;
        private uint mControlId;
        private MIXERCONTROL_CONTROLTYPE mControlType;
        private MIXERCONTROL_CONTROLFLAG mControlFlag;
        private uint mMultipleItems;
        private uint mMinimum;
        private uint mMaximum;
        private uint mSteps;
        private IntPtr mHMixer;
        #endregion

        #region Constructors
        public MixerControl()
        {
        }
        #endregion

        #region Properties
        #region Line
        public MixerLine Line
        {
            get { return mLine; }
            set { mLine = value; }
        }
        #endregion

        #region Name
        public string Name
        {
            get { return mName; }
            set { mName = value; }
        }
        #endregion

        #region Id
        public uint Id
        {
            get { return mControlId; }
            set { mControlId = value; }
        }
        #endregion

        #region Type
        public MIXERCONTROL_CONTROLTYPE Type
        {
            get { return mControlType; }
            set { mControlType = value; }
        }
        #endregion

        #region ControlFlag
        public MIXERCONTROL_CONTROLFLAG ControlFlag
        {
            get { return mControlFlag; }
            set { mControlFlag = value; }
        }
        #endregion

        #region MultipleItems
        public uint MultipleItems
        {
            get { return mMultipleItems; }
            set { mMultipleItems = value; }
        }
        #endregion

        #region Minimum
        public uint Minimum
        {
            get { return mMinimum; }
            set { mMinimum = value; }
        }
        #endregion

        #region Maximum
        public uint Maximum
        {
            get { return mMaximum; }
            set { mMaximum = value; }
        }
        #endregion

        #region Steps
        public uint Steps
        {
            get { return mSteps; }
            set { mSteps = value; }
        }
        #endregion

        #region HMixer
        internal unsafe IntPtr HMixer
        {
            get { return mHMixer; }
            set { mHMixer = value; }
        }
        #endregion

        #region Signed Value
        public unsafe int ValueAsSigned
        {
            get
            {
                MMErrors errorCode = 0;
                IntPtr pUnsigned = IntPtr.Zero;

                try
                {
                    uint cChannels = mLine.Channels;
                    if ((((uint)MIXERCONTROL_CONTROLFLAG.UNIFORM) & (uint)mControlFlag) != 0)
                        cChannels = 1;

                    pUnsigned = Marshal.AllocHGlobal((int)(cChannels * sizeof(MIXERCONTROLDETAILS_SIGNED)));

                    MIXERCONTROLDETAILS mxcd = new MIXERCONTROLDETAILS();
                    mxcd.cbStruct = (uint)sizeof(MIXERCONTROLDETAILS);
                    mxcd.dwControlID = Id;
                    mxcd.cChannels = cChannels;
                    mxcd.hwndOwner = IntPtr.Zero;
                    mxcd.cbDetails = (uint)sizeof(MIXERCONTROLDETAILS_SIGNED);
                    mxcd.paDetails = pUnsigned;

                    errorCode = (MMErrors)MixerNative.mixerGetControlDetails(mHMixer, ref mxcd, MIXER_SETCONTROLDETAILSFLAG.VALUE);
                    if (errorCode != MMErrors.MMSYSERR_NOERROR)
                        throw new MixerException(errorCode, Mixers.GetErrorDescription(FuncName.fnMixerGetControlDetails, errorCode));

                    MIXERCONTROLDETAILS_SIGNED mixerControlDetail;
                    if (mLine.Channel == Channel.Uniform)
                        mixerControlDetail = (MIXERCONTROLDETAILS_SIGNED)Marshal.PtrToStructure(pUnsigned, typeof(MIXERCONTROLDETAILS_SIGNED));
                    else
                    {
                        if (((int)mLine.Channel) > cChannels)
                            return -1;
                        mixerControlDetail = (MIXERCONTROLDETAILS_SIGNED)Marshal.PtrToStructure((IntPtr)((int)pUnsigned + (sizeof(MIXERCONTROLDETAILS_SIGNED) * ((int)mLine.Channel - 1))), typeof(MIXERCONTROLDETAILS_SIGNED));
                    }

                    //mLine.mVolumeMin = mxcd.cbStruct->
                    return (int)mixerControlDetail.value;
                }
                finally
                {
                    if (pUnsigned != IntPtr.Zero)
                        Marshal.FreeHGlobal(pUnsigned);
                }
            }
            set
            {
                MMErrors errorCode = 0;
                IntPtr pUnsigned = IntPtr.Zero;

                try
                {

                    uint cChannels = mLine.Channels;
                    if ((((uint)MIXERCONTROL_CONTROLFLAG.UNIFORM) & (uint)mControlFlag) != 0)
                        cChannels = 1;

                    pUnsigned = Marshal.AllocHGlobal((int)(cChannels * sizeof(MIXERCONTROLDETAILS_SIGNED)));

                    MIXERCONTROLDETAILS mxcd = new MIXERCONTROLDETAILS();
                    mxcd.cbStruct = (uint)sizeof(MIXERCONTROLDETAILS);
                    mxcd.dwControlID = Id;
                    mxcd.cChannels = cChannels;
                    mxcd.hwndOwner = IntPtr.Zero;
                    mxcd.cbDetails = (uint)sizeof(MIXERCONTROLDETAILS_SIGNED);
                    mxcd.paDetails = pUnsigned;

                    errorCode = (MMErrors)MixerNative.mixerGetControlDetails(mHMixer, ref mxcd, MIXER_SETCONTROLDETAILSFLAG.VALUE);
                    if (errorCode != MMErrors.MMSYSERR_NOERROR)
                        throw new MixerException(errorCode, Mixers.GetErrorDescription(FuncName.fnMixerGetControlDetails, errorCode));

                    MIXERCONTROLDETAILS_SIGNED mixerControlDetail = (MIXERCONTROLDETAILS_SIGNED)Marshal.PtrToStructure(pUnsigned, typeof(MIXERCONTROLDETAILS_SIGNED));

                    // Set the volume to the middle  (for both channels as needed) 
                    for (int i = 0; i < cChannels; i++)
                    {
                        if (mLine.Channel == Channel.Uniform || ((int)mLine.Channel - 1) == i)
                        {
                            uint* vol = ((uint*)pUnsigned) + i;
                            *(vol) = (uint)value;
                        }
                    }

                    errorCode = (MMErrors)MixerNative.mixerSetControlDetails(mHMixer, ref mxcd, MIXER_SETCONTROLDETAILSFLAG.VALUE);
                    if (errorCode != MMErrors.MMSYSERR_NOERROR)
                        throw new MixerException(errorCode, Mixers.GetErrorDescription(FuncName.fnMixerSetControlDetails, errorCode));
                }
                finally
                {
                    if (pUnsigned != IntPtr.Zero)
                        Marshal.FreeHGlobal(pUnsigned);
                }
            }
        }
        #endregion

        #region Unsigned Value
        public unsafe int ValueAsUnsigned
        {
            get
            {
                MMErrors errorCode = 0;
                IntPtr pUnsigned = IntPtr.Zero;

                try
                {
                    uint cChannels = mLine.Channels;
                    if ((((uint)MIXERCONTROL_CONTROLFLAG.UNIFORM) & (uint)mControlFlag) != 0)
                        cChannels = 1;

                    pUnsigned = Marshal.AllocHGlobal((int)(cChannels * sizeof(MIXERCONTROLDETAILS_UNSIGNED)));

                    MIXERCONTROLDETAILS mxcd = new MIXERCONTROLDETAILS();
                    mxcd.cbStruct = (uint)sizeof(MIXERCONTROLDETAILS);
                    mxcd.dwControlID = Id;
                    mxcd.cChannels = cChannels;
                    mxcd.hwndOwner = IntPtr.Zero;
                    mxcd.cbDetails = (uint)sizeof(MIXERCONTROLDETAILS_UNSIGNED);
                    mxcd.paDetails = pUnsigned;

                    errorCode = (MMErrors)MixerNative.mixerGetControlDetails(mHMixer, ref mxcd, MIXER_SETCONTROLDETAILSFLAG.VALUE);
                    if (errorCode != MMErrors.MMSYSERR_NOERROR)
                        throw new MixerException(errorCode, Mixers.GetErrorDescription(FuncName.fnMixerGetControlDetails, errorCode));

                    MIXERCONTROLDETAILS_UNSIGNED mixerControlDetail;
                    if (mLine.Channel == Channel.Uniform)
                        mixerControlDetail = (MIXERCONTROLDETAILS_UNSIGNED)Marshal.PtrToStructure(pUnsigned, typeof(MIXERCONTROLDETAILS_UNSIGNED));
                    else
                    {
                        if (((int)mLine.Channel) > cChannels)
                            return -1;
                        mixerControlDetail = (MIXERCONTROLDETAILS_UNSIGNED)Marshal.PtrToStructure((IntPtr)((int)pUnsigned + (sizeof(MIXERCONTROLDETAILS_UNSIGNED) * ((int)mLine.Channel - 1))), typeof(MIXERCONTROLDETAILS_UNSIGNED));
                    }

                    //mLine.mVolumeMin = mxcd.cbStruct->
                    return (int)mixerControlDetail.dwValue;
                }
                finally
                {
                    if (pUnsigned != IntPtr.Zero)
                        Marshal.FreeHGlobal(pUnsigned);
                }
            }
            set
            {
                MMErrors errorCode = 0;
                IntPtr pUnsigned = IntPtr.Zero;

                try
                {

                    uint cChannels = mLine.Channels;
                    if ((((uint)MIXERCONTROL_CONTROLFLAG.UNIFORM) & (uint)mControlFlag) != 0)
                        cChannels = 1;

                    pUnsigned = Marshal.AllocHGlobal((int)(cChannels * sizeof(MIXERCONTROLDETAILS_UNSIGNED)));

                    MIXERCONTROLDETAILS mxcd = new MIXERCONTROLDETAILS();
                    mxcd.cbStruct = (uint)sizeof(MIXERCONTROLDETAILS);
                    mxcd.dwControlID = Id;
                    mxcd.cChannels = cChannels;
                    mxcd.hwndOwner = IntPtr.Zero;
                    mxcd.cbDetails = (uint)sizeof(MIXERCONTROLDETAILS_UNSIGNED);
                    mxcd.paDetails = pUnsigned;

                    errorCode = (MMErrors)MixerNative.mixerGetControlDetails(mHMixer, ref mxcd, MIXER_SETCONTROLDETAILSFLAG.VALUE);
                    if (errorCode != MMErrors.MMSYSERR_NOERROR)
                        throw new MixerException(errorCode, Mixers.GetErrorDescription(FuncName.fnMixerGetControlDetails, errorCode));

                    MIXERCONTROLDETAILS_UNSIGNED mixerControlDetail = (MIXERCONTROLDETAILS_UNSIGNED)Marshal.PtrToStructure(pUnsigned, typeof(MIXERCONTROLDETAILS_UNSIGNED));

                    // Set the volume to the middle  (for both channels as needed) 
                    for (int i = 0; i < cChannels; i++)
                    {
                        if (mLine.Channel == Channel.Uniform || ((int)mLine.Channel - 1) == i)
                        {
                            uint* vol = ((uint*)pUnsigned) + i;
                            *(vol) = (uint)value;
                        }
                    }

                    errorCode = (MMErrors)MixerNative.mixerSetControlDetails(mHMixer, ref mxcd, MIXER_SETCONTROLDETAILSFLAG.VALUE);
                    if (errorCode != MMErrors.MMSYSERR_NOERROR)
                        throw new MixerException(errorCode, Mixers.GetErrorDescription(FuncName.fnMixerSetControlDetails, errorCode));
                }
                finally
                {
                    if (pUnsigned != IntPtr.Zero)
                        Marshal.FreeHGlobal(pUnsigned);
                }
            }
        }
        #endregion

        #region Boolean Value
        public unsafe bool ValueAsBoolean
        {
            get
            {
                MMErrors errorCode = 0;
                IntPtr pUnsigned = IntPtr.Zero;

                try
                {
                    IntPtr pmxcdSelectValue = Marshal.AllocHGlobal((int)(1 * sizeof(MIXERCONTROLDETAILS_BOOLEAN)));

                    MIXERCONTROLDETAILS mxcd = new MIXERCONTROLDETAILS();
                    mxcd.cbStruct = (uint)sizeof(MIXERCONTROLDETAILS);
                    mxcd.dwControlID = Id;
                    mxcd.cChannels = 1;
                    mxcd.hwndOwner = IntPtr.Zero;
                    mxcd.cbDetails = (uint)sizeof(MIXERCONTROLDETAILS_BOOLEAN);
                    mxcd.paDetails = pmxcdSelectValue;

                    unchecked
                    {
                        errorCode = (MMErrors)MixerNative.mixerGetControlDetails(mHMixer, ref mxcd, (MIXER_GETCONTROLDETAILSFLAG)(int)((uint)MIXER_OBJECTFLAG.HMIXER | (int)MIXER_GETCONTROLDETAILSFLAG.VALUE));
                    }
                    if (errorCode != MMErrors.MMSYSERR_NOERROR)
                        throw new MixerException(errorCode, Mixers.GetErrorDescription(FuncName.fnMixerGetControlDetails, errorCode));

                    uint val = *((uint*)pmxcdSelectValue);
                    return val == 1 ? true : false;
                }
                finally
                {
                    if (pUnsigned != IntPtr.Zero)
                        Marshal.FreeHGlobal(pUnsigned);
                }
            }
            set
            {
                MMErrors errorCode = 0;
                IntPtr pUnsigned = IntPtr.Zero;

                try
                {
                    IntPtr pmxcdSelectValue = Marshal.AllocHGlobal((int)(1 * sizeof(MIXERCONTROLDETAILS_BOOLEAN)));

                    MIXERCONTROLDETAILS mxcd = new MIXERCONTROLDETAILS();
                    mxcd.cbStruct = (uint)sizeof(MIXERCONTROLDETAILS);
                    mxcd.dwControlID = Id;
                    mxcd.cChannels = 1;
                    mxcd.hwndOwner = IntPtr.Zero;
                    mxcd.cbDetails = (uint)sizeof(MIXERCONTROLDETAILS_BOOLEAN);
                    mxcd.paDetails = pmxcdSelectValue;

                    unchecked
                    {
                        errorCode = (MMErrors)MixerNative.mixerGetControlDetails(mHMixer, ref mxcd, (MIXER_GETCONTROLDETAILSFLAG)(int)((uint)MIXER_OBJECTFLAG.HMIXER | (int)MIXER_GETCONTROLDETAILSFLAG.VALUE));
                    }
                    if (errorCode != MMErrors.MMSYSERR_NOERROR)
                        throw new MixerException(errorCode, Mixers.GetErrorDescription(FuncName.fnMixerGetControlDetails, errorCode));

                    *((uint*)pmxcdSelectValue) = value ? 1U : 0U;

                    errorCode = (MMErrors)MixerNative.mixerSetControlDetails(mHMixer, ref mxcd, MIXER_SETCONTROLDETAILSFLAG.VALUE);
                    if (errorCode != MMErrors.MMSYSERR_NOERROR)
                        throw new MixerException(errorCode, Mixers.GetErrorDescription(FuncName.fnMixerSetControlDetails, errorCode));
                }
                finally
                {
                    if (pUnsigned != IntPtr.Zero)
                        Marshal.FreeHGlobal(pUnsigned);
                }
            }
        }
        #endregion

        #region Volume
        internal unsafe int Volume
        {
            get { return ValueAsUnsigned; }
            set { ValueAsUnsigned = value; }
        }
        #endregion

        #region Selected
        internal unsafe uint Selected
        {
            get
            {
                IntPtr pmixList = IntPtr.Zero;
                IntPtr pmixBool = IntPtr.Zero;
                MMErrors errorCode = 0;

                try
                {
                    if (mMultipleItems == 1 && this.Line.Mixer.UserLines.Count >= 1)
                        return this.Line.Mixer.UserLines[0].Id;

                    MIXERCONTROLDETAILS mxcdl = new MIXERCONTROLDETAILS();
                    pmixList = Marshal.AllocHGlobal((int)(mMultipleItems * Marshal.SizeOf(typeof(MIXERCONTROLDETAILS_LISTTEXT))));

                    mxcdl.cbStruct = (uint)sizeof(MIXERCONTROLDETAILS);
                    mxcdl.dwControlID = mControlId;
                    mxcdl.cChannels = 1;
                    mxcdl.cMultipleItems = mMultipleItems;
                    mxcdl.cbDetails = (uint)Marshal.SizeOf(typeof(MIXERCONTROLDETAILS_LISTTEXT));
                    mxcdl.paDetails = pmixList;
                    errorCode = (MMErrors)MixerNative.mixerGetControlDetails(mHMixer, ref mxcdl, MIXER_GETCONTROLDETAILSFLAG.LISTTEXT);
                    if (errorCode != MMErrors.MMSYSERR_NOERROR)
                        throw new MixerException(errorCode, Mixers.GetErrorDescription(FuncName.fnMixerGetControlDetails, errorCode));

                    MIXERCONTROLDETAILS mxcdb = new MIXERCONTROLDETAILS();
                    pmixBool = Marshal.AllocHGlobal((int)(mMultipleItems * Marshal.SizeOf(typeof(MIXERCONTROLDETAILS_BOOLEAN))));

                    mxcdb.cbStruct = (uint)sizeof(MIXERCONTROLDETAILS);
                    mxcdb.dwControlID = mControlId;
                    mxcdb.cChannels = 1;
                    mxcdb.cMultipleItems = mMultipleItems;
                    mxcdb.cbDetails = (uint)Marshal.SizeOf(typeof(MIXERCONTROLDETAILS_BOOLEAN));
                    mxcdb.paDetails = pmixBool;
                    errorCode = (MMErrors)MixerNative.mixerGetControlDetails(mHMixer, ref mxcdb, ((uint)MIXER_OBJECTFLAG.HMIXER | (uint)MIXER_GETCONTROLDETAILSFLAG.VALUE));
                    if (errorCode != MMErrors.MMSYSERR_NOERROR)
                        throw new MixerException(errorCode, Mixers.GetErrorDescription(FuncName.fnMixerGetControlDetails, errorCode));

                    for (uint y = 0; y < mxcdb.cMultipleItems; y++)
                    {
                        IntPtr pVmixList = (IntPtr)(((byte*)pmixList) + (Marshal.SizeOf(typeof(MIXERCONTROLDETAILS_LISTTEXT)) * y));
                        MIXERCONTROLDETAILS_LISTTEXT mixList = (MIXERCONTROLDETAILS_LISTTEXT)Marshal.PtrToStructure(pVmixList, typeof(MIXERCONTROLDETAILS_LISTTEXT));

                        uint lineId = mixList.dwParam1;
                        bool selected = (*(((uint*)pmixBool) + y)) == 1 ? true : false;
                        if (selected == true)
                            return lineId;
                    }
                }
                finally
                {
                    if (pmixList != IntPtr.Zero)
                        Marshal.FreeHGlobal(pmixList);
                    if (pmixBool != IntPtr.Zero)
                        Marshal.FreeHGlobal(pmixBool);
                }

                return 0;
            }
            set
            {
                IntPtr pmixList = IntPtr.Zero;
                IntPtr pmixBool = IntPtr.Zero;
                MMErrors errorCode = 0;

                try
                {
                    uint minusOne;
                    unchecked { minusOne = (uint)-1; }

                    if ((mMultipleItems == 1 && this.Line.Mixer.UserLines.Count >= 1) || value == minusOne)
                    {
                        MixerNative.SendMessage(this.Line.Mixer.CallbackWindowHandle, MixerNative.MM_MIXM_LINE_CHANGE, (uint)mHMixer, this.Line.Mixer.UserLines[0].Id);
                        return;
                    }

                    MIXERCONTROLDETAILS mxcdl = new MIXERCONTROLDETAILS();
                    pmixList = Marshal.AllocHGlobal((int)(mMultipleItems * Marshal.SizeOf(typeof(MIXERCONTROLDETAILS_LISTTEXT))));

                    mxcdl.cbStruct = (uint)sizeof(MIXERCONTROLDETAILS);
                    mxcdl.dwControlID = mControlId;
                    mxcdl.cChannels = 1;
                    mxcdl.cMultipleItems = mMultipleItems;
                    mxcdl.cbDetails = (uint)Marshal.SizeOf(typeof(MIXERCONTROLDETAILS_LISTTEXT));
                    mxcdl.paDetails = pmixList;
                    errorCode = (MMErrors)MixerNative.mixerGetControlDetails(mHMixer, ref mxcdl, MIXER_GETCONTROLDETAILSFLAG.LISTTEXT);
                    if (errorCode != MMErrors.MMSYSERR_NOERROR)
                        throw new MixerException(errorCode, Mixers.GetErrorDescription(FuncName.fnMixerGetControlDetails, errorCode));

                    MIXERCONTROLDETAILS mxcdb = new MIXERCONTROLDETAILS();
                    pmixBool = Marshal.AllocHGlobal((int)(mMultipleItems * Marshal.SizeOf(typeof(MIXERCONTROLDETAILS_BOOLEAN))));

                    mxcdb.cbStruct = (uint)sizeof(MIXERCONTROLDETAILS);
                    mxcdb.dwControlID = mControlId;
                    mxcdb.cChannels = 1;
                    mxcdb.cMultipleItems = mMultipleItems;
                    mxcdb.cbDetails = (uint)Marshal.SizeOf(typeof(MIXERCONTROLDETAILS_BOOLEAN));
                    mxcdb.paDetails = pmixBool;
                    errorCode = (MMErrors)MixerNative.mixerGetControlDetails(mHMixer, ref mxcdb, ((uint)MIXER_OBJECTFLAG.HMIXER | (uint)MIXER_GETCONTROLDETAILSFLAG.VALUE));
                    if (errorCode != MMErrors.MMSYSERR_NOERROR)
                        throw new MixerException(errorCode, Mixers.GetErrorDescription(FuncName.fnMixerGetControlDetails, errorCode));

                    for (uint y = 0; y < mxcdb.cMultipleItems; y++)
                    {
                        IntPtr pVmixList = (IntPtr)(((byte*)pmixList) + (Marshal.SizeOf(typeof(MIXERCONTROLDETAILS_LISTTEXT)) * y));
                        MIXERCONTROLDETAILS_LISTTEXT mixList = (MIXERCONTROLDETAILS_LISTTEXT)Marshal.PtrToStructure(pVmixList, typeof(MIXERCONTROLDETAILS_LISTTEXT));

                        uint lineId = mixList.dwParam1;
                        uint* pBoolVal = (((uint*)pmixBool) + y);

                        if (lineId == value)
                            *pBoolVal = 1;
                        else
                            *pBoolVal = 0;
                    }

                    errorCode = (MMErrors)MixerNative.mixerSetControlDetails(mHMixer, ref mxcdb, MIXER_SETCONTROLDETAILSFLAG.VALUE);
                    if (errorCode != MMErrors.MMSYSERR_NOERROR)
                        throw new MixerException(errorCode, Mixers.GetErrorDescription(FuncName.fnMixerSetControlDetails, errorCode));

                    foreach (MixerLine line in this.Line.Mixer.Lines)
                        MixerNative.SendMessage(this.Line.Mixer.CallbackWindowHandle, MixerNative.MM_MIXM_LINE_CHANGE, (uint)mHMixer, line.Id);
                }
                finally
                {
                    if (pmixList != IntPtr.Zero)
                        Marshal.FreeHGlobal(pmixList);
                    if (pmixBool != IntPtr.Zero)
                        Marshal.FreeHGlobal(pmixBool);
                }
            }
        }
        #endregion

        #region Mute
        internal unsafe bool Mute
        {
            get { return ValueAsBoolean; }
            set { ValueAsBoolean = value; }
        }
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