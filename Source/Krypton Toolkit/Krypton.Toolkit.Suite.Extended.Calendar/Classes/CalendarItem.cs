#region MIT License
/*
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

namespace Krypton.Toolkit.Suite.Extended.Calendar
{
    [Serializable]
    public class CalendarItem
    {
        [NonSerialized]
        private DateTime _startTime = DateTime.MinValue;
        [NonSerialized]
        private DateTime _endTime = DateTime.MinValue;
        [NonSerialized]
        private string _description = string.Empty;
        [NonSerialized]
        private bool _isTentative = false;
        [NonSerialized]
        private string _key = string.Empty;
        [NonSerialized]
        private Color _colour = Color.White;

        public CalendarItem()
        {
        }

        public CalendarItem(DateTime startTime, DateTime endTime, string description, bool isTentative, string key, string colour)
        {
            _startTime = startTime;
            _endTime = endTime;
            _description = description;
            _isTentative = isTentative;
            _key = key;

            _colour = ColourTable.CheckColourFromNameRGB(colour);
        }

        public DateTime StartTime
        {
            get => _startTime;
            set => _startTime = value;
        }

        public DateTime EndTime
        {
            get => _endTime;
            set => _endTime = value;
        }

        public string Description
        {
            get => _description;
            set => _description = value;
        }

        public string Key
        {
            get => _key;
            set => _key = value;
        }

        public Color Colour
        {
            get => _colour;
            set => _colour = value;
        }

        public bool IsTentative
        {
            get => _isTentative;
            set => _isTentative = value;
        }
    }
}