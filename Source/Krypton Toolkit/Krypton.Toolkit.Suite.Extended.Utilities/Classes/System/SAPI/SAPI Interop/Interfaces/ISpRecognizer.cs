#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
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
