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