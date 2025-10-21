#region MIT License
/*
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

#region Original MIT License

/*
 * Source code for _PasswordTextBox Control_ is Copyright © 2016
 * [Nils Jonsson][mail] and [contributors][contributors].
 *  
 * Permission is hereby granted, free of charge, to any person obtaining a copy of
 * this software and associated documentation files (the “Software”), to deal in the
 * Software without restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the
 * Software, and to permit persons to whom the Software is furnished to do so,
 * subject to the following conditions:
 *  
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *  
 * THE SOFTWARE IS PROVIDED “AS IS,” WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
 * FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
 * COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN
 * AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
 * WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 *  
 * [mail]:         mailto:passwordtextbox@nilsjonsson.com                           "send email to Nils Jonsson"
 * [contributors]: https://github.com/njonsson/PasswordTextBox-Control/contributors "PasswordTextBox Control contributors at GitHub"   
 */

#endregion

namespace Krypton.Toolkit.Suite.Extended.Controls;

[DefaultProperty("PasswordCharDelay")]
[Description("Enables the user to enter password input, momentarily showing each character entered.")]
[ToolboxBitmap(typeof(KryptonTextBox))]
[ToolboxItem(true)]
public class KryptonPasswordTextBox : KryptonTextBox
{
    #region Instance Fields

    private char _passwordChar;
    private int _passwordCharDelay;
    private string _textPrevious;
    private ITimer? _timer;

    #endregion

    #region Functions

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static Func<bool> IsFontSmoothingEnabled = () => SystemInformation.IsFontSmoothingEnabled;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static Func<Control, IGraphics> NewGraphics = self => new GraphicsExtended(self);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static Func<Color, ISolidBrush> NewSolidBrush = color => new SolidBrushExtended(color);

    [EditorBrowsable(EditorBrowsableState.Never)]
    public static Func<bool, double, ISynchronizeInvoke, ITimer> NewTimer = (autoReset, interval, synchronizingObject) => new TimerExtended(autoReset, interval, synchronizingObject);

    #endregion

    #region Constants


    /// <summary>
    /// The default value of <see cref="PasswordChar"/>.
    /// </summary>
    public const char DefaultPasswordChar = '\0';

    /// <summary>
    /// The default value of <see cref="PasswordCharDelay"/>.
    /// </summary>
    public const int DefaultPasswordCharDelay = 1000;

    /// <summary>
    /// The default value of <see cref="UseSystemPasswordChar"/>.
    /// </summary>
    public const bool DefaultUseSystemPasswordChar = true;

    #endregion

    #region Identity

    public KryptonPasswordTextBox()
    {
        _passwordChar = DefaultPasswordChar;

        _passwordCharDelay = DefaultPasswordCharDelay;

        base.UseSystemPasswordChar = DefaultUseSystemPasswordChar;

        SetUpTimer(true);
    }

    #endregion

    #region Events

    /// <summary>
    /// Occurs before the <see cref="PasswordChar"/> property value changes.
    /// </summary>
    public event EventHandler<CancelChangeEventArgs<char>> PasswordCharChanging;

    /// <summary>
    /// Occurs when the <see cref="PasswordChar"/> property value changes.
    /// </summary>
    public event EventHandler<ChangeEventArgs<char>> PasswordCharChanged;

    /// <summary>
    /// Occurs before the <see cref="PasswordCharDelay"/> property value
    /// changes.
    /// </summary>
    public event EventHandler<CancelChangeEventArgs<int>> PasswordCharDelayChanging;

    /// <summary>
    /// Occurs when the <see cref="PasswordCharDelay"/> property value
    /// changes.
    /// </summary>
    public event EventHandler<ChangeEventArgs<int>> PasswordCharDelayChanged;

    /// <summary>
    /// Occurs before the <see cref="UseSystemPasswordChar"/> property value
    /// changes.
    /// </summary>
    public event EventHandler<CancelChangeEventArgs<bool>> UseSystemPasswordCharChanging;

    /// <summary>
    /// Occurs when the <see cref="UseSystemPasswordChar"/> property value
    /// changes.
    /// </summary>
    public event EventHandler<ChangeEventArgs<bool>> UseSystemPasswordCharChanged;

    #endregion

    #region Hidden Properties

    /*[Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Multiline
    {
        get { return base.Multiline; }

        set
        {
            if (value)
            {
                throw new ArgumentException($"{GetType().FullName} does not support Multiline.");
            }
        }
    }*/

