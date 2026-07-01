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
/// Base class for pre-styled <see cref="KryptonCard"/> sections.
/// </summary>
[ToolboxItem(false)]
public abstract class KryptonCardSection : KryptonPanel
{
    private KryptonCard? _ownerCard;

    /// <summary>
    /// Initializes a new instance of the <see cref="KryptonCardSection"/> class.
    /// </summary>
    /// <param name="padding">Section padding.</param>
    protected KryptonCardSection(Padding padding)
    {
        PanelBackStyle = PaletteBackStyle.PanelClient;
        Padding = padding;
        Margin = Padding.Empty;
        TabStop = false;
    }

    /// <summary>
    /// Gets or sets the owning card control.
    /// </summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    internal KryptonCard? OwnerCard
    {
        get => _ownerCard;
        set => _ownerCard = value;
    }

    /// <summary>
    /// Determines whether the section has no visible content.
    /// </summary>
    internal abstract bool IsSectionEmpty();

    /// <summary>
    /// Notifies the owning card that section content changed.
    /// </summary>
    protected void NotifyOwnerContentChanged() => _ownerCard?.UpdateSectionVisibility();

    /// <inheritdoc />
    protected override void OnControlAdded(ControlEventArgs e)
    {
        base.OnControlAdded(e);
        NotifyOwnerContentChanged();
    }

    /// <inheritdoc />
    protected override void OnControlRemoved(ControlEventArgs e)
    {
        base.OnControlRemoved(e);
        NotifyOwnerContentChanged();
    }
}
