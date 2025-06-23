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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.TTSEngine;

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