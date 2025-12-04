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

/// <summary>
/// Provides data for a cancelable value-change event.
/// </summary>
/// <typeparam name="T">The type of value being changed.</typeparam>
public class CancelChangeEventArgs<T> : CancelEventArgs
{
    public static bool operator ==(CancelChangeEventArgs<T> left,
        CancelChangeEventArgs<T> right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(CancelChangeEventArgs<T> left,
        CancelChangeEventArgs<T> right)
    {
        return !Equals(left, right);
    }

    /// <summary>
    /// Invokes the specified <paramref name="callEventRaisingMethod"/> (unless
    /// <paramref name="sender"/> is strictly an instance of
    /// <typeparamref name="TSender"/> and <paramref name="event"/> is
    /// <c>null</c>) with a new <see cref="CancelChangeEventArgs{T}"/>
    /// having the specified <paramref name="oldValue"/> and
    /// <paramref name="newValue"/>.
    /// </summary>
    /// <remarks>This can be used for safely avoiding the needless
    /// construction of <see cref="CancelChangeEventArgs{T}"/> objects and
    /// needless calls to event-raising <c>OnVALUEChanging</c>
    /// methods.</remarks>
    /// <typeparam name="TSender">The type of <paramref name="sender"/>
    /// ignored.</typeparam>
    /// <param name="sender">The <paramref name="event"/> sender.</param>
    /// <param name="event">An <see cref="EventHandler{TEventArgs}"/> of
    /// <see cref="CancelChangeEventArgs{T}"/>.</param>
    /// <param name="callEventRaisingMethod">An <see cref="Action{T}"/> of
    /// <see cref="CancelChangeEventArgs{T}"/>> that calls an event-raising
    /// method.</param>
    /// <param name="oldValue">The desired value of
    /// <see cref="OldValue"/>.</param>
    /// <param name="newValue">The desired value of
    /// <see cref="NewValue"/>.</param>
    /// <returns>A new <see cref="CancelChangeEventArgs{T}"/> if
    /// <paramref name="callEventRaisingMethod"/> is invoked, otherwise
    /// <c>null</c>.</returns>
    /// <exception cref="ArgumentNullException"><para><paramref name="sender"/>
    /// is <c>null</c>.</para>
    /// <para>-or-</para>
    /// <para><paramref name="callEventRaisingMethod"/> is
    /// <c>null</c>.</para></exception>
    public static CancelChangeEventArgs<T> DoIf<TSender>(TSender sender,
        EventHandler<CancelChangeEventArgs<T>> @event,
        Action<CancelChangeEventArgs<T>> callEventRaisingMethod,
        T oldValue,
        T newValue)
    {
        if (ReferenceEquals(callEventRaisingMethod, null))
        {
            throw new ArgumentNullException(nameof(callEventRaisingMethod));
        }

        return Event.DoIf(sender, @event!, delegate
        {
            var eventArgs = new CancelChangeEventArgs<T>(oldValue, newValue);
            callEventRaisingMethod(eventArgs);
            return eventArgs;
        });
    }

    /// <summary>
    /// A <see cref="ChangeEventArgs{T}"/> of <typeparamref name="T"/> that
    /// persists <see cref="OldValue"/> and <see cref="NewValue"/>.
    /// </summary>
    protected readonly ChangeEventArgs<T> ChangeEventArgs;

    /// <summary>
    /// Instantiates a new <see cref="CancelChangeEventArgs{T}"/> with the
    /// specified properties.
    /// </summary>
    /// <param name="oldValue">The desired value of
    /// <see cref="OldValue"/>.</param>
    /// <param name="newValue">The desired value of
    /// <see cref="NewValue"/>.</param>
    public CancelChangeEventArgs(T oldValue, T newValue)
    {
        ChangeEventArgs = new ChangeEventArgs<T>(oldValue, newValue);
    }

    /// <summary>
    /// Instantiates a new <see cref="CancelChangeEventArgs{T}"/> with the
    /// specified properties.
    /// </summary>
    /// <param name="oldValue">The desired value of
    /// <see cref="OldValue"/>.</param>
    /// <param name="newValue">The desired value of
    /// <see cref="NewValue"/>.</param>
    /// <param name="cancel">The desired value of
    /// <see cref="CancelEventArgs.Cancel"/>.</param>
    public CancelChangeEventArgs(T oldValue, T newValue, bool cancel) :
        base(cancel)
    {
        ChangeEventArgs = new ChangeEventArgs<T>(oldValue, newValue);
    }

    /// <summary>
    /// The value after the change.
    /// </summary>
    public T NewValue => ChangeEventArgs.NewValue;

    /// <summary>
    /// The value before the change.
    /// </summary>
    public T OldValue => ChangeEventArgs.OldValue;

    public override bool Equals(object? other)
    {
        return Equals(other as CancelChangeEventArgs<T>);
    }

    public bool Equals(CancelChangeEventArgs<T>? other)
    {
        if (ReferenceEquals(null, other)) return false;

        if (ReferenceEquals(this, other)) return true;

        return EqualityComparer<T>.Default.Equals(NewValue,
                   other.NewValue) &&
               EqualityComparer<T>.Default.Equals(OldValue, other.OldValue);
    }

    [SuppressMessage("ReSharper", "NonReadonlyMemberInGetHashCode")]
    public override int GetHashCode()
    {
        unchecked
        {
            return (EqualityComparer<T>.Default.GetHashCode(NewValue) *
                    397) ^
                   EqualityComparer<T>.Default.GetHashCode(OldValue);
        }
    }
}