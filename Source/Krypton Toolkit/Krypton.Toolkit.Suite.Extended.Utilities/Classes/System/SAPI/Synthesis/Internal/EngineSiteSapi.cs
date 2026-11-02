#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis;

[ComVisible(true)]
internal class EngineSiteSapi : ISpEngineSite
{
    private enum WaveFormatId
    {
        Pcm = 1,
        Alaw = 6,
        Mulaw = 7
    }

    private EngineSite _site;

    internal EngineSiteSapi(EngineSite site, ResourceLoader resourceLoader)
    {
        _site = site;
    }

    void ISpEngineSite.AddEvents([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] SpeechEventSapi[] eventsSapi, int ulCount)
    {
        SpeechEventInfo[] array = new SpeechEventInfo[eventsSapi.Length];
        for (int i = 0; i < eventsSapi.Length; i++)
        {
            SpeechEventSapi speechEventSapi = eventsSapi[i];
            array[i].EventId = speechEventSapi.EventId;
            array[i].ParameterType = speechEventSapi.ParameterType;
            array[i].Param1 = (int)speechEventSapi.Param1;
            array[i].Param2 = speechEventSapi.Param2;
        }
        _site.AddEvents(array, ulCount);
    }

    void ISpEngineSite.GetEventInterest(out long eventInterest)
    {
        eventInterest = (uint)_site.EventInterest;
    }

    [PreserveSig]
    int ISpEngineSite.GetActions()
    {
        return _site.Actions;
    }

    void ISpEngineSite.Write(IntPtr pBuff, int cb, IntPtr pcbWritten)
    {
        pcbWritten = (IntPtr)_site.Write(pBuff, cb);
    }

    void ISpEngineSite.GetRate(out int pRateAdjust)
    {
        pRateAdjust = _site.Rate;
    }

    void ISpEngineSite.GetVolume(out short pusVolume)
    {
        pusVolume = (short)_site.Volume;
    }

    void ISpEngineSite.GetSkipInfo(out int peType, out int plNumItems)
    {
        SkipInfo skipInfo = _site.GetSkipInfo();
        if (skipInfo != null)
        {
            peType = skipInfo.Type;
            plNumItems = skipInfo.Count;
        }
        else
        {
            peType = 1;
            plNumItems = 0;
        }
    }

    void ISpEngineSite.CompleteSkip(int ulNumSkipped)
    {
        _site.CompleteSkip(ulNumSkipped);
    }

    void ISpEngineSite.LoadResource(string uri, ref string? mediaType, out IStream? stream)
    {
        mediaType = null;
        try
        {
            Stream stream2 = _site.LoadResource(new Uri(uri, UriKind.RelativeOrAbsolute), mediaType);
            BinaryReader br = new BinaryReader(stream2);
            byte[]? waveFormat = AudioBase.GetWaveFormat(br);
            mediaType = null;
            if (waveFormat != null)
            {
                WAVEFORMATEX wAVEFORMATEX = WAVEFORMATEX.ToWaveHeader(waveFormat);
                WaveFormatId wFormatTag = (WaveFormatId)wAVEFORMATEX.wFormatTag;
                if (wFormatTag == WaveFormatId.Pcm || (uint)(wFormatTag - 6) <= 1u)
                {
                    mediaType = "audio/x-wav";
                }
            }
            stream2.Position = 0L;
            stream = new SpStreamWrapper(stream2);
        }
        catch
        {
            stream = null;
        }
    }
}