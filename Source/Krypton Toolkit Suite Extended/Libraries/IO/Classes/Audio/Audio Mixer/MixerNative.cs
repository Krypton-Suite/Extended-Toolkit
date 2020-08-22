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
    #region Enums
    #region Channel
    public enum Channel
    {
        Uniform = 0,
        Left = 1,
        Right = 2,
        Channel_1 = 1,
        Channel_2 = 2,
        Channel_3 = 3,
        Channel_4 = 4
    }
    #endregion

    #region MIXERLINE_LINEFLAG
    public enum MIXERLINE_LINEFLAG : uint
    {
        ACTIVE = 0x00000001,
        DISCONNECTED = 0x00008000,
        SOURCE = 0x80000000
    }
    #endregion

    #region MIXERCONTROL_CONTROLFLAG
    public enum MIXERCONTROL_CONTROLFLAG : uint
    {
        UNIFORM = 0x00000001,
        MULTIPLE = 0x00000002,
        DISABLED = 0x80000000
    }
    #endregion

    #region MIXER_GETCONTROLDETAILSFLAG
    public enum MIXER_GETCONTROLDETAILSFLAG
    {
        VALUE = 0x00000000,
        LISTTEXT = 0x00000001,
        QUERYMASK = 0x0000000F
    }
    #endregion

    #region MIXER_SETCONTROLDETAILSFLAG
    public enum MIXER_SETCONTROLDETAILSFLAG
    {
        VALUE = 0x00000000,
        CUSTOM = 0x00000001,
        QUERYMASK = 0x0000000F
    }
    #endregion

    #region MIXER_OBJECTFLAG
    public enum MIXER_OBJECTFLAG : uint
    {
        HANDLE = 0x80000000,
        MIXER = 0x00000000,
        HMIXER = (HANDLE | MIXER),
        WAVEOUT = 0x10000000,
        HWAVEOUT = (HANDLE | WAVEOUT),
        WAVEIN = 0x20000000,
        HWAVEIN = (HANDLE | WAVEIN),
        MIDIOUT = 0x30000000,
        HMIDIOUT = (HANDLE | MIDIOUT),
        MIDIIN = 0x40000000,
        HMIDIIN = (HANDLE | MIDIIN),
        AUX = 0x50000000,
    }
    #endregion

    #region MIXER_GETLINECONTROLSFLAG
    public enum MIXER_GETLINECONTROLSFLAG
    {
        ALL = 0x00000000,
        ONEBYID = 0x00000001,
        ONEBYTYPE = 0x00000002,

        QUERYMASK = 0x0000000F,
    }
    #endregion

    #region MIXER_GETLINEINFO
    public enum MIXER_GETLINEINFOF
    {
        DESTINATION = 0x00000000,
        SOURCE = 0x00000001,
        LINEID = 0x00000002,
        COMPONENTTYPE = 0x00000003,
        TARGETTYPE = 0x00000004,

        QUERYMASK = 0x0000000F
    }
    #endregion

    #region MIXERCONTROL_CT_CLASS
    public enum MIXERCONTROL_CT_CLASS : uint
    {
        MASK = 0xF0000000,
        CUSTOM = 0x00000000,
        METER = 0x10000000,
        SWITCH = 0x20000000,
        NUMBER = 0x30000000,
        SLIDER = 0x40000000,
        FADER = 0x50000000,
        TIME = 0x60000000,
        LIST = 0x70000000,

        MIXERCONTROL_CT_SUBCLASS_MASK = 0x0F000000,

        MIXERCONTROL_CT_SC_SWITCH_BOOLEAN = 0x00000000,
        MIXERCONTROL_CT_SC_SWITCH_BUTTON = 0x01000000,

        MIXERCONTROL_CT_SC_METER_POLLED = 0x00000000,

        MIXERCONTROL_CT_SC_TIME_MICROSECS = 0x00000000,
        MIXERCONTROL_CT_SC_TIME_MILLISECS = 0x01000000,

        MIXERCONTROL_CT_SC_LIST_SINGLE = 0x00000000,
        MIXERCONTROL_CT_SC_LIST_MULTIPLE = 0x01000000,

        MIXERCONTROL_CT_UNITS_MASK = 0x00FF0000,
        MIXERCONTROL_CT_UNITS_CUSTOM = 0x00000000,
        MIXERCONTROL_CT_UNITS_BOOLEAN = 0x00010000,
        MIXERCONTROL_CT_UNITS_SIGNED = 0x00020000,
        MIXERCONTROL_CT_UNITS_UNSIGNED = 0x00030000,
        MIXERCONTROL_CT_UNITS_DECIBELS = 0x00040000, /* in 10ths */
        MIXERCONTROL_CT_UNITS_PERCENT = 0x00050000, /* in 10ths */
    }
    #endregion

    #region MIXERCONTROL_CONTROLTYPE
    public enum MIXERCONTROL_CONTROLTYPE : uint
    {
        CUSTOM = (MIXERCONTROL_CT_CLASS.CUSTOM | MIXERCONTROL_CT_CLASS.MIXERCONTROL_CT_UNITS_CUSTOM),
        BOOLEANMETER = (MIXERCONTROL_CT_CLASS.METER | MIXERCONTROL_CT_CLASS.MIXERCONTROL_CT_SC_METER_POLLED | MIXERCONTROL_CT_CLASS.MIXERCONTROL_CT_UNITS_BOOLEAN),
        SIGNEDMETER = (MIXERCONTROL_CT_CLASS.METER | MIXERCONTROL_CT_CLASS.MIXERCONTROL_CT_SC_METER_POLLED | MIXERCONTROL_CT_CLASS.MIXERCONTROL_CT_UNITS_SIGNED),
        PEAKMETER = (SIGNEDMETER + 1),
        UNSIGNEDMETER = (MIXERCONTROL_CT_CLASS.METER | MIXERCONTROL_CT_CLASS.MIXERCONTROL_CT_SC_METER_POLLED | MIXERCONTROL_CT_CLASS.MIXERCONTROL_CT_UNITS_UNSIGNED),
        BOOLEAN = (MIXERCONTROL_CT_CLASS.SWITCH | MIXERCONTROL_CT_CLASS.MIXERCONTROL_CT_SC_SWITCH_BOOLEAN | MIXERCONTROL_CT_CLASS.MIXERCONTROL_CT_UNITS_BOOLEAN),
        ONOFF = (BOOLEAN + 1),
        MUTE = (BOOLEAN + 2),
        MONO = (BOOLEAN + 3),
        LOUDNESS = (BOOLEAN + 4),
        STEREOENH = (BOOLEAN + 5),
        BASS_BOOST = (BOOLEAN + 0x00002277),
        BUTTON = (MIXERCONTROL_CT_CLASS.SWITCH | MIXERCONTROL_CT_CLASS.MIXERCONTROL_CT_SC_SWITCH_BUTTON | MIXERCONTROL_CT_CLASS.MIXERCONTROL_CT_UNITS_BOOLEAN),
        DECIBELS = (MIXERCONTROL_CT_CLASS.NUMBER | MIXERCONTROL_CT_CLASS.MIXERCONTROL_CT_UNITS_DECIBELS),
        SIGNED = (MIXERCONTROL_CT_CLASS.NUMBER | MIXERCONTROL_CT_CLASS.MIXERCONTROL_CT_UNITS_SIGNED),
        UNSIGNED = (MIXERCONTROL_CT_CLASS.NUMBER | MIXERCONTROL_CT_CLASS.MIXERCONTROL_CT_UNITS_UNSIGNED),
        PERCENT = (MIXERCONTROL_CT_CLASS.NUMBER | MIXERCONTROL_CT_CLASS.MIXERCONTROL_CT_UNITS_PERCENT),
        SLIDER = (MIXERCONTROL_CT_CLASS.SLIDER | MIXERCONTROL_CT_CLASS.MIXERCONTROL_CT_UNITS_SIGNED),
        PAN = (SLIDER + 1),
        QSOUNDPAN = (SLIDER + 2),
        FADER = (MIXERCONTROL_CT_CLASS.FADER | MIXERCONTROL_CT_CLASS.MIXERCONTROL_CT_UNITS_UNSIGNED),
        VOLUME = (FADER + 1),
        BASS = (FADER + 2),
        TREBLE = (FADER + 3),
        EQUALIZER = (FADER + 4),
        SINGLESELECT = (MIXERCONTROL_CT_CLASS.LIST | MIXERCONTROL_CT_CLASS.MIXERCONTROL_CT_SC_LIST_SINGLE | MIXERCONTROL_CT_CLASS.MIXERCONTROL_CT_UNITS_BOOLEAN),
        MUX = (SINGLESELECT + 1),
        MULTIPLESELECT = (MIXERCONTROL_CT_CLASS.LIST | MIXERCONTROL_CT_CLASS.MIXERCONTROL_CT_SC_LIST_MULTIPLE | MIXERCONTROL_CT_CLASS.MIXERCONTROL_CT_UNITS_BOOLEAN),
        MIXER = (MULTIPLESELECT + 1),
        MICROTIME = (MIXERCONTROL_CT_CLASS.TIME | MIXERCONTROL_CT_CLASS.MIXERCONTROL_CT_SC_TIME_MICROSECS | MIXERCONTROL_CT_CLASS.MIXERCONTROL_CT_UNITS_UNSIGNED),
        MILLITIME = (MIXERCONTROL_CT_CLASS.TIME | MIXERCONTROL_CT_CLASS.MIXERCONTROL_CT_SC_TIME_MILLISECS | MIXERCONTROL_CT_CLASS.MIXERCONTROL_CT_UNITS_UNSIGNED)
    }
    #endregion

    #region MIXERLINE_COMPONENTTYPE
    public enum MIXERLINE_COMPONENTTYPE
    {
        DST_FIRST = 0x00000000,
        DST_UNDEFINED = (DST_FIRST + 0),
        DST_DIGITAL = (DST_FIRST + 1),
        DST_LINE = (DST_FIRST + 2),
        DST_MONITOR = (DST_FIRST + 3),
        DST_SPEAKERS = (DST_FIRST + 4),
        DST_HEADPHONES = (DST_FIRST + 5),
        DST_TELEPHONE = (DST_FIRST + 6),
        DST_WAVEIN = (DST_FIRST + 7),
        DST_VOICEIN = (DST_FIRST + 8),
        DST_LAST = (DST_FIRST + 8),

        SRC_FIRST = 0x00001000,
        SRC_UNDEFINED = (SRC_FIRST + 0),
        SRC_DIGITAL = (SRC_FIRST + 1),
        SRC_LINE = (SRC_FIRST + 2),
        SRC_MICROPHONE = (SRC_FIRST + 3),
        SRC_SYNTHESIZER = (SRC_FIRST + 4),
        SRC_COMPACTDISC = (SRC_FIRST + 5),
        SRC_TELEPHONE = (SRC_FIRST + 6),
        SRC_PCSPEAKER = (SRC_FIRST + 7),
        SRC_WAVEOUT = (SRC_FIRST + 8),
        SRC_AUXILIARY = (SRC_FIRST + 9),
        SRC_ANALOG = (SRC_FIRST + 10),
        SRC_LAST = (SRC_FIRST + 10)
    }
    #endregion

    #region MMErrors
    public enum MMErrors
    {
        MMSYSERR_NOERROR = 0,                                 /* no error */
        MMSYSERR_ERROR = (MixerNative.MMSYSERR_BASE + 1),  /* unspecified error */
        MMSYSERR_BADDEVICEID = (MixerNative.MMSYSERR_BASE + 2),  /* device ID out of range */
        MMSYSERR_NOTENABLED = (MixerNative.MMSYSERR_BASE + 3),  /* driver failed enable */
        MMSYSERR_ALLOCATED = (MixerNative.MMSYSERR_BASE + 4),  /* device already allocated */
        MMSYSERR_INVALHANDLE = (MixerNative.MMSYSERR_BASE + 5),  /* device handle is invalid */
        MMSYSERR_NODRIVER = (MixerNative.MMSYSERR_BASE + 6),  /* no device driver present */
        MMSYSERR_NOMEM = (MixerNative.MMSYSERR_BASE + 7),  /* memory allocation error */
        MMSYSERR_NOTSUPPORTED = (MixerNative.MMSYSERR_BASE + 8),  /* function isn't supported */
        MMSYSERR_BADERRNUM = (MixerNative.MMSYSERR_BASE + 9),  /* error value out of range */
        MMSYSERR_INVALFLAG = (MixerNative.MMSYSERR_BASE + 10), /* invalid flag passed */
        MMSYSERR_INVALPARAM = (MixerNative.MMSYSERR_BASE + 11), /* invalid parameter passed */
        MMSYSERR_HANDLEBUSY = (MixerNative.MMSYSERR_BASE + 12), /* handle being used */
        MMSYSERR_INVALIDALIAS = (MixerNative.MMSYSERR_BASE + 13), /* specified alias not found */
        MMSYSERR_BADDB = (MixerNative.MMSYSERR_BASE + 14), /* bad registry database */
        MMSYSERR_KEYNOTFOUND = (MixerNative.MMSYSERR_BASE + 15), /* registry key not found */
        MMSYSERR_READERROR = (MixerNative.MMSYSERR_BASE + 16), /* registry read error */
        MMSYSERR_WRITEERROR = (MixerNative.MMSYSERR_BASE + 17), /* registry write error */
        MMSYSERR_DELETEERROR = (MixerNative.MMSYSERR_BASE + 18), /* registry delete error */
        MMSYSERR_VALNOTFOUND = (MixerNative.MMSYSERR_BASE + 19), /* registry value not found */
        MMSYSERR_NODRIVERCB = (MixerNative.MMSYSERR_BASE + 20), /* driver does not call DriverCallback */
        MMSYSERR_MOREDATA = (MixerNative.MMSYSERR_BASE + 21), /* more data to be returned */
        MMSYSERR_LASTERROR = (MixerNative.MMSYSERR_BASE + 21),  /* last error in range */

        WAVERR_BADFORMAT = (MixerNative.WAVERR_BASE + 0),    /* unsupported wave format */
        WAVERR_STILLPLAYING = (MixerNative.WAVERR_BASE + 1),    /* still something playing */
        WAVERR_UNPREPARED = (MixerNative.WAVERR_BASE + 2),    /* header not prepared */
        WAVERR_SYNC = (MixerNative.WAVERR_BASE + 3),    /* device is synchronous */
        WAVERR_LASTERROR = (MixerNative.WAVERR_BASE + 3),    /* last error in range */

        MIXERR_INVALLINE = (MixerNative.MIXERR_BASE + 0),
        MIXERR_INVALCONTROL = (MixerNative.MIXERR_BASE + 1),
        MIXERR_INVALVALUE = (MixerNative.MIXERR_BASE + 2),
        MIXERR_LASTERROR = (MixerNative.MIXERR_BASE + 2)
    }
    #endregion
    #endregion

    #region Structs
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 2)]
    public struct MIXERCONTROLDETAILS_LISTTEXT
    {
        public uint dwParam1;
        public uint dwParam2;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MixerNative.MIXER_LONG_NAME_CHARS)]
        public string szName;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 2)]
    public struct MIXERCONTROLDETAILS_BOOLEAN
    {
        uint fValue;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 2)]
    public struct MIXERCAPS
    {
        public short wMid;
        public short wPid;
        public int vDriverVersion;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MixerNative.MAXPNAMELEN)]
        public string szPname;
        public int fdwSupport;
        public int cDestinations;
    }

    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Auto)]
    public struct MIXERCONTROLDETAILS
    {
        [FieldOffset(0)] public UInt32 cbStruct;
        [FieldOffset(4)] public UInt32 dwControlID;
        [FieldOffset(8)] public UInt32 cChannels;
        // Union start
        [FieldOffset(12)] public IntPtr hwndOwner;
        [FieldOffset(12)] public UInt32 cMultipleItems;
        // Union end
        [FieldOffset(16)] public UInt32 cbDetails;
        [FieldOffset(20)] public IntPtr paDetails;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct MIXERCONTROLDETAILS_UNSIGNED
    {
        public uint dwValue;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct MIXERCONTROLDETAILS_SIGNED
    {
        public int value;
    }

    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi)]
    public struct MIXERCONTROL_BOUNDS
    {
        [FieldOffset(0)] public int lMinimum;
        [FieldOffset(4)] public int lMaximum;
        [FieldOffset(0)] public uint dwMinimum;
        [FieldOffset(4)] public uint dwMaximum;
        [FieldOffset(0)] public uint dwReserved1;
        [FieldOffset(4)] public uint dwReserved2;
        [FieldOffset(8)] public uint dwReserved3;
        [FieldOffset(12)] public uint dwReserved4;
        [FieldOffset(16)] public uint dwReserved5;
        [FieldOffset(20)] public uint dwReserved6;
    }

    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi)]
    public struct MIXERCONTROL_METRICS
    {
        [FieldOffset(0)] public uint cSteps;
        [FieldOffset(0)] public uint cbCustomData;
        [FieldOffset(0)] public uint dwReserved1;
        [FieldOffset(4)] public uint dwReserved2;
        [FieldOffset(8)] public uint dwReserved3;
        [FieldOffset(12)] public uint dwReserved4;
        [FieldOffset(16)] public uint dwReserved5;
        [FieldOffset(20)] public uint dwReserved6;
    }

    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi)]
    public struct MIXERCONTROL
    {
        [FieldOffset(0)] public UInt32 cbStruct;
        [FieldOffset(4)] public UInt32 dwControlID;
        [FieldOffset(8)] public UInt32 dwControlType;
        [FieldOffset(12)] public UInt32 fdwControl;
        [FieldOffset(16)] public UInt32 cMultipleItems;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MixerNative.MIXER_SHORT_NAME_CHARS)]
        [FieldOffset(20)]
        public string szShortName;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MixerNative.MIXER_LONG_NAME_CHARS)]
        [FieldOffset(20 + MixerNative.MIXER_SHORT_NAME_CHARS)]
        public string szName;

        [FieldOffset(20 + MixerNative.MIXER_SHORT_NAME_CHARS + MixerNative.MIXER_LONG_NAME_CHARS)]
        public MIXERCONTROL_BOUNDS Bounds;

        [FieldOffset(20 + MixerNative.MIXER_SHORT_NAME_CHARS + MixerNative.MIXER_LONG_NAME_CHARS + 24)]
        public MIXERCONTROL_METRICS Metrics;
    }

    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Auto)]
    public struct MIXERLINECONTROLS
    {
        [FieldOffset(0)] public UInt32 cbStruct;
        [FieldOffset(4)] public UInt32 dwLineID;
        // Union start
        [FieldOffset(8)] public UInt32 dwControlID;
        [FieldOffset(8)] public MIXERCONTROL_CONTROLTYPE dwControlType;
        // Union end
        [FieldOffset(12)] public UInt32 cControls;
        [FieldOffset(16)] public UInt32 cbmxctrl;
        [FieldOffset(20)] public IntPtr pamxctrl;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 2)]
    public struct MIXERLINETARGET
    {
        public uint dwType;
        public uint dwDeviceID;
        public ushort wMid;
        public ushort wPid;
        public uint vDriverVersion;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MixerNative.MAXPNAMELEN)]
        public string szPname;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 2)]
    internal struct MIXERLINE
    {
        public UInt32 cbStruct;
        public UInt32 dwDestination;
        public UInt32 dwSource;
        public UInt32 dwLineID;
        public UInt32 fdwLine;
        public IntPtr dwUser;
        public MIXERLINE_COMPONENTTYPE dwComponentType;
        public UInt32 cChannels;
        public UInt32 cConnections;
        public UInt32 cControls;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MixerNative.MIXER_SHORT_NAME_CHARS)]
        public string szShortName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MixerNative.MIXER_LONG_NAME_CHARS)]
        public string szName;
        public MIXERLINETARGET Target;
    }
    #endregion

    [Author("Gustavo Franco")]
    public class MixerNative
    {
        #region Constants
        public const int MMSYSERR_BASE = 0;
        public const int WAVERR_BASE = 32;
        public const int MIXER_SHORT_NAME_CHARS = 16;
        public const int MIXER_LONG_NAME_CHARS = 64;
        public const int MAXPNAMELEN = 32;     /* max product name length (including NULL) */
        public const int MIXERR_BASE = 1024;
        public const int CALLBACK_WINDOW = 0x00010000;    /* dwCallback is a HWND */
        public const int MM_MIXM_LINE_CHANGE = 0x3D0;       /* mixer line change notify */
        public const int MM_MIXM_CONTROL_CHANGE = 0x3D1;
        #endregion

        #region User32.dll functions
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int msg, uint wParam, uint lParam);
        #endregion

        #region Winmm.dll functions
        [DllImport("winmm.dll")]
        public static extern int mixerOpen(out IntPtr phmx, int pMxId, IntPtr dwCallback, IntPtr dwInstance, uint fdwOpen);
        [DllImport("winmm.dll")]
        public static extern int mixerOpen(out IntPtr phmx, IntPtr pMxId, IntPtr dwCallback, IntPtr dwInstance, MIXER_OBJECTFLAG fdwOpen);
        [DllImport("winmm.dll")]
        public static extern int mixerOpen(out IntPtr phmx, IntPtr pMxId, IntPtr dwCallback, IntPtr dwInstance, uint fdwOpen);
        [DllImport("winmm.dll")]
        internal static extern int mixerGetLineInfo(IntPtr hmxobj, ref MIXERLINE pmxl, MIXER_GETLINEINFOF fdwInfo);
        [DllImport("winmm.dll")]
        public static extern int mixerClose(IntPtr hmx);
        [DllImport("winmm.dll")]
        public static extern int mixerGetLineControls(IntPtr hmxobj, ref MIXERLINECONTROLS pmxlc, MIXER_GETLINECONTROLSFLAG fdwControls);
        [DllImport("winmm.dll")]
        public static extern int mixerGetControlDetails(IntPtr hmxobj, ref MIXERCONTROLDETAILS pmxcd, MIXER_SETCONTROLDETAILSFLAG fdwDetailsmixer);
        [DllImport("winmm.dll")]
        public static extern int mixerGetControlDetails(IntPtr hmxobj, ref MIXERCONTROLDETAILS pmxcd, uint fdwDetailsmixer);
        [DllImport("winmm.dll")]
        public static extern int mixerGetControlDetails(IntPtr hmxobj, ref MIXERCONTROLDETAILS pmxcd, MIXER_GETCONTROLDETAILSFLAG fdwDetailsmixer);
        [DllImport("winmm.dll")]
        public static extern int mixerSetControlDetails(IntPtr hmxobj, ref MIXERCONTROLDETAILS pmxcd, MIXER_SETCONTROLDETAILSFLAG fdwDetails);
        [DllImport("winmm.dll")]
        public static extern int mixerGetID(IntPtr hmxobj, ref int mxId, MIXER_OBJECTFLAG fdwId);
        [DllImport("winmm.dll", CharSet = CharSet.Ansi)]
        public static extern int mixerGetDevCaps(int uMxId, ref MIXERCAPS pmxcaps, int cbmxcaps);
        [DllImport("winmm.dll", SetLastError = true)]
        public static extern int mixerGetNumDevs();
        #endregion

        #region Constructors
        private MixerNative()
        {
        }
        #endregion
    }
}