#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Drawing;

namespace Krypton.Toolkit.Suite.Extended.Calendar
{
    public class ColourTable
    {

        #region "   Members   "

        private Font _fontStd = new Font("Tahoma", 8);
        private Color _borderColor = Color.FromArgb(6, 80, 70); //Color.Black;
        private SolidBrush _borderBrush = new SolidBrush(Color.FromArgb(6, 80, 70));
        private Color _foreColor = Color.FromArgb(6, 80, 70); //Color.Black;
        private SolidBrush _foreBrush = new SolidBrush(Color.FromArgb(6, 80, 70));
        private Color _separatorDark = Color.FromArgb(76, 118, 112);//ColorTable.BackColorDark;
        private Color _selectionColor = Color.FromArgb(83, 122, 117);//ColorTable.SelectionColor;
        private Color _backColor = Color.FromArgb(194, 225, 222);//ColorTable.BackColor;
        private Color _headerDark = Color.Orange;//ColorTable.HaederDark;
        private Color _headerLight = Color.LightYellow;//ColorTable.HaederLight;
        private Color _headerText = Color.FromArgb(255, 255, 255); //Color.White
        private SolidBrush _headerBrush = new SolidBrush(Color.FromArgb(255, 255, 255));
        private Color _dayBackColor = Color.FromArgb(194, 225, 222);//Color.FromArgb(250, 240, 200)
        private Color _newMonth = Color.FromArgb(141, 197, 190); //ColorTable.NewMonth;
        private Color _currentMonth = Color.FromArgb(199, 227, 223); //ColorTable.CurrentMonth;
        private Color _todayGradient = Color.DarkOrange;
        private SolidBrush _todayGradientBrush = new SolidBrush(Color.DarkOrange);
        private Color _workingColor = Color.FromArgb(226, 238, 237);//Color.LightYellow;
        private Color _nonWorkingColor = Color.FromArgb(184, 215, 212);
        private Color _halfHourEndingColour = Color.FromArgb(117, 184, 174);
        private Color _hourEndingColour = Color.FromArgb(107, 169, 179);
        private Color _leftMarginFillColor = Color.White;
        private Color _itemBackColor = Color.White;
        private Color _itemLeftMarginColor = Color.Blue;
        private Color _selectedBackColor = Color.FromArgb(83, 122, 117);
        private Color _selectedForeColor = Color.FromArgb(6, 80, 70);
        #endregion

        #region "   Constructor   "
        public ColourTable()
        {

        }

        #endregion

