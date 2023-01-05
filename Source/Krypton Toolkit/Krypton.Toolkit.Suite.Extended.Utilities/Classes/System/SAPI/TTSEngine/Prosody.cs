#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2023 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Utilities.System.TTSEngine
{
    [StructLayout(LayoutKind.Sequential)]
    public class Prosody
    {
        internal ProsodyNumber _pitch;

        internal ProsodyNumber _range;

        internal ProsodyNumber _rate;

        internal int _duration;

        internal ProsodyNumber _volume;

        internal ContourPoint[] _contourPoints;

        public ProsodyNumber Pitch
        {
            get => _pitch;
            set => _pitch = value;
        }

        public ProsodyNumber Range
        {
            get => _range;
            set => _range = value;
        }

        public ProsodyNumber Rate
        {
            get => _rate;
            set => _rate = value;
        }

        public int Duration
        {
            get => _duration;
            set => _duration = value;
        }

        public ProsodyNumber Volume
        {
            get => _volume;
            set => _volume = value;
        }

        public ContourPoint[] GetContourPoints()
        {
            return _contourPoints;
        }

        public void SetContourPoints(ContourPoint[] points)
        {
            Helpers.ThrowIfNull(points, "points");
            _contourPoints = (ContourPoint[])points.Clone();
        }

        public Prosody()
        {
            Pitch = new ProsodyNumber(0);
            Range = new ProsodyNumber(0);
            Rate = new ProsodyNumber(0);
            Volume = new ProsodyNumber(-1);
        }

        internal Prosody Clone()
        {
            Prosody prosody = new Prosody();
            prosody._pitch = _pitch;
            prosody._range = _range;
            prosody._rate = _rate;
            prosody._duration = _duration;
            prosody._volume = _volume;
            return prosody;
        }
    }
}
