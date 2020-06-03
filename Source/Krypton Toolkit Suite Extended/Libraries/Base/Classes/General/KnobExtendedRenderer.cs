using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Krypton.Toolkit.Extended.Base
{
    public class KnobExtendedRenderer
    {
        #region Variables
        private KryptonKnobControlEnhanced _knobControlEnhanced;
        #endregion

        #region Property
        public KryptonKnobControlEnhanced KnobControlEnhanced { get => _knobControlEnhanced; set => _knobControlEnhanced = value; }
        #endregion

        #region Constructor
        public KnobExtendedRenderer(KryptonKnobControlEnhanced kryptonKnobControl)
        {
            KnobControlEnhanced = kryptonKnobControl;
        }
        #endregion

        #region Virtual
        public virtual bool DrawBackground(Graphics g, RectangleF r)
        {
            if (KnobControlEnhanced == null) return false;

            Color c = KnobControlEnhanced.BackColor;

            SolidBrush brush = new SolidBrush(c);

            Pen pen = new Pen(c);

            Rectangle tmp = new Rectangle(0, 0, KnobControlEnhanced.Width, KnobControlEnhanced.Height);

            g.DrawRectangle(pen, tmp);

            g.FillRectangle(brush, r);

            brush.Dispose();

            pen.Dispose();

            return true;
        }

        /// <summary>
        /// Draw the scale of the control
        /// </summary>
        /// <param name="Gr"></param>
        /// <param name="rc"></param>
        /// <returns></returns>
        public virtual bool DrawScale(Graphics Gr, RectangleF rc)
        {
            if (this.KnobControlEnhanced == null)
                return false;

            Color cKnob = this.KnobControlEnhanced.ScaleColour, cKnobDark = ColourManager.StepColour(cKnob, 60);

            LinearGradientBrush br = new LinearGradientBrush(rc, cKnobDark, cKnob, 45);

            Gr.FillEllipse(br, rc);

            br.Dispose();

            return true;
        }

        /// <summary>
        /// Draw the KnobControlEnhanced of the control
        /// </summary>
        /// <param name="Gr"></param>
        /// <param name="rc"></param>
        /// <returns></returns>
        public virtual bool DrawKnob(Graphics Gr, RectangleF rc, Color knobColourBegin, Color knobColourEnd, float angleOfGradient = 45, LinearGradientMode gradientMode = LinearGradientMode.ForwardDiagonal)
        {
            if (this.KnobControlEnhanced == null)
                return false;

            //Color cKnob = KnobControlEnhanced.KnobColour, cKnobDark = ColourManager.StepColour(cKnob, 60);

            LinearGradientBrush br = new LinearGradientBrush(rc, knobColourBegin, knobColourEnd, angleOfGradient);

            Gr.FillEllipse(br, rc);

            br.Dispose();

            return true;
        }

        public virtual bool DrawKnobIndicator(Graphics g, RectangleF rc, PointF pos)
        {
            if (this.KnobControlEnhanced == null)
                return false;

            RectangleF _rc = rc;
            _rc.X = pos.X - 4;
            _rc.Y = pos.Y - 4;
            _rc.Width = 8;
            _rc.Height = 8;

            //Color cKnob = this.KnobControlEnhanced.IndicatorColour, cKnobDark = ColourManager.StepColour(cKnob, 60);

            //LinearGradientBrush br = new LinearGradientBrush(_rc, cKnobDark, cKnob, 45);

            //g.FillEllipse(br, _rc);

            //br.Dispose();

            return true;
        }

        public static float GetRadian(float val)
        {
            return (float)(val * Math.PI / 180);
        }


        public static Color GetDarkColour(Color c, byte d)
        {
            byte r = 0;
            byte g = 0;
            byte b = 0;

            if (c.R > d) r = (byte)(c.R - d);
            if (c.G > d) g = (byte)(c.G - d);
            if (c.B > d) b = (byte)(c.B - d);

            Color c1 = Color.FromArgb(r, g, b);
            return c1;
        }
        public static Color GetLightColour(Color c, byte d)
        {
            byte r = 255;
            byte g = 255;
            byte b = 255;

            if (c.R + d < 255) r = (byte)(c.R + d);
            if (c.G + d < 255) g = (byte)(c.G + d);
            if (c.B + d < 255) b = (byte)(c.B + d);

            Color c2 = Color.FromArgb(r, g, b);
            return c2;
        }

        /// <summary>
        /// Method which checks is particular point is in rectangle
        /// </summary>
        /// <param name="p">Point to be Chaecked</param>
        /// <param name="r">Rectangle</param>
        /// <returns>true is Point is in rectangle, else false</returns>
        public static bool IsPointinRectangle(Point p, Rectangle r)
        {
            bool flag = false;
            if (p.X > r.X && p.X < r.X + r.Width && p.Y > r.Y && p.Y < r.Y + r.Height)
            {
                flag = true;
            }
            return flag;

        }
        public static void DrawInsetCircle(ref Graphics g, Rectangle r, Pen p)
        {

            Pen p1 = new Pen(GetDarkColour(p.Color, 50));
            Pen p2 = new Pen(GetLightColour(p.Color, 50));
            for (int i = 0; i < p.Width; i++)
            {
                Rectangle r1 = new Rectangle(r.X + i, r.Y + i, r.Width - i * 2, r.Height - i * 2);
                g.DrawArc(p2, r1, -45, 180);
                g.DrawArc(p1, r1, 135, 180);
            }
        }
        #endregion
    }
}