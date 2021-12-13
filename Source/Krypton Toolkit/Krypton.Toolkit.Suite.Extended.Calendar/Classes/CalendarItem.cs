#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Drawing;

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
            get
            {
                return _startTime;
            }
            set
            {
                _startTime = value;
            }
        }

        public DateTime EndTime
        {
            get
            {
                return _endTime;
            }
            set
            {
                _endTime = value;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
            }
        }

        public string Key
        {
            get
            {
                return _key;
            }
            set
            {
                _key = value;
            }
        }

        public Color Colour
        {
            get
            {
                return _colour;
            }
            set
            {
                _colour = value;
            }
        }

        public bool IsTentative
        {
            get
            {
                return _isTentative;
            }
            set
            {
                _isTentative = value;
            }
        }
    }
}