    #endregion

    #region Public

    /// <summary>
    /// Gets or sets the character used to mask characters of a password in
    /// a <see cref="KryptonPasswordTextBox"/> control.
    /// </summary>
    /// <returns>A <see cref="char"/>. Set the value of this property to
    /// <c>'\0'</c> (character value) if you do not want the control to mask
    /// characters as they are typed. Equals 0 (character value) by default.</returns>
    [DefaultValue(DefaultPasswordChar)]
    [Description("Indicates the character to display for password input in a KryptonPasswordTextBox control.")]
    public new char PasswordChar
    {
        get => _passwordChar;

        set
        {
            if ((_passwordChar == value) && (base.PasswordChar == value))
            {
                return;
            }

            var eventArgs = CancelChangeEventArgs<char>.DoIf(this,
                PasswordCharChanging,
                OnPasswordCharChanging,
                PasswordChar,
                value);
            if (eventArgs.Cancel)
            {
                return;
            }

            var oldValue = PasswordChar;
            _passwordChar = base.PasswordChar = value;
            ChangeEventArgs<char>.DoIf(this,
                PasswordCharChanged,
                OnPasswordCharChanged,
                oldValue,
                PasswordChar);
        }
    }

    /// <summary>
    /// Gets or sets the time in milliseconds during which password input is
    /// legible before appearing as the password character.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">Value is less than or
    /// equal to zero.</exception>
    [Category("Behavior")]
    [DefaultValue(DefaultPasswordCharDelay)]
    [Description("Indicates the time in milliseconds during which password input is legible before appearing as the password character.")]
    public int PasswordCharDelay
    {
        get => _passwordCharDelay;

        set
        {
            var t = _timer;
            if (ReferenceEquals(t, null))
            {
                System.Diagnostics.Debug.WriteLine($"Ignoring {GetType().FullName}#PasswordCharDelay property setting {value} at:");
#if DEBUG
                    Utilities.DebugWithIndentation(() => Utilities.DebugStackTrace());
#endif
                return;
            }

            if ((_passwordCharDelay == value) && ((int)t.Interval == value))
            {
                return;
            }

            var eventArgs = CancelChangeEventArgs<int>.DoIf(this,
                PasswordCharDelayChanging,
                OnPasswordCharDelayChanging,
                PasswordCharDelay,
                value);
            if (eventArgs.Cancel)
            {
                return;
            }

            try
            {
                t.Interval = value;
            }
            catch (ArgumentException)
            {
                throw new ArgumentOutOfRangeException(null,
                    value,
                    @"Must be greater than zero.");
            }

            var oldValue = PasswordCharDelay;
            _passwordCharDelay = value;
            ChangeEventArgs<int>.DoIf(this,
                PasswordCharDelayChanged,
                OnPasswordCharDelayChanged,
                oldValue,
                PasswordCharDelay);
        }
    }

    /// <summary>
    /// Computes the password character actually in effect, based on the
    /// values of <see cref="UseSystemPasswordChar"/> and
    /// <see cref="PasswordChar"/>.
    /// </summary>
    /// <returns>A <see cref="char"/>.</returns>
    [Browsable(false)]
    public char PasswordCharEffective =>
        // ReSharper disable once ConvertPropertyToExpressionBody
        UseSystemPasswordChar ? base.PasswordChar : _passwordChar;

    /// <summary>
    /// Gets or sets a value indicating whether the text in the
    /// <see cref="KryptonPasswordTextBox"/> control should appear as the default
    /// password character.
    /// </summary>
    [DefaultValue(DefaultUseSystemPasswordChar)]
    [Description("Indicates if the text in the KryptonPasswordTextBox control should appear as the default password character.")]
    public new bool UseSystemPasswordChar
    {
        get => base.UseSystemPasswordChar;

        set
        {
            if (base.UseSystemPasswordChar == value)
            {
                return;
            }

            var eventArgs = CancelChangeEventArgs<bool>.DoIf(this,
                UseSystemPasswordCharChanging,
                OnUseSystemPasswordCharChanging,
                UseSystemPasswordChar,
                value);
            if (eventArgs.Cancel)
            {
                return;
            }

            var oldValue = UseSystemPasswordChar;
            base.UseSystemPasswordChar = value;
            ChangeEventArgs<bool>.DoIf(this,
                UseSystemPasswordCharChanged,
                OnUseSystemPasswordCharChanged,
                oldValue,
                UseSystemPasswordChar);
        }
    }

