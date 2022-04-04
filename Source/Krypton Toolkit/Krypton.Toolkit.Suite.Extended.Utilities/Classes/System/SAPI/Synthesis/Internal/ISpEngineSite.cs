#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis
{
    [ComImport]
    [Guid("9880499B-CCE9-11D2-B503-00C04F797396")]
    [InterfaceType(1)]
    internal interface ISpEngineSite
    {
        void AddEvents([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] SpeechEventSapi[] events, int count);

        void GetEventInterest(out long eventInterest);

        [PreserveSig]
        int GetActions();

        void Write(IntPtr data, int count, IntPtr bytesWritten);

        void GetRate(out int rate);

        void GetVolume(out short volume);

        void GetSkipInfo(out int type, out int count);

        void CompleteSkip(int skipped);

        void LoadResource([MarshalAs(UnmanagedType.LPWStr)] string resource, ref string mediaType, out IStream stream);
    }
}