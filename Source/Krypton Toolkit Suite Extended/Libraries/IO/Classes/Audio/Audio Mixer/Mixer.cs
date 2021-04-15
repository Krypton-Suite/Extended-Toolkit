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
    #region Aliases
    using HMIXER = System.IntPtr;
    using HWAVEOUT = System.IntPtr;
    #endregion

    #region Enum
    public enum MixerType
    {
        Playback = 0,
        Recording = 1
    }
    #endregion

    #region Delegates
    internal delegate void CallbackWindowControlChangeHandler(IntPtr hMixer, uint controlId);
    internal delegate void CallbackWindowLineChangeHandler(IntPtr hMixer, uint lineId);
    #endregion

    [Author("Gustavo Franco")]
    public class Mixer : IDisposable
    {
        #region Delegates
        public delegate void MixerLineChangeHandler(Mixer mixer, MixerLine line);
        #endregion

        #region Events
        public event MixerLineChangeHandler MixerLineChanged;
        #endregion

        #region Constants Declaration
        #endregion

        #region Variables Declaration
        private MixerType mMixerType;
        private int mDeviceId;
        private IntPtr mHMixer;
        private MixerLines mLines;
        private MixerLines mUserLines;
        private CallbackWindow mCallbackWindow;
        private CallbackWindowControlChangeHandler mMixerControlChangeHandler;
        private CallbackWindowLineChangeHandler mMixerLineChangeHandler;
        #endregion

        #region Constructors
        public Mixer(MixerType mixerType)
        {
            mMixerType = mixerType;
            mLines = new MixerLines();
            mUserLines = new MixerLines();
            mMixerControlChangeHandler = new CallbackWindowControlChangeHandler(PtrMixerControlChange);
            mMixerLineChangeHandler = new CallbackWindowLineChangeHandler(PtrMixerLineChange);
            mCallbackWindow = new CallbackWindow(mMixerControlChangeHandler, mMixerLineChangeHandler);
            DeviceId = -1;
        }
        #endregion

        #region Properties
        internal IntPtr CallbackWindowHandle
        {
            get { return mCallbackWindow.Handle; }
        }

        #region MixerType
        public MixerType MixerType
        {
            get { return mMixerType; }
        }
        #endregion

        #region Lines
        public MixerLines Lines
        {
            get { return mLines; }
        }

        public MixerLines UserLines
        {
            get { return mUserLines; }
        }
        #endregion

        #region DeviceId
        public int DeviceId
        {
            get { return mDeviceId; }
            set
            {
                MMErrors errorCode = 0;

                if (value == -1)
                    mDeviceId = DeviceIdDefault;
                else
                    mDeviceId = value;

                if (mHMixer != IntPtr.Zero)
                    MixerNative.mixerClose(mHMixer);

                errorCode = (MMErrors)MixerNative.mixerOpen(out mHMixer, mDeviceId, mCallbackWindow.Handle, IntPtr.Zero, MixerNative.CALLBACK_WINDOW);
                if (errorCode != MMErrors.MMSYSERR_NOERROR)
                    throw new MixerException(errorCode, Mixers.GetErrorDescription(FuncName.fnMixerOpen, errorCode));

                ReloadLines();
            }
        }
        #endregion

        #region DeviceDetail
        public MixerDetail DeviceDetail
        {
            get
            {
                foreach (MixerDetail mixerDetail in Devices)
                    if (mixerDetail.DeviceId == mDeviceId)
                        return mixerDetail;

                return null;
            }
        }
        #endregion

        #region DeviceIdDefault
        public int DeviceIdDefault
        {
            get
            {
                MMErrors errorCode = 0;
                HWAVEOUT hWave = IntPtr.Zero;
                HMIXER hMixer = IntPtr.Zero;
                int deviceId = -1;

                try
                {
                    WAVEFORMATEX waveFormat = WAVEFORMATEX.Empty;

                    waveFormat.formatTag = WaveFormatTag.PCM;
                    waveFormat.nChannels = 1;
                    waveFormat.nSamplesPerSec = 8000;
                    waveFormat.wBitsPerSample = 8;
                    waveFormat.nBlockAlign = (short)(waveFormat.nChannels * (waveFormat.wBitsPerSample / 8));
                    waveFormat.nAvgBytesPerSec = waveFormat.nSamplesPerSec * waveFormat.nBlockAlign;
                    waveFormat.cbSize = 0;

                    if (mMixerType == MixerType.Recording)
                        errorCode = (MMErrors)WaveNative.waveInOpen(out hWave, WaveNative.WAVE_MAPPER, ref waveFormat, IntPtr.Zero, IntPtr.Zero, (int)CallBackFlag.CALLBACK_NULL);
                    else if (mMixerType == MixerType.Playback)
                        errorCode = (MMErrors)WaveNative.waveOutOpen(out hWave, WaveNative.WAVE_MAPPER, ref waveFormat, IntPtr.Zero, IntPtr.Zero, (int)CallBackFlag.CALLBACK_NULL);
                    if (errorCode != MMErrors.MMSYSERR_NOERROR)
                        throw new MixerException(errorCode, Mixers.GetErrorDescription(FuncName.fnWaveInOpen, errorCode));

                    if (mMixerType == MixerType.Recording)
                        errorCode = (MMErrors)MixerNative.mixerOpen(out hMixer, hWave, IntPtr.Zero, IntPtr.Zero, ((uint)MIXER_OBJECTFLAG.HWAVEIN));
                    else if (mMixerType == MixerType.Playback)
                        errorCode = (MMErrors)MixerNative.mixerOpen(out hMixer, hWave, IntPtr.Zero, IntPtr.Zero, ((uint)MIXER_OBJECTFLAG.HWAVEOUT));
                    if (errorCode != MMErrors.MMSYSERR_NOERROR)
                        throw new MixerException(errorCode, Mixers.GetErrorDescription(FuncName.fnMixerOpen, errorCode));

                    errorCode = (MMErrors)MixerNative.mixerGetID(hMixer, ref deviceId, MIXER_OBJECTFLAG.MIXER);
                    if (errorCode != MMErrors.MMSYSERR_NOERROR)
                        throw new MixerException(errorCode, Mixers.GetErrorDescription(FuncName.fnMixerGetID, errorCode));
                }
                finally
                {
                    if (hMixer != IntPtr.Zero)
                        MixerNative.mixerClose(hMixer);
                    if (hWave != IntPtr.Zero && mMixerType == MixerType.Playback)
                        WaveNative.waveOutClose(hWave);
                    if (hWave != IntPtr.Zero && mMixerType == MixerType.Recording)
                        WaveNative.waveInClose(hWave);
                }

                return deviceId;
            }
        }
        #endregion

        #region Devices
        public unsafe MixerDetails Devices
        {
            get
            {
                MMErrors errorCode = 0;
                MixerDetails mixDetails = new MixerDetails();
                HMIXER hMixer = IntPtr.Zero;

                try
                {
                    MIXERCAPS wic = new MIXERCAPS();

                    int iNumDevs = MixerNative.mixerGetNumDevs();

                    for (int i = 0; i < iNumDevs; i++)
                    {
                        // Get info about the next device 
                        errorCode = (MMErrors)MixerNative.mixerGetDevCaps(i, ref wic, Marshal.SizeOf(wic));
                        if (errorCode != MMErrors.MMSYSERR_NOERROR)
                            throw new MixerException(errorCode, Mixers.GetErrorDescription(FuncName.fnMixerGetDevCaps, errorCode));

                        errorCode = (MMErrors)MixerNative.mixerOpen(out hMixer, i, IntPtr.Zero, IntPtr.Zero, 0);
                        if (errorCode != MMErrors.MMSYSERR_NOERROR)
                            throw new MixerException(errorCode, Mixers.GetErrorDescription(FuncName.fnMixerOpen, errorCode));

                        MixerDetail mixDetail = new MixerDetail();
                        MIXERLINE mxl = new MIXERLINE();

                        mxl.cbStruct = (uint)Marshal.SizeOf(mxl);
                        mxl.dwComponentType = MIXERLINE_COMPONENTTYPE.DST_WAVEIN;
                        if (MixerNative.mixerGetLineInfo(hMixer, ref mxl, MIXER_GETLINEINFOF.COMPONENTTYPE) == 0)
                        {
                            mixDetail.DeviceId = i;
                            mixDetail.MixerName = wic.szPname;
                            mixDetail.SupportWaveIn = true;
                        }

                        mxl.dwComponentType = MIXERLINE_COMPONENTTYPE.DST_SPEAKERS;
                        if (MixerNative.mixerGetLineInfo(hMixer, ref mxl, MIXER_GETLINEINFOF.COMPONENTTYPE) == 0)
                        {
                            mixDetail.DeviceId = i;
                            mixDetail.MixerName = wic.szPname;
                            mixDetail.SupportWaveOut = true;
                        }
                        else
                        {
                            mxl.dwComponentType = MIXERLINE_COMPONENTTYPE.DST_UNDEFINED;
                            if (MixerNative.mixerGetLineInfo(hMixer, ref mxl, MIXER_GETLINEINFOF.COMPONENTTYPE) == 0)
                            {
                                mixDetail.DeviceId = i;
                                mixDetail.MixerName = wic.szPname;
                                mixDetail.SupportWaveOut = true;
                            }
                        }

                        if (mMixerType == MixerType.Recording && mixDetail.SupportWaveIn == true)
                            mixDetails.Add(mixDetail);

                        if (mMixerType == MixerType.Playback && mixDetail.SupportWaveOut == true)
                            mixDetails.Add(mixDetail);
                    }
                }
                finally
                {
                    if (hMixer != IntPtr.Zero)
                        MixerNative.mixerClose(hMixer);
                }
                return mixDetails;
            }
        }
        #endregion
        #endregion

        #region Private Methods
        private void ReloadLines()
        {
            MMErrors errorCode = 0;

            mLines.Clear();
            mUserLines.Clear();

            MIXERLINE mxl = new MIXERLINE();
            MIXERLINECONTROLS mlc = new MIXERLINECONTROLS();
            MIXERCONTROL mc = new MIXERCONTROL();
            uint dwDestination;
            unchecked
            {
                dwDestination = (uint)-1;
            }

            mxl.cbStruct = (uint)Marshal.SizeOf(mxl);

            if (mMixerType == MixerType.Recording)
            {
                mxl.dwComponentType = MIXERLINE_COMPONENTTYPE.DST_WAVEIN;
                errorCode = (MMErrors)MixerNative.mixerGetLineInfo(mHMixer, ref mxl, MIXER_GETLINEINFOF.COMPONENTTYPE);
                if (errorCode != MMErrors.MMSYSERR_NOERROR)
                    throw new MixerException(errorCode, Mixers.GetErrorDescription(FuncName.fnMixerGetLineInfo, errorCode));
            }
            else if (mMixerType == MixerType.Playback)
            {
                mxl.dwComponentType = MIXERLINE_COMPONENTTYPE.DST_SPEAKERS;
                errorCode = (MMErrors)MixerNative.mixerGetLineInfo(mHMixer, ref mxl, MIXER_GETLINEINFOF.COMPONENTTYPE);
                if (errorCode != MMErrors.MMSYSERR_NOERROR)
                {
                    mxl.dwComponentType = MIXERLINE_COMPONENTTYPE.DST_UNDEFINED;
                    errorCode = (MMErrors)MixerNative.mixerGetLineInfo(mHMixer, ref mxl, MIXER_GETLINEINFOF.COMPONENTTYPE);
                    if (errorCode != MMErrors.MMSYSERR_NOERROR)
                        throw new MixerException(errorCode, Mixers.GetErrorDescription(FuncName.fnMixerGetLineInfo, errorCode));
                }
            }

            dwDestination = mxl.dwDestination;

            MixerLine mixLine = new MixerLine();

            if (mMixerType == MixerType.Recording)
                mixLine.Direction = MixerType.Recording;
            else if (mMixerType == MixerType.Playback)
                mixLine.Direction = MixerType.Playback;

            mixLine.Mixer = this;
            mixLine.Channels = mxl.cChannels;
            mixLine.CControls = mxl.cControls;
            mixLine.Connections = mxl.cConnections;
            mixLine.Flag = mxl.fdwLine;
            mixLine.Destination = dwDestination;
            mixLine.Name = mxl.szName;
            mixLine.Id = mxl.dwLineID;
            mixLine.ComponentType = mxl.dwComponentType;
            mixLine.Source = mxl.dwSource;
            mixLine.HMixer = mHMixer;

            if (mixLine.CControls != 0 && !(mixLine.CControls == 1 && mixLine.Controls[0].Type == MIXERCONTROL_CONTROLTYPE.MUX))
                mUserLines.Add(mixLine);
            mLines.Add(mixLine);

            int cConnections = (int)mxl.cConnections;
            for (int i = 0; i < cConnections; i++)
            {
                mxl.cbStruct = (uint)Marshal.SizeOf(mxl);
                mxl.dwDestination = dwDestination;
                mxl.dwSource = (uint)i;

                errorCode = (MMErrors)MixerNative.mixerGetLineInfo(mHMixer, ref mxl, MIXER_GETLINEINFOF.SOURCE);
                if (errorCode != MMErrors.MMSYSERR_NOERROR)
                    throw new MixerException(errorCode, Mixers.GetErrorDescription(FuncName.fnMixerGetLineInfo, errorCode));

                MixerLine mixLineNew = new MixerLine();

                if (mMixerType == MixerType.Recording)
                    mixLineNew.Direction = MixerType.Recording;
                else if (mMixerType == MixerType.Playback)
                    mixLineNew.Direction = MixerType.Playback;

                mixLineNew.Mixer = this;
                mixLineNew.Channels = mxl.cChannels;
                mixLineNew.CControls = mxl.cControls;
                mixLineNew.Connections = mxl.cConnections;
                mixLineNew.Flag = mxl.fdwLine;
                mixLineNew.Destination = dwDestination;
                mixLineNew.Name = mxl.szName;
                mixLineNew.Id = mxl.dwLineID;
                mixLineNew.ComponentType = mxl.dwComponentType;
                mixLineNew.Source = mxl.dwSource;
                mixLineNew.HMixer = mHMixer;

                if (mixLineNew.CControls != 0)
                    mUserLines.Add(mixLineNew);
                mLines.Add(mixLineNew);
            }
        }

        private void PtrMixerControlChange(IntPtr hMixer, uint controlId)
        {
            if (hMixer != IntPtr.Zero && MixerLineChanged != null)
            {
                MixerLine line = mUserLines.GetMixerLineByControlId(controlId);
                if (line != null)
                    MixerLineChanged(this, line);
                else
                {
                    MixerLine lineOS = mLines.GetMixerLineByControlId(controlId);
                    if (lineOS != null)
                    {
                        foreach (MixerLine broadcastLine in mUserLines)
                        {
                            MixerLineChanged(this, broadcastLine);
                        }
                    }
                }
            }
        }

        private void PtrMixerLineChange(IntPtr hMixer, uint lineId)
        {
            if (hMixer != IntPtr.Zero && MixerLineChanged != null)
            {
                MixerLine line = mUserLines.GetMixerLineByLineId(lineId);
                if (line != null)
                    MixerLineChanged(this, line);
            }
        }
        #endregion

        #region Public Methods
        public void Dispose()
        {
            mMixerControlChangeHandler = null;
            mMixerLineChangeHandler = null;
            mCallbackWindow.Dispose();
        }
        #endregion
    }
}