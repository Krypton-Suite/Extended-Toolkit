#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Calendar.Library
{
    [Serializable]
    public class CalendarItem
    {
        [NonSerialized]
        private DateTime m_startTime = DateTime.MinValue;
        [NonSerialized]
        private DateTime m_endTime = DateTime.MinValue;
        [NonSerialized]
        private string m_description = String.Empty;
        [NonSerialized]
        private bool m_isTentative = false;
        [NonSerialized]
        private string m_key = String.Empty;
        [NonSerialized]
        private Color m_color = Color.White;

        public CalendarItem()
        {
        }

        public CalendarItem(DateTime startTime, DateTime endTime, string description, bool isTentative, string key, string color)
        {
            m_startTime = startTime;
            m_endTime = endTime;
            m_description = description;
            m_isTentative = isTentative;
            m_key = key;

            m_color = ColourTable.CheckColorFromNameRGB(color);
        }

        public DateTime StartTime
        {
            get
            {
                return m_startTime;
            }
            set
            {
                m_startTime = value;
            }
        }

        public DateTime EndTime
        {
            get
            {
                return m_endTime;
            }
            set
            {
                m_endTime = value;
            }
        }

        public string Description
        {
            get
            {
                return m_description;
            }
            set
            {
                m_description = value;
            }
        }

        public string Key
        {
            get
            {
                return m_key;
            }
            set
            {
                m_key = value;
            }
        }

        public Color Colour
        {
            get
            {
                return m_color;
            }
            set
            {
                m_color = value;
            }
        }

        public bool IsTentative
        {
            get
            {
                return m_isTentative;
            }
            set
            {
                m_isTentative = value;
            }
        }
    }
}