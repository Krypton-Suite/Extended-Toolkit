using System.Drawing;

using Microsoft.VisualBasic;

namespace Krypton.Toolkit.Suite.Extended.Calendar.Library
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
        private Color _halfHourEndingColor = Color.FromArgb(117, 184, 174);
        private Color _hourEndingColor = Color.FromArgb(107, 169, 179);
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
        public Color BorderColor
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
        public Color ForeColor
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
        public Color SelectionColor
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
        public Color BackColor
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
        public Color DayBackColor
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
        public Color WorkingColor
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
        public Color NonWorkingColor
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
        public Color HalfHourEndingColor
        {
            get
            {
                return _halfHourEndingColor;
            }
            set
            {
                _halfHourEndingColor = value;
            }
        }
        public Color HourEndingColor
        {
            get
            {
                return _hourEndingColor;
            }
            set
            {
                _hourEndingColor = value;
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
        public Color ItemBackColor
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
        public Color ItemLeftMarginColor
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
        public Color SelectedBackColor
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
        public Color SelectedForeColor
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

        public static Color getDarkColor(Color c, byte d)
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
        public static Color getLightColor(Color c, byte d)
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


        public static Color CheckColorFromNameRGB(string InputColor)
        {
            //return value
            Color ReturnColor = Color.White;
            //try to parse the array
            string[] RGBColorArray = Microsoft.VisualBasic.Strings.Split(InputColor, ",", -1, CompareMethod.Text);
            //is a color name?
            try
            {
                //named color (string)?
                Color NamedColor = System.Drawing.Color.FromName(InputColor);
                if ((NamedColor.A == 0 & NamedColor.R == 0 & NamedColor.G == 0 & NamedColor.B == 0))
                {
                    //is an array?
                    int r = 0;
                    int g = 0;
                    int b = 0;

                    int.TryParse(RGBColorArray[0], out r);
                    int.TryParse(RGBColorArray[1], out g);
                    int.TryParse(RGBColorArray[2], out b);

                    Color RGBColor = System.Drawing.Color.FromArgb(255, r, g, b);

                    if (RGBColor.A == 0 & RGBColor.R == 0 & RGBColor.G == 0 & RGBColor.B == 0)
                    {
                        //input error, return black
                        ReturnColor = Color.White;
                    }
                    else
                    {
                        //return rgb color
                        ReturnColor = RGBColor;
                    }
                }
                else
                {
                    //return string color name
                    ReturnColor = NamedColor;
                }
            }
            catch
            {
                //silent crash
            }
            //return Value
            return ReturnColor;
        }
        #endregion

    }
}