    #endregion

    #region Overrides

    /// <summary>
    /// Disposes unmanaged resources and, optionally, managed resources.
    /// </summary>
    /// <param name="disposing">If <c>true</c>, managed resources will be
    /// disposed.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            SetUpTimer(false);
        }

        base.Dispose(disposing);
    }

    #endregion

    #region Virtuals

    /// <summary>
    /// Raises the <see cref="PasswordCharChanged"/> event with the
    /// specified <see cref="ChangeEventArgs{T}"/> of <see cref="char"/>.
    /// </summary>
    /// <param name="e">A <see cref="ChangeEventArgs{T}"/> of
    /// <see cref="char"/>.</param>
    /// <exception cref="ArgumentNullException"><paramref name="e"/> is
    /// <c>null</c>.</exception>>
    protected virtual void OnPasswordCharChanged(ChangeEventArgs<char> e)
    {
        if (ReferenceEquals(e, null))
        {
            throw new ArgumentNullException(nameof(e));
        }

        if (!ReferenceEquals(PasswordCharChanged, null))
        {
            PasswordCharChanged(this, e);
        }
    }

    /// <summary>
    /// Raises the <see cref="PasswordCharChanging"/> event with the
    /// specified <see cref="CancelChangeEventArgs{T}"/> of
    /// <see cref="char"/>.
    /// </summary>
    /// <param name="e">A <see cref="CancelChangeEventArgs{T}"/> of
    /// <see cref="char"/>.</param>
    /// <exception cref="ArgumentNullException"><paramref name="e"/> is
    /// <c>null</c>.</exception>>
    protected virtual void OnPasswordCharChanging(CancelChangeEventArgs<char> e)
    {
        if (ReferenceEquals(e, null))
        {
            throw new ArgumentNullException(nameof(e));
        }

        if (!ReferenceEquals(PasswordCharChanging, null))
        {
            PasswordCharChanging(this, e);
        }
    }

    /// <summary>
    /// Raises the <see cref="PasswordCharDelayChanged"/> event with the
    /// specified <see cref="ChangeEventArgs{T}"/> of <see cref="int"/>.
    /// </summary>
    /// <param name="e">A <see cref="ChangeEventArgs{T}"/> of
    /// <see cref="int"/>.</param>
    /// <exception cref="ArgumentNullException"><paramref name="e"/> is
    /// <c>null</c>.</exception>>
    protected virtual void OnPasswordCharDelayChanged(ChangeEventArgs<int> e)
    {
        if (ReferenceEquals(e, null))
        {
            throw new ArgumentNullException(nameof(e));
        }

        if (!ReferenceEquals(PasswordCharDelayChanged, null))
        {
            PasswordCharDelayChanged(this, e);
        }
    }

    /// <summary>
    /// Raises the <see cref="PasswordCharDelayChanging"/> event with the
    /// specified <see cref="CancelChangeEventArgs{T}"/> of
    /// <see cref="int"/>.
    /// </summary>
    /// <param name="e">A <see cref="CancelChangeEventArgs{T}"/> of
    /// <see cref="int"/>.</param>
    /// <exception cref="ArgumentNullException"><paramref name="e"/> is
    /// <c>null</c>.</exception>>
    protected virtual void OnPasswordCharDelayChanging(CancelChangeEventArgs<int> e)
    {
        if (ReferenceEquals(e, null))
        {
            throw new ArgumentNullException(nameof(e));
        }

        if (!ReferenceEquals(PasswordCharDelayChanging, null))
        {
            PasswordCharDelayChanging(this, e);
        }
    }

    /// <summary>
    /// Raises the <see cref="UseSystemPasswordCharChanged"/> event with the
    /// specified <see cref="ChangeEventArgs{T}"/> of <see cref="bool"/>.
    /// </summary>
    /// <param name="e">A <see cref="ChangeEventArgs{T}"/> of
    /// <see cref="bool"/>.</param>
    /// <exception cref="ArgumentNullException"><paramref name="e"/> is
    /// <c>null</c>.</exception>>
    protected virtual void OnUseSystemPasswordCharChanged(ChangeEventArgs<bool> e)
    {
        if (ReferenceEquals(e, null))
        {
            throw new ArgumentNullException(nameof(e));
        }

        if (!ReferenceEquals(UseSystemPasswordCharChanged, null))
        {
            UseSystemPasswordCharChanged(this, e);
        }
    }

    /// <summary>
    /// Raises the <see cref="UseSystemPasswordCharChanging"/> event with
    /// the specified <see cref="CancelChangeEventArgs{T}"/> of
    /// <see cref="bool"/>.
    /// </summary>
    /// <param name="e">A <see cref="CancelChangeEventArgs{T}"/> of
    /// <see cref="bool"/>.</param>
    /// <exception cref="ArgumentNullException"><paramref name="e"/> is
    /// <c>null</c>.</exception>>
    protected virtual void OnUseSystemPasswordCharChanging(CancelChangeEventArgs<bool> e)
    {
        if (ReferenceEquals(e, null))
        {
            throw new ArgumentNullException(nameof(e));
        }

        if (!ReferenceEquals(UseSystemPasswordCharChanging, null))
        {
            UseSystemPasswordCharChanging(this, e);
        }
    }

    #endregion

    #region Overrides

    /// <summary>
    /// Raises the <see cref="TextBox.TextChanged"/> event with the
    /// specified <see cref="EventArgs"/>.
    /// </summary>
    /// <param name="e">An <see cref="EventArgs"/>.</param>
    /// <exception cref="ArgumentNullException"><paramref name="e"/> is
    /// <c>null</c>.</exception>>
    protected override void OnTextChanged(EventArgs e)
    {
        if (ReferenceEquals(e, null))
        {
            throw new ArgumentNullException(nameof(e));
        }

        _timer?.Stop();
        _timer?.Start();

        var text = Text;
        if ((0 < text.Length) &&
            (text.Length <= SelectionStart) &&
            ((_textPrevious).Length < text.Length))
        {
            PaintUnobscured(text.Substring(text.Length - 1, 1),
                text.Length - 1);
        }
        _textPrevious = text;

        base.OnTextChanged(e);
    }

    #endregion

    #region Protected

    /// <summary>
    /// Paints the specified <paramref name="string"/> at the specified
    /// <paramref name="position"/>.
    /// </summary>
    /// <param name="string">A <see cref="string"/>.</param>
    /// <param name="position"></param>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="position"/>
    /// is less than zero or not less than
    /// <see cref="KryptonPasswordTextBox.TextLength"/>.</exception>
    protected void PaintUnobscured(string @string, int position)
    {
        if ((position < 0) || (TextLength <= position))
        {
            throw new ArgumentOutOfRangeException(nameof(position),
                position,
                @"Must be greater than or equal to 0 and less than the value of TextLength.");
        }

        // If we're not obscuring the text at all then there's no need
        // to paint unobscured text over it.
        if (PasswordCharEffective == '\0')
        {
            return;
        }

        if (string.IsNullOrEmpty(@string))
        {
            return;
        }

        using (var graphics = NewGraphics(this))
        {
            if (IsFontSmoothingEnabled())
            {
                graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            }
            using (var foreBrush = NewSolidBrush(ForeColor))
            {
                using (var backBrush = NewSolidBrush(BackColor))
                {
                    var obscuredNewText = new string(PasswordCharEffective,
                        @string.Length);
                    var sizeOfObscuredNewText = graphics.MeasureString(obscuredNewText,
                        Font);
                    var point = GetPositionFromCharIndex(position);
                    point.Offset(-(int)Math.Round(Math.Pow(Font.SizeInPoints, 0.15)),
                        (int)Math.Round(Math.Pow(Font.SizeInPoints, 0.05)));

                    graphics.FillRectangle(backBrush,
                        new RectangleF(point,
                            sizeOfObscuredNewText));
                    graphics.DrawString(@string, Font, foreBrush, point);
                }
            }
        }
    }

    #endregion

    #region Implementation

    private void SetUpTimer(bool settingUp)
    {
        if (settingUp)
        {
            System.Diagnostics.Debug.Assert(ReferenceEquals(_timer, null));

            _timer = NewTimer(false, PasswordCharDelay, this);
            _timer.Elapsed += timer_Elapsed;
        }
        else
        {
            _timer?.Dispose();
            _timer = null;
        }
    }

    // ReSharper disable once InconsistentNaming
    private void timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        Invalidate();
    }

    #endregion
}