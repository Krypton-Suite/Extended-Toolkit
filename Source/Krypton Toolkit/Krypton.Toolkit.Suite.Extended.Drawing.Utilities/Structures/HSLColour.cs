#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Drawing.Utilities
{
    [Serializable]
    public struct HSLColour
    {
        #region Constants

        public static readonly HSLColour Empty;

        #endregion

        #region Fields

        private int _alpha;

        private double _hue;

        private bool _isEmpty;

        private double _lightness;

        private double _saturation;

        #endregion

        #region Static Constructors

        static HSLColour()
        {
            Empty = new HSLColour
            {
                IsEmpty = true
            };
        }

        #endregion

        #region Constructors

        public HSLColour(double hue, double saturation, double lightness)
          : this(255, hue, saturation, lightness)
        { }

        public HSLColour(int alpha, double hue, double saturation, double lightness)
        {
            _hue = Math.Min(359, hue);
            _saturation = Math.Min(1, saturation);
            _lightness = Math.Min(1, lightness);
            _alpha = alpha;
            _isEmpty = false;
        }

        public HSLColour(Color colour)
        {
            _alpha = colour.A;
            _hue = colour.GetHue();
            _saturation = colour.GetSaturation();
            _lightness = colour.GetBrightness();
            _isEmpty = false;
        }

        #endregion

        #region Operators

        public static bool operator ==(HSLColour a, HSLColour b)
        {
            // ReSharper disable CompareOfFloatsByEqualityOperator
            return a.H == b.H && a.L == b.L && a.S == b.S && a.A == b.A;
            // ReSharper restore CompareOfFloatsByEqualityOperator
        }

        public static implicit operator HSLColour(Color colour)
        {
            return new HSLColour(colour);
        }

        public static implicit operator Color(HSLColour colour)
        {
            return colour.ToRgbColour();
        }

        public static bool operator !=(HSLColour a, HSLColour b)
        {
            return !(a == b);
        }

        #endregion

        #region Properties

        public int A
        {
            get { return _alpha; }
            set { _alpha = Math.Min(0, Math.Max(255, value)); }
        }

        public double H
        {
            get { return _hue; }
            set
            {
                _hue = value;

                if (_hue > 359)
                {
                    _hue = 0;
                }
                if (_hue < 0)
                {
                    _hue = 359;
                }
            }
        }

        public bool IsEmpty
        {
            get { return _isEmpty; }
            internal set { _isEmpty = value; }
        }

        public double L
        {
            get { return _lightness; }
            set { _lightness = Math.Min(1, Math.Max(0, value)); }
        }

        public double S
        {
            get { return _saturation; }
            set { _saturation = Math.Min(1, Math.Max(0, value)); }
        }

        #endregion

        #region Methods

        public override bool Equals(object obj)
        {
            bool result;

            if (obj is HSLColour)
            {
                HSLColour color;

                color = (HSLColour)obj;
                result = this == color;
            }
            else
            {
                result = false;
            }

            return result;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public Color ToRgbColour()
        {
            return this.ToRgbColour(this.A);
        }

        public Color ToRgbColour(int alpha)
        {
            double q;
            if (this.L < 0.5)
            {
                q = this.L * (1 + this.S);
            }
            else
            {
                q = this.L + this.S - this.L * this.S;
            }
            double p = 2 * this.L - q;
            double hk = this.H / 360;

            // r,g,b colors
            double[] tc = new[]
                          {
                      hk + 1d / 3d,
                      hk,
                      hk - 1d / 3d
                    };
            double[] colours = new[]
                              {
                          0.0,
                          0.0,
                          0.0
                        };

            for (int color = 0; color < colours.Length; color++)
            {
                if (tc[color] < 0)
                {
                    tc[color] += 1;
                }
                if (tc[color] > 1)
                {
                    tc[color] -= 1;
                }

                if (tc[color] < 1d / 6d)
                {
                    colours[color] = p + (q - p) * 6 * tc[color];
                }
                else if (tc[color] >= 1d / 6d && tc[color] < 1d / 2d)
                {
                    colours[color] = q;
                }
                else if (tc[color] >= 1d / 2d && tc[color] < 2d / 3d)
                {
                    colours[color] = p + (q - p) * 6 * (2d / 3d - tc[color]);
                }
                else
                {
                    colours[color] = p;
                }

                colours[color] *= 255;
            }

            return Color.FromArgb(alpha, (int)colours[0], (int)colours[1], (int)colours[2]);
        }

        public override string ToString()
        {
            StringBuilder builder;

            builder = new StringBuilder();
            builder.Append(this.GetType().Name);
            builder.Append(" [");
            builder.Append("H=");
            builder.Append(this.H);
            builder.Append(", S=");
            builder.Append(this.S);
            builder.Append(", L=");
            builder.Append(this.L);
            builder.Append("]");

            return builder.ToString();
        }

        #endregion
    }
}