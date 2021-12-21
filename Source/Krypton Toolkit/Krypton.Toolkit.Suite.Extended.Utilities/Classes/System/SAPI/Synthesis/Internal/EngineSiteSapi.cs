#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using Krypton.Toolkit.Suite.Extended.Utilities.System.Internal;
using Krypton.Toolkit.Suite.Extended.Utilities.System.SAPIInterop;
using Krypton.Toolkit.Suite.Extended.Utilities.System.TTSEngine;

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.Synthesis
{
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

        void ISpEngineSite.LoadResource(string uri, ref string mediaType, out IStream stream)
        {
            mediaType = null;
            try
            {
                Stream stream2 = _site.LoadResource(new Uri(uri, UriKind.RelativeOrAbsolute), mediaType);
                BinaryReader br = new BinaryReader(stream2);
                byte[] waveFormat = AudioBase.GetWaveFormat(br);
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
}