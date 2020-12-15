#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Base
{
    /// <summary>
    /// A toggle switch.
    /// Boilerplate code from: https://github.com/aalitor/AltoControls/blob/on-development/AltoControls/Controls/SwitchButton.cs
    /// </summary>
    [DefaultEvent("SliderValueChanged"), ToolboxItem(true)]
    public class KryptonToggleSwitchOld : Control
    {
        public delegate void SliderChangedEventHandler(object sender, EventArgs e);
        public event SliderChangedEventHandler SliderValueChanged;

        #region Variables
        private float _diameter, _artis;
        private RoundedRectangleF _rect;
        private RectangleF _circle;
        private bool _isOn, _textEnabled, _useGradientOnKnob;
        private Color _borderColour, _textEnabledForeColour, _textDisabledForeColour,
                      _enabledBackColour, _disabledBackColour, _disabledControlColour,
                      _knobColour, _penColour, _gradientStartColour,
                      _gradientEndColour;
        private Timer _paintTicker = new Timer();
        private LinearGradientMode _mode;
        private string _onText, _offText;
        #endregion

        #region Properties
        [Description("Shows or hides the slider text.")]
        public bool TextEnabled
        {
            get => _textEnabled;

            set
            {
                _textEnabled = value;
                Invalidate();
            }
        }

        public bool IsOn
        {
            get => _isOn;

            set
            {
                _paintTicker.Stop();

                _isOn = value;

                _paintTicker.Start();

                if (SliderValueChanged != null)
                    SliderValueChanged(this, EventArgs.Empty);
            }
        }

        public bool UseGradientOnKnob
        {
            get => _useGradientOnKnob;

            set
            {
                _useGradientOnKnob = value;

                Invalidate();
            }
        }

        public Color BorderColour
        {
            get => _borderColour;

            set
            {
                _borderColour = value;

                Invalidate();
            }
        }

        public Color TextEnabledForeColour
        {
            get => _textEnabledForeColour;

            set
            {
                _textEnabledForeColour = value;

                Invalidate();
            }
        }

        public Color TextDisabledForeColour
        {
            get => _textDisabledForeColour;

            set
            {
                _textDisabledForeColour = value;

                Invalidate();
            }
        }

        public Color EnabledBackColour
        {
            get => _enabledBackColour;

            set
            {
                _enabledBackColour = value;

                Invalidate();
            }
        }

        public Color DisabledBackColour
        {
            get => _disabledBackColour;

            set
            {
                _disabledBackColour = value;

                Invalidate();
            }
        }

        public Color DisabledControlColour
        {
            get => _disabledControlColour;

            set
            {
                _disabledControlColour = value;

                Invalidate();
            }
        }

        public Color KnobColour
        {
            get => _knobColour;

            set
            {
                _knobColour = value;

                Invalidate();
            }
        }

        public Color PenColour
        {
            get => _penColour;

            set
            {
                _penColour = value;

                Invalidate();
            }
        }

        public Color GradientStartColour
        {
            get => _gradientStartColour;

            set
            {
                _gradientStartColour = value;

                Invalidate();
            }
        }

        public Color GradientEndColour
        {
            get => _gradientEndColour;

            set
            {
                _gradientEndColour = value;

                Invalidate();
            }
        }

        public LinearGradientMode GradientMode
        {
            get => _mode;

            set
            {
                _mode = value;

                Invalidate();
            }
        }

        public string OnText
        {
            get => _onText;

            set
            {
                _onText = value;

                Invalidate();
            }
        }

        public string OffText
        {
            get => _offText;

            set
            {
                _offText = value;

                Invalidate();
            }
        }
        #endregion

        #region Constructor
        public KryptonToggleSwitchOld()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            Cursor = Cursors.Hand;
            DoubleBuffered = true;

            BackColor = Color.Transparent;

            Font = new Font("Segoe UI", 9f);

            _artis = 4; //increment for sliding animation

            _diameter = 30;

            TextEnabled = true;

            _rect = new RoundedRectangleF(2 * _diameter, _diameter + 2, _diameter / 2, 1, 1);

            _circle = new RectangleF(1, 1, _diameter, _diameter);

            IsOn = true;

            BorderColour = Color.LightGray;

            UseGradientOnKnob = true;

            TextEnabledForeColour = Color.Gray;

            TextDisabledForeColour = Color.White;

            EnabledBackColour = Color.LightGreen;

            DisabledBackColour = Color.Red;

            PenColour = Color.LightGray;

            DisabledControlColour = Color.LightGray;

            KnobColour = Color.White;

            GradientStartColour = Color.FromArgb(187, 206, 230);

            GradientEndColour = Color.FromArgb(132, 157, 189);

            GradientMode = LinearGradientMode.ForwardDiagonal;

            OnText = "On";

            OffText = "Off";

            _paintTicker.Tick += paintTicker_Tick;
            _paintTicker.Interval = 1;
        }
        #endregion

        protected override void OnEnabledChanged(EventArgs e)
        {
            Invalidate();
            base.OnEnabledChanged(e);
        }
        protected override void OnResize(EventArgs e)
        {
            float textSize = Font.Size;

            Width = (Height - 2) * 2;
            _diameter = Width / 2;
            _artis = 4 * _diameter / 30;
            _rect = new RoundedRectangleF(2 * _diameter, _diameter + 2, _diameter / 2, 1, 1);
            _circle = new RectangleF(!_isOn ? 1 : Width - _diameter - 1, 1, _diameter, _diameter);

            Font = Font;

            base.OnResize(e);
        }

        //creates slide animation
        private void paintTicker_Tick(object sender, EventArgs e)
        {
            float x = _circle.X;

            if (_isOn)           //switch the circle to the left
            {
                if (x + _artis <= Width - _diameter - 1)
                {
                    x += _artis;
                    _circle = new RectangleF(x, 1, _diameter, _diameter);

                    Invalidate();

                    IsOn = true;
                }
                else
                {
                    x = Width - _diameter - 1;
                    _circle = new RectangleF(x, 1, _diameter, _diameter);

                    Invalidate();
                    _paintTicker.Stop();

                    IsOn = false;
                }

            }
            else //switch the circle to the left with animation
            {
                if (x - _artis >= 1)
                {
                    x -= _artis;
                    _circle = new RectangleF(x, 1, _diameter, _diameter);

                    Invalidate();

                    IsOn = true;
                }
                else
                {
                    x = 1;
                    _circle = new RectangleF(x, 1, _diameter, _diameter);

                    Invalidate();
                    _paintTicker.Stop();

                    IsOn = false;
                }
            }
        }

        protected override Size DefaultSize
        {
            get
            {
                return new Size(60, 35);
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            if (Enabled)
            {
                using (SolidBrush brush = new SolidBrush(IsOn ? EnabledBackColour : DisabledBackColour))
                    e.Graphics.FillPath(brush, _rect.Path);

                using (Pen pen = new Pen(BorderColour, 2f))
                    e.Graphics.DrawPath(pen, _rect.Path);

                string on = OnText, off = OffText;

                SolidBrush onColour = new SolidBrush(TextEnabledForeColour), offBrush = new SolidBrush(TextDisabledForeColour);

                if (TextEnabled)
                    using (Font font = new Font(Font.FontFamily, Font.Size * _diameter / 30, Font.Style))
                    {
                        int height = TextRenderer.MeasureText(on, font).Height;
                        float y = (_diameter - height) / 2f;
                        e.Graphics.DrawString(on, font, onColour, 5, y + 1);

                        height = TextRenderer.MeasureText(off, font).Height;
                        y = (_diameter - height) / 2f;
                        e.Graphics.DrawString(off, font, offBrush, _diameter + 2, y + 1);
                    }

                if (UseGradientOnKnob)
                {
                    using (LinearGradientBrush lgb = new LinearGradientBrush(_circle, GradientStartColour, GradientEndColour, GradientMode))
                    {
                        e.Graphics.FillEllipse(lgb, _circle);
                    }
                }
                else
                {
                    using (SolidBrush circleBrush = new SolidBrush(KnobColour))
                    {
                        e.Graphics.FillEllipse(circleBrush, _circle);
                    }
                }

                using (Pen pen = new Pen(PenColour, 1.2f))
                    e.Graphics.DrawEllipse(pen, _circle);

            }
            else
            {
                using (SolidBrush disableBrush = new SolidBrush(DisabledControlColour))
                using (SolidBrush ellBrush = new SolidBrush(DisabledBackColour))
                {
                    e.Graphics.FillPath(disableBrush, _rect.Path);
                    e.Graphics.FillEllipse(ellBrush, _circle);
                    e.Graphics.DrawEllipse(Pens.DarkGray, _circle);
                }
            }

            base.OnPaint(e);

        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            _isOn = !_isOn;
            IsOn = _isOn;

            base.OnMouseClick(e);
        }
    }
}