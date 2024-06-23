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

namespace Krypton.Toolkit.Suite.Extended.Controls
{
    /// <summary>
    /// Provides methods for safely avoiding the needless construction of
    /// <see cref="EventArgs"/> descendent objects and needless calls to
    /// event-raising <c>OnEVENTNAME</c> methods.
    /// </summary>
    public static class Event
    {
        /// <summary>
        /// Invokes the specified
        /// <paramref name="constructEventArgsAndCallEventRaisingMethod"/>
        /// function (unless <paramref name="sender"/> is strictly an instance of
        /// <typeparamref name="TSender"/> and <paramref name="event"/> is
        /// <c>null</c>).
        /// </summary>
        /// <typeparam name="TSender">The type of <paramref name="sender"/> for
        /// which not to invoke the
        /// <paramref name="constructEventArgsAndCallEventRaisingMethod"/>
        /// function.</typeparam>
        /// <typeparam name="TEventArgs">The type of
        /// <see cref="EventArgs"/>.</typeparam>
        /// <param name="sender">The <paramref name="event"/> sender.</param>
        /// <param name="event">An <see cref="EventHandler{TEventArgs}"/> of
        /// <typeparamref name="TEventArgs"/>.</param>
        /// <param name="constructEventArgsAndCallEventRaisingMethod">A
        /// <see cref="Func{T}"/> of <typeparamref name="TEventArgs"/> that
        /// constructs a <typeparamref name="TEventArgs"/> and calls an
        /// event-raising method with it.</param>
        /// <returns>The return value of
        /// <paramref name="constructEventArgsAndCallEventRaisingMethod"/>, if
        /// invoked, otherwise, <c>null</c>.</returns>
        /// <exception cref="ArgumentNullException"><para><paramref name="sender"/>
        /// is <c>null</c>.</para>
        /// <para>-or-</para>
        /// <para><paramref name="constructEventArgsAndCallEventRaisingMethod"/>
        /// is <c>null</c>.</para></exception>
        public static TEventArgs DoIf<TSender, TEventArgs>(TSender sender,
                                                           EventHandler<TEventArgs?> @event,
                                                           Func<TEventArgs?> constructEventArgsAndCallEventRaisingMethod)
            where TEventArgs : EventArgs
        {
            if (ReferenceEquals(sender, null))
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (ReferenceEquals(constructEventArgsAndCallEventRaisingMethod,
                null))
            {
                throw new ArgumentNullException(nameof(constructEventArgsAndCallEventRaisingMethod));
            }

            // ReSharper disable ArrangeRedundantParentheses
            return ((sender.GetType() == typeof(TSender)) ?
                DoIf(@event, constructEventArgsAndCallEventRaisingMethod) :
                constructEventArgsAndCallEventRaisingMethod())!;
            // ReSharper restore ArrangeRedundantParentheses
        }

        private static TEventArgs DoIf<TEventArgs>(EventHandler<TEventArgs> @event,
                                                   Func<TEventArgs> constructEventArgsAndCallEventRaisingMethod)
            where TEventArgs : EventArgs?
        {
            System.Diagnostics.Debug.Assert(!ReferenceEquals(constructEventArgsAndCallEventRaisingMethod,
                                          null));

            return ReferenceEquals(@event, null) ?
                   default(TEventArgs) :
                   constructEventArgsAndCallEventRaisingMethod?.Invoke();
        }
    }
}