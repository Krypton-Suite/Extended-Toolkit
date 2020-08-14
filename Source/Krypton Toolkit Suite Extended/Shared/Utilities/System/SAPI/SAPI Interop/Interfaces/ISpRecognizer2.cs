using System;
using System.Runtime.InteropServices;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop
{
    [ComImport, Guid("8FC6D974-C81E-4098-93C5-0147F61ED4D3"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ISpRecognizer2
    {
        [PreserveSig]
        int EmulateRecognitionEx(ISpPhrase pPhrase, uint dwCompareFlags);

        void SetTrainingState(bool fDoingTraining, bool fAdaptFromTrainingData);

        void ResetAcousticModelAdaptation();
    }
}