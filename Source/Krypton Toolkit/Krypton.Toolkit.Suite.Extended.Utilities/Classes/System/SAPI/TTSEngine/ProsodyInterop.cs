#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.TTSEngine
{
    internal struct ProsodyInterop
    {
        internal ProsodyNumber _pitch;

        internal ProsodyNumber _range;

        internal ProsodyNumber _rate;

        internal int _duration;

        internal ProsodyNumber _volume;

        internal IntPtr _contourPoints;

        internal static IntPtr ProsodyToPtr(Prosody prosody, Collection<IntPtr> memoryBlocks)
        {
            if (prosody == null)
            {
                return IntPtr.Zero;
            }
            ProsodyInterop prosodyInterop = default(ProsodyInterop);
            prosodyInterop._pitch = prosody.Pitch;
            prosodyInterop._range = prosody.Range;
            prosodyInterop._rate = prosody.Rate;
            prosodyInterop._duration = prosody.Duration;
            prosodyInterop._volume = prosody.Volume;
            ContourPoint[] contourPoints = prosody.GetContourPoints();
            if (contourPoints != null)
            {
                int num = Marshal.SizeOf((object)contourPoints[0]);
                prosodyInterop._contourPoints = Marshal.AllocCoTaskMem(contourPoints.Length * num);
                memoryBlocks.Add(prosodyInterop._contourPoints);
                for (uint num2 = 0u; num2 < contourPoints.Length; num2++)
                {
                    Marshal.StructureToPtr((object)contourPoints[num2], (IntPtr)((long)prosodyInterop._contourPoints + num * num2), false);
                }
            }
            else
            {
                prosodyInterop._contourPoints = IntPtr.Zero;
            }
            IntPtr intPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf((object)prosodyInterop));
            memoryBlocks.Add(intPtr);
            Marshal.StructureToPtr((object)prosodyInterop, intPtr, false);
            return intPtr;
        }
    }
}
