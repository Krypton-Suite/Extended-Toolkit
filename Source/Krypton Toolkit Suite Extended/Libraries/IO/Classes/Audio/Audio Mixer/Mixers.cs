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
    using HMIXER = System.IntPtr;
    #endregion

    #region Enums
    internal enum FuncName
    {
        fnWaveInOpen,
        fnWaveInClose,
        fnWaveInGetDevCaps,
        fnWaveOutOpen,
        fnWaveOutClose,
        fnWaveOutGetDevCaps,
        fnMixerOpen,
        fnMixerGetID,
        fnMixerClose,
        fnMixerGetLineInfo,
        fnMixerGetLineControls,
        fnMixerGetControlDetails,
        fnMixerSetControlDetails,
        fnMixerGetDevCaps,


        fnCustom
    };
    #endregion

    [Author("Gustavo Franco")]
    public class Mixers
    {
        #region Constants Declaration
        #endregion

        #region Variables Declaration 
        private Mixer mRecording;
        private Mixer mPlayback;
        #endregion

        #region Constructors
        public Mixers()
        {
            mRecording = new Mixer(MixerType.Recording);
            mPlayback = new Mixer(MixerType.Playback);
        }
        #endregion

        #region Properties
        #region Recording
        public Mixer Recording
        {
            get { return mRecording; }
        }
        #endregion

        #region Playback
        public Mixer Playback
        {
            get { return mPlayback; }
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
                            throw new MixerException(errorCode, GetErrorDescription(FuncName.fnMixerGetDevCaps, errorCode));

                        errorCode = (MMErrors)MixerNative.mixerOpen(out hMixer, i, IntPtr.Zero, IntPtr.Zero, 0);
                        if (errorCode != MMErrors.MMSYSERR_NOERROR)
                            throw new MixerException(errorCode, GetErrorDescription(FuncName.fnMixerOpen, errorCode));

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

                        if (mixDetail.SupportWaveIn == true || mixDetail.SupportWaveOut == true)
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

        #region Methods
        #endregion

        #region GetErrorDescription
        internal static string GetErrorDescription(FuncName funcName, MMErrors errorCode)
        {
            string errorDesc = "";

            switch (funcName)
            {
                case FuncName.fnWaveOutOpen:
                case FuncName.fnWaveInOpen:
                    switch (errorCode)
                    {
                        case MMErrors.MMSYSERR_ALLOCATED:
                            errorDesc = "Specified resource is already allocated.";
                            break;
                        case MMErrors.MMSYSERR_BADDEVICEID:
                            errorDesc = "Specified device identifier is out of range.";
                            break;
                        case MMErrors.MMSYSERR_NODRIVER:
                            errorDesc = "No device driver is present.";
                            break;
                        case MMErrors.MMSYSERR_NOMEM:
                            errorDesc = "Unable to allocate or lock memory.";
                            break;
                        case MMErrors.WAVERR_BADFORMAT:
                            errorDesc = "Attempted to open with an unsupported waveform-audio format.";
                            break;
                        case MMErrors.WAVERR_SYNC:
                            errorDesc = "The device is synchronous but waveOutOpen was called without using the WAVE_ALLOWSYNC flag.";
                            break;
                    }
                    break;
                case FuncName.fnMixerOpen:
                    switch (errorCode)
                    {
                        case MMErrors.MMSYSERR_ALLOCATED:
                            errorDesc = "The specified resource is already allocated by the maximum number of clients possible.";
                            break;
                        case MMErrors.MMSYSERR_BADDEVICEID:
                            errorDesc = "The uMxId parameter specifies an invalid device identifier.";
                            break;
                        case MMErrors.MMSYSERR_INVALFLAG:
                            errorDesc = "One or more flags are invalid.";
                            break;
                        case MMErrors.MMSYSERR_INVALHANDLE:
                            errorDesc = "The uMxId parameter specifies an invalid handle.";
                            break;
                        case MMErrors.MMSYSERR_INVALPARAM:
                            errorDesc = "One or more parameters are invalid.";
                            break;
                        case MMErrors.MMSYSERR_NODRIVER:
                            errorDesc = "No device driver is present.";
                            break;
                        case MMErrors.MMSYSERR_NOMEM:
                            errorDesc = "Unable to allocate or lock memory.";
                            break;
                    }
                    break;
                case FuncName.fnMixerGetID:
                case FuncName.fnMixerGetLineInfo:
                case FuncName.fnMixerGetLineControls:
                case FuncName.fnMixerGetControlDetails:
                case FuncName.fnMixerSetControlDetails:
                    switch (errorCode)
                    {
                        case MMErrors.MIXERR_INVALCONTROL:
                            errorDesc = "The control reference is invalid.";
                            break;
                        case MMErrors.MIXERR_INVALLINE:
                            errorDesc = "The audio line reference is invalid.";
                            break;
                        case MMErrors.MMSYSERR_BADDEVICEID:
                            errorDesc = "The hmxobj parameter specifies an invalid device identifier.";
                            break;
                        case MMErrors.MMSYSERR_INVALFLAG:
                            errorDesc = "One or more flags are invalid.";
                            break;
                        case MMErrors.MMSYSERR_INVALHANDLE:
                            errorDesc = "The hmxobj parameter specifies an invalid handle.";
                            break;
                        case MMErrors.MMSYSERR_INVALPARAM:
                            errorDesc = "One or more parameters are invalid.";
                            break;
                        case MMErrors.MMSYSERR_NODRIVER:
                            errorDesc = "No device driver is present.";
                            break;
                    }
                    break;
                case FuncName.fnMixerClose:
                    switch (errorCode)
                    {
                        case MMErrors.MMSYSERR_INVALHANDLE:
                            errorDesc = "Specified device handle is invalid.";
                            break;
                    }
                    break;
                case FuncName.fnWaveOutClose:
                case FuncName.fnWaveInClose:
                case FuncName.fnWaveInGetDevCaps:
                case FuncName.fnWaveOutGetDevCaps:
                case FuncName.fnMixerGetDevCaps:
                    switch (errorCode)
                    {
                        case MMErrors.MMSYSERR_BADDEVICEID:
                            errorDesc = "Specified device identifier is out of range.";
                            break;
                        case MMErrors.MMSYSERR_INVALHANDLE:
                            errorDesc = "Specified device handle is invalid.";
                            break;
                        case MMErrors.MMSYSERR_NODRIVER:
                            errorDesc = "No device driver is present.";
                            break;
                        case MMErrors.MMSYSERR_NOMEM:
                            errorDesc = "Unable to allocate or lock memory.";
                            break;
                        case MMErrors.WAVERR_STILLPLAYING:
                            errorDesc = "There are still buffers in the queue.";
                            break;
                    }
                    break;
                case FuncName.fnCustom:
                    switch (errorCode)
                    {
                        case (MMErrors)1000:
                            errorDesc = "Device Not Found.";
                            break;
                    }
                    break;
            }
            return errorDesc;
        }
        #endregion
    }
}