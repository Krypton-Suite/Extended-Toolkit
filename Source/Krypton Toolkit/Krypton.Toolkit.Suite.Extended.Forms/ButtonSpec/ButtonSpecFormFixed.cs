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

namespace Krypton.Toolkit.Suite.Extended.Forms;

/// <summary>
/// Implementation for the fixed navigator buttons.
/// </summary>
[TypeConverter(typeof(ButtonSpecFormFixedConverter))]
public abstract class ButtonSpecFormFixed : ButtonSpec
{
    #region Instance Fields

    #endregion

    #region Identity
    /// <summary>
    /// Initialize a new instance of the ButtonSpecFormFixed class.
    /// </summary>
    /// <param name="form">Reference to owning krypton form.</param>
    /// <param name="fixedStyle">Fixed style to use.</param>
    protected ButtonSpecFormFixed(VisualKryptonFormExtended form,
        PaletteButtonSpecStyle fixedStyle)
    {
        Debug.Assert(form != null);

        // Remember back reference to owning navigator.
        KryptonForm = form;

        // Fix the type
        ProtectedType = fixedStyle;
    }
    #endregion

    #region AllowComponent
    /// <summary>
    /// Can a component be associated with the view.
    /// </summary>
    public override bool AllowComponent => false;

    #endregion

    #region KryptonForm
    /// <summary>
    /// Gets access to the owning krypton form.
    /// </summary>
    protected VisualKryptonFormExtended? KryptonForm { get; }

    #endregion

    #region ButtonSpecType
    /// <summary>
    /// Gets and sets the actual type of the button.
    /// </summary>
    public virtual PaletteButtonSpecStyle ButtonSpecType
    {
        get => ProtectedType;
        set => ProtectedType = value;
    }
    #endregion
}