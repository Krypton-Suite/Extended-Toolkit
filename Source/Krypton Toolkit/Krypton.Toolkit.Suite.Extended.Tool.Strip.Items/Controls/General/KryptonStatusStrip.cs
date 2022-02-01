#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Tool.Strip.Items
{
    public class KryptonStatusStrip : StatusStrip
    {
        #region Variables
        private bool _useAsProgressBar;

        private Color _barColour, _shadeColour;

        private float _maximumValue, _minimumValue, _currentValue;

        private ToolStripProgressBar _progressBar;
        #endregion

        #region Properties
        [DefaultValue(false), Description("Use the status strip as a progressbar.")]
        public bool UseAsProgressBar { get => _useAsProgressBar; set { _useAsProgressBar = value; Invalidate(); } }

        [Description("The colour of the Progress Bar"), Category("Progress Bar"), DefaultValue(typeof(Color), "Color.ForestGreen")]
        public Color BarColour { get => _barColour; set { _barColour = value; Invalidate(); } }

        [Description("The shade colour of the Progress Bar"), Category("Progress Bar"), DefaultValue(typeof(Color), "Color.LightGreen")]
        public Color BarShade { get => _shadeColour; set { _shadeColour = value; Invalidate(); } }

        [Description("The current value for the Progress Bar, in the range specified by the minimum and maximum properties"), Category("Progress Bar"), DefaultValue(0.0F)]
        public float CurrentValue
        {
            get => _currentValue;

            set
            {
                _currentValue = value;

                if (_currentValue < _minimumValue)
                {
                    _currentValue = _minimumValue;
                }

                if (_currentValue > _maximumValue)
                {
                    _currentValue = _maximumValue;
                }

                Invalidate();
            }
        }

        [Description("The upper bound of the range the Progress Bar is working with"), Category("Progress Bar"), DefaultValue(100.0F)]
        public float MaximumValue
        {
            get => _maximumValue;

            set
            {
                _maximumValue = value;

                if (_maximumValue < _minimumValue)
                {
                    _minimumValue = _maximumValue;
                }

                if (_maximumValue < _currentValue)
                {
                    _currentValue = _maximumValue;
                }

                Invalidate();
            }
        }

        [Description("The lower bound of the range the Progress Bar is working with"), Category("Progress Bar"), DefaultValue(0.0F)]
        public float MinimumValue
        {
            get => _minimumValue;

            set
            {
                _minimumValue = value;

                if (_minimumValue > _maximumValue)
                {
                    _maximumValue = _minimumValue;
                }

                if (_minimumValue > _currentValue)
                {
                    _currentValue = _minimumValue;
                }

                Invalidate();
            }
        }

        public ToolStripProgressBar ProgressBar { get => _progressBar; set => _progressBar = value; }
        #endregion

        #region Constructor
        public KryptonStatusStrip()
        {
            RenderMode = ToolStripRenderMode.ManagerRenderMode;
        }
        #endregion

        #region Overrides
        protected override void OnRendererChanged(EventArgs e)
        {
            try
            {
                // This is too buggy!!!
                //if (ToolStripManager.Renderer is KryptonProfessionalRenderer kpr)
                //{
                //    ProgressBar.BackColor = kpr.KCT.StatusStripGradientEnd;
                //}
            }
            catch (Exception ex)
            {

            }

            base.OnRendererChanged(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            float progressPercent = (float)(_currentValue / (_maximumValue - _minimumValue));

            if (_useAsProgressBar)
            {
                RenderMode = ToolStripRenderMode.System;

                if (progressPercent > 0)
                {
                    RectangleF progressRectangle = e.Graphics.VisibleClipBounds;

                    progressRectangle.Width *= progressPercent;

                    LinearGradientBrush lgb = new LinearGradientBrush(progressRectangle, _barColour, _shadeColour, LinearGradientMode.Horizontal);

                    e.Graphics.FillRectangle(lgb, progressRectangle);

                    lgb.Dispose();
                }
            }
            else
            {
                RenderMode = ToolStripRenderMode.ManagerRenderMode;
            }

            base.OnPaint(e);
        }
        #endregion
    }
}