#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2026 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Tool.Strip.Items;

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
            // Note: This is too buggy!!!
            //if (ToolStripManager.Renderer is KryptonProfessionalRenderer kpr)
            //{
            //    ProgressBar.BackColor = kpr.KCT.StatusStripGradientEnd;
            //}
        }
        catch (Exception ex)
        {
            DebugUtilities.NotImplemented(ex.ToString());
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