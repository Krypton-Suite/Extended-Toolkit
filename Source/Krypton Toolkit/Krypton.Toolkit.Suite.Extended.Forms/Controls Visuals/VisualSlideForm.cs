using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krypton.Toolkit.Suite.Extended.Forms
{
    public partial class VisualSlideForm : KryptonForm
    {
        #region Instance Fields

        private bool _expand;

        private float _ratio;

        private float _step;

        private readonly KryptonFormExtended? _owner;

        private SlideDirection _slideDirection;

        private SizeF _offset;

        private SizeF _sizeStep;

        private Point _origin;

        #endregion

        #region Public

        public bool IsExpanded => _expand;

        public SlideDirection SlideDirection
        {
            set => _slideDirection = value;
        }

        public float SlideStep
        {
            set => _step = value;
        }

        #endregion

        #region Identity

        public VisualSlideForm(KryptonFormExtended? owner, float step)
        {
            InitializeComponent();

            _owner = owner;

            _ratio = 0.0f;

            _step = step;
        }

        public VisualSlideForm() : this(null, 0)
        {

        }

        #endregion

        #region Implementation

        public void Slide()
        {
            if (!_expand)
            {
                Show();
            }

            _owner?.BringToFront();

            _expand = !_expand;

            tmrSlide.Start();
        }

        private void tmrSlide_Tick(object sender, EventArgs e)
        {
            if (_expand)
            {
                _ratio += _step;

                _offset += _sizeStep;

                if (_ratio > 1)
                {
                    tmrSlide.Stop();
                }
            }
            else
            {
                _ratio -= _step;

                _offset -= _sizeStep;

                if (_ratio <= 0)
                {
                    tmrSlide.Stop();
                }
            }

            UpdateLocation();
        }

        private void UpdateLocation() => Location = _origin + _offset.ToSize();

        private void UpdateSlideLocation()
        {
            if (_owner != null)
            {
                _origin = new Point();

                switch (_slideDirection)
                {
                    case SlideDirection.Top:
                        _origin = _owner.Location;

                        Width = _owner.Width;

                        _sizeStep = new SizeF(0, -Height * _step);
                        break;
                    case SlideDirection.Bottom:
                        _origin.X = _owner.Location.X;

                        _origin.Y = _owner.Location.Y + _owner.Height - Height;

                        Width = _owner.Width;

                        _sizeStep = new SizeF(0, Height * _step);
                        break;
                    case SlideDirection.Left:
                        _origin = _owner.Location;

                        _sizeStep = new SizeF(-Width * _step, 0);

                        Height = _owner.Height;
                        break;
                    case SlideDirection.Right:
                        _origin.X = _owner.Location.X + _owner.Width - Width;

                        _origin.Y = _owner.Location.Y;

                        _sizeStep = new SizeF(Width * _step, 0);

                        Height = _owner.Height;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private void VisualSlideForm_Move(object sender, EventArgs e)
        {
            UpdateSlideLocation();

            UpdateLocation();
        }

        private void VisualSlideForm_Resize(object sender, EventArgs e)
        {
            UpdateSlideLocation();

            UpdateLocation();
        }

        private void VisualSlideForm_Closed(object sender, EventArgs e) => Close();

        #endregion

        #region Protected

        protected override void OnLoad(EventArgs e)
        {
            UpdateSlideLocation();

            UpdateLocation();

            if (_owner != null)
            {
                _owner.LocationChanged += VisualSlideForm_Move;

                _owner.Resize += VisualSlideForm_Resize;

                _owner.Closed += VisualSlideForm_Closed;
            }
        }

        #endregion
    }
}
