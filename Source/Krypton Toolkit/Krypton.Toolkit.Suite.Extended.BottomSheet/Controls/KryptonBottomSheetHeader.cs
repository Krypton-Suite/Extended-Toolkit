#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2026 - 2026 Krypton Suite
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

namespace Krypton.Toolkit.Suite.Extended.BottomSheet;

/// <summary>
/// Optional header chrome for bottom sheet content with a title and close affordance.
/// </summary>
[ToolboxItem(true)]
[DesignerCategory(@"code")]
[Description(@"Header chrome for bottom sheet content with title and optional close button.")]
public class KryptonBottomSheetHeader : UserControl
{
    private readonly KryptonWrapLabel _titleLabel = new();
    private readonly KryptonButton _closeButton = new();
    private bool _showCloseButton = true;

    /// <summary>
    /// Initializes a new instance of the <see cref="KryptonBottomSheetHeader"/> class.
    /// </summary>
    public KryptonBottomSheetHeader()
    {
        Dock = DockStyle.Top;
        AutoSize = true;
        AutoSizeMode = AutoSizeMode.GrowAndShrink;
        Padding = new Padding(16, 8, 8, 4);
        MinimumSize = new Size(0, 40);

        _titleLabel.AutoSize = false;
        _titleLabel.Dock = DockStyle.Fill;
        _titleLabel.Text = "Bottom sheet";
        _titleLabel.LabelStyle = LabelStyle.TitleControl;
        _titleLabel.TextAlign = ContentAlignment.MiddleLeft;

        _closeButton.Text = string.Empty;
        _closeButton.ButtonStyle = ButtonStyle.LowProfile;
        _closeButton.Dock = DockStyle.Right;
        _closeButton.Size = new Size(36, 36);
        _closeButton.Values.Image = null;
        _closeButton.Values.Text = "X";
        _closeButton.Click += (_, _) => CloseRequested?.Invoke(this, EventArgs.Empty);

        Controls.Add(_titleLabel);
        Controls.Add(_closeButton);
    }

    /// <summary>
    /// Occurs when the close button is clicked.
    /// </summary>
    public event EventHandler? CloseRequested;

    /// <summary>
    /// Gets or sets the header title text.
    /// </summary>
    [Category(@"Appearance")]
    [DefaultValue("Bottom sheet")]
    public string Title
    {
        get => _titleLabel.Text;
        set => _titleLabel.Text = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether the close button is shown.
    /// </summary>
    [Category(@"Appearance")]
    [DefaultValue(true)]
    public bool ShowCloseButton
    {
        get => _showCloseButton;
        set
        {
            _showCloseButton = value;
            _closeButton.Visible = value;
        }
    }

    /// <summary>
    /// Wires the header close button to dismiss the active bottom sheet reference.
    /// </summary>
    public void BindDismiss(KryptonBottomSheetRef sheetRef, object? result = null)
    {
        CloseRequested += (_, _) => sheetRef.Dismiss(result);
    }
}
