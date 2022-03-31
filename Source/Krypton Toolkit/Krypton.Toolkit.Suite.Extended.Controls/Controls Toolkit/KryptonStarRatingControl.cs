#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System.Collections.Generic;

namespace Krypton.Toolkit.Suite.Extended.Controls
{
    [ToolboxBitmap(typeof(Panel))]
    public class KryptonStarRatingControl : Panel
    {
        private Container _components;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        Color _firstColour = Color.Red;
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("Color.Red")]
        public Color FirstColour
        {
            get { return _firstColour; }
            set { _firstColour = value; ReInit(); Invalidate(); }
        }

        Color _secondColour = Color.Blue;
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("Color.Blue")]
        public Color SecondColour
        {
            get { return _secondColour; }
            set { _secondColour = value; ReInit(); Invalidate(); }
        }

        Color _thirdColour = Color.Green;
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("Color.Green")]
        public Color ThirdColour
        {
            get { return _thirdColour; }
            set { _thirdColour = value; ReInit(); Invalidate(); }
        }

        int _firstColourQuantity = 2;
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("2")]
        public int FirstColourQuantity
        {
            get { return _firstColourQuantity; }
            set { _firstColourQuantity = value; ReInit(); Invalidate(); }
        }

        int _secondColourQuantity = 1;
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("1")]
        public int SecondColourQuantity
        {
            get { return _secondColourQuantity; }
            set { _secondColourQuantity = value; ReInit(); Invalidate(); }
        }

        int _thirdColourQuantity = 2;
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("2")]
        public int ThirdColourQuantity
        {
            get { return _thirdColourQuantity; }
            set { _thirdColourQuantity = value; ReInit(); Invalidate(); }
        }

        int _starSize = 15;
        [Browsable(true), Category("Appearance-Extended")]
        [DefaultValue("15")]
        public int StartSize
        {
            get { return _starSize; }
            set { _starSize = value; ReInit(); Invalidate(); }
        }

        public new int Width { get; private set; }
        public new int Height { get; private set; }

        private Image _offImage;
        [Browsable(true), Category("Appearance-Extended")]
        public Image OffImage
        {
            set
            {
                _offImage = value;
                SetUpStars();
            }
        }

        private List<Image> _onImages;
        [Browsable(true), Category("Appearance-Extended")]
        public List<Image> OnImages
        {
            set
            {
                _onImages = value;
                SetUpStars();
            }
        }

        private int _starCount;
        [Browsable(true), Category("Appearance-Extended")]
        public int StarCount
        {
            get { return _starCount; }
            set
            {
                _starCount = value;
                SetUpStars();
            }
        }

        private int _currentStarValue;
        [Browsable(true), Category("Appearance-Extended")]
        public int CurrentStarValue
        {
            get { return _currentStarValue; }
            set
            {
                _currentStarValue = value;
                DrawCurrentState(_currentStarValue);
            }
        }

        private int _starHalfSize = 7;

        public KryptonStarRatingControl()
        {
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            UpdateStyles();

            BackColor = Color.Transparent;

            Height = _starSize;
            Width = _starSize;
            _starCount = 5;

            ReInit();
        }

        private void ReInit()
        {
            _starHalfSize = (int)(_starSize / 2);
            InitializeComponent();
            InitGrayStars();
            SetUpStars();
        }

        private void InitGrayStars()
        {
            _offImage = new Bitmap(DrawStar(_starSize, _starHalfSize, _starHalfSize, _starHalfSize, Color.LightGray, Color.Gray, false));
            _onImages = LoadDefaultImages();
        }

        private void SetUpStars()
        {
            AddTheStars();
            DrawCurrentState(_currentStarValue);
            SetControlSize();
        }

        private void AddTheStars()
        {
            Controls.Clear();
            for (var x = 0; x < _starCount; x++)
            {
                Controls.Add(new Star(x + 1, _offImage, _onImages[Math.Min(_onImages.Count - 1, x)],
                                      starNumber => _currentStarValue = _currentStarValue == starNumber ? 0 : starNumber,
                                      DrawCurrentState,
                                      (starNumber) => DrawCurrentState(_currentStarValue)
                                 ));
            }
        }

        private void DrawCurrentState(int starNumber)
        {
            //base.Controls.Cast<Star>().ToList().ForEach(s => s.ToggleStar(starNumber));
            foreach (Control ctrl in this.Controls)
            {
                Star s = ctrl as Star;
                if (s != null) s.ToggleStar(starNumber);
            }
        }

        private void SetControlSize()
        {
            base.Width = Width = _offImage.Width * _starCount;
            base.Height = Height = _offImage.Height;
        }

        private List<Image> LoadDefaultImages()
        {
            //var red = new Bitmap(GetType(), "StarOnRed.bmp");
            var red = new Bitmap(DrawStar(_starSize, _starHalfSize, _starHalfSize, _starHalfSize, ControlPaint.LightLight(_firstColour), _firstColour, false));
            var blue = new Bitmap(DrawStar(_starSize, _starHalfSize, _starHalfSize, _starHalfSize, ControlPaint.LightLight(_secondColour), _secondColour, false));
            var green = new Bitmap(DrawStar(_starSize, _starHalfSize, _starHalfSize, _starHalfSize, ControlPaint.LightLight(_thirdColour), _thirdColour, false));
            List<Image> list = new List<Image>();

            for (int i = 0; i < _firstColourQuantity; i++) list.Add(red);
            for (int k = 0; k < _secondColourQuantity; k++) list.Add(blue);
            for (int j = 0; j < _thirdColourQuantity; j++) list.Add(green);

            return list;

        }

        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
        {
            base.SetBoundsCore(x, y, Width, Height, specified);
        }


        public static Bitmap DrawStar(int size, float radius, float xCenter, float yCenter, Color fillColor, Color borderColor, bool isHalfStar)
        {
            //now when you draw with g, you actually draw on bmp. You can put the image in the picture box to see what you are drawing on mouse move events.
            //And then later, if you want you can save the pretty picture you created using bmp.Save(); 
            Bitmap bmp = new Bitmap(size, size);
            Graphics g = Graphics.FromImage(bmp);

            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Only Half, exclude half region
            if (isHalfStar)
            {
                Rectangle rect = new Rectangle((int)(size / 2), 0, size, size);
                Region rg = new Region(rect);
                g.ExcludeClip(rg);
            }

            // radius: determines the size of the star.
            // xCenter, yCenter: determine the location of the star.
            float sin36 = (float)Math.Sin(36.0 * Math.PI / 180.0);
            float sin72 = (float)Math.Sin(72.0 * Math.PI / 180.0);
            float cos36 = (float)Math.Cos(36.0 * Math.PI / 180.0);
            float cos72 = (float)Math.Cos(72.0 * Math.PI / 180.0);
            float r1 = radius * cos72 / cos36;

            // Compute the star:
            PointF[] pts = new PointF[10];
            pts[0] = new PointF(xCenter, yCenter - radius);
            pts[1] = new PointF(xCenter + r1 * sin36, yCenter - r1 * cos36);
            pts[2] = new PointF(xCenter + radius * sin72, yCenter - radius * cos72);
            pts[3] = new PointF(xCenter + r1 * sin72, yCenter + r1 * cos72);
            pts[4] = new PointF(xCenter + radius * sin36, yCenter + radius * cos36);
            pts[5] = new PointF(xCenter, yCenter + r1);
            pts[6] = new PointF(xCenter - radius * sin36, yCenter + radius * cos36);
            pts[7] = new PointF(xCenter - r1 * sin72, yCenter + r1 * cos72);
            pts[8] = new PointF(xCenter - radius * sin72, yCenter - radius * cos72);
            pts[9] = new PointF(xCenter - r1 * sin36, yCenter - r1 * cos36);

            //Fill the star
            g.FillPolygon(new SolidBrush(fillColor), pts);

            // Only Half, reset region for the border
            if (isHalfStar) { g.ResetClip(); }

            // Draw Border
            g.DrawPolygon(new Pen(borderColor), pts);

            //return
            return bmp;
        }



        #region Component Designer generated code

        private void InitializeComponent()
        {
            _components = new Container();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_components != null)
                    _components.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion
    }
}