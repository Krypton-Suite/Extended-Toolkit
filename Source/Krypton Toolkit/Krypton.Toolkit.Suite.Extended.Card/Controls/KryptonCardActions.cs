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
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Card;

/// <summary>
/// Card actions section for hosting action buttons.
/// </summary>
[ToolboxItem(false)]
public class KryptonCardActions : KryptonCardSection
{
    private readonly FlowLayoutPanel _flow;
    private CardActionsAlignment _alignment = CardActionsAlignment.End;

    /// <summary>
    /// Initializes a new instance of the <see cref="KryptonCardActions"/> class.
    /// </summary>
    public KryptonCardActions()
        : base(new Padding(
            CardMetrics.ActionsHorizontalPadding,
            CardMetrics.ActionsVerticalPadding,
            CardMetrics.ActionsHorizontalPadding,
            CardMetrics.ActionsVerticalPadding))
    {
        AutoSize = true;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        Dock = DockStyle.Bottom;

        _flow = new FlowLayoutPanel
        {
            AutoSize = true,
            AutoSizeMode = AutoSizeMode.GrowAndShrink,
            Dock = DockStyle.Fill,
            FlowDirection = FlowDirection.LeftToRight,
            Margin = Padding.Empty,
            WrapContents = true,
            Padding = Padding.Empty,
        };

        Controls.Add(_flow);
        _flow.ControlAdded += (_, _) => NotifyOwnerContentChanged();
        _flow.ControlRemoved += (_, _) => NotifyOwnerContentChanged();
        ApplyAlignment();
    }

    /// <summary>
    /// Gets the collection of action controls.
    /// </summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Control.ControlCollection ActionControls => _flow.Controls;

    /// <summary>
    /// Gets the design-time actions panel.
    /// </summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    internal Control DesignPanel => _flow;

    /// <summary>
    /// Applies right-to-left layout to action buttons.
    /// </summary>
    internal void ApplyRtl(bool rtl)
    {
        if (rtl)
        {
            _flow.FlowDirection = _alignment == CardActionsAlignment.End
                ? FlowDirection.LeftToRight
                : FlowDirection.RightToLeft;
        }
        else
        {
            ApplyAlignment();
        }
    }

    /// <summary>
    /// Gets or sets the horizontal alignment of action buttons.
    /// </summary>
    [Category(@"Layout")]
    [DefaultValue(CardActionsAlignment.End)]
    public CardActionsAlignment Alignment
    {
        get => _alignment;
        set
        {
            if (_alignment == value)
            {
                return;
            }

            _alignment = value;
            ApplyAlignment();
        }
    }

    /// <inheritdoc />
    internal override bool IsSectionEmpty() => _flow.Controls.Count == 0;

    private void ApplyAlignment()
    {
        _flow.FlowDirection = _alignment == CardActionsAlignment.End
            ? FlowDirection.RightToLeft
            : FlowDirection.LeftToRight;
    }
}
