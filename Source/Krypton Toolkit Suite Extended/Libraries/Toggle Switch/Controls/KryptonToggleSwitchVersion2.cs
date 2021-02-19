using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Toggle.Switch
{
    /// <summary>
    /// A toggle switch.
    /// Boilerplate code from: https://github.com/aalitor/AltoControls/blob/on-development/AltoControls/Controls/SwitchButton.cs
    /// </summary>
    [DefaultEvent("SliderValueChanged"), ToolboxItem(true)]
    public class KryptonToggleSwitchVersion2 : Control
    {
        #region Variables
        private float _diameter, _artis;
        private RoundedRectangleF _rect;
        private RectangleF _circle;
        private bool _toggled, _textEnabled, _useGradientOnKnob;
        private Color _borderColour, _textEnabledForeColour, _textDisabledForeColour,
                      _enabledBackColour, _disabledBackColour, _disabledControlColour,
                      _knobColour, _penColour, _gradientStartColour,
                      _gradientEndColour;
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

        public bool Toggled
        {
            get => _toggled;

            set
            {
                _toggled = value;

                SliderValueChangedEventArgs evt = new SliderValueChangedEventArgs(value);

                OnSliderValueChanged(null, evt);
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

        #region Custom Event
        public delegate void SliderValueChangedEventHandler(object sender, SliderValueChangedEventArgs e);

        public event SliderValueChangedEventHandler SliderValueChanged;
        #endregion

        #region Constructor
        public KryptonToggleSwitchVersion2()
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
        }
        #endregion

        #region Protected
        protected void OnSliderValueChanged(object sender, SliderValueChangedEventArgs e) => SliderValueChanged?.Invoke(sender, e);
        #endregion

        #region Events

        #endregion

        #region Methods
        private void Animate(bool toggleValue)          
        {
            float x = _circle.X;

            if (toggleValue)
            {
                if (x + _artis <= Width - _diameter - 1)
                {
                    x += _artis;

                    _circle = new RectangleF(x, 1, _diameter, _diameter);

                    Invalidate();
                }
                else
                {
                    x = Width - _diameter - 1;
                    
                    _circle = new RectangleF(x, 1, _diameter, _diameter);

                    Invalidate();
                }
            }
            else
            {
                if (x - _artis >= 1)
                {
                    x -= _artis;

                    _circle = new RectangleF(x, 1, _diameter, _diameter);

                    Invalidate();
                }
                else
                {
                    x = 1;

                    _circle = new RectangleF(x, 1, _diameter, _diameter);

                    Invalidate();
                }
            }
        }
        #endregion

        #region Krypton

        #endregion

        #region Overrides
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            if (Enabled)
            {
                using (SolidBrush brush = new SolidBrush(_toggled ? _enabledBackColour : _disabledBackColour))
                {
                    e.Graphics.FillPath(brush, _rect.Path);
                }

                using (Pen pen = new Pen(_borderColour, 2f))
                {
                    e.Graphics.DrawPath(pen, _rect.Path);
                }

                string onText = _onText, offText = _offText;

                SolidBrush onBrushColour = new SolidBrush(_textEnabledForeColour), offBrushColour = new SolidBrush(_textDisabledForeColour);

                if (_textEnabled)
                {
                    using (Font font = new Font(Font.FontFamily, Font.Size * _diameter / 30, Font.Style))
                    {
                        int height = TextRenderer.MeasureText(onText, font).Height;

                        float y = (_diameter - height) / 2f;

                        e.Graphics.DrawString(onText, font, onBrushColour, 5, y + 1);

                        height = TextRenderer.MeasureText(offText, font).Height;

                        y = (_diameter - height) / 2f;

                        e.Graphics.DrawString(offText, font, offBrushColour, _diameter + 2, y + 1);
                    }

                    if (_useGradientOnKnob)
                    {
                        using (LinearGradientBrush lgb = new LinearGradientBrush(_circle, _gradientStartColour, _gradientEndColour, _mode))
                        {
                            e.Graphics.FillEllipse(lgb, _circle);
                        }
                    }
                    else
                    {
                        using (SolidBrush circleBrush = new SolidBrush(_knobColour))
                        {
                            e.Graphics.FillEllipse(circleBrush, _circle);
                        }
                    }

                    using (Pen pen = new Pen(_penColour, 1.2f))
                    {
                        e.Graphics.DrawEllipse(pen, _circle);
                    }
                }
            }
            else
            {
                using (SolidBrush disabledBrush = new SolidBrush(_disabledControlColour))
                {
                    using (SolidBrush ellBrush = new SolidBrush(_disabledBackColour))
                    {
                        e.Graphics.FillPath(disabledBrush, _rect.Path);

                        e.Graphics.FillEllipse(ellBrush, _circle);

                        e.Graphics.DrawEllipse(Pens.DarkGray, _circle);
                    }
                }
            }

            Animate(_toggled);

            base.OnPaint(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }

            _toggled = !_toggled;

            Toggled = _toggled;

            base.OnMouseDown(e);
        }

        protected override Size DefaultSize => new Size(60, 15);
        #endregion
    }
}