        #region "   Properties   "
        public Font FontStd
        {
            get
            {
                return _fontStd;
            }
            set
            {
                _fontStd = value;
            }
        }
        public Color BorderColour
        {
            get
            {
                return _borderColor;
            }
            set
            {
                _borderColor = value;
            }
        }
        public SolidBrush BorderBrush
        {
            get
            {
                return _borderBrush;
            }
            set
            {
                _borderBrush = value;
            }
        }
        public Color ForeColour
        {
            get
            {
                return _foreColor;
            }
            set
            {
                _foreColor = value;
            }
        }
        public SolidBrush ForeBrush
        {
            get
            {
                return _foreBrush;
            }
            set
            {
                _foreBrush = value;
            }
        }
        public Color SeparatorDark
        {
            get
            {
                return _separatorDark;
            }
            set
            {
                _separatorDark = value;
            }
        }
        public Color SelectionColour
        {
            get
            {
                return _selectionColor;
            }
            set
            {
                _selectionColor = value;
            }
        }
        public Color BackColour
        {
            get
            {
                return _backColor;
            }
            set
            {
                _backColor = value;
            }
        }
        public Color HeaderDark
        {
            get
            {
                return _headerDark;
            }
            set
            {
                _headerDark = value;
            }
        }
        public Color HeaderLight
        {
            get
            {
                return _headerLight;
            }
            set
            {
                _headerLight = value;
            }
        }
        public Color HeaderText
        {
            get
            {
                return _headerText;
            }
            set
            {
                _headerText = value;
            }
        }
        public SolidBrush HeaderBrush
        {
            get
            {
                return _headerBrush;
            }
            set
            {
                _headerBrush = value;
            }
        }
        public Color DayBackColour
        {
            get
            {
                return _dayBackColor;
            }
            set
            {
                _dayBackColor = value;
            }
        }
        public Color NewMonth
        {
            get
            {
                return _newMonth;
            }
            set
            {
                _newMonth = value;
            }
        }
        public Color CurrentMonth
        {
            get
            {
                return _currentMonth;
            }
            set
            {
                _currentMonth = value;
            }
        }
        public Color TodayGradient
        {
            get
            {
                return _todayGradient;
            }
            set
            {
                _todayGradient = value;
            }
        }
        public SolidBrush TodayGradientBrush
        {
            get
            {
                return _todayGradientBrush;
            }
            set
            {
                _todayGradientBrush = value;
            }
        }
        public Color WorkingColour
        {
            get
            {
                return _workingColor;
            }
            set
            {
                _workingColor = value;
            }
        }
        public Color NonWorkingColour
        {
            get
            {
                return _nonWorkingColor;
            }
            set
            {
                _nonWorkingColor = value;
            }
        }
        public Color HalfHourEndingColour
        {
            get
            {
                return _halfHourEndingColour;
            }
            set
            {
                _halfHourEndingColour = value;
            }
        }
        public Color HourEndingColour
        {
            get
            {
                return _hourEndingColour;
            }
            set
            {
                _hourEndingColour = value;
            }
        }
        public Color LeftMarginFillColor
        {
            get
            {
                return _leftMarginFillColor;
            }
            set
            {
                _leftMarginFillColor = value;
            }
        }
        public Color ItemBackColour
        {
            get
            {
                return _itemBackColor;
            }
            set
            {
                _itemBackColor = value;
            }
        }
        public Color ItemLeftMarginColour
        {
            get
            {
                return _itemLeftMarginColor;
            }
            set
            {
                _itemLeftMarginColor = value;
            }
        }
        public Color SelectedBackColour
        {
            get
            {
                return _selectedBackColor;
            }
            set
            {
                _selectedBackColor = value;
            }
        }
        public Color SelectedForeColour
        {
            get
            {
                return _selectedForeColor;
            }
            set
            {
                _selectedForeColor = value;
            }
        }
        #endregion
        #region "   Functions   "

        public static Color GetDarkColour(Color c, byte d)
        {
            byte r = 0;
            byte g = 0;
            byte b = 0;

            if ((c.R > d)) r = (byte)(c.R - d);
            if ((c.G > d)) g = (byte)(c.G - d);
            if ((c.B > d)) b = (byte)(c.B - d);

            Color c1 = Color.FromArgb(r, g, b);
            return c1;
        }
        public static Color GetLightColour(Color c, byte d)
        {
            byte r = 255;
            byte g = 255;
            byte b = 255;

            if (((int)c.R + (int)d <= 255)) r = (byte)(c.R + d);
            if (((int)c.G + (int)d <= 255)) g = (byte)(c.G + d);
            if (((int)c.B + (int)d <= 255)) b = (byte)(c.B + d);

            Color c2 = Color.FromArgb(r, g, b);
            return c2;
        }


        public static Color CheckColourFromNameRGB(string inputColour)
        {
            //return value
            Color returnColour = Color.White;
            //try to parse the array
            string[] RGBColorArray = inputColour.Split(',');
            //is a color name?
            try
            {
                //named color (string)?
                Color NamedColor = Color.FromName(inputColour);
                if ((NamedColor.A == 0 & NamedColor.R == 0 & NamedColor.G == 0 & NamedColor.B == 0))
                {
                    //is an array?
                    int r = 0;
                    int g = 0;
                    int b = 0;

                    int.TryParse(RGBColorArray[0], out r);
                    int.TryParse(RGBColorArray[1], out g);
                    int.TryParse(RGBColorArray[2], out b);

                    Color RGBCOlor = Color.FromArgb(255, r, g, b);

                    if (RGBCOlor.A == 0 & RGBCOlor.R == 0 & RGBCOlor.G == 0 & RGBCOlor.B == 0)
                    {
                        //input error, return black
                        returnColour = Color.White;
                    }
                    else
                    {
                        //return rgb color
                        returnColour = RGBCOlor;
                    }
                }
                else
                {
                    //return string color name
                    returnColour = NamedColor;
                }
            }
            catch
            {
                //silent crash
            }
            //return Value
            return returnColour;
        }
        #endregion

    }
}