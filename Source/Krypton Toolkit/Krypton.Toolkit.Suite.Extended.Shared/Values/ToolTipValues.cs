#region MIT License
/*
 *
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.Shared;

/// <summary>
/// What will be Displayed in the designer
/// </summary>
[ToolboxItem(false)]
[DesignerCategory(@"code")]
public class ToolTipValues : HeaderValues
{
    private LabelStyle _toolTipStyle;

    /// <summary>
    /// Initializes a new instance of the <see cref="ToolTipValues"/> class.
    /// </summary>
    /// <param name="needPaint">Delegate for notifying paint requests.</param>
    /// <param name="getDpiFactor"></param>
    public ToolTipValues(NeedPaintHandler needPaint, GetDpiFactor getDpiFactor)
        : base(needPaint, getDpiFactor)
    {
        ResetToolTipStyle();
        ToolTipPosition = new PopupPositionValues();
    }

    /// <summary>
    /// 
    /// </summary>
    public void Reset()
    {
        ResetEnableToolTips();
        ResetToolTipStyle();
        ResetToolTipPosition();
        ResetImage();
        ResetImageTransparentColor();
        ResetHeading();
        ResetDescription();
    }

    /// <summary>
    /// Make sure default values are         
    /// Gets and sets the EnableToolTips
    /// </summary>
    [DefaultValue(false)]
    public bool EnableToolTips { get; set; }

    private bool ShouldSerializeEnableToolTips() => EnableToolTips;

    /// <inheritdoc />
    protected override Image? GetImageDefault() => null;

    /// <summary>
    /// 
    /// </summary>
    public void ResetEnableToolTips()
    {
        EnableToolTips = false;
    }

    #region ToolTipShadow
    /// <summary>
    /// Gets and sets the tooltip label style.
    /// </summary>
    [Category(@"ToolTip")]
    [Description(@"Button tooltip Shadow.")]
    [DefaultValue(true)]
    public bool ToolTipShadow { get; set; } = true; // Backward compatible -> "Material Design" suggests this to be false

    private bool ShouldSerializeToolTipShadow() => !ToolTipShadow;

    private void ResetToolTipShadow()
    {
        ToolTipShadow = true;
    }
    #endregion

    /// <summary>
    /// Gets and sets the EnableToolTips
    /// </summary>
    [Description(@"The orientation of the ToolTip control when it opens, and specifies how the ToolTip control behaves when it overlaps screen boundaries.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public PopupPositionValues ToolTipPosition { get; set; }

    private bool ShouldSerializeToolTipPosition() => !ToolTipPosition.IsDefault;

    /// <summary>
    /// Resets the ToolTipStyle property to its default value.
    /// </summary>
    public void ResetToolTipPosition() => ToolTipPosition.Reset();

    #region ToolTipStyle

    /// <summary>
    /// Gets and sets the tooltip label style.
    /// </summary>
    [Description(@"Button tooltip label style.")]
    [DefaultValue(typeof(LabelStyle), "SuperTip")]
    public LabelStyle ToolTipStyle
    {
        get => _toolTipStyle;
        set => _toolTipStyle = value;
    }

    private bool ShouldSerializeToolTipStyle() => ToolTipStyle != LabelStyle.SuperTip;

    /// <summary>
    /// Resets the ToolTipStyle property to its default value.
    /// </summary>
    public void ResetToolTipStyle()
    {
        ToolTipStyle = LabelStyle.SuperTip;
    }
    #endregion

    #region IsDefault
    /// <summary>
    /// Gets a value indicating if all values are default.
    /// </summary>
    [Browsable(false)]
    public override bool IsDefault => !ShouldSerializeEnableToolTips()
                                      && !ShouldSerializeToolTipStyle()
                                      && !ShouldSerializeToolTipPosition()
                                      && base.IsDefault
    ;


    #endregion

}