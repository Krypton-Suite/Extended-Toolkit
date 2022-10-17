#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    [ComImport, Guid("C2B5F241-DAA0-4507-9E16-5A1EAA2B7A5C"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ISpRecognizer : ISpProperties
    {
        [PreserveSig]
        new int SetPropertyNum([MarshalAs(UnmanagedType.LPWStr)] string pName, int lValue);

        [PreserveSig]
        new int GetPropertyNum([MarshalAs(UnmanagedType.LPWStr)] string pName, out int plValue);

        [PreserveSig]
        new int SetPropertyString([MarshalAs(UnmanagedType.LPWStr)] string pName, [MarshalAs(UnmanagedType.LPWStr)] string pValue);

        [PreserveSig]
        new int GetPropertyString([MarshalAs(UnmanagedType.LPWStr)] string pName, [MarshalAs(UnmanagedType.LPWStr)] out string ppCoMemValue);

        void SetRecognizer(ISpObjectToken pRecognizer);

        void GetRecognizer(out ISpObjectToken ppRecognizer);

        void SetInput([MarshalAs(UnmanagedType.IUnknown)] object pUnkInput, [MarshalAs(UnmanagedType.Bool)] bool fAllowFormatChanges);

        void Slot8();

        void Slot9();

        void CreateRecoContext(out ISpRecoContext ppNewCtxt);

        void Slot11();

        void Slot12();

        void Slot13();

        void GetRecoState(out SPRECOSTATE pState);

        void SetRecoState(SPRECOSTATE NewState);

        void GetStatus(out SPRECOGNIZERSTATUS pStatus);

        void GetFormat(SPSTREAMFORMATTYPE WaveFormatType, out Guid pFormatId, out IntPtr ppCoMemWFEX);

        void IsUISupported([MarshalAs(UnmanagedType.LPWStr)] string pszTypeOfUI, IntPtr pvExtraData, uint cbExtraData, [MarshalAs(UnmanagedType.Bool)] out bool pfSupported);

        [PreserveSig]
        int DisplayUI(IntPtr hWndParent, [MarshalAs(UnmanagedType.LPWStr)] string pszTitle, [MarshalAs(UnmanagedType.LPWStr)] string pszTypeOfUI, IntPtr pvExtraData, uint cbExtraData);

        [PreserveSig]
        int EmulateRecognition(ISpPhrase pPhrase);
    }